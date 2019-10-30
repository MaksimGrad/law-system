using ConnectToMySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace CourseWork
{
    class DataBaseDeleteRow
    {
        public static MySqlCommand cmd = new MySqlCommand();
        public static MySqlConnection Conn = DBUtils.GetDBConnection();

        public static bool DeleteRow(string TableName, int id)
        {
            Conn.Open();
            try
            {
                String Query = "";
                if (TableName == "lawyers")
                    Query = "DELETE FROM lawyers WHERE id_lawyer = @id";
                else if (TableName == "clients")
                    Query = "DELETE FROM clients WHERE id = @id";
                else if (TableName == "causes")
                    Query = "DELETE FROM finished_causes WHERE id_cause = @id";
                else if (TableName == "success")
                    Query = "DELETE FROM success WHERE id = @id";
                else if (TableName == "fees")
                    Query = "DELETE FROM fees WHERE id = @id";
                else if (TableName == "reports")
                    Query = "DELETE FROM reports WHERE id_report = @id";
                else if (TableName == "authoriz")
                    Query = "DELETE FROM authorization WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Conn.Close();
                return false;
            }
            Conn.Close();
            return true;
        }
    }
}
