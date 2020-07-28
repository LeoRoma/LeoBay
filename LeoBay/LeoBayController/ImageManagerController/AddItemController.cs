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
        private CurrentUser _currentUser = new CurrentUser();
        public void AddNewItem(string name, double price, string description, string image)
        {
            using (var db = new LeoBayContext())
            {
                var newProduct = db.Users.Where(u => u.UserId == _currentUser.CurrentUserId).Include(p => p.Products).FirstOrDefault();
                byte[] imageToByte = null;
                FileStream fileStream = new FileStream(image, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fileStream);
                imageToByte = binaryReader.ReadBytes((int)fileStream.Length);

                newProduct.Products.Add(
                    new Product
                    {
                        ProductName = name,
                        Price = price,
                        Description = description,
                        ImageData = @imageToByte,
                        SellerId = _currentUser.CurrentUserId,
                        Date = DateTime.Now
                    });
                db.SaveChanges();
            }
        }

    }
}
