namespace CourseWork
{
    public class TableAuthorization
    {
        public TableAuthorization(int ID, string Login, string Password, int? IDLawyer)
        {
            this.ID = ID;
            this.Login = Login;
            this.Password = Password;
            this.IDLawyer = IDLawyer;
        }

        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? IDLawyer { get; set; }
    }

    public class TableLawyers
    {
        public TableLawyers(int ID, string Surname, string Name, string SecondName, string Phone)
        {
            this.ID = ID;
            this.Surname = Surname;
            this.Name = Name;
            this.SecondName = SecondName;
            this.Phone = Phone;
        }

        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
    }

    public class TableClients
    {
        public TableClients(int ID, string Surname, string Name, string SecondName, string Phone, int? IDLawyer)
        {
            this.ID = ID;
            this.Surname = Surname;
            this.Name = Name;
            this.SecondName = SecondName;
            this.Phone = Phone;
            this.IDLawyer = IDLawyer;
        }

        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public int? IDLawyer { get; set; }
    }

    public class TableReports
    {
        public TableReports(int ID, string Description, int Year, int? IDLawyer)
        {
            this.ID = ID;
            this.Description = Description;
            this.Year = Year;
            this.IDLawyer = IDLawyer;
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int? IDLawyer { get; set; }
    }

    public class TableFees
    {
        public TableFees(int ID, int SumFee, int? IDCause, int? IDLawyer)
        {
            this.ID = ID;
            this.SumFee = SumFee;
            this.IDCause = IDCause;
            this.IDLawyer = IDLawyer;
        }

        public int ID { get; set; }
        public int SumFee { get; set; }
        public int? IDCause { get; set; }
        public int? IDLawyer { get; set; }
    }

    public class TableCauses
    {
        public TableCauses(int ID, int MaxTerm, int MinTerm, int ResultTerm, string Excuse, int SuspendedSentence, int Fines, string Date, string Description, int? IDClient)
        {
            this.ID = ID;
            this.MaxTerm = MaxTerm;
            this.MinTerm = MinTerm;
            this.ResultTerm = ResultTerm;
            this.Excuse = Excuse;
            this.SuspendedSentence = SuspendedSentence;
            this.Fines = Fines;
            this.Date = Date;
            this.Description = Description;
            this.IDClient = IDClient;
        }

        public int ID { get; set; }
        public int MaxTerm { get; set; }
        public int MinTerm { get; set; }
        public int ResultTerm { get; set; }
        public string Excuse { get; set; }
        public int SuspendedSentence { get; set; }
        public int Fines { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public int? IDClient { get; set; }
    }

    public class TableEfficiency
    {
        public TableEfficiency(int ID, int Efficiency, int Inefficiency, int? IDCase)
        {
            this.ID = ID;
            this.Efficiency = Efficiency;
            this.Inefficiency = Inefficiency;
            this.IDCase = IDCase;
        }

        public int ID { get; set; }
        public int Efficiency { get; set; }
        public int Inefficiency { get; set; }
        public int? IDCase { get; set; }
    }
}
