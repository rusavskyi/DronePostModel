using DronePost.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DronePost.DataModel;

namespace CoreService
{
    [ServiceContract]
    public interface ICoreService
    {
        [OperationContract]
        int RegisterPackage(Package package);
        [OperationContract]
        int RegisterTransfer(Transfer transfer);
        [OperationContract]
        int RegisterDrone(Drone drone);
        [OperationContract]
        int RegisterStation(Station station);
        [OperationContract]
        int RegisterCustomer(Customer customer);
        [OperationContract]
        void SendDroneOnCharge(Drone drone, Station station);
        [OperationContract]
        void RequestDroneForPackage(Package package);
        [OperationContract]
        void RequestDroneForPackages(params Package[] packages);
    }
}
