using System.ComponentModel.DataAnnotations;

namespace DronePost
{
    /// <summary>
    /// 
    /// </summary>
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public EmployeeType WorkPost { get; set; }

        [Required]
        public Person Person { get; set; }
    }
}