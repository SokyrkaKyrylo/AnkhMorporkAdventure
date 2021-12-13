using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Infrastructure;
using AnkhMorporkAdventure.Models;
using System;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index(GameIndexMessageModel model)
        {
            if (model == null)
                return View("Index", null);
            return View("Index", model);
        }

        public ActionResult Wander()
        {
            var random = new Random();
            switch (random.Next(1,5))
            {
                case 1:
                    return RedirectToAction("AssassinsIndex", "Assassins");
                case 2:
                    return RedirectToAction("ThievesIndex", "Thieves");
                case 3:
                    return RedirectToAction("BeggarsIndex", "Beggars");
                case 4:
                    return RedirectToAction("FoolsIndex", "Fools");
            }
            return View("Index", null);
        }
      
        public ActionResult Restart(Player player)
        {
            var neededSum = 100 - player.Purse;
            player.AddMoney(neededSum);
            NumberOfTheftsManager.NumberOfThefts = 6;
            return RedirectToAction("Index");
        }

        public ActionResult Info(Player player)
        {
            return PartialView(player);
        }

        public ActionResult Inventory(Player player)
        {
            return PartialView(player.Inventory);
        }

    }
}