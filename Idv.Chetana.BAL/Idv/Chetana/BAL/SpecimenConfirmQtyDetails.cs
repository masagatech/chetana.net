namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class SpecimenConfirmQtyDetails
    {
        private int _SpecimenDetailID = Constants.NullInt;
        private int _ConfirmDcQtyId = Constants.NullInt;
        private int _AvailableQty = Constants.NullInt;
        private decimal _SubDocNo = Constants.NullDecimal;
        private bool _IsCreateInvoice = Constants.NullBoolean;
        private string _CreatedInvoiceBy = Constants.NullString;
        private int _PrintInvoiceDetails = Constants.NullInt;
        private bool _IsPrintInvoice = Constants.NullBoolean;
        private int _PrintCount = Constants.NullInt;
        private string _CreatedBy = Constants.NullString;
        private int _DocumentNo = Constants.NullInt;
        private decimal _Freight = Constants.NullDecimal;
        private decimal _Tax = Constants.NullDecimal;
        private decimal _TotalAmount = Constants.NullDecimal;
        private string _Transporter = Constants.NullString;
        private string _LrNo = Constants.NullString;
        private string _Bundles = Constants.NullString;
        private DateTime _InvoiceDate = Constants.NullDateTime;
        private decimal _SubDocId = Constants.NullInt;

        public static DataTable Get_SpecimenDetails_SubDocNo_ByDocID(int DocNo)
        {
            return new AdminDataService().Get_SpecimenDetails_SubDocNo_ByDocID(DocNo);
        }

        public void Save()
        {
            new AdminDataService().Save_SpecimenConfirmQtyDetails(this._ConfirmDcQtyId, this._SpecimenDetailID, this._AvailableQty, this._SubDocNo);
        }

        public void Save_FrightTax_Details()
        {
            new AdminDataService().Save_FrightTax_Details(this._DocumentNo, this._SubDocNo, this._Freight, this._Tax, this._TotalAmount, this._CreatedBy);
        }

        public void Save_Specimen_PrintInvoiceDetails()
        {
            new AdminDataService().Save_Specimen_PrintInvoiceDetails(this._PrintInvoiceDetails, this._SubDocId, this._IsPrintInvoice, this._PrintCount, this._CreatedBy);
        }

        public void SaveConfirmDetails()
        {
            new AdminDataService().Save_GenerateInvoice_Details(this._SubDocNo, this._IsCreateInvoice, this._CreatedInvoiceBy, this._Transporter, this._LrNo, this._Bundles, this._InvoiceDate);
        }

        public int SpecimenDetailID
        {
            get
            {
                return this._SpecimenDetailID;
            }
            set
            {
                this._SpecimenDetailID = value;
            }
        }

        public int ConfirmDcQtyId
        {
            get
            {
                return this._ConfirmDcQtyId;
            }
            set
            {
                this._ConfirmDcQtyId = value;
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

        public string Transporter
        {
            get
            {
                return this._Transporter;
            }
            set
            {
                this._Transporter = value;
            }
        }

        public string LrNo
        {
            get
            {
                return this._LrNo;
            }
            set
            {
                this._LrNo = value;
            }
        }

        public string Bundles
        {
            get
            {
                return this._Bundles;
            }
            set
            {
                this._Bundles = value;
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
    }
}

