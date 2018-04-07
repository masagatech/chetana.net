namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class BookKind
    {
        private int _BMID = Constants.NullInt;
        private string _Name = Constants.NullString;
        private int _ParentID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _BMCode = Constants.NullString;
        private int _BKID = Constants.NullInt;

        public static DataSet GetBookKind(string flag)
        {
            return new AdminDataService().GetBookKind(flag);
        }

        public void Save()
        {
            new AdminDataService().SaveBookKindmaster(this._BMID, this._Name, this._ParentID, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._BMCode);
        }

        public int BMID
        {
            get
            {
                return this._BMID;
            }
            set
            {
                this._BMID = value;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public int ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this._ParentID = value;
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

        public string BMCode
        {
            get
            {
                return this._BMCode;
            }
            set
            {
                this._BMCode = value;
            }
        }

        public int BKID
        {
            get
            {
                return this._BKID;
            }
            set
            {
                this._BKID = value;
            }
        }
    }
}

