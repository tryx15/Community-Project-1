using SProj_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Areas.Common.Controllers
{
    public class OpportunityController : Controller
    {
        private Opportunity_Bs objBs;
        public OpportunityController()
        {
            objBs = new Opportunity_Bs();
        }
        // GET: Common/Opportunity
        public ActionResult Index(string Page)
        {
            var opportunities = objBs.GetALL().ToList();

            ViewBag.TotalPages = Math.Ceiling(objBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            opportunities = opportunities.Skip((page - 1) * 10).Take(10).ToList();


            return View(opportunities);


        }


       
    }

}