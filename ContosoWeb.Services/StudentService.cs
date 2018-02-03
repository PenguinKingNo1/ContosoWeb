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
        protected IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public void AddStudent(Student student)
        {
            _repository.Add(student);
        }

        public virtual IEnumerable<Student> GetAllStudents()
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

        public IEnumerable<Course> GetEnrolledCourses(int studentId)
        {
            try
            {
                Student person = _repository.GetById(studentId);
                var enrollmentList = person.Enrollments;
                var courseList = new List<Course>();
                foreach (var enroll in enrollmentList)
                {
                    courseList.Add(enroll.Course);
                }
                return courseList;
            }
            catch (Exception)
            {

                throw;
            }          
        }
    }

    public class StudentServiceEager : StudentService
    {
        public StudentServiceEager(IStudentRepository repository) : base(repository)
        {
        }
        public override IEnumerable<Student> GetAllStudents()
        {            
            return _repository.EagerGetAll();
        }
    }

    public interface IStudentService
    {
        Student GetStudentById(int id);
        IEnumerable<Student> GetAllStudents();
        void AddStudent(Student student);
        void DeleteStudent(Student student);
        IEnumerable<Course> GetEnrolledCourses(int id);
    }
}
