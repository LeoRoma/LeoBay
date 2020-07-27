using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LeoBayModel
{
    public class CurrentUser
    {
        private int _currentUserId;
        private string _currentFirstName;
        private string _currentLastName;
        private string _currentEmail;
        public  int CurrentUserId 
        {
            get { return _currentUserId; }
            set { _currentUserId = value; }
        }
        public string CurrentFirstName
        {
            get { return _currentFirstName; }
            set { _currentFirstName = value; }
        }
        public string CurrentLastName
        {
            get { return _currentLastName; }
            set { _currentLastName = value; }
        }
        public string CurrentEmail
        {
            get { return _currentEmail; }
            set { _currentEmail = value; }
        }

        //public int GetCurrentUserId(int userId)
        //{
        //    return userId;
        //}
    }
}
