using Proj_BOL;
using SProj_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SProj_BLL
{
    public class Opportunity_Bs
    {
        private Opportunity_Db objDb;

        public Opportunity_Bs()
        {
            objDb = new Opportunity_Db();
        }

        public IEnumerable<tbl_Opportunity> GetALL()
        {
            return objDb.GetALL();
        }

        public tbl_Opportunity GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(tbl_Opportunity url)
        {
            objDb.Insert(url);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(tbl_Opportunity url)
        {
            objDb.Update(url);
        }
    }
}
