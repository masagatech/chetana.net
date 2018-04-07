namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class DCConfirmQtyDetails
    {
        private int _ConfirmODcQtyId = Constants.NullInt;
        private int _Auto_ID = Constants.NullInt;
        private int _DocumentNo = Constants.NullInt;
        private int _DCDetailID = Constants.NullInt;
        private int _AvailableQty = Constants.NullInt;
        private decimal _SubDocNo = Constants.NullDecimal;
        private bool _IsCreateInvoice = Constants.NullBoolean;
        private string _CreatedInvoiceBy = Constants.NullString;
        private int _PrintInvoiceDetails = Constants.NullInt;
        private bool _IsPrintInvoice = Constants.NullBoolean;
        private int _PrintCount = Constants.NullInt;
        private decimal _SubDocId = Constants.NullInt;
        private string _CreatedBy = Constants.NullString;
        private decimal _Freight = Constants.NullDecimal;
        private decimal _Tax = Constants.NullDecimal;
        private decimal _TotalAmount = Constants.NullDecimal;
        private DateTime _InvoiceDate = Constants.NullDateTime;
        private string _LRNo = Constants.NullString;
        private decimal _parcel = Constants.NullDecimal;
        private decimal _bundles = Constants.NullDecimal;

        public static DataTable Get_DCDetails_SubDocNo_ByDocID(int DocNo)
        {
            return new AdminDataService_DC().Get_DCDetails_SubDocNo_ByDocID(DocNo);
        }

        public static DataTable Get_DCDetails_SubDocNo_ByDocID(int DocNo, int FY)
        {
            return new AdminDataService_DC().Get_DCDetails_SubDocNo_ByDocID(DocNo, FY);
        }

        public void Save_DC_PrintInvoiceDetails()
        {
            new AdminDataService_DC().Save_DC_PrintInvoiceDetails(this._PrintInvoiceDetails, this._SubDocId, this._IsPrintInvoice, this._PrintCount, this._CreatedBy);
        }

        public void Save_DC_PrintInvoiceDetails(int fy)
        {
            new AdminDataService_DC().Save_DC_PrintInvoiceDetails(this._PrintInvoiceDetails, this._SubDocId, this._IsPrintInvoice, this._PrintCount, this._CreatedBy, this._AvailableQty);
        }

        public void Save_FrightTax_Details()
        {
            new AdminDataService_DC().Save_FrightTax_Details(this._Auto_ID, this._DocumentNo, this._SubDocNo, this._Freight, this._Tax, this._TotalAmount, this._InvoiceDate, this._LRNo, this._CreatedBy);
        }

        public void Save_FrightTax_Details(int FY)
        {
            new AdminDataService_DC().Save_FrightTax_Details(this._Auto_ID, this._DocumentNo, this._SubDocNo, this._Freight, this._Tax, this._TotalAmount, this._InvoiceDate, this._LRNo, this._CreatedBy, this._AvailableQty);
        }

        public void SaveConfirmDetails()
        {
            new AdminDataService_DC().Save_GenerateInvoice_Details(this._SubDocNo, this._IsCreateInvoice, this._CreatedInvoiceBy);
        }

        public void SaveConfirmDetails(int FY)
        {
            new AdminDataService_DC().Save_GenerateInvoice_Details(this._SubDocNo, this._IsCreateInvoice, this._CreatedInvoiceBy, this._AvailableQty);
        }

        public void SaveDCConfirmQtyDetails()
        {
            new AdminDataService_DC().Save_DCConfirmQtyDetails(this._ConfirmODcQtyId, this._DCDetailID, this._AvailableQty, this._SubDocNo, this._parcel, this._bundles, this._CreatedBy);
        }

        public int Auto_ID
        {
            get
            {
                return this._Auto_ID;
            }
            set
            {
                this._Auto_ID = value;
            }
        }

        public int ConfirmODcQtyId
        {
            get
            {
                return this._ConfirmODcQtyId;
            }
            set
            {
                this._ConfirmODcQtyId = value;
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

        public int DCDetailID
        {
            get
            {
                return this._DCDetailID;
            }
            set
            {
                this._DCDetailID = value;
            }
        }

        public int AvailableQty
        {
            get
            {
                return this._AvailableQty;
            }
            set
            {
                this._AvailableQty = value;
            }
        }

        public decimal SubDocNo
        {
            get
            {
                return this._SubDocNo;
            }
            set
            {
                this._SubDocNo = value;
            }
        }

        public bool IsCreateInvoice
        {
            get
            {
                return this._IsCreateInvoice;
            }
            set
            {
                this._IsCreateInvoice = value;
            }
        }

        public string CreatedInvoiceBy
        {
            get
            {
                return this._CreatedInvoiceBy;
            }
            set
            {
                this._CreatedInvoiceBy = value;
            }
        }

        public int PrintInvoiceDetails
        {
            get
            {
                return this._PrintInvoiceDetails;
            }
            set
            {
                this._PrintInvoiceDetails = value;
            }
        }

        public decimal SubDocId
        {
            get
            {
                return this._SubDocId;
            }
            set
            {
                this._SubDocId = value;
            }
        }

        public bool IsPrintInvoice
        {
            get
            {
                return this._IsPrintInvoice;
            }
            set
            {
                this._IsPrintInvoice = value;
            }
        }

        public int PrintCount
        {
            get
            {
                return this._PrintCount;
            }
            set
            {
                this._PrintCount = value;
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

        public decimal Freight
        {
            get
            {
                return this._Freight;
            }
            set
            {
                this._Freight = value;
            }
        }

        public decimal Tax
        {
            get
            {
                return this._Tax;
            }
            set
            {
                this._Tax = value;
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

        public string LRNo
        {
            get
            {
                return this._LRNo;
            }
            set
            {
                this._LRNo = value;
            }
        }

        public decimal Parcel
        {
            get
            {
                return this._parcel;
            }
            set
            {
                this._parcel = value;
            }
        }

        public decimal Bundles
        {
            get
            {
                return this._bundles;
            }
            set
            {
                this._bundles = value;
            }
        }
    }
}

