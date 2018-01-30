using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class BlogRepoMemory : IBlogPostsRepo
    {
        private static List<BlogPost> _BlogPost;
        private static int _nextId = 1;
        private int id;

        public BlogRepoMemory()
        {
            if (_BlogPost == null)
            {
                _BlogPost = new List<BlogPost>();
            }
        }

        public void Add(BlogPost newBlogPost)
        {
            newBlogPost.Id = _nextId++;
            _BlogPost.Add(newBlogPost);
        }

        public void Delete(BlogPost newpostDelete)
        {
            var origBlogPost = GetById(newpostDelete.Id);

            _BlogPost.Remove(origBlogPost);
        }

        public void Edit(BlogPost newpost)
        {
            var origTelegram = GetById(newpost.Id);

            origBlogPost.Content = newpost.Content;
            origBlogPost.Receiver = newpost.Receiver;
            origBlogPost.Sender = newpost.Sender;
            origBlogPost.Title = newpost.Title;
        }

        public BlogPost GetPostByPermalink(string permalink)
        {
            return _BlogPost.Find(t => t.Id == id);
        }

        public List<BlogPost> ListAll()
        {
            return _BlogPost;
        }

        //public void Add(BlogPost newpost)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(BlogPost newpost)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Edit(BlogPost newpost)
        //{
        //    throw new NotImplementedException();
        //}

        //public BlogPost GetPostByPermalink(string permalink)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<BlogPost> ListAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
