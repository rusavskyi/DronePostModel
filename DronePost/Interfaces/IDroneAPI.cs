using System;
using System.Collections.Generic;
using System.Text;
using DronePost.SupportClasses;

namespace DronePost.Interfaces
{
    interface IDroneAPI
    {
        DroneTechInfo GetTechInfo(); // Return technical information(GPS, battery status, ?)
        void SetTask(DroneTask task); // Set task immediately for drone
        
        /*
           Commit arrival 
           Commit departure 
           Take package
           Give package
           Request (Get) information about next waypoint
           Send technical info every 5 min to core
         */
    }
}
