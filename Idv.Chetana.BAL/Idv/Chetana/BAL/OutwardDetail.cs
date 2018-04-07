namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class OutwardDetail
    {
        private int _OdDAutoId = Constants.NullInt;
        private int _OdMAutoId = Constants.NullInt;
        private int _FY = Constants.NullInt;
        private string _InvoiceNo = Constants.NullString;
        private string _InvoiceOrDC = Constants.NullString;
        private string _CustomerName = Constants.NullString;
        private string _HandOverToInward = Constants.NullString;
        private string _InwardBy = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CustArea = Constants.NullString;

        public static DataSet Get_OutwardDetails(string InvoiceNo, string flag, string status, int strFY)
        {
            return new AdminDataService_DC().Get_OutwardDetails(InvoiceNo, flag, status, strFY);
        }

        public static DataSet Get_OutwardDetails(string InvoiceNo, string flag, string status, int strFY, DateTime Fromdate, DateTime Todate)
        {
            return new AdminDataService_DC().Get_OutwardDetails(InvoiceNo, flag, status, strFY, Fromdate, Todate);
        }

        public static DataSet GetCustN_Doc(int DocNo, int strFY)
        {
            return new AdminDataService_DC().GetCustN_Doc(DocNo, strFY);
        }

        public static DataSet GetCustN_Invoice(decimal InvoiceNo, int strFY)
        {
            return new AdminDataService_DC().GetCustN_Invoice(InvoiceNo, strFY);
        }

        public static DataSet GetOutward(int OdDocNo, int strFY)
        {
            return new AdminDataService_DC().GetOutward(OdDocNo, strFY);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveODDetail(this._OdDAutoId, this._OdMAutoId, this._FY, this._InvoiceNo, this._InvoiceOrDC, this._CustomerName, this._IsActive, this._IsDeleted, this._CustArea);
        }

        public int OdDAutoId
        {
            get
            {
                return this._OdDAutoId;
            }
            set
            {
                this._OdDAutoId = value;
            }
        }

        public int OdMAutoId
        {
            get
            {
                return this._OdMAutoId;
            }
            set
            {
                this._OdMAutoId = value;
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

        public string InvoiceOrDC
        {
            get
            {
                return this._InvoiceOrDC;
            }
            set
            {
                this._InvoiceOrDC = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return this._CustomerName;
            }
            set
            {
                this._CustomerName = value;
            }
        }

        public string HandOverToInward
        {
            get
            {
                return this._HandOverToInward;
            }
            set
            {
                this._HandOverToInward = value;
            }
        }

        public string InwardBy
        {
            get
            {
                return this._InwardBy;
            }
            set
            {
                this._InwardBy = value;
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

        public string CustArea
        {
            get
            {
                return this._CustArea;
            }
            set
            {
                this._CustArea = value;
            }
        }
    }
}

