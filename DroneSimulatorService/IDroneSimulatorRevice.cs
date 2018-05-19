using System.ServiceModel;
using DronePost.SupportClasses;

namespace DroneSimulatorService
{
    [ServiceContract]
    public interface IDroneSimulatorRevice
    {
        [OperationContract]
        void SetTask(DroneTask task);
    }

}
