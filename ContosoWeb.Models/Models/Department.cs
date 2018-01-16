using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Models.Common;

namespace ContosoWeb.Models
{
    public class Department: AuditableEntity
    {
        public string Name { get; set; }
        public Decimal Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public ICollection<Course> Courses { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
