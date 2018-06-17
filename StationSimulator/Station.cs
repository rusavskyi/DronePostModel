using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;
using StationSimulator.CoreServiceReference;

namespace StationSimulator
{
    class Station : DronePost.DataModel.Station, IStation
    {
        private IMessageHandler _messageHandler;

        public Station(){}

        public Station(DronePost.DataModel.Station station)
        {
            Id = station.Id;
            Address = station.Address;
            Longitude = station.Longitude;
            Latitude = station.Latitude;
            Name = station.Name;
        }

        public void SetMessageHandler(IMessageHandler _handler)
        {
            _messageHandler = _handler;
        }

        public void CheckIn(Drone drone)
        {
            Log($"drone {drone.Id} trying to check in.");
            CoreServiceClient core = new CoreServiceClient();
            DronePost.DataModel.Station arrivalStation = new DronePost.DataModel.Station()
            {
                Address = this.Address,
                Id = this.Id,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Name = this.Name
            };
            core.RegisterTransfer(new Transfer()
            {
                ArrivalStation = arrivalStation,
                ArrivalTime = DateTime.Now,
                Drone = drone
            });
            Log($"drone {drone.Id} checked in.");
        }

        public void CheckOut(Drone drone)
        {
            Log($"drone {drone.Id} trying to check out.");
            CoreServiceClient core = new CoreServiceClient();
            DronePost.DataModel.Station departureStation = new DronePost.DataModel.Station()
            {
                Address = this.Address,
                Id = this.Id,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Name = this.Name
            };
            core.RegisterTransfer(new Transfer()
            {
                DepartureStation = departureStation,
                DepartureTime = DateTime.Now,
                Drone = drone
            });
            Log($"drone {drone.Id} checked out.");
        }

        public void GivePackageToRecipient(Customer customer, Package package)
        {
            Log($"customer {customer.Id} trying to take package {package.Id}.");
            CoreServiceClient core = new CoreServiceClient();
            DronePost.DataModel.Station departureStation = new DronePost.DataModel.Station()
            {
                Address = this.Address,
                Id = this.Id,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Name = this.Name
            };
            core.RegisterTransfer(new Transfer()
            {
                DepartureStation = departureStation,
                DepartureTime = DateTime.Now,
                Package = package
            });
            Log($"package {package.Id} was given to customer.");
        }

        public bool GetPackageFromCustomer(GeneratedPackage package)
        {
            Log($"Get package from customer, but dont know what to do :D");
            return true;
        }

        public void SetTask(StationTask stationTask)
        {
            throw new NotImplementedException();
        }

        public void AddTask(StationTask stationTask)
        {
            throw new NotImplementedException();
        }

        public void DoNextTask(bool force = false)
        {
            Debug.WriteLine("STATION IS GOOD");
        }

        public int RequestChargeSlot()
        {
            throw new NotImplementedException();
        }

        private void Log(string message)
        {
            _messageHandler.Handle($"Station {Id}: " + message);
        }
    }
}
