using System.Collections.Generic;
using DronePost.Interfaces;
using System.ServiceModel;
using DronePost.DataModel;
using DronePost.SupportClasses;

namespace CoreService
{
    [ServiceContract]
    public interface ICoreService
    {
        [OperationContract]
        void AssignCore(ICore core);

        [OperationContract]
        Package RegisterPackage(GeneratedPackage package);

        [OperationContract]
        int RegisterTransfer(Transfer transfer);

        [OperationContract]
        int RegisterDrone(Drone drone);

        [OperationContract]
        int RegisterStation(Station station);

        [OperationContract]
        int RegisterCustomer(Customer customer);

        [OperationContract]
        void RequestDroneForPackage(Package package);

        [OperationContract]
        void RequestDroneForPackages(params Package[] packages);

        [OperationContract]
        int RequestChargeForDrone(int id);

        [OperationContract]
        List<Drone> GetDrones();

        [OperationContract]
        List<Station> GetStations();

        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        List<PackageSize> GetSizes();
    }
}
