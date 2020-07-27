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
        //static void Main(string[] args)
        //{
        //    //Console.WriteLine(GetName());
        //}

        public void CreateNewUser(string firstName, string lastName, string email, string password)
        {
            using (var db = new LeoBayContext())
            {
                string encryptedPassword = Encrypt(password);
                db.Add(new User {FirstName = firstName, LastName = lastName, Email = email, Password = encryptedPassword });
                db.SaveChanges();
            }
        }

        public string Encrypt(string str)
        {
            string EncrptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
