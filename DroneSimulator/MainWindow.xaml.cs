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

		public List<string> DroneList = new List<string>();
		public Simulation Simulation;
		public bool isAddedDrone = false;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void buttonAddDrone_Click(object sender, RoutedEventArgs e)
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

		public void Handle(string s)
		{
			Dispatcher.Invoke(() =>
			{
				LogTextBox.Text += s + "\n";
				LogTextBox.ScrollToEnd();
			});
		}

		private void button_startSim_Click(object sender, RoutedEventArgs e)
		{
			Simulation = new Simulation(this);
			Simulation.StartSimulation();
			ButtonAddDront.Visibility = Visibility.Visible;
			ButtonAddTask.Visibility = Visibility.Visible;
			
		}

		private void button_stopSim_Click(object sender, RoutedEventArgs e)
		{
			Simulation.StopSimulation();
			ButtonAddDront.Visibility = Visibility.Hidden;
			ButtonAddTask.Visibility = Visibility.Hidden;
		}
	}
}
