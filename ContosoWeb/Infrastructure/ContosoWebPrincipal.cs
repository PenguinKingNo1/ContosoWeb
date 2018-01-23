using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ContosoWeb.Infrastructure
{
    public class ContosoWebPrincipal : IPrincipal
    {
        
        public ContosoWebPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username); //what is this?
        }

        public bool IsInRole(string role)
        {
            return Roles.Any(r => r.Contains(role));
        }
        public IIdentity Identity { get; private set; } //???
        public string UserName { get; private set; }
        public int PersonId { get; set; }
        public string[] Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}