using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proj_BOL;

namespace SProj_MtoM.Areas.Admin.Controllers
{
    public class tbl_OpportunityController : Controller
    {
        private DB_Models db = new DB_Models();

       


        // GET: Admin/tbl_Opportunity
        public ActionResult Index()
        {
            return View(db.tbl_Opportunity.ToList());
        }

        // GET: Admin/tbl_Opportunity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Opportunity tbl_Opportunity = db.tbl_Opportunity.Find(id);
            if (tbl_Opportunity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Opportunity);
        }

        private void PopulateAssignedCatData(tbl_Opportunity opportunity)
        {
            var allCategories = db.tbl_Category;
            var opporCat = new HashSet<int>(opportunity.OPPOR_HAS_CATEGORY.Select(b => b.Category_Id));
            var viewModelAvailable = new List<tbl_Category>();
            var viewModelSelected = new List<tbl_Category>();
            foreach (var cat in allCategories)
            {
                if (opporCat.Contains(cat.Category_Id))
                {
                    viewModelSelected.Add(new tbl_Category
                    {
                        Category_Id = cat.Category_Id,
                        CategoryName = cat.CategoryName,
                        //Assigned = true
                    });
                }
                else
                {
                    viewModelAvailable.Add(new tbl_Category
                    {
                        Category_Id = cat.Category_Id,
                        CategoryName = cat.CategoryName,
                        //Assigned = false
                    });
                }
            }

            ViewBag.selOpts = new MultiSelectList(viewModelSelected, "Category_Id", "CategoryName");
            ViewBag.availOpts = new MultiSelectList(viewModelAvailable, "Category_Id", "CategoryName");
        }





        // GET: Admin/tbl_Opportunity/Create
        public ActionResult Create()
        {
            var Tbl_Opportunity = new tbl_Opportunity();
            Tbl_Opportunity.OPPOR_HAS_CATEGORY = new List<OPPOR_HAS_CATEGORY>();
            PopulateAssignedCatData(Tbl_Opportunity);

            return View();
        }


        // POST: Admin/tbl_Opportunity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Oppor_Id,Oppor_Name,Oppor_Description,Oppor_Dateofevent,Oppor_ImageThumbnailUrl,Oppor_ImageUrl,Oppor_Streetaddress,Oppor_Streetaddress2,Oppor_City,Oppor_State,Oppor_Zip,Oppor_County,Oppor_Eldersource,Oppor_Eldersourceinstitute,Oppor_RequiresBackgroundCheck,Oppor_IsFeatured,Oppor_CreatedOn,UserId,Role")] tbl_Opportunity tbl_Opportunity, string[] selectedOptions)
        {
            if (selectedOptions != null)
            {
                tbl_Opportunity.OPPOR_HAS_CATEGORY = new List<OPPOR_HAS_CATEGORY>();
                foreach (var cat in selectedOptions)
                {
                    var catToAdd = db.OPPOR_HAS_CATEGORY.Find(int.Parse(cat));

                   // var oPPOR_HAS_CATEGORY = db.OPPOR_HAS_CATEGORY.Include(o => o.tbl_Category).Include(o => o.tbl_Opportunity);

                    tbl_Opportunity.OPPOR_HAS_CATEGORY.Add(catToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                db.tbl_Opportunity.Add(tbl_Opportunity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.TeamID = new SelectList(db.Teams, "ID", "TeamName", player.TeamID);
            PopulateAssignedCatData(tbl_Opportunity);
            return View(tbl_Opportunity);
        }

      


        // GET: Admin/tbl_Opportunity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Opportunity tbl_Opportunity = db.tbl_Opportunity.Find(id);
            if (tbl_Opportunity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Opportunity);
        }

        // POST: Admin/tbl_Opportunity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Oppor_Id,Oppor_Name,Oppor_Description,Oppor_Dateofevent,Oppor_ImageThumbnailUrl,Oppor_ImageUrl,Oppor_Streetaddress,Oppor_Streetaddress2,Oppor_City,Oppor_State,Oppor_Zip,Oppor_County,Oppor_Eldersource,Oppor_Eldersourceinstitute,Oppor_RequiresBackgroundCheck,Oppor_IsFeatured,Oppor_CreatedOn,UserId,Role")] tbl_Opportunity tbl_Opportunity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Opportunity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Opportunity);
        }

        // GET: Admin/tbl_Opportunity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Opportunity tbl_Opportunity = db.tbl_Opportunity.Find(id);
            if (tbl_Opportunity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Opportunity);
        }

        // POST: Admin/tbl_Opportunity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Opportunity tbl_Opportunity = db.tbl_Opportunity.Find(id);
            db.tbl_Opportunity.Remove(tbl_Opportunity);
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
