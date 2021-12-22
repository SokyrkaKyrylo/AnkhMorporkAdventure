using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Concrete.Guilds;
using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Infrastructure
{
    public class ThiefGuildModelBinder : IModelBinder
    {
        private const string _sessionKey = "Thief";

        private IEnumerable<Thief> _repo;

        public ThiefGuildModelBinder(IEnumerable<Thief> thieves)
        {
            _repo = thieves;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            IThiefGuild thieves = null;
            if (controllerContext.HttpContext.Session != null)
            {
                thieves = (IThiefGuild)controllerContext.HttpContext.Session[_sessionKey];
            }

            if (thieves == null)
            {
                thieves = new ThiefGuild(_repo);
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[_sessionKey] = thieves;
                }
            }

            return thieves;
        }
    }
}