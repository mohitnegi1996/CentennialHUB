using CentennialHUB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Services
{
   public interface IOrderDetails
    {
        IEnumerable<OrderDetails> GetOrderDetailss { get; }
        OrderDetails GetOrderDetail(int? Id);
        void Add(OrderDetails _OrderDetails);
        void Remove(int? Id);
    }
}
