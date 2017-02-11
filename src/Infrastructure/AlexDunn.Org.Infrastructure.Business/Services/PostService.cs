using AlexDunn.Org.Definitions.Business.Services;
using AlexDunn.Org.Definitions.Data.Providers;
using AlexDunn.Org.Definitions.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexDunn.Org.Definitions.Models.Application;
using AlexDunn.Org.Definitions.Models.Data;
using AlexDunn.Org.Definitions.Models.Constants;

namespace AlexDunn.Org.Infrastructure.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostDataProvider _postDataProvider;
        public PostService(IPostRepository postRepository, IPostDataProvider postDataProvider)
        {
            _postRepository = postRepository;
            _postDataProvider = postDataProvider;
        }

        public async Task<Result<IEnumerable<Post>>> GetPostsAsync(int skip)
        {
            var localPosts = await _postRepository.GetAsync(skip, 20);
            if(localPosts == null || !localPosts.Any())
            {
                return await RefreshPostsAsync();
            }
            return new Result<IEnumerable<Post>>(localPosts);
        }

        public async Task<Result<IEnumerable<Post>>> RefreshPostsAsync()
        {
            var remotePostsResult = await _postDataProvider.GetPostsAsync(Urls.FEED, 1);
            if (remotePostsResult?.Type == ResultType.Ok)
            {
                await _postRepository.AddRangeAsync(remotePostsResult.Data);
                return new Result<IEnumerable<Post>>(remotePostsResult.Data);
            }
            return new Result<IEnumerable<Post>>("Unable to get posts. Try again later.");

        }
    }
}
