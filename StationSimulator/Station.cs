using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

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
            throw new NotImplementedException();
        }

        public void CheckOut(Drone drone)
        {
            throw new NotImplementedException();
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
