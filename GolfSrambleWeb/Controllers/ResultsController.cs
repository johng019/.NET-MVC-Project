using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GolfSrambleWeb.Models;

namespace GolfSrambleWeb.Controllers
{
    public class ResultsController : Controller
    {
        private ResultsCtxtContext db = new ResultsCtxtContext();

        // GET: Results
        public ActionResult Index()
        {
            return View(db.ResultsCtxt.ToList());
        }

        public ActionResult Search(string Searchbox)
        {
            var result = (from p in db.ResultsCtxt
                          where p.LastName.Contains(Searchbox)
                          || p.FirstName.Contains(Searchbox)
                          select p).ToList();
            return View("Index", result);
        }

        // GET: Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.ResultsCtxt.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }
        [Authorize(Roles = "Admin, Manager")]
        // GET: Results/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResultsId,Date,LastName,FirstName,Level,Score,Winnings")] Results results)
        {
            if (ModelState.IsValid)
            {
                db.ResultsCtxt.Add(results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(results);
        }
        [Authorize(Roles = "Admin, Manager")]
        // GET: Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.ResultsCtxt.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResultsId,Date,LastName,FirstName,Level,Score,Winnings")] Results results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(results);
        }
        [Authorize(Roles = "Admin, Manager")]
        // GET: Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.ResultsCtxt.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Results results = db.ResultsCtxt.Find(id);
            db.ResultsCtxt.Remove(results);
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
