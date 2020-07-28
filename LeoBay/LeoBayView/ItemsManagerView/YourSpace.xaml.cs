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

namespace LeoBayView.ItemsManagerView
{
    /// <summary>
    /// Interaction logic for YourSpace.xaml
    /// </summary>
    public partial class YourSpace : UserControl
    {
        private AddItem _addItem = new AddItem();
        public YourSpace()
        {
            InitializeComponent();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            _addItem.Show();
        }
    }
}
