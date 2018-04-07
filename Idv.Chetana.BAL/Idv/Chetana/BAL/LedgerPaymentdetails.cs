namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class LedgerPaymentdetails
    {
        private int _Autoid = Constants.NullInt;
        private int _ReceiptNo = Constants.NullInt;
        private int _CQ_ID = Constants.NullInt;
        private decimal _InvoiceNo = Constants.NullDecimal;
        private decimal _debitAmount = Constants.NullDecimal;
        private decimal _ReceiptAmount = Constants.NullDecimal;

        public void save()
        {
            new AdminDataService_DC().saveLedgerPaymentDetails(this.Autoid, this.ReceiptNo, this.CQ_ID, this.InvoiceNo, this.debitAmount, this.ReceiptAmount);
        }

        public int Autoid
        {
            get
            {
                return this._Autoid;
            }
            set
            {
                this._Autoid = value;
            }
        }

        public int ReceiptNo
        {
            get
            {
                return this._ReceiptNo;
            }
            set
            {
                this._ReceiptNo = value;
            }
        }

        public int CQ_ID
        {
            get
            {
                return this._CQ_ID;
            }
            set
            {
                this._CQ_ID = value;
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

        public decimal debitAmount
        {
            get
            {
                return this._debitAmount;
            }
            set
            {
                this._debitAmount = value;
            }
        }

        public decimal ReceiptAmount
        {
            get
            {
                return this._ReceiptAmount;
            }
            set
            {
                this._ReceiptAmount = value;
            }
        }
    }
}

