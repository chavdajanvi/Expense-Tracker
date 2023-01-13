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
    public class TotalExpenseTablesController : Controller
    {
        private DB_ExpenseTrakerEntities db = new DB_ExpenseTrakerEntities();

        // GET: TotalExpenseTables
        public ActionResult Index()
        {
            return View(db.TotalExpenseTables.ToList());
        }

        // GET: TotalExpenseTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalExpenseTable totalExpenseTable = db.TotalExpenseTables.Find(id);
            if (totalExpenseTable == null)
            {
                return HttpNotFound();
            }
            return View(totalExpenseTable);
        }

        // GET: TotalExpenseTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TotalExpenseTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Total_Expense")] TotalExpenseTable totalExpenseTable)
        {
            if (ModelState.IsValid)
            {
                db.TotalExpenseTables.Add(totalExpenseTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(totalExpenseTable);
        }

        // GET: TotalExpenseTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalExpenseTable totalExpenseTable = db.TotalExpenseTables.Find(id);
            if (totalExpenseTable == null)
            {
                return HttpNotFound();
            }
            return View(totalExpenseTable);
        }

        // POST: TotalExpenseTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Total_Expense")] TotalExpenseTable totalExpenseTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totalExpenseTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(totalExpenseTable);
        }

        // GET: TotalExpenseTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalExpenseTable totalExpenseTable = db.TotalExpenseTables.Find(id);
            if (totalExpenseTable == null)
            {
                return HttpNotFound();
            }
            return View(totalExpenseTable);
        }

        // POST: TotalExpenseTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TotalExpenseTable totalExpenseTable = db.TotalExpenseTables.Find(id);
            db.TotalExpenseTables.Remove(totalExpenseTable);
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
