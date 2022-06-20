using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UMelusiTrack.Services;

namespace UMelusiTrack.ViewModel
{
    public class UmelusiVM
    {
        static UmelusiDB database;

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
    }
}
