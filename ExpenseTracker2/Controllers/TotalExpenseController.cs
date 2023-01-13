using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpenseTracker2.Models;

namespace ExpenseTracker2.Controllers
{
    public class TotalExpenseController : Controller
    {
        private FamilyExpenseDBEntities db = new FamilyExpenseDBEntities();

        // GET: TotalExpense
        public ActionResult Index()
        {
            return View(db.TotalExpenses.ToList());
        }

        // GET: TotalExpense/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            if (totalExpense == null)
            {
                return HttpNotFound();
            }
            return View(totalExpense);
        }

        // GET: TotalExpense/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TotalExpense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TotalLimit")] TotalExpense totalExpense)
        {
            if (ModelState.IsValid)
            {
                db.TotalExpenses.Add(totalExpense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(totalExpense);
        }

        // GET: TotalExpense/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            if (totalExpense == null)
            {
                return HttpNotFound();
            }
            return View(totalExpense);
        }

        // POST: TotalExpense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TotalLimit")] TotalExpense totalExpense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totalExpense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(totalExpense);
        }

        // GET: TotalExpense/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            if (totalExpense == null)
            {
                return HttpNotFound();
            }
            return View(totalExpense);
        }

        // POST: TotalExpense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            TotalExpense totalExpense = db.TotalExpenses.Find(id);
            db.TotalExpenses.Remove(totalExpense);
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
