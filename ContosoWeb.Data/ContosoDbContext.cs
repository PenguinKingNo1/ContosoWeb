using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;   // EF reference
using ContosoWeb.Models;

namespace ContosoWeb.Data
{
    public class ContosoDbContext : DbContext
    {
        public ContosoDbContext() : base("name = ContosoDbContext")//
        {
            Configuration.LazyLoadingEnabled = true;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Instructor>().Map(m => m.ToTable("Instructors"));
        //}
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Instructor> Instructors{ get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
    }
}
