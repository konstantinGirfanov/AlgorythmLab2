using AlgorythmLab2.View;

namespace AlgorythmLab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TowersButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TowersWindow window = new TowersWindow();
            window.Show();
            window.Owner = this;
        }

        private void FractalButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FractalWindow window = new FractalWindow();
            window.Show();
            window.Owner = this;
        }
    }
}