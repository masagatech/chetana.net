namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Scheme
    {
        private int _SchemeMappingID = Constants.NullInt;
        private int _SchemeID = Constants.NullInt;
        private string _CustID = Constants.NullString;
        private string _Years = Constants.NullString;
        private decimal _Discount = Constants.NullDecimal;
        private int _FinancialYearFrom = Constants.NullInt;
        private int _FinancialYearTo = Constants.NullInt;
        private bool _ISS = Constants.NullBoolean;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private string _Remark3 = Constants.NullString;
        private decimal _Amount = Constants.NullDecimal;
        private string _startYear = Constants.NullString;
        private bool _IsDelivered = Constants.NullBoolean;
        private bool _IsReceived = Constants.NullBoolean;
        private DateTime _DeliveredDate = Constants.NullDateTime;
        private DateTime _ReceivedDate = Constants.NullDateTime;

        public static DataSet Get_Rep_Scheme(int CustID, string FromDate, string ToDate, int FY, int SuperDuperzone, int Superzone, int Zone, string Flags, int schemeId)
        {
            return new AdminDataService().Get_Rep_Scheme(CustID, FromDate, ToDate, FY, SuperDuperzone, Superzone, Zone, Flags, schemeId);
        }

        public static DataSet Get_Rep_Scheme(int CustID, string FromDate, string ToDate, int FY, int SuperDuperzone, int Superzone, int Zone, string Flags, int schemeId, string CustCateID)
        {
            return new AdminDataService().Get_Rep_Scheme(CustID, FromDate, ToDate, FY, SuperDuperzone, Superzone, Zone, Flags, schemeId, CustCateID);
        }

        public static DataSet Get_Report_ABC_Analysis(int Superzone, int Zone, int FY, int SuperDuperZone)
        {
            return new AdminDataService_DC().Get_Report_ABC_Analysis(Superzone, Zone, FY, SuperDuperZone);
        }

        public static DataSet Get_Report_BoardWise(int Board, int Superzone, int Zone, int SuperDuperZone, int FY)
        {
            return new AdminDataService_DC().Get_Report_BoardWise(Board, Superzone, Zone, SuperDuperZone, FY);
        }

        public static DataSet Get_Scheme_Customer_Mapping(string Flag, string Flag1, int FY)
        {
            return new AdminDataService().Get_Scheme_Customer_Mapping(Flag, Flag1, FY);
        }

        public void Save_Scheme_Customer_Mapping(int a)
        {
            new AdminDataService().Save_Scheme_Customer_Mapping(this._SchemeMappingID, this._SchemeID, this._CustID, this._Years, this._Discount, this._FinancialYearFrom, this._ISS, this._IsActive, this._IsDeleted, this._CreatedBy, this._Remark1, this._Remark2, this._Remark3, this._Amount, this._startYear, this._IsDelivered, this._IsReceived, this._DeliveredDate, this._ReceivedDate);
        }

        public int SchemeMappingID
        {
            get
            {
                return this._SchemeMappingID;
            }
            set
            {
                this._SchemeMappingID = value;
            }
        }

        public int SchemeID
        {
            get
            {
                return this._SchemeID;
            }
            set
            {
                this._SchemeID = value;
            }
        }

        public string CustID
        {
            get
            {
                return this._CustID;
            }
            set
            {
                this._CustID = value;
            }
        }

        public string Years
        {
            get
            {
                return this._Years;
            }
            set
            {
                this._Years = value;
            }
        }

        public decimal Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this._Discount = value;
            }
        }

        public int FinancialYearFrom
        {
            get
            {
                return this._FinancialYearFrom;
            }
            set
            {
                this._FinancialYearFrom = value;
            }
        }

        public int FinancialYearTo
        {
            get
            {
                return this._FinancialYearTo;
            }
            set
            {
                this._FinancialYearTo = value;
            }
        }

        public bool ISS
        {
            get
            {
                return this._ISS;
            }
            set
            {
                this._ISS = value;
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

        public DateTime CreatedOn
        {
            get
            {
                return this._CreatedOn;
            }
            set
            {
                this._CreatedOn = value;
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

        public DateTime UpdatedOn
        {
            get
            {
                return this._UpdatedOn;
            }
            set
            {
                this._UpdatedOn = value;
            }
        }

        public string Remark1
        {
            get
            {
                return this._Remark1;
            }
            set
            {
                this._Remark1 = value;
            }
        }

        public string Remark2
        {
            get
            {
                return this._Remark2;
            }
            set
            {
                this._Remark2 = value;
            }
        }

        public string Remark3
        {
            get
            {
                return this._Remark3;
            }
            set
            {
                this._Remark3 = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                this._Amount = value;
            }
        }

        public string startYear
        {
            get
            {
                return this._startYear;
            }
            set
            {
                this._startYear = value;
            }
        }

        public bool IsDelivered
        {
            get
            {
                return this._IsDelivered;
            }
            set
            {
                this._IsDelivered = value;
            }
        }

        public bool IsReceived
        {
            get
            {
                return this._IsReceived;
            }
            set
            {
                this._IsReceived = value;
            }
        }

        public DateTime DeliveredDate
        {
            get
            {
                return this._DeliveredDate;
            }
            set
            {
                this._DeliveredDate = value;
            }
        }

        public DateTime ReceivedDate
        {
            get
            {
                return this._ReceivedDate;
            }
            set
            {
                this._ReceivedDate = value;
            }
        }
    }
}

