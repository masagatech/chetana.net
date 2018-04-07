namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class ZoneMaster
    {
        private int _ZoneID = Constants.NullInt;
        private int _Flag = Constants.NullInt;
        private string _ZoneCode = Constants.NullString;
        private string _ZoneName = Constants.NullString;
        private int _SuperZoneID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;

        public static DataTable GetZoneMaster()
        {
            return new AdminDataService().GetZoneMaster().Tables[0];
        }

        public void Save()
        {
            new AdminDataService().SaveZoneMaster(this._ZoneID, this._ZoneCode, this._ZoneName, this._SuperZoneID, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
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

        public int Flag
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

        public string ZoneCode
        {
            get
            {
                return this._ZoneCode;
            }
            set
            {
                this._ZoneCode = value;
            }
        }

        public string ZoneName
        {
            get
            {
                return this._ZoneName;
            }
            set
            {
                this._ZoneName = value;
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

