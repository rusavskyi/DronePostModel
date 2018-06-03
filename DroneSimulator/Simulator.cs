using System;
using System.Collections.Generic;
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
		private List<Drone> _drones;
		private CoreServiceClient _coreServiceClient;
		private bool _started;

		public Simulator(IMessageHandlerDrone messageHandler)
		{
			_messageHandler = messageHandler;
			_drones = new List<Drone>();
			_coreServiceClient = new CoreServiceClient();
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
					_messageHandler.Handle(String.Format("Exception: {0}\n",e.Message));
					_messageHandler.Handle("Failed to load drones.\n");
					_messageHandler.Handle(String.Format("Core client is null: {0}\n", _coreServiceClient == null));
					return;
				}
				_messageHandler.Handle("Drones loaded from core, count: " + _drones.Count);
			}
		}

		public void StopSimulation() {

			if (_started) {
				_started = false;
				_messageHandler.Handle("Simualtion has stopped");
			}

		}

		public async Task LoadDronesFromCore() {
			_drones.Clear();

		    DronePost.DataModel.Drone[] arrTmpDrones = await _coreServiceClient.GetDronesAsync();
		    foreach (var drone in arrTmpDrones)
		    {
                var tDrone = new Drone(drone);
		        _drones.Add();
		    }

            /*List<Drone> tmpDrones = new List<Drone>(await _coreServiceClient.GetDronesAsync());//await _coreServiceClient.GetDronesAsync();
            foreach (Drone drone in tmpDrones)
			{
				_drones.Add(drone);
			}
			_messageHandler.Handle("Count: " + _drones.Count);
            */

		    foreach (var drone in _drones)
		    {
		        HostDrone(drone);
		    }
		}

		public void HostDrone(Drone drone)
		{
			ServiceHost _host;
			Uri baseAddress = new Uri("http://localhost:4999/Drone/"+drone.Id);
			_host = new DroneServiceHost(drone, typeof(DroneService.DroneService), baseAddress);

			try
			{
				WSHttpBinding binding = new WSHttpBinding();
				_host.AddServiceEndpoint(typeof(IDroneService), binding, baseAddress);
				ServiceMetadataBehavior smb = new ServiceMetadataBehavior(){ HttpGetEnabled = true};
				_host.Description.Behaviors.Add(smb);
				_host.Open();
				Log("Drone hosted: "+baseAddress);
			}
			catch (CommunicationException ce)
			{
				Log(String.Format("Exception: {0}", ce.Message));
				_host.Abort();
			}
		}

		public void Log(string message) {
			_messageHandler.Handle(message);
		}
	}
}
