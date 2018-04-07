namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class Cheque_CashDetails
    {
        private string _EmpCode = Constants.NullString;
        private int _CQ_ID = Constants.NullInt;
        private string _EmpID = Constants.NullString;
        private string _CustId = Constants.NullString;
        private int _ReciptNo = Constants.NullInt;
        private string _Deposite_Type = Constants.NullString;
        private string _ChequeNo = Constants.NullString;
        private string _ChequeDate = Constants.NullString;
        private string _Deposited_By = Constants.NullString;
        private decimal _Amount = Constants.NullDecimal;
        private string _CreatedBy = Constants.NullString;
        private int _FromNo = Constants.NullInt;
        private string _ToNo = Constants.NullString;
        private bool _IsCancel = Constants.NullBoolean;
        private string _Description = Constants.NullString;
        private string _CancelBy = Constants.NullString;
        private DateTime _CancelDate = Constants.NullDateTime;
        private string _BankName = Constants.NullString;
        private string _Payee_Bank = Constants.NullString;
        private string _DepositDate = Constants.NullString;
        private bool _ISactive = Constants.NullBoolean;
        private string _BankCode = Constants.NullString;
        private string _OtherId = Constants.NullString;
        private int _FinancialYear = Constants.NullInt;
        private bool _IsDelete = Constants.NullBoolean;

        public static DataSet get_ChequeCashDeposit(string ECode, string FromDate, string ToDate)
        {
            return new AdminDataService_DC().getChequeCashDeposit(ECode, FromDate, ToDate);
        }

        public static DataSet Get_ChequeChashDoCancel(DateTime Fromdate, DateTime Todate)
        {
            return new AdminDataService_DC().Get_ChequeChashDoCancel(Fromdate, Todate);
        }

        public static DataSet Get_ChequeChashReport(string Fromdate, string Todate)
        {
            return new AdminDataService_DC().GetChequeCashReport(Fromdate, Todate);
        }

        public static DataSet get_Count_Calender1()
        {
            return new AdminDataService_DC().get_Count_Calender();
        }

        public static DataSet get_depositDetails(string CustCode)
        {
            return new AdminDataService_DC().getDepositDetails(CustCode);
        }

        public static DataSet get_depositDetails(string CustCode, string FromDate, string ToDate)
        {
            return new AdminDataService_DC().getDepositDetails(CustCode, FromDate, ToDate);
        }

        public static DataSet Get_PDC_Details(DateTime FromDate, DateTime ToDate, string Flag)
        {
            return new AdminDataService_DC().Get_PDC_Details(FromDate, ToDate, Flag);
        }

        public static DataSet Idv_Chetana_Get_ChequeCashDeposited_AfterPayment(string ECode, string FromDate, string ToDate)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_ChequeCashDeposited_AfterPayment(ECode, FromDate, ToDate);
        }

        public void Save()
        {
            new AdminDataService_DC().save_ChequeCashDetailsdal(this._CQ_ID, this._EmpID, this._CustId, this._ReciptNo, this._Deposite_Type, this._ChequeNo, this._ChequeDate, this._Deposited_By, this._Amount, this._CreatedBy, this._IsCancel, this._Description, this._CancelBy, this._CancelDate, this._Payee_Bank, this._DepositDate, this._ISactive, this._BankCode, this._OtherId);
        }

        public void Save(out int _IDNo)
        {
            this.Save(out _IDNo);
        }

        public void Save(int Fy)
        {
            new AdminDataService_DC().save_ChequeCashDetailsdal(this._CQ_ID, this._EmpID, this._CustId, this._ReciptNo, this._Deposite_Type, this._ChequeNo, this._ChequeDate, this._Deposited_By, this._Amount, this._CreatedBy, this._IsCancel, this._Description, this._CancelBy, this._CancelDate, this._Payee_Bank, this._DepositDate, this._ISactive, this._BankCode, this._OtherId, this._FinancialYear);
        }

        public void Save(int Fy, out int _IDNo)
        {
            new AdminDataService_DC().save_ChequeCashDetailsdal(this._CQ_ID, this._EmpID, this._CustId, this._ReciptNo, this._Deposite_Type, this._ChequeNo, this._ChequeDate, this._Deposited_By, this._Amount, this._CreatedBy, this._IsCancel, this._Description, this._CancelBy, this._CancelDate, this._Payee_Bank, this._DepositDate, this._ISactive, this._BankCode, this._OtherId, this._FinancialYear, out _IDNo);
        }

        public static DataSet UnPaidLedgerDetailForClient(int ClientId)
        {
            return new AdminDataService_DC().UnPaidLedgerDetailForClient(ClientId);
        }

        public void Update()
        {
            new AdminDataService_DC().Idv_Chetana_UpdateChequeCashDetails(this._CQ_ID, this._EmpID, this._CustId, this._ReciptNo, this._Deposite_Type, this._ChequeNo, this._ChequeDate, this._Amount, this._CreatedBy, this._Description, this._Payee_Bank, this._FinancialYear, this._IsDelete);
        }

        public void Updatebounce()
        {
            new AdminDataService_DC().save_ChequeCashDetailsBounce(this._CQ_ID, this.ISactive);
        }

        public void UpdateDeposit()
        {
            new AdminDataService_DC().Idv_Chetana_ChequeCashDeposited_Update_Delete(this._CQ_ID, this._BankCode, this._DepositDate, this._Description, this._CreatedBy, this._FinancialYear, this._IsDelete);
        }

        public string EmpCode
        {
            get
            {
                return this._EmpCode;
            }
            set
            {
                this._EmpCode = value;
            }
        }

        public int CQ_ID
        {
            get
            {
                return this._CQ_ID;
            }
            set
            {
                this._CQ_ID = value;
            }
        }

        public string EmpID
        {
            get
            {
                return this._EmpID;
            }
            set
            {
                this._EmpID = value;
            }
        }

        public string CustId
        {
            get
            {
                return this._CustId;
            }
            set
            {
                this._CustId = value;
            }
        }

        public int ReciptNo
        {
            get
            {
                return this._ReciptNo;
            }
            set
            {
                this._ReciptNo = value;
            }
        }

        public string Deposite_Type
        {
            get
            {
                return this._Deposite_Type;
            }
            set
            {
                this._Deposite_Type = value;
            }
        }

        public string ChequeNo
        {
            get
            {
                return this._ChequeNo;
            }
            set
            {
                this._ChequeNo = value;
            }
        }

        public string ChequeDate
        {
            get
            {
                return this._ChequeDate;
            }
            set
            {
                this._ChequeDate = value;
            }
        }

        public string Deposited_By
        {
            get
            {
                return this._Deposited_By;
            }
            set
            {
                this._Deposited_By = value;
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

        public int FromNo
        {
            get
            {
                return this._FromNo;
            }
            set
            {
                this._FromNo = value;
            }
        }

        public string ToNo
        {
            get
            {
                return this._ToNo;
            }
            set
            {
                this._ToNo = value;
            }
        }

        public bool IsCancel
        {
            get
            {
                return this._IsCancel;
            }
            set
            {
                this._IsCancel = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public string CancelBy
        {
            get
            {
                return this._CancelBy;
            }
            set
            {
                this._CancelBy = value;
            }
        }

        public DateTime CancelDate
        {
            get
            {
                return this._CancelDate;
            }
            set
            {
                this._CancelDate = value;
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

        public string Payee_Bank
        {
            get
            {
                return this._Payee_Bank;
            }
            set
            {
                this._Payee_Bank = value;
            }
        }

        public string DepositDate
        {
            get
            {
                return this._DepositDate;
            }
            set
            {
                this._DepositDate = value;
            }
        }

        public bool ISactive
        {
            get
            {
                return this._ISactive;
            }
            set
            {
                this._ISactive = value;
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

        public string OtherId
        {
            get
            {
                return this._OtherId;
            }
            set
            {
                this._OtherId = value;
            }
        }

        public int FinancialYear
        {
            get
            {
                return this._FinancialYear;
            }
            set
            {
                this._FinancialYear = value;
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
    }
}

