using Blog.DataAccess.Repository.IRepository;
using Blog.Models.Model;
using Blog.Models.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BlogWebApp.Pages.post
{
    public class PostCommentsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty(SupportsGet = true)]
        public PostVM PostVM { get; set; }

        public PostCommentsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int? id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            PostVM = new()
            {
                CommentList = _unitOfWork.Comment.GetAll(u => u.PostId == id, includeProperties: "ApplicationUser"),
                Post = _unitOfWork.Post.GetFirstOrDefault(u => u.Id == id && u.ApplicationUserId == claim.Value, includeProperties: "ApplicationUser")
            };
            


        }
    }
}
