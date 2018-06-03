using DronePost.DataModel;
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

namespace StationSimulator
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string name = null;
        private string address = null;
        private float longitude = -1f;
        private float latitude = -1f;


        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Station s = new Station();
            name = NameTextBox.Text;


            try
            {
                longitude = float.Parse(LongitudeTextBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                latitude = float.Parse(LatitudeTextBox.Text, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Float convert exeption");
            }
            if (name != null && name != "" && address != null && address != "" && longitude != -1f && latitude != -1f)
            {
                s.Name = name;
                s.Address = address;
                s.Longitude = longitude;
                s.Latitude = latitude;

            }
            StationSimulation ss = new StationSimulation(s);

            ((MainWindow)Application.Current.MainWindow).droneList.Add(modelName);





            textBoxModelName.Text = "";
            textBoxMaxFlightDistance.Text = "";
            textBoxMaxWeightCarry.Text = "";
            comboBoxMaxSizeCarry.SelectedIndex = 0;
            MessageBox.Show("Drone is added");

            this.Close();
        }
    }
}
