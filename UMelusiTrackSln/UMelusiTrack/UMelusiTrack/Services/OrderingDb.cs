using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Models;

namespace UMelusiTrack.Services
{
    public class OrderingDb
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<OrderingDb> Instance = new AsyncLazy<OrderingDb>(async () =>
        {
            var instance = new OrderingDb();
            CreateTableResult result = await Database.CreateTableAsync<OrderingModels>();
            return instance;
        });

        public OrderingDb()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<OrderingModels>> GetItemsAsync()
        {
            return Database.Table<OrderingModels>().ToListAsync();
        }

        public Task<List<OrderingModels>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<OrderingModels>("SELECT * FROM [livestock]");
        }

        public Task<OrderingModels> GetItemAsync(int id)
        {
            return Database.Table<OrderingModels>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(OrderingModels item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(OrderingModels item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
