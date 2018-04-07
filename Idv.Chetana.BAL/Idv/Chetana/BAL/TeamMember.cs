namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;

    public class TeamMember
    {
        private int _TMBID = Constants.NullInt;
        private string _TeamGrpID = Constants.NullString;
        private string _TNAME = Constants.NullString;
        private string _EmpID = Constants.NullString;
        private bool _CIsActive = Constants.NullBoolean;
        private bool _CIsDeleted = Constants.NullBoolean;
        private string _CCreatedBy = Constants.NullString;
        private string _CUpdatedBy = Constants.NullString;

        public void CSave()
        {
            new AdminDataService().SaveTeamMember(this._TMBID, this._TeamGrpID, this._TNAME, this._EmpID, this._CIsActive, this._CIsDeleted, this._CCreatedBy, this._CUpdatedBy);
        }

        public int TMBID
        {
            get
            {
                return this._TMBID;
            }
            set
            {
                this._TMBID = value;
            }
        }

        public string TeamGrpID
        {
            get
            {
                return this._TeamGrpID;
            }
            set
            {
                this._TeamGrpID = value;
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

        public string EmpID
        {
            get
            {
                return this._EmpID;
            }
            set
            {
                this._EmpID = value;
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

