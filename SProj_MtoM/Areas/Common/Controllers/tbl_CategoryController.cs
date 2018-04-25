using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proj_BOL;

namespace SProj_MtoM.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class tbl_CategoryController : Controller
    {
        private DB_Models db = new DB_Models();

        // GET: Common/tbl_Category
        public ActionResult Index()
        {
            return View(db.tbl_Category.ToList());
        }

        
    }
}
