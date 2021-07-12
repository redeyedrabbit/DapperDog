using DapperDog.Models.Category;
using DapperDog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperDog.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(CreateCategoryService().GetCategoryList());
        }

        public ActionResult Create()
        {
            ViewBag.Name = "New Category";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateCategoryService().CreateCategory(model))
            {
                TempData["SaveResult"] = "Category Successfully Created!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not create a Category");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var category = CreateCategoryService().GetCategoryDetailsById(id);
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = CreateCategoryService().GetCategoryDetailsById(id);
            return View(new CategoryEdit
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CategoryId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateCategoryService().UpdateCategory(model))
            {
                TempData["SaveResult"] = "Category Successfully Updated!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not edit a Category");
            return View(model);
        }

        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;
        }


        public ActionResult Delete(int id)
        {
            var svc = CreateCategoryService();

            var model = svc.GetCategoryDetailsById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            var service = CreateCategoryService();

            service.DeleteCategory(id);

            TempData["SaveResult"] = "The Category was successfully deleted";

            return RedirectToAction("Index");
        }
    }
}