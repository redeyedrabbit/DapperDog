using DapperDog.Data;
using DapperDog.Models.Product;
using DapperDog.Services;
using Microsoft.AspNet.Identity;
using MvcPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace DapperDog.WebMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public ApplicationDbContext _db = new ApplicationDbContext();
        
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

            // Show Category Name in dropdown option
            List<Category> Categories = new CategoryService().GetCategories().ToList();
            var queryTwo = from m in Categories
                        select new SelectListItem()
                        {
                            Value = m.CategoryId.ToString(),
                            Text = m.Name
                        };
            ViewBag.CategoryId = queryTwo.ToList();

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

            // Show Category Name in dropdown option
            List<Category> Categories = new CategoryService().GetCategories().ToList();
            var queryTwo = from m in Categories
                           select new SelectListItem()
                           {
                               Value = m.CategoryId.ToString(),
                               Text = m.Name
                           };
            ViewBag.CategoryId = queryTwo.ToList();

            return View(new ProductEdit
            {                
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


        public ActionResult ViewByCategory(int categoryId, int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            var productsByCategory = _db.Products.Where(p => p.CategoryId.Equals(categoryId)).OrderBy(p => p.ProductId).ToPagedList(currentPageIndex, 10);
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", categoryId);
            ViewBag.CategoryDisplayId = categoryId;
            return View("ProductsByCategory", productsByCategory);
        }


    }
}