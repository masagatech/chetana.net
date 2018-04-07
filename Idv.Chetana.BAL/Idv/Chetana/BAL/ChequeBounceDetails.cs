namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class ChequeBounceDetails
    {
        private int _AutoId = Constants.NullInt;
        private int _ReceiptNo = Constants.NullInt;
        private string _ChequeNo = Constants.NullString;
        private string _ChequeReturnDate = Constants.NullString;
        private decimal _ReturnAmount = Constants.NullDecimal;
        private string _ReturnRemark = Constants.NullString;
        private decimal _Amount = Constants.NullDecimal;
        private int _cq_id = Constants.NullInt;
        private int _FYfrom = Constants.NullInt;
        private int _FYto = Constants.NullInt;

        public static DataSet Get_ChequeCashBounceDetails(int ReciptNo)
        {
            return new AdminDataService_DC().Get_ChequeCashBounceDetails(ReciptNo);
        }

        public static DataSet Get_ReceiptViewBookDetails(int ReciptNo)
        {
            return new AdminDataService_DC().Get_ReceiptViewBookDetails(ReciptNo);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveChequebounceDetails(this._AutoId, this._ReceiptNo, this._ChequeNo, this._ChequeReturnDate, this._ReturnAmount, this._ReturnRemark, this._Amount, this._cq_id, this._FYfrom, this._FYto);
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

        public string ChequeNo
        {
            get
            {
                return this._ChequeNo;
            }
            set
            {
                this._ChequeNo = value;
            }
        }

        public string ChequeReturnDate
        {
            get
            {
                return this._ChequeReturnDate;
            }
            set
            {
                this._ChequeReturnDate = value;
            }
        }

        public decimal ReturnAmount
        {
            get
            {
                return this._ReturnAmount;
            }
            set
            {
                this._ReturnAmount = value;
            }
        }

        public string ReturnRemark
        {
            get
            {
                return this._ReturnRemark;
            }
            set
            {
                this._ReturnRemark = value;
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

        public int Cq_id
        {
            get
            {
                return this._cq_id;
            }
            set
            {
                this._cq_id = value;
            }
        }

        public int FYfrom
        {
            get
            {
                return this._FYfrom;
            }
            set
            {
                this._FYfrom = value;
            }
        }

        public int FYto
        {
            get
            {
                return this._FYto;
            }
            set
            {
                this._FYto = value;
            }
        }
    }
}

