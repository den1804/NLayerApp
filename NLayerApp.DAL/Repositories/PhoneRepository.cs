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
     public class PhoneRepository : IRepository<Phone>
    {
        private MobileContext _db;
        public PhoneRepository(MobileContext context)
        {
            _db = context;
        }

        public void Create(Phone item)
        {
            _db.Phones.Add(item);
        }

        public void Delete(int id)
        {
            Phone phohe = _db.Phones.Find(id);
            if (phohe != null)
                _db.Phones.Remove(phohe);
        }

        public IEnumerable<Phone> Find(Func<Phone, bool> predicate)
        {
            return _db.Phones.Where(predicate).ToList();
        }

        public Phone Get(int id)
        {
            return _db.Phones.Find(id);
        }

        public IEnumerable<Phone> GetAll()
        {
            return _db.Phones;
        }

        public void Update(Phone item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
