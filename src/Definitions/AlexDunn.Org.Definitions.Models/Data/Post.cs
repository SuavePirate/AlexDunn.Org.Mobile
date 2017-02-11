using System;
using System.Collections.Generic;

namespace AlexDunn.Org.Definitions.Models.Data
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFavorited { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
