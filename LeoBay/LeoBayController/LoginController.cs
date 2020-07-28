using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using LeoBayModel;
using System.Linq;

namespace LeoBayController
{
    public class LoginController
    {
        private Encryption _encryption = new Encryption();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            //AuthenticateUser("chris@gmail.com", "123");
        }

        public bool AuthenticateUser(string email, string password)
        {
            using (var db = new LeoBayContext())
            {
                var encryptedPassword = db.Users.Where(u => u.Email == email).Select(u => u.Password).FirstOrDefault();
                var decryptedPassword = _encryption.Decrypt(encryptedPassword);
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
                if (details.FirstOrDefault() != null && decryptedPassword == password)
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
            CurrentUser.Id = currentUserId;
            CurrentUser.FirstName = currentFirstName;
            CurrentUser.LastName = currentLastName;
            CurrentUser.Email = currentEmail;
            //};
            GetCurrentUser();
        }

        public string GetCurrentUser()
        {
            return $"Welcome To LeoBay {CurrentUser.FirstName} {CurrentUser.LastName}";
        }

        
    }
}
