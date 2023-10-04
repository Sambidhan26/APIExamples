using System.Windows;

namespace ClientAPI
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

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            //textResult.Text = WebClientExamples.WebClientExamples.CallAction1("action1");
            //textResult.Text = HttpWebRequestExamples.HttpWebRequestExamples.CallAction1("action1");

            //textResult.Text = WebClientExamples.WebClientExamples.CallAction2("action2");
            //textResult.Text = WebClientExamples.WebClientExamples.CallAction8("action8");

            textResult.Text = WebClientExamples.WebClientExamples.CallAction9("action9");

        }
    }
}
