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
using LeoBayModel;
using LeoBayView.ShoppinCart;
using LeoBayController.ItemsManagerController;

namespace LeoBayView.ItemsManagerView
{
    /// <summary>
    /// Interaction logic for ShowItemsView.xaml
    /// </summary>
    public partial class ShowItemsView : UserControl
    {
        private ShoppingCart _shoppingCart = new ShoppingCart();
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
            AllItems.ItemsSource = _itemsManagerController.GetAllItems();
        }

        public void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AllItems.SelectedItem != null)
            {
                //_mainWindow.SetSelectedProduct(AllItems.SelectedItem);
                _itemsManagerController.SetSelectedItem(AllItems.SelectedItem);
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
            string productName = _itemsManagerController.SelectedItem.ProductName;
            string price = _itemsManagerController.SelectedItem.Price.ToString();
            _shoppingCart.GetCheckoutItem(productName, price);
            _shoppingCart.PopulateCheckoutItem();
            _shoppingCart.Show();
        }
    }
}
