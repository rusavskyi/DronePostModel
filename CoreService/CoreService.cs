using System;
using System.Collections.Generic;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace CoreService
{
    public class CoreService : ICoreService
    {
        public ICore Core { get; set; }

        //public CoreService() { }

        public CoreService(ICore core)
        {
            Core = core;
        }

        public void AssignCore(ICore core)
        {
            Core = core;
        }

        public Package RegisterPackage(GeneratedPackage package)
        {
            return Core.RegisterPackage(package);
        }

        public int RegisterTransfer(Transfer transfer)
        {
            Core.RegisterTransfer(transfer);
            return 0;
        }

        public int RegisterDrone(Drone drone)
        {
            Core.RegisterDrone(drone);
            return 0;
        }

        public int RegisterStation(Station station)
        {
            Core.RegisterStation(station);
            return 0;
        }

        public int RegisterCustomer(Customer customer)
        {
            Core.RegisterCustomer(customer);
            return 0;
        }

        public void RequestDroneForPackage(Package package)
        {
            Core.RequestDroneForPackage(package);
        }

        public void RequestDroneForPackages(params Package[] packages)
        {
            Core.RequestDroneForPackages(packages);
        }

        public int RequestChargeForDrone(int id)
        {
            Core.SendDroneOnCharge(id);
            return 0;
        }

        public List<Drone> GetDrones()
        {
            return Core.GetDrones();
        }

        public List<Station> GetStations()
        {
            return Core.GetStations();
        }
    }
}
