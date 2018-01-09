using Proj_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        //
        // GET: /Security/Register/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Role = "A"; //Changed U to A so only admin can add user.
                    objBs.userBs.Insert(user);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}