using AutoReservation.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutoReservation.GUI {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public MainWindowViewModel AppVm { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppVm = new MainWindowViewModel();
            MainWindow = new MainWindow();
            MainWindow.DataContext = AppVm;
            MainWindow.Show();
            // eigener init code...
        }
    }
}
