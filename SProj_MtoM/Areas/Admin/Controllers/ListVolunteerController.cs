using SProj_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Areas.Admin.Controllers
{
    public class ListVolunteerController : Controller
    {
        private Volunteer_Bs objBs;


        // GET: Admin/ListVolunteer
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var volunteers = objBs.GetALL();

            #region SwitchCase
            switch (SortBy)
            {
                case "VolunEmail":
                    switch (SortOrder)
                    {

                        case "Asc":
                            volunteers = volunteers.OrderBy(x => x.VolunEmail).ToList();
                            break;
                        case "Desc":
                            volunteers = volunteers.OrderByDescending(x => x.VolunEmail).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Role":
                    switch (SortOrder)
                    {

                        case "Asc":
                            volunteers = volunteers.OrderBy(x => x.Role).ToList();
                            break;
                        case "Desc":
                            volunteers = volunteers.OrderByDescending(x => x.Role).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "VolunZip":
                    switch (SortOrder)
                    {

                        case "Asc":
                            volunteers = volunteers.OrderBy(x => x.VolunZip).ToList();
                            break;
                        case "Desc":
                            volunteers = volunteers.OrderByDescending(x => x.VolunZip).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    volunteers = volunteers.OrderBy(x => x.VolunEmail).ToList();
                    break;
            }
            #endregion

            ViewBag.TotalPages = Math.Ceiling(objBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            volunteers = volunteers.Skip((page - 1) * 10).Take(10).ToList();

            return View(volunteers);
        }
    }
}