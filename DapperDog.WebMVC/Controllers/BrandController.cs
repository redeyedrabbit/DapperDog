﻿using DapperDog.Models.Brand;
using DapperDog.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperDog.WebMVC.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            return View(CreateBrandService().GetBrandList());
        }

        public ActionResult Create()
        {
            ViewBag.Name = "New Brand";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateBrandService().CreateBrand(model))
            {
                TempData["SaveResult"] = "Brand Successfully Created!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not create a Brand");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var brand = CreateBrandService().GetBrandDetailsById(id);
            return View(brand);
        }

        public ActionResult Edit(int id)
        {
            var brand = CreateBrandService().GetBrandDetailsById(id);
            return View(new BrandEdit
            {
                BrandId = brand.BrandId,
                Name = brand.Name
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BrandEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BrandId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateBrandService().UpdateBrand(model))
            {
                TempData["SaveResult"] = "Brand Successfully Updated!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not edit a Brand");
            return View(model);
        }

        private BrandService CreateBrandService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BrandService(userId);
            return service;
        }


        public ActionResult Delete(int brandId)
        {
            var service = CreateBrandService();

            var model = service.GetBrandDetailsById(brandId);
            return View(model);
        }
    }
}