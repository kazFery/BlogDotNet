using Blog.DataAccess.Repository.IRepository;
using Blog.DataAccess.Data;
using Blog.Models.Model;
using Bolg.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repository
{
    public class  PostRepository : Repository<Post>, IPostRepository
    {
      private ApplicationDbContext _db;
      public PostRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Post post)
        {
            _db.posts.Update(post);
        }

    }
}
