using ConnectToMySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace CourseWork
{
    class DataBaseCreateEditRow
    {

        public static MySqlCommand cmd = new MySqlCommand();
        public static MySqlConnection Conn = DBUtils.GetDBConnection();
        
        public static bool CreateEditLawyerRow(TableLawyers row, Boolean isCreate, int id)
        {
            Conn.Open();
            try
            {
                string Query;
                if (isCreate)
                    Query = "INSERT INTO lawyers (id_lawyer, surname, name, second_name, phone)" + "VALUES (@id_lawyer, @surname, @name, @second_name, @phone)";
                else
                    Query = "UPDATE lawyers SET id_lawyer = @id_lawyer, surname = @surname, name = @name, second_name = @second_name, phone = @phone WHERE id_lawyer = " + id;
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id_lawyer", row.ID);
                cmd.Parameters.AddWithValue("@surname", row.Surname);
                cmd.Parameters.AddWithValue("@name", row.Name);
                cmd.Parameters.AddWithValue("@second_name", row.SecondName);
                cmd.Parameters.AddWithValue("@phone", row.Phone);
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

        public static bool CreateEditClientRow(TableClients row, Boolean isCreate, int id)
        {
            Conn.Open();
            try
            {
                string Query;
                if (isCreate)
                    Query = "INSERT INTO clients (id, surname, name, second_name, phone, id_lawyer)" + "VALUES (@id_client, @surname, @name, @second_name, @phone, @id_lawyer)";
                else
                    Query = "UPDATE clients SET id = @id_client, surname = @surname, name = @name, second_name = @second_name, phone = @phone , id_lawyer = @id_lawyer WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id_client", row.ID);
                cmd.Parameters.AddWithValue("@surname", row.Surname);
                cmd.Parameters.AddWithValue("@name", row.Name);
                cmd.Parameters.AddWithValue("@second_name", row.SecondName);
                cmd.Parameters.AddWithValue("@phone", row.Phone);
                cmd.Parameters.AddWithValue("@id_lawyer", row.IDLawyer);
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

        public static bool CreateEditCauseRow(TableCauses row, Boolean isCreate, int id)
        {
            Conn.Open();
            try
            {
                string Query;
                if (isCreate)
                    Query = "INSERT INTO finished_causes (`id_cause`, `max_term`, `min_term`, `received_term`, `excuses`, `suspended_sentence`, `fines`, `date_cause`, `description`, `id_client`)" + "VALUES (@id_cause, @max_term, @min_term, @received_term, @excuses, @suspended_sentence, @fines, @date_cause, @description, @id_client)";
                else
                    Query = "UPDATE finished_causes SET id_cause = @id_cause, max_term = @max_term, min_term = @min_term, received_term = @received_term, excuses = @excuses, suspended_sentence = @suspended_sentence, fines = @fines, date_cause = @date_cause, description = @description, id_client = @id_client WHERE id_cause = " + id;
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id_cause", row.ID);
                cmd.Parameters.AddWithValue("@max_term", row.MaxTerm);
                cmd.Parameters.AddWithValue("@min_term", row.MinTerm);
                cmd.Parameters.AddWithValue("@received_term", row.ResultTerm);
                cmd.Parameters.AddWithValue("@excuses", row.Excuse);
                cmd.Parameters.AddWithValue("@suspended_sentence", row.SuspendedSentence);
                cmd.Parameters.AddWithValue("@fines", row.Fines);
                cmd.Parameters.AddWithValue("@date_cause", row.Date);
                cmd.Parameters.AddWithValue("@description", row.Description);
                cmd.Parameters.AddWithValue("@id_client", row.IDClient);
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

        public static bool CreateEditEfficiencyRow(TableEfficiency row, Boolean isCreate, int id)
        {
            Conn.Open();
            try
            {
                string Query;
                if (isCreate)
                    Query = "INSERT INTO success (`id`, `efficiency`, `inefficiency`, `id_cause`)" + "VALUES (@id, @efficiency, @inefficiency, @id_cause)";
                else
                    Query = "UPDATE success SET id = @id, efficiency = @efficiency, inefficiency = @inefficiency, id_cause = @id_cause WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", row.ID);
                cmd.Parameters.AddWithValue("@efficiency", row.Efficiency);
                cmd.Parameters.AddWithValue("@inefficiency", row.Inefficiency);
                cmd.Parameters.AddWithValue("@id_cause", row.IDCase);
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

        public static bool CreateEditFeesRow(TableFees row, Boolean isCreate, int id)
        {
            Conn.Open();
            try
            {
                string Query;
                if (isCreate)
                    Query = "INSERT INTO fees (`id`, `sum`, `id_lawyer`, `id_cause`)" + "VALUES (@id, @sum, @id_lawyer, @id_cause)";
                else
                    Query = "UPDATE fees SET id = @id, sum = @sum, id_lawyer = @id_lawyer, id_cause = @id_cause WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", row.ID);
                cmd.Parameters.AddWithValue("@sum", row.SumFee);
                cmd.Parameters.AddWithValue("@id_lawyer", row.IDLawyer);
                cmd.Parameters.AddWithValue("@id_cause", row.IDCause);
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

        public static bool CreateEditReportsRow(TableReports row, Boolean isCreate, int id)
        {
            Conn.Open();
            try
            {
                string Query;
                if (isCreate)
                    Query = "INSERT INTO reports (`id_report`, `description`, `year`, `id_lawyer`)" + "VALUES (@id, @description, @year, @id_lawyer)";
                else
                    Query = "UPDATE reports SET id_report = @id, description = @description, year = @year, id_lawyer = @id_lawyer WHERE id_report = " + id;
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", row.ID);
                cmd.Parameters.AddWithValue("@description", row.Description);
                cmd.Parameters.AddWithValue("@year", row.Year);
                cmd.Parameters.AddWithValue("@id_lawyer", row.IDLawyer);
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

        public static bool CreateEditAuthorizRow(TableAuthorization row, Boolean isCreate, int id)
        {
            Conn.Open();
            try
            {
                string Query;
                if (isCreate)
                    Query = "INSERT INTO authorization (`id`, `login`, `password`, `id_lawyer`)" + "VALUES (@id, @login, @password, @id_lawyer)";
                else
                    Query = "UPDATE authorization SET id = @id, login = @login, password = @password, id_lawyer = @id_lawyer WHERE id = " + id;
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", row.ID);
                cmd.Parameters.AddWithValue("@login", row.Login);
                cmd.Parameters.AddWithValue("@password", row.Password);
                cmd.Parameters.AddWithValue("@id_lawyer", row.IDLawyer);
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
