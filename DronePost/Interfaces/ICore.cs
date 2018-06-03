using System.Collections.Generic;
using DronePost.DataModel;
using DronePost.SupportClasses;

namespace DronePost.Interfaces
{
    public interface ICore
    {

        Package RegisterPackage(GeneratedPackage package);
        int RegisterTransfer(Transfer transfer);
        int RegisterDrone(Drone drone);
        int RegisterStation(Station station);
        int RegisterCustomer(Customer customer);
        void SendDroneOnCharge(int idDrone);
        void RequestDroneForPackage(Package package);
        void RequestDroneForPackages(params Package[] packages);
        List<Drone> GetDrones();

        // int RegisterCustumer(Customer customer, Company company); // ?

        /*
            Give task for drone to station (Add package to queue for sending with drone)
            Get drone technical info
            Inform client to take package
        */
    }
}
