using CentennialHUB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using CentennialHUB.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Repository
{
    public class ProductCatogoryRepository :IProductCatogory
    {
        private DB_Context db;
        public ProductCatogoryRepository(DB_Context _db)
        {
            db = _db;
        }
        //Commented by Reza: Getting all the Courses from the Database in the following line 


       

     

        public IEnumerable<ProductCatogory> GetProductCatogories => db.productCatogory;

        public void Add(ProductCatogory _ProductCatogory)
        {
            if (_ProductCatogory.ProductCatogoryID == 0)
            {
                db.productCatogory.Add(_ProductCatogory);
                db.SaveChanges();
            }
            else
            {
                var dbEntity = db.productCatogory.Find(_ProductCatogory.ProductCatogoryID);
                dbEntity.ProductCatogoryName = _ProductCatogory.ProductCatogoryName;
               
                db.SaveChanges();
            }
        }
        public  ProductCatogory GetProductCatogory(int? Id)
        {
            return db.productCatogory.Include(e => e.ProductCatogoryName)
                         
                                           .SingleOrDefault(m => m.ProductCatogoryID == Id);
        }
        public void Remove(int? Id)
        {
            ProductCatogory dbEntity = db.productCatogory.Find(Id);
            db.productCatogory.Remove(dbEntity);
            db.SaveChanges();
        }


    }
}
