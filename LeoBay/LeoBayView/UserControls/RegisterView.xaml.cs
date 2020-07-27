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

namespace LeoBayView.UserControls
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        private RegisterController _registerController = new RegisterController();
        //private MainWindow _mainWindow = new MainWindow();
        private LoginView _loginView = new LoginView();
        public RegisterView()
        {
            InitializeComponent();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //_mainWindow.LoginPanel.Children.Add(_loginView);
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
