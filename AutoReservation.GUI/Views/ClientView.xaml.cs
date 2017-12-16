﻿using AutoReservation.GUI.ViewModels;
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

namespace AutoReservation.GUI.Views
{
    /// <summary>
    /// Interaction logic for ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl
    {
        public ClientView()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove the client permanently?", "Delete Client", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var viewModel = (ClientViewModel)DataContext;
                if (viewModel.DeleteCommand.CanExecute(null))
                {
                    viewModel.DeleteCommand.Execute(null);
                }
            }
        }
    }
}
