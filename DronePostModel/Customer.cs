using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePost
{
    /// <summary>
    /// This class represents customet as business entity. Can be presented as a person or company.
    /// </summary>
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsPhysicalPerson { get; set; }

        public Person Person { get; set; }

        public Company Company { get; set; }

        [Required]
        public float Balance { get; set; }
    }
}
