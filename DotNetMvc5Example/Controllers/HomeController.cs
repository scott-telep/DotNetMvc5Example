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
using System.IO;
using Amazon.S3;
using Amazon.S3.Transfer;

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

        public ActionResult About(int? id, WorkerProcess process, DeepWorker deep, DeepWorker deep2, LoggedUser user)
        {
            ViewBag.Message = "Your application description page.";

            deep2.doIt();

            user.sayIt();

            return View();
        }

        public ActionResult Contact(LoggedUser user)
        {
            ViewBag.Message = "Your contact page.";

            PropertyWorker pw = new PropertyWorker();

            pw.testPropInjection();

            return View();
        }

        public ActionResult TestDelayedAction(int? id)
        {
            System.Threading.Thread.Sleep(1000 * 10);

            return Content("Here is the page finally");
        }

        public ActionResult TestBucket(int? id)
        {
            ViewBag.Message = "Your contact page.";


            try
            {
                TransferUtility fileTransferUtility = new
                    TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast2));

                string filePath = Path.Combine(Server.MapPath("~/content/temp/"), "IMG_2126.JPG");
                string bucketname = "testbucket537dhfg";
                string keypath = "testdir/img.JPG";
                /*
                // 1. Upload a file, file name is used as the object key name.
                fileTransferUtility.Upload(filePath, bucketname);
                Console.WriteLine("Upload 1 completed");
                */
                 /*
                // 2. Specify object key name explicitly.
                fileTransferUtility.Upload(filePath,
                                          bucketname, "testdir/IMG_2126.JPG");
                Console.WriteLine("Upload 2 completed");
                
                // 3. Upload data from a type of System.IO.Stream.
                using (FileStream fileToUpload =
                    new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fileTransferUtility.Upload(fileToUpload,
                                               existingBucketName, keyName);
                }
                Console.WriteLine("Upload 3 completed");
                  * */
                
                // 4.Specify advanced settings/options.
                TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = bucketname,
                    FilePath = filePath,
                    StorageClass = S3StorageClass.Standard,
                    //PartSize = 6291456, // 6 MB.
                    Key = keypath,
                    CannedACL = S3CannedACL.PublicRead
                };
                
                fileTransferUtilityRequest.Metadata.Add("param1", "Value1");
                fileTransferUtilityRequest.Metadata.Add("param2", "Value2");
                
                fileTransferUtility.Upload(fileTransferUtilityRequest);
                
                Console.WriteLine("Upload 4 completed");
            }
            catch (AmazonS3Exception s3Exception)
            {
                Console.WriteLine(s3Exception.Message,
                                  s3Exception.InnerException);
            }


            return Content("Done");
        }
    }
}