using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities
{
    public class Post
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CurrentImage { get; set; } = "";
        public string Image { get; set; } = "";
        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Category { get; set; } = "";


    }
}
