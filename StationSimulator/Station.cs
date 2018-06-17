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
        public Station(){}

        public Station(DronePost.DataModel.Station station)
        {
            Id = station.Id;
            Address = station.Address;
            Longitude = station.Longitude;
            Latitude = station.Latitude;
            Name = station.Name;
        }

        public void CheckIn(Drone drone)
        {
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

        }

        public void CheckOut(Drone drone)
        {
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

        }

        public void GivePackageToRecipient(Customer customer, Package package)
        {
            throw new NotImplementedException();
        }

        public bool GetPackageFromCustomer(Package package)
        {
            throw new NotImplementedException();
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
    }
}
