using Microsoft.Extensions.DependencyInjection;
using OrdersWPF.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OrdersWPF.View
{
    public partial class OrderReadView : UserControl
    {
        public IEntityService entityService;
        public List<Order> query;
        public OrderReadView()
        {
            InitializeComponent();
            UpdateDg();
        }
        public async Task UpdateDg()
        {
            entityService = MainWindow.serviceProvider.GetService<IEntityService>();
            await Task.Run(() =>
            {
                query = entityService.ReadOrder();
            });
            dgOrderRead.ItemsSource = query.ToList();
        }
    }
}
