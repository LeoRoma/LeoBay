using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeoBayModel
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public string Sold { get; set; }
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
