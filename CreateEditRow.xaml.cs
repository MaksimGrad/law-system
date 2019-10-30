using System;
using System.Windows;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class CreateEditRow : Window
    {
        MainWindow main;
        Boolean isCreate;
        int ID;
        String table;

        public CreateEditRow(MainWindow win, String tablename, Boolean isCreating, int Id)
        {
            InitializeComponent();
            main = win;

            if(tablename == "lawyers")
            {
                Lawyer.Visibility = Visibility.Visible;
            }
            else if(tablename == "clients")
            {
                Client.Visibility = Visibility.Visible;
            }
            else if (tablename == "causes")
            {
                Cause.Visibility = Visibility.Visible;
            }
            else if (tablename == "success")
            {
                Efficiency.Visibility = Visibility.Visible;
            }
            else if (tablename == "fees")
            {
                Fees.Visibility = Visibility.Visible;
            }
            else if (tablename == "reports")
            {
                Reports.Visibility = Visibility.Visible;
            }
            else if (tablename == "authoriz")
            {
                Authorization.Visibility = Visibility.Visible;
            }

            isCreate = isCreating;
            ID = Id;
            table = tablename;
        }

        public void GetLawyerData(TableLawyers row)
        {
            IDLawyer.Text = row.ID.ToString();
            SurnameLawyer.Text = row.Surname;
            NameLawyer.Text = row.Name;
            SecondNameLawyer.Text = row.SecondName;
            PhoneLawyer.Text = row.Phone;
        }

        public void GetClientData(TableClients row)
        {
            IDClient.Text = row.ID.ToString();
            SurnameClient.Text = row.Surname;
            NameClient.Text = row.Name;
            SecondNameClient.Text = row.SecondName;
            PhoneClient.Text = row.Phone;
            IDLawyerClient.Text = row.IDLawyer.ToString();
        }

        public void GetCauseData(TableCauses row)
        {
            IDCause.Text = row.ID.ToString();
            MaxTerm.Text = row.MaxTerm.ToString();
            MinTerm.Text = row.MinTerm.ToString();
            ReceivedTerm.Text = row.ResultTerm.ToString();
            Excuses.Text = row.Excuse;
            SuspendedSentence.Text = row.SuspendedSentence.ToString();
            Fines.Text = row.Fines.ToString();
            Date.Text = row.Date;
            Description.Text = row.Description;
            IDClientCase.Text = row.IDClient.ToString();
        }

        public void GetEfficiencyData(TableEfficiency row)
        {
            IDEfficiency.Text = row.ID.ToString();
            EfficiencyPerc.Text = row.Efficiency.ToString();
            InefficiencyPerc.Text = row.Inefficiency.ToString();
            IDCauseEf.Text = row.IDCase.ToString();
        }

        public void GetFeeData(TableFees row)
        {
            IDFee.Text = row.ID.ToString();
            SumFee.Text = row.SumFee.ToString();
            IDCauseFee.Text = row.IDCause.ToString();
            IDLawyerFee.Text = row.IDLawyer.ToString();
        }

        public void GetReportData(TableReports row)
        {
            IDReport.Text = row.ID.ToString();
            DescriptionReport.Text = row.Description.ToString();
            Year.Text = row.Year.ToString();
            IDLawyerReport.Text = row.IDLawyer.ToString();
        }

        public void GetAuthorizData(TableAuthorization row)
        {
            IDAuthor.Text = row.ID.ToString();
            Login.Text = row.Login.ToString();
            Password.Text = row.Password.ToString();
            IDLawyerAuthor.Text = row.IDLawyer.ToString();
        }

        int GetLawyerRow()
        {
            TableLawyers row;
            try
            {
                row = new TableLawyers(Convert.ToInt32(IDLawyer.Text), SurnameLawyer.Text.GetValue(), NameLawyer.Text.GetValue(), SecondNameLawyer.Text, PhoneLawyer.Text);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка. Введены некорректные данные", "Результат выполнения запроса", MessageBoxButtons.OK);
                return 0;
            }
            if (DataBaseCreateEditRow.CreateEditLawyerRow(row, isCreate, ID))
            {
                System.Windows.Forms.MessageBox.Show("Операция успешно выполнена", "Результат выполнения запроса", MessageBoxButtons.OK);
                Close();
                DataBaseGetRows.QueryLawyersTable();
                main.admin.IsEnabled = true;
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка при выполнении операции в БД", "Результат выполнения запроса", MessageBoxButtons.OK);
            return 0;
        }

        int GetClientRow()
        {
            TableClients row;
            try
            {
                row = new TableClients(Convert.ToInt32(IDClient.Text), SurnameClient.Text.GetValue(), NameClient.Text.GetValue(), SecondNameClient.Text, PhoneClient.Text.GetValue(), Convert.ToInt32(IDLawyerClient.Text));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка. Введены некорректные данные", "Результат выполнения запроса", MessageBoxButtons.OK);
                return 0;
            }
            if (DataBaseCreateEditRow.CreateEditClientRow(row, isCreate, ID))
            {
                System.Windows.Forms.MessageBox.Show("Операция успешно выполнена", "Результат выполнения запроса", MessageBoxButtons.OK);
                Close();
                DataBaseGetRows.QueryClientsTable();
                main.admin.IsEnabled = true;
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка при выполнении операции в БД", "Результат выполнения запроса", MessageBoxButtons.OK);
            return 0;
        }

        int GetCauseRow()
        {
            TableCauses row;
            try
            {
                row = new TableCauses(Convert.ToInt32(IDCause.Text), Convert.ToInt32(MaxTerm.Text), Convert.ToInt32(MinTerm.Text), Convert.ToInt32(ReceivedTerm.Text), Excuses.Text, Convert.ToInt32(SuspendedSentence.Text), Convert.ToInt32(Fines.Text), Date.Text.GetValue(), Description.Text, Convert.ToInt32(IDClientCase.Text));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка. Введены некорректные данные", "Результат выполнения запроса", MessageBoxButtons.OK);
                return 0;
            }
            if (DataBaseCreateEditRow.CreateEditCauseRow(row, isCreate, ID))
            {
                System.Windows.Forms.MessageBox.Show("Операция успешно выполнена", "Результат выполнения запроса", MessageBoxButtons.OK);
                Close();
                DataBaseGetRows.QueryCausesTable();
                main.admin.IsEnabled = true;
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка при выполнении операции в БД", "Результат выполнения запроса", MessageBoxButtons.OK);
            return 0;
        }

        int GetEfficiencyRow()
        {
            TableEfficiency row;
            try
            {
                row = new TableEfficiency(Convert.ToInt32(IDEfficiency.Text), Convert.ToInt32(EfficiencyPerc.Text), Convert.ToInt32(InefficiencyPerc.Text), Convert.ToInt32(IDCauseEf.Text));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка. Введены некорректные данные", "Результат выполнения запроса", MessageBoxButtons.OK);
                return 0;
            }
            if (DataBaseCreateEditRow.CreateEditEfficiencyRow(row, isCreate, ID))
            {
                System.Windows.Forms.MessageBox.Show("Операция успешно выполнена", "Результат выполнения запроса", MessageBoxButtons.OK);
                Close();
                DataBaseGetRows.QueryEfficiencyTable();
                main.admin.IsEnabled = true;
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка при выполнении операции в БД", "Результат выполнения запроса", MessageBoxButtons.OK);
            return 0;
        }

        int GetFeeRow()
        {
            TableFees row;
            try
            {
                row = new TableFees(Convert.ToInt32(IDFee.Text), Convert.ToInt32(SumFee.Text), Convert.ToInt32(IDCauseFee.Text), Convert.ToInt32(IDLawyerFee.Text));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка. Введены некорректные данные", "Результат выполнения запроса", MessageBoxButtons.OK);
                return 0;
            }
            if (DataBaseCreateEditRow.CreateEditFeesRow(row, isCreate, ID))
            {
                System.Windows.Forms.MessageBox.Show("Операция успешно выполнена", "Результат выполнения запроса", MessageBoxButtons.OK);
                Close();
                DataBaseGetRows.QueryFeesTable();
                main.admin.IsEnabled = true;
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка при выполнении операции в БД", "Результат выполнения запроса", MessageBoxButtons.OK);
            return 0;
        }

        int GetReportRow()
        {
            TableReports row;
            try
            {
                row = new TableReports(Convert.ToInt32(IDReport.Text), DescriptionReport.Text.GetValue(), Convert.ToInt32(Year.Text), Convert.ToInt32(IDLawyerReport.Text));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка. Введены некорректные данные", "Результат выполнения запроса", MessageBoxButtons.OK);
                return 0;
            }
            if (DataBaseCreateEditRow.CreateEditReportsRow(row, isCreate, ID))
            {
                System.Windows.Forms.MessageBox.Show("Операция успешно выполнена", "Результат выполнения запроса", MessageBoxButtons.OK);
                Close();
                DataBaseGetRows.QueryReportsTable();
                main.admin.IsEnabled = true;
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка при выполнении операции в БД", "Результат выполнения запроса", MessageBoxButtons.OK);
            return 0;
        }

        int GetAuthorizRow()
        {
            TableAuthorization row;
            try
            {
                row = new TableAuthorization(Convert.ToInt32(IDAuthor.Text), Login.Text.GetValue(), Password.Text.GetValue(), Convert.ToInt32(IDLawyerAuthor.Text));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка. Введены некорректные данные", "Результат выполнения запроса", MessageBoxButtons.OK);
                return 0;
            }
            if (DataBaseCreateEditRow.CreateEditAuthorizRow(row, isCreate, ID))
            {
                System.Windows.Forms.MessageBox.Show("Операция успешно выполнена", "Результат выполнения запроса", MessageBoxButtons.OK);
                Close();
                DataBaseGetRows.QueryAuthorizTable();
                main.admin.IsEnabled = true;
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка при выполнении операции в БД", "Результат выполнения запроса", MessageBoxButtons.OK);
            return 0;
        }

        void CancelClick(object sender, EventArgs e)
        {
            Close();
            main.admin.IsEnabled = true;
        }

        void OKClick(object sender, EventArgs e)
        {
            if (table == "lawyers")
            {
                GetLawyerRow();
            }
            else if (table == "clients")
            {
                GetClientRow();
            }
            else if (table == "causes")
            {
                GetCauseRow();
            }
            else if (table == "success")
            {
                GetEfficiencyRow();
            }
            else if (table == "fees")
            {
                GetFeeRow();
            }
            else if (table == "reports")
            {
                GetReportRow();
            }
            else if (table == "authoriz")
            {
                GetAuthorizRow();
            }
        }
    }
}
