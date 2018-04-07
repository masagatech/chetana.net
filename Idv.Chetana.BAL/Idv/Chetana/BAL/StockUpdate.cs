namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class StockUpdate
    {
        private int _StockUpdateID = Constants.NullInt;
        private string _BookCode = Constants.NullString;
        private int _OldStock = Constants.NullInt;
        private int _NewStock = Constants.NullInt;
        private int _TotalStock = Constants.NullInt;
        private string _Comment = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;

        public static DataSet Get_Name(string Code, string flag)
        {
            return new AdminDataService_DC().Get_Name(Code, flag);
        }

        public static DataSet Get_StockReport()
        {
            return new AdminDataService().Get_StockReport();
        }

        public static DataSet GetStockUpdate()
        {
            return new AdminDataService_DC().GetStockUpdate();
        }

        public static DataSet GetStockUpdateRep(string BookCode)
        {
            return new AdminDataService_DC().GetStockUpdateRep(BookCode);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveStockUpdate(this._StockUpdateID, this._BookCode, this._OldStock, this._NewStock, this._TotalStock, this._Comment, this._CreatedBy, this._UpdatedBy);
        }

        public int StockUpdateID
        {
            get
            {
                return this._StockUpdateID;
            }
            set
            {
                this._StockUpdateID = value;
            }
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

        public int OldStock
        {
            get
            {
                return this._OldStock;
            }
            set
            {
                this._OldStock = value;
            }
        }

        public int NewStock
        {
            get
            {
                return this._NewStock;
            }
            set
            {
                this._NewStock = value;
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
    }
}

