namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Destination
    {
        private int _DMID = Constants.NullInt;
        private string _Name = Constants.NullString;
        private int _ParentID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _DMCode = Constants.NullString;

        public static DataSet GetDestination(string flag)
        {
            return new AdminDataService().GetDestination(flag);
        }

        public void Save()
        {
            new AdminDataService().Savedestinationmaster(this._DMID, this._Name, this._ParentID, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._DMCode);
        }

        public int DMID
        {
            get
            {
                return this._DMID;
            }
            set
            {
                this._DMID = value;
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

        public string DMCode
        {
            get
            {
                return this._DMCode;
            }
            set
            {
                this._DMCode = value;
            }
        }
    }
}

