using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> TGetDestinationById(int id);
        List<Comment> TGetListCommentsWithDestination();
        public List<Comment> TGetListCommentsWithDestinationAndUser(int id);


        List<Comment> TGetCommentsByUserWithDestination(int userId); // Yeni metot


    }
}
