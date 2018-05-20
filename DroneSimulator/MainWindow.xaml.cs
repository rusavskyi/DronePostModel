using DronePost.DataModel;
using System;
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



        public MainWindow()
        {
            InitializeComponent();
			comboBoxMaxSizeCarry.Items.Insert(0, "A");
			comboBoxMaxSizeCarry.Items.Insert(1, "B");
			comboBoxMaxSizeCarry.Items.Insert(2, "C");
			comboBoxMaxSizeCarry.Items.Insert(3, "D");

		}

		private void button_Click_1(object sender, RoutedEventArgs e)
		{
			Drone d = new Drone();
			try {
				maxWeightSize = float.Parse(textBoxMaxWeightCarry.ToString());
				maxFlightDistance = float.Parse(textBoxMaxFlightDistance.ToString());
			}
			catch (Exception ex) {

			}
			if (modelName != null && modelName != "" && maxCarrySize!=-1 && maxWeightSize!=-1f && maxFlightDistance!=-1f)
			{
				d.Model.ModelName = modelName;
				d.Model.MaxSizeCarry = new PackageSize();
				d.Model.MaxFlightDistance = maxFlightDistance;
				d.Model.MaxWeightCarry = maxWeightSize;

			}
			DroneSimulation ds = new DroneSimulation(d);
			MessageBox.Show("Drone is added");
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void comboBoxMaxSizeCarry_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
