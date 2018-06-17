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
    public class Simulation
    {
        private readonly IMessageHandlerDrone _messageHandler;
        private readonly List<Drone> _drones;
        private readonly CoreServiceClient _coreServiceClient;
        private readonly List<ServiceHost> _hosts;
        private bool _started;
        public int numOfDrones = 0;

        public Simulation(IMessageHandlerDrone messageHandler)
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
                _messageHandler.Handle("Simulation has started");
                Log("Loading drones");
                try
                {
                    await LoadDronesFromCore();
                    ++numOfDrones;
                }
                catch (Exception e)
                {
                    Log("Failed to load drones");
                    Log(String.Format("Exception: {0}\n", e.Message));
                    return;
                }
                Log("Drones loaded from core, count: " + _drones.Count);
                _started = true;
            }
        }

        public void StopSimulation()
        {
            if (_started)
            {
                foreach (Drone drone in _drones)
                {
                    drone.Stop();
                }

                foreach (ServiceHost serviceHost in _hosts)
                {
                    try
                    {
                        serviceHost.Close();
                    }
                    catch (Exception e)
                    {
                        Log("Error: "+e.Message);
                    }
                }

                _hosts.Clear();

                _started = false;
                Log("Simualtion has stopped");
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
                drone.SetMessageHandler(_messageHandler);
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
                Log("Drone has been started, waiting for commands on: " + baseAddress);
                ++numOfDrones;
                drone.Start();
            }
            catch (CommunicationException ce)
            {
                Log($"Exception: {ce.Message}");
                host.Abort();
            }
        }

        public void HostDrone(Drone drone, int id)
        {
            Uri baseAddress = new Uri("http://localhost:4999/Drone/" + id);
            ServiceHost host = new DroneServiceHost(drone, typeof(DroneService.DroneService), baseAddress);

            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                host.AddServiceEndpoint(typeof(DroneService.IDroneService), binding, baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior() { HttpGetEnabled = true };
                host.Description.Behaviors.Add(smb);
                host.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

                host.Open();
                _hosts.Add(host);
                Log("Drone hosted: " + baseAddress);
                ++numOfDrones;
            }
            catch (CommunicationException ce)
            {
                Log($"Exception: {0} {ce.Message}");
                host.Abort();
            }
        }

        public void Log(string message)
        {
            _messageHandler.Handle(message);
        }
    }
}