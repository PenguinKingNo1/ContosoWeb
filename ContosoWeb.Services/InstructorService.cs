using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Data;
using ContosoWeb.Models;

namespace ContosoWeb.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _repository;
        public InstructorService(IInstructorRepository repository)
        {
            _repository = repository;
        }
        public void AddInstructor(Instructor instructor)
        {
            _repository.Add(instructor);
        }

        public void DeleteInstructor(Instructor instructor)
        {
            _repository.Delete(instructor);
        }

        public void EditInstructor(Instructor instructor)
        {
            _repository.Update(instructor);
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _repository.GetAll();
        }

        public Instructor GetInstructorById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Instructor> EagerGetAll()
        {
            return _repository.EagerGetAll();
        }
    }

    public interface IInstructorService
    {
        void AddInstructor(Instructor instructor);
        void DeleteInstructor(Instructor instructor);
        void EditInstructor(Instructor instructor);
        Instructor GetInstructorById(int id);
        IEnumerable<Instructor> GetAllInstructors();
        IEnumerable<Instructor> EagerGetAll();
    }
}
