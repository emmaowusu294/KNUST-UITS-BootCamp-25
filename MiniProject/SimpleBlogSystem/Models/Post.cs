using SimpleBlogSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlogSystem.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        // --- Foreign Key for the User (Author) ---
        [Required]
        public required string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        // 'required' was removed from here
        public virtual ApplicationUser Author { get; set; }

        // --- Navigation Property for Comments ---
        // A Post can have many Comments
        // 'required' was removed and the collection is initialized
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}