using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LeoBayModel
{
    public partial class CurrentUser
    {
        public int CurrentUserId { get; set; }
        public string CurrentFirstName { get; set; }
        public string CurrentLastName { get; set; }
        public string CurrentEmail { get; set; }
    }
}
