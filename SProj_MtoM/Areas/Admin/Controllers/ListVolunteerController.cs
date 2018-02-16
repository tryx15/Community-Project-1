﻿using Microsoft.Reporting.WebForms;
using SProj_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Areas.Admin.Controllers
{
    public class ListVolunteerController : BaseAdminController
    {
        //private AdminBs objBs; //Volunteer_Bs changed to AdminBs since it handles the Admin functions (See AdminBs for reference)

        //public ListVolunteerController()
        //{
        //    objBs = new AdminBs();
        //}

        // GET: Admin/ListVolunteer
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var volunteers = objBs.volunteer_Bs.GetALL().Where(x => x.IsApproved == "A").ToList();


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

                case "IsApproved":
                    switch (SortOrder)
                    {

                        case "Asc":
                            volunteers = volunteers.OrderBy(x => x.IsApproved).ToList();
                            break;
                        case "Desc":
                            volunteers = volunteers.OrderByDescending(x => x.IsApproved).ToList();
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

            ViewBag.TotalPages = Math.Ceiling(objBs.volunteer_Bs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            volunteers = volunteers.Skip((page - 1) * 10).Take(10).ToList();

            return View(volunteers);
        }

       
        public FileResult ExportTo(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/VoluntteerReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "Volunteer_rdlc_DataSet";
            reportDataSource.Value = objBs.volunteer_Bs.GetALL().Where(x => x.IsApproved == "A").ToList();

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
    }
}