using Microsoft.Reporting.WebForms;
using Proj_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SProj_MtoM.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ApproveVolunteerController : BaseAdminController
    {
        private DB_Models db = new DB_Models();
        // GET: /Admin/Approve
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? "P" : Status);
            if (Status == null)
            {
                var volunteer = objBs.volunteer_Bs.GetALL().Where(x => x.IsApproved == "P").ToList();
                return View(volunteer);
            }
            else
            {
                var volunteer = objBs.volunteer_Bs.GetALL().Where(x => x.IsApproved == Status).ToList();
                return View(volunteer);
            }

        }

        public ActionResult Approve(int id)
        {
            try
            {
                var myVolunteer = objBs.volunteer_Bs.GetByID(id);
                myVolunteer.IsApproved = "A";
                objBs.volunteer_Bs.Update(myVolunteer);
                TempData["Msg"] = "Approved Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Approval Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Reject(int id)
        {
            try
            {
                var myVolunteer = objBs.volunteer_Bs.GetByID(id);
                myVolunteer.IsApproved = "R";
                objBs.volunteer_Bs.Update(myVolunteer);
                TempData["Msg"] = "Rejected Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Rejection Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
        public FileResult ExportTo(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/VoluntteerReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "Volunteer_rdlc_DataSet";
            //reportDataSource.Value = objBs.volunteer_Bs.GetALL().Where(x => x.IsApproved == "A").ToList();
            reportDataSource.Value = objBs.volunteer_Bs.GetALL().ToList();
            localReport.DataSources.Add(reportDataSource);

            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension = (ReportType == "Excel") ? "xlsx" : (ReportType == "Word" ? "doc" : "pdf");
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding,
                                                out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment; filename=Volunteers." + fileNameExtension);

            return File(renderedBytes, fileNameExtension);

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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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