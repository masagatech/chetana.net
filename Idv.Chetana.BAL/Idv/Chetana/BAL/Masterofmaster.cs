namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Masterofmaster
    {
        private int _AutoId = Constants.NullInt;
        private string _key = Constants.NullString;
        private string _Value = Constants.NullString;
        private string _Group = Constants.NullString;
        private string _Description = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private int _BKID = Constants.NullInt;

        public static DataSet Get_MasterOfMaster()
        {
            return new AdminDataService().GetMasterOfMaster();
        }

        public static DataSet Get_MasterOfMaster_ByGroup(string Group)
        {
            return new AdminDataService().Get_MasterOfMaster_ByGroup(Group);
        }

        public static DataSet Get_MasterOfMaster_ByGroup_ForDropdown(string Group, string Flag2)
        {
            return new AdminDataService().Get_MasterOfMaster_ByGroup_ForDropdown(Group, Flag2);
        }

        public static DataSet GetBookKind(string flag)
        {
            return new AdminDataService().GetBookKind(flag);
        }

        public void Save()
        {
            new AdminDataService().Savemasterofmaster(this._AutoId, this._key, this._Value, this._Group, this._Description, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._BKID);
        }

        public int AutoId
        {
            get
            {
                return this._AutoId;
            }
            set
            {
                this._AutoId = value;
            }
        }

        public string key
        {
            get
            {
                return this._key;
            }
            set
            {
                this._key = value;
            }
        }

        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }

        public string Group
        {
            get
            {
                return this._Group;
            }
            set
            {
                this._Group = value;
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

