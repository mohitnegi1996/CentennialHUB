using CentennialHUB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Repository
{
    public class DB_Context : DbContext
    {
      

        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {

        }
        //We should keep the name that we use in front of DbSets exactly the same as of our database tables name.

        public DbSet<Customer> customer { get; set; }
      
        public DbSet<Order> order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<ProductCatogory> productCatogory { get; set; }

    }
}
