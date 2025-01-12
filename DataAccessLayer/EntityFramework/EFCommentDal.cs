using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentsWithDestination()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(c => c.Destination).ToList();
            }
        }

        public List<Comment> GetListCommentsWithDestinationAndUser(int id)
        {
            using (var c = new Context())
            {
                return c.Comments.Where(x => x.DestinationID == id).Include(c => c.AppUser).ToList();
            }
        }




        public List<Comment> GetCommentsByUserWithDestination(int userId)
        {
            using (var c = new Context())
            {
                return c.Comments
                    .Where(x => x.AppUserID == userId) // Kullanıcıya göre filtrele
                    .Include(c => c.Destination)      // Destination bilgisini dahil et
                    .Include(c => c.AppUser)          // Kullanıcı bilgisini dahil et
                    .ToList();
            }
        }

    }
}
