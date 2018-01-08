using SProj_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Areas.Admin.Controllers
{

    /**
     * Similar to BaseBs this class minimize the need for repeating the same code
     * in all the classes. It will therefore be an inheritance. I deleted the code from 
     * one of the Admin class and paste it here, if i wanted to go back just paste this code back in
     * to whichever controller and change the constructor name.
     * */
    public class BaseAdminController : Controller
    {
        protected AdminBs objBs; //protected because it will be used for inheritance

        public BaseAdminController()
        {
            objBs = new AdminBs();
        }
    }
}