namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class InvoiceDeliveryStatus
    {
        private int _AutoId = Constants.NullInt;
        private decimal _InvoiceNo = Constants.NullDecimal;
        private DateTime _InvoiceDate = Constants.NullDateTime;
        private string _CustCode = Constants.NullString;
        private string _CustName = Constants.NullString;
        private string _Area = Constants.NullString;
        private string _DeliveryStatus = Constants.NullString;
        private decimal _TotalAmount = Constants.NullDecimal;
        private string _CreatedBy = Constants.NullString;
        private DateTime _Createdon = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private bool _IsActive = Constants.NullBoolean;
        private int _Fy = Constants.NullInt;
        private string _FinancialYearFrom = Constants.NullString;
        private string _FinancialYearTo = Constants.NullString;

        public static DataSet Idv_Chetana_EditInvoiceDelivery_Status(decimal InvoiceNo, int Fy)
        {
            return new AdminDataService().Idv_Chetana_EditInvoiceDelivery_Status(InvoiceNo, Fy);
        }

        public static DataSet Idv_Chetana_Get_StatusFor_Report(int SZID, DateTime FromDate, DateTime ToDate, int Fy)
        {
            return new AdminDataService().Idv_Chetana_Get_StatusFor_Report(SZID, FromDate, ToDate, Fy);
        }

        public static DataSet Idv_Chetana_Get_StatusFor_Report(int SZID, DateTime FromDate, DateTime ToDate, int Fy, string Flag)
        {
            return new AdminDataService().Idv_Chetana_Get_StatusFor_Report(SZID, FromDate, ToDate, Fy, Flag);
        }

        public static DataSet Idv_Chetana_Get_StatusFor_Report(int SZID, DateTime FromDate, DateTime ToDate, int Fy, string Flag, int ZoneID, string Flag1)
        {
            return new AdminDataService().Idv_Chetana_Get_StatusFor_Report(SZID, FromDate, ToDate, Fy, Flag, ZoneID, Flag1);
        }

        public static DataSet Idv_Chetana_GetInvoiceDeliveryStatusDetails(decimal InvoiceNo, int Fy)
        {
            return new AdminDataService().Idv_Chetana_GetInvoiceDeliveryStatusDetails(InvoiceNo, Fy);
        }

        public void Save()
        {
            new AdminDataService().Idv_Chetana_Save_InvoiceDelivery_Status(this._AutoId, this._InvoiceNo, this._InvoiceDate, this._CustCode, this._CustName, this._Area, this._DeliveryStatus, this._TotalAmount, this._CreatedBy, this._IsActive, this._Fy);
        }

        public int AutoId
        {
            get
            {
                return this._AutoId;
            }
            set
            {
                this._AutoId = value;
            }
        }

        public decimal InvoiceNo
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

        public string CustCode
        {
            get
            {
                return this._CustCode;
            }
            set
            {
                this._CustCode = value;
            }
        }

        public string CustName
        {
            get
            {
                return this._CustName;
            }
            set
            {
                this._CustName = value;
            }
        }

        public string Area
        {
            get
            {
                return this._Area;
            }
            set
            {
                this._Area = value;
            }
        }

        public string DeliveryStatus
        {
            get
            {
                return this._DeliveryStatus;
            }
            set
            {
                this._DeliveryStatus = value;
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

        public DateTime Createdon
        {
            get
            {
                return this._Createdon;
            }
            set
            {
                this._Createdon = value;
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

        public int Fy
        {
            get
            {
                return this._Fy;
            }
            set
            {
                this._Fy = value;
            }
        }

        public string FinancialYearFrom
        {
            get
            {
                return this._FinancialYearFrom;
            }
            set
            {
                this._FinancialYearFrom = value;
            }
        }

        public string FinancialYearTo
        {
            get
            {
                return this._FinancialYearTo;
            }
            set
            {
                this._FinancialYearTo = value;
            }
        }
    }
}

