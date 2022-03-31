using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OrdersWPF.View
{
    public partial class ReadView : UserControl
    {
        public IEntityService entityService;
        public List<Order> query;
        public ReadView()
        {
            InitializeComponent();
            UpdateLast();
            UpdateBorders();
        }
        public async Task UpdateLast()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            await Task.Run(() =>
            {
                query = entityService.ReadOrder();
            });
            txtLast.Text = "ID: " + query.Last().ID_Order + 
                           "\nName: " + query.Last().Name_product +
                           "\nTags: " + query.Last().Tags;
        }
        public async Task UpdateBorders()
        {
            using (UsingBase db = new UsingBase())
            {
                var qrOrder = entityService.ReadOrder();
                var qrWorker = entityService.ReadWorker();
                var qrDepartment = entityService.ReadDepartment();
                txtOrderLenght.Text = qrOrder.Count + " Rows";
                txtWorkerLenght.Text = qrWorker.Count + " Rows";
                txtDepartLenght.Text = qrDepartment.Count + " Rows";
            }
        }
    }
}
