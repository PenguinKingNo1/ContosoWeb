using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoWeb.Data;
using ContosoWeb.Models;

namespace ContosoWeb.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            _enrollmentRepository.Add(enrollment);
            _enrollmentRepository.SaveChanges();
        }

        public void DeleteEnrollment(Enrollment enrollment)
        {
            _enrollmentRepository.Delete(enrollment);
        }

        public Enrollment GetEnrollmentById(int id)
        {
            return _enrollmentRepository.GetById(id);
        }

        public Course GetEnrolledCourse(int enrollId)
        {
            return _enrollmentRepository.GetById(enrollId).Course;
        }

        public Student GetEnrolledStudent(int enrollId)
        {
            return _enrollmentRepository.GetById(enrollId).Student;
        }
    }

    public interface IEnrollmentService
    {
        void AddEnrollment(Enrollment enrollment);
        void DeleteEnrollment(Enrollment enrollment);
        Enrollment GetEnrollmentById(int id);
        Course GetEnrolledCourse(int enrollId);
        Student GetEnrolledStudent(int enrollId);
    }
}
