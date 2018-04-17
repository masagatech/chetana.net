using Idv.Chetana.Common;
using Idv.Chetana.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Others
{
    public class SupplierMaster : DataServiceBase
    {
        #region "Field"

        private int _SBillID = Constants.NullInt;
        private string _SupplierCode = Constants.NullString;
        private string _SupplierName = Constants.NullString;
        private string _PurchaseCode = Constants.NullString;
        private string _PurchaseName = Constants.NullString;
        private int _InvoiceNo = Constants.NullInt;
        private DateTime _InvoiceDate = Constants.NullDateTime;
        private decimal _GSTPer = Constants.NullInt;
        private int _FY = Constants.NullInt;
        private string _Remark = Constants.NullString;

        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;

        #endregion

        #region "Properties"

        public int SBillID
        {
            get
            {
                return this._SBillID;
            }
            set
            {
                this._SBillID = value;
            }
        }

        public string SupplierCode
        {
            get
            {
                return this._SupplierCode;
            }
            set
            {
                this._SupplierCode = value;
            }
        }

        public string SupplierName
        {
            get
            {
                return this._SupplierName;
            }
            set
            {
                this._SupplierName = value;
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

        public decimal GSTPer
        {
            get { return _GSTPer; }
            set { _GSTPer = value; }
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

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
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


        public string SBillDT { get; set; }

        #endregion

        public DataSet SaveSupplierBill()
        {
            return base.ExecuteDataSet("Idv_Chetana_Save_SupplierMaster", new IDataParameter[] {
                base.CreateParameter("@AutoID", SqlDbType.Int, SBillID),
                base.CreateParameter("@SupplierCode", SqlDbType.NVarChar, SupplierCode),
                base.CreateParameter("@SupplierName", SqlDbType.NVarChar, SupplierName),
                base.CreateParameter("@PurchaseCode", SqlDbType.NVarChar, PurchaseCode),
                base.CreateParameter("@PurchaseName", SqlDbType.NVarChar, PurchaseName),
                base.CreateParameter("@InvoiceNo", SqlDbType.Int, InvoiceNo),
                base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, InvoiceDate),
                base.CreateParameter("@GSTPer", SqlDbType.Int, GSTPer),
                base.CreateParameter("@FY", SqlDbType.Int, FY),
                base.CreateParameter("@Remark", SqlDbType.NVarChar, Remark),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy),
                base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive),
                base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted),
                base.CreateParameter("@SBillDT", SqlDbType.Xml, SBillDT),
            });
        }
    }
}
