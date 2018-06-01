using DronePost.DataModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DroneSimulator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IMessageHandlerDrone
	{

		public List<string> droneList = new List<string>();
		public SimulationDrone _simulationDrone;

		public MainWindow()
		{
			InitializeComponent();
			

		}

		private void buttonAddDront_Click(object sender, RoutedEventArgs e)
		{
			AddDrone ad = new AddDrone();
			//ad.DataContext = this;
			ad.Show();
		}

		private void buttonAddTask_Click(object sender, RoutedEventArgs e)
		{
			AddDroneTask adt = new AddDroneTask();
			//adt.DataContext = this;
			adt.Show();
		}

		public void Handle(string s) {
			textBlock_log.Text += s;
		}

		private void button_startSim_Click(object sender, RoutedEventArgs e)
		{
			_simulationDrone = new SimulationDrone(this);
			_simulationDrone.startSimulation();
			buttonAddDront.Visibility = Visibility.Visible;
			buttonAddTask.Visibility = Visibility.Visible;
			
		}

		private void button_stopSim_Click(object sender, RoutedEventArgs e)
		{
			_simulationDrone.StopSimulation();
			buttonAddDront.Visibility = Visibility.Hidden;
			buttonAddTask.Visibility = Visibility.Hidden;
		}
	}
}
