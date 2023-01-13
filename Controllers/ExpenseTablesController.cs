using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    public class ExpenseTablesController : Controller
    {
        private DB_ExpenseTrakerEntities db = new DB_ExpenseTrakerEntities();

        // GET: ExpenseTables
        public ActionResult Index()
        {
            return View(db.ExpenseTables.ToList());
        }

        // GET: ExpenseTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseTable expenseTable = db.ExpenseTables.Find(id);
            if (expenseTable == null)
            {
                return HttpNotFound();
            }
            return View(expenseTable);
        }

        // GET: ExpenseTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpenseTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category_ID,Title,Description,Amount,Date")] ExpenseTable expenseTable)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseTables.Add(expenseTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseTable);
        }

        // GET: ExpenseTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseTable expenseTable = db.ExpenseTables.Find(id);
            if (expenseTable == null)
            {
                return HttpNotFound();
            }
            return View(expenseTable);
        }

        // POST: ExpenseTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_ID,Title,Description,Amount,Date")] ExpenseTable expenseTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseTable);
        }

        // GET: ExpenseTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseTable expenseTable = db.ExpenseTables.Find(id);
            if (expenseTable == null)
            {
                return HttpNotFound();
            }
            return View(expenseTable);
        }

        // POST: ExpenseTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseTable expenseTable = db.ExpenseTables.Find(id);
            db.ExpenseTables.Remove(expenseTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
