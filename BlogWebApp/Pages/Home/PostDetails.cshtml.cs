using Blog.DataAccess.Repository.IRepository;
using Blog.Models.Model;
using Blog.Models.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BlogWebApp.Pages.Home
{
    public class PostDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty(SupportsGet = true)]
        public PostVM PostVM  {get; set;}

        public PostDetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int? postId)
        {
            PostVM = new()
            {
                CommentList = _unitOfWork.Comment.GetAll(u => u.PostId == postId, includeProperties: "ApplicationUser"),
                Post = _unitOfWork.Post.GetFirstOrDefault(u => u.Id == postId, includeProperties: "ApplicationUser")
            };
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


        }
    }
}
