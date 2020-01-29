using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentennialHUB.Models;
using CentennialHUB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CentennialHUB.Repository
{
    public class CustomerRepository : ICustomer
    {
        private DB_Context db;
        public CustomerRepository(DB_Context _db)
        {
            db = _db;
        }
        //Commented by Reza: Getting all the Courses from the Database in the following line 
        public IEnumerable<Customer> GetCustomers => db.customer;
        public void Add(Customer _Customer)
        {
            if (_Customer.CustomerId == 0)
            {
                db.customer.Add(_Customer);
                db.SaveChanges();
            }
            else
            {
                var dbEntity = db.customer.Find(_Customer.CustomerId);
                dbEntity.CustomerName = _Customer.CustomerName;
                dbEntity.CustomerEmail = _Customer.CustomerEmail;
                dbEntity.CustomerPhoneNumber = _Customer.CustomerPhoneNumber;
                dbEntity.CustomerPassword = _Customer.CustomerPassword;
                db.SaveChanges();
            }
        }
        public Customer GetCustomer(int? Id)
        {
            return db.customer.Include(e => e.CustomerName)
                           .Include(e => e.CustomerPhoneNumber)
                                           .Include(e => e.CustomerEmail)
                                           .SingleOrDefault(m => m.CustomerId == Id);
        }
        public void Remove(int? Id)
        {
            Customer dbEntity = db.customer.Find(Id);
            db.customer.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}

