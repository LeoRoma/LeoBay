using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LeoBayModel
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [StringLength(50)]
        public double Price { get; set; }
        public string Description { get; set; }
        public  int SellerId { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public User User { get; set; }
        public List<Sale> Sales { get; } = new List<Sale>();

    }
}
