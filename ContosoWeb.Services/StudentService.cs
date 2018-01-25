using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Models;
using ContosoWeb.Data;

namespace ContosoWeb.Services
{
    public class StudentService : IStudentService
    {
        IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public void AddStudent(Student student)
        {
            _repository.Add(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _repository.GetAll();
        }

        public Student GetStudentById(int id)
        {
            return _repository.GetById(id);
        }

        public void DeleteStudent(Student student)
        {
            _repository.Delete(student);
            _repository.SaveChanges();
        }
    }

    public interface IStudentService
    {
        Student GetStudentById(int id);
        IEnumerable<Student> GetAllStudents();
        void AddStudent(Student student);
        void DeleteStudent(Student student);
    }
}
