using DronePost.DataModel;

namespace DronePost.SupportClasses
{
    public class DroneTask
    {
        public DroneTaskType Type { get; }
        public Package Package { get; }
        public Station Station { get; }


        public DroneTask(DroneTaskType type, Package package, Station station)
        {
            Type = type;
            Package = package;
            Station = station;
        }

        public DroneTask(DroneTaskType type, Station station)
        {
            Type = type;
            Station = station;
        }

    }

    public enum DroneTaskType
    {
        TakePackage, GoToStation, LeavePackage, ChargeAtStation
    }
}