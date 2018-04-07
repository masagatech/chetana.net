namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Rolemaster
    {
        private int _RoleId = Constants.NullInt;
        private string _RoleName = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;

        public static DataTable Get_RoleList()
        {
            DataSet set = new DataSet();
            set = new AdminDataService().Get_RoleList();
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataSet Get_RoleMaster()
        {
            return new AdminDataService().GetRoleMaster();
        }

        public void Save()
        {
            new AdminDataService().Saverolemaster(this._RoleId, this._RoleName, this._IsActive, this._IsDeleted);
        }

        public int RoleId
        {
            get
            {
                return this._RoleId;
            }
            set
            {
                this._RoleId = value;
            }
        }

        public string RoleName
        {
            get
            {
                return this._RoleName;
            }
            set
            {
                this._RoleName = value;
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
    }
}

