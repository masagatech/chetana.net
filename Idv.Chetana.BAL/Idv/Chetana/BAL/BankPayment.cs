namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class BankPayment
    {
        private int _BankPaymentID = Constants.NullInt;
        private string _BankCode = Constants.NullString;
        private int _DocumentNo = Constants.NullInt;
        private int _SerialNo = Constants.NullInt;
        private DateTime _DocumentDate = Constants.NullDateTime;
        private string _AccountCode = Constants.NullString;
        private string _PersonInCharge = Constants.NullString;
        private string _ReportCode = Constants.NullString;
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
        private bool _IsChequeBounce = Constants.NullBoolean;
        private string _Paymode = Constants.NullString;

        public static DataSet Get_AppraisalForm(int SuperZone, int FY, DateTime FromDt, DateTime ToDt, string Flag, int SuperDuperZone)
        {
            return new AdminDataService_DC().Get_AppraisalForm(SuperZone, FY, FromDt, ToDt, Flag, SuperDuperZone);
        }

        public static string Get_BankPaymentDocNo(string Code)
        {
            return new AdminDataService_DC().Get_BankPaymentDocNo(Code).Tables[0].Rows[0][0].ToString();
        }

        public static DataSet Get_SuperZoneWise_Weekly_Collection(int SuperZoneid, DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().Get_SuperZoneWise_Weekly_Collection(SuperZoneid, FromDt, ToDt);
        }

        public static DataSet Get_SuperZoneWise_Weekly_Collection(int SuperZoneid, DateTime FromDt, DateTime ToDt, string Flag)
        {
            return new AdminDataService_DC().Get_SuperZoneWise_Weekly_Collection(SuperZoneid, FromDt, ToDt, Flag);
        }

        public static DataSet Get_SuperZoneWise_Weekly_Collection(int SuperZoneid, DateTime FromDt, DateTime ToDt, string Flag, int SuperDuperZoneid)
        {
            return new AdminDataService_DC().Get_SuperZoneWise_Weekly_Collection(SuperZoneid, FromDt, ToDt, Flag, SuperDuperZoneid);
        }

        public static DataSet Get_YearOnYeaGrowth(int SuperZone, int FY, DateTime FromDt, DateTime ToDt, string Flag, int SuperDuperZone)
        {
            return new AdminDataService_DC().Get_YearOnYeaGrowth(SuperZone, FY, FromDt, ToDt, Flag, SuperDuperZone);
        }

        public static DataSet GetBankPayment(string BankCode, DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().GetBankPayment(BankCode, FromDt, ToDt);
        }

        public void Save(out int _DocNo)
        {
            this.Save(null, out _DocNo);
        }

        public void Save(IDbTransaction txn, out int _DocNo)
        {
            new AdminDataService_DC().SaveBankPayment(this._BankPaymentID, this._BankCode, this._DocumentNo, this._SerialNo, this._DocumentDate, this._AccountCode, this._PersonInCharge, this._ReportCode, this._Cash_Cheque_DD, this._Cheque_DD_NO, this._Type, this._Amount, this._DrawnOn, this._Remarks, this._Isactive, this._CreatedBy, this._UpdatedBy, out _DocNo, this._strFY, this._Paymode, this._IsChequeBounce);
        }

        public string Paymode
        {
            get
            {
                return this._Paymode;
            }
            set
            {
                this._Paymode = value;
            }
        }

        public int BankPaymentID
        {
            get
            {
                return this._BankPaymentID;
            }
            set
            {
                this._BankPaymentID = value;
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

        public bool IsChequeBounce
        {
            get
            {
                return this._IsChequeBounce;
            }
            set
            {
                this._IsChequeBounce = value;
            }
        }
    }
}

