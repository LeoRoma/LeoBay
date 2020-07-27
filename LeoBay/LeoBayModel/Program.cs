using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LeoBayModel

{
    class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine(u);
            }

        }
    }
}
