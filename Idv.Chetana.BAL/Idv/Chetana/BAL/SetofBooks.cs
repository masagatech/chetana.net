namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class SetofBooks
    {
        private int _BooksetDetailID = Constants.NullInt;
        private int _BookSetCode = Constants.NullInt;
        private string _BookCode = Constants.NullString;
        private int _Quantity = Constants.NullInt;
        private decimal _SellingPrice = Constants.NullDecimal;
        private decimal _OMPrice = Constants.NullDecimal;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;

        public static DataSet GetBooksetdetails_ByBooksetID(int BookSetID)
        {
            return new AdminDataService().GetBooksetdetails_ByBooksetID(BookSetID);
        }

        public void Save()
        {
            new AdminDataService().SaveSetofbooks(this._BooksetDetailID, this._BookSetCode, this._BookCode, this._Quantity, this._SellingPrice, this._OMPrice, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int BooksetDetailID
        {
            get
            {
                return this._BooksetDetailID;
            }
            set
            {
                this._BooksetDetailID = value;
            }
        }

        public int BookSetCode
        {
            get
            {
                return this._BookSetCode;
            }
            set
            {
                this._BookSetCode = value;
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

        public int Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this._Quantity = value;
            }
        }

        public decimal SellingPrice
        {
            get
            {
                return this._SellingPrice;
            }
            set
            {
                this._SellingPrice = value;
            }
        }

        public decimal OMPrice
        {
            get
            {
                return this._OMPrice;
            }
            set
            {
                this._OMPrice = value;
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
    }
}

