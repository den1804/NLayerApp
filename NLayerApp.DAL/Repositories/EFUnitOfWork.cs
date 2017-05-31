using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private MobileContext _db;
        private PhoneRepository _phoneRepository;
        private OrderRepository _orderRepository;
        private bool _disposed = false;
        public EFUnitOfWork(string connectionString)
        {
            _db = new MobileContext(connectionString);
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_db);
                }
                return _orderRepository;
            }
        }

        public IRepository<Phone> Phones
        {
            get
            {
                if (_phoneRepository == null)
                {
                    _phoneRepository = new PhoneRepository(_db);
                }
                return _phoneRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if(disposing)
                {
                    _db.Dispose();
                }
                disposing = true;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
