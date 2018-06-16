using DronePost.DataModel;
using DroneSimulator.CoreServiceReference;
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
		private List<Station> _stations;
		private List<Drone> _drones;
		private CoreServiceClient _coreServiceClient;
		
		public AddDroneTask()
		{
			InitializeComponent();

			comboBoxDroneTask.Items.Insert(0, "TakePackage");
			comboBoxDroneTask.Items.Insert(1, "GoToStation");
			comboBoxDroneTask.Items.Insert(2, "LeavePackage");
			comboBoxDroneTask.Items.Insert(3, "ChargeAtStation");



			_coreServiceClient = new CoreServiceClient();
			_stations = new List<Station>(_coreServiceClient.GetStations());
			for (int i = 0; i < _stations.Count; i++)
			{
				comboBoxStation.Items.Insert(i, _stations.ElementAt(i).Name);
			}

			if (!((MainWindow)Application.Current.MainWindow).isAddedDrone)
			{
				_coreServiceClient = new CoreServiceClient();
				_drones = ((MainWindow)Application.Current.MainWindow).Simulation._drones;
				foreach (Drone drone in _drones)
				{
					((MainWindow)Application.Current.MainWindow).droneList.Add(drone.Model.ModelName);
				}
				((MainWindow)Application.Current.MainWindow).isAddedDrone = true;
			}

			foreach (string droneName in ((MainWindow)Application.Current.MainWindow).droneList)
			{
				comboBoxDrone.Items.Add(droneName);
			}


		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Task is added");
			((MainWindow)Application.Current.MainWindow).LogTextBox.Text += ("New task is added \n");
			this.Close();
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
