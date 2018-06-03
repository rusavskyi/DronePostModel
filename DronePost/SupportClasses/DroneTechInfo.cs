using System.Runtime.Serialization;
using DronePost.DataModel;

namespace DronePost.SupportClasses
{
    [DataContract]
    public class DroneTechInfo
    {
        [DataMember]
        public DroneModel Model { get; }
        [DataMember]
        public double BatteryCharge { get; }
        [DataMember]
        public int CountOfTasks { get; }
        [DataMember]
        public float Longitude { get; }
        [DataMember]
        public float Latitude { get; }

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
