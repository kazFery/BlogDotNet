using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.Model.ViewModel
{
	public class PostVM
	{
        public Post Post { get; set; }

        [ValidateNever]
        public IEnumerable<Comment>? CommentList { get; set; }
    }
}
