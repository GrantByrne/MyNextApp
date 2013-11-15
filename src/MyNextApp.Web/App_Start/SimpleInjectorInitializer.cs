[assembly: WebActivator.PostApplicationStartMethod(typeof(MyNextApp.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace MyNextApp.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;
    using MyNextApp.Components.Service;
    using MyNextApp.Components.Service.Abstract;
    using MyNextApp.Components.Repository;
    using MyNextApp.Components.Repository.Abstract;
    using MyNextApp.Components.Domain;
    using Raven.Client;
    using Raven.Client.Document;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>
        ///     Initialize the container and register it as MVC3 Dependency Resolver.
        /// </summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: http://bit.ly/YE8OJj.
            var container = new Container();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.RegisterMvcAttributeFilterProvider();
       
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {

            DocumentStore ds = new DocumentStore { ConnectionStringName = "RavenHQ" };
            var something = ds.Url;
            ds.Initialize();

            container.RegisterSingle<IDocumentStore>(ds);
            container.Register<IGenericRepository<Idea>, GenericRepository<Idea>>();
            container.Register<IIdeaService, IdeaService>();
            

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>();
        }
    }
}