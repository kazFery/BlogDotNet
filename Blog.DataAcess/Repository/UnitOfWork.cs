
using Blog.DataAccess.Repository.IRepository;
using Blog.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DataAcess.Repository;

namespace Blog.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;  
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Post = new PostRepository(_db);
            Comment = new CommentRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
        public IPostRepository Post { get; private set; }
        public ICommentRepository Comment { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

  
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
