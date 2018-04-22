using DronePost.DataModel;
using DronePost.SupportClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DronePost.Interfaces
{
    public interface IStationAPI
    {
        void CheckInDrone(Drone drone);
        void CheckOutDrone(Drone drone);
        void RequestDrone(Package package, Drone drone);
        void ChargeDroneOn(Drone drone);
        void ChargeDroneOff(Drone drone);
        DroneTechInfo GetDroneTechInfo(Drone drone);
        void GivePackage(Customer customer, Package package);
        Package GetPackage(Package package);
        void SetTask(DroneTask droneTask, Drone drone);


        // Int CheckInDrone (Drone d) - check-in drone to station
        // ? Void CheckoutDrone(Drone d) - check-out drone from station
        
        /*
           Request drone to take package
           Set drone on charge
           Get drone technical info
           Give package to recipient
           Get package from sender
           Set task for drone
         */
    }
}
