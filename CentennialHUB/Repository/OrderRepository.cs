using CentennialHUB.Models;
using CentennialHUB.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Repository
{
    public class OrderRepository : IOrder
    {
        private DB_Context db;
        public OrderRepository(DB_Context _db)
        {
            db = _db;
        }
        //Commented by Reza: Getting all the Courses from the Database in the following line 
       

    public  IEnumerable<Order> GetOrders => db.order;

        public void Add(Order _Order)
        {
            if (_Order.OrderID == 0)
            {
                db.order.Add(_Order);
                db.SaveChanges();
            }
            else
            {
                var dbEntity = db.order.Find(_Order.OrderID);
                dbEntity.OrderNumber = _Order.OrderNumber;
                dbEntity.OrderDate = _Order.OrderDate;
                dbEntity.OrderQuantity = _Order.OrderQuantity;
                dbEntity.OrderTotalPrice = _Order.OrderTotalPrice;
                db.SaveChanges();
            }
        }
        public Order GetOrder(int? Id)
        {
            return db.order.Include(e => e.OrderNumber).
                           Include(e => e.OrderDate).
                                          Include(e => e.OrderQuantity).
                           Include(e => e.OrderTotalPrice)
                                           .SingleOrDefault(m => m.OrderID == Id);
        }
        public void Remove(int? Id)
        {
            Order dbEntity = db.order.Find(Id);
            db.order.Remove(dbEntity);
            db.SaveChanges();
        }

       
    }
}
