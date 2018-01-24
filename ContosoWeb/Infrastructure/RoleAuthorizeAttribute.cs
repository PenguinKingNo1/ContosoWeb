using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContosoWeb.Infrastructure
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public RoleAuthorizeAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
        protected virtual ContosoWebPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as ContosoWebPrincipal; }
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentUser!=null && CurrentUser.IsInRole(Roles))
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