using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure
{
    public class BlogRepoFs : IBlogPostsRepo
    {
        public void Add(BlogPost newpost)
        {
            throw new NotImplementedException();
        }

        public void Delete(BlogPost newpost)
        {
            throw new NotImplementedException();
        }

        public void Edit(BlogPost newpost)
        {
            throw new NotImplementedException();
        }

        public BlogPost GetPostByPermalink(string permalink)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
