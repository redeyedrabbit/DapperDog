using DapperDog.Models.Product;
using DapperDog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperDog.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(CreateProductService().GetProductList());
        }

        public ActionResult Create()
        {
            ViewBag.Name = "New Product";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateProductService().CreateProduct(model))
            {
                TempData["SaveResult"] = "Product Successfully Created!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not create a Product");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var product = CreateProductService().GetProductDetailsById(id);
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = CreateProductService().GetProductDetailsById(id);
            return View(new ProductEdit 
            {
                ProductId = product.ProductId,
                Description = product.Description
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateProductService().UpdateProduct(model))
            {
                TempData["SaveResult"] = "Product Successfully Updated!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not edit a Product");
            return View(model);
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
    }
}