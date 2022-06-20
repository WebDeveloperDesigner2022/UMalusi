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
        readonly SQLiteAsyncConnection database;

        public UmelusiDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<SigningDataModel>().Wait();
        }

        public Task<List<SigningDataModel>> GetSigningDataAsync()
        {
            //Get all notes.
            return database.Table<SigningDataModel>().ToListAsync();
        }

        public Task<SigningDataModel> GetSigningDatumAsync(int id)
        {
            // Get a specific note.
            return database.Table<SigningDataModel>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveSigningDatumAsync(SigningDataModel data)
        {
            if (data.Id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(data);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(data);
            }
        }

        public Task<int> DeleteSigningDatumAsync(SigningDataModel data)
        {
            // Delete a note.
            return database.DeleteAsync(data);
        }
    }
}
