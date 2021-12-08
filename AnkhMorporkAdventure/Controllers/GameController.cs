using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Wander()
        {
            var random = new Random();
            switch (1)
            {
                case 1:
                    return RedirectToAction("Index", "Assassins");
                case 2:
                    return RedirectToAction("Index", "Thieves");
                case 3:
                    return RedirectToAction("Index", "Beggars");
                case 4:
                    return RedirectToAction("Index", "Fools");
            }
        }
    }
}