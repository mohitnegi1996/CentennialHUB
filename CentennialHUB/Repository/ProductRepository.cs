using CentennialHUB.Models;
using CentennialHUB.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentennialHUB.Repository
{
    public class ProductRepository :IProduct
    {
        private DB_Context db;
        public ProductRepository(DB_Context _db)
        {
            db = _db;
        }
        //Commented by Reza: Getting all the Courses from the Database in the following line 
        public IEnumerable<Product>GetProducts => db.product;
        public void Add(Product _Product)
        {
            if (_Product.ProductID == 0)
            {
                db.product.Add(_Product);
                db.SaveChanges();
            }
            else
            {
                var dbEntity = db.product.Find(_Product.ProductID);
                dbEntity.ProductName = _Product.ProductName;
                dbEntity.ProductPrice = _Product.ProductPrice;
                dbEntity.ProductDescription = _Product.ProductDescription;
                dbEntity.ProductBrand = _Product.ProductBrand;
                dbEntity.ProductQuantity = _Product.ProductQuantity;
                dbEntity.ProductCatogoryName = _Product.ProductCatogoryName;
                db.SaveChanges();
            }
        }
        public Product GetProduct(int? Id)
        {
            return db.product.Include(e => e.ProductName)
                           .Include(e => e.ProductPrice)
                                           .Include(e => e.ProductDescription)
                           .Include(e => e.ProductBrand).Include(e => e.ProductQuantity)
                           .Include(e => e.ProductCatogoryName)
                                           .SingleOrDefault(m => m.ProductID == Id);
        }
        public void Remove(int? Id)
        {
            Product dbEntity = db.product.Find(Id);
            db.product.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
