namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class UserLoginDetails
    {
        private int _AutoId = Constants.NullInt;
        private int _EmpID = Constants.NullInt;
        private int _RoleID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private string _Password = Constants.NullString;
        private bool _IsBlocked = Constants.NullBoolean;
        private bool _IsSysAdmin = Constants.NullBoolean;

        public static string Get_UserLogin(string EmpCode, string Password)
        {
            DataTable table = new DataTable();
            table = new AdminDataService().Get_UserLogin(EmpCode, Password).Tables[0];
            if (table.Rows.Count > 0)
            {
                if (table.Rows[0]["Password"].ToString() == Password)
                {
                    return table.Rows[0]["RoleID"].ToString();
                }
                return Convert.ToString(0);
            }
            return Convert.ToString(0);
        }

        public static DataTable Get_UserLoginDetails(string EmpCode)
        {
            DataTable table = new DataTable();
            return new AdminDataService().Get_UserLoginDetails(EmpCode).Tables[0];
        }

        public void Save()
        {
            this.Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new AdminDataService().SaveUserLoginDetails(this._AutoId, this._EmpID, this._RoleID, this._IsActive, this._Password, this._IsSysAdmin);
        }

        public void Update_UserLog()
        {
            new AdminDataService().UpdateUserlog(this._EmpID, this._IsBlocked);
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

        public int EmpID
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

        public int RoleID
        {
            get
            {
                return this._RoleID;
            }
            set
            {
                this._RoleID = value;
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

        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
            }
        }

        public bool IsBlocked
        {
            get
            {
                return this._IsBlocked;
            }
            set
            {
                this._IsBlocked = value;
            }
        }

        public bool IsSysAdmin
        {
            get
            {
                return this._IsSysAdmin;
            }
            set
            {
                this._IsSysAdmin = value;
            }
        }
    }
}

