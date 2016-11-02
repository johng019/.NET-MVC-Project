using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GolfSrambleWeb.Models;
using System.IO;

namespace GolfSrambleWeb.Controllers
{
    public class PlayersController : Controller

    {
        private PlayersCtxtContext db = new PlayersCtxtContext();
       
        // GET: Players
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string Searchbox)
        {
            var player = (from p in db.PlayersCtxt
                          where p.LastName.Contains(Searchbox)
                          || p.FirstName.Contains(Searchbox)
                          select p).ToList();
            return View("PlayerInfo", player);
        }
        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Players players = db.PlayersCtxt.Find(id);
            if (players == null)
            {
                return HttpNotFound();
            }
            return View(players);
        }
        [Authorize(Roles = "Admin, Manager")]
        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        /*public ActionResult GetImage(int id)
        {
            byte[] imageData = db.PlayersCtxt.Find(id).Picture;
            return File(imageData, "image/jpeg");
        }*/

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Level,Email,Phone,Picture,ImagePath")] Players players, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if(ImageFile!= null)
                {
                    string pic = System.IO.Path.GetFileName(ImageFile.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/profile"), pic);

                    ImageFile.SaveAs(path);
                    players.ImagePath = pic;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        ImageFile.InputStream.CopyTo(ms);
                        players.Picture = ms.GetBuffer();
                    }
                }
                else
                {
                        string pic = System.IO.Path.GetFileName(ImageFile.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/Images/profile"), pic);

                        ImageFile.SaveAs(path);
                        players.ImagePath = pic;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            ImageFile.InputStream.CopyTo(ms);
                            players.Picture = ms.GetBuffer();
                        }
                    }
                
                db.PlayersCtxt.Add(players);
                db.SaveChanges();
                return RedirectToAction("PlayerInfo");
            }

            return View(players);
        }
        [Authorize(Roles = "Admin, Manager")]
        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Players players = db.PlayersCtxt.Find(id);
            if (players == null)
            {
                return HttpNotFound();
            }
            return View(players);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Level,Email,Phone,Picture,ImagePath")] Players players)
        {
            if (ModelState.IsValid)
            {
                db.Entry(players).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PlayerInfo");
            }
            return View(players);
        }
        [Authorize(Roles = "Admin, Manager")]
        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Players players = db.PlayersCtxt.Find(id);
            if (players == null)
            {
                return HttpNotFound();
            }
            return View(players);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Players players = db.PlayersCtxt.Find(id);
            db.PlayersCtxt.Remove(players);
            db.SaveChanges();
            return RedirectToAction("PlayerInfo");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult PlayerInfo()
        {
            return View(db.PlayersCtxt.ToList());
        }
    }
}
