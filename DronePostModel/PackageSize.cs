using System.ComponentModel.DataAnnotations;

namespace DronePost
{
    /// <summary>
    /// This class represents specified package size.
    /// </summary>
    public class PackageSize
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string SizeName { get; set; }

        [Required]
        public float Width { get; set; }

        [Required]
        public float Height { get; set; }

        [Required]
        public float Lenght { get; set; }

    }
}