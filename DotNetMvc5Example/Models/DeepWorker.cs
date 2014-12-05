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

        public DeepWorker(WorkerProcess w, Repo repo){
            _repo = repo;
            w.doIt();
            System.Diagnostics.Debug.WriteLine("DeepWorker made");
        }

        public void doIt()
        {

            System.Diagnostics.Debug.WriteLine("Deep do it " + _repo.getStuff());



        }

    }
}