using System.ServiceModel;
using DronePost.Interfaces;
using DronePost.SupportClasses;

namespace DroneService
{
    [ServiceContract]
    public interface IDroneService
    {
        [OperationContract]
        DroneTechInfo GetTechInfo(); // Return technical information(GPS, battery status, ?)

        [OperationContract]
        void AddTask(DroneTask task); // Add task to queue

        [OperationContract]
        void SetTask(DroneTask task); // Set task to do immediately for drone

        [OperationContract]
        void DoNextTask(bool force = false);

        [OperationContract]
        bool Start();

        [OperationContract]
        bool Stop();
    }
}
