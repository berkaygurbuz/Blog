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

        public bool CanGoNext(int pageNumber,string category)
        {
            return _blogRepository.CanGoNext(pageNumber,category);
        }

        public List<Post> GetAllPosts()
        {
            return _blogRepository.GetAllPosts();
        }

        public List<Post> GetAllPosts(string category)
        {
            return _blogRepository.GetAllPosts(category);
        }

        public List<Post> GetAllPosts(int pageNumber,string category)
        {
            return _blogRepository.GetAllPosts(pageNumber,category);
        }


        public Post GetPost(int id)
        {
            return _blogRepository.GetPost(id);
        }

        public string ImageUpload(IFormFile file)
        {
            
            return _blogRepository.ImageUpload(file);
        }

        public void RemoveImage(string image)
        {
            _blogRepository.RemoveImage(image);
        }

        public void RemovePost(int id)
        {
            _blogRepository.RemovePost(id);
        }

        public List<Post> Search(string search,int pageNumber)
        {
            return _blogRepository.Search(search,pageNumber);
        }

        public void UpdatePost(Post post)
        {
            _blogRepository.UpdatePost(post);
        }
    }
}
