using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using DronePost.DataModel;
using StationSimulatorService;

namespace StationSimulator
{
    class Simulation
    {
        private readonly IMessageHandler _messageHandler;
        private readonly List<StationSimulation> _stations;
        private ServiceHost _host;

        private bool _started;

        public Simulation(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
            _stations = new List<StationSimulation>();
        }

        public void StartSimulation()
        {
            if (!_started)
            {
                LoadStations();
                HostService();
                _started = true;
                Log("Simulation has started");
            }
        }

        public void StopSimulation()
        {
            if (_started)
            {
                StopHost();
                _started = false;
                Log("Simulation has stopped");
            }
        }

        public void LoadStations()
        {
            _stations.Clear();

            // TODO: Get all stations from DB and 
        }

        public void Log(string message)
        {
            _messageHandler.Handle(message);
        }


        public void HostService()
        {
            Uri baseAddress = new Uri("http://localhost:5000/StationSimulator");
            _host = new ServiceHost(typeof(StationSimulatorService.StationService), baseAddress);

            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                _host.AddServiceEndpoint(typeof(IStationService), binding, baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior() {HttpGetEnabled = true};
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
                Log("Exception: "+exception.Message);
            }
        }
    }
}
