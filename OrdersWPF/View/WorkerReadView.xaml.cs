using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Windows.Controls;
using System.Threading.Tasks;
using OrdersWPF.Services;
using System.Collections.Generic;

namespace OrdersWPF.View
{
    public partial class WorkerReadView : UserControl
    {
        public IEntityService entityService;
        public List<Worker> query;
        public WorkerReadView()
        {
            InitializeComponent();
            UpdateWorker();
        }
        public async Task UpdateWorker()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            await Task.Run(() =>
            {
                query = entityService.ReadWorker();
            });
            dgWorkerRead.ItemsSource = query.ToList();
        }
    }
}
