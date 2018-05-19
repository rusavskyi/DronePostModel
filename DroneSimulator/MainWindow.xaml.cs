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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

		private void button_Click_1(object sender, RoutedEventArgs e)
		{
			Drone d = new Drone();
			if (modelName != null && modelName != "" && maxCarrySize!=-1f && maxWeightSize!=-1f && maxFlightDistance!=-1f)
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
	}
}
