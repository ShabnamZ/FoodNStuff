using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodNStuff.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            var transactionList = _db.Transactions.OrderBy(transaction => transaction.Customer.LastName).ThenBy(transaction => transaction.Customer.FirstName).ToList();
            return View(transactionList);
        }

        //GET :Transaction/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "Name");

            return View();
        }

        //POST: Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Transactions transaction)
        {
            if (ModelState.IsValid && transaction.CustomerID !=0 && transaction.ProductID !=0)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "Name");


            return View(transaction);
        }
    }
}