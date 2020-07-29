using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LeoBayController;
using LeoBayController.ItemsManagerController;
using LeoBayModel;

namespace LeoBayView.ShoppinCart
{
    /// <summary>
    /// Interaction logic for ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Window
    {
        private ItemsManagerController _itemsManagerController = new ItemsManagerController();
        private Product _product = new Product();
        private string _name;
        private string _price;
        public ShoppingCart()
        {
            InitializeComponent();
            PopulateCheckoutItem();
        }

        public void PopulateCheckoutItem()
        {
            if (_name != null && _price != null)
            {
                ProductName.Text = _name;
                Price.Text = _price;
            }
        }

        public void GetCheckoutItem(string productName, string price)
        {
            SetCheckoutItemName(productName);
            SetCheckoutItemPrice(price);
        }

        public string SetCheckoutItemName(string productName)
        {
            _name = productName;
            return _name;
        }

        public string SetCheckoutItemPrice(string price)
        {
            _price = price;
            return _price;
        }

        private void ButtonConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            
            if(AmounToPay.Text == _price)
            {
                MessageBox.Show("Checkout complete");
            }
            MessageBox.Show("Please insert correct amount");
        }
    }
}
