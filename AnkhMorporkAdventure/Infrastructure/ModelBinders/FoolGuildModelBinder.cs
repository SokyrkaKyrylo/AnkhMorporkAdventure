using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Concrete.Guilds;
using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Infrastructure
{
    public class FoolGuildModelBinder : IModelBinder
    {
        private const string _sessionKey = "Fool";

        private IEnumerable<Fool> _repo;

        public FoolGuildModelBinder(IEnumerable<Fool> repo)
        {
            _repo = repo;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            IFoolGuild fool = null;
            if (controllerContext.HttpContext.Session != null)
            {
                fool = (IFoolGuild)controllerContext.HttpContext.Session[_sessionKey];
            }

            if (fool == null)
            {
                fool = new FoolGuild(_repo);
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[_sessionKey] = fool;
                }
            }

            return fool;
        }
    }
}