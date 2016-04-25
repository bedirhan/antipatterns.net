using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntiPatterns.Models
{
    public class Database
    {
        public List<User> Users { get; set; }

        public List<Account> Accounts { get; set; }
    }
}