using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Models;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class AssassinsController : Controller
    {
        private readonly IAssassinsRepo _assassins;

        public AssassinsController(IAssassinsRepo assassins)
        {
            this._assassins = assassins;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contract()
        {
            return View();
        }
           
        [HttpPost]
        public ActionResult Contract(int reward, Player player)
        {
            var assassin = _assassins.GetAssassin(reward);

            if (assassin == null)
                return RedirectToAction("End", "Game",
                    routeValues: new { message = "Sorry, but we don't have killer who will make this job for this reward" });

            if (!player.GetMoney(reward))
            {
                return RedirectToAction("End", "Game",
                   routeValues: new { message = "Ha, u decided to treat us, so u are dead man" });
            }

            return PartialView("Result", assassin);
        }
    }
}
