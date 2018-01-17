using ContosoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoWeb.Data
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ContosoDbContext context) : base(context)
        {
        }

        public IEnumerable<Instructor> EagerGetAll()
        {
            return _context.Instructors.Include("Departments").ToList();  // eager loading
        }

    }

    public interface IInstructorRepository : IRepository<Instructor>
    {
        IEnumerable<Instructor> EagerGetAll();
    }
}
