using Proj_BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SProj_DAL
{
    class Opportunity_Db
    {
        private DB_Models db;

        public Opportunity_Db()
        {
            db = new DB_Models();
        }
        public IEnumerable<tbl_Opportunity> GetALL()
        {
            return db.tbl_Opportunity.ToList();
        }
        public tbl_Opportunity GetByID(int Id)
        {
            return db.tbl_Opportunity.Find(Id);
        }
        public void Insert(tbl_Opportunity opportunity)
        {
            db.tbl_Opportunity.Add(opportunity);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_Opportunity opportunity = db.tbl_Opportunity.Find(Id);
            db.tbl_Opportunity.Remove(opportunity);
            Save();
        }
        public void Update(tbl_Opportunity opportunity)
        {
            db.Entry(opportunity).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
