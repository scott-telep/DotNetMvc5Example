using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace DotNetMvc5Example.Models
{
    public class DeepWorker
    {
        Repo _repo;
        public WorkerProcess workerprop { get; set; }

        public DeepWorker(WorkerProcess w, Repo repo){
            System.Diagnostics.Debug.WriteLine("DeepWorker made");
            _repo = repo;
            w.doIt();
        }

        public void doIt()
        {

            System.Diagnostics.Debug.WriteLine("Deep do it " + _repo.getStuff());

            workerprop.doIt();

        }

    }
}