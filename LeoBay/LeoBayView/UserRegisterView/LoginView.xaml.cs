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
using System.Text.RegularExpressions;
using LeoBayController;
using LeoBayModel;

namespace LeoBayView.UserRegisterView
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private LoginController _loginController = new LoginController();
        public LoginView()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxEmail.Text.Length == 0)
            {
                ErrorMessage.Text = "Enter an email.";
                TextBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(TextBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                ErrorMessage.Text = "Enter a valid email.";
                TextBoxEmail.Select(0, TextBoxEmail.Text.Length);
                TextBoxEmail.Focus();
            }
            else
            {
                string email = TextBoxEmail.Text;
                string password = passwordBox1.Password;

                if (_loginController.AuthenticateUser(email, password) == true)
                {
                    string welcomeMessage = _loginController.GetCurrentUser();
                    MessageBox.Show(welcomeMessage);
                    this.Close();
                }
                else
                {
                    ErrorMessage.Text = "Sorry! Please enter existing emailid/password.";
                }

            }
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            //_mainWindow.Main.Content = _registerView;
        }
    }
}
