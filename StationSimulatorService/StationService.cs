using System;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace StationService
{
    public class StationService : IStationService
    {
        private IStation _station;
        public StationService(IStation station)
        {
            _station = station;
        }

        public void AddTask(StationTask stationTask)
        {
            _station.AddTask(stationTask);
        }

        public void CheckIn(Drone drone)
        {
            _station.CheckIn(drone);
        }

        public void CheckOut(Drone drone)
        {
            _station.CheckOut(drone);
        }

        public void DoNextTask(bool force = false)
        {
            _station.DoNextTask(force);
        }

        public bool GetPackageFromCustomer(Package package)
        {
            return _station.GetPackageFromCustomer(package);
        }

        public void GivePackageToRecipient(Customer customer, Package package)
        {
            _station.GivePackageToRecipient(customer, package);
        }

        public int RequestChargeSlot()
        {
            return _station.RequestChargeSlot();
        }

        public void SetTask(StationTask stationTask)
        {
            _station.SetTask(stationTask);
        }
    }
}
