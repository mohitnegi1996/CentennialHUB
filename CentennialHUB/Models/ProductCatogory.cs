using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Models
{
    public class ProductCatogory
    {
        [Key]
        public int ProductCatogoryID { get; set; }

        [Required]
        [Display(Name = "Product Catogory Name")]
        public string ProductCatogoryName { get; set; }
       
    }
}
