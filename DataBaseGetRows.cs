using ConnectToMySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace CourseWork
{
    class DataBaseGetRows
    {
        static MainWindow main;

        public static ObservableCollection<TableAuthorization> resultAuthor = new ObservableCollection<TableAuthorization>();
        public static ObservableCollection<TableLawyers> resultLawyers = new ObservableCollection<TableLawyers>();
        public static ObservableCollection<TableClients> resultClients = new ObservableCollection<TableClients>();
        public static ObservableCollection<TableCauses> resultCauses = new ObservableCollection<TableCauses>();
        public static ObservableCollection<TableEfficiency> resultEfficiency = new ObservableCollection<TableEfficiency>();
        public static ObservableCollection<TableFees> resultFees = new ObservableCollection<TableFees>();
        public static ObservableCollection<TableReports> resultReports = new ObservableCollection<TableReports>();

        public static Dictionary<int, string> listClients = new Dictionary<int, string>();
        public static Dictionary<int, string> listCauses = new Dictionary<int, string>();
        public static Dictionary<int, string> listYear = new Dictionary<int, string>();

        public static MySqlCommand cmd = new MySqlCommand();
        public static MySqlConnection Conn = DBUtils.GetDBConnection();

        public DataBaseGetRows(MainWindow win)
        {
            main = win;
        }

        public static int IsAdmin(string login, string password)
        {
            if (login != "" && password != "")
            {
                Conn.Open();
                string Query = "SELECT * FROM authorization WHERE login = " + "'" + login + "'" + " AND password = " + "'" + password + "'";
                cmd.Connection = Conn;
                cmd.CommandText = Query;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader.GetValue(0));
                            Conn.Close();
                            return id;
                        }
                    }
                }
                Conn.Close();
            }
            return -1;
        }

        public static int GetLawyerID(int IDAuthoriz)
        {
            Conn.Open();
            string Query = "SELECT id_lawyer FROM authorization WHERE id = " + "'" + IDAuthoriz + "'";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader.GetValue(0));
                        Conn.Close();
                        return id;
                    }
                }
            }
            Conn.Close();
            return -1;
        }

        public static string GetLawyerSurname(int IDLawyer)
        {
            Conn.Open();
            string Query = "SELECT surname FROM lawyers WHERE id_lawyer = " + "'" + IDLawyer + "'";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string surname = reader.GetValue(0).ToString();
                        Conn.Close();
                        return "Адвокат " + surname;
                    }
                }
            }
            Conn.Close();
            return "";
        }

        public static Dictionary<int, string> GetClientsList(int id)
        {
            Conn.Open();
            listClients.Clear();
            string Query = "SELECT id, surname, name, second_name, phone FROM clients WHERE id_lawyer = " + "'" + id + "'";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int idClient = Convert.ToInt32(reader.GetValue(0));
                        string surname = reader.GetValue(1).ToString();
                        string name = reader.GetValue(2).ToString();
                        string second_name = reader.GetValue(3).ToString();
                        string phone = reader.GetValue(4).ToString();
                        listClients.Add(idClient, surname + " " + name + " " + second_name + " (тел. " + phone + ")");
                    }
                    Conn.Close();
                    return listClients;
                }
            }
            Conn.Close();
            return null;
        }

        public static Dictionary<int, string> GetCausesList(int id)
        {
            if (id != -1)
            {
                Conn.Open();
                listCauses.Clear();
                string Query = "";
                Query = "SELECT id_cause, description FROM finished_causes WHERE id_client = " + "'" + id + "'";
                cmd.Connection = Conn;
                cmd.CommandText = Query;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idCause = Convert.ToInt32(reader.GetValue(0));
                            string description = reader.GetValue(1).ToString();
                            if (description.Length > 45)
                                description = description.Substring(0, 45);
                            description += "...";
                            listCauses.Add(idCause, description);
                        }
                        Conn.Close();
                        return listCauses;
                    }
                }
                Conn.Close();
            }
            return null;
        }

        public static void GetCauseData(int id)
        {
            Conn.Open();
            string Query = "SELECT ca.*, fe.sum, su.efficiency, su.inefficiency FROM finished_causes as ca "
                + "LEFT JOIN fees as fe ON ca.id_cause = fe.id_cause "
                + "LEFT JOIN success as su ON ca.id_cause = su.id_cause "
                + "WHERE ca.id_cause = " + "'" + id + "';";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int maxTerm = Convert.ToInt32(reader.GetString(1));
                        int minTerm = Convert.ToInt32(reader.GetString(2));
                        int resultTerm = Convert.ToInt32(reader.GetString(3));
                        string excuse = reader.GetString(4);
                        int suspendedSentence = Convert.ToInt32(reader.GetString(5));
                        int fines = Convert.ToInt32(reader.GetString(6));
                        string date = reader.GetString(7);
                        string description = reader.GetString(8);
                        int sum = Convert.ToInt32(reader.GetString(10));
                        int efficiency = Convert.ToInt32(reader.GetString(11));
                        int inefficiency = Convert.ToInt32(reader.GetString(12));
                        main.CauseInfo.Items.Add("ОПИСАНИЕ: " + description);
                        main.CauseInfo.Items.Add("ОПРАВДАНИЯ: " + excuse);
                        main.CauseInfo.Items.Add("ПОЛУЧЕННЫЙ СРОК: " + resultTerm + " года(лет)");
                        main.CauseInfo.Items.Add("УСЛОВНЫЙ СРОК: " + suspendedSentence + " года(лет)");
                        main.CauseInfo.Items.Add("МАКСИМАЛЬНЫЙ СРОК: " + maxTerm + " года(лет)");
                        main.CauseInfo.Items.Add("МИНИМАЛЬНЫЙ СРОК: " + minTerm + " года(лет)");
                        main.CauseInfo.Items.Add("ШТРАФЫ: " + fines + " бел. руб.");
                        main.CauseInfo.Items.Add("ДАТА: " + date);
                        main.CauseInfo.Items.Add("---ИТОГ ПО ДЕЛУ---");
                        main.CauseInfo.Items.Add("ЭФФЕКТИВНОСТЬ: " + efficiency + "%");
                        main.CauseInfo.Items.Add("НЕЭФФЕКТИВНОСТЬ: " + inefficiency + "%");
                        main.CauseInfo.Items.Add("СУММА ГОНОРАРА: " + sum + " бел. руб.");
                    }
                }
            }
            Conn.Close();
        }

        public static Dictionary<int, string> GetYearList(int id)
        {
            if (id != -1)
            {
                Conn.Open();
                listYear.Clear();
                string Query = "";
                Query = "SELECT year FROM reports WHERE id_lawyer = " + "'" + id + "'";
                cmd.Connection = Conn;
                cmd.CommandText = Query;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int year = Convert.ToInt32(reader.GetValue(0));
                            listYear.Add(year, year.ToString());
                        }
                        Conn.Close();
                        return listYear;
                    }
                }
                Conn.Close();
            }
            return null;
        }

        public static string GetReportInfo(int year, int idLawyer)
        {
                Conn.Open();
                string Query = "";
                Query = "SELECT description FROM reports WHERE id_lawyer = " + "'" + idLawyer + "'" + " AND year = " + "'" + year + "'";
                cmd.Connection = Conn;
                cmd.CommandText = Query;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string description = reader.GetValue(0).ToString();Conn.Close();
                            Conn.Close();
                            return description;
                        }
                    }
                }
                Conn.Close();
            return "11";
        }

        public static void QueryAuthorizTable()
        {
            Conn.Open();
            resultAuthor.Clear();
            string Query = "SELECT * FROM authorization";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
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
                        resultAuthor.Add(new TableAuthorization(id, login, password, idLawyer));
                    }
                    main.PasswordTable.ItemsSource = resultAuthor;
                }
            }
            Conn.Close();
        }

        public static void QueryLawyersTable()
        {
            Conn.Open();
            resultLawyers.Clear();
            string Query = "SELECT * FROM lawyers";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
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
                        resultLawyers.Add(new TableLawyers(id, surname, name, secondname, phone));
                    }
                    main.LawyersTable.ItemsSource = resultLawyers;
                }
            }
            Conn.Close();
        }

        public static void QueryClientsTable()
        {
            Conn.Open();
            resultClients.Clear();
            string Query = "SELECT * FROM clients";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
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
                        int? idLawyer = reader.GetValue(5).ToString().TuNull();
                        resultClients.Add(new TableClients(id, surname, name, secondname, phone, idLawyer));
                    }
                    main.ClientsTable.ItemsSource = resultClients;
                }
            }
            Conn.Close();
        }

        public static void QueryCausesTable()
        {
            Conn.Open();
            resultCauses.Clear();
            string Query = "SELECT * FROM finished_causes";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
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
                        int? idClient = reader.GetValue(9).ToString().TuNull();
                        resultCauses.Add(new TableCauses(id, maxTerm, minTerm, resultTerm, excuse, suspendedSentence, fines, date, description, idClient));
                    }
                    main.CausesTable.ItemsSource = resultCauses;
                }
            }
            Conn.Close();
        }

        public static void QueryEfficiencyTable()
        {
            Conn.Open();
            resultEfficiency.Clear();
            string Query = "SELECT * FROM success";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
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
                        resultEfficiency.Add(new TableEfficiency(id, efficiency, inefficiency, idCause));
                    }
                    main.EfficiencyTable.ItemsSource = resultEfficiency;
                }
            }
            Conn.Close();
        }

        public static void QueryFeesTable()
        {
            Conn.Open();
            resultFees.Clear();
            string Query = "SELECT * FROM fees";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
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
                        resultFees.Add(new TableFees(id, sum, idCause, idLawyer));
                    }
                    main.FeesTable.ItemsSource = resultFees;
                }
            }
            Conn.Close();
        }

        public static void QueryReportsTable()
        {
            Conn.Open();
            resultReports.Clear();
            string Query = "SELECT * FROM reports";
            cmd.Connection = Conn;
            cmd.CommandText = Query;
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
                        resultReports.Add(new TableReports(id, description, year, idLawyer));
                    }
                    main.ReportsTable.ItemsSource = resultReports;
                }
            }
            Conn.Close();
        }
    }
}
