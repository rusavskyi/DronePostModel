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
        private Simulation simulation;

        internal Simulation Simulation { get => simulation; set => simulation = value; }

        public MainWindow()
        {
            InitializeComponent();
            Simulation = new Simulation(this);
        }

        private void StartSimButton_Click(object sender, RoutedEventArgs e)
        {
            Simulation = new Simulation(this);
            AddStationButton.Visibility = Visibility.Visible;
            Simulation.StartSimulation();
        }

        public void Handle(string message)
        {
            Dispatcher.Invoke(() => { LogTextBox.AppendText(message+"\n");});
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Simulation.StopSimulation();
        }

        private void LogTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StopSimButton_Click(object sender, RoutedEventArgs e)
        {
            Simulation.StopSimulation();
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
