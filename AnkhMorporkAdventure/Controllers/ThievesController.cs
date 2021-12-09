using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Infrastructure;
using AnkhMorporkAdventure.Models;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class ThievesController : Controller
    {
        private IThievesRepo _thieves;

        public ThievesController(IThievesRepo thieves)
        {
            _thieves = thieves;
        }

        public ActionResult Meeting()
        {
            ThiefMeetingModel model = new ThiefMeetingModel();
            
            if (NumberOfTheftsManager.NumberOfThefts == 0)
            {
                model.Message = "Wandering in downtown u came across a stranger who wish u a good luck";
                return View("Meeting", model: model);
            }

            NumberOfTheftsManager.NumberOfThefts--;
            model.Thief = _thieves.GetThief();
            
            return View("Meeting", model: model);
        }
        
        public ActionResult Confirm(Player player)
        {
            if (!player.GetMoney(10))
                return RedirectToAction("End", "Game", new { message = "You died" });
            return RedirectToAction("Index", "Game");
        }
    }
}