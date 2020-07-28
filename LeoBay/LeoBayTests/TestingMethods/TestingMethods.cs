using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using LeoBayModel;
using Microsoft.EntityFrameworkCore;

namespace LeoBayTests
{
    public class TestingMethods
    {
        public List<User> GetUser()
        {
            using (var db = new LeoBayContext())
            {
                var users = db.Users.ToList();
                return users;
            }
                
        }

        public void DeleteUser()
        {
            using (var db = new LeoBayContext())
            {
                var users = db.Users.ToList();
                users.Reverse();
                var lastUser = users[0];
                db.Users.Remove(lastUser);
                db.SaveChanges();
            }
        }

        public bool AuthenticateUser(string email, string password)
        {
            using (var db = new LeoBayContext())
            {
                var pw = db.Users.Where(u => u.Email == email).Select(u => u.Password).FirstOrDefault();
                var details =
                    (from user in db.Users
                     where user.Email == email
                     select new
                     {
                         user.UserId,
                         user.FirstName,
                         user.LastName,
                         user.Email
                     }).ToList();
                if (details.FirstOrDefault() != null && pw == password)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
