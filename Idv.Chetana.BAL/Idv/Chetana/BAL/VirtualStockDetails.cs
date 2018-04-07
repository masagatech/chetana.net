namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class VirtualStockDetails
    {
        private int _DetailID = Constants.NullInt;
        private int _VMasterID = Constants.NullInt;
        private string _BookCode = Constants.NullString;
        private string _BookName = Constants.NullString;
        private int _Quantity = Constants.NullInt;
        private string _Standard = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private int _FY = Constants.NullInt;

        public static DataSet Get_VirtualStockDatails(int InvoiceNo, int FY)
        {
            return new AdminDataService().Get_VirtualStockDatails(InvoiceNo, FY);
        }

        public void Save()
        {
            new AdminDataService().SaveDetails(this._DetailID, this._VMasterID, this._BookCode, this._BookName, this._Quantity, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._Standard, this._FY);
        }

        public int DetailID
        {
            get
            {
                return this._DetailID;
            }
            set
            {
                this._DetailID = value;
            }
        }

        public int VMasterID
        {
            get
            {
                return this._VMasterID;
            }
            set
            {
                this._VMasterID = value;
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

        public string BookName
        {
            get
            {
                return this._BookName;
            }
            set
            {
                this._BookName = value;
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

        public int FY
        {
            get
            {
                return this._FY;
            }
            set
            {
                this._FY = value;
            }
        }
    }
}

