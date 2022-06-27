using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Models;


namespace UMelusiTrack.Services
{
    public class livestockDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<livestockDatabase> Instance = new AsyncLazy<livestockDatabase>(async () =>
        {
            var instance = new livestockDatabase();
            CreateTableResult result = await Database.CreateTableAsync<livestock>();
            return instance;
        });

        public livestockDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<livestock>> GetItemsAsync()
        {
            return Database.Table<livestock>().ToListAsync();
        }

        public Task<List<livestock>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<livestock>("SELECT * FROM [livestock]");
        }

        public Task<livestock> GetItemAsync(int id)
        {
            return Database.Table<livestock>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(livestock item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(livestock item)
        {
            return Database.DeleteAsync(item);
        }
    }
}

