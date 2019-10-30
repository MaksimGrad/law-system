using System;
using System.Windows;
using System.Windows.Controls;

namespace CourseWork
{
    public partial class SearchWindow : Window
    {
        MainWindow main;
        String table;
        public SearchWindow(MainWindow win, String tablename)
        {
            InitializeComponent();
            main = win;
            table = tablename;
            if (table == "lawyers")
                Lawyer.Visibility = Visibility.Visible;
            else if(table == "clients")
                Client.Visibility = Visibility.Visible;
            else if (table == "causes")
                Cause.Visibility = Visibility.Visible;
            else if (table == "success")
                Efficiency.Visibility = Visibility.Visible;
            else if (table == "fees")
                Fees.Visibility = Visibility.Visible;
            else if (table == "reports")
                Reports.Visibility = Visibility.Visible;
            else if (table == "authoriz")
                Authorization.Visibility = Visibility.Visible;
        }

        public void SearchLawyers()
        {
            DataBaseSearchRows.SearchLawyers(IDLawyer.Text, SurnameLawyer.Text, NameLawyer.Text, SecondNameLawyer.Text, PhoneLawyer.Text);
            LawyersTable.ItemsSource = DataBaseSearchRows.searchLawyers;
        }

        public void SearchClients()
        {
            DataBaseSearchRows.SearchClients(IDClient.Text, SurnameClient.Text, NameClient.Text, SecondNameClient.Text, PhoneClient.Text, IDLawyerClient.Text);
            ClientsTable.ItemsSource = DataBaseSearchRows.searchClients;
        }

        public void SearchCauses()
        {
            DataBaseSearchRows.SearchCauses(IDCause.Text, MaxTerm.Text, MinTerm.Text, ReceivedTerm.Text, Excuses.Text, SuspendedSentence.Text, Fines.Text, Date.Text, Description.Text, IDClientCase.Text);
            CausesTable.ItemsSource = DataBaseSearchRows.searchCauses;
        }

        public void SearchEfficiency()
        {
            DataBaseSearchRows.SearchEfficiency(IDEfficiency.Text, EfficiencyPerc.Text, InefficiencyPerc.Text, IDCauseEf.Text);
            EfficiencyTable.ItemsSource = DataBaseSearchRows.searchEfficiency;
        }

        public void SearchFees()
        {
            DataBaseSearchRows.SearchFees(IDFee.Text, SumFee.Text, IDLawyerFee.Text, IDCauseFee.Text);
            FeesTable.ItemsSource = DataBaseSearchRows.searchFees;
        }

        public void SearchReports()
        {
            DataBaseSearchRows.SearchReports(IDReport.Text, Description.Text, Year.Text, IDLawyerReport.Text);
            ReportsTable.ItemsSource = DataBaseSearchRows.searchReports;
        }

        public void SearchAuthoriz()
        {
            DataBaseSearchRows.SearchAuthoriz(IDAuthor.Text, Login.Text, Password.Text, IDLawyerAuthor.Text);
            AuthorizTable.ItemsSource = DataBaseSearchRows.searchAuthor;
        }

        private void SearchBut(object sender, EventArgs e)
        {
            if (table == "lawyers")
                SearchLawyers();
            else if (table == "clients")
                SearchClients();
            else if (table == "causes")
                SearchCauses();
            else if (table == "success")
                SearchEfficiency();
            else if (table == "fees")
                SearchFees();
            else if (table == "reports")
                SearchReports();
            else if (table == "authoriz")
                SearchAuthoriz();
        }

        private void GeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Description")
            {
                Style style = new Style(typeof(DataGridCell));
                style.Setters.Add(new Setter(ContentTemplateProperty, Resources["description"]));
                e.Column.CellStyle = style;
            }
            else if (e.Column.Header.ToString() == "Excuse")
            {
                Style style = new Style(typeof(DataGridCell));
                style.Setters.Add(new Setter(ContentTemplateProperty, Resources["excuse"]));
                e.Column.CellStyle = style;
            }
        }

        private void CancelBut(object sender, EventArgs e)
        {
            Close();
            main.admin.IsEnabled = true;
        }
    }
}
