using DapperDog.Models.Transaction;
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
    public class TransactionController : Controller
    {
        /// GET: Transaction
        public ActionResult Index()
        {
            return View(CreateTransactionService().GetTransactionList());
        }

        public ActionResult Create()
        {
            ViewBag.Name = "New Transaction";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateTransactionService().CreateTransaction(model))
            {
                TempData["SaveResult"] = "Transaction Successfully Created!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not create a Transaction");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var transaction = CreateTransactionService().GetTransactionDetailsById(id);
            return View(transaction);
        }

        public ActionResult Edit(int id)
        {
            var transaction = CreateTransactionService().GetTransactionDetailsById(id);
            return View(new TransactionEdit
            {
                TransactionId = transaction.TransactionId,
                CustomerId = transaction.CustomerId,
                ProductId = transaction.ProductId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TransactionId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateTransactionService().UpdateTransaction(model))
            {
                TempData["SaveResult"] = "Transaction Successfully Updated!";
                return RedirectToAction("Index");
            }

            //Did not save correctly
            ModelState.AddModelError("", "Soemthing went wrong = could not edit a Transaction");
            return View(model);
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }


        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionService();

            var model = svc.GetTransactionDetailsById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTransaction(int id)
        {
            var service = CreateTransactionService();

            service.DeleteTransaction(id);

            TempData["SaveResult"] = "The Transaction was successfully deleted";

            return RedirectToAction("Index");
        }
    }
}