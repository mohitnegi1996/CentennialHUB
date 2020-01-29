using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Models
{
    public class Order
    {
        [Key]
        public int OrderID{ get; set; }
        [Required]
        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "OrderQuantity")]
        public int OrderQuantity { get; set; }
        [Required]
        [Display(Name = "OrderTotalPrice")]
        public int OrderTotalPrice { get; set; }
    }
}
