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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LeoBayController;
using LeoBayController.ItemsManagerController;

namespace LeoBayView.ItemsManagerView
{
    /// <summary>
    /// Interaction logic for YourSpace.xaml
    /// </summary>
    public partial class YourSpace : UserControl
    {
        private ItemsManagerController _itemsManagerController = new ItemsManagerController();
        private AddItem _addItem = new AddItem();
        public YourSpace()
        {
            InitializeComponent();
            GetCurrentItems();
        }

        public void GetCurrentItems()
        {
            CurrentItems.ItemsSource = _itemsManagerController.GetCurrentUserItems();
        }

        public void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            
            _addItem.Show();
        }
    }
}