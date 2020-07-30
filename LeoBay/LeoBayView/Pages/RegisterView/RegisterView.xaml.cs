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

namespace LeoBayView.Pages.RegisterView
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        private RegisterController _registerController = new RegisterController();
        //private MainWindow _mainWindow = new MainWindow();
        //private LoginView _loginView = new LoginView();
        public RegisterView()
        {
            InitializeComponent();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
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
                string firstName = TextBoxFirstName.Text;
                string lastName = TextBoxLastName.Text;
                string email = TextBoxEmail.Text;
                string password = PasswordBox1.Password;
                if (PasswordBox1.Password.Length == 0)
                {
                    ErrorMessage.Text = "Enter password.";
                    PasswordBox1.Focus();
                }
                else if (PasswordBoxConfirm.Password.Length == 0)
                {
                    ErrorMessage.Text = "Enter Confirm password.";
                    PasswordBoxConfirm.Focus();
                }
                else if (PasswordBox1.Password != PasswordBoxConfirm.Password)
                {
                    ErrorMessage.Text = "Confirm password must be same as password.";
                    PasswordBoxConfirm.Focus();
                }
                else
                {
                    ErrorMessage.Text = "";

                    _registerController.CreateNewUser(firstName, lastName, email, password);
                    ErrorMessage.Text = "You have Registered successfully.";
                    Reset();
                }
            }
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxEmail.Text = "";
            PasswordBox1.Password = "";
            PasswordBoxConfirm.Password = "";
        }


        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            //_mainWindow.Main.Content = _loginView;
        }
    }
}
