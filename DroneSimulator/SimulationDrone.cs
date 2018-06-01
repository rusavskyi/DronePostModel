using DroneSimulatorService;
using System;
using System.Collections.Generic;

using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace DroneSimulator
{
	public class SimulationDrone
	{
		private readonly IMessageHandlerDrone _messageHandler;
		private readonly List<DroneSimulation> _drones;
		private ServiceHost _host;

		private bool _started;

		public SimulationDrone(IMessageHandlerDrone messageHandler)
		{
			_messageHandler = messageHandler;
			_drones = new List<DroneSimulation>();
		}

		public void startSimulation()
		{

			if (!_started)
			{
				LoadDrones();
				HostService();
				_started = true;
				Log("Simulation has started");
			}
		}

		public void StopSimulation() {

			if (_started) {

				StopHost();
				_started = false;
				Log("Simualtion has stopped");
			}

		}

		public void LoadDrones() {
			_drones.Clear();

			//TODO
		}

		public void HostService()
		{
			Uri baseAddress = new Uri("http://localhost:4999/DroneSimulator");
            _host = new ServiceHost(typeof(DroneSimulatorService.DroneSimulatorRevice), baseAddress);

            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                _host.AddServiceEndpoint(typeof(IDroneSimulatorRevice), binding, baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior(){ HttpGetEnabled = true};
                _host.Description.Behaviors.Add(smb);
                _host.Open();
            }
            catch (CommunicationException ce)
            {
                Log(String.Format("Exception: {0}", ce.Message));
                _host.Abort();
            }
		}

		public void StopHost()
		{
			try
			{
				_host.Close();
				_host = null;
			}
			catch (Exception exception)
			{
				Log("Exception: " + exception.Message);
			}
		}

		public void Log(string message) {
			_messageHandler.Handle(message);
		}
	}
}
