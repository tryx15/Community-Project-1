using Proj_BOL;
using SProj_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SProj_BLL
{
    public class Volunteer_Bs
    {
        private Volunteer_Db objDb;

        public Volunteer_Bs()
        {
            objDb = new Volunteer_Db();
        }

        public IEnumerable<tbl_Volunteer> GetALL()
        {
            return objDb.GetALL();
        }

        public tbl_Volunteer GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(tbl_Volunteer user)
        {
            objDb.Insert(user);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(tbl_Volunteer user)
        {
            objDb.Update(user);
        }
    }
}
