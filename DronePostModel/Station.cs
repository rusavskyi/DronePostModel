using System.ComponentModel.DataAnnotations;

namespace DronePost
{
    /// <summary>
    /// This class represents station with it's name, address and geographical coordinates.
    /// </summary>
    public class Station
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        public float Latitude { get; set; }
    }
}
