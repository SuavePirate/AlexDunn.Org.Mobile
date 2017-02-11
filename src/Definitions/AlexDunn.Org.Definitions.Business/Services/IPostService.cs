using AlexDunn.Org.Definitions.Models.Application;
using AlexDunn.Org.Definitions.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Definitions.Business.Services
{
    public interface IPostService
    {
        Task<Result<IEnumerable<Post>>> GetPostsAsync(int skip);
        Task<Result<IEnumerable<Post>>> RefreshPostsAsync();
    }
}
