using System.ServiceModel;
using DronePost.DataModel;
using DronePost.SupportClasses;
using DronePost.Interfaces;

namespace StationService
{
    [ServiceContract]
    public interface IStationService
    {
        [OperationContract]
        void CheckIn(Drone drone);

        [OperationContract]
        void CheckOut(Drone drone);

        [OperationContract]
        void GivePackageToRecipient(Customer customer, Package package);

        [OperationContract]
        bool GetPackageFromCustomer(GeneratedPackage package);

        [OperationContract]
        void SetTask(StationTask stationTask);

        [OperationContract]
        void AddTask(StationTask stationTask);

        [OperationContract]
        void DoNextTask(bool force = false);

        [OperationContract]
        int RequestChargeSlot();
    }

}
