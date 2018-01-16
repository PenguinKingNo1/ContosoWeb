using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoWeb.Models
{
    [Table("Students")]
    public class Student:People
    {
        public DateTime? EnrollmentDate { get; set; }
    }
}
