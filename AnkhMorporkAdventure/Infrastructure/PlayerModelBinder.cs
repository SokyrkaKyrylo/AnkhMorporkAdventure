using AnkhMorporkAdventure.Domain.Concrete;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Infrastructure
{
    public class PlayerModelBinder : IModelBinder
    {
        private const string _sessionKey = "Player";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Player player = null;
            if (controllerContext.HttpContext.Session != null)
            {
                player = (Player)controllerContext.HttpContext.Session[_sessionKey];
            }

            if (player == null)
            {
                player = new Player(100);
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[_sessionKey] = player;
                }
            }

            return player;
        }
    }
}