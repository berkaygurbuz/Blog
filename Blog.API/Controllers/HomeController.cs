using Blog.Business.Abstract;
using Blog.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    public class HomeController : Controller
    {
        private IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var post = _blogService.GetAllPosts();
            if (post == null)
            {
                return View();
            }
            else
            {
                return View(post);
            }

        }

        public IActionResult Post(int id)
        {
            var post = _blogService.GetPost(id);
            return View(post);
        }
        public IActionResult Remove(int id)
        {
            _blogService.RemovePost(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new Post());
            }
            else
            {

                var post = _blogService.GetPost((int)id);
                return View(post);
            }

        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            if (post.Id > 0)
            {
                _blogService.UpdatePost(post);
            }
            else
            {
                _blogService.AddPost(post);
            }

            return RedirectToAction("Index");
        }

    }
}
