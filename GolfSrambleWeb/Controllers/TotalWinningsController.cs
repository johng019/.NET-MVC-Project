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
    public class TotalWinningsController : Controller
    {
        private WinningsContext db = new WinningsContext();

        // GET: TotalWinnings
        public ActionResult Index()
        {
            return View(db.Winnings.ToList());
        }
        public ActionResult Search(string Searchbox)
        {
            var winnings = (from p in db.Winnings
                          where p.LastName.Contains(Searchbox)
                          || p.FirstName.Contains(Searchbox)
                          select p).ToList();
            return View("Index",winnings);
        }
        // GET: TotalWinnings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalWinnings totalWinnings = db.Winnings.Find(id);
            if (totalWinnings == null)
            {
                return HttpNotFound();
            }
            return View(totalWinnings);
        }
        [Authorize(Roles = "Admin, Manager")]
        // GET: TotalWinnings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TotalWinnings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Level,Total")] TotalWinnings totalWinnings)
        {
            if (ModelState.IsValid)
            {
                db.Winnings.Add(totalWinnings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(totalWinnings);
        }
        [Authorize(Roles = "Admin, Manager")]
        // GET: TotalWinnings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalWinnings totalWinnings = db.Winnings.Find(id);
            if (totalWinnings == null)
            {
                return HttpNotFound();
            }
            return View(totalWinnings);
        }

        // POST: TotalWinnings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Level,Total")] TotalWinnings totalWinnings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totalWinnings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(totalWinnings);
        }
        [Authorize(Roles = "Admin, Manager")]
        // GET: TotalWinnings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalWinnings totalWinnings = db.Winnings.Find(id);
            if (totalWinnings == null)
            {
                return HttpNotFound();
            }
            return View(totalWinnings);
        }

        // POST: TotalWinnings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TotalWinnings totalWinnings = db.Winnings.Find(id);
            db.Winnings.Remove(totalWinnings);
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
