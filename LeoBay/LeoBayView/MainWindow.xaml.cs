﻿using System;
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
using LeoBayView.UserControls;

namespace LeoBayView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Signup _signup = new Signup();
        private Register _register = new Register();
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void ButtonHomeClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRegisterClick(object sender, RoutedEventArgs e)
        {
            RegisterPanel.Children.Add(_register);
        }
    }
}
