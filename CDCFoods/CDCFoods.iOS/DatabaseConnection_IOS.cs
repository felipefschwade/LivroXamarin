using System;
using System.IO;
using CDCFoods.Infra;
using CDCFoods.iOS;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_IOS))]
namespace CDCFoods.iOS
{
    public class DatabaseConnection_IOS : IDatabaseConnection
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "CDCFoods.db3";
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}