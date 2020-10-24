using Blog.DataAccess.Abstract;
using Blog.Entities;
using System;
using System.Collections.Generic;
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
