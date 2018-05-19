using System.ServiceModel;
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
