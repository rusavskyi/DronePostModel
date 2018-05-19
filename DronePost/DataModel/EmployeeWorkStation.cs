using System.ComponentModel.DataAnnotations;

namespace DronePost.DataModel
{
    /// <summary>
    /// This class represents relation between employee and it's work station.
    /// </summary>
    public class EmployeeWorkStation
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Station Station { get; set; }
    }
}
