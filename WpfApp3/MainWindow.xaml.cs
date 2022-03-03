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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("addCustomer.xaml", UriKind.Relative));
        }
        private void ListClient_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("CustomerList.xaml", UriKind.Relative));
        }

        private void AddCourtier_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("addBroker.xaml", UriKind.Relative));
        }

        private void ListCourtier_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("brokerList.xaml", UriKind.Relative));
        }

        private void AddRDV_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("addAppointment.xaml", UriKind.Relative));
        }

        private void ListRDV_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("AppointmentList.xaml", UriKind.Relative));
        }
    }
}
