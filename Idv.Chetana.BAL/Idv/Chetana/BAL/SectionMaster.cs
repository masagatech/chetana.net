namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class SectionMaster
    {
        private int _SectionID = Constants.NullInt;
        private string _Sectioncode = Constants.NullString;
        private string _SectionName = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;

        public static DataTable Get_SectionList()
        {
            DataSet sectionMaster = new DataSet();
            sectionMaster = new AdminDataService().GetSectionMaster();
            DataTable table = new DataTable();
            return sectionMaster.Tables[0];
        }

        public void Save()
        {
            new AdminDataService().SaveSectionMaster(this._SectionID, this._Sectioncode, this._SectionName, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int SectionID
        {
            get
            {
                return this._SectionID;
            }
            set
            {
                this._SectionID = value;
            }
        }

        public string Sectioncode
        {
            get
            {
                return this._Sectioncode;
            }
            set
            {
                this._Sectioncode = value;
            }
        }

        public string SectionName
        {
            get
            {
                return this._SectionName;
            }
            set
            {
                this._SectionName = value;
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

