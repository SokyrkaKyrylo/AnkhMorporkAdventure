using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Domain.Models;
using AnkhMorporkAdventure.Infrastructure;
using AnkhMorporkAdventure.Models;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class FoolsController : Controller
    {
        private IFoolsRepo _fools;

        public FoolsController(IFoolsRepo fools)
        {
            _fools = fools;
        }

        public ActionResult FoolsIndex()
        {
            var fool = _fools.GetFool();
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