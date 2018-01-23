using ContosoWeb.Data;
using ContosoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoWeb.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository roleRepository)
        {
            _repository = roleRepository;
        }
        public void AddRole(Roles role)
        {
            _repository.Add(role);
        }

        public void DeleteRole(Roles role)
        {
            _repository.Delete(role);
        }

        public void EditRole(Roles role)
        {
            _repository.Update(role);
        }

        public IEnumerable<Roles> GetAllRoles()
        {
            return _repository.GetAll();
        }
    }

    public interface IRoleService
    {
        void AddRole(Roles role);
        void EditRole(Roles role);
        void DeleteRole(Roles role);
        IEnumerable<Roles> GetAllRoles();

    }
}
