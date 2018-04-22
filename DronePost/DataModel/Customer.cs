using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePost.DataModel
{
    /// <summary>
    /// This class represents customet as business entity. Can be presented as a person or company.
    /// </summary>
    public class Customer : Person
    {
        [Required]
        public bool CompanyAgent { get; set; }
        public Company Company { get; set; }
    }
}
