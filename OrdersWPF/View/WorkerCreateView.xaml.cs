using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OrdersWPF.View
{
    public partial class WorkerCreateView : UserControl
    {
        public IEntityService entityService;
        public List<Worker> query;
        public WorkerCreateView()
        {
            InitializeComponent();
            UpdateCreate();
            UpdateCmb();
        }
        public async Task UpdateCreate()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            await Task.Run(() =>
            {
                query = entityService.ReadWorker();
            });
            dgWorkerCreate.ItemsSource = query;
        }
        public async Task UpdateCmb()
        {
            var sexs = Enum.GetValues(typeof(Sex));
            cmbSex.ItemsSource = sexs;
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker w = new Worker();
                w.Last_name = txtLastName.Text;
                w.First_name = txtFirstName.Text;
                w.Middle_name = txtMiddleName.Text;
                w.Birth_date = dpBirth.SelectedDate;
                w.Sex = cmbSex.SelectedItem.ToString();
                entityService.CreateWorker(w);
                UpdateCreate();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
