using System.ServiceModel;
using DronePost.DataModel;
using DronePost.SupportClasses;

namespace StationSimulatorService
{
    [ServiceContract]
    public interface IStationSimulatorService
    {
        [OperationContract]
        bool RegisterPackageFromClient(GeneratedPackage package);

        [OperationContract]
        void CommitArrival(Drone drone);

        [OperationContract]
        ChargeRespond RequestCharge();
    }

}
