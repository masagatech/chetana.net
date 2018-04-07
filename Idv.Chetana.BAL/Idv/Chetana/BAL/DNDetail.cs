namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class DNDetail
    {
        private int _DNDetailID = Constants.NullInt;
        private int _DNMasterID = Constants.NullInt;
        private string _AccountCode = Constants.NullString;
        private decimal _DebitAmount = Constants.NullDecimal;
        private decimal _CreditAmount = Constants.NullDecimal;
        private string _Remarks = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsDeleted = Constants.NullBoolean;
        private int _strFY = Constants.NullInt;
        private string _Flag = Constants.NullString;
        private int _ID = Constants.NullInt;

        public void deleteDNRec()
        {
            new AdminDataService_DC().DeleteDNRecord(this._Flag, this._ID, this._IsActive, this._IsDeleted);
        }

        public static DataSet GetDN(int DocNo, int strFY)
        {
            return new AdminDataService_DC().GetDN(DocNo, strFY);
        }

        public static DataSet RepGetDN(int DocNo, int strFY)
        {
            return new AdminDataService_DC().RepGetDN(DocNo, strFY);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveDNDetail(this._DNDetailID, this._DNMasterID, this._AccountCode, this._DebitAmount, this._CreditAmount, this._Remarks, this._IsActive, this._CreatedBy, this._UpdatedBy, this._strFY);
        }

        public int DNDetailID
        {
            get
            {
                return this._DNDetailID;
            }
            set
            {
                this._DNDetailID = value;
            }
        }

        public int DNMasterID
        {
            get
            {
                return this._DNMasterID;
            }
            set
            {
                this._DNMasterID = value;
            }
        }

        public string AccountCode
        {
            get
            {
                return this._AccountCode;
            }
            set
            {
                this._AccountCode = value;
            }
        }

        public decimal DebitAmount
        {
            get
            {
                return this._DebitAmount;
            }
            set
            {
                this._DebitAmount = value;
            }
        }

        public decimal CreditAmount
        {
            get
            {
                return this._CreditAmount;
            }
            set
            {
                this._CreditAmount = value;
            }
        }

        public string Remarks
        {
            get
            {
                return this._Remarks;
            }
            set
            {
                this._Remarks = value;
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

        public string Flag
        {
            get
            {
                return this._Flag;
            }
            set
            {
                this._Flag = value;
            }
        }

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public int strFY
        {
            get
            {
                return this._strFY;
            }
            set
            {
                this._strFY = value;
            }
        }
    }
}

