using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<ReservationDto> reservations;
        private ObservableCollection<KundeDto> clients;
        private ObservableCollection<AutoDto> cars;


        public MainWindow()
        {
            InitializeComponent();
            InitializeCounter();
        }

        private void InitializeCounter()
        {
            channelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
            autoReservationService = channelFactory.CreateChannel();

            cars = new ObservableCollection<AutoDto>(autoReservationService.AllAutos);
            clients = new ObservableCollection<KundeDto>(autoReservationService.AllKunden);
            reservations = new ObservableCollection<ReservationDto>(autoReservationService.AllReservationen);

            CarListView.ItemsSource = cars;
            ClientListView.ItemsSource = clients;
            ReservationListView.ItemsSource = reservations;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (MainWindowTabControl.SelectedIndex == 0)
            //{
            //    CarListView.ItemsSource = autoReservationService.AllAutos;
            //}
            //else if (MainWindowTabControl.SelectedIndex == 1)
            //{
            //    ClientListView.ItemsSource = autoReservationService.AllKunden;
            //}
            //else if (MainWindowTabControl.SelectedIndex == 2)
            //{
            //    ReservationListView.ItemsSource = autoReservationService.AllReservationen;
            //}
        }
    }
}
