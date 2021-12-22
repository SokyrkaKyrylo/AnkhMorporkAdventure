using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Models;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class BeggarsController : Controller
    {       
        public ActionResult BeggarsIndex(IBeggarGuild beggars)
        {
            var beggar = beggars.GetBeggar();
            return View(beggar);
        }

        public ActionResult Beer(Player player)
        {
            var result = player.Inventory.GetItem("Bear");

            if (result)
                return View("Index", "Game", new GameIndexMessageModel
                {
                    Title = "Have a nice day",
                    Message = "A beggar, whom u gave a beer, tell u a funny history and wish a good luck",
                    Died = false
                });

            return RedirectToAction("Index", "Game", new GameIndexMessageModel
            {
                Title = "You are dead",
                Message = "You don't have bear in your inventory, " +
                "so this beggar chased u to death",
                Died = true
            });
        }

        public ActionResult Fee(decimal fee, Player player)
        {
            if (!player.GetMoney(fee))
            {
                return RedirectToAction("Index", "Game", new GameIndexMessageModel
                {
                    Title = "You are dead",
                    Message = "You don't have enough money to give him " +
                            "so this beggar chased u to death (",
                    Died = true
                });
            }
            return RedirectToAction("Index", "Game");
        }
    }
}