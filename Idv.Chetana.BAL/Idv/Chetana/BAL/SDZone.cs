namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class SDZone
    {
        private int _SDZoneID = Constants.NullInt;
        private string _SDZoneCode = Constants.NullString;
        private string _SDZoneName = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;

        public static DataTable GetSDZonemaster()
        {
            DataSet sDZonemaster = new DataSet();
            sDZonemaster = new AdminDataService().GetSDZonemaster();
            DataTable table = new DataTable();
            return sDZonemaster.Tables[0];
        }

        public void Save()
        {
            new AdminDataService().SaveSDZoneMaster(this._SDZoneID, this._SDZoneCode, this._SDZoneName, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int SDZoneID
        {
            get
            {
                return this._SDZoneID;
            }
            set
            {
                this._SDZoneID = value;
            }
        }

        public string SDZoneCode
        {
            get
            {
                return this._SDZoneCode;
            }
            set
            {
                this._SDZoneCode = value;
            }
        }

        public string SDZoneName
        {
            get
            {
                return this._SDZoneName;
            }
            set
            {
                this._SDZoneName = value;
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

