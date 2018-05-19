using DronePost.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CoreService
{
    [ServiceContract]
    public interface ICoreService
    {
        [OperationContract]
        string GetData(int value);
    }
}
