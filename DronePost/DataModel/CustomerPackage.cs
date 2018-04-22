using System.ComponentModel.DataAnnotations;

namespace DronePost.DataModel
{
    /// <summary>
    /// Represents relation between sender custumer and package.
    /// </summary>
    public class CustomerPackage
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Customer Sender { get; set; }

        [Required]
        public Package Package { get; set; }
    }
}