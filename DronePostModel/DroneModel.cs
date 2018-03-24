using System.ComponentModel.DataAnnotations;

namespace DronePost
{
    /// <summary>
    /// Represents drone model.
    /// </summary>
    public class DroneModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string ModelName { get; set; }

        [Required]
        public PackageSize MaxSizeCarry { get; set; }

        [Required]
        public float MaxWeightCarry { get; set; }

        [Required]
        public float MaxFlightDistance { get; set; }
    }
}