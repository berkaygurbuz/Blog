using Blog.DataAccess.Abstract;
using Blog.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete
{
    public class BlogRepository : IBlogRepository
    {

        public void AddPost(Post post)
        {
            using (var blogDbContext = new BlogDbContext())
            {
                
                blogDbContext.Posts.Add(post);
                blogDbContext.SaveChanges();
            }
        }

        public List<Post> GetAllPosts()
        {
            using (var blogDbContext = new BlogDbContext())
            {
                var posts = blogDbContext.Posts.ToList();
                return posts;
            }
        }

        public Post GetPost(int id)
        {
            using (var blogDbContext = new BlogDbContext())
            {
                var post = blogDbContext.Posts.FirstOrDefault(x => x.Id == id);
                return post;
            }
        }

        public string ImageUpload(IFormFile file)
        {
            using (var blogDbContext=new BlogDbContext())
            {
                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + imageExtension;
                string path = $"wwwroot/content/{imageName}";
                using var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                return path;
            }
        }

        public void RemovePost(int id)
        {
            using (var blogDbContext = new BlogDbContext())
            {
                blogDbContext.Posts.Remove(GetPost(id));
                blogDbContext.SaveChanges();
            }
        }

        public void UpdatePost(Post post)
        {
            using (var blogDbContext = new BlogDbContext())
            {


                blogDbContext.Posts.Update(post);
                blogDbContext.SaveChanges();

            }
        }
    }
}
