using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;

        [MaxLength(5000)]
        public string Body { get; set; }

        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        [ValidateNever]
        public Post Post { get; set; }

        public string? ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }


    }
      
}
