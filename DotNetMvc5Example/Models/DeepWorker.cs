using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace DotNetMvc5Example.Models
{
    public class DeepWorker
    {
        public DeepWorker(WorkerProcess w){
            
            w.doIt();
            System.Diagnostics.Debug.WriteLine("DeepWorker made");
        }
    }
}