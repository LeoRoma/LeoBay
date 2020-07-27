using System;
using System.Linq;
using LeoBayModel;

namespace LeoBayController
{
    public class Signup
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GetName());
        }

        public string GetName()
        {
            using (var db = new LeoBayContext())
            {
                string u = "";
                var users = 
                    from user in db.Users
                    select user;
                foreach (var item in users)
                {
                    u += item;
                }
                return u;
            }
            
        }
    }
}
