using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Entities
{
    public class Post
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DataConstants.PostConstrains.TitleMaxLength)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(DataConstants.PostConstrains.ContentMaxLength)]
        public string Content { get; set; } = null!;    
    }
}
