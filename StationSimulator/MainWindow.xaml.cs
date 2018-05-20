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
        private List<StationSimulation> stationList = new List<StationSimulation>();
        private Simulation _simulation;

        public MainWindow()
        {
            InitializeComponent();

            ListOfPackagesComboBox.Items.Insert(0, "To send");
            ListOfPackagesComboBox.Items.Insert(1, "To give");
        }

        private void StartSimButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            String name = StationNameTextBox.Text;
            String address = StationAddressTextBox.Text;
            float longitude = -1;
            float latitude = -1;
            
            Station station = new Station();
            try
            {
                longitude = float.Parse(StationLongitudeTextBox.Text);
                latitude = float.Parse(StationLatitudeTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Longitude or latitude is wrong");
            }

            if (name != "" && address != "" && longitude > 0 && latitude > 0)
            {
                station.Name = name;
                station.Address = address;
                station.Longitude = longitude;
                station.Latitude = latitude;
            }

            StationSimulation stationSimulation = new StationSimulation(station);
            stationList.Add(stationSimulation);
            StationComboBox.Items.Add(name);

            StationNameTextBox.Text = "";
            StationAddressTextBox.Text = "";
            StationLongitudeTextBox.Text = "";
            StationLatitudeTextBox.Text = "";

            
        }

        private void comboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            StationComboBox.Items.Clear();
            ListOfPackagesComboBox.Items.Clear();

            foreach (StationSimulation stationSimulation in stationList)
            {
                if (StationComboBox.Text == stationSimulation.Station.Name)
                {
                    foreach (Drone drone in stationSimulation._drones)
                    {
                        ListBoxOfDrones.Items.Add(drone.Id + " " + drone.Model.ModelName);
                    }

                    if (ListOfPackagesComboBox.SelectedIndex == 0)
                    {
                        foreach (Package package in stationSimulation._packagesToSent)
                        {
                            ListBoxOfDrones.Items.Add(package.Id + " " + package.RecipientPhoneNumber);
                        }
                    }
                    else
                    {
                        foreach (Package package in stationSimulation._packagesToSent)
                        {
                            ListBoxOfDrones.Items.Add(package.Id + " " + package.RecipientPhoneNumber);
                        }
                    }
                }
                
            }


            //foreach (Drone drone in )
            //{
            //    listBox1.Items.Add("Item " + x.ToString());
            //}
        }

        private void StationLatitudeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StationAddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StationNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StationLongitudeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _simulation = new Simulation(this);
        }

        public void Handle(string message)
        {
            Dispatcher.Invoke(() => { LogTextBox.AppendText(message+"\n");});
        }

        private void StartSimButton_OnClick(object sender, RoutedEventArgs e)
        {
            _simulation.StartSimulation();
        }

        private void StopSimButton_OnClick(object sender, RoutedEventArgs e)
        {
            _simulation.StopSimulation();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _simulation.StopSimulation();
        }
    }
}
