using AutoReservation.GUI.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AutoReservation.GUI.Views
{
    /// <summary>
    /// Interaction logic for ReservationView.xaml
    /// </summary>
    public partial class ReservationView : UserControl
    {
        public ReservationView()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove the reservation permanently?", "Delete Reservation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var viewModel = (ReservationViewModel)DataContext;
                if (viewModel.DeleteCommand.CanExecute(null))
                {
                    viewModel.DeleteCommand.Execute(null);
                }
            }
        }

        private void Live_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ReservationViewModel)DataContext;
            if (viewModel.LiveCommand.CanExecute(null))
            {
                viewModel.LiveCommand.Execute(null);
            }

        }

        private void cbActiveReservations_Checked(object sender, RoutedEventArgs e)
        {
            if (ReservationDataGrid != null)
            {
                var collectionView = CollectionViewSource.GetDefaultView(ReservationDataGrid.ItemsSource);
                collectionView.Filter = ((ReservationViewModel)DataContext).IsReservationActive;
                collectionView.Refresh();
            }
        }

        private void cbActiveReservations_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ReservationDataGrid != null)
            {
                var collectionView = CollectionViewSource.GetDefaultView(ReservationDataGrid.ItemsSource);
                collectionView.Filter = null;
                collectionView.Refresh();
            }
        }
    }
}
