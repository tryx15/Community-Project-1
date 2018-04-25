using Proj_BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Areas.Common.Models
{
    public class Basket
    {
        private string BasketID { get; set; }
        private const string BasketSessionKey = "BasketID";
        private DB_Models db = new DB_Models();

        private string GetBasketID(HttpContextBase context)
        {
            if (HttpContext.Current.Session[BasketSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[BasketSessionKey] =
                    HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempBasketID = Guid.NewGuid();
                    HttpContext.Current.Session[BasketSessionKey] = tempBasketID.ToString();
                }
            }

            return HttpContext.Current.Session[BasketSessionKey].ToString();
        }
        public static Basket GetBasket(HttpContextBase context)
        {
            Basket basket = new Basket();
            basket.BasketID = basket.GetBasketID(context);
            return basket;
        }

        // Helper method to simplify shopping cart calls
        public static Basket GetBasket(Controller controller)
        {
            return GetBasket(controller.HttpContext);
        }




        public void AddToBasket(Basket basket2, tbl_Opportunity opportunity)
        {
            var basketLine = db.BasketLines.FirstOrDefault(b => b.BasketID == BasketID &&
            b.Oppor_Id == opportunity.Oppor_Id);

            if (basketLine == null)
            {
                basketLine = new BasketLine
                {
                    Oppor_Id = opportunity.Oppor_Id,
                    BasketID = BasketID,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                db.BasketLines.Add(basketLine);
            }
            else
            {
                basketLine.Quantity++;/*= quantity;*/
            }
            db.SaveChanges();
        }



        public void RemoveLine(Basket basket2, tbl_Opportunity opportunity)
        {
            var basketLine = db.BasketLines.FirstOrDefault(b => b.BasketID == BasketID &&
            b.Oppor_Id == opportunity.Oppor_Id);
            if (basketLine != null)
            {
                db.BasketLines.Remove(basketLine);
            }
            db.SaveChanges();
        }

        public int CreateOrderLines(tbl_Volunteer volunteer)
        {


            var basketLines = GetBasketLines();

            foreach (var item in basketLines)
            {
                OrderLine orderLine = new OrderLine
                {


                    tbl_Opportunity = item.tbl_Opportunity,
                    Oppor_Id = item.Oppor_Id,
                    Oppor_Name = item.tbl_Opportunity.Oppor_Name,
                    Quantity = item.Quantity,
                    DateCreated = item.DateCreated,
                    Volun_Id = volunteer.Volun_Id


                };


                db.OrderLines.Add(orderLine);

            }

            db.SaveChanges();
            EmptyBasket();

            return volunteer.Volun_Id;
        }


        public void EmptyBasket()
        {
            var basketLines = db.BasketLines.Where(b => b.BasketID == BasketID);
            foreach (var basketLine in basketLines)
            {
                db.BasketLines.Remove(basketLine);
            }
            db.SaveChanges();
        }
        public List<BasketLine> GetBasketLines()
        {
            return db.BasketLines.Where(b => b.BasketID == BasketID).Include(s => s.tbl_Opportunity).ToList();


        }


        public int GetNumberOfItems()
        {
            // Get the count of each item in the cart and sum them up
            int? numberOfItems = 0;
            if (GetBasketLines().Count > 0)
            {
                numberOfItems = db.BasketLines.Where(b => b.BasketID == BasketID).Sum(b =>
                b.Quantity);
            }
            // Return 0 if all entries are null
            return numberOfItems ?? 0;
        }




        

    }
}