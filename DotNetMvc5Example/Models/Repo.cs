using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMvc5Example.Models
{
    public class Repo
    {
        public Repo()
        {
            System.Diagnostics.Debug.WriteLine("Repo made");
        }

        public string getStuff()
        {
            return "This is stuff from the repo";
        }
    }
}