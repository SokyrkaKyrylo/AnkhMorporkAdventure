using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Domain.Models;
using AnkhMorporkAdventure.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AnkhMorporkAdventure
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var dbContext = ApplicationContext.GetInstance();

            if (!dbContext.Database.Exists())
                DbManager.FeedDb(dbContext);

            ModelBinders.Binders.Add(typeof(Player), new PlayerModelBinder());
            ModelBinders.Binders.Add(typeof(IAssassinGuild), 
                new AssassinGuildModelBinder(dbContext.Assassins.AsEnumerable().ToList()));
            ModelBinders.Binders.Add(typeof(IBeggarGuild),
                new BeggarGuildModelBinder(dbContext.Beggars.AsEnumerable().ToList()));
            ModelBinders.Binders.Add(typeof(IThiefGuild),
                new ThiefGuildModelBinder(dbContext.Thieves.AsEnumerable().ToList()));
            ModelBinders.Binders.Add(typeof(IFoolGuild),
                new FoolGuildModelBinder(dbContext.Fools.AsEnumerable().ToList()));
        }
    }
}
