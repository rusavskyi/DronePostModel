using DronePost.DataModel;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DronePost.SupportClasses
{
	[DataContract]
	public class DroneTask
	{
		[DataMember]
		public DroneTaskType Type { get; protected set; }
		[DataMember()]
		public Package Package { get; protected set; }
		[DataMember()]
		public Station Station { get; protected set; }


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