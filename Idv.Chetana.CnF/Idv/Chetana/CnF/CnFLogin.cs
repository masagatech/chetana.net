namespace Idv.Chetana.CnF
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CnFLogin : DataServiceBase
    {
        private int _AutoId = Constants.NullInt;
        private string _EmpID = Constants.NullString;
        private int _CnFId = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private string _Password = Constants.NullString;
        private bool _IsBlocked = Constants.NullBoolean;
        private bool _IsSysAdmin = Constants.NullBoolean;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private string _Remark3 = Constants.NullString;
        private string _Remark4 = Constants.NullString;
        private string _Remark5 = Constants.NullString;

        public static DataSet GetCnF_Login(string Flag, string Flag1)
        {
            return new CnFLogin().GetCnFLogin(Flag, Flag1);
        }

        public DataSet GetCnFLogin(string Flag, string Flag1)
        {
            return base.ExecuteDataSet("C_Idv_Chetana_GetCnFLoginDetails", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@Flag1", SqlDbType.NVarChar, Flag1) });
        }

        public void SaveCnF_UserLoginDetails()
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "C_Idv_Chetana_SaveCnFUserLoginDetails", new IDataParameter[] { base.CreateParameter("@AutoId", SqlDbType.Int, this._AutoId), base.CreateParameter("@EmpID", SqlDbType.NVarChar, this._EmpID), base.CreateParameter("@CnFId", SqlDbType.Int, this._CnFId), base.CreateParameter("@IsActive", SqlDbType.Bit, this._IsActive), base.CreateParameter("@Password", SqlDbType.NVarChar, this._Password), base.CreateParameter("@IsSysadmin", SqlDbType.Bit, this._IsSysAdmin) });
            command.Dispose();
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

        public int CnFId
        {
            get
            {
                return this._CnFId;
            }
            set
            {
                this._CnFId = value;
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

        public string Remark1
        {
            get
            {
                return this._Remark1;
            }
            set
            {
                this._Remark1 = value;
            }
        }

        public string Remark2
        {
            get
            {
                return this._Remark2;
            }
            set
            {
                this._Remark2 = value;
            }
        }

        public string Remark3
        {
            get
            {
                return this._Remark3;
            }
            set
            {
                this._Remark3 = value;
            }
        }

        public string Remark4
        {
            get
            {
                return this._Remark4;
            }
            set
            {
                this._Remark4 = value;
            }
        }

        public string Remark5
        {
            get
            {
                return this._Remark5;
            }
            set
            {
                this._Remark5 = value;
            }
        }
    }
}

