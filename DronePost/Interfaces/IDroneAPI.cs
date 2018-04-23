using DronePost.SupportClasses;

namespace DronePost.Interfaces
{
    public interface IDroneAPI
    {
        DroneTechInfo GetTechInfo(); // Return technical information(GPS, battery status, ?)
        void AddTask(DroneTask task); // Add task to queue
        void SetTask(DroneTask task); // Set task to do immediately for drone
        void DoNextTask(bool force = false);
        bool Start();
        bool Stop();

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
