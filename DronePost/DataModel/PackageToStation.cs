using System.ComponentModel.DataAnnotations;

namespace DronePost.DataModel
{
    /// <summary>
    /// This class represents relation between package and it's final destination (Station).
    /// </summary>
    public class PackageToStation
    {
        [Required]
        public Package Package { get; set; }

        [Required]
        public Station Station { get; set; }
    }
}