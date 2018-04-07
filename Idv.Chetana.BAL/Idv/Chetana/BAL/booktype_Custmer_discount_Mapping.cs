namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class booktype_Custmer_discount_Mapping
    {
        private int _BKTYPCustDisID = Constants.NullInt;
        private string _Custcode = Constants.NullString;
        private int _BookType = Constants.NullInt;
        private decimal _Discount = Constants.NullDecimal;
        private decimal _AdditionalDiscount = Constants.NullDecimal;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;

        public static DataSet Get_AddDiscount_On_Cusomer(string CustCode)
        {
            return new AdminDataService().Get_AddDiscount_On_Cusomer(CustCode);
        }

        public static DataSet Get_CustomerDiscountBy_BookType(string Custcode)
        {
            return new AdminDataService().Get_CustomerDiscountBy_BookType(Custcode);
        }

        public void Save()
        {
            new AdminDataService().Save_booktype_Custmer_discount_Mapping(this._BKTYPCustDisID, this._Custcode, this._BookType, this._Discount, this._AdditionalDiscount, this._IsActive, this._IsDeleted);
        }

        public int BKTYPCustDisID
        {
            get
            {
                return this._BKTYPCustDisID;
            }
            set
            {
                this._BKTYPCustDisID = value;
            }
        }

        public string Custcode
        {
            get
            {
                return this._Custcode;
            }
            set
            {
                this._Custcode = value;
            }
        }

        public int BookType
        {
            get
            {
                return this._BookType;
            }
            set
            {
                this._BookType = value;
            }
        }

        public decimal Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this._Discount = value;
            }
        }

        public decimal AdditionalDiscount
        {
            get
            {
                return this._AdditionalDiscount;
            }
            set
            {
                this._AdditionalDiscount = value;
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
    }
}

