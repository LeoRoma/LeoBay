using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeoBayModel;
using Microsoft.EntityFrameworkCore;

namespace LeoBayController.CheckoutController
{
    public class CheckoutController
    {
        public void AddToCart(int productId)
        {
            using(var db = new LeoBayContext())
            {
                var user = db.Users.Where(u => u.UserId == CurrentUser.Id).FirstOrDefault();
                var order = db.Orders;
                db.Add(new Order { ProductId = productId, BuyerId = CurrentUser.Id, Date = DateTime.Now});
                db.SaveChanges();
            }
        }

        public void ConfirmPayment()
        {
            using(var db = new LeoBayContext())
            {
                var order = db.Orders.Where(o => o.BuyerId == CurrentUser.Id).FirstOrDefault();
                order.Sold = "Sold";
                db.SaveChanges();
            }
            DeleteSoldItem();
        }

        public void DeleteSoldItem()
        {
            using (var db = new LeoBayContext())
            {
                var products =
                    (from product in db.Products
                    join order in db.Orders on product.ProductId equals order.ProductId
                    select product).FirstOrDefault();
                Console.WriteLine(products);
                db.Remove(products);
                db.SaveChanges();
            }

        }
    }
}
