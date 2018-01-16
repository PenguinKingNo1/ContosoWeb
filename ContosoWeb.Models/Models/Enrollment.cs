using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Models.Common;

namespace ContosoWeb.Models
{
    public class Enrollment: AuditableEntity
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
    public enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }
}
