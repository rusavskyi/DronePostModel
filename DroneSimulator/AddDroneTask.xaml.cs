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
	/// Interaction logic for AddDroneTask.xaml
	/// </summary>
	public partial class AddDroneTask : Window
	{
		public AddDroneTask()
		{
			InitializeComponent();

			comboBoxDroneTask.Items.Insert(0, "TakePackage");
			comboBoxDroneTask.Items.Insert(1, "GoToStation");
			comboBoxDroneTask.Items.Insert(2, "LeavePackage");
			comboBoxDroneTask.Items.Insert(3, "ChargeAtStation");

			comboBoxStation.Items.Insert(0, "StationA");
			comboBoxStation.Items.Insert(1, "StationB");
			comboBoxStation.Items.Insert(2, "StationC");
			comboBoxStation.Items.Insert(3, "StationD");
			comboBoxStation.Items.Insert(4, "StationE");
			comboBoxStation.Items.Insert(5, "StationF");

			foreach (string droneName in ((MainWindow)Application.Current.MainWindow).droneList) {
				comboBoxDrone.Items.Add(droneName);
			}

			
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Task is added");
		
			this.Close();
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
