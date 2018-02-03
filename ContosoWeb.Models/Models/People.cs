using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ContosoWeb.Models
{
    public class People : AuditableEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? Birthday { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string UnitNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Byte? IsLocked { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
    }
}
