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
        public virtual Department Department { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
