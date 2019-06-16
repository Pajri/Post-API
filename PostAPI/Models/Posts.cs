using System;
using System.Collections.Generic;

namespace PostAPI.Models
{
    public partial class Posts
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
