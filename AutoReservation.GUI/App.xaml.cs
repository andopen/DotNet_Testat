using AutoReservation.GUI.ViewModels;
using System.Windows;

namespace AutoReservation.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainWindowViewModel AppVm { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppVm = new MainWindowViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = AppVm
            };
            MainWindow.Show();
            ((MainWindow)MainWindow).Init();
            // eigener init code...
        }




    }
}
