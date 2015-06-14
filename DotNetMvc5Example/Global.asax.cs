using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
//using Autofac.Extras.DomainServices;
using Autofac.Integration.Mvc;
using System.Reflection;
using DotNetMvc5Example.Models;

namespace DotNetMvc5Example
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            /* */
            builder.RegisterType<ExtensibleActionInvoker>()
                                    .As<IActionInvoker>()
                                    .WithParameter("injectActionMethodParameters", true);
            
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InjectActionInvoker();
           
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterType<Repo>().InstancePerRequest();
            builder.RegisterType<WorkerProcess>().OnActivating(e =>
            {
                var dep = e.Context.Resolve<Repo>();
                e.Instance.SetTheDependency(dep);
            }); ;
            builder.RegisterType<DeepWorker>().InstancePerRequest().PropertiesAutowired();

            builder.RegisterType<LoggedUser>().InstancePerRequest();

            builder.RegisterType<PropertyWorker>().PropertiesAutowired();

            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
