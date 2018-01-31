using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IBlogPostsRepo
    {
        List<BlogPost> ListAll();
        BlogPost GetPostByPermalink(string permalink);

        void Add(BlogPost newpost);
        void Edit(BlogPost newpost);
        void Delete(BlogPost newpost);
        void Details(BlogPost newpost);
        BlogPost GetById(int id);
    }
}
