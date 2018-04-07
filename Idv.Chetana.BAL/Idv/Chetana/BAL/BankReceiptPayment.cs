namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class BankReceiptPayment
    {
        private int _Bank_RecPayID = Constants.NullInt;
        private int _AccBookID = Constants.NullInt;
        private int _AccDocumentNo = Constants.NullInt;
        private int _AccDocSerialNo = Constants.NullInt;
        private string _CustomerCode = Constants.NullString;
        private string _SalesmanCode = Constants.NullString;
        private string _SalesmanReceipt = Constants.NullString;
        private string _Cash_Cheque_DD = Constants.NullString;
        private string _Cheque_DDNo = Constants.NullString;
        private string _Type = Constants.NullString;
        private decimal _Amount = Constants.NullDecimal;
        private string _DrawnOn = Constants.NullString;
        private int _NarrationID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;

        public static DataSet GetBankReceiptPayment()
        {
            return new AdminDataService_DC().GetBankReceiptPayment();
        }

        public static DataSet idv_Chetana_Get_Trial_Balance()
        {
            return new AdminDataService_DC().idv_Chetana_Get_Trial_Balance();
        }

        public static DataSet idv_Chetana_Get_Trial_Balance(DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService_DC().idv_Chetana_Get_Trial_Balance(FromDate, ToDate);
        }

        public static DataSet idv_Chetana_Get_Trial_Balance(DateTime FromDate, DateTime ToDate, string Flag, int FY, string Group)
        {
            return new AdminDataService_DC().idv_Chetana_Get_Trial_Balance(FromDate, ToDate, Flag, FY, Group);
        }

        public static DataSet Idv_Chetana_Get_Trial_Balance_Summary(DateTime FromDate, DateTime ToDate, string Flag, int FY, string Group)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_Trial_Balance_Summary(FromDate, ToDate, Flag, FY, Group);
        }

        public static DataSet Idv_Chetana_REP_Collection_Report(int SuperZone, int FY, DateTime FromDate, DateTime Todate, string Flag)
        {
            return new AdminDataService_DC().Idv_Chetana_REP_Collection_Report(SuperZone, FY, FromDate, Todate, Flag);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveBankReceiptPaymentDetails(this._Bank_RecPayID, this._AccBookID, this._AccDocumentNo, this._AccDocSerialNo, this.CustomerCode, this.SalesmanCode, this.SalesmanReceipt, this._Cash_Cheque_DD, this._Cheque_DDNo, this._Type, this._Amount, this._DrawnOn, this._NarrationID, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int Bank_RecPayID
        {
            get
            {
                return this._Bank_RecPayID;
            }
            set
            {
                this._Bank_RecPayID = value;
            }
        }

        public int AccBookID
        {
            get
            {
                return this._AccBookID;
            }
            set
            {
                this._AccBookID = value;
            }
        }

        public int AccDocumentNo
        {
            get
            {
                return this._AccDocumentNo;
            }
            set
            {
                this._AccDocumentNo = value;
            }
        }

        public int AccDocSerialNo
        {
            get
            {
                return this._AccDocSerialNo;
            }
            set
            {
                this._AccDocSerialNo = value;
            }
        }

        public string CustomerCode
        {
            get
            {
                return this._CustomerCode;
            }
            set
            {
                this._CustomerCode = value;
            }
        }

        public string SalesmanCode
        {
            get
            {
                return this._SalesmanCode;
            }
            set
            {
                this._SalesmanCode = value;
            }
        }

        public string SalesmanReceipt
        {
            get
            {
                return this._SalesmanReceipt;
            }
            set
            {
                this._SalesmanReceipt = value;
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

        public string Cheque_DDNo
        {
            get
            {
                return this._Cheque_DDNo;
            }
            set
            {
                this._Cheque_DDNo = value;
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

        public int NarrationID
        {
            get
            {
                return this._NarrationID;
            }
            set
            {
                this._NarrationID = value;
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

