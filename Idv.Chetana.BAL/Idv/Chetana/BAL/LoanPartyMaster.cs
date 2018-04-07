namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class LoanPartyMaster
    {
        private int _PartyID = Constants.NullInt;
        private string _PartyCode = Constants.NullString;
        private string _PartyName = Constants.NullString;
        private string _LoanReceivedGiven = Constants.NullString;
        private string _Address = Constants.NullString;
        private string _Zip = Constants.NullString;
        private int _CityID = Constants.NullInt;
        private string _Phone1 = Constants.NullString;
        private string _Phone2 = Constants.NullString;
        private string _EmailID = Constants.NullString;
        private decimal _CreditLimit = Constants.NullDecimal;
        private string _CreditDays = Constants.NullString;
        private int _InterestRate = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;

        public static DataSet GetLoanPartyMaster()
        {
            return new AdminDataService_DC().GetLoanPartyMaster();
        }

        public static DataSet Idv_Chetana_Customer_Aging_Report(int Zone, string FromDate, string ToDate, int FY, string CustCode)
        {
            return new AdminDataService_DC().Idv_Chetana_Customer_Aging_Report(FromDate, ToDate, FY, Zone, CustCode);
        }

        public static DataSet Idv_Chetana_Stock_Aging_Report(DateTime FromDate, DateTime ToDate, int FY, string flag)
        {
            return new AdminDataService_DC().Idv_Chetana_Stock_Aging_Report(FromDate, ToDate, FY, flag);
        }

        public static DataSet Report_Commision(int SuperZone, int Zone, string FromDate, string ToDate, int FY)
        {
            return new AdminDataService_DC().Idv_Chetana_Customer_Commission_Report(0, FromDate, ToDate, FY, SuperZone, Zone, "");
        }

        public static DataSet Report_LoanInterest(string AcCode, DateTime FromDate, DateTime ToDate, int FY, string IntRate, string ReptCode)
        {
            return new AdminDataService_DC().Report_LoanInterest(AcCode, FromDate, ToDate, FY, IntRate, ReptCode);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveLoanPartyMaster(this._PartyID, this._PartyCode, this._PartyName, this._LoanReceivedGiven, this._Address, this._Zip, this._CityID, this._Phone1, this._Phone2, this._EmailID, this._CreditLimit, this._CreditDays, this._InterestRate, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int PartyID
        {
            get
            {
                return this._PartyID;
            }
            set
            {
                this._PartyID = value;
            }
        }

        public string PartyCode
        {
            get
            {
                return this._PartyCode;
            }
            set
            {
                this._PartyCode = value;
            }
        }

        public string PartyName
        {
            get
            {
                return this._PartyName;
            }
            set
            {
                this._PartyName = value;
            }
        }

        public string LoanReceivedGiven
        {
            get
            {
                return this._LoanReceivedGiven;
            }
            set
            {
                this._LoanReceivedGiven = value;
            }
        }

        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }

        public string Zip
        {
            get
            {
                return this._Zip;
            }
            set
            {
                this._Zip = value;
            }
        }

        public int CityID
        {
            get
            {
                return this._CityID;
            }
            set
            {
                this._CityID = value;
            }
        }

        public string Phone1
        {
            get
            {
                return this._Phone1;
            }
            set
            {
                this._Phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this._Phone2;
            }
            set
            {
                this._Phone2 = value;
            }
        }

        public string EmailID
        {
            get
            {
                return this._EmailID;
            }
            set
            {
                this._EmailID = value;
            }
        }

        public decimal CreditLimit
        {
            get
            {
                return this._CreditLimit;
            }
            set
            {
                this._CreditLimit = value;
            }
        }

        public string CreditDays
        {
            get
            {
                return this._CreditDays;
            }
            set
            {
                this._CreditDays = value;
            }
        }

        public int InterestRate
        {
            get
            {
                return this._InterestRate;
            }
            set
            {
                this._InterestRate = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this._IsActive = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }
            set
            {
                this._IsDeleted = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return this._CreatedBy;
            }
            set
            {
                this._CreatedBy = value;
            }
        }

        public string UpdatedBy
        {
            get
            {
                return this._UpdatedBy;
            }
            set
            {
                this._UpdatedBy = value;
            }
        }
    }
}

