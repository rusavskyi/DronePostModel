﻿using System;
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
        private readonly List<ServiceHost> _hosts;
        private bool _started;
        public int numOfStations = 0;

        public Simulation(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
            _stations = new List<Station>();
            _coreServiceClient = new CoreServiceClient();
            _hosts = new List<ServiceHost>();
        }

        public async Task StartSimulation()
        {
            if (!_started)
            {
                Log("Simulation has started");
                Log("Loading stations");
                try
                {
                    await LoadStationsFromCore();
                    ++numOfStations;
                }
                catch (Exception e)
                {
                    Log("Failed to load stations");
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
                foreach (ServiceHost serviceHost in _hosts)
                {
                    try
                    {
                        serviceHost.Close();
                    }
                    catch (Exception e)
                    {
                        Log("Error: " + e.Message);
                    }
                }

                _hosts.Clear();

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
                station.SetMessageHandler(_messageHandler);
                HostStation(station);
            }
        }




        private void HostStation(Station station)
        {
            ServiceHost host = null;
            Uri baseAddress = new Uri("http://localhost:5000/Station/"+station.Id);
            host = new StationServiceHost(station, typeof(StationService.StationService), baseAddress);

            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                host.AddServiceEndpoint(typeof(StationService.IStationService), binding, baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior() { HttpGetEnabled = true };
                host.Description.Behaviors.Add(smb);
                host.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

                host.Open();
                _hosts.Add(host);
                Log("Station hosted: "+baseAddress);
                ++numOfStations;
            }
            catch (CommunicationException ce)
            {
                Log(String.Format("Exception: {0}", ce.Message));
                host.Abort();
            }
        }

        private void HostStation(Station station, int id)
        {
            ServiceHost host = null;
            Uri baseAddress = new Uri("http://localhost:5000/Station/" + id);
            host = new StationServiceHost(station, typeof(StationService.StationService), baseAddress);

            try
            {
                WSHttpBinding binding = new WSHttpBinding();
                host.AddServiceEndpoint(typeof(IStationService), binding, baseAddress);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior() { HttpGetEnabled = true };
                host.Description.Behaviors.Add(smb);
                host.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

                host.Open();
                _hosts.Add(host);
                Log("Station hosted: " + baseAddress);
                ++numOfStations;
            }
            catch (CommunicationException ce)
            {
                Log(String.Format("Exception: {0}", ce.Message));
                host.Abort();
            }
        }

        public void AddStation(Station station)
        {
            HostStation(station);
        }

        public void AddStation(Station station, int id)
        {
            HostStation(station, id);
        }

        public void Log(string message)
        {
            _messageHandler.Handle(message);
        }
    }
}
