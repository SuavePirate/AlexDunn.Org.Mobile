using AlexDunn.Org.Definitions.Data.Providers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Infrastructure.Data
{
    public class DbContext
    {
        private readonly IFilePathProvider _filePathProvider;
        public SQLiteAsyncConnection Database { get; }
        

        /// <summary>
        /// Initialized a new DbContext
        /// </summary>
        /// <param name="filePathProvider"></param>
        public DbContext(IFilePathProvider filePathProvider)
        {
            _filePathProvider = filePathProvider;
            Database = new SQLiteAsyncConnection(_filePathProvider.GetLocalFilePath("localdb.db3"));
        }

        /// <summary>
        /// Creates a table for a given type in sql lite
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<CreateTablesResult> CreateTableAsync<T>() where T : new()
        {
            return await Database.CreateTableAsync<T>();
        }

        /// <summary>
        /// Gets a table by it's type from the db.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public AsyncTableQuery<T> Set<T>() where T : new()
        {
            return Database.Table<T>();
        }
    }
}
