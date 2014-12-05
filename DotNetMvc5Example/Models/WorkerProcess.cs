using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMvc5Example.Models
{
    public class WorkerProcess
    {
        Repo _repo;

        public WorkerProcess(Repo repo)
        {
            _repo = repo;
            System.Diagnostics.Debug.WriteLine("Worker made");
        }

        public void doIt()
        {
            System.Diagnostics.Debug.WriteLine(_repo.getStuff());

        }
    }
}