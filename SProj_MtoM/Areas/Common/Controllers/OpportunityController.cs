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
            var opportunities = objBs.GetALL().Where(x=>x.IsApproved=="A").ToList();

            //ViewBag.TotalPages = Math.Ceiling(objBs.GetALL().Where(x => x.IsApproved == "A").Count() / 2.0);
            //int page = int.Parse(Page == null ? "1" : Page);
            //ViewBag.Page = page;
            //opportunities = opportunities.Skip((page - 1) * 10).Take(10);


            return View(opportunities);


        }


       
    }

}