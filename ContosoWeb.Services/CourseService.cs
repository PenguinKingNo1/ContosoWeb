using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Data;
using ContosoWeb.Models;

namespace ContosoWeb.Services
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _repository;
        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public void AddCourse(Course course)
        {
            _repository.Add(course);
            _repository.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            _repository.Delete(course);
            _repository.SaveChanges();
        }

        public void EditCourse(Course course)
        {
            _repository.Update(course);
            _repository.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _repository.GetAll();
        }

        public Course GetCourseById(int id)
        {
            return _repository.GetById(id);
        }
    }

    public interface ICourseService
    {
        void AddCourse(Course course);
        void DeleteCourse(Course course);
        void EditCourse(Course course);
        Course GetCourseById(int id);
        IEnumerable<Course> GetAllCourses();
    }
}
