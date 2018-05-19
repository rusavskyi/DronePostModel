using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DronePost.DataModel;
using DronePost.Interfaces;

namespace CoreService
{
    public class CoreService : ICoreService
    {
        private ICore _core;


        public int RegisterPackage(Package package)
        {
            _core.RegisterPackage(package);
            return 0;
        }

        public int RegisterTransfer(Transfer transfer)
        {
            _core.RegisterTransfer(transfer);
            return 0;
        }

        public int RegisterDrone(Drone drone)
        {
            _core.RegisterDrone(drone);
            return 0;
        }

        public int RegisterStation(Station station)
        {
            _core.RegisterStation(station);
            return 0;
        }

        public int RegisterCustomer(Customer customer)
        {
            _core.RegisterCustomer(customer);
            return 0;
        }

        public void SendDroneOnCharge(Drone drone, Station station)
        {
            _core.SendDroneOnCharge(drone, station);
        }

        public void RequestDroneForPackage(Package package)
        {
            _core.RequestDroneForPackage(package);
        }

        public void RequestDroneForPackages(params Package[] packages)
        {
            _core.RequestDroneForPackages(packages);
        }
    }
}
