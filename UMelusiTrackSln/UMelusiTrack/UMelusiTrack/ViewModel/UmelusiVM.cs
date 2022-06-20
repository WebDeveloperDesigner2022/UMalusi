using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UMelusiTrack.Models;
using UMelusiTrack.Models.Services;
using UMelusiTrack.Services;

namespace UMelusiTrack.ViewModel
{
    public class UmelusiVM
    {
        
        public Task APIAsync()
        {
            return Task.CompletedTask;
        }
    }    
}
  //static UmelusiDB database;

        // Create the database connection as a singleton.
        /* public static UmelusiDB Database
         {
             get
             {
                 if (database == null)
                 {
                     database = new UmelusiDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LoginDetails.db3"));
                 }
                 return database;
             }
         }*/
        /*
        var data = (SigningDataModel)BindingContext;
        UmelusiDB database = await UmelusiDB.Instance;
        await database.SaveItemAsync(data);
        await Navigation.PopAsync();
        */