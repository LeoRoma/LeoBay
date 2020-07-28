using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using LeoBayModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LeoBayController.ImageManagerController
{
    public class AddItemController
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
  
    }
}
