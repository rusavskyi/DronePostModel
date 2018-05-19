using System;
using DronePost.DataModel;
using DronePost.Interfaces;

namespace CoreService
{
    public class CoreService : ICoreService
    {
        public ICore Core { get; set; }

        public void AssignCore(ICore core)
        {
            Core = core;
        }


        public int RegisterPackage(Package package)
        {
            Core.RegisterPackage(package);
            return 0;
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

        public void SendDroneOnCharge(Drone drone, Station station)
        {
            Core.SendDroneOnCharge(drone, station);
        }

        public void RequestDroneForPackage(Package package)
        {
            Core.RequestDroneForPackage(package);
        }

        public void RequestDroneForPackages(params Package[] packages)
        {
            Core.RequestDroneForPackages(packages);
        }

        public void RegisterPackageFromStation(Package package)
        {
            throw new NotImplementedException();
        }
    }
}
