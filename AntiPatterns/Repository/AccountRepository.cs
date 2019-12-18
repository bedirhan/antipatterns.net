using AntiPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntiPatterns.Repository
{
    public class AccountRepository
    {
        public Database Database { get; set; }
        public AccountRepository()
        {
            List<User> users = new List<User>();
            users.Add(new User() { ID = 1, Username = "akdora", FullName = "Ozay Akdora" });
            users.Add(new User() { ID = 2, Username = "burgun", FullName = "Bedirhan Urgun" });
            users.Add(new User() { ID = 3, Username = "dcevik", FullName = "Deniz Cevik" });
            users.Add(new User() { ID = 4, Username = "ogoker", FullName = "Ozer Goker" });
            users.Add(new User() { ID = 5, Username = "cdemirel", FullName = "Can Demirel" });

            List<Account> accounts = new List<Account>();
            accounts.Add(new Account() { ID = 1, UserID = 1, Amount = 4522.6, Title = "Primary", Description = "Primary bank account" });
            accounts.Add(new Account() { ID = 2, UserID = 1, Amount = 3412.3, Title = "Secondary", Description = "Secondary bank account" });
            accounts.Add(new Account() { ID = 3, UserID = 1, Amount = 529.7, Title = "Savings", Description = "Savings bank account" });
            accounts.Add(new Account() { ID = 4, UserID = 1, Amount = 2123.1, Title = "Credit", Description = "Credit card bank account" });
            accounts.Add(new Account() { ID = 5, UserID = 1, Amount = 2922.0, Title = "Extra", Description = "Extra bank account" });
            accounts.Add(new Account() { ID = 6, UserID = 1, Amount = 5633.6, Title = "Special", Description = "Special bank account" });
            accounts.Add(new Account() { ID = 7, UserID = 2, Amount = 9575.3, Title = "Primary", Description = "Primary bank account" });
            accounts.Add(new Account() { ID = 8, UserID = 2, Amount = 7563.5, Title = "Secondary", Description = "Secondary bank account" });
            accounts.Add(new Account() { ID = 9, UserID = 2, Amount = 9264.6, Title = "Savings", Description = "Savings bank account" });
            accounts.Add(new Account() { ID = 10, UserID = 2, Amount = 85463.1, Title = "Credit", Description = "Credit card bank account" });
            accounts.Add(new Account() { ID = 11, UserID = 2, Amount = 9474.2, Title = "Special", Description = "Special bank account" });
            accounts.Add(new Account() { ID = 12, UserID = 2, Amount = 523.3, Title = "Extra", Description = "Extra bank account" });
            accounts.Add(new Account() { ID = 13, UserID = 3, Amount = 937.4, Title = "Primary", Description = "Primary bank account" });
            accounts.Add(new Account() { ID = 14, UserID = 3, Amount = 324.5, Title = "Secondary", Description = "Secondary bank account" });
            accounts.Add(new Account() { ID = 15, UserID = 3, Amount = 967.6, Title = "Savings", Description = "Savings bank account" });
            accounts.Add(new Account() { ID = 16, UserID = 4, Amount = 274.7, Title = "Primary", Description = "Primary bank account" });
            accounts.Add(new Account() { ID = 17, UserID = 4, Amount = 758.8, Title = "Secondary", Description = "Secondary bank account" });
            accounts.Add(new Account() { ID = 18, UserID = 4, Amount = 437.9, Title = "Extra", Description = "Extra bank account" });
            accounts.Add(new Account() { ID = 19, UserID = 4, Amount = 937.4, Title = "Credit", Description = "Credit bank account" });
            accounts.Add(new Account() { ID = 20, UserID = 5, Amount = 483.3, Title = "Primary", Description = "Primary bank account" });
            accounts.Add(new Account() { ID = 21, UserID = 5, Amount = 39373.2, Title = "Secondary", Description = "Secondary bank account" });
            accounts.Add(new Account() { ID = 22, UserID = 5, Amount = 9463.1, Title = "Credit", Description = "Credit card bank account" });

            Database = new Database() { Accounts = accounts, Users = users };
        }

        public Account GetAccount(int accountID)
        {
            return Database.Accounts.Where(d => d.ID == accountID).FirstOrDefault();
        }

        public IEnumerable<Account> GetAccounts(int userID)
        {
            return Database.Accounts.Where(d => d.UserID == userID);
        }
    }
}