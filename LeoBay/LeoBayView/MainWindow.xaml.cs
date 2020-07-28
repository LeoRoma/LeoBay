using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using LeoBayView.ItemsManagerView;
using LeoBayView.UserControls;

namespace LeoBayView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RegisterController _registerController = new RegisterController();
        private RegisterView _registerView = new RegisterView();
        private LoginView _loginView = new LoginView();
        private ShowItemsView _showItemsView = new ShowItemsView();
        private YourSpace _yourSpace = new YourSpace();
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = _registerView;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = _loginView;
        }

        private void ButtonShowItems_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = _showItemsView;
        }

        private void ButtonYourSpace_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = _yourSpace;
        }
    }
}
