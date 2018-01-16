using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Data;
using ContosoWeb.Models;

namespace ContosoWeb.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public void AddDepartment(Department dep)
        {
            _repository.Add(dep);
            _repository.SaveChanges();
        }

        public void DeleteDepartment(Department dep)
        {
            _repository.Delete(dep);
            _repository.SaveChanges();
        }

        public void EditDepartment(Department dep)
        {
            _repository.Update(dep);
            _repository.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return _repository.GetAll();
        }

        public Department GetDepartmentById(int id)
        {
            return _repository.GetById(id);
        }
    }

    public interface IDepartmentService
    {
        void AddDepartment(Department dep);
        void DeleteDepartment(Department dep);
        void EditDepartment(Department dep);
        Department GetDepartmentById(int id);
        IEnumerable<Department> GetAllDepartment();
    }
}
