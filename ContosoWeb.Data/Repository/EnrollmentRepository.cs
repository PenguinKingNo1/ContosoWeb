using ContosoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoWeb.Data
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ContosoDbContext context) : base(context)
        {
        }
    }

    public interface IEnrollmentRepository : IRepository<Enrollment>
    {

    }
}
