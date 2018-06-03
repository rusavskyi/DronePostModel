using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public int RequestChargeSlot()
        {
            throw new NotImplementedException();
        }
    }
}
