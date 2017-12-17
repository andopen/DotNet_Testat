using AutoReservation.GUI.ViewModels;
using System.Windows;
using System.Windows.Controls;

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
