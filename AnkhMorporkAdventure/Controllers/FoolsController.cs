using AnkhMorporkAdventure.Domain.Abstract;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class FoolsController : Controller
    {
        private IFoolsRepo _fools;

        public FoolsController(IFoolsRepo fools)
        {
            _fools = fools;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}