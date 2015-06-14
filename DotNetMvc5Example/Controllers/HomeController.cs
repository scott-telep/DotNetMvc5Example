using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
//using Autofac.Extras.DomainServices;
using Autofac.Integration.Mvc;
using System.Reflection;
using DotNetMvc5Example.Models;

namespace DotNetMvc5Example.Controllers
{
    public class HomeController : Controller
    {
        public Repo _repo;

        public HomeController(Repo repo)
        {
            _repo = repo;
        }


        public ActionResult Index()
        {
            using (var scope2 = MvcApplication.container.BeginLifetimeScope(Autofac.Core.Lifetime.MatchingScopeLifetimeTags.RequestLifetimeScopeTag))
            {
                var w = scope2.Resolve<WorkerProcess>();
                w.doIt();

                var w2 = scope2.Resolve<WorkerProcess>();
                w2.doIt();

                var dw = scope2.Resolve<DeepWorker>();

                var dw2 = scope2.Resolve<DeepWorker>();
            }

            using (var scope2 = MvcApplication.container.BeginLifetimeScope(Autofac.Core.Lifetime.MatchingScopeLifetimeTags.RequestLifetimeScopeTag))
            {
                var w = scope2.Resolve<WorkerProcess>();
                w.doIt();

                var w2 = scope2.Resolve<WorkerProcess>();
                w2.doIt();

                var dw = scope2.Resolve<DeepWorker>();
            }

            /*
            //using (var scope = AutofacDependencyResolver.Current.RequestLifetimeScope)
            using (var scope2 = MvcApplication.container.BeginLifetimeScope(Autofac.Core.Lifetime.MatchingScopeLifetimeTags.RequestLifetimeScopeTag))
            {
                var service = scope2.Resolve<Repo>();
                var service2 = scope2.Resolve<Repo>();
            }

            using (var scope = MvcApplication.container.BeginLifetimeScope(Autofac.Core.Lifetime.MatchingScopeLifetimeTags.RequestLifetimeScopeTag))
            {
                var service3 = scope.Resolve<Repo>();
            }
            */
            return View();
        }

        public ActionResult About(int? id, WorkerProcess process, DeepWorker deep, DeepWorker deep2)
        {
            ViewBag.Message = "Your application description page.";

            deep2.doIt();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var worker = new WorkerProcess();

            return View();
        }
    }
}