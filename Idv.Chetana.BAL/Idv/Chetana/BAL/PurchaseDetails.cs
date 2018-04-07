namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class PurchaseDetails
    {
        private int _PurchaseDetailId = Constants.NullInt;
        private int _PurchaseMasterID = Constants.NullInt;
        private string _Code = Constants.NullString;
        private string _Description = Constants.NullString;
        private int _Quantity = Constants.NullInt;
        private decimal _Rate = Constants.NullDecimal;
        private decimal _Discount = Constants.NullDecimal;
        private decimal _Amount = Constants.NullDecimal;
        private string _Per = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _Isdeleted = Constants.NullBoolean;
        private string _Standard = Constants.NullString;
        private int _OriQuantity = Constants.NullInt;
        private string _Remark = Constants.NullString;

        public void Delete()
        {
            new AdminDataService().DeletePurchaseDetails(this._PurchaseDetailId, this._IsActive, this._Isdeleted, this._Amount, this._Rate, this._Discount, this._Quantity, this._UpdatedBy);
        }

        public static DataSet GetPurchaseRegister(DateTime FromDate, DateTime ToDate, int FY, string ID, string Flag)
        {
            return new AdminDataService_DC().getPurchseRegister(FromDate, ToDate, FY, ID, Flag);
        }

        public void Save()
        {
            new AdminDataService().SavePurchaseDetails(this._PurchaseDetailId, this._PurchaseMasterID, this._Code, this._Description, this._Quantity, this._Rate, this._Amount, this._Discount, this._Per, this._IsActive, this._Isdeleted, this._CreatedBy, this._UpdatedBy, this._Standard);
        }

        public void Save(int id)
        {
            new AdminDataService().SavePurchaseDetails(this._PurchaseDetailId, this._PurchaseMasterID, this._Code, this._Description, this._Quantity, this._Rate, this._Amount, this._Discount, this._Per, this._IsActive, this._Isdeleted, this._CreatedBy, this._UpdatedBy, this._Standard, this._OriQuantity);
        }

        public void Update()
        {
            new AdminDataService().UpdatePurchaseDetails(this._PurchaseDetailId, this._PurchaseMasterID, this._Code, this._Description, this._Quantity, this._Rate, this._Amount, this._Discount, this._Per, this._IsActive, this._Isdeleted, this._CreatedBy, this._UpdatedBy, this._Standard, this._OriQuantity);
        }

        public int PurchaseDetailId
        {
            get
            {
                return this._PurchaseDetailId;
            }
            set
            {
                this._PurchaseDetailId = value;
            }
        }

        public int PurchaseMasterID
        {
            get
            {
                return this._PurchaseMasterID;
            }
            set
            {
                this._PurchaseMasterID = value;
            }
        }

        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
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

        public decimal Rate
        {
            get
            {
                return this._Rate;
            }
            set
            {
                this._Rate = value;
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

        public string Per
        {
            get
            {
                return this._Per;
            }
            set
            {
                this._Per = value;
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

        public bool Isdeleted
        {
            get
            {
                return this._Isdeleted;
            }
            set
            {
                this._Isdeleted = value;
            }
        }

        public string Standard
        {
            get
            {
                return this._Standard;
            }
            set
            {
                this._Standard = value;
            }
        }

        public int OriQuantity
        {
            get
            {
                return this._OriQuantity;
            }
            set
            {
                this._OriQuantity = value;
            }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}

