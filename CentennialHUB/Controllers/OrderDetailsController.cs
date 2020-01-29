using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentennialHUB.Models;
using CentennialHUB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentennialHUB.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetails _OrderDetails;
        public OrderDetailsController(IOrderDetails _IOrderDetails)
        {
            _OrderDetails = _IOrderDetails;
        }
        public IActionResult Index()
        {
            return View(_OrderDetails.GetOrderDetailss);
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderDetails model = new OrderDetails();
            model.OrderDetailID = 0;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(OrderDetails model)
        {
            if (ModelState.IsValid)
            {
                _OrderDetails.Add(model);
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
                OrderDetails model = _OrderDetails.GetOrderDetail(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _OrderDetails.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_OrderDetails.GetOrderDetail(Id));
        }
        public IActionResult Edit(int? Id)
        {
            var model = _OrderDetails.GetOrderDetail(Id);
            return View("Create", model);
        }
    }
}