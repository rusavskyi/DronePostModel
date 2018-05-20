using DronePost.DataModel;
using System;
using System.Collections.Generic;
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
		private string modelName = null;
		private int maxCarrySize = -1;
		private float maxWeightSize = -1f;
		private float maxFlightDistance = -1f;
		private List<DroneSimulation> droneList = new List<DroneSimulation>();
		public AddDrone()
		{
			InitializeComponent();

			comboBoxMaxSizeCarry.Items.Insert(0, "A");
			comboBoxMaxSizeCarry.Items.Insert(1, "B");
			comboBoxMaxSizeCarry.Items.Insert(2, "C");
			comboBoxMaxSizeCarry.Items.Insert(3, "D");
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
		
			Drone d = new Drone();
			
			try
			{
				maxWeightSize = float.Parse(textBoxMaxWeightCarry.Text);
				maxFlightDistance = float.Parse(textBoxMaxFlightDistance.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Float conver exeption");
			}
			if (modelName != null && modelName != "" && maxCarrySize != -1 && maxWeightSize != -1f && maxFlightDistance != -1f)
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
			MainWindow mw = new MainWindow();
			mw.Show();
		}
	}
}
