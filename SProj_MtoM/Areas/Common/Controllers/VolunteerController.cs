using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Proj_BOL;
using SProj_MtoM.Areas.Common.Models;

namespace SProj_MtoM.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class VolunteerController : Controller
    {
        private DB_Models db = new DB_Models();

        // GET: Common/Volunteer
        public ActionResult Index()
        {
            return View(db.tbl_Volunteer.ToList());
        }

        // GET: Common/Volunteer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Volunteer tbl_Volunteer = db.tbl_Volunteer.Find(id);
            if (tbl_Volunteer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Volunteer);
        }


        public ActionResult Review()
        {
            Basket basket = Basket.GetBasket(this.HttpContext);
            tbl_Volunteer volunteer = new tbl_Volunteer();
            volunteer.OrderLines = new List<OrderLine>();
            foreach (var basketLine in basket.GetBasketLines())
            {
                OrderLine line = new OrderLine
                {
                    tbl_Opportunity = basketLine.tbl_Opportunity,
                    Oppor_Id = basketLine.Oppor_Id,
                    Oppor_Name = basketLine.tbl_Opportunity.Oppor_Name,
                    Quantity = basketLine.Quantity,
                    DateCreated = basketLine.DateCreated
                };
                volunteer.OrderLines.Add(line);
            }

            return View(volunteer);
        }


        // POST: Common/Volunteer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Volun_Id,VolunFname,VolunLname,VolunEmail,VolunDateofbirth,VolunStreetaddress," +
            "VolunStreetaddress2,VolunCity,VolunState,VolunZip,County,VolunAvailableMonday,VolunAvailableMondayMorning,VolunAvailableMondayAfternoon," +
            "VolunAvailableMondayEvening,VolunAvailableTuesday,VolunAvailableTuesdayMorning,VolunAvailableTuesdayAfternoon,VolunAvailableTuesdayEvening," +
            "VolunAvailableWednesday,VolunAvailableWednesdayMorning,VolunAvailableWednesdayAfternoon,VolunAvailableWednesdayEvening,VolunAvailableThursday," +
            "VolunAvailableThursdayMorning,VolunAvailableThursdayAfternoon,VolunAvailableThursdayEvening,VolunAvailableFriday,VolunAvailableFridayMorning," +
            "VolunAvailableFridayAfternoon,VolunAvailableFridayEvening,VolunAvailableSaturday,VolunAvailableSaturdayMorning,VolunAvailableSaturdayAfternoon," +
            "VolunAvailableSaturdayEvening,VolunAvailableSunday,VolunAvailableSundayMorning,VolunAvailableSundayAfternoon,VolunAvailableSundayEvening," +
            "VoluntNutrition,VolunTrainingFacilitator,VolunAdmin,VolunGeneral,VolunHealthyliving,VolunDiseaseManagement,VolunFallsPrevention,VolunCaregiver," +
            "VolunMentalWellness,VolunEvents,VolunSocialMedia,VolunOtherInterest")] tbl_Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {

                volunteer.DateCreated = DateTime.Now;
                volunteer.IsApproved = "P";
                db.tbl_Volunteer.Add(volunteer);
                db.SaveChanges();

                //add the orderlines to the database after creating the order
                Basket basket = Basket.GetBasket(this.HttpContext);

                basket.CreateOrderLines(volunteer);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = volunteer.Volun_Id });
            }
            return RedirectToAction("Review");
        }




        // GET: Common/Volunteer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Volunteer tbl_Volunteer = db.tbl_Volunteer.Find(id);
            if (tbl_Volunteer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Volunteer);
        }

        // POST: Common/Volunteer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Volun_Id,VolunFname,VolunLname,VolunEmail,VolunDateofbirth,VolunStreetaddress,VolunStreetaddress2,VolunCity,VolunState,VolunZip,County,VolunAvailableMonday,VolunAvailableMondayMorning,VolunAvailableMondayAfternoon,VolunAvailableMondayEvening,VolunAvailableTuesday,VolunAvailableTuesdayMorning,VolunAvailableTuesdayAfternoon,VolunAvailableTuesdayEvening,VolunAvailableWednesday,VolunAvailableWednesdayMorning,VolunAvailableWednesdayAfternoon,VolunAvailableWednesdayEvening,VolunAvailableThursday,VolunAvailableThursdayMorning,VolunAvailableThursdayAfternoon,VolunAvailableThursdayEvening,VolunAvailableFriday,VolunAvailableFridayMorning,VolunAvailableFridayAfternoon,VolunAvailableFridayEvening,VolunAvailableSaturday,VolunAvailableSaturdayMorning,VolunAvailableSaturdayAfternoon,VolunAvailableSaturdayEvening,VolunAvailableSunday,VolunAvailableSundayMorning,VolunAvailableSundayAfternoon,VolunAvailableSundayEvening,VoluntNutrition,VolunTrainingFacilitator,VolunAdmin,VolunGeneral,VolunHealthyliving,VolunDiseaseManagement,VolunFallsPrevention,VolunCaregiver,VolunMentalWellness,VolunEvents,VolunSocialMedia,VolunOtherInterest,VolunBackgroundCheckRequired,VolunBackgroundCheckCompletedOn,VolunBackgroundCheckExpiresOn,VolunActivitiesParticipated,VolunMarkVolunteer,VolunFlagged,VolunFlaggedInformation,VolunGeneralNotes,VolunUpdateHours,DateCreated,Password,IsApproved")] tbl_Volunteer tbl_Volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Volunteer);
        }

        // GET: Common/Volunteer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Volunteer tbl_Volunteer = db.tbl_Volunteer.Include(o => o.OrderLines).Where(o => o.Volun_Id == id).SingleOrDefault();
            
            if (tbl_Volunteer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Volunteer);
        }

        // POST: Common/Volunteer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Volunteer tbl_Volunteer = db.tbl_Volunteer.Find(id);
            db.tbl_Volunteer.Remove(tbl_Volunteer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
