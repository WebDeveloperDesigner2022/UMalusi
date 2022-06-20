using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using UMelusiTrack.Models;

namespace UMelusiTrack.Services
{
    public class UmelusiDB
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<UmelusiDB> Instance = new AsyncLazy<UmelusiDB>(async () =>
        {
            var instance = new UmelusiDB();
            CreateTableResult result = await Database.CreateTableAsync<SigningDataModel>();
            return instance;
        });

        public UmelusiDB()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<SigningDataModel>> GetItemsAsync()
        {
            return Database.Table<SigningDataModel>().ToListAsync();
        }

        public Task<List<SigningDataModel>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<SigningDataModel>("SELECT * FROM [SwagItem] WHERE [Done] = 0");
        }

        public Task<SigningDataModel> GetItemAsync(int id)
        {
            return Database.Table<SigningDataModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SigningDataModel item)
        {
            return Database.InsertAsync(item);

            /*   if (item.ID != 0)
               {
                   return Database.UpdateAsync(item);
               }
               else
               {
                   return Database.InsertAsync(item);
               }*/
        }

        public Task<int> DeleteItemAsync(SigningDataModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
