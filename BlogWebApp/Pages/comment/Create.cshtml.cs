using Blog.DataAccess.Repository.IRepository;
using Blog.Models.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendGrid;
using System.Security.Claims;

namespace BlogWebApp.Pages.comment
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Comment Comment { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int? postId)
        {
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                Comment.ApplicationUserId =  claim.Value;

                Comment.PostId = postId;
  

                _unitOfWork.Comment.Add(Comment);

                _unitOfWork.Save();
                TempData["success"] = "Comment created successfully";
                return RedirectToPage("/home/Index");
            }
            return RedirectToPage("/home/Index");   //stay in the same pag
        }
    }
}