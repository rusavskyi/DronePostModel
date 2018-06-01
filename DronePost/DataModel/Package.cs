using System.ComponentModel.DataAnnotations;

namespace DronePost.DataModel
{
    /// <summary>
    /// This class represents package.
    /// </summary>
    public class Package 
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RecipientPhoneNumber { get; set; }

        [Required]
        public PackageSize Size { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public Station DestinationStation { get; set; }

    }
}