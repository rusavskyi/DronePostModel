using System.ComponentModel.DataAnnotations;

namespace DronePost
{
    /// <summary>
    /// Class represents location (city, town, village) with location name and geographical coordinates.
    /// </summary>
    public class City
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        //[Required]
        //public float Longitude { get; set; }

        //[Required]
        //public float Latitude { get; set; }

    }
}