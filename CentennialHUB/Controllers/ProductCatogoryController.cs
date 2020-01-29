using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentennialHUB.Models;
using CentennialHUB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentennialHUB.Controllers
{
    public class ProductCatogoryController : Controller
    {
        private readonly IProductCatogory _ProductCatogory;
        public ProductCatogoryController(IProductCatogory _IProductCatogory)
        {
            _ProductCatogory = _IProductCatogory;
        }
        public IActionResult Index()
        {
            return View(_ProductCatogory.GetProductCatogories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductCatogory model = new ProductCatogory();
            model.ProductCatogoryID = 0;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(ProductCatogory model)
        {
            if (ModelState.IsValid)
            {
                _ProductCatogory.Add(model);
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
                ProductCatogory model = _ProductCatogory.GetProductCatogory(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _ProductCatogory.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_ProductCatogory.GetProductCatogory(Id));
        }
        public IActionResult Edit(int? Id)
        {
            var model = _ProductCatogory.GetProductCatogory(Id);
            return View("Create", model);
        }
    
}
}