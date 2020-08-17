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
using LeoBayController.CheckoutController;
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
        private CheckoutController _checkoutController = new CheckoutController();
        private Product _product = new Product();

        private int _currentProductId;
        private string _name;
        private string _price;
        private string _description;
        private string _image;

        private Image buttonImage;

        public Image ButtonImage
        {
            get
            {
                return buttonImage;
            }
        }

        private ImageSourceConverter _imgSourceConverter = new ImageSourceConverter();
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
                Description.Text = _description;
                //BitmapImage src = new BitmapImage();
                //src.BeginInit();
                //src.UriSource = new Uri(CurrentUser.Image, UriKind.Relative);
                //src.CacheOption = BitmapCacheOption.OnLoad;
                //src.EndInit();

                buttonImage = new Image();
                //buttonImage.Source = src;
            }
        }

        public void GetCheckoutItem(string productName, string price, int currentProductId, string description)
        {
            SetCheckoutItemName(productName);
            SetCheckoutItemPrice(price);
            SetCheckoutItemId(currentProductId);
            SetCheckoutItemDescription(description);
        }

        public void SetCheckoutItemName(string productName)
        {
            _name = productName;
        }

        public void SetCheckoutItemPrice(string price)
        {
            _price = price;
        }

        public void SetCheckoutItemId(int currentProductId)
        {
            _currentProductId = currentProductId;
        }

        public void SetImage(string image)
        {
            _image = image;
        }


        public void SetCheckoutItemDescription(string description)
        {
            _description = description;
        }

        private void ButtonConfirmPayment_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Checkout complete");
            _checkoutController.AddToCart(_currentProductId);
            _checkoutController.ConfirmPayment(_currentProductId);
            this.Close();
        }

    }
}
