using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Concrete;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class BeggarsController : Controller
    {
        private IBeggarsRepo _beggars;

        public BeggarsController(IBeggarsRepo beggarsRepo)
        {
            _beggars = beggarsRepo;
        }

        public ActionResult Index()
        {
            var beggar = _beggars.GetBeggar();
            return View(beggar);
        }

        public ActionResult Bear(Player player)
        {
            var result = player.Inventory.GetItem("Bear");

            if (result)
                return View("Index", "Game");
            return RedirectToAction("End", "Game", new
            {
                message = "You don't have bear in your inventory, " +
                "so this beggar chased u to death"
            });
        }

        public ActionResult Fee(decimal fee, Player player)
        {
            if (!player.GetMoney(fee))
            {
                return RedirectToAction("End", "Game", new
                {
                    message = "You don't have enough money to give him " +
               "so this beggar chased u to death ("
                });
            }
            return RedirectToAction("Index", "Game");
        }
    }
}