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
        private CurrentUser _currentUser = new CurrentUser();
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
                var decryptedPassword = Decrypt(encryptedPassword);
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
            _currentUser.CurrentUserId = currentUserId;
            _currentUser.CurrentFirstName = currentFirstName;
            _currentUser.CurrentLastName = currentLastName;
            _currentUser.CurrentEmail = currentEmail;
            //};
            GetCurrentUser();
        }

        public string GetCurrentUser()
        {
            return $"Welcome to Leobay {_currentUser.CurrentFirstName} {_currentUser.CurrentLastName}";
        }

        public string Decrypt(string str)
        {
            str = str.Replace(" ", "+");
            string DecryptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[str.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
    }
}
