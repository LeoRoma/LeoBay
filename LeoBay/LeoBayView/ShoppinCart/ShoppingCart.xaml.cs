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
        public ShoppingCart()
        {
            InitializeComponent();
            //ShowItem();
        }

        //public void ShowItem()
        //{
        //    if (_itemsManagerController.SelectedItem != null)
        //    {
        //        DataContext = _itemsManagerController.ShowItemToCart();
        //    }
        //}
    }
}
