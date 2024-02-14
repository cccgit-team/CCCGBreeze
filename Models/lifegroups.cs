using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
namespace CCCGBreeze.Models
{
    public class lifegroups
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string status { get; set; }
        public string gender { get; set; }
        public string profession { get; set; }
        public lifegroups()
        {

        }
    }


}
