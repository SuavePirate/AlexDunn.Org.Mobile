using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Definitions.Data.Providers
{
    public interface IFilePathProvider
    {
        string GetLocalFilePath(string fileName);
    }
}
