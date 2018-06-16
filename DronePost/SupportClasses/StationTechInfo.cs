using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DronePost.SupportClasses
{
	[DataContract]
	public class StationTechInfo
	{
		[DataMember] public int Id { get; protected set; }
		[DataMember] public int CountOfTasks { get; protected set; }
	}
}
