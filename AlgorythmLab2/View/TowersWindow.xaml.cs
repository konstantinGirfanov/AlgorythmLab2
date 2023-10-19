using AlgorythmLab2.ViewModel;
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
using System.Windows.Shapes;

namespace AlgorythmLab2.View
{
    /// <summary>
    /// Логика взаимодействия для TowersWindow.xaml
    /// </summary>
    public partial class TowersWindow : Window
    {
        public static int CurrentStep { get; set; } = 0;

        public TowersWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
    private void NextStepButton_Click(object sender, RoutedEventArgs e)
        {
            HanoiAnimator.MoveTheRing(1);
        }

        private void PreviousStepButton_Click(object sender, RoutedEventArgs e)
        {
            HanoiAnimator.MoveTheRing(-1);
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(RingsCountTextBox.Text, out int ringsCount) == false)
            {
                MessageBox.Show("Задайте количество колец корректно и попробуйте снова", "Ошибка считывания количества колец", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
             HanoiAnimator.HanoiAnimatorInit(this, ringsCount);
        }
    }
}
