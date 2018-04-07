namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class AreaMaster
    {
        private int _AreaID = Constants.NullInt;
        private string _AreaCode = Constants.NullString;
        private string _AreaName = Constants.NullString;
        private int _AreaZoneID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;

        public static DataTable GetAreaMaster()
        {
            DataSet areaMaster = new DataSet();
            areaMaster = new AdminDataService().GetAreaMaster();
            DataTable table = new DataTable();
            return areaMaster.Tables[0];
        }

        public void Save()
        {
            new AdminDataService().SaveAreaMaster(this._AreaID, this._AreaCode, this._AreaZoneID, this._AreaName, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int AreaID
        {
            get
            {
                return this._AreaID;
            }
            set
            {
                this._AreaID = value;
            }
        }

        public string AreaCode
        {
            get
            {
                return this._AreaCode;
            }
            set
            {
                this._AreaCode = value;
            }
        }

        public string AreaName
        {
            get
            {
                return this._AreaName;
            }
            set
            {
                this._AreaName = value;
            }
        }

        public int AreaZoneID
        {
            get
            {
                return this._AreaZoneID;
            }
            set
            {
                this._AreaZoneID = value;
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
    }
}

