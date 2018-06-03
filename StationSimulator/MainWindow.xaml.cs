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
        private List<string> stationList = new List<string>();
        private Simulation _simulation;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void StartSimButton_Click(object sender, RoutedEventArgs e)
        {
            _simulation = new Simulation(this);
            _simulation.StartSimulation();
            AddStationButton.Visibility = Visibility.Visible;
           // buttonAddTask.Visibility = Visibility.Visible;
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

        }
    }
}
