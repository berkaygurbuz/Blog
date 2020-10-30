using Blog.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
    public interface IBlogService
    {
        List<Post> GetAllPosts(string category);
        List<Post> GetAllPosts();
        List<Post> GetAllPosts(int pageNumber,string category);
        List<Post> Search(string search,int pageNumber);
        bool CanGoNext(int pageNumber,string category);
        Post GetPost(int id);
        void AddPost(Post post);
        void RemovePost(int id);
        void UpdatePost(Post post);
        string ImageUpload(IFormFile file);
        void RemoveImage(string image);
    }
}
