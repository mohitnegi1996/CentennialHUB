using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailID { get; set; }
        
        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "Order Product Name")]
        public String OrderProductName { get; set; }
        [Required]
        [Display(Name = "OrderProductQuantity")]
        public int OrderProductQuantity { get; set; }
        [Required]
        [Display(Name = "OrderProductPrice")]
        public int OrderProductPrice { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
