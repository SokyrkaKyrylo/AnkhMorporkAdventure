using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Domain.Models;
using AnkhMorporkAdventure.Infrastructure;
using AnkhMorporkAdventure.Models;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class FoolsController : Controller
    {
     
        public ActionResult FoolsIndex(IFoolGuild fools)
        {
            var fool = fools.GetFool();
            return View(fool);
        }

        public ActionResult Offer(Fool fool, Player player)
        {
            player.AddMoney(fool.Salary);
            return RedirectToAction("Index", "Game", new GameIndexMessageModel
            {
                Title = "Congrats",
                Message = $"You have earned {MoneyConvertor.Convert(fool.Salary)}",
                Died = false
            });
        }
    }
}