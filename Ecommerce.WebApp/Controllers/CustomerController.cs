﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        public IActionResult Index()
        {
            var customerList = _customerRepository.GetAll();
            //ViewBag.Customers = customerList;
            return View(customerList);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _customerRepository.Add(model);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                    //var customer = _customerRepository.GetAll();
                    //ViewBag.Customers = customer;
                    //ViewBag.SuccessMessage = "Saved Successfully";
                    //return View("Index");

                }
            }
            return View();
        }
    }
}