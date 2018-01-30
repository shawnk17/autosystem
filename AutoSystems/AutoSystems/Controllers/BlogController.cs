using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace AutoSystems.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostsRepo _blogPostRepo;

        public BlogController(IBlogPostsRepo blogPostsRepo)
        {
            _blogPostRepo = blogPostsRepo;
        }
        // GET: Blog
        public ActionResult Index()
        {
            return View(_blogPostRepo.ListAll());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View(_blogPostRepo.GetById(id));
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View(new BlogPost
            {
                PubDate = DateTime.Now
            });
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogPost newBlogPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _blogPostRepo.Add(newBlogPost);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
            return View(newBlogPost);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_blogPostRepo.GetById(id));
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BlogPost editedBlogPost)
        {
            try
            {
                _blogPostRepo.Edit(editedBlogPost);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // TODO Log the exception
            }
            return View(editedBlogPost);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_blogPostRepo.GetById(id));
        }

        // POST: Blog/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BlogPost blogPostDelete)
        {
            try
            {
                _blogPostRepo.Delete(blogPostDelete);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // TODO Log the exception
            }
            return View(blogPostDelete);
        }
    }
}