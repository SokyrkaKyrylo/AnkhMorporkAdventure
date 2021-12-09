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

        [HttpGet]
        public ActionResult Offer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Confirm(RewardModel r, Player player)
        {
            if (r == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                var assassin = _assassins.GetAssassin(r.Reward);

                if (assassin == null)
                    return RedirectToAction("End", "Game",
                        routeValues: new { message = "Sorry, but we don't have killer who will make this job for this reward" });

                if (!player.GetMoney(r.Reward))
                {
                    return RedirectToAction("End", "Game",
                       routeValues: new { message = "Ha, u decided to treat us, so u are dead man" });
                }

                return View("Result", assassin);
            }
            return View(r);
        }
    }
}
