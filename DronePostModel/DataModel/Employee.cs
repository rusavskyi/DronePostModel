using System.ComponentModel.DataAnnotations;

namespace DronePost.DataModel
{
    /// <summary>
    /// 
    /// </summary>
    public class Employee : Person
    {

        [Required]
        public EmployeeType WorkPost { get; set; }
        
    }
}