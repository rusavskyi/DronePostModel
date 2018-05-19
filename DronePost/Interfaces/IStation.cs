using DronePost.DataModel;
using DronePost.SupportClasses;

namespace DronePost.Interfaces
{
    public interface IStation
    {
        void CheckIn(Drone drone);
        void CheckOut(Drone drone);
        void GivePackageToRecipient(Customer customer, Package package);
        Package GetPackageFromCustomer(Package package);
        void SetTask(StationTask stationTask); // Setting task to do immediately
        void AddTask(StationTask stationTask); // Adding task to queue
        void DoNextTask(bool force = false); // Starting next task, if forsed starting immediately
        int RequestChargeSlot();

        // Connect to slot method?


        // Int CheckInDrone (Drone d) - check-in drone to station
        // ? Void CheckoutDrone(Drone d) - check-out drone from station

        /*
           Request drone to take package
           Set drone on charge // ?! core shit?
           Get drone technical info
           Give package to recipient
           Get package from sender
           Set task for drone
         */
    }
}
