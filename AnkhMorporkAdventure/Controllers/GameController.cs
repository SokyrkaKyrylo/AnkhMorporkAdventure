using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Infrastructure;
using System;
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
                    return RedirectToAction("Meeting", "Thieves");
                case 3:
                    return RedirectToAction("Meeting", "Beggars");
                case 4:
                    return RedirectToAction("Meeting", "Fools");
            }
        }

        public ActionResult End(string message)
        {
            return View("End", model: message);
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