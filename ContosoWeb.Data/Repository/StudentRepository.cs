using ContosoWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoWeb.Data
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ContosoDbContext context) : base(context)
        {
        }

        public IEnumerable<Student> EagerGetAll()
        {
            var includeEnroll = dbSet.AsNoTracking().Include("Enrollments");
            var includeCourse = dbSet.AsNoTracking().Include(s=>s.Enrollments.Select(e=>e.Course));
            return includeCourse.ToList();
        }

        public People GetByLastName(string lastName)
        {
            var student = _context.People.Where(p => p.LastName == lastName).FirstOrDefault();
            return student;
        }
    }

    public interface IStudentRepository : IRepository<Student>
    {
        People GetByLastName(string lastName);
        IEnumerable<Student> EagerGetAll();
    }
}
