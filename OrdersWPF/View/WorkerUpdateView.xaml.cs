using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OrdersWPF.View
{
    public partial class WorkerUpdateView : UserControl
    {
        public IEntityService entityService;
        public List<Worker> query;
        public long index;
        public WorkerUpdateView()
        {
            InitializeComponent();
            UpdateDg();
            UpdateCmb();
        }
        public async Task UpdateDg()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            await Task.Run(() =>
            {
                query = entityService.ReadWorker();
            });
            dgWorkerUpdate.ItemsSource = query;
        }
        public async Task UpdateCmb()
        {
            var sexs = Enum.GetValues(typeof(Sex));
            cmbSex.ItemsSource = sexs;
        }
        private void dgWorkerUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgWorkerUpdate.SelectedItem != null)
            {
                using (UsingBase db = new UsingBase())
                {
                    Worker wID = dgWorkerUpdate.SelectedItem as Worker;
                    index = wID.ID_Worker;
                    var query = (from q in db.Worker
                                where q.ID_Worker == index
                                select q).First();
                    txtLastName.Text = query.Last_name;
                    txtFirstName.Text = query.First_name;
                    txtMiddleName.Text = query.Middle_name;
                    dpBirth.SelectedDate = query.Birth_date;
                    cmbSex.Text = query.Sex;
                }
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UsingBase db = new UsingBase())
                {
                    Worker w = new Worker();
                    w.ID_Worker = index;
                    w.Last_name = txtLastName.Text;
                    w.First_name = txtFirstName.Text;
                    w.Middle_name = txtMiddleName.Text;
                    w.Birth_date = dpBirth.SelectedDate;
                    w.Sex = cmbSex.SelectedItem.ToString();
                    entityService.UpdateWorker(w);
                }
                UpdateDg();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
