using System.Net.Http;
using DronePost.DataModel;

namespace DronePost.Interfaces
{
    public interface ICoreAPI
    {
        int RegisterPackage(Package package);

        int RegisterTransfer(Transfer transfer);

        int RegisterDrone(Drone drone);

        int RegisterStation(Station station);

        int RegisterCustumer(Customer customer);

        // int RegisterCustumer(Customer customer, Company company); // Don't 

    }
}