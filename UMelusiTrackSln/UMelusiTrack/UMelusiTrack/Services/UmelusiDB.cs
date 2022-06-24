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

             Database.CreateTableAsync<SigningDataModel>().Wait();
        }

        public Task<List<SigningDataModel>> GetItemsAsync()
        {
            return Database.Table<SigningDataModel>().ToListAsync();
        }

        public Task<List<SigningDataModel>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<SigningDataModel>("SELECT * FROM [SigningDataModel] WHERE [Done] = 0");
        }

        public Task<SigningDataModel> GetItemAsync(int id)
        {
            return Database.Table<SigningDataModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SigningDataModel item)
        {
            //return Database.InsertAsync(item);

               if (item.Id != 0)
               {
                   return Database.UpdateAsync(item);
               }
              
               return Database.InsertAsync(item);
             
        }

        public Task<int> DeleteItemAsync(SigningDataModel item)
        {
            return Database.DeleteAsync(item);
        }

        public async Task<bool> Login(string userName, string password)
        {
            var user = await Database.Table<SigningDataModel>().Where(x => x.Username == userName).FirstOrDefaultAsync();

            if (user != null)
            {
                if (password == user.Password)
                    return true;
            }

            return false;
        }
    }
}
