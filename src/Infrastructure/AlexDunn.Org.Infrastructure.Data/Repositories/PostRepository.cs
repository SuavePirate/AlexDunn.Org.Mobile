using AlexDunn.Org.Definitions.Data.Repositories;
using AlexDunn.Org.Definitions.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Infrastructure.Data.Repositories
{
    public class PostRepository : GenericSqliteRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {
        }
    }
}
