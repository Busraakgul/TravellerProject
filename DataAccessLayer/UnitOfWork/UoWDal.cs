using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UoWDal : IUoWDal
    {
        private readonly Context _context;

        public UoWDal(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();//2 tarafta da contrsuctor oluşturuldu buradan anlaşılacak 
        }
    }
}
