using ContosoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoWeb.Data
{
    public class PersonRepository : Repository<People>, IPersonRepository
    {
        public PersonRepository(ContosoDbContext context) : base(context)
        {
        }

        public void AddRole(int personId, int roleId)
        {
            var role = _context.Roles.Find(roleId);
            dbSet.Find(personId).Roles.Add(role);
        }

        public People GetByLastName(string lastName)
        {
            var person = _context.People.Where(p => p.LastName == lastName).FirstOrDefault();
            var test = _context.People.OfType<Student>().FirstOrDefault();
            return person;
        }
    }

    public interface IPersonRepository : IRepository<People>
    {
        People GetByLastName(string lastName);
        void AddRole(int personId, int roleId);
    }
}
