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
    public class OPPOR_HAS_CATEGORYController : Controller
    {
        private DB_Models db = new DB_Models();

        // GET: Admin/OPPOR_HAS_CATEGORY
        public ActionResult Index()
        {
            var oPPOR_HAS_CATEGORY = db.OPPOR_HAS_CATEGORY.Include(o => o.tbl_Category).Include(o => o.tbl_Opportunity);
            return View(oPPOR_HAS_CATEGORY.ToList());
        }

        // GET: Admin/OPPOR_HAS_CATEGORY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPOR_HAS_CATEGORY oPPOR_HAS_CATEGORY = db.OPPOR_HAS_CATEGORY.Find(id);
            if (oPPOR_HAS_CATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(oPPOR_HAS_CATEGORY);
        }

        // GET: Admin/OPPOR_HAS_CATEGORY/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(db.tbl_Category, "Category_Id", "CategoryName");
            ViewBag.Oppor_Id = new SelectList(db.tbl_Opportunity, "Oppor_Id", "Oppor_Name");
            return View();
        }

        // POST: Admin/OPPOR_HAS_CATEGORY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Oppor_Id,Category_Id,Assigned")] OPPOR_HAS_CATEGORY oPPOR_HAS_CATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.OPPOR_HAS_CATEGORY.Add(oPPOR_HAS_CATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Id = new SelectList(db.tbl_Category, "Category_Id", "CategoryName", oPPOR_HAS_CATEGORY.Category_Id);
            ViewBag.Oppor_Id = new SelectList(db.tbl_Opportunity, "Oppor_Id", "Oppor_Name", oPPOR_HAS_CATEGORY.Oppor_Id);
            return View(oPPOR_HAS_CATEGORY);
        }

        // GET: Admin/OPPOR_HAS_CATEGORY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPOR_HAS_CATEGORY oPPOR_HAS_CATEGORY = db.OPPOR_HAS_CATEGORY.Find(id);
            if (oPPOR_HAS_CATEGORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.tbl_Category, "Category_Id", "CategoryName", oPPOR_HAS_CATEGORY.Category_Id);
            ViewBag.Oppor_Id = new SelectList(db.tbl_Opportunity, "Oppor_Id", "Oppor_Name", oPPOR_HAS_CATEGORY.Oppor_Id);
            return View(oPPOR_HAS_CATEGORY);
        }

        // POST: Admin/OPPOR_HAS_CATEGORY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Oppor_Id,Category_Id,Assigned")] OPPOR_HAS_CATEGORY oPPOR_HAS_CATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oPPOR_HAS_CATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.tbl_Category, "Category_Id", "CategoryName", oPPOR_HAS_CATEGORY.Category_Id);
            ViewBag.Oppor_Id = new SelectList(db.tbl_Opportunity, "Oppor_Id", "Oppor_Name", oPPOR_HAS_CATEGORY.Oppor_Id);
            return View(oPPOR_HAS_CATEGORY);
        }

        // GET: Admin/OPPOR_HAS_CATEGORY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPOR_HAS_CATEGORY oPPOR_HAS_CATEGORY = db.OPPOR_HAS_CATEGORY.Find(id);
            if (oPPOR_HAS_CATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(oPPOR_HAS_CATEGORY);
        }

        // POST: Admin/OPPOR_HAS_CATEGORY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OPPOR_HAS_CATEGORY oPPOR_HAS_CATEGORY = db.OPPOR_HAS_CATEGORY.Find(id);
            db.OPPOR_HAS_CATEGORY.Remove(oPPOR_HAS_CATEGORY);
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
