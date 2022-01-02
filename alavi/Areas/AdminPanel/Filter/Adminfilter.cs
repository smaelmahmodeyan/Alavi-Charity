using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace alavi.Areas.AdminPanel.Filter
{
    public class Adminfilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (alavi.Helper.CookieUtility.GetUserName() == "")
            {
                filterContext.Result = new RedirectToRouteResult(
           new RouteValueDictionary {{ "Controller", "Login" },
                                      { "Action", "Index" } });

            }
            base.OnActionExecuting(filterContext);
        }

       
    }
}