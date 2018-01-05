using Proj_BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SProj_DAL
{
    public class Volunteer_Db
    {
        private DB_Models db;

        public Volunteer_Db()
        {
            db = new DB_Models();
        }
        public IEnumerable<tbl_Volunteer> GetALL()
        {
            return db.tbl_Volunteer.ToList();
        }
        public tbl_Volunteer GetByID(int Id)
        {
            return db.tbl_Volunteer.Find(Id);
        }
        public void Insert(tbl_Volunteer user)
        {
            db.tbl_Volunteer.Add(user);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_Volunteer user = db.tbl_Volunteer.Find(Id);
            db.tbl_Volunteer.Remove(user);
            Save();
        }
        public void Update(tbl_Volunteer user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
