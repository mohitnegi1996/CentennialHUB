using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; }
        [Required]
        [Display(Name = "Customer Phone Number")]
        public int CustomerPhoneNumber { get; set; }
        [Required]
        [Display(Name = "Customer password")]
        public string CustomerPassword { get; set; }


    }
}
