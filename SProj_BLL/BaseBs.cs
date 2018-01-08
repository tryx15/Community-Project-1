using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SProj_BLL
{

    /**
     * This class is used as a parent class to all the area Bs classes 
     * to eliminate repeating the same code. This will be used as an implemetation
     * to the classes like this (Class name) :BaseBs
     * */
    public class BaseBs
    {
        public CategoryBs categoryBs { get; set; }

        public Volunteer_Bs volunteer_Bs { get; set; }

        public UserBs userBs { get; set; }
        public Opportunity_Bs opportunity_Bs { get; set; }



        public BaseBs()
        {
            categoryBs = new CategoryBs();
            volunteer_Bs = new Volunteer_Bs();
            userBs = new UserBs();
            opportunity_Bs = new Opportunity_Bs();
        }
    }
}
