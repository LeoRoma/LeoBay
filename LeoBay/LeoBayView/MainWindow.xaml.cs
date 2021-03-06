﻿
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
//using LeoBayView.UserControls;
using LeoBayView.Pages.RegisterView;
using LeoBayModel;
using LeoBayController.ItemsManagerController;
using LeoBayView.ShoppinCart;

namespace LeoBayView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RegisterView _registerView = new RegisterView();
        private LoginView _loginView = new LoginView();
        private ShowItemsView _showItemsView = new ShowItemsView();
        private YourSpace _yourSpace = new YourSpace();
        private ItemsManagerController _itemsManagerController = new ItemsManagerController();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(this);
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new RegisterView());
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new LoginView());
        }

        private void ButtonShowItems_Click(object sender, RoutedEventArgs e)
        {
            _showItemsView.PopulateAllItems();
            FrameMain.Navigate(new ShowItemsView());
        }

        private void ButtonYourSpace_Click(object sender, RoutedEventArgs e)
        {
            _yourSpace.GetCurrentItems();
            FrameMain.Navigate(new YourSpace());
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            EndCurrentUser();
            
            MessageBoxResult result = MessageBox.Show("You have logged out", "Logout");
            _yourSpace.GetCurrentItems();
            FrameMain.Navigate(new YourSpace());
        }

        private void EndCurrentUser()
        {
            CurrentUser.Id = 0;
            CurrentUser.FirstName = "";
            CurrentUser.LastName = "";
            CurrentUser.Email = "";
        }
    }
}