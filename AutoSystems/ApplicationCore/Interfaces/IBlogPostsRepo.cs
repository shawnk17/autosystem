using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
   public interface IBlogPostsRepo
    {
        List<BlogPost> ListAll();
    }
}
