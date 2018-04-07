namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class CustCategory
    {
        private int _CMID = Constants.NullInt;
        private string _CName = Constants.NullString;
        private int _CParentID = Constants.NullInt;
        private bool _CIsActive = Constants.NullBoolean;
        private bool _CIsDeleted = Constants.NullBoolean;
        private string _CCreatedBy = Constants.NullString;
        private string _CUpdatedBy = Constants.NullString;
        private string _CDMCode = Constants.NullString;

        public void CSave()
        {
            new AdminDataService().SaveCustomerCategoryMaster(this._CMID, this._CName, this._CParentID, this._CIsActive, this._CIsDeleted, this._CCreatedBy, this._CUpdatedBy, this._CDMCode);
        }

        public static DataSet GetCustomerCategoryMaster(string flag)
        {
            return new AdminDataService().GetCustomerCategoryMaster(flag);
        }

        public int CMID
        {
            get
            {
                return this._CMID;
            }
            set
            {
                this._CMID = value;
            }
        }

        public string CName
        {
            get
            {
                return this._CName;
            }
            set
            {
                this._CName = value;
            }
        }

        public int CParentID
        {
            get
            {
                return this._CParentID;
            }
            set
            {
                this._CParentID = value;
            }
        }

        public bool CIsActive
        {
            get
            {
                return this._CIsActive;
            }
            set
            {
                this._CIsActive = value;
            }
        }

        public bool CIsDeleted
        {
            get
            {
                return this._CIsDeleted;
            }
            set
            {
                this._CIsDeleted = value;
            }
        }

        public string CCreatedBy
        {
            get
            {
                return this._CCreatedBy;
            }
            set
            {
                this._CCreatedBy = value;
            }
        }

        public string CUpdatedBy
        {
            get
            {
                return this._CUpdatedBy;
            }
            set
            {
                this._CUpdatedBy = value;
            }
        }

        public string CDMCode
        {
            get
            {
                return this._CDMCode;
            }
            set
            {
                this._CDMCode = value;
            }
        }
    }
}

