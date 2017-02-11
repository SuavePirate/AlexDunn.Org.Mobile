using AlexDunn.Org.Definitions.Models.Application;
using AlexDunn.Org.Definitions.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Definitions.Data.Providers
{
    public interface IPostDataProvider
    {
        Task<Result<IEnumerable<Post>>> GetPostsAsync(string url, int page);
    }
}
