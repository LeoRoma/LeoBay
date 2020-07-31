using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LeoBayModel
{
    public static partial class CurrentUser
    {
        public static int Id { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string Email { get; set; }

        private static string _image;
        public static string Image 
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
  
            }
        }
    }
}

