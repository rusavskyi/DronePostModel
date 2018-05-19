using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StationSimulatorService
{
    [ServiceContract]
    public interface IStationSimulatorService
    {
        [OperationContract]
        string GetData(int value);


        // TODO: Add your service operations here
    }

}
