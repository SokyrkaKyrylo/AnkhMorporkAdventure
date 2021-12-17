using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Infrastructure;
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
            
            ModelBinders.Binders.Add(typeof(Player), new PlayerModelBinder());


            var dbContext = ApplicationContext.GetInstance();
            if (dbContext.Database.Exists())
                DbManager.RefershDb(dbContext);
            else
                DbManager.FeedDb(dbContext);
        }
    }
}
