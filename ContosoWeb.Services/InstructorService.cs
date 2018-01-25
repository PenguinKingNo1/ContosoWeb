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
            _repository.SaveChanges();
        }

        public void EditInstructor(Instructor instructor)
        {
            _repository.Update(instructor);
            _repository.SaveChanges();
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
        public void AddMoreCourses(int instId, int courseId)
        {
            _repository.AddMoreCourse(instId, courseId);
            _repository.SaveChanges();
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
        void AddMoreCourses(int instId, int courseId);
    }
}
