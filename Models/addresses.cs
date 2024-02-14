using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
namespace CCCGBreeze.Models
{
    public class addresses
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public addresses()
        {

        }
    }


}
