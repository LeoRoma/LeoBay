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
        private CurrentUser _currentUser = new CurrentUser();
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
                    int currentUserId = details.FirstOrDefault().UserId;
                    string currentFirstName = details.FirstOrDefault().FirstName;
                    string currentLastName = details.FirstOrDefault().LastName;
                    string currentEmail = details.FirstOrDefault().Email;
                    SetCurrentUser(currentUserId, currentFirstName, currentLastName, currentEmail);
                    return true;
                }
                return false;
            }
        }

        public void SetCurrentUser(int currentUserId, string currentFirstName, string currentLastName, string currentEmail)
        {
            //CurrentUser currentUser = new CurrentUser()
            //{
            _currentUser.CurrentUserId = currentUserId;
            _currentUser.CurrentFirstName = currentFirstName;
            _currentUser.CurrentLastName = currentLastName;
            _currentUser.CurrentEmail = currentEmail;
            //};
        }
    }
}
