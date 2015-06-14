using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMvc5Example.Models
{
    public class LoggedUser
    {

        public string name { get; set; }

        public LoggedUser()
        {
            name = HttpContext.Current.Request.Path;
        }

        public void sayIt()
        {

            System.Diagnostics.Debug.WriteLine("I'm " + name);


        }

    }
}