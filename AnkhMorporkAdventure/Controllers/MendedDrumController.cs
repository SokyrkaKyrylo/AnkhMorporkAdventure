using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Models;
using System.Linq;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class MendedDrumController : Controller
    {
        private IItemsRepo _items;

        public MendedDrumController(IItemsRepo items)
        {
            _items = items;
        }

        public ActionResult Bar()
        {
            return View(_items.Items);
        }

        [HttpPost]
        public ActionResult Buy(int id, int quantity, Player player)
        {
            var item = _items.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return HttpNotFound();

            if (!player.GetMoney(item.Price * quantity))
                return RedirectToAction("Index", "Game",
                    new GameIndexMessageModel 
                    { 
                        Title = "You died",
                        Message = "You ask on credit, but this is Ankh-Morpork, they just kill u and get all money",
                        Died = true
                    });

            string errorMessage = "";
            if ((errorMessage = player.Inventory.AddItem(item, quantity)) != "")
            {
                return RedirectToAction("Index", "Game", new GameIndexMessageModel
                {
                    Title = "Your backpack is full of it",
                    Message = errorMessage,
                });
            }
            
            return RedirectToAction("Index", "Game");
        }
    }
}