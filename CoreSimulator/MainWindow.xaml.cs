using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows;
using CoreService;

namespace CoreSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceHost _host;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void WriteToOutput(string message)
        {
            Dispatcher.Invoke(() => { LogTextBox.AppendText(message + "\n"); });
        }

        private void StartHost()
        {
            Uri baseAddress = new Uri("http://localhost:8888/Core");
            _host = new ServiceHost(typeof(CoreService.CoreService), baseAddress);

            try
            {
                ServiceEndpoint endpoint = _host.AddServiceEndpoint(
                    typeof(ICoreService),
                    new WSHttpBinding(),
                    ""
                    );
                ServiceMetadataBehavior bechavior = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true
                };
                _host.Description.Behaviors.Add(bechavior);
                _host.Open();
            }
            catch (Exception e)
            {
                
            }
        }

        private void StopHost()
        {
            _host.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopHost();
        }

        private void StartSimButton_Click(object sender, RoutedEventArgs e)
        {
            StartHost();
        }

        private void StopSimButton_Click(object sender, RoutedEventArgs e)
        {
            StopHost();
        }
    }
}
