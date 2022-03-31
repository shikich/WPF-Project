using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using OrdersWPF.Windows;
using System;
using System.Windows;
using System.Windows.Input;

namespace OrdersWPF
{
    public partial class MainWindow : Window
    {
        public static IServiceProvider serviceProvider;
        public MainWindow()
        {
            InitializeComponent();
            serviceProvider = CreateServiceProvider();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IEntityService, EntityService>();
            services.AddSingleton<ITagEditor, TagEditor>();
            return services.BuildServiceProvider();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            WorkersWindow wrkWin = new WorkersWindow();
            wrkWin.Show();
            Hide();
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordWin = new OrdersWindow();
            ordWin.Show();
            Hide();
        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            DepartmentsWindow dprtWin = new DepartmentsWindow();
            dprtWin.Show();
            Hide();
        }
    }
}
