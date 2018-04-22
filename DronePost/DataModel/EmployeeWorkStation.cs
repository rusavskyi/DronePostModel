using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
