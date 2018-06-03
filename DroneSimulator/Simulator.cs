using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using DronePost.DataModel;
using DroneService;
using DroneSimulator.CoreServiceReference;

namespace DroneSimulator
{
    public class Simulator
    {
        private readonly IMessageHandlerDrone _messageHandler;
        private readonly List<Drone> _drones;
        private readonly CoreServiceClient _coreServiceClient;
        private List<ServiceHost> _hosts;
        private bool _started;

        public Simulator(IMessageHandlerDrone messageHandler)
        {
            _messageHandler = messageHandler;
            _drones = new List<Drone>();
            _coreServiceClient = new CoreServiceClient();
            _hosts = new List<ServiceHost>();
        }

        public async Task StartSimulation()
        {
            if (!_started)
            {
                _started = true;
                _messageHandler.Handle("Simulation has started\n");
                try
                {
                    await LoadDronesFromCore();
                }
                catch (Exception e)
                {
                    _messageHandler.Handle(String.Format("Exception: {0}\n", e.Message));
                    _messageHandler.Handle("Stack trace: " + e.StackTrace);
                    _messageHandler.Handle("Failed to load drones.\n");
                    _messageHandler.Handle(String.Format("Core client is null: {0}\n", _coreServiceClient == null));
                    return;
                }

                _messageHandler.Handle("Drones loaded from core, count: " + _drones.Count);
            }
        }

        public void StopSimulation()
        {
            if (_started)
            {
                foreach (ServiceHost serviceHost in _hosts)
                {
                    try
                    {
                        serviceHost.Close();
                    }
                    catch (Exception e)
                    {
                        _messageHandler.Handle("Error: "+e.Message);
                    }
                }

                _hosts.Clear();

                _started = false;
                _messageHandler.Handle("Simualtion has stopped");
            }
        }
        public async Task LoadDronesFromCore()
        {
            _drones.Clear();

            DronePost.DataModel.Drone[] arrTmpDrones = await _coreServiceClient.GetDronesAsync();
            foreach (var drone in arrTmpDrones)
            {
                _drones.Add(new Drone(drone));
            }

            foreach (var drone in _drones)
            {
                HostDrone(drone);
            }
        }

        public void HostDrone(Drone drone)
        {
            Uri baseAddress = new Uri("http://localhost:4999/Drone/" + drone.Id);
            ServiceHost host = new DroneServiceHost(drone, typeof(DroneService.DroneService), baseAddress);

            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                host.AddServiceEndpoint(typeof(DroneService.IDroneService), binding, baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior() {HttpGetEnabled = true};
                host.Description.Behaviors.Add(smb);
                host.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;


                host.Open();
                _hosts.Add(host);
                Log("Drone hosted: " + baseAddress);
            }
            catch (CommunicationException ce)
            {
                Log(String.Format("Exception: {0}", ce.Message));
                host.Abort();
            }
        }

        public void Log(string message)
        {
            _messageHandler.Handle(message);
        }
    }
}