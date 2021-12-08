using OOPCourse.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnkhMorporkAdventure.Controllers
{
    public class BeggarsController : Controller
    {
        private IBeggarsRepo _beggars;

        public BeggarsController(IBeggarsRepo beggarsRepo)
        {
            _beggars = beggarsRepo;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}