using System.Runtime.Serialization;
using DronePost.DataModel;

namespace DronePost.SupportClasses
{
    [DataContract]
    public class DroneTechInfo
    {
        [DataMember]
        public DroneModel Model { get; protected set; }
        [DataMember]
        public double BatteryCharge { get; protected set; }
        [DataMember]
        public int CountOfTasks { get; protected set; }
        [DataMember]
        public float Longitude { get; protected set; }
        [DataMember]
        public float Latitude { get; protected set; }

        public DroneTechInfo(DroneModel model, double batteryCharge, int countOfTasks, float longitude, float latitude)
        {
            Model = model;
            BatteryCharge = batteryCharge;
            CountOfTasks = countOfTasks;
            Longitude = longitude;
            Latitude = latitude;
        }
    }

}
