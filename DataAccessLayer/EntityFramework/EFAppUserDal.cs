using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public AppUser GetByID(int id)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Delete(AppUser appUser)
        {
            using (var context = new Context())
            {
                context.Remove(appUser);
                context.SaveChanges();
            }
        }



    }
}
