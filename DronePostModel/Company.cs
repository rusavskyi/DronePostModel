using System.ComponentModel.DataAnnotations;

namespace DronePost
{
    /// <summary>
    /// This class represents company.
    /// </summary>
    public class Company
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }


    }
}