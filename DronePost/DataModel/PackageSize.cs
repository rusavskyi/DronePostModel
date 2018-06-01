using System.ComponentModel.DataAnnotations;

namespace DronePost.DataModel
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
        public float Length { get; set; }

    }
}