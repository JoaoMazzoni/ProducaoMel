using Microsoft.Data.Sqlite;


namespace ProducaoMel.DALL
{
    public class DALProducaoMel
    {
        private static SqliteConnection sQLiteConnection;

        public static string path = Directory.GetCurrentDirectory() + "\\ProducaoMel.db";
        
        public SqliteConnection DbConnection()
        {
            sQLiteConnection = new SqliteConnection("Data Source=" + path);
            sQLiteConnection.Open();
            return sQLiteConnection;
        }

    }
}
