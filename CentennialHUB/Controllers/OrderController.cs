using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentennialHUB.Models;
using CentennialHUB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentennialHUB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _Order;
        public OrderController(IOrder _IOrder)
        {
            _Order = _IOrder;
        }
        public IActionResult Index()
        {
            return View(_Order.GetOrders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Order model = new Order();
            model.OrderID = 0;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Order model)
        {
            if (ModelState.IsValid)
            {
                _Order.Add(model);
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
                Order model = _Order.GetOrder(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Order.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_Order.GetOrder(Id));
        }
        public IActionResult Edit(int? Id)
        {
            var model = _Order.GetOrder(Id);
            return View("Create", model);
        }
    }
}
