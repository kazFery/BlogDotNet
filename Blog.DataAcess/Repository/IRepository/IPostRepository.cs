using Blog.Models.Model;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repository.IRepository
{
    public  interface IPostRepository : IRepository<Post>
    {
        void Update(Post post); 
    }
}
