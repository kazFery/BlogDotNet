﻿using Blog.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repository.IRepository
{
    public  interface ICommentRepository : IRepository<Comment>
    {
        void Update(Comment comment);
    }
}
