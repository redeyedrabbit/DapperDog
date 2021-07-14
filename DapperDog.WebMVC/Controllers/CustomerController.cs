using DapperDog.Models.Customer;
using DapperDog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperDog.WebMVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View(CreateCustomerService().GetCustomerList());
        }

        public ActionResult Create()
        {
            ViewBag.Name = "New Customer";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateCustomerService().CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer Successfully Created!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not create a Customer");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var customer = CreateCustomerService().GetCustomerDetailsById(id);
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = CreateCustomerService().GetCustomerDetailsById(id);
            return View(new CustomerEdit
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                Zipcode = customer.Zipcode
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateCustomerService().UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Customer Successfully Updated!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not edit a Customer");
            return View(model);
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }


        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();

            var model = svc.GetCustomerDetailsById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "The Customer was successfully deleted";

            return RedirectToAction("Index");
        }
    }
}