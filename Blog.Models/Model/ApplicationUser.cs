
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Model
{
    public class ApplicationUser: IdentityUser
    {
      

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        [ValidateNever]
        public List<Post>? Posts { get; set; }

        [ValidateNever]
        public List<Comment>? Comments { get; set; }

    }
}
