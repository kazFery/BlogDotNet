using Blog.DataAccess.Repository.IRepository;
using Blog.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace BlogWebApp.Pages.comment
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty(SupportsGet = true)]
        public Comment Comment { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
  
        }
        public void OnGet(int? id)
        {
           
           Comment = _unitOfWork.Comment.GetFirstOrDefault(x => x.Id == id, includeProperties: "Post,ApplicationUser");
            
        }

        public IActionResult OnPost()
        {
            var comment = _unitOfWork.Comment.GetFirstOrDefault(t => t.Id == Comment.Id);
            _unitOfWork.Comment.Remove(comment);
            _unitOfWork.Save();
            TempData["delete"] = "Comment deleted successfully";
            return RedirectToPage("/post/Index");

        }
    }
}
