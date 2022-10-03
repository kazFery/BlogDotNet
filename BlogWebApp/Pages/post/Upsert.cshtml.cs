using Blog.DataAccess.Repository;
using Blog.DataAccess.Repository.IRepository;
using Blog.Models.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using SendGrid;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlogWebApp.Pages.post
{
    public class UpsertModel : PageModel
    {  
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public Post Post { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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

       

        public IActionResult OnPost(IFormFile? file)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //????? why it is invalid
            //if (ModelState.IsValid)
            {
                if (file != null)
                {
                    Post post = new();
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    var uploads = Path.Combine(wwwRootPath, @"images\posts");
                    var extension = Path.GetExtension(file.FileName);
                    string fileName = Guid.NewGuid().ToString();
                    if (post.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath,post.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }


                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    Post.ImageUrl = @"\images\posts\" + fileName + extension;
                   
                    Post.ApplicationUserId = claim.Value;

                    _unitOfWork.Post.Add(Post);
                    _unitOfWork.Save();
                    TempData["success"] = "Post created successfully";
                }
               
            }

            return RedirectToPage("Index");
        }
    }
}
