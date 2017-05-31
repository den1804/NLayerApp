using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using System.Data.Entity;
namespace NLayerApp.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private MobileContext _db;
        public OrderRepository(MobileContext contex)
        {
            _db = contex;
        }

        public void Create(Order item)
        {
            _db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order order = _db.Orders.Find(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
            }
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return _db.Orders.Include(p => p.Phone).Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            return _db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.Include(p => p.Phone);
        }

        public void Update(Order item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
