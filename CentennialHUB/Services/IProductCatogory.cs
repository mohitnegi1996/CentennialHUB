using CentennialHUB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Services
{
  public interface IProductCatogory
    {
        IEnumerable<ProductCatogory> GetProductCatogories { get; }
        ProductCatogory GetProductCatogory(int? Id);
        void Add(ProductCatogory _ProductCatogory);
        void Remove(int? Id);
    }
}
