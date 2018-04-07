namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class TeamMaster
    {
        private int _TMID = Constants.NullInt;
        private string _TNAME = Constants.NullString;
        private string _TDESC = Constants.NullString;
        private bool _CIsActive = Constants.NullBoolean;
        private bool _CIsDeleted = Constants.NullBoolean;
        private string _CCreatedBy = Constants.NullString;
        private string _CUpdatedBy = Constants.NullString;

        public void CSave()
        {
            new AdminDataService().SaveTeamMaster(this._TMID, this._TNAME, this._TDESC, this._CIsActive, this._CIsDeleted, this._CCreatedBy, this._CUpdatedBy);
        }

        public static DataSet GetTeamMaster(string flag)
        {
            return new AdminDataService().TeamMaster(flag);
        }

        public int TMID
        {
            get
            {
                return this._TMID;
            }
            set
            {
                this._TMID = value;
            }
        }

        public string TNAME
        {
            get
            {
                return this._TNAME;
            }
            set
            {
                this._TNAME = value;
            }
        }

        public string TDESC
        {
            get
            {
                return this._TDESC;
            }
            set
            {
                this._TDESC = value;
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
    }
}

