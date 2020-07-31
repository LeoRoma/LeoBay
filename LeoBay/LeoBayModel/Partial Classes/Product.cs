using System;
using System.Collections.Generic;
using System.Text;


namespace LeoBayModel
{
    public partial class Product
    {
        public override string ToString()
        {
            return $"{ProductName} {Price} {Description} {ImageData}";
        }
    }
}