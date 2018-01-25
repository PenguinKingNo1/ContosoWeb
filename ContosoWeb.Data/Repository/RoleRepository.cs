using ContosoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoWeb.Data
{
    public class RoleRepository: Repository<Roles>, IRoleRepository
    {
        public RoleRepository(ContosoDbContext context) : base(context)
        {

        }
    }
    public interface IRoleRepository: IRepository<Roles>
    {
    }
}
