using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeoBayModel
{ 
    public partial class Product
    {
        public override string ToString()
        {
            return $"{ProductName} £{Price} {Description} {ImageData}";
        }
    }
}
