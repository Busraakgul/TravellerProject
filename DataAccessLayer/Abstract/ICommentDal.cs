﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetListCommentsWithDestination();

        public List<Comment> GetListCommentsWithDestinationAndUser(int id);



        List<Comment> GetCommentsByUserWithDestination(int userId); // Yeni metot

    }
}
