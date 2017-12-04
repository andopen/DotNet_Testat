﻿using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace AutoReservation.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAutoReservationService autoReservationService;
        private ChannelFactory<IAutoReservationService> channelFactory;

        public MainWindow()
        {
            InitializeComponent();
            InitializeCounter();
        }

        private void InitializeCounter()
        {
            channelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
            autoReservationService = channelFactory.CreateChannel();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReservationList.ItemsSource = autoReservationService.AllReservationen;
        }
    }
}
