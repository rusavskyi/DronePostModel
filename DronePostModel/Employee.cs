using System.ComponentModel.DataAnnotations;

namespace DronePost
{
    /// <summary>
    /// 
    /// </summary>
    public class Employee : Person
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public EmployeeType WorkPost { get; set; }
        
    }
}