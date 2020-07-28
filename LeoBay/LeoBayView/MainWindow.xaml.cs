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
using LeoBayModel;

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
        private bool _login;
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
            if(_login == false)
            {
                MessageBoxResult result = MessageBox.Show("You must login before to acceed this area", "Error");
            }
            Main.Content = _showItemsView;
        }

        private void ButtonYourSpace_Click(object sender, RoutedEventArgs e)
        {
            if (_login == false)
            {
                MessageBoxResult result = MessageBox.Show("You must login before to acceed this area", "Error");
            }
            Main.Content = _yourSpace;
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            EndCurrentUser();
            MessageBoxResult result = MessageBox.Show("You have logged out", "Logout");

        }

        private void EndCurrentUser()
        {
            CurrentUser.Id = 0;
            CurrentUser.FirstName = "";
            CurrentUser.LastName = "";
            CurrentUser.Email = "";
        }

        private void CheckLogin()
        {
            if(CurrentUser.Id == 0)
            {
                _login = false;
            }
            _login = true;
        }
    }
}
