using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using LeoBayModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

using System.Data;
using System.Data.SqlClient;


namespace LeoBayController.ItemsManagerController
{
    public class ItemsManagerController
    {
        public void AddNewItem(string name, double price, string description, byte[] image)
        {
            using (var db = new LeoBayContext())
            {
                var newProduct = db.Users.Where(u => u.UserId == CurrentUser.Id).Include(p => p.Products).FirstOrDefault();
                Console.WriteLine(CurrentUser.Id);

                newProduct.Products.Add(
                    new Product
                    {
                        ProductName = name,
                        Price = price,
                        Description = description,
                        ImageData = image,
                        SellerId = CurrentUser.Id,
                        Date = DateTime.Now
                    });
                db.SaveChanges();
            }
        }

        public List<Product> GetAllItems()
        {
            using (var db = new LeoBayContext())
            {
                //var items =
                //    (from product in db.Products
                //     join user in db.Users on product.SellerId equals user.UserId
                //     select new { ProductName = product.ProductName, Description = product.Description, ImageByte = product.ImageData, Price = product.Price }).ToList();
                var items = db.Products.Where(p => p.SellerId == p.User.UserId).ToList();

                //foreach (var item in items)
                //{

                //    byte[] img = (byte[])item.ImageByte;
                //    Bitma

                //}
                return items;
            }
        }

        public List<Product> GetCurrentUserItems()
        {
            using (var db = new LeoBayContext())
            {
                //var items =
                //    (from product in db.Products
                //     join user in db.Users on product.SellerId equals user.UserId
                //     select new { ProductName = product.ProductName, Description = product.Description, ImageByte = product.ImageData, Price = product.Price }).ToList();
                var items = db.Products.Where(p => p.SellerId == CurrentUser.Id).ToList();

                //foreach (var item in items)
                //{

                //    byte[] img = (byte[])item.ImageByte;
                //    Bitma

                //}
                return items;
            }
        }

    }
}