using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public void AddPost(Post post)
        {
            _blogRepository.AddPost(post);
        }

        public List<Post> GetAllPosts()
        {
            return _blogRepository.GetAllPosts();
        }

        public Post GetPost(int id)
        {
            return _blogRepository.GetPost(id);
        }

        public string ImageUpload(IFormFile file)
        {
            
            return _blogRepository.ImageUpload(file);
        }

        public void RemovePost(int id)
        {
            _blogRepository.RemovePost(id);
        }

        public void UpdatePost(Post post)
        {
            _blogRepository.UpdatePost(post);
        }
    }
}
