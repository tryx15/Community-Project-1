using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SProj_BLL
{

    /**
     * Whenever the Admin area wants to interact with the BLL this class
     * will be used to handle the request.
     * */
   public class AdminBs : BaseBs
    {
        public void ApproveOrReject(List<int> Ids, string Status)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in Ids)
                    {
                        var myVolunteer = volunteer_Bs.GetByID(item);
                        myVolunteer.IsApproved = Status;
                        volunteer_Bs.Update(myVolunteer);
                    }

                    Trans.Complete();
                }
                catch (Exception E1)
                {
                    throw new Exception(E1.Message);
                }


            }
        }
    }
}
