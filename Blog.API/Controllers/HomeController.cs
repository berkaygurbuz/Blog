﻿using Blog.Business.Abstract;
using Blog.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        public IActionResult Index(string category)
        {
            var post = string.IsNullOrEmpty(category) ? _blogService.GetAllPosts() : _blogService.GetAllPosts(category);
            return View(post);
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
        public IActionResult Edit(Post post, IFormFile file)
        {
            //if Id bigger than 0 it means it created before so we update data.
            if (post.Id > 0)
            {
                if (file != null)
                {
                    //take the Image path
                    string path = _blogService.ImageUpload(file);
                    post.Image = path;
                    post.CurrentImage = path;
                    _blogService.UpdatePost(post);
                }
                //there is no Image just update title and body.
                else
                {
                    post.Image = post.CurrentImage;
                    _blogService.UpdatePost(post);
                }

            }
            else
            {
                string path = _blogService.ImageUpload(file);
                post.CurrentImage = path;
                post.Image = path;
                _blogService.AddPost(post);
            }

            return RedirectToAction("Index");
        }

    }
}
