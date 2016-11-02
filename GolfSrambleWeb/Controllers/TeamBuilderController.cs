using System.Linq;
using System.Web.Mvc;
using GolfSrambleWeb.Models;
using System.Collections.Generic;
namespace GolfSrambleWeb.Controllers
{
    public class TeamBuilderController : Controller
    {
        private PlayersCtxtContext db = new PlayersCtxtContext();
        public object lb1;

        public ActionResult Index()
        {
           
            return View(db.PlayersCtxt.ToList());
        }

        public ActionResult addPlayer()
        {
            return View(db.PlayersCtxt.ToList());
        }
        /*public void RemoveFromGrid(string item)
        {
          
        }
        /*
        public ActionResult PlayerInfo()
        {
            Playerz playerz = new Playerz();
            List<Playerz> mylist = new List<Playerz>();

            playerz.id = 1;
            playerz.level = "A";
            playerz.firstName = "Mark";
            playerz.lastName = "Farrow";
            mylist.Add(playerz);

            playerz = new Playerz();
            playerz.id = 2;
            playerz.level = "B";
            playerz.firstName = "Gary";
            playerz.lastName = "Johnston";
            mylist.Add(playerz);

            playerz = new Playerz();
            playerz.id = 3;
            playerz.level = "C";
            playerz.firstName = "Andy";
            playerz.lastName = "Zopeta";
            mylist.Add(playerz);

            playerz = new Playerz();
            playerz.id = 4;
            playerz.level = "C";
            playerz.firstName = "Opey";
            playerz.lastName = "Taylor";
            mylist.Add(playerz);

            playerz = new Playerz();
            playerz.id = 5;
            playerz.level = "B";
            playerz.firstName = "Tony";
            playerz.lastName = "Bologna";
            mylist.Add(playerz);

            playerz = new Playerz();
            playerz.id = 6;
            playerz.level = "A";
            playerz.firstName = "Kevin";
            playerz.lastName = "Carpenter";
            mylist.Add(playerz);
            var data = mylist;
            return View(data);
            
        }
        */
    }
}
