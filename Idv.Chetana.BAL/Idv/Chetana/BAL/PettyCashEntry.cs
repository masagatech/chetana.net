namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class PettyCashEntry
    {
        private int _AutoID = Constants.NullInt;
        private int _ExpenseHead = Constants.NullInt;
        private string _EmpCode = Constants.NullString;
        private int _EmpId = Constants.NullInt;
        private decimal _Amount = Constants.NullDecimal;
        private string _VoucherBillSubmitDate = Constants.NullString;
        private decimal _TotalAmount = Constants.NullDecimal;
        private bool _IsPaid = Constants.NullBoolean;
        private string _GivenFrom = Constants.NullString;
        private string _VoucherNo = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _Remark = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private decimal _PaidAmount = Constants.NullDecimal;
        private string _PaymentDate = Constants.NullString;
        private string _ChequeNo = Constants.NullString;
        private string _BankCode = Constants.NullString;
        private string _BankName = Constants.NullString;
        private string _PaymentRemar = Constants.NullString;

        public static DataSet Get_All_PettyCashDetals(string FromDate, string Todate)
        {
            return new AdminDataService_DC().Get_All_PettyCashDetals(FromDate, Todate);
        }

        public static bool Get_Validate_PettyCash_Details(string VoucherNo)
        {
            DataTable table = new DataTable();
            table = new AdminDataService_DC().Get_Validate_PettyCash_Details(VoucherNo).Tables[0];
            return (table.Rows.Count > 0);
        }

        public static DataSet GetPettyCash(string FromDate, string ToDate)
        {
            return new AdminDataService_DC().Get_PettyCashEntry(FromDate, ToDate);
        }

        public static DataSet GetVoucher_Payment(string FromVoc, string ToVoc)
        {
            return new AdminDataService_DC().Get_VoucherPayment(FromVoc, ToVoc);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveIdv_Chetana_PettyCash_Details(this._AutoID, this._VoucherNo, this._ExpenseHead, this._EmpCode, this._Amount, this._VoucherBillSubmitDate, this._TotalAmount, this._IsPaid, this._CreatedBy, this._Remark, this._IsActive);
        }

        public void update()
        {
            new AdminDataService_DC().Update_PettyCashPayment(this._GivenFrom, this.PaidAmount, this._PaymentDate, this._EmpId, this._VoucherNo, this.IsPaid, this._ChequeNo, this._BankCode, this._PaymentRemar);
        }

        public int AutoID
        {
            get
            {
                return this._AutoID;
            }
            set
            {
                this._AutoID = value;
            }
        }

        public int ExpenseHead
        {
            get
            {
                return this._ExpenseHead;
            }
            set
            {
                this._ExpenseHead = value;
            }
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

        public string VoucherBillSubmitDate
        {
            get
            {
                return this._VoucherBillSubmitDate;
            }
            set
            {
                this._VoucherBillSubmitDate = value;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return this._TotalAmount;
            }
            set
            {
                this._TotalAmount = value;
            }
        }

        public bool IsPaid
        {
            get
            {
                return this._IsPaid;
            }
            set
            {
                this._IsPaid = value;
            }
        }

        public string GivenFrom
        {
            get
            {
                return this._GivenFrom;
            }
            set
            {
                this._GivenFrom = value;
            }
        }

        public string VoucherNo
        {
            get
            {
                return this._VoucherNo;
            }
            set
            {
                this._VoucherNo = value;
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

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
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

        public decimal PaidAmount
        {
            get
            {
                return this._PaidAmount;
            }
            set
            {
                this._PaidAmount = value;
            }
        }

        public string PaymentDate
        {
            get
            {
                return this._PaymentDate;
            }
            set
            {
                this._PaymentDate = value;
            }
        }

        public int EmpId
        {
            get
            {
                return this._EmpId;
            }
            set
            {
                this._EmpId = value;
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

        public string PaymentRemar
        {
            get
            {
                return this._PaymentRemar;
            }
            set
            {
                this._PaymentRemar = value;
            }
        }
    }
}

