using Proj_BOL;
using SProj_BLL;
using SProj_MtoM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace SProj_MtoM.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class OpportunityController : Controller
    {
       

        private DB_Models db = new DB_Models();
        public int PageSize = 6;

       

        public ViewResult Index(string category, string search, int page = 1)
        {
            var opportunity = db.tbl_Opportunity.Include(p => p.OPPOR_HAS_CATEGORY);
            if (!String.IsNullOrEmpty(category))
            {
                opportunity = opportunity.Where(p => p.OPPOR_HAS_CATEGORY.Any(c => c.tbl_Category.CategoryName == category));
            }

            //Implementing Search
            if (!String.IsNullOrEmpty(search))
            {
                opportunity = opportunity.Where(p => p.Oppor_Name.Contains(search) ||
                p.Oppor_Description.Contains(search) ||
                p.OPPOR_HAS_CATEGORY.Any(c => c.tbl_Category.CategoryName.Contains(search)));
            }

            OpportunityListViewModel viewModel = new OpportunityListViewModel
            {

                Opportunities = opportunity
                .Where(p => category == null || p.OPPOR_HAS_CATEGORY.Any(c => c.tbl_Category.CategoryName == category))
                .OrderBy(p => p.Oppor_Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    opportunity.Count() :
                    opportunity.Where(e => e.OPPOR_HAS_CATEGORY.Any(c => c.tbl_Category.CategoryName == category)).Count()
                },
                CurrentCategory = category

            };


            return View(viewModel);
            }


        public ViewResult Details(int? Oppor_Id)
        {
            tbl_Opportunity opportunity = db.tbl_Opportunity.FirstOrDefault(o => o.Oppor_Id == Oppor_Id);
            if (opportunity == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(opportunity);

        }

        public FileContentResult GetImage(int Oppor_Id)
        {
            tbl_Opportunity oppor = db.tbl_Opportunity
            .FirstOrDefault(o => o.Oppor_Id == Oppor_Id);
            if (oppor != null)
            {
                return File(oppor.ImageData, oppor.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


    }
    }

