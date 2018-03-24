using System.ComponentModel.DataAnnotations;

namespace DronePost
{
    /// <summary>
    /// Represents relation between sender custumer and package.
    /// </summary>
    public class CustomerPackage
    {
        [Required]
        public Customer Sender { get; set; }

        [Required]
        public Package Package { get; set; }
    }
}