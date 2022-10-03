using Blog.DataAccess.Repository.IRepository;
using Blog.Models.Model;
using Blog.Models.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace BlogWebApp.Pages.comment
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostVM PostVM { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int? postId)
        {

            PostVM  postVM= new PostVM();  
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

        //    IEnumerable<SelectListItem> CommentList = _unitOfWork.Post.GetAll(u => u.Id == postId, includeProperties: "Comments");
             

        }
    }
}
