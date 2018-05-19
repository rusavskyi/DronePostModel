using System.Net.Http;
using DronePost.DataModel;

namespace DronePost.Interfaces
{
    public interface ICore
    {
        int RegisterPackage(Package package);

        int RegisterTransfer(Transfer transfer);

        int RegisterDrone(Drone drone);

        int RegisterStation(Station station);

        int RegisterCustumer(Customer customer);

        void SendDroneOnCharge(Drone drone, Station station);
        void RequestDroneForPackage(Package package); 
        void RequestDroneForPackages(params Package[] packages);


        // int RegisterCustumer(Customer customer, Company company); // ?

        /*
            Give task for drone to station (Add package to queue for sending with drone)
            Get drone technical info
            Inform client to take package
        */
    }
}
