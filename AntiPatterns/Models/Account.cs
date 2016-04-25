using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntiPatterns.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}