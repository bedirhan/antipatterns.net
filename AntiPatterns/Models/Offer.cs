using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntiPatterns.Models
{
    public class Offer
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public int Total { get; set; }
        public string Reference { get; set; }
    }
}