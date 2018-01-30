using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
   public class BlogPost
    {
        public int Id { get; set; }
        public String Permalink { get; set; }
        [StringLength(255)]
        public String Title { get; set; }
        [Display(Name = "Post Content")]
        public String PostContent { get; set; }
        public String Author { get; set; }
        [Display(Name ="Publish Date")]
        public DateTime PubDate { get; set; }
        [Display(Name = "Photo Url")]
        public String PhotoUrl { get; set; }
    }
}
