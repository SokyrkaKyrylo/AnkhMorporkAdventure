using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Models;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class AssassinsController : Controller
    {
        public ActionResult AssassinsIndex()
        {
            return View("AssassinsIndex");
        }

        public ActionResult Contract()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Contract(int reward, Player player, IAssassinGuild assassins)
        {
            var assassin = assassins.GetAssassin(reward);

            if (assassin == null)
                return RedirectToAction("Index", "Game",
                   new GameIndexMessageModel
                   {
                       Title = "You died",
                       Message = "Sorry, but we don't have killer who will make this job for this reward",
                       Died = false
                   });

            if (!player.GetMoney(reward))
            {
                return RedirectToAction("Index", "Game",
                    new GameIndexMessageModel
                    {
                        Title = "You died",
                        Message = "Ha, u decided to treat us, so u are dead man",
                        Died = true
                    });
            }

            return RedirectToAction("Index", "Game",
                new GameIndexMessageModel
                {
                    Title = "Contract was successfully signed",
                    Message = $"{assassin.Name} will find to discuss some details",
                    Died = false
                });
        }
    }
}
