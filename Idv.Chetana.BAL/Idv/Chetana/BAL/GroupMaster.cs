namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class GroupMaster
    {
        private int _GrpID = Constants.NullInt;
        private string _GrpCode = Constants.NullString;
        private string _GrpName = Constants.NullString;
        private string _Remark = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _Updatedon = Constants.NullDateTime;

        public static DataSet GetGroupmaster(string Flag)
        {
            return new AdminDataService().GetGroupmaster(Flag);
        }

        public void Save()
        {
            new AdminDataService().SaveGroupMaster(this._GrpID, this._GrpCode, this._GrpName, this._Remark, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int GrpID
        {
            get
            {
                return this._GrpID;
            }
            set
            {
                this._GrpID = value;
            }
        }

        public string GrpCode
        {
            get
            {
                return this._GrpCode;
            }
            set
            {
                this._GrpCode = value;
            }
        }

        public string GrpName
        {
            get
            {
                return this._GrpName;
            }
            set
            {
                this._GrpName = value;
            }
        }

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
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

        public DateTime Updatedon
        {
            get
            {
                return this._Updatedon;
            }
            set
            {
                this._Updatedon = value;
            }
        }
    }
}

