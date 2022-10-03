using Blog.DataAccess.Repository.IRepository;
using Blog.DataAccess.Data;
using Blog.Models.Model;
using Bolg.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private ApplicationDbContext _db;
        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Comment comment)
        {
            _db.comments.Update(comment);
        }
    }
}
