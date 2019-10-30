using MySql.Data.MySqlClient;

namespace ConnectToMySQL
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "127.0.0.1";
            int port = 3306;
            string database = "law_system";
            string username = "root";
            string password = "";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}