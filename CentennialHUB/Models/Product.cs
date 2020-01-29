using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public int ProductPrice { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Required]
        [Display(Name = "Product Brand")]
        public string ProductBrand { get; set; }
        [Required]
        [Display(Name = "Product Quantity")]
        public int ProductQuantity { get; set; }
        [Required]
        [Display(Name = "Product Catogory Name")]
        public string ProductCatogoryName { get; set; }
        
    }
}
