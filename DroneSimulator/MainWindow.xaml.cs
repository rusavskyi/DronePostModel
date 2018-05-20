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

		public List<string> droneList = new List<string>();


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
	}
}
