using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proj_BOL;
using SProj_MtoM.ViewModels;

namespace SProj_MtoM.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class tbl_OpportunityController : Controller
    {
        private DB_Models db = new DB_Models();




        // GET: Admin/tbl_Opportunity
        public ActionResult Index()
        {
            return View(db.tbl_Opportunity.ToList());
        }


        public ActionResult Details(int? id)
        {
            tbl_Opportunity opportunity = db.tbl_Opportunity.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }

            var Results = from b in db.tbl_Category
                          select new
                          {
                              b.Category_Id,
                              b.CategoryName,
                              Checked = ((from ab in db.OPPOR_HAS_CATEGORY
                                          where (ab.Oppor_Id == id) & (ab.Category_Id == b.Category_Id)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new OpportunityViewModel();

            MyViewModel.Oppor_Id = id.Value;
            MyViewModel.Oppor_Name = opportunity.Oppor_Name;
            MyViewModel.Oppor_Description = opportunity.Oppor_Description;
            MyViewModel.Oppor_Dateofevent = opportunity.Oppor_Dateofevent;
            MyViewModel.ImageData = opportunity.ImageData;
            MyViewModel.ImageMimeType = opportunity.ImageMimeType;
            MyViewModel.Oppor_Streetaddress = opportunity.Oppor_Streetaddress;
            MyViewModel.Oppor_Streetaddress2 = opportunity.Oppor_Streetaddress2;
            MyViewModel.Oppor_City = opportunity.Oppor_City;
            MyViewModel.Oppor_State = opportunity.Oppor_State;
            MyViewModel.Oppor_Zip = opportunity.Oppor_Zip;
            MyViewModel.Oppor_County = opportunity.Oppor_County;
            MyViewModel.Oppor_Eldersource = opportunity.Oppor_Eldersource;
            MyViewModel.Oppor_Eldersourceinstitute = opportunity.Oppor_Eldersourceinstitute;
            MyViewModel.Oppor_RequiresBackgroundCheck = opportunity.Oppor_RequiresBackgroundCheck;
            MyViewModel.Oppor_IsFeatured = opportunity.Oppor_IsFeatured;
            MyViewModel.Oppor_CreatedOn = opportunity.Oppor_CreatedOn;
            MyViewModel.UserId = opportunity.UserId;
            MyViewModel.Role = opportunity.Role;

        var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.Category_Id, Name = item.CategoryName, Checked = item.Checked });
            }

            MyViewModel.Categories = MyCheckBoxList;

            return View(MyViewModel);
        }




        // GET: Admin/tbl_Opportunity/Create
        public ActionResult Create()
        {

            //tbl_Opportunity opportunity = db.tbl_Opportunity.Find(id);
            tbl_Opportunity opportunity = new tbl_Opportunity();
            var Results = from b in db.tbl_Category
                          select new
                          {
                              b.Category_Id,
                              b.CategoryName,

                          };

            var MyViewModel = new OpportunityViewModel();

            MyViewModel.Oppor_Id = opportunity.Oppor_Id;
            MyViewModel.Oppor_Name = opportunity.Oppor_Name;
            MyViewModel.Oppor_Description = opportunity.Oppor_Description;
            MyViewModel.Oppor_Dateofevent = opportunity.Oppor_Dateofevent;
            MyViewModel.ImageData = opportunity.ImageData;
            MyViewModel.ImageMimeType = opportunity.ImageMimeType;
            MyViewModel.Oppor_Streetaddress = opportunity.Oppor_Streetaddress;
            MyViewModel.Oppor_Streetaddress2 = opportunity.Oppor_Streetaddress2;
            MyViewModel.Oppor_City = opportunity.Oppor_City;
            MyViewModel.Oppor_State = opportunity.Oppor_State;
            MyViewModel.Oppor_Zip = opportunity.Oppor_Zip;
            MyViewModel.Oppor_County = opportunity.Oppor_County;
            MyViewModel.Oppor_Eldersource = opportunity.Oppor_Eldersource;
            MyViewModel.Oppor_Eldersourceinstitute = opportunity.Oppor_Eldersourceinstitute;
            MyViewModel.Oppor_RequiresBackgroundCheck = opportunity.Oppor_RequiresBackgroundCheck;
            MyViewModel.Oppor_IsFeatured = opportunity.Oppor_IsFeatured;
            MyViewModel.Oppor_CreatedOn = opportunity.Oppor_CreatedOn;
            MyViewModel.UserId = opportunity.UserId;
            MyViewModel.Role = opportunity.Role;


            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.Category_Id, Name = item.CategoryName, Checked = false });
            }

            MyViewModel.Categories = MyCheckBoxList;

            return View(MyViewModel);
        }
        
        // POST: Admin/tbl_Opportunity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Oppor_Id,Oppor_Name,Oppor_Description,Oppor_Dateofevent,Oppor_ImageThumbnailUrl," +
            "Oppor_ImageUrl,Oppor_Streetaddress,Oppor_Streetaddress2,Oppor_City,Oppor_State,Oppor_Zip,Oppor_County,Oppor_Eldersource," +
            "Oppor_Eldersourceinstitute,Oppor_RequiresBackgroundCheck,Oppor_IsFeatured,Oppor_CreatedOn," +
            "UserId,Role")] tbl_Opportunity opportunity, OpportunityViewModel opportunityVM)

        {
            if (ModelState.IsValid)
            {
               
                foreach (var item in db.OPPOR_HAS_CATEGORY)
                {
                    if (item.Oppor_Id == opportunity.Oppor_Id)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in opportunityVM.Categories)
                {
                    if (item.Checked)
                    {
                        db.OPPOR_HAS_CATEGORY.Add(new OPPOR_HAS_CATEGORY() { Oppor_Id = opportunity.Oppor_Id, Category_Id = item.Id });
                    }
                }

                db.tbl_Opportunity.Add(opportunity);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opportunity);
        }


        // GET: /Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Opportunity opportunity = db.tbl_Opportunity.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }

            var Results = from b in db.tbl_Category
                          select new
                          {
                              b.Category_Id,
                              b.CategoryName,
                              Checked = ((from ab in db.OPPOR_HAS_CATEGORY
                                          where (ab.Oppor_Id == id) & (ab.Category_Id == b.Category_Id)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new OpportunityViewModel();

            MyViewModel.Oppor_Id = id.Value;
            MyViewModel.Oppor_Name = opportunity.Oppor_Name;
            MyViewModel.Oppor_Description = opportunity.Oppor_Description;
            MyViewModel.Oppor_Dateofevent = opportunity.Oppor_Dateofevent;
            MyViewModel.ImageData = opportunity.ImageData;
            MyViewModel.ImageMimeType = opportunity.ImageMimeType;
            MyViewModel.Oppor_Streetaddress = opportunity.Oppor_Streetaddress;
            MyViewModel.Oppor_Streetaddress2 = opportunity.Oppor_Streetaddress2;
            MyViewModel.Oppor_City = opportunity.Oppor_City;
            MyViewModel.Oppor_State = opportunity.Oppor_State;
            MyViewModel.Oppor_Zip = opportunity.Oppor_Zip;
            MyViewModel.Oppor_County = opportunity.Oppor_County;
            MyViewModel.Oppor_Eldersource = opportunity.Oppor_Eldersource;
            MyViewModel.Oppor_Eldersourceinstitute = opportunity.Oppor_Eldersourceinstitute;
            MyViewModel.Oppor_RequiresBackgroundCheck = opportunity.Oppor_RequiresBackgroundCheck;
            MyViewModel.Oppor_IsFeatured = opportunity.Oppor_IsFeatured;
            MyViewModel.Oppor_CreatedOn = opportunity.Oppor_CreatedOn;
            MyViewModel.UserId = opportunity.UserId;
            MyViewModel.Role = opportunity.Role;


            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.Category_Id, Name = item.CategoryName, Checked = item.Checked });
            }

            MyViewModel.Categories = MyCheckBoxList;

            return View(MyViewModel);
        }

        // POST:/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OpportunityViewModel opportunity, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    opportunity.ImageMimeType = image.ContentType;
                    opportunity.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(opportunity.ImageData, 0, image.ContentLength);
                }

                var MyOpportunity = db.tbl_Opportunity.Find(opportunity.Oppor_Id);

                MyOpportunity.Oppor_Name = opportunity.Oppor_Name;
                MyOpportunity.Oppor_Description = opportunity.Oppor_Description;
                MyOpportunity.Oppor_Dateofevent = opportunity.Oppor_Dateofevent;
                MyOpportunity.ImageData = opportunity.ImageData;
                MyOpportunity.ImageMimeType = opportunity.ImageMimeType;
                MyOpportunity.Oppor_Streetaddress = opportunity.Oppor_Streetaddress;
                MyOpportunity.Oppor_Streetaddress2 = opportunity.Oppor_Streetaddress2;
                MyOpportunity.Oppor_City = opportunity.Oppor_City;
                MyOpportunity.Oppor_State = opportunity.Oppor_State;
                MyOpportunity.Oppor_Zip = opportunity.Oppor_Zip;
                MyOpportunity.Oppor_County = opportunity.Oppor_County;
                MyOpportunity.Oppor_Eldersource = opportunity.Oppor_Eldersource;
                MyOpportunity.Oppor_Eldersourceinstitute = opportunity.Oppor_Eldersourceinstitute;
                MyOpportunity.Oppor_RequiresBackgroundCheck = opportunity.Oppor_RequiresBackgroundCheck;
                MyOpportunity.Oppor_IsFeatured = opportunity.Oppor_IsFeatured;
                MyOpportunity.Oppor_CreatedOn = opportunity.Oppor_CreatedOn;
                MyOpportunity.UserId = opportunity.UserId;
                MyOpportunity.Role = opportunity.Role;

                foreach (var item in db.OPPOR_HAS_CATEGORY)
                {
                    if (item.Oppor_Id == opportunity.Oppor_Id)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in opportunity.Categories)
                {
                    if (item.Checked)
                    {
                        db.OPPOR_HAS_CATEGORY.Add(new OPPOR_HAS_CATEGORY() { Oppor_Id = opportunity.Oppor_Id, Category_Id = item.Id });
                    }
                }

                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been saved", opportunity.Oppor_Name);
                return RedirectToAction("Index");
            }
            return View(opportunity);
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