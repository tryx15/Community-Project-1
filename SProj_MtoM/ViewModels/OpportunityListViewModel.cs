using Proj_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SProj_MtoM.ViewModels
{
    public class OpportunityListViewModel
    {
        public IEnumerable<tbl_Opportunity> Opportunities { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
        public string Category { get; set; }
        public string CurrentCategory { get; set; }
    }
}