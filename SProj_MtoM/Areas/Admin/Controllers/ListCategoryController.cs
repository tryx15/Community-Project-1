using Proj_BOL;
using SProj_BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListCategoryController : BaseAdminController
    {
        //private AdminBs objBs;

        //public ListCategoryController()
        //{
        //    objBs = new AdminBs();
        //}
       
        // GET: Admin/ListCategory
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var categories = objBs.categoryBs.GetALL().ToList();

            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {

                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "CategoryDesc":
                    switch (SortOrder)
                    {

                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    categories = categories.OrderBy(x => x.CategoryName).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.categoryBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            categories = categories.Skip((page - 1) * 10).Take(10).ToList();

            return View(categories);
        }

        public ActionResult Delete(int id)
        {

            try
            {
                objBs.categoryBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Delete Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
/// <summary>
/// //////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// 

        private DB_Models db = new DB_Models();

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Category tbl_Category = db.tbl_Category.Find(id);
            if (tbl_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Category);
        }


        // GET: Common/tbl_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Category tbl_Category = db.tbl_Category.Find(id);
            if (tbl_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Category);
        }

        // POST: Common/tbl_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_Id,CategoryName,CategoryDesc")] tbl_Category tbl_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Category);
        }

    }
}