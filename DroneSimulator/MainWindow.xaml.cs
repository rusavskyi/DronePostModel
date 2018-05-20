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
			comboBoxMaxSizeCarry.Items.Insert(0, "A");
			comboBoxMaxSizeCarry.Items.Insert(1, "B");
			comboBoxMaxSizeCarry.Items.Insert(2, "C");
			comboBoxMaxSizeCarry.Items.Insert(3, "D");

			comboBoxDroneTask.Items.Insert(0, "TakePackage");
			comboBoxDroneTask.Items.Insert(1, "GoToStation");
			comboBoxDroneTask.Items.Insert(2, "LeavePackage");
			comboBoxDroneTask.Items.Insert(3, "ChargeAtStation");

			comboBoxStation.Items.Insert(0, "StationA");
			comboBoxStation.Items.Insert(0, "StationB");
			comboBoxStation.Items.Insert(0, "StationC");
			comboBoxStation.Items.Insert(0, "StationD");
			comboBoxStation.Items.Insert(0, "StationE");
			comboBoxStation.Items.Insert(0, "StationF");
		}

		private void button_Click_1(object sender, RoutedEventArgs e)
		{
			modelName = textBoxModelName.Text;
			Drone d = new Drone();
			comboBoxDrone.Items.Add(modelName);
			try { 
				maxWeightSize = float.Parse(textBoxMaxWeightCarry.Text);
				maxFlightDistance = float.Parse(textBoxMaxFlightDistance.Text);
			}
			catch (Exception ex) {
				MessageBox.Show("Float conver exeption");
			}
			if (modelName != null && modelName != "" && maxCarrySize!=-1 && maxWeightSize!=-1f && maxFlightDistance!=-1f)
			{
				
				d.Model.ModelName = modelName;
				d.Model.MaxSizeCarry = new PackageSize();
				d.Model.MaxFlightDistance = maxFlightDistance;
				d.Model.MaxWeightCarry = maxWeightSize;

			}
			DroneSimulation ds = new DroneSimulation(d);
			droneList.Add(ds);
			
				


			textBoxModelName.Text = "";
			textBoxMaxFlightDistance.Text = "";
			textBoxMaxWeightCarry.Text = "";
			comboBoxMaxSizeCarry.SelectedIndex = 0;
			MessageBox.Show("Drone is added");
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void comboBoxMaxSizeCarry_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{

		}

		private void comboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
		{

		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			comboBoxDrone.SelectedIndex = 0;
			comboBoxDroneTask.SelectedIndex = 0;
			comboBoxStation.SelectedIndex = 0;
			MessageBox.Show("Task is added to queue");
		}
	}
}
