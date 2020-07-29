using LeoBayController.ItemsManagerController;
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
using System.IO;
using System.Drawing;

namespace LeoBayView.ItemsManagerView
{
    /// <summary>
    /// Interaction logic for ShowItemsView.xaml
    /// </summary>
    public partial class ShowItemsView : UserControl
    {
        private ItemsManagerController _itemsManagerController = new ItemsManagerController();
        public ShowItemsView()
        {
            InitializeComponent();
            GetAllItems();
        }

        public void GetAllItems()
        {
            AllItems.ItemsSource = _itemsManagerController.GetAllItems();
        }
    }
}
