namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class BankReceipt
    {
        private int _BankReceiptID = Constants.NullInt;
        private string _BankCode = Constants.NullString;
        private int _DocumentNo = Constants.NullInt;
        private int _SerialNo = Constants.NullInt;
        private DateTime _DocumentDate = Constants.NullDateTime;
        private string _AccountCode = Constants.NullString;
        private string _PersonInCharge = Constants.NullString;
        private string _ReportCode = Constants.NullString;
        private int _SalesmanReceiptNo = Constants.NullInt;
        private string _Cash_Cheque_DD = Constants.NullString;
        private string _Cheque_DD_NO = Constants.NullString;
        private string _Type = Constants.NullString;
        private decimal _Amount = Constants.NullDecimal;
        private string _DrawnOn = Constants.NullString;
        private string _Remarks = Constants.NullString;
        private bool _Isactive = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private int _DocNo = Constants.NullInt;
        private int _strFY = Constants.NullInt;

        public static string Get_BankPaymentDocNo(string Code)
        {
            return new AdminDataService_DC().Get_BankReceiptDocNo(Code).Tables[0].Rows[0][0].ToString();
        }

        public static DataSet GetBankReceipt(string BankCode, DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().GetBankReceipt(BankCode, FromDt, ToDt);
        }

        public void Save(out int _DocNo)
        {
            this.Save(null, out _DocNo);
        }

        public void Save(IDbTransaction txn, out int _DocNo)
        {
            new AdminDataService_DC().SaveBankReceipt(this._BankReceiptID, this._BankCode, this._DocumentNo, this._SerialNo, this._DocumentDate, this._AccountCode, this._PersonInCharge, this._ReportCode, this._SalesmanReceiptNo, this._Cash_Cheque_DD, this._Cheque_DD_NO, this._Type, this._Amount, this._DrawnOn, this._Remarks, this._Isactive, this._CreatedBy, this._UpdatedBy, out _DocNo, this._strFY);
        }

        public static DataSet UpdateSms(string DocumentNo)
        {
            return new AdminDataService_DC().UpdateSms(DocumentNo);
        }

        public int BankReceiptID
        {
            get
            {
                return this._BankReceiptID;
            }
            set
            {
                this._BankReceiptID = value;
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

        public int DocumentNo
        {
            get
            {
                return this._DocumentNo;
            }
            set
            {
                this._DocumentNo = value;
            }
        }

        public int SerialNo
        {
            get
            {
                return this._SerialNo;
            }
            set
            {
                this._SerialNo = value;
            }
        }

        public DateTime DocumentDate
        {
            get
            {
                return this._DocumentDate;
            }
            set
            {
                this._DocumentDate = value;
            }
        }

        public string AccountCode
        {
            get
            {
                return this._AccountCode;
            }
            set
            {
                this._AccountCode = value;
            }
        }

        public string PersonInCharge
        {
            get
            {
                return this._PersonInCharge;
            }
            set
            {
                this._PersonInCharge = value;
            }
        }

        public string ReportCode
        {
            get
            {
                return this._ReportCode;
            }
            set
            {
                this._ReportCode = value;
            }
        }

        public int SalesmanReceiptNo
        {
            get
            {
                return this._SalesmanReceiptNo;
            }
            set
            {
                this._SalesmanReceiptNo = value;
            }
        }

        public string Cash_Cheque_DD
        {
            get
            {
                return this._Cash_Cheque_DD;
            }
            set
            {
                this._Cash_Cheque_DD = value;
            }
        }

        public string Cheque_DD_NO
        {
            get
            {
                return this._Cheque_DD_NO;
            }
            set
            {
                this._Cheque_DD_NO = value;
            }
        }

        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
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

        public string DrawnOn
        {
            get
            {
                return this._DrawnOn;
            }
            set
            {
                this._DrawnOn = value;
            }
        }

        public string Remarks
        {
            get
            {
                return this._Remarks;
            }
            set
            {
                this._Remarks = value;
            }
        }

        public bool Isactive
        {
            get
            {
                return this._Isactive;
            }
            set
            {
                this._Isactive = value;
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

        public int DocNo
        {
            get
            {
                return this._DocNo;
            }
            set
            {
                this._DocNo = value;
            }
        }

        public int strFY
        {
            get
            {
                return this._strFY;
            }
            set
            {
                this._strFY = value;
            }
        }
    }
}

