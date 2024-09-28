using System.Data.SQLite;

namespace ProducaoMel.DALL
{
    public class DALProducaoMel
    {
        private static SQLiteConnection sQLiteConnection;

        public static string path = "C:\\Users\\João Mazzoni\\source\\repos\\ProducaoMel\\DBProducao";
        
        public SQLiteConnection DbConnection()
        {
            sQLiteConnection = new SQLiteConnection("Data Source=" + path);
            sQLiteConnection.Open();
            return sQLiteConnection;
        }

    }
}
