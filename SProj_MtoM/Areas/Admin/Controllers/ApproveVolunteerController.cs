using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Areas.Admin.Controllers
{
    public class ApproveVolunteerController : BaseAdminController
    {
            // GET: /Admin/ApproveURLs/
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

        [HttpPost]
        public void ApproveOrRejectALL(List<int> Ids, String Status, string CurrentStatus)
        {
            //try
            //{
            //    objBs.ApproveOrReject(Ids, Status);
            //    TempData["Msg"] = "Operation Successfully";
            //    var volunteers = objBs.volunteer_Bs.GetALL().Where(x => x.IsApproved == CurrentStatus).ToList();
            //    return PartialView("pv_ApproveURLs", volunteers);
            //}
            //catch (Exception e1)
            //{
            //    TempData["Msg"] = "Operation Failed" + e1.Message;
            //    var volunteers = objBs.volunteer_Bs.GetALL().Where(x => x.IsApproved == CurrentStatus).ToList();
            //    return PartialView("pv_ApproveURLs", volunteers);
            //}

        }

    }
}