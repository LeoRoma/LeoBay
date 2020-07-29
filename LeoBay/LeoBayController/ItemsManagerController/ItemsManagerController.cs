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
        public Product SelectedItem { get; set; }
        public void AddNewItem(string name, double price, string description, string image)
        {
            using (var db = new LeoBayContext())
            {
                var newProduct = db.Users.Where(u => u.UserId == CurrentUser.Id).Include(p => p.Products).FirstOrDefault();
                byte[] imageToByte = File.ReadAllBytes(image);

                newProduct.Products.Add(
                    new Product
                    {
                        ProductName = name,
                        Price = price,
                        Description = description,
                        ImageData = imageToByte,
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
                //Stream StreamObj = new MemoryStream(result);

                //BitmapImage BitObj = new BitmapImage();

                //BitObj.BeginInit();

                //BitObj.StreamSource = StreamObj;

                //BitObj.EndInit();
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

        public void SetSelectedItem(object selectedItem)
        {
            selectedItem = (Product)SelectedItem;
        }

    }
}