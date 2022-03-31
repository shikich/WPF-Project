using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWPF.Services
{
    public class EntityService : IEntityService
    {
        //Worker
        public List<Worker> ReadWorker()
        {
            using (UsingBase db = new UsingBase())
            {
                var query = from q in db.Worker
                        select q;
                return query.ToList();
            }
        }
        public async Task CreateWorker(Worker w)
        {
            UsingBase db = new UsingBase();
            db.Worker.Add(w);
            db.SaveChanges();
        }
        public async Task UpdateWorker(Worker w)
        {
            UsingBase db = new UsingBase();
            db.Entry(w).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Order
        public List<Order> ReadOrder()
        {
            using (UsingBase db = new UsingBase())
            {
                var query = from q in db.Order
                        select q;
                return query.ToList();
            }
        }
        public async Task CreateOrder(Order o)
        {
            UsingBase db = new UsingBase();
            db.Order.Add(o);
            db.SaveChanges();
        }
        public async Task UpdateOrder(Order o)
        {
            UsingBase db = new UsingBase();
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Department
        public List<Department> ReadDepartment()
        {
            using (UsingBase db = new UsingBase())
            {
                var query = from q in db.Department
                        select q; 
                return query.ToList();
            }
        }
        public async Task CreateDepartment(Department d)
        {
            UsingBase db = new UsingBase();
            db.Department.Add(d);
            db.SaveChanges();
        }
        public async Task UpdateDepartment(Department d)
        {
            UsingBase db = new UsingBase();
            db.Entry(d).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
