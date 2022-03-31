using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersWPF.Services
{
    public interface IEntityService
    {
        List<Worker> ReadWorker();
        Task CreateWorker(Worker w);
        Task UpdateWorker(Worker w);
        List<Order> ReadOrder();
        Task CreateOrder(Order o);
        Task UpdateOrder(Order o);
        List<Department> ReadDepartment();
        Task CreateDepartment(Department d);
        Task UpdateDepartment(Department d);
    }
}
