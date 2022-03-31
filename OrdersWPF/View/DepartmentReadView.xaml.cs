using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OrdersWPF.View
{
    public partial class DepartmentReadView : UserControl
    {
        public IEntityService entityService;
        public List<Department> query;
        public DepartmentReadView()
        {
            InitializeComponent();
            UpdateDg();
        }
        public async Task UpdateDg()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            await Task.Run(() =>
            {
                query = entityService.ReadDepartment();
            });
            dgDepartmentRead.ItemsSource = query;
        }
    }
}
