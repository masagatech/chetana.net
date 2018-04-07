namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class BookVirtualStock
    {
        private string _BookCode = Constants.NullString;
        private int _OpeningStock = Constants.NullInt;
        private int _VirtualStock = Constants.NullInt;
        private int _TotalStock = Constants.NullInt;
        private int _CurrentStock = Constants.NullInt;
        private string _Comment = Constants.NullString;
        private string _FinancialYear = Constants.NullString;
        private string _CreatedBy = Constants.NullString;

        public void Save()
        {
            new AdminDataService_DC().SaveVirtualBook(this._BookCode, this._OpeningStock, this._VirtualStock, this._TotalStock, this._CurrentStock, this._Comment, this._FinancialYear, this._CreatedBy);
        }

        public string BookCode
        {
            get
            {
                return this._BookCode;
            }
            set
            {
                this._BookCode = value;
            }
        }

        public int OpeningStock
        {
            get
            {
                return this._OpeningStock;
            }
            set
            {
                this._OpeningStock = value;
            }
        }

        public int VirtualStock
        {
            get
            {
                return this._VirtualStock;
            }
            set
            {
                this._VirtualStock = value;
            }
        }

        public int TotalStock
        {
            get
            {
                return this._TotalStock;
            }
            set
            {
                this._TotalStock = value;
            }
        }

        public int CurrentStock
        {
            get
            {
                return this._CurrentStock;
            }
            set
            {
                this._CurrentStock = value;
            }
        }

        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                this._Comment = value;
            }
        }

        public string FinancialYear
        {
            get
            {
                return this._FinancialYear;
            }
            set
            {
                this._FinancialYear = value;
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
    }
}

