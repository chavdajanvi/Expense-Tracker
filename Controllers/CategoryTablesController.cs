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
    public class CategoryTablesController : Controller
    {
        private DB_ExpenseTrakerEntities db = new DB_ExpenseTrakerEntities();

        // GET: CategoryTables
        public ActionResult Index()
        {
            var categoryTables = db.CategoryTables.Include(c => c.ExpenseTable);
            return View(categoryTables.ToList());
        }

        // GET: CategoryTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTable categoryTable = db.CategoryTables.Find(id);
            if (categoryTable == null)
            {
                return HttpNotFound();
            }
            return View(categoryTable);
        }

        // GET: CategoryTables/Create
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.ExpenseTables, "Category_ID", "Title");
            return View();
        }

        // POST: CategoryTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Expense_ID,Category_Name,Category_Expense_Limit,Category_ID")] CategoryTable categoryTable)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTables.Add(categoryTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_ID = new SelectList(db.ExpenseTables, "Category_ID", "Title", categoryTable.Category_ID);
            return View(categoryTable);
        }

        // GET: CategoryTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTable categoryTable = db.CategoryTables.Find(id);
            if (categoryTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(db.ExpenseTables, "Category_ID", "Title", categoryTable.Category_ID);
            return View(categoryTable);
        }

        // POST: CategoryTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Expense_ID,Category_Name,Category_Expense_Limit,Category_ID")] CategoryTable categoryTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.ExpenseTables, "Category_ID", "Title", categoryTable.Category_ID);
            return View(categoryTable);
        }

        // GET: CategoryTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTable categoryTable = db.CategoryTables.Find(id);
            if (categoryTable == null)
            {
                return HttpNotFound();
            }
            return View(categoryTable);
        }

        // POST: CategoryTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryTable categoryTable = db.CategoryTables.Find(id);
            db.CategoryTables.Remove(categoryTable);
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
