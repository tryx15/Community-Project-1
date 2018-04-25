using Proj_BOL;
using SProj_MtoM.Areas.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SProj_MtoM.Areas.Common.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketLine> BasketLines { get; set; }
        public string ReturnUrl { get; set; }
        public Basket Basket2 { get; set; }
    }
}