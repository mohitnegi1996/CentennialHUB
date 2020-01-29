using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentennialHUB.Models;
using CentennialHUB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentennialHUB.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _Customer;
        public CustomerController(ICustomer _ICustomer)
        {
            _Customer = _ICustomer;
        }
        public IActionResult Index()
        {
            return View(_Customer.GetCustomers);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            Customer model = new Customer();
            model.CustomerId = 0;
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                _Customer.Add(model);
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
                Customer model = _Customer.GetCustomer(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Customer.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_Customer.GetCustomer(Id));
        }
        public IActionResult Edit(int? Id)
        {
            var model = _Customer.GetCustomer(Id);
            return View("Create", model);
        }
    }


}
