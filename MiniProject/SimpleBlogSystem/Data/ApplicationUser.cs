using Microsoft.AspNetCore.Identity;
using SimpleBlogSystem.Models;
using System.Collections.Generic;

namespace SimpleBlogSystem.Data
{
    public class ApplicationUser : IdentityUser
    {
        // ADDING these two collections links the user to their posts/comments

        // Initialized the collections to prevent null reference errors
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}