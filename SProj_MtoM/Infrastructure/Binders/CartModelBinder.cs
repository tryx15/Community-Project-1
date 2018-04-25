using SProj_MtoM.Areas.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SProj_MtoM.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Basket";
    
    public object BindModel(ControllerContext controllerContext,
ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            Basket basket2 = null;
            if (controllerContext.HttpContext.Session != null)
            {
                basket2 = (Basket)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the Cart if there wasn't one in the session data
            if (basket2 == null)
            {
                basket2 = new Basket();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = basket2;
                }
            }
            // return the basket
            return basket2;
        }
    }
}