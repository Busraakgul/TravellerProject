using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericUowRepository<T> : IGenericUowDal<T> where T : class
    {
        private readonly Context _context;

        public GenericUowRepository(Context context)
        {
            _context = context;
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            _context.Add(t);
            //_context.SaveChanges(); Unit of work kullanmanın bir anlamı olmaz, SaveChanges başka bir method ya da sınıfta tanımlanacak

        }

        public void MultiUpdate(List<T> t)
        {
            _context.UpdateRange(t);//Aynı anda birden fazla değeri günceller.
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}
