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
        public readonly List<Drone> _drones;
        private readonly CoreServiceClient _coreServiceClient;
        private readonly List<ServiceHost> _hosts;
        private bool _started;
		public readonly List<PackageSize> _packageSize;
        public int numOfDrones = 0;

        public Simulation(IMessageHandlerDrone messageHandler)
        {
            _messageHandler = messageHandler;
            _drones = new List<Drone>();
            _coreServiceClient = new CoreServiceClient();
            _hosts = new List<ServiceHost>();
			_packageSize = new List<PackageSize>();
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
					await LoadPackageSizeFromCore();
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

		public async Task LoadPackageSizeFromCore()
		{
			_packageSize.Clear();

			DronePost.DataModel.PackageSize[] arrTmpPackageSize = await _coreServiceClient.GetSizesAsync();
			foreach (var packageSize in arrTmpPackageSize)
			{
				_packageSize.Add(packageSize);
			}

		
		}

		public async Task LoadDronesFromCore()
        {
            _drones.Clear();

            DronePost.DataModel.Drone[] arrTmpDrones = await _coreServiceClient.GetDronesAsync();
            foreach (var drone in arrTmpDrones)
            {
                _drones.Add(new Drone(drone, _messageHandler));
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


        public bool AddDrone(DronePost.DataModel.Drone drone)
        {
            try
            {
                Drone newDrone = new Drone(drone, _messageHandler);
                _drones.Add(newDrone);
                HostDrone(newDrone);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void Log(string message)
        {
            _messageHandler.Handle(message);
        }
    }
}