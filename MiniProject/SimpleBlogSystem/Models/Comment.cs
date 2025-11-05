using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleBlogSystem.Data;

namespace SimpleBlogSystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Content { get; set; }

        public DateTime CommentDate { get; set; }

        // --- Foreign Key for the Post ---
        [Required]
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        // 'required' was removed from here
        public virtual Post Post { get; set; }

        // --- Foreign Key for the User (Author) ---
        [Required]
        // 'required' was removed from here
        public required string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        // 'required' was removed from here
        public virtual ApplicationUser Author { get; set; }
    }
}