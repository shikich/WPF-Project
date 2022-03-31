using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OrdersWPF.View
{
    public partial class DepartmentCreateView : UserControl
    {
        public IEntityService entityService;
        public List<Department> query;
        public DepartmentCreateView()
        {
            InitializeComponent();
            UpdateCreate();
        }
        public async Task UpdateCreate()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            await Task.Run(() =>
            {
                query = entityService.ReadDepartment();
            });
            dgDepartmentCreate.ItemsSource = query;
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Department d = new Department();
                d.Name = txtName.Text;
                d.ID_Worker = Convert.ToInt64(txtWorkerID.Text);
                entityService.CreateDepartment(d);
                UpdateCreate();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
