using OOPCourse.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class TheivesController : Controller
    {
        private IThievesRepo _thieves;

        public TheivesController(IThievesRepo thieves)
        {
            _thieves = thieves;
        }

        public ActionResult Index()
        {
            return View();
        }


    }
}