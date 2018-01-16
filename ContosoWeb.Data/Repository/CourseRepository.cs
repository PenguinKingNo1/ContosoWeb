using ContosoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoWeb.Data
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ContosoDbContext context) : base(context)
        {
        }
    }

    public interface ICourseRepository : IRepository<Course>
    {

    }
}
