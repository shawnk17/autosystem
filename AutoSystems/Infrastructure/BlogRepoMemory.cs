using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class BlogRepoMemory : IBlogPostsRepo
    {
        private static List<BlogPost> _blogPost;
        private static int _nextId = 1;
        
        public BlogRepoMemory()
        {
            if (_blogPost == null)
            {
                _blogPost = new List<BlogPost>();
            }
        }

        public void Add(BlogPost newBlogPost)
        {
            newBlogPost.Id = _nextId++;
            _blogPost.Add(newBlogPost);
        }

        public void Delete(BlogPost newPostDelete)
        {
            var origBlogPost = GetById(newPostDelete.Id);

            _blogPost.Remove(origBlogPost);
        }

        public void Edit(BlogPost newpost)
        {
            var newBlogPost = GetById(newpost.Id);

            newBlogPost.Permalink = newpost.Permalink;
            newBlogPost.PhotoUrl = newpost.PhotoUrl;
            newBlogPost.PostContent = newpost.PostContent;
            newBlogPost.Title = newpost.Title;
            newBlogPost.Author = newpost.Author;
        }

        public BlogPost GetById(int id)
        {
            return _blogPost.Find(t => t.Id == id);
        }

        public BlogPost GetPostByPermalink(string permalink)
        {
            return _blogPost.Find(t => t.Permalink == permalink);
        }

        public List<BlogPost> ListAll()
        {
            return _blogPost;
        }
    }
}
