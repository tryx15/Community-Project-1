using Proj_BOL;
using SProj_MtoM.Areas.Common.Models;
using SProj_MtoM.Areas.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private DB_Models db = new DB_Models();


        // GET: Common/Basket
        public ActionResult Index(Basket basket2)
        {
            Basket basket = Basket.GetBasket(this.HttpContext);
            BasketViewModel viewModel = new BasketViewModel
            {
                BasketLines = basket.GetBasketLines(),
                Basket2 = basket2
            };
            return View(viewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToBasket(Basket basket2, int? Oppor_Id)
        {
            if (Oppor_Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Opportunity addedItem = db.tbl_Opportunity.Find(Oppor_Id);


            Basket basket = Basket.GetBasket(this.HttpContext);
            basket.AddToBasket(basket,addedItem);
            return RedirectToAction("Index", "Opportunity");
           
        }


        [HttpGet]
        public ActionResult RemoveLine(Basket basket2, int? Oppor_Id)
        {
            if (Oppor_Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Opportunity addedItem = db.tbl_Opportunity.Find(Oppor_Id);

            Basket basket = Basket.GetBasket(this.HttpContext);
            basket.RemoveLine(basket, addedItem);
            return RedirectToAction("Index");
        }

        public PartialViewResult Summary(Basket basket2)
        {
            return PartialView(basket2);
        }



    }
}