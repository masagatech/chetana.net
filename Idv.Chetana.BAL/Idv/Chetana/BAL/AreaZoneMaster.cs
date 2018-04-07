namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class AreaZoneMaster
    {
        private int _AreaZoneID = Constants.NullInt;
        private string _AreaZoneCode = Constants.NullString;
        private string _AreaZoneName = Constants.NullString;
        private int _ZoneID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;

        public static DataTable GetAreaZoneMaster()
        {
            DataSet areazoneMaster = new DataSet();
            areazoneMaster = new AdminDataService().GetAreazoneMaster();
            DataTable table = new DataTable();
            return areazoneMaster.Tables[0];
        }

        public void Save()
        {
            new AdminDataService().SaveAreaZoneMaster(this._AreaZoneID, this._AreaZoneCode, this._AreaZoneName, this._ZoneID, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
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

        public string AreaZoneCode
        {
            get
            {
                return this._AreaZoneCode;
            }
            set
            {
                this._AreaZoneCode = value;
            }
        }

        public string AreaZoneName
        {
            get
            {
                return this._AreaZoneName;
            }
            set
            {
                this._AreaZoneName = value;
            }
        }

        public int ZoneID
        {
            get
            {
                return this._ZoneID;
            }
            set
            {
                this._ZoneID = value;
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
    }
}

