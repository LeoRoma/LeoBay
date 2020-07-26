using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LeoBayModel
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public List<Product> Products { get; } = new List<Product>();
        public List<Sale> Sales { get; } = new List<Sale>();

    }
}
