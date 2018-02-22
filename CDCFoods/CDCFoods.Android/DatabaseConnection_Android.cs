using System.IO;
using CDCFoods.Droid;
using CDCFoods.Infra;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace CDCFoods.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "CDCFoods.db3";
            string documentsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}