using System.Globalization;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Desktopcurs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartClock();
            DisplayCurrentDate();
            SetLabelShadow();
        }

        private void StartClock()
        {
            // Создаем таймер, который будет обновлять время каждую секунду
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Обновляем текст Label с текущим временем
            ClockLabel.Content = DateTime.Now.ToString("HH:mm");
        }
        private void DisplayCurrentDate()
        {
            DateTime now = DateTime.Now;
            // Используем CultureInfo для русского языка
            string formattedDate = $"{now.Day} {now.ToString("MMMM", new CultureInfo("en-EN"))} {now.Year}";
            DateLabel.Content = formattedDate;
        }
        private void SetLabelShadow()
        {
            DropShadowEffect shadowEffect = new DropShadowEffect
            {
                Color = Color.FromArgb(60, 60, 60, 0),
                BlurRadius = 4,
                ShadowDepth = 5,
                Direction = 315
            };
            ClockLabel.Effect = shadowEffect;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/Window2.xaml", UriKind.Relative));
        }

    }
}


