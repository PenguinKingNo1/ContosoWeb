using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Models.Common;

namespace ContosoWeb.Models
{
    public class Roles : AuditableEntity
    {
        public string RoleName { get; set; }
        public string Desciprtion { get; set; }
        public virtual ICollection<People> People { get; set; }
    }
}
