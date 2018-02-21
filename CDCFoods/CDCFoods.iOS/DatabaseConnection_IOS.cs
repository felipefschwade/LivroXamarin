using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CDCFoods.Infra;
using CDCFoods.iOS;
using Foundation;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_IOS))]
namespace CDCFoods.iOS
{
    class DatabaseConnection_IOS : IDatabaseConnection
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "CDCFoods.db3";
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            var platform = new SQLitePlatformIOS();
            return new SQLiteConnection(platform, path);
        }
    }
}