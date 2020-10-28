using Blog.DataAccess.Abstract;
using Blog.Entities;
using Microsoft.AspNetCore.Http;
using PhotoSauce.MagicScaler;
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
        private string path;

        public void AddPost(Post post)
        {
            using (var blogDbContext = new BlogDbContext())
            {
                
                blogDbContext.Posts.Add(post);
                blogDbContext.SaveChanges();
            }
        }

        public List<Post> GetAllPosts(string category)
        {
            using (var blogDbContext = new BlogDbContext())
            {

                var posts = blogDbContext.Posts.Where(x=>x.Category.ToLower().Equals(category.ToLower()))
                    .ToList();
                return posts;
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
        //settings for ImageScaler nuGet package.
        private ProcessImageSettings ImageOptions() => new ProcessImageSettings()
        {
            Width = 800,
            Height = 500,
            ResizeMode = CropScaleMode.Crop,
            SaveFormat = FileFormat.Jpeg,
            JpegQuality = 100,
            JpegSubsampleMode = ChromaSubsampleMode.Subsample420
        };

        public string ImageUpload(IFormFile file)
        {
            using (var blogDbContext=new BlogDbContext())
            {
                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + imageExtension;
                string path = $"wwwroot/content/{imageName}";
                using var stream = new FileStream(path, FileMode.Create);
                //It is for resize images with nuGet package which is ImageScaler dont forget to add
                MagicImageProcessor.ProcessImage(file.OpenReadStream(), stream, ImageOptions());
                //file.CopyTo(stream);
                return path;
            }
        }

        public void RemoveImage(string image)
        {
            using (var blogDbContext=new BlogDbContext())
            {
                var file = image;
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                
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
