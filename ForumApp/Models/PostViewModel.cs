using ForumApp.Data;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models
{
    public class PostViewModel
    {
        public int Id { get; init; }

        [Required]
        [StringLength(DataConstants.PostConstrains.TitleMaxLength, MinimumLength = DataConstants.PostConstrains.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.PostConstrains.ContentMaxLength, MinimumLength = DataConstants.PostConstrains.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
