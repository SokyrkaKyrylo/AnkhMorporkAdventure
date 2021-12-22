using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Concrete.Guilds;
using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Infrastructure
{
    public class AssassinGuildModelBinder : IModelBinder
    {
        private const string _sessionKey = "Assassins";

        private IEnumerable<Assassin> _repo;

        public AssassinGuildModelBinder(IEnumerable<Assassin> assassinsRepo)
        {
            _repo = assassinsRepo;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            IAssassinGuild assassins = null;
            if (controllerContext.HttpContext.Session != null)
            {
                assassins = (IAssassinGuild)controllerContext.HttpContext.Session[_sessionKey];
            }

            if (assassins == null)
            {
                assassins = new AssassinsGuild(_repo);
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[_sessionKey] = assassins;
                }
            }

            return assassins;
        }
    }
}