using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class BlogRepoFs : IBlogPostsRepo
    {
        private static List<BlogPost> _BlogRepoFs;
        private static int _nextId = 1;

        private const string PATH = "data";
        private const string FILENAME = "Blog.json";

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
            newpost.Id = _nextId++;
            _BlogRepoFs.Add(newpost);

            SaveFile();
        }



        public void Delete(BlogPost newpost)
        {
            var origBlogPost = GetById(newpost.Id);

            _BlogRepoFs.Remove(origBlogPost);

            SaveFile();
        }
        public void Edit(BlogPost newpost)
        {
            var newBlogPost = GetById(newpost.Id);

            newBlogPost.Permalink = newpost.Permalink;
            newBlogPost.PhotoUrl = newpost.PhotoUrl;
            newBlogPost.PostContent = newpost.PostContent;
            newBlogPost.Title = newpost.Title;
            newBlogPost.Author = newpost.Author;

            SaveFile();
        }
        public BlogPost GetPostByPermalink(string permalink)
        {
            return _BlogRepoFs.Find(t => t.Permalink == permalink);
        }

        public List<BlogPost> ListAll()
        {
            return _BlogRepoFs;
        }

        public BlogPost GetById(int id)
        {
            return _BlogRepoFs.Find(t => t.Id == id);
        }

        private List<BlogPost> LoadFile()
        {
            try
            {
                string rawList = File.ReadAllText(_fileFullPath);

                return JsonConvert.DeserializeObject<List<BlogPost>>(rawList);
            }
            catch (Exception)
            {
               // TODO Log the exception 
            }
            return new List<BlogPost>();
        }

        private void SaveFile()
        {
            try
            {
                if (!Directory.Exists(PATH))
                {
                    Directory.CreateDirectory(PATH);
                }
                string rawListStr = JsonConvert.SerializeObject(_BlogRepoFs);

                File.WriteAllText(_fileFullPath, rawListStr);

            }
            catch (Exception)
            {

                
            }
        }
    }
}
