using AnkhMorporkAdventure.Models;
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

        [HttpGet]
        public ActionResult Offer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Confirm(RewardModel r)
        {
            if (r == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {        
                //var assassin = _assassins.Assassins
                //    .Where(a => a.Status)
                //    .FirstOrDefault(a => a.HighRewardBound >= reward && a.LowRewardBound <= reward);

                //if (assassin == null)
                //    return RedirectToAction("End", "Game",
                //        new { message = "Sorry, but we don't have killer who will make this job for this reward" });

                return RedirectToAction("Index");
            }
            return View(r);
        }
    }
}