using ConnectToMySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace CourseWork
{
    class DataBaseSearchRows
    {

        public static ObservableCollection<TableAuthorization> searchAuthor = new ObservableCollection<TableAuthorization>();
        public static ObservableCollection<TableLawyers> searchLawyers = new ObservableCollection<TableLawyers>();
        public static ObservableCollection<TableClients> searchClients = new ObservableCollection<TableClients>();
        public static ObservableCollection<TableCauses> searchCauses = new ObservableCollection<TableCauses>();
        public static ObservableCollection<TableEfficiency> searchEfficiency = new ObservableCollection<TableEfficiency>();
        public static ObservableCollection<TableFees> searchFees = new ObservableCollection<TableFees>();
        public static ObservableCollection<TableReports> searchReports = new ObservableCollection<TableReports>();

        public static MySqlCommand cmd = new MySqlCommand();
        public static MySqlConnection Conn = DBUtils.GetDBConnection();

        public static bool SearchLawyers(String Id, String Surname, String Name, String Secondname, String Phone)
        {
            try
            {
                searchLawyers.Clear();
                Conn.Open();
                string Query = "SELECT * FROM lawyers WHERE id_lawyer IS NOT NULL";
                if (Id != "")
                    Query += " AND id_lawyer = @id_lawyer";
                if(Surname != "")
                    Query += " AND surname = @surname";
                if (Name != "")
                    Query += " AND name = @name";
                if (Secondname != "")
                    Query += " AND second_name = @second_name";
                if (Phone != "")
                    Query += " AND phone = @phone";
                if(Query == "SELECT * FROM lawyers WHERE id_lawyer IS NOT NULL")
                {
                    Conn.Close();
                    return false;
                }
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id_lawyer", Id);
                cmd.Parameters.AddWithValue("@surname", Surname);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@second_name", Secondname);
                cmd.Parameters.AddWithValue("@phone", Phone);
                cmd.ExecuteNonQuery();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetValue(0));
                            string surname = reader.GetString(1);
                            string name = reader.GetString(2);
                            string secondname = reader.GetString(3);
                            string phone = reader.GetString(4);
                            searchLawyers.Add(new TableLawyers(id, surname, name, secondname, phone));
                        }
                    }
                }
                Conn.Close();
            }
            catch
            {
                Conn.Close();
                return false;
            }
            return true;
        }

        public static bool SearchClients(String Id, String Surname, String Name, String Secondname, String Phone, String IdLawyer)
        {
            try
            {
                searchClients.Clear();
                Conn.Open();
                string Query = "SELECT * FROM clients WHERE id IS NOT NULL";
                if (Id != "")
                    Query += " AND id = @id";
                if (Surname != "")
                    Query += " AND surname = @surname";
                if (Name != "")
                    Query += " AND name = @name";
                if (Secondname != "")
                    Query += " AND second_name = @second_name";
                if (Phone != "")
                    Query += " AND phone = @phone";
                if (IdLawyer != "")
                    Query += " AND id_lawyer = @id_lawyer";
                if (Query == "SELECT * FROM lawyers WHERE id_lawyer IS NOT NULL")
                {
                    Conn.Close();
                    return false;
                }
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@surname", Surname);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@second_name", Secondname);
                cmd.Parameters.AddWithValue("@phone", Phone);
                cmd.Parameters.AddWithValue("@id_lawyer", IdLawyer);
                cmd.ExecuteNonQuery();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetValue(0));
                            string surname = reader.GetString(1);
                            string name = reader.GetString(2);
                            string secondname = reader.GetString(3);
                            string phone = reader.GetString(4);
                            int idLawyer = Convert.ToInt32(reader.GetValue(5));
                            searchClients.Add(new TableClients(id, surname, name, secondname, phone, idLawyer));
                        }
                    }
                }
                Conn.Close();
            }
            catch
            {
                Conn.Close();
                return false;
            }
            return true;
        }

        public static bool SearchCauses(String ID, String MaxTerm, String MinTerm, String ResultTerm, String Excuse, String SuspendedSentence, String Fines, String Date, String Description, String IDClient)
        {
            try
            {
                searchCauses.Clear();
                Conn.Open();
                string Query = "SELECT * FROM finished_causes WHERE id_cause IS NOT NULL";
                if (ID != "")
                    Query += " AND id_cause = @id_cause";
                if (MaxTerm != "")
                    Query += " AND max_term = @max_term";
                if (MinTerm != "")
                    Query += " AND min_term = @min_term";
                if (ResultTerm != "")
                    Query += " AND received_term = @received_term";
                if (Excuse != "")
                    Query += " AND excuses = @excuses";
                if (SuspendedSentence != "")
                    Query += " AND suspended_sentence = @suspended_sentence";
                if (Fines != "")
                    Query += " AND fines = @fines";
                if (Date != "")
                    Query += " AND date_cause = @date_cause";
                if (Description != "")
                    Query += " AND description = @description";
                if (IDClient != "")
                    Query += " AND id_client = @id_client";
                if (Query == "SELECT * FROM finished_causes WHERE id_cause IS NOT NULL")
                {
                    Conn.Close();
                    return false;
                }
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id_cause", ID);
                cmd.Parameters.AddWithValue("@max_term", MaxTerm);
                cmd.Parameters.AddWithValue("@min_term", MinTerm);
                cmd.Parameters.AddWithValue("@received_term", ResultTerm);
                cmd.Parameters.AddWithValue("@excuses", Excuse);
                cmd.Parameters.AddWithValue("@suspended_sentence", SuspendedSentence);
                cmd.Parameters.AddWithValue("@fines", Fines);
                cmd.Parameters.AddWithValue("@date_cause", Date);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@id_client", IDClient);
                cmd.ExecuteNonQuery();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetValue(0));
                            int maxTerm = Convert.ToInt32(reader.GetString(1));
                            int minTerm = Convert.ToInt32(reader.GetString(2));
                            int resultTerm = Convert.ToInt32(reader.GetString(3));
                            string excuse = reader.GetString(4);
                            int suspendedSentence = Convert.ToInt32(reader.GetString(5));
                            int fines = Convert.ToInt32(reader.GetString(6));
                            string date = reader.GetString(7);
                            string description = reader.GetString(8);
                            int idClient = Convert.ToInt32(reader.GetValue(9));
                            searchCauses.Add(new TableCauses(id, maxTerm, minTerm, resultTerm, excuse, suspendedSentence, fines, date, description, idClient));
                        }
                    }
                }
                Conn.Close();
            }
            catch
            {
                Conn.Close();
                return false;
            }
            return true;
        }

        public static bool SearchEfficiency(String Id, String Efficiency, String Inefficiency, String IdCase)
        {
            try
            {
                searchEfficiency.Clear();
                Conn.Open();
                string Query = "SELECT * FROM success WHERE id IS NOT NULL";
                if (Id != "")
                    Query += " AND id = @id";
                if (Efficiency != "")
                    Query += " AND efficiency = @efficiency";
                if (Inefficiency != "")
                    Query += " AND inefficiency = @inefficiency";
                if (IdCase != "")
                    Query += " AND id_cause = @id_cause";
                if (Query == "SELECT * FROM success WHERE id IS NOT NULL")
                {
                    Conn.Close();
                    return false;
                }
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@efficiency", Efficiency);
                cmd.Parameters.AddWithValue("@inefficiency", Inefficiency);
                cmd.Parameters.AddWithValue("@id_cause", IdCase);
                cmd.ExecuteNonQuery();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetValue(0));
                            int efficiency = Convert.ToInt32(reader.GetString(1));
                            int inefficiency = Convert.ToInt32(reader.GetString(2));
                            int? idCause = reader.GetValue(3).ToString().TuNull();
                            searchEfficiency.Add(new TableEfficiency(id, efficiency, inefficiency, idCause));
                        }
                    }
                }
                Conn.Close();
            }
            catch
            {
                Conn.Close();
                return false;
            }
            return true;
        }

        public static bool SearchFees(String Id, String Sum, String IdLawyer, String IdCause)
        {
            try
            {
                searchFees.Clear();
                Conn.Open();
                string Query = "SELECT * FROM fees WHERE id IS NOT NULL";
                if (Id != "")
                    Query += " AND id = @id";
                if (Sum != "")
                    Query += " AND sum = @sum";
                if (IdLawyer != "")
                    Query += " AND id_lawyer = @id_lawyer";
                if (IdCause != "")
                    Query += " AND id_cause = @id_cause";
                if (Query == "SELECT * FROM fees WHERE id IS NOT NULL")
                {
                    Conn.Close();
                    return false;
                }
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@sum", Sum);
                cmd.Parameters.AddWithValue("@id_lawyer", IdLawyer);
                cmd.Parameters.AddWithValue("@id_cause", IdCause);
                cmd.ExecuteNonQuery();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetValue(0));
                            int sum = Convert.ToInt32(reader.GetValue(1));
                            int? idLawyer = reader.GetValue(2).ToString().TuNull();
                            int? idCause = reader.GetValue(3).ToString().TuNull();
                            searchFees.Add(new TableFees(id, sum, idCause, idLawyer));
                        }
                    }
                }
                Conn.Close();
            }
            catch
            {
                Conn.Close();
                return false;
            }
            return true;
        }

        public static bool SearchReports(String Id, String Description, String Year, String IdLawyer)
        {
            try
            {
                searchReports.Clear();
                Conn.Open();
                string Query = "SELECT * FROM reports WHERE id_report IS NOT NULL";
                if (Id != "")
                    Query += " AND id_report = @id";
                if (Description != "")
                    Query += " AND description = @description";
                if (Year != "")
                    Query += " AND year = @year";
                if (IdLawyer != "")
                    Query += " AND id_lawyer = @id_lawyer";
                if (Query == "SELECT * FROM reports WHERE id_report IS NOT NULL")
                {
                    Conn.Close();
                    return false;
                }
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@year", Year);
                cmd.Parameters.AddWithValue("@id_lawyer", IdLawyer);
                cmd.ExecuteNonQuery();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetValue(0));
                            string description = reader.GetString(1);
                            int year = Convert.ToInt32(reader.GetValue(2));
                            int? idLawyer = reader.GetValue(3).ToString().TuNull();
                            searchReports.Add(new TableReports(id, description, year, idLawyer));
                        }
                    }
                }
                Conn.Close();
            }
            catch
            {
                Conn.Close();
                return false;
            }
            return true;
        }

        public static bool SearchAuthoriz(String Id, String Login, String Password, String IdLawyer)
        {
            try
            {
                searchAuthor.Clear();
                Conn.Open();
                string Query = "SELECT * FROM authorization WHERE id IS NOT NULL";
                if (Id != "")
                    Query += " AND id = @id";
                if (Login != "")
                    Query += " AND login = @login";
                if (Password != "")
                    Query += " AND password = @password";
                if (IdLawyer != "")
                    Query += " AND id_lawyer = @id_lawyer";
                if (Query == "SELECT * FROM authorization WHERE id IS NOT NULL")
                {
                    Conn.Close();
                    return false;
                }
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@login", Login);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@id_lawyer", IdLawyer);
                cmd.ExecuteNonQuery();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetValue(0));
                            string login = reader.GetString(1);
                            string password = reader.GetString(2);
                            int? idLawyer = reader.GetValue(3).ToString().TuNull();
                            searchAuthor.Add(new TableAuthorization(id, login, password, idLawyer));
                        }
                    }
                }
                Conn.Close();
            }
            catch
            {
                Conn.Close();
                return false;
            }
            return true;
        }
    }
}
