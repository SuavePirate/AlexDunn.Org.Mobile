using AlexDunn.Org.Definitions.Data.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexDunn.Org.Definitions.Models.Application;
using AlexDunn.Org.Definitions.Models.Data;
using System.Xml.Linq;
using AlexDunn.Org.Infrastructure.Data.Extensions;

namespace AlexDunn.Org.Infrastructure.Data.Providers
{
    public class PostDataProvider : BaseHttpProvider, IPostDataProvider
    {
        public async Task<Result<IEnumerable<Post>>> GetPostsAsync(string url, int page)
        {
            try
            {
                var fullUrl = page <= 1 ? url : $"{url}?paged={page}";
                var resultString = await GetRssXmlStringAsync(fullUrl);
                resultString = resultString.Replace(Convert.ToChar((byte)0x1F), ' ');
                var document = XDocument.Parse(resultString);
                var posts = document.ToPosts();
                return posts != null ? new Result<IEnumerable<Post>>(posts) : new Result<IEnumerable<Post>>("Unable to get posts.");
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<Post>>(ex.Message);
            }
        }
    }
}
