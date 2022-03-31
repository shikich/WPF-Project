using System.Windows;
using System.Windows.Input;

namespace OrdersWPF.Windows
{
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mwWin = new MainWindow();
            mwWin.Show();
        }
    }
}
