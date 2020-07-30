using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using System.Collections;
using LeoBayModel;
using LeoBayView.ShoppinCart;
using LeoBayController.ItemsManagerController;
using LeoBayController.CheckoutController;


namespace LeoBayView.ItemsManagerView
{
    /// <summary>
    /// Interaction logic for ShowItemsView.xaml
    /// </summary>
    public partial class ShowItemsView : UserControl
    {
        private ShoppingCart _shoppingCart = new ShoppingCart();
        private CheckoutController _checkoutController = new CheckoutController();
        //public MainWindow _mainWindow = ((MainWindow)Application.Current.MainWindow);
        private ItemsManagerController _itemsManagerController = new ItemsManagerController();
        public ShowItemsView()
        {
            InitializeComponent();
            PopulateAllItems();
            PopulateItemFields();
        }

        public void PopulateAllItems()
        {
            ListViewItems.ItemsSource = _itemsManagerController.GetAllItems();
        }

        public void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewItems.SelectedItem != null)
            {
                _itemsManagerController.SetSelectedItem(ListViewItems.SelectedItem);
                PopulateItemFields();
            }
        }

        public void PopulateItemFields()
        {
            if (_itemsManagerController.SelectedItem != null)
            {
                ProductName.Text = _itemsManagerController.SelectedItem.ProductName;
                Price.Text = _itemsManagerController.SelectedItem.Price.ToString();
            }
        }

        private void ButtonAddToCart_Click(object sender, RoutedEventArgs e)
        {
            int currentProductId = _itemsManagerController.SelectedItem.ProductId;
            string productName = _itemsManagerController.SelectedItem.ProductName;
            string price = _itemsManagerController.SelectedItem.Price.ToString();
            _checkoutController.AddToCart(currentProductId);
            _shoppingCart.GetCheckoutItem(productName, price, currentProductId);
            _shoppingCart.PopulateCheckoutItem();
            MessageBox.Show("Items added successfully to your cart!");
            _shoppingCart.Show();
        }


    }
}
