using Blog.Entities;
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
        Post GetPost(int id);
        void AddPost(Post post);
        void RemovePost(int id);
        void UpdatePost(Post post);

    }
}
