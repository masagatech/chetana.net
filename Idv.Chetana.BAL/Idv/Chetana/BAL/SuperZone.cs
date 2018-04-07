namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class SuperZone
    {
        private int _SuperZoneID = Constants.NullInt;
        private string _SuperZoneCode = Constants.NullString;
        private string _SuperZoneName = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private int _SDZoneID = Constants.NullInt;
        private string _SEmailID = Constants.NullString;

        public static DataTable GetSuperzonemaster()
        {
            DataSet superzonemaster = new DataSet();
            superzonemaster = new AdminDataService().GetSuperzonemaster();
            DataTable table = new DataTable();
            return superzonemaster.Tables[0];
        }

        public void Save()
        {
            new AdminDataService().SaveSuperZoneMaster(this._SuperZoneID, this._SuperZoneCode, this._SuperZoneName, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._SEmailID, this._SDZoneID);
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

        public int SuperZoneID
        {
            get
            {
                return this._SuperZoneID;
            }
            set
            {
                this._SuperZoneID = value;
            }
        }

        public string SEmailID
        {
            get
            {
                return this._SEmailID;
            }
            set
            {
                this._SEmailID = value;
            }
        }

        public string SuperZoneCode
        {
            get
            {
                return this._SuperZoneCode;
            }
            set
            {
                this._SuperZoneCode = value;
            }
        }

        public string SuperZoneName
        {
            get
            {
                return this._SuperZoneName;
            }
            set
            {
                this._SuperZoneName = value;
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

