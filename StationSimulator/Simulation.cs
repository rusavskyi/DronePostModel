using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using DronePost.Interfaces;
using StationService;
using StationSimulator.CoreServiceReference;

namespace StationSimulator
{
    class Simulation
    {
        private readonly IMessageHandler _messageHandler;
        private readonly List<Station> _stations;
        private readonly CoreServiceClient _coreServiceClient;
        
        private bool _started;

        public Simulation(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
            _stations = new List<Station>();
            _coreServiceClient = new CoreServiceClient();
        }

        public async Task StartSimulation()
        {
            if (!_started)
            {
                _started = true;
                Log("Simulation has started");
                Log("Loading stations");
                try
                {
                    await LoadStationsFromCore();
                }
                catch (Exception e)
                {
                    Log(String.Format("Exception: {0}\n", e.Message));
                    return;
                }
                Log("Stations loaded from core, count: " + _stations.Count);
                _started = true;
            }
        }

        public void StopSimulation()
        {
            if (_started)
            {
                _started = false;
                Log("Simulation has stopped");
            }
        }



        public async Task LoadStationsFromCore()
        {
            _stations.Clear();

            DronePost.DataModel.Station[] arrTmpStations = await _coreServiceClient.GetStationsAsync();
            foreach (var station in arrTmpStations)
            {
                _stations.Add(new Station(station));
            }


            foreach (var station in _stations)
            {
                HostStation(station);
            }
        }

        public void Log(string message)
        {
            _messageHandler.Handle(message);
        }



        public void AddStation(Station station)
        {
            HostStation(station);
        }


        private void HostStation(Station station)
        {
            ServiceHost _host = null;
            Uri baseAddress = new Uri("http://localhost:5000/Station/"+station.Id);
            _host = new StationServiceHost(station, typeof(StationService.StationService), baseAddress);

            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                _host.AddServiceEndpoint(typeof(IStationService), binding, baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior() { HttpGetEnabled = true };
                _host.Description.Behaviors.Add(smb);
                _host.Open();
                Log("Station hosted: "+baseAddress);
            }
            catch (CommunicationException ce)
            {
                Log(String.Format("Exception: {0}", ce.Message));
                _host.Abort();
            }
        }
    }
}
