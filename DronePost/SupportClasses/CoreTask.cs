using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DronePost.SupportClasses
{
    [DataContract]
    public class CoreTask
    {
        [DataMember] public CoreTaskType Type { get; }

        public CoreTask(CoreTaskType type)
        {
            Type = type;
        }
    }

    public enum CoreTaskType
    {
        CheckDronesStatus,
        CheckStationsStatus
    }
}
