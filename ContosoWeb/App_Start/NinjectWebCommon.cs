using ContosoWeb.Services;
using ContosoWeb.Models;
using ContosoWeb.Data;
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Contoso.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Contoso.App_Start.NinjectWebCommon), "Stop")]


namespace Contoso.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using ContosoWeb.Data;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Repositories
            kernel.Bind<IStudentRepository>().To<StudentRepository>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<IInstructorRepository>().To<InstructorRepository>();
            kernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();
            kernel.Bind<ICourseRepository>().To<CourseRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IEnrollmentRepository>().To<EnrollmentRepository>();

            //Services
            kernel.Bind<IStudentService>().To<StudentServiceEager>();
            kernel.Bind<IPersonService>().To<PersonService>();
            kernel.Bind<IInstructorService>().To<InstructorService>();
            kernel.Bind<IDepartmentService>().To<DepartmentService>();
            kernel.Bind<ICourseService>().To<CourseService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IEnrollmentService>().To<EnrollmentService>();
        }
    }
}
