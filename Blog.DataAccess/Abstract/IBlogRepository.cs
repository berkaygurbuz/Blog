using Blog.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Abstract
{
    public interface IBlogRepository
    {
        List<Post> GetAllPosts();
        List<Post> GetAllPosts(string category);
        Post GetPost(int id);
        void AddPost(Post post);
        void RemovePost(int id);
        void UpdatePost(Post post);
        string ImageUpload(IFormFile file); 
        void RemoveImage(string image); 

    }
}
