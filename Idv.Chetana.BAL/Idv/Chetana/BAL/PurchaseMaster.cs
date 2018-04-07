namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class PurchaseMaster
    {
        private int _PurchaseMasterID = Constants.NullInt;
        private int _InvoiceNo = Constants.NullInt;
        private string _SuppliersRef = Constants.NullString;
        private DateTime _InvoiceDate = Constants.NullDateTime;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _Isdeleted = Constants.NullBoolean;
        private string _SuppliersRefCode = Constants.NullString;
        private string _PurchaseCode = Constants.NullString;
        private string _PurchaseName = Constants.NullString;
        private int _FY = Constants.NullInt;
        private string _oms = Constants.NullString;
        private decimal _ms = Constants.NullDecimal;

        public static DataSet Get_PurchaseDetails(int InvoiceNo, DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService().Get_PurchaseDetails(InvoiceNo, FromDate, ToDate);
        }

        public static DataSet Get_PurchaseDetails(int InvoiceNo, DateTime FromDate, DateTime ToDate, int FY, string FLAG, int MONTH, int YEAR)
        {
            return new AdminDataService().Get_PurchaseDetails(InvoiceNo, FromDate, ToDate, FY, FLAG, MONTH, YEAR);
        }

        public static bool Idv_Chetana_Get_Validate_PurchaseInvoice(int Invoice)
        {
            DataTable table = new DataTable();
            table = new AdminDataService_DC().Idv_Chetana_Get_Validate_PurchaseInvoice(Invoice).Tables[0];
            return (table.Rows.Count > 0);
        }

        public void Save(out int _DocNo)
        {
            this.Save(null, out _DocNo);
        }

        public void Save(IDbTransaction txn, out int _DocNo)
        {
            new AdminDataService().SavePurchaseMaster(this._PurchaseMasterID, this._InvoiceNo, this._SuppliersRef, this._InvoiceDate, this._CreatedBy, this._UpdatedBy, this._IsActive, this._Isdeleted, this._SuppliersRefCode, this._PurchaseCode, this._PurchaseName, out _DocNo, this._FY);
        }

        public void Save(out int _DocNo, string nes)
        {
            new AdminDataService().SavePurchaseMaster(this._PurchaseMasterID, this._InvoiceNo, this._SuppliersRef, this._InvoiceDate, this._CreatedBy, this._UpdatedBy, this._IsActive, this._Isdeleted, this._SuppliersRefCode, this._PurchaseCode, this._PurchaseName, out _DocNo, this._FY, this._oms, this._ms);
        }

        public int PurchaseMasterID
        {
            get
            {
                return this._PurchaseMasterID;
            }
            set
            {
                this._PurchaseMasterID = value;
            }
        }

        public int InvoiceNo
        {
            get
            {
                return this._InvoiceNo;
            }
            set
            {
                this._InvoiceNo = value;
            }
        }

        public string SuppliersRef
        {
            get
            {
                return this._SuppliersRef;
            }
            set
            {
                this._SuppliersRef = value;
            }
        }

        public DateTime InvoiceDate
        {
            get
            {
                return this._InvoiceDate;
            }
            set
            {
                this._InvoiceDate = value;
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

        public bool Isdeleted
        {
            get
            {
                return this._Isdeleted;
            }
            set
            {
                this._Isdeleted = value;
            }
        }

        public string SuppliersRefCode
        {
            get
            {
                return this._SuppliersRefCode;
            }
            set
            {
                this._SuppliersRefCode = value;
            }
        }

        public string PurchaseCode
        {
            get
            {
                return this._PurchaseCode;
            }
            set
            {
                this._PurchaseCode = value;
            }
        }

        public string PurchaseName
        {
            get
            {
                return this._PurchaseName;
            }
            set
            {
                this._PurchaseName = value;
            }
        }

        public int FY
        {
            get
            {
                return this._FY;
            }
            set
            {
                this._FY = value;
            }
        }

        public string Oms
        {
            get
            {
                return this._oms;
            }
            set
            {
                this._oms = value;
            }
        }

        public decimal Ms
        {
            get
            {
                return this._ms;
            }
            set
            {
                this._ms = value;
            }
        }
    }
}

