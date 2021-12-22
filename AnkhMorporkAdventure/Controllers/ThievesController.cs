using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Infrastructure;
using AnkhMorporkAdventure.Models;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class ThievesController : Controller
    {       
        public ActionResult ThievesIndex(IThiefGuild thieves)
        {            
            if (NumberOfTheftsManager.NumberOfThefts == 0)
            {
                return RedirectToAction("Index", "Game", new GameIndexMessageModel
                {
                    Title = "Have a nice day",
                    Message = "Wandering through city u came accross a stranger who wish u a good luck",
                    Died = false
                });
            }

            NumberOfTheftsManager.NumberOfThefts--;
            var thief = thieves.GetThief();
            
            return View(thief);
        }
        
        public ActionResult Confirm(Player player)
        {
            if (!player.GetMoney(10))
                return RedirectToAction("Index", "Game", new GameIndexMessageModel { 
                    Title = "You died",
                    Message = "U try to fool a thief guild, it leaded to your death",
                    Died = true                    
                });
            return RedirectToAction("Index", "Game");
        }
    }
}