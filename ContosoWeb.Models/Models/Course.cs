using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace ContosoWeb.Models
{
    public class Course: AuditableEntity
    {
        [StringLength(50,MinimumLength = 3)]
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Instructor> Instructor { get; set; }
    }
}
