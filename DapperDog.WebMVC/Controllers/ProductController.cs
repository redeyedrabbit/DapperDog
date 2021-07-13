using DapperDog.Data;
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
        //private readonly Guid _userId;

        //public BrandService(Guid userId)
        //{
        //    _userId = userId;
        //}
        // GET: Product
        public ActionResult Index()
        {
            return View(CreateProductService().GetProductList());
        }

        public ActionResult Create()
        {
            ViewBag.Name = "New Product";
            // Show Brand Name in dropdown option
            List<Brand> Brands = new BrandService().GetBrands().ToList();
            var query = from m in Brands
                        select new SelectListItem()
                        {
                            Value = m.BrandId.ToString(),
                            Text = m.Name
                        };
            ViewBag.BrandId = query.ToList();

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
            ModelState.AddModelError("", "Something went wrong = could not create a Product");
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

            ViewBag.Name = "New Product";
            // Show Brand Name in dropdown option
            List<Brand> Brands = new BrandService().GetBrands().ToList();
            var query = from m in Brands
                        select new SelectListItem()
                        {
                            Value = m.BrandId.ToString(),
                            Text = m.Name
                           
                        };
            ViewBag.BrandId = query.ToList();

            return View(new ProductEdit
            {
                //ProductId = product.ProductId,
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

        //private BrandService CreateBrandService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new BrandService(userId);
        //    return service;
        //}

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();

            var model = svc.GetProductDetailsById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Product was successfully deleted";

            return RedirectToAction("Index");
        }

    }
}