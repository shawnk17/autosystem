using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure
{
    public class BlogRepoFs : IBlogPostsRepo
    {
        private static List<BlogRepoFs> _BlogRepoFs;
        private static int _nextId = 1;
        
        private const string PATH = "data";
        private const string FILENAME = ".json";

        private readonly string _fileFullPath = Path.Combine(PATH, FILENAME);

        public BlogRepoFs()
        {
            if (_BlogRepoFs == null)
            {
                _BlogRepoFs = LoadFile();

                if (_BlogRepoFs.Count > 0)
                {
                    _nextId = _BlogRepoFs.Max(t => t.Id) + 1;
                }
            }
        }

        public void Add(BlogPost newpost)
        {
            newBlogPost.permalink = _nextId++;
            _BlogRepoFs.Add(newBlogPost);

            SaveFile();
        }

        public void Delete(BlogPost newpost)
        {
            var origTelegram = GetById(newpost.permalink);

            _BlogRepoFs.Remove(newBlogPost);

            SaveFile();
        }
        public void Edit(BlogPost newpost)
        {
            var newBlogPost = GetById(newpost.permalink);

            newBlogPost.Content = newpost.Content;
            newBlogPost.Receiver = newpost.Receiver;
            newBlogPost.Sender = newpost.Sender;
            newBlogPost.Title = newpost.Title;

            SaveFile();
        }
        public BlogPost GetPostByPermalink(string permalink)
        {
            return _BlogRepoFs.Find(t => t.permalink == permalink);
        }

        public List<BlogPost> ListAll()
        {
            return _BlogRepoFs;
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
