using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SProj_BLL
{
    public class SecurityBs
    {
        public CategoryBs categoryBs { get; set; }

        public Volunteer_Bs volunteer_Bs { get; set; }

        public UserBs userBs { get; set; }
        public Opportunity_Bs opportunity_Bs { get; set; }



        public SecurityBs()
        {
            categoryBs = new CategoryBs();
            volunteer_Bs = new Volunteer_Bs();
            userBs = new UserBs();
            opportunity_Bs = new Opportunity_Bs();
        }
    }
}
