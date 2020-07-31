
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using LeoBayController.ItemsManagerController;

namespace LeoBayView.ItemsManagerView
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        private ItemsManagerController _itemsManagerController = new ItemsManagerController();
        private ShowItemsView _showItemsView = new ShowItemsView();
        public AddItem()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.ShowDialog();

            openFileDialog1.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            openFileDialog1.DefaultExt = ".png";

            //Path of image
            TextBoxImage1.Text = openFileDialog1.FileName;
            //Load image
            ImageSource imageSource = new BitmapImage(new Uri(TextBoxImage1.Text));
            //Show image
            ImageBox1.Source = imageSource;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxName.Text;
            double price = double.Parse(TextBoxPrice.Text);
            string description = TextBoxDescription.Text;
            string image = TextBoxImage1.Text;
            _itemsManagerController.AddNewItem(name, price, description, image);
            MessageBox.Show("You have added an item!");
            this.Close();
            _showItemsView.PopulateAllItems();
            FrameMain.Navigate(new ShowItemsView());
        }
    }
}
