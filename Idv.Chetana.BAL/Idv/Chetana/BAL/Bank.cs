namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Bank
    {
        private int _BankID = Constants.NullInt;
        private string _BankCode = Constants.NullString;
        private string _BankName = Constants.NullString;
        private string _BankDescription = Constants.NullString;
        private string _Country = Constants.NullString;
        private int _State = Constants.NullInt;
        private int _City = Constants.NullInt;
        private string _CreatedBy = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDelete = Constants.NullBoolean;
        private bool _IsReco = Constants.NullBoolean;
        private int _Recoid = Constants.NullInt;
        private string _flag = Constants.NullString;
        private DateTime _RecoDate = Constants.NullDateTime;

        public static DataSet Get_BalanceSheet(DateTime Fdate, DateTime Tdate, string Flag, int FY, string AorL)
        {
            return new AdminDataService_DC().Get_BalanceSheet(Fdate, Tdate, Flag, FY, AorL);
        }

        public static DataSet Get_Bank_Checklist(string Code, DateTime Fdate, DateTime Tdate, int FY, string Flag)
        {
            return new AdminDataService().Get_Bank_Checklist(Code, Fdate, Tdate, FY, Flag);
        }

        public static DataSet Get_Bank_LedgerNew(string Code, int Frommonth, int FY, decimal OpenBal)
        {
            return new AdminDataService().Get_Bank_LedgerNew(Code, Frommonth, FY, OpenBal);
        }

        public static DataSet Get_Bank_LedgerNew(string Code, int Frommonth, int FY, decimal OpenBal, string flag, string remark1, string remark2, string remark3)
        {
            return new AdminDataService().Get_Bank_LedgerNew(Code, Frommonth, FY, OpenBal, flag, remark1, remark2, remark3);
        }

        public static DataSet Get_Bank_Reco(string Code, int Frommonth, int FY, decimal OpenBal)
        {
            return new AdminDataService().Get_Bank_Reco(Code, Frommonth, FY, OpenBal);
        }

        public static DataSet Get_Bank_Reco(string Code, int Frommonth, int FY, decimal OpenBal, string flag)
        {
            return new AdminDataService().Get_Bank_Reco(Code, Frommonth, FY, OpenBal, flag);
        }

        public static DataSet Get_BankBookSummary(int FY, string Code)
        {
            return new AdminDataService().Get_BankBookSummary(FY, Code);
        }

        public static DataSet Get_BankBookSummary(int FY, string Code, DateTime FDate, DateTime TDate)
        {
            return new AdminDataService().Get_BankBookSummary(FY, Code, FDate, TDate);
        }

        public static DataSet Get_BankMaster(string BankCode)
        {
            return new AdminDataService().GetBankMaster(BankCode);
        }

        public static DataSet Get_BankPaymentReport(string BankCode, int DocumentNo, string strFY)
        {
            return new AdminDataService().Get_BankPaymentReport(BankCode, DocumentNo, strFY);
        }

        public static DataSet Get_BankPaymentReport_MultiPrint(string BankCode, string strFY, string flag, int fromDocumentNo, int todocumentno)
        {
            return new AdminDataService().Get_BankPaymentReport_MultiPrint(BankCode, strFY, flag, fromDocumentNo, todocumentno);
        }

        public static DataSet Get_Profit_and_Loss(DateTime Fdate, DateTime Tdate, string Flag, int FY, string AorL)
        {
            return new AdminDataService_DC().Get_Profit_and_Loss(Fdate, Tdate, Flag, FY, AorL);
        }

        public static DataSet Get_Trading_Profit_and_Loss(DateTime Fdate, DateTime Tdate, string Flag, int FY, string AorL)
        {
            return new AdminDataService_DC().Get_Trading_Profit_and_Loss(Fdate, Tdate, Flag, FY, AorL);
        }

        public static DataSet Idev_Chetana_BankReceipt_Report(string BankCode, int DocumentNo, string strFY)
        {
            return new AdminDataService().Idev_Chetana_BankReceipt_Report(BankCode, DocumentNo, strFY);
        }

        public static DataSet Idv_chetana_Get_Month()
        {
            return new AdminDataService().Idv_chetana_Get_Month();
        }

        public static DataSet Idv_Chetana_Get_PettyCashBook(string Code, int FY, string remark1, string remark2, string remark3, string remark4)
        {
            return new AdminDataService().Idv_Chetana_Get_PettyCashBook(Code, FY, remark1, remark2, remark3, remark4);
        }

        public void Save()
        {
            new AdminDataService().SaveBank(this._BankID, this._BankCode, this._BankName, this._BankDescription, this._Country, this._State, this._City, this._CreatedBy, this._IsActive, this._IsDelete);
        }

        public void Update_BankRaconcilation()
        {
            new AdminDataService_DC().Update_BankRaconcilation(this._Recoid, this._IsReco, this._RecoDate, this._flag);
        }

        public static DataSet UpdateIsSms(string BankCode, int DocumentNo, string strFY)
        {
            return new AdminDataService().UpdateIsSms(BankCode, DocumentNo, strFY);
        }

        public int BankID
        {
            get
            {
                return this._BankID;
            }
            set
            {
                this._BankID = value;
            }
        }

        public string BankCode
        {
            get
            {
                return this._BankCode;
            }
            set
            {
                this._BankCode = value;
            }
        }

        public string BankName
        {
            get
            {
                return this._BankName;
            }
            set
            {
                this._BankName = value;
            }
        }

        public string BankDescription
        {
            get
            {
                return this._BankDescription;
            }
            set
            {
                this._BankDescription = value;
            }
        }

        public string Country
        {
            get
            {
                return this._Country;
            }
            set
            {
                this._Country = value;
            }
        }

        public int State
        {
            get
            {
                return this._State;
            }
            set
            {
                this._State = value;
            }
        }

        public int City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
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

        public bool IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {
                this._IsDelete = value;
            }
        }

        public bool IsReco
        {
            get
            {
                return this._IsReco;
            }
            set
            {
                this._IsReco = value;
            }
        }

        public string flag
        {
            get
            {
                return this._flag;
            }
            set
            {
                this._flag = value;
            }
        }

        public int Recoid
        {
            get
            {
                return this._Recoid;
            }
            set
            {
                this._Recoid = value;
            }
        }

        public DateTime RecoDate
        {
            get
            {
                return this._RecoDate;
            }
            set
            {
                this._RecoDate = value;
            }
        }
    }
}

