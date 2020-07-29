﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LeoBayModel
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [StringLength(50)]
        public double Price { get; set; }
        public string Description { get; set; }

        public byte[] ImageData { get; set; }
        [MaxLength(16)]
        public int SellerId { get; set; }
        public int? OrderId { get; set; }
        //public int ImageId { get; set; }
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public User User { get; set; }
        public Order Order { get; set; }

        //public Image Image { get; set; }

    }
}