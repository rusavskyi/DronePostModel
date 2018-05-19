using System;
using DronePost.DataModel;
using DronePost.Interfaces;

namespace Core
{
    class Core : ICore
    {
        public int RegisterPackage(Package package)
        {
            throw new NotImplementedException();
        }

        public int RegisterTransfer(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public int RegisterDrone(Drone drone)
        {
            throw new NotImplementedException();
        }

        public int RegisterStation(Station station)
        {
            throw new NotImplementedException();
        }

        public int RegisterCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void SendDroneOnCharge(Drone drone, Station station)
        {
            throw new NotImplementedException();
        }

        public void RequestDroneForPackage(Package package)
        {
            throw new NotImplementedException();
        }

        public void RequestDroneForPackages(params Package[] packages)
        {
            throw new NotImplementedException();
        }
    }
}
