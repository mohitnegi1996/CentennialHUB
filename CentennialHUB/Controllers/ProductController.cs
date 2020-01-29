using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentennialHUB.Services;
using CentennialHUB.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentennialHUB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _Product;
        public ProductController(IProduct _IProduct)
        {
            _Product = _IProduct;
        }
        public IActionResult Index()
        {
            return View(_Product.GetProducts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product model = new Product();
            model.ProductID = 0;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                _Product.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                //Written by Reza: Error Handling
                return NotFound();
            }
            else
            {
                Product model = _Product.GetProduct(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Product.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_Product.GetProduct(Id));
        }
        public IActionResult Edit(int? Id)
        {
            var model = _Product.GetProduct(Id);
            return View("Create", model);
        }
    }
}