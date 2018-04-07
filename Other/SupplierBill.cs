using Idv.Chetana.Common;
using Idv.Chetana.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Others
{
    public class SupplierBill : DataServiceBase
    {
        #region "Field"

        private int _SBillID = Constants.NullInt;
        private string _SupplierCode = Constants.NullString;
        private string _SupplierName = Constants.NullString;
        private string _PurchaseCode = Constants.NullString;
        private string _PurchaseName = Constants.NullString;
        private string _InvoiceNo = Constants.NullString;
        private DateTime _InvoiceDate = Constants.NullDateTime;
        private int _GSTPer = Constants.NullInt;

        private int _SBillDID = Constants.NullInt;
        private string _AccountCode = Constants.NullString;
        private string _AccountName = Constants.NullString;
        private int _Quantity = Constants.NullInt;
        private decimal _Amount = Constants.NullDecimal;
        private string _Remark = Constants.NullString;

        private int _FY = Constants.NullInt;
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

        public string InvoiceNo
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

        public int GSTPer
        {
            get { return _GSTPer; }
            set { _GSTPer = value; }
        }


        public int SBillDID
        {
            get { return _SBillDID; }
            set { _SBillDID = value; }
        }

        public string AccountCode
        {
            get { return _AccountCode; }
            set { _AccountCode = value; }
        }

        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; }
        }

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
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

        #endregion

        #region "User-Defined Function"

        public DataSet SaveSupplierBill()
        {
            return base.ExecuteDataSet("Idv_Chetana_Save_SupplierBill", new IDataParameter[] {
                base.CreateParameter("@SBillID", SqlDbType.Int, SBillID),
                base.CreateParameter("@SupplierCode", SqlDbType.NVarChar, SupplierCode),
                base.CreateParameter("@PurchaseCode", SqlDbType.NVarChar, PurchaseCode),
                base.CreateParameter("@InvoiceNo", SqlDbType.NVarChar, InvoiceNo),
                base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, InvoiceDate),
                base.CreateParameter("@GSTPer", SqlDbType.Int, GSTPer),
                base.CreateParameter("@FY", SqlDbType.Int, FY),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy),
                base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive)
            });
        }

        public void SaveSupplierBillDetails()
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SupplierBill_Details", new IDataParameter[] {
                base.CreateParameter("@SBillDID", SqlDbType.Int, SBillDID),
                base.CreateParameter("@SBillID", SqlDbType.Int, SBillID),
                base.CreateParameter("@AccountCode", SqlDbType.NVarChar, AccountCode),
                base.CreateParameter("@Quantity", SqlDbType.Int, Quantity),
                base.CreateParameter("@Amount", SqlDbType.Decimal, Amount),
                base.CreateParameter("@Remark", SqlDbType.NVarChar, Remark),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy),
                base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive)
            });
            
            command.Dispose();
        }

        public DataSet GetSupplierDatails(int InvoiceNo, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SupplierDatails", new IDataParameter[] {
                base.CreateParameter("@InvoiceNo", SqlDbType.Int, InvoiceNo),
                base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDate),
                base.CreateParameter("@todate", SqlDbType.DateTime, ToDate)
            });
        }

        public static DataSet GetSupplierDetails(int InvoiceNo, DateTime FromDate, DateTime ToDate)
        {
            return GetSupplierDetails(InvoiceNo, FromDate, ToDate);
        }

        #endregion
    }
}
