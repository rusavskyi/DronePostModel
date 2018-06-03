using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows;
using CoreService;


namespace CoreHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMessageHandler
    {

        private Core _core;

        public MainWindow()
        {
            InitializeComponent();
            _core = new Core(this);
        }

        public void WriteToOutput(string message)
        {
            Dispatcher.Invoke(() => { LogTextBox.AppendText(message + "\n"); });
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _core.StopHost();
        }

        private void StartSimButton_Click(object sender, RoutedEventArgs e)
        {
            _core.StartHost();
        }

        private void StopSimButton_Click(object sender, RoutedEventArgs e)
        {
            _core.StopHost();
        }

        public void Handle(string message)
        {
            WriteToOutput(message);
        }

        private void TEST_OnClick(object sender, RoutedEventArgs e)
        {
            _core.Test();
        }
    }
}
