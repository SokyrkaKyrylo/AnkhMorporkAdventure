using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Concrete.Guilds;
using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Infrastructure
{
    public class BeggarGuildModelBinder : IModelBinder
    {
        private const string _sessionKey = "beggars";

        private IEnumerable<Beggar> _repo;

        public BeggarGuildModelBinder(IEnumerable<Beggar> assassinsRepo)
        {
            _repo = assassinsRepo;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            IBeggarGuild beggars = null;
            if (controllerContext.HttpContext.Session != null)
            {
                beggars = (IBeggarGuild)controllerContext.HttpContext.Session[_sessionKey];
            }

            if (beggars == null)
            {
                beggars = new BeggarGuild(_repo);
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[_sessionKey] = beggars;
                }
            }

            return beggars;
        }
    }
}