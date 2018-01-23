using ContosoWeb.Infrastructure;
using ContosoWeb.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace ContosoWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            /// get the request's cookie name
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)// have cookie
            {
                /// get plain text cookie
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket != null)
                {
                    /// Convert Json Data to ContosoPrincipleModel
                    var serializeModel = JsonConvert.DeserializeObject<ContosoPrincipleModel>(authTicket.UserData);

                    var newUser = new ContosoWebPrincipal(authTicket.Name)
                    {
                        PersonId = serializeModel.PersonId,
                        FirstName = serializeModel.FirstName,
                        LastName = serializeModel.LastName,
                        Roles = serializeModel.Roles
                    };

                    HttpContext.Current.User = newUser;
                }
            }
        }
    }
}
