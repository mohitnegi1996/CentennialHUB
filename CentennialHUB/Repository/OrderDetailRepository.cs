using CentennialHUB.Models;
using CentennialHUB.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Repository
{
    public class OrderDetailRepository :IOrderDetails
    {
        private DB_Context db;
        public OrderDetailRepository(DB_Context _db)
        {
            db = _db;
        }
        //Commented by Reza: Getting all the Courses from the Database in the following line 




        public IEnumerable<OrderDetails> GetOrderDetailss => db.OrderDetails;

        public void Add(OrderDetails _OrderDetails)
        {
            if (_OrderDetails.OrderDetailID == 0)
            {
                db.OrderDetails.Add(_OrderDetails);
                db.SaveChanges();
            }
            else
            {
                var dbEntity = db.OrderDetails.Find(_OrderDetails.OrderID);
                dbEntity.OrderProductName = _OrderDetails.OrderProductName;
                dbEntity.OrderDate = _OrderDetails.OrderDate;
                dbEntity.OrderProductQuantity = _OrderDetails.OrderProductQuantity;
               
                dbEntity.OrderProductPrice = _OrderDetails.OrderProductPrice;
                db.SaveChanges();
            }
        }
        public OrderDetails GetOrderDetail(int? Id)
        {
            return db.OrderDetails.Include(e => e.OrderProductName).
                           Include(e => e.OrderDate).
                                          Include(e => e.OrderProductQuantity).
                           Include(e => e.OrderProductPrice)
                                           .SingleOrDefault(m => m.OrderDetailID == Id);
        }
        public void Remove(int? Id)
        {
            OrderDetails dbEntity = db.OrderDetails.Find(Id);
            db.OrderDetails.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
