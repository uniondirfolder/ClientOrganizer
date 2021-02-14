﻿
using System.Windows;

namespace ClientOrganizer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow(new ViewModel.MainViewModel(new Data.ClientDataService()));

            mainWindow.Show();
        }

    }
}
