namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class LeadgerDetails
    {
        private int _LedgerId = Constants.NullInt;
        private string _Particulars = Constants.NullString;
        private object _DebitAmount = Constants.NullDecimal;
        private object _CreditAmount = Constants.NullDecimal;
        private object _Openingbalance = Constants.NullDecimal;
        private DateTime _CreaditDate = Constants.NullDateTime;
        private string _FinancialYearFrom = Constants.NullString;
        private string _FinancialYearTo = Constants.NullString;
        private string _relation = Constants.NullString;
        private string _remark = Constants.NullString;
        private string _otherId = Constants.NullString;

        public static DataSet Get_LedgerDetails(string CustCode, string flag, string fromno, string tono)
        {
            return new AdminDataService_DC().get_LedgerDetails(CustCode, flag, fromno, tono);
        }

        public static DataSet Get_LedgerDetails(string CustCode, string flag, string fromno, string tono, int FY)
        {
            return new AdminDataService_DC().get_LedgerDetails(CustCode, flag, fromno, tono, FY);
        }

        public static DataSet Get_LedgerDetails(string CustCode, string flag, string fromno, string tono, int FY, DateTime fromDate, DateTime toDate)
        {
            return new AdminDataService_DC().get_LedgerDetails(CustCode, flag, fromno, tono, FY, fromDate, toDate);
        }

        public static DataSet Get_SalesRegister(string flag, DateTime fromDate, DateTime toDate, int FY)
        {
            return new AdminDataService_DC().Get_SalesRegister(flag, fromDate, toDate, FY);
        }

        public static DataSet Get_SalesRegister(string flag, DateTime fromDate, DateTime toDate, int FY, string flag1, string Remark1)
        {
            return new AdminDataService_DC().Get_SalesRegister(flag, fromDate, toDate, FY, flag1, Remark1);
        }

        public int LedgerId
        {
            get
            {
                return this._LedgerId;
            }
            set
            {
                this._LedgerId = value;
            }
        }

        public string Particulars
        {
            get
            {
                return this._Particulars;
            }
            set
            {
                this._Particulars = value;
            }
        }

        public object DebitAmount
        {
            get
            {
                return this._DebitAmount;
            }
            set
            {
                this._DebitAmount = value;
            }
        }

        public object CreditAmount
        {
            get
            {
                return this._CreditAmount;
            }
            set
            {
                this._CreditAmount = value;
            }
        }

        public object Openingbalance
        {
            get
            {
                return this._Openingbalance;
            }
            set
            {
                this._Openingbalance = value;
            }
        }

        public DateTime CreaditDate
        {
            get
            {
                return this._CreaditDate;
            }
            set
            {
                this._CreaditDate = value;
            }
        }

        public string FinancialYearFrom
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

        public string FinancialYearTo
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

        public string relation
        {
            get
            {
                return this._relation;
            }
            set
            {
                this._relation = value;
            }
        }

        public string remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }

        public string otherId
        {
            get
            {
                return this._otherId;
            }
            set
            {
                this._otherId = value;
            }
        }
    }
}

