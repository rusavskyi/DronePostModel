﻿using DronePost.DataModel;
using DroneSimulator.CoreServiceReference;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DroneSimulator
{
	/// <summary>
	/// Interaction logic for AddDrone.xaml
	/// </summary>
	public partial class AddDrone : Window
	{
		//public List<String> droneList = new List<String>();


		private string modelName = null;
		private int maxCarrySize = -1;
		private float maxWeightSize = -1f;
		private float maxFlightDistance = -1f;
		private CoreServiceClient _coreServiceClient;
		private List<PackageSize> _maxCarrySize;
		
		public AddDrone()
		{
			InitializeComponent();

			_coreServiceClient = new CoreServiceClient();
			_maxCarrySize = ((MainWindow)Application.Current.MainWindow).Simulation._packageSize;
			for (int i = 0; i < _maxCarrySize.Count; i++)
			{
				comboBoxMaxSizeCarry.Items.Insert(i, _maxCarrySize.ElementAt(i).SizeName);
			}

		}


		private void button_Click(object sender, RoutedEventArgs e)
		{
		
			Drone d = new Drone();
			modelName = textBoxModelName.Text;
			
			
			try
			{
				maxWeightSize = float.Parse(textBoxMaxWeightCarry.Text, CultureInfo.InvariantCulture.NumberFormat);
				maxFlightDistance = float.Parse(textBoxMaxFlightDistance.Text, CultureInfo.InvariantCulture.NumberFormat);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Float convert exeption");
			}
			if (modelName != null && modelName != "" && maxCarrySize != -1 && maxWeightSize != -1f && maxFlightDistance != -1f)
			{
				d.Model.ModelName = modelName;
				d.Model.MaxSizeCarry = new PackageSize();
				d.Model.MaxFlightDistance = maxFlightDistance;
				d.Model.MaxWeightCarry = maxWeightSize;

			}
			
			((MainWindow)Application.Current.MainWindow).DroneList.Add(modelName);
			((MainWindow)Application.Current.MainWindow).Simulation.HostDrone(d);



			textBoxModelName.Text = "";
			textBoxMaxFlightDistance.Text = "";
			textBoxMaxWeightCarry.Text = "";
			comboBoxMaxSizeCarry.SelectedIndex = 0;
			
			MessageBox.Show("Drone is added");
			((MainWindow)Application.Current.MainWindow).LogTextBox.Text +=( "Drone "+modelName +" is added \n");
			this.Close();
		}
	}
}
