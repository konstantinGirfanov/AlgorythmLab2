using AlgorythmLab2.Model;
using AlgorythmLab2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlgorythmLab2.View
{
    /// <summary>
    /// Логика взаимодействия для FractalWindow.xaml
    /// </summary>
    public partial class FractalWindow : Window
    {

        public FractalWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(DepthTextBox.Text, out int depth) == false)
            {
                MessageBox.Show("Глубина задана неверно. Задайте значение глубины рекурсии корректно и попробуйте снова", "Ошибка считывания глубины", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            new FractalDrawer(this, depth/*, currentWindow.Width / 2, currentWindow.Height / 2*/);
        }
    }
}
