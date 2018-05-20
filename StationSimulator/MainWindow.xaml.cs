using System.Windows;

namespace StationSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMessageHandler
    {
        private Simulation _simulation;

        public MainWindow()
        {
            InitializeComponent();
            _simulation = new Simulation(this);
        }

        public void Handle(string message)
        {
            Dispatcher.Invoke(() => { LogTextBox.AppendText(message+"\n");});
        }

        private void StartSimButton_OnClick(object sender, RoutedEventArgs e)
        {
            _simulation.StartSimulation();
        }

        private void StopSimButton_OnClick(object sender, RoutedEventArgs e)
        {
            _simulation.StopSimulation();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _simulation.StopSimulation();
        }
    }
}
