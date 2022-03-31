using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OrdersWPF.View
{
    public partial class DepartmentUpdateView : UserControl
    {
        public IEntityService entityService;
        public long index;
        public List<Department> query;
        public DepartmentUpdateView()
        {
            InitializeComponent();
            UpdateUp();
        }
        public async Task UpdateUp()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            await Task.Run(() =>
            {
                query = entityService.ReadDepartment();
            });
            dgDepartmentUpdate.ItemsSource = query;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UsingBase db = new UsingBase())
                {        
                    Department d = new Department();
                    d.ID_Department = index;
                    d.Name = txtName.Text;
                    d.ID_Worker = Convert.ToInt64(txtWorkerID.Text);
                    db.Entry(d).State = EntityState.Modified;
                    db.SaveChanges();
                }
                UpdateUp();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void dgDepartmentUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDepartmentUpdate.SelectedItem != null)
            {
                using (UsingBase db = new UsingBase())
                {
                    Department dID = dgDepartmentUpdate.SelectedItem as Department;
                    index = dID.ID_Department;
                    var query = (from q in db.Department
                                 where q.ID_Department == index
                                 select q).First();
                    txtName.Text = query.Name;
                    txtWorkerID.Text = query.ID_Worker.ToString();
                }
            }
        }
    }
}
