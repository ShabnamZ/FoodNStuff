using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        //GET: Customer/Edit/{id}

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return new HttpNotFoundResult();
            }
           ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "Name");
            return View(transaction);
        }

        //POST: Restaurant/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transactions transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "Name");
            return View(transaction);
        }

        //GET : Customer/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Transactions transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //GET: Restaurant/Delete/{id}

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //POST : Customer/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Transactions transaction = _db.Transactions.Find(id);
            _db.Transactions.Remove(transaction);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}