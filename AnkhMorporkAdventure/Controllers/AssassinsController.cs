using OOPCourse.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class AssassinsController : Controller
    {
        private readonly IAssassinsRepo _assassins;

        public AssassinsController(IAssassinsRepo assassins)
        {
            this._assassins = assassins;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}