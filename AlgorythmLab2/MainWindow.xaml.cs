using AlgorythmLab2.View;
using System.Windows;

namespace AlgorythmLab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
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