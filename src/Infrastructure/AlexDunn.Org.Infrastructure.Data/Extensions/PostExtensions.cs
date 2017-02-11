using AlexDunn.Org.Definitions.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlexDunn.Org.Infrastructure.Data.Extensions
{
    /// <summary>
    /// Extension methods for posts
    /// </summary>
    public static class PostExtensions
    {
        public static IEnumerable<Post> ToPosts(this System.Xml.Linq.XDocument document)
        {
            XNamespace content = "http://purl.org/rss/1.0/modules/content/";
            var blogItems = new List<Post>();
            if (!document.Root.IsEmpty)
            {
                var parsedBlogs = document.Descendants("item")
                    .Select(rssItem => new Post()
                    {
                        Title = rssItem.Element("title")?.Value,
                        Link = rssItem.Element("link")?.Value,
                        PublishedDate = DateTime.Parse(rssItem.Element("pubDate")?.Value),
                        Categories = rssItem.Elements("category").Any()
                                                    ? rssItem.Elements("category")?.Select(c => c?.Value)
                                                    : new List<string>(),
                        Content = rssItem.Element("content")?.Value ?? rssItem.Element(content + "encoded")?.Value,
                        Description = rssItem.Element("description")?.Value?.StripTags(true).Take(150, true)
                    })
                    .ToList();
                blogItems.AddRange(parsedBlogs);
            }

            return blogItems;
        }
    }
}
