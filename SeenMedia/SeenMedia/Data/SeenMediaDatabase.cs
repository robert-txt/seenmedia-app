using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SeenMedia.Model;

namespace SeenMedia.Data
{
    public class SeenMediaDatabase
    {

        readonly SQLiteAsyncConnection database;

        public SeenMediaDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<SeenMediaEntry>().Wait();
        }

        public Task<List<SeenMediaEntry>> GetItemsAsync()
        {
            return database.Table<SeenMediaEntry>().ToListAsync();
        }

        /*public Task<int> CountBooksAsync()
        {
            return database.QueryAsync<SeenMediaEntry>("SELECT [Media] COUNT FROM [SeenMediaEntry] WHERE [Media] = 'Książka'");
        }*/

        public Task<int> CountItemAsync(string column)
        {
            return database.Table<SeenMediaEntry>().Where(i => i.Media == column).CountAsync();
        }

        public Task<int> SaveItemAsync(SeenMediaEntry item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(SeenMediaEntry item)
        {
            return database.DeleteAsync(item);
        }
    }
}
