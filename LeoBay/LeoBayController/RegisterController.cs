using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using LeoBayModel;

namespace LeoBayController
{
    public class RegisterController
    {
        private Encryption _encryption = new Encryption();
        //static void Main(string[] args)
        //{
        //    //Console.WriteLine(GetName());
        //}

        public void CreateNewUser(string firstName, string lastName, string email, string password)
        {
            using (var db = new LeoBayContext())
            {
                string encryptedPassword = _encryption.Encrypt(password);
                db.Add(new User {FirstName = firstName, LastName = lastName, Email = email, Password = encryptedPassword });
                db.SaveChanges();
            }
        }

      
    }
}
