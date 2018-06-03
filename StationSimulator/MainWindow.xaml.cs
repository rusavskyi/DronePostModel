using DronePost.DataModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StationSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMessageHandler
    {
        public List<string> stationList = new List<string>();
        private Simulation _simulation;

        public MainWindow()
        {
            InitializeComponent();
            _simulation = new Simulation(this);
        }

        private void StartSimButton_Click(object sender, RoutedEventArgs e)
        {
            _simulation = new Simulation(this);
            AddStationButton.Visibility = Visibility.Visible;
            _simulation.StartSimulation();
        }

        public void Handle(string message)
        {
            Dispatcher.Invoke(() => { LogTextBox.AppendText(message+"\n");});
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _simulation.StopSimulation();
        }

        private void LogTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StopSimButton_Click(object sender, RoutedEventArgs e)
        {
            _simulation.StopSimulation();
            AddStationButton.Visibility = Visibility.Hidden;
        }

        private void AddStationButton_Click(object sender, RoutedEventArgs e)
        {
            //Station station = new Station(){Id = 1, Address = "Śląska 88"};
            //_simulation.AddStation(station);
            AddStation ads = new AddStation();
            ads.Show();
        }
    }
}
