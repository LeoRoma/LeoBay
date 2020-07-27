using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LeoBayModel
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        
        public User User { get; set; }
        public string Sold { get; set; }
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        
        public Product Product { get; set; }
    }
}
