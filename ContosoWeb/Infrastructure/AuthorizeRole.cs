using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoWeb.Infrastructure
{
    public static class AuthorizeRole
    {
        public const string Administrator = "Administrator";
        public const string Student= "Student";
        public const string Instructor = "Instructor";
        public const int AdministratorId = 1;
        public const int StudentId = 3;
        public const int InstructorId = 2;
    }
}