using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DronePost.DataModel
{
    /// <summary>
    /// Represents drone.
    /// </summary>
     
    [DataContract]
    public class Drone
    {
        [DataMember]
        [Required]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public DroneModel Model { get; set; }

        //public DroneTechInfo techInfo {get; set}

        [DataMember]
        [Required]
        public float Longitude { get; set; }

        [DataMember]
        [Required]
        public float Latitude { get; set; }

    }
}
