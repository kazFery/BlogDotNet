using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPostRepository Post { get; }

        ICommentRepository Comment { get; }

        IApplicationUserRepository ApplicationUser { get; }

        void Save();
    }
}
