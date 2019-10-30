using System.Windows;
using System;
using System.Windows.Media;
using System.Windows.Forms;
using System.Windows.Controls;

namespace CourseWork
{
    public partial class MainWindow : Window
    {
        int IDLawyer = -1;

        private void ShowPasswordTable(object sender, EventArgs e)
        {
            DataBaseGetRows.QueryAuthorizTable();
            HiddenTables();
            AdminTablePassword.Background = new LinearGradientBrush(Colors.DarkSlateBlue, Colors.SlateBlue, 90);
            PasswordTable.Visibility = Visibility.Visible;
        }

        private void ShowLawyersTable(object sender, EventArgs e)
        {
            DataBaseGetRows.QueryLawyersTable();
            HiddenTables();
            AdminTableLawyers.Background = new LinearGradientBrush(Colors.DarkSlateBlue, Colors.SlateBlue, 90);
            LawyersTable.Visibility = Visibility.Visible;
        }

        private void ShowClientsTable(object sender, EventArgs e)
        {
            DataBaseGetRows.QueryClientsTable();
            HiddenTables();
            AdminTableClients.Background = new LinearGradientBrush(Colors.DarkSlateBlue, Colors.SlateBlue, 90);
            ClientsTable.Visibility = Visibility.Visible;
        }

        private void ShowCausesTable(object sender, EventArgs e)
        {
            DataBaseGetRows.QueryCausesTable();
            HiddenTables();
            AdminTableCauses.Background = new LinearGradientBrush(Colors.DarkSlateBlue, Colors.SlateBlue, 90);
            CausesTable.Visibility = Visibility.Visible;
        }

        private void ShowEfficiencyTable(object sender, EventArgs e)
        {
            DataBaseGetRows.QueryEfficiencyTable();
            HiddenTables();
            AdminTableEfficiency.Background = new LinearGradientBrush(Colors.DarkSlateBlue, Colors.SlateBlue, 90);
            EfficiencyTable.Visibility = Visibility.Visible;
        }

        private void ShowFeesTable(object sender, EventArgs e)
        {
            DataBaseGetRows.QueryFeesTable();
            HiddenTables();
            AdminTableFees.Background = new LinearGradientBrush(Colors.DarkSlateBlue, Colors.SlateBlue, 90);
            FeesTable.Visibility = Visibility.Visible;
        }

        private void ShowReportsTable(object sender, EventArgs e)
        {
            DataBaseGetRows.QueryReportsTable();
            HiddenTables();
            AdminTableReports.Background = new LinearGradientBrush(Colors.DarkSlateBlue, Colors.SlateBlue, 90);
            ReportsTable.Visibility = Visibility.Visible;
        }

        public MainWindow()
        {
            InitializeComponent();
            new DataBaseGetRows(this);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            int ClientID = DataBaseGetRows.IsAdmin(LoginForm.Text, PasswordForm.Password.ToString());
            if (ClientID == 0)
            {
                admin.Visibility = Visibility.Visible;
                first.Visibility = Visibility.Hidden;
            }
            else if (ClientID > 0)
            {
                lawyer.Visibility = Visibility.Visible;
                first.Visibility = Visibility.Hidden;
                LawyerData(ClientID);
            }
            else
            {
                ErroAuthorization.Visibility = Visibility.Visible;
            }
        }

        private void LawyerData(int ClientID)
        {
            IDLawyer = DataBaseGetRows.GetLawyerID(ClientID);
            Surname.Text = DataBaseGetRows.GetLawyerSurname(IDLawyer);
            ListClients.ItemsSource = DataBaseGetRows.GetClientsList(IDLawyer);
            ListCauses.ItemsSource = DataBaseGetRows.GetCausesList(-1);
        }

        private void GetCausesSelect(object sender, EventArgs e)
        {
            try
            {
                int selectedId = (int)ListClients.SelectedValue;
                ListCauses.ItemsSource = null;
                CauseInfo.Items.Clear();
                ListCauses.ItemsSource = DataBaseGetRows.GetCausesList(selectedId);
            }
            catch { }
        }

        private void GetCauseInfo(object sender, EventArgs e)
        {
            try
            {
                int selectedId = (int)ListCauses.SelectedValue;
                CauseInfo.Items.Clear();
                DataBaseGetRows.GetCauseData(selectedId);
            }
            catch { }
        }

        private void ShowClientsInfo(object sender, EventArgs e)
        {
            lawyerReports.Visibility = Visibility.Hidden;
            lawyerClients.Visibility = Visibility.Visible;
            CauseData.Visibility = Visibility.Visible;
        }

        private void ShowReportsInfo(object sender, EventArgs e)
        {
            lawyerClients.Visibility = Visibility.Hidden;
            CauseData.Visibility = Visibility.Hidden;
            lawyerReports.Visibility = Visibility.Visible;
            ListYear.ItemsSource = DataBaseGetRows.GetYearList(IDLawyer);
        }

        private void GetReport(object sender, EventArgs e)
        {
            try
            {
                int selectedId = (int)ListYear.SelectedValue;
                Report.Text = DataBaseGetRows.GetReportInfo(selectedId, IDLawyer);
            }
            catch { }
        }

        private void CreateRowClick(object sender, EventArgs e)
        {
            if (LawyersTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                CreateEditRow cer = new CreateEditRow(this, "lawyers", true, -1);
                cer.Show();
            }
            else if(ClientsTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                CreateEditRow cer = new CreateEditRow(this, "clients", true, -1);
                cer.Show();
            }
            else if (CausesTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                CreateEditRow cer = new CreateEditRow(this, "causes", true, -1);
                cer.Show();
            }
            else if (EfficiencyTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                CreateEditRow cer = new CreateEditRow(this, "success", true, -1);
                cer.Show();
            }
            else if (FeesTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                CreateEditRow cer = new CreateEditRow(this, "fees", true, -1);
                cer.Show();
            }
            else if (ReportsTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                CreateEditRow cer = new CreateEditRow(this, "reports", true, -1);
                cer.Show();
            }
            else if (PasswordTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                CreateEditRow cer = new CreateEditRow(this, "authoriz", true, -1);
                cer.Show();
            }
            else
                System.Windows.Forms.MessageBox.Show("Вы не выбрали таблицу", "Добавление", MessageBoxButtons.OK);
        }

        private void EditRowClick(object sender, EventArgs e)
        {
            try
            {
                if (LawyersTable.Visibility == Visibility.Visible)
                {
                    TableLawyers row = (TableLawyers)LawyersTable.SelectedItems[0];
                    if (row != null)
                    {
                        admin.IsEnabled = false;
                        CreateEditRow cer = new CreateEditRow(this, "lawyers", false, row.ID);
                        cer.GetLawyerData(row);
                        cer.Show();
                    }
                }
                else if(ClientsTable.Visibility == Visibility.Visible)
                {
                    TableClients row = (TableClients)ClientsTable.SelectedItems[0];
                    if (row != null)
                    {
                        admin.IsEnabled = false;
                        CreateEditRow cer = new CreateEditRow(this, "clients", false, row.ID);
                        cer.GetClientData(row);
                        cer.Show();
                    }
                }
                else if (CausesTable.Visibility == Visibility.Visible)
                {
                    TableCauses row = (TableCauses)CausesTable.SelectedItems[0];
                    if (row != null)
                    {
                        admin.IsEnabled = false;
                        CreateEditRow cer = new CreateEditRow(this, "causes", false, row.ID);
                        cer.GetCauseData(row);
                        cer.Show();
                    }
                }
                else if (EfficiencyTable.Visibility == Visibility.Visible)
                {
                    TableEfficiency row = (TableEfficiency)EfficiencyTable.SelectedItems[0];
                    if (row != null)
                    {
                        admin.IsEnabled = false;
                        CreateEditRow cer = new CreateEditRow(this, "success", false, row.ID);
                        cer.GetEfficiencyData(row);
                        cer.Show();
                    }
                }
                else if (FeesTable.Visibility == Visibility.Visible)
                {
                    TableFees row = (TableFees)FeesTable.SelectedItems[0];
                    if (row != null)
                    {
                        admin.IsEnabled = false;
                        CreateEditRow cer = new CreateEditRow(this, "fees", false, row.ID);
                        cer.GetFeeData(row);
                        cer.Show();
                    }
                }
                else if (ReportsTable.Visibility == Visibility.Visible)
                {
                    TableReports row = (TableReports)ReportsTable.SelectedItems[0];
                    if (row != null)
                    {
                        admin.IsEnabled = false;
                        CreateEditRow cer = new CreateEditRow(this, "reports", false, row.ID);
                        cer.GetReportData(row);
                        cer.Show();
                    }
                }
                else if (PasswordTable.Visibility == Visibility.Visible)
                {
                    TableAuthorization row = (TableAuthorization)PasswordTable.SelectedItems[0];
                    if (row != null)
                    {
                        admin.IsEnabled = false;
                        CreateEditRow cer = new CreateEditRow(this, "authoriz", false, row.ID);
                        cer.GetAuthorizData(row);
                        cer.Show();
                    }
                }
                else
                    System.Windows.Forms.MessageBox.Show("Вы не выбрали запись для редактирования", "Редактирование", MessageBoxButtons.OK);
            }
            catch {
                System.Windows.Forms.MessageBox.Show("Вы не выбрали запись для редактирования", "Редактирование", MessageBoxButtons.OK);
            }
        }

        private void DeleteRowClick(object sender, EventArgs e)
        {
            try
            {
                if (LawyersTable.Visibility == Visibility.Visible)
                {
                    TableLawyers row = (TableLawyers)LawyersTable.SelectedItems[0];
                    if (DataBaseDeleteRow.DeleteRow("lawyers", row.ID))
                    {
                        DataBaseGetRows.QueryLawyersTable();
                        System.Windows.Forms.MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButtons.OK);
                    }
                }
                else if (ClientsTable.Visibility == Visibility.Visible)
                {
                    TableClients row = (TableClients)ClientsTable.SelectedItems[0];
                    if (DataBaseDeleteRow.DeleteRow("clients", row.ID))
                    {
                        DataBaseGetRows.QueryClientsTable();
                        System.Windows.Forms.MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButtons.OK);
                    }
                }
                else if (CausesTable.Visibility == Visibility.Visible)
                {
                    TableCauses row = (TableCauses)CausesTable.SelectedItems[0];
                    if (DataBaseDeleteRow.DeleteRow("causes", row.ID))
                    {
                        DataBaseGetRows.QueryCausesTable();
                        System.Windows.Forms.MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButtons.OK);
                    }
                }
                else if (EfficiencyTable.Visibility == Visibility.Visible)
                {
                    TableEfficiency row = (TableEfficiency)EfficiencyTable.SelectedItems[0];
                    if (DataBaseDeleteRow.DeleteRow("success", row.ID))
                    {
                        DataBaseGetRows.QueryEfficiencyTable();
                        System.Windows.Forms.MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButtons.OK);
                    }
                }
                else if (FeesTable.Visibility == Visibility.Visible)
                {
                    TableFees row = (TableFees)FeesTable.SelectedItems[0];
                    if (DataBaseDeleteRow.DeleteRow("fees", row.ID))
                    {
                        DataBaseGetRows.QueryFeesTable();
                        System.Windows.Forms.MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButtons.OK);
                    }
                }
                else if (ReportsTable.Visibility == Visibility.Visible)
                {
                    TableReports row = (TableReports)ReportsTable.SelectedItems[0];
                    if (DataBaseDeleteRow.DeleteRow("reports", row.ID))
                    {
                        DataBaseGetRows.QueryReportsTable();
                        System.Windows.Forms.MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButtons.OK);
                    }
                }
                else if (PasswordTable.Visibility == Visibility.Visible)
                {
                    TableAuthorization row = (TableAuthorization)PasswordTable.SelectedItems[0];
                    if (DataBaseDeleteRow.DeleteRow("authoriz", row.ID))
                    {
                        DataBaseGetRows.QueryAuthorizTable();
                        System.Windows.Forms.MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButtons.OK);
                    }
                }
                else System.Windows.Forms.MessageBox.Show("Вы не выбрали запись для удаления", "Удаление", MessageBoxButtons.OK);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Вы не выбрали запись для удаления", "Удаление", MessageBoxButtons.OK);
            }
        }

        private void SearchClick(object sender, EventArgs e)
        {
            if (LawyersTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                SearchWindow sear = new SearchWindow(this, "lawyers");
                sear.Show();
            }
            else if (ClientsTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                SearchWindow sear = new SearchWindow(this, "clients");
                sear.Show();
            }
            else if (CausesTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                SearchWindow sear = new SearchWindow(this, "causes");
                sear.Show();
            }
            else if (EfficiencyTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                SearchWindow sear = new SearchWindow(this, "success");
                sear.Show();
            }
            else if (FeesTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                SearchWindow sear = new SearchWindow(this, "fees");
                sear.Show();
            }
            else if (ReportsTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                SearchWindow sear = new SearchWindow(this, "reports");
                sear.Show();
            }
            else if (PasswordTable.Visibility == Visibility.Visible)
            {
                admin.IsEnabled = false;
                SearchWindow sear = new SearchWindow(this, "authoriz");
                sear.Show();
            }
            else
                System.Windows.Forms.MessageBox.Show("Вы не выбрали таблицу для поиска", "Поиск", MessageBoxButtons.OK);
        }

        private void GeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Description")
            {
                Style style = new Style(typeof(System.Windows.Controls.DataGridCell));
                style.Setters.Add(new Setter(ContentTemplateProperty, Resources["description"]));
                e.Column.CellStyle = style;
            }
            else if (e.Column.Header.ToString() == "Excuse")
            {
                Style style = new Style(typeof(System.Windows.Controls.DataGridCell));
                style.Setters.Add(new Setter(ContentTemplateProperty, Resources["excuse"]));
                e.Column.CellStyle = style;
            }
        }

        private void ExitAdmin(object sender, EventArgs e)
        {
            first.Visibility = Visibility.Visible;
            admin.Visibility = Visibility.Hidden;
            ClearForm(sender, e);
        }

        private void ExitLawyer(object sender, EventArgs e)
        {
            first.Visibility = Visibility.Visible;
            lawyer.Visibility = Visibility.Hidden;
            lawyerClients.Visibility = Visibility.Hidden;
            lawyerReports.Visibility = Visibility.Hidden;
            CauseData.Visibility = Visibility.Hidden;
            ClearForm(sender, e);
        }

        private void ExitSystem(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearForm(object sender, EventArgs e)
        {
            LoginForm.Clear();
            PasswordForm.Clear();
            ErroAuthorization.Visibility = Visibility.Hidden;
        }

        private void HiddenTables()
        {
            PasswordTable.Visibility = Visibility.Hidden;
            LawyersTable.Visibility = Visibility.Hidden;
            ClientsTable.Visibility = Visibility.Hidden;
            CausesTable.Visibility = Visibility.Hidden;
            EfficiencyTable.Visibility = Visibility.Hidden;
            FeesTable.Visibility = Visibility.Hidden;
            ReportsTable.Visibility = Visibility.Hidden;

            AdminTableLawyers.Background = Brushes.DarkSlateGray;
            AdminTableClients.Background = Brushes.DarkSlateGray;
            AdminTablePassword.Background = Brushes.DarkSlateGray;
            AdminTableCauses.Background = Brushes.DarkSlateGray;
            AdminTableEfficiency.Background = Brushes.DarkSlateGray;
            AdminTableFees.Background = Brushes.DarkSlateGray;
            AdminTableReports.Background = Brushes.DarkSlateGray;
        }
    }
}
