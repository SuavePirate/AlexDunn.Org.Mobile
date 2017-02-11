using AlexDunn.Org.Definitions.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Definitions.Data.Repositories
{
    public interface ISiteRepository : IGenericRepository<Site>
    {
        Task<Site> GetSiteDataAsync();
    }
}
