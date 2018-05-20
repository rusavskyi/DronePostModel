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
	public partial class MainWindow : Window
	{
		private string modelName = null;
		private int maxCarrySize = -1;
		private float maxWeightSize = -1f;
		private float maxFlightDistance = -1f;
		private List<DroneSimulation> droneList = new List<DroneSimulation>();


		public MainWindow()
		{
			InitializeComponent();

		}

		private void buttonAddDront_Click(object sender, RoutedEventArgs e)
		{
			AddDrone ad = new AddDrone();
			ad.Show();
		}

		private void buttonAddTask_Click(object sender, RoutedEventArgs e)
		{
			AddDroneTask adt = new AddDroneTask();
			adt.Show();
		}
	}
}
