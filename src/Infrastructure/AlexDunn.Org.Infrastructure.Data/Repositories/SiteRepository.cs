using AlexDunn.Org.Definitions.Data.Repositories;
using AlexDunn.Org.Definitions.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Infrastructure.Data.Repositories
{
    public class SiteRepository : GenericSqliteRepository<Site>, ISiteRepository
    {
        public SiteRepository(DbContext context) : base(context)
        {
        }

        public async Task<Site> GetSiteDataAsync()
        {
            return await _context.Set<Site>().FirstOrDefaultAsync();
        }
    }
}
