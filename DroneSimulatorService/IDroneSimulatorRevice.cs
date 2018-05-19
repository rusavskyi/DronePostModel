using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
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
