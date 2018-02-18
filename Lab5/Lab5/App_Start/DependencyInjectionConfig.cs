using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Lab5.Repositories;
using System.Reflection;
using System.Web.Mvc;
using Lab5.Data;
using Lab5.Services;

namespace Lab5.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<ICarRepository, CarRepository>(Lifestyle.Scoped);
            container.Register<ICarService, CarService>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<SubDbContext, SubDbContext>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}