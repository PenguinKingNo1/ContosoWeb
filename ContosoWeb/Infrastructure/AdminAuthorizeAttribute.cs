using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContosoWeb.Infrastructure
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual ContosoWebPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as ContosoWebPrincipal; }
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                Roles = "Admin";
            }
            if (!string.IsNullOrEmpty(Roles)&& CurrentUser.IsInRole(Roles))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                filterContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }                 
        }
    }
}