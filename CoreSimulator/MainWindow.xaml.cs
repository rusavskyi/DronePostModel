using System.Windows;


namespace CoreSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void WriteToOutput(string message)
        {
            Dispatcher.Invoke(() => { TbOutput.AppendText(message + "\n"); });
        }
    }
}
