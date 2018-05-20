using System;
using DronePost.DataModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace StationSimulatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StationSimulatorService" in both code and config file together.
    public class StationSimulatorService : IStationSimulatorService
    {
        public IStation Station { get; set; }

        public bool RegisterPackageFromClient(GeneratedPackage package)
        {
            throw new NotImplementedException();
        }

        public void CommitArrival(Drone drone)
        {
            throw new NotImplementedException();
        }

        public ChargeRespond RequestCharge()
        {
            throw new NotImplementedException();
        }
    }
}
