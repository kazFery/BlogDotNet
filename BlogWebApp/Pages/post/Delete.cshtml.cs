using Blog.DataAccess.Repository.IRepository;
using Blog.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogWebApp.Pages.post
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public Post Post { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public void OnGet(int? id)
        {
            var data = Request.Query["id"];

            if (id == null || id == 0)
            {
                Post = new();
            }
            else
            {
                Post = _unitOfWork.Post.GetFirstOrDefault(x => x.Id == id);
            }

            // return Page();
        }

        public IActionResult OnPost()
        {
            var post = _unitOfWork.Post.GetFirstOrDefault(type => type.Id == Post.Id,includeProperties:"Comments");
            foreach (var item in post.Comments)
            {
                _unitOfWork.Comment.Remove(item);
            }
            _unitOfWork.Post.Remove(post);
            _unitOfWork.Save();
            TempData["delete"] = "Post deleted successfully";
            return RedirectToPage("Index");

        }
    }

}
