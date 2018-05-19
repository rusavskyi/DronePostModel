using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DronePost.DataModel;
using DronePost.SupportClasses;

namespace StationSimulatorService
{
    [ServiceContract]
    public interface IStationSimulatorService
    {
        [OperationContract]
        void RegisterPackageFromClient(GeneratedPackage package);

        [OperationContract]
        void CommitArrival(Drone drone);

        [OperationContract]
        ChargeRespond RequestCharge();
    }

}
