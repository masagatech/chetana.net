namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class TargetMaster
    {
        private int _TargetdetailsId = Constants.NullInt;
        private int _TargetId = Constants.NullInt;
        private int _TargetPersonId = Constants.NullInt;
        private int _FY = Constants.NullInt;
        private decimal _TargetAmt = Constants.NullDecimal;
        private DateTime _TargetStartDate = Constants.NullDateTime;
        private DateTime _TargetEndDate = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;

        public static DataTable Get_AllocateKRA(string EmpCode)
        {
            DataSet set = new AdminDataService().Get_AllocateKRA(EmpCode);
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataTable Get_AllocateKRA(string EmpCode, int FY, string Flag)
        {
            DataSet set = new AdminDataService().Get_AllocateKRA(EmpCode, FY, Flag);
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataSet Get_Employee_onUserLogin(string Empcode, string Flag)
        {
            return new AdminDataService().Get_Employee_onUserLogin(Empcode, Flag);
        }

        public static string get_Target_validateh_valid(int empid, string flag1)
        {
            DataTable table = new DataTable();
            table = new AdminDataService().get_Target_validateh_valid(empid, flag1).Tables[0];
            if (table.Rows.Count > 0)
            {
                return table.Rows[0][0].ToString();
            }
            return "not set!";
        }

        public static DataTable Get_TargetMaster(int FY)
        {
            DataSet set = new AdminDataService().Get_TargetMaster(FY);
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public void Save()
        {
            new AdminDataService().SaveTarget(this._TargetId, this._TargetPersonId, this._TargetAmt, this._FY, this._TargetStartDate, this._TargetEndDate, this._CreatedBy, this._IsActive);
        }

        public void SaveAllocate()
        {
            new AdminDataService().SaveAllocate(this._TargetdetailsId, this._TargetId, this._TargetPersonId, this._TargetAmt, this._FY, this._TargetStartDate, this._TargetEndDate, this._CreatedBy, this._IsActive);
        }

        public int TargetdetailsId
        {
            get
            {
                return this._TargetdetailsId;
            }
            set
            {
                this._TargetdetailsId = value;
            }
        }

        public int TargetId
        {
            get
            {
                return this._TargetId;
            }
            set
            {
                this._TargetId = value;
            }
        }

        public int TargetPersonId
        {
            get
            {
                return this._TargetPersonId;
            }
            set
            {
                this._TargetPersonId = value;
            }
        }

        public int FY
        {
            get
            {
                return this._FY;
            }
            set
            {
                this._FY = value;
            }
        }

        public decimal TargetAmt
        {
            get
            {
                return this._TargetAmt;
            }
            set
            {
                this._TargetAmt = value;
            }
        }

        public DateTime TargetStartDate
        {
            get
            {
                return this._TargetStartDate;
            }
            set
            {
                this._TargetStartDate = value;
            }
        }

        public DateTime TargetEndDate
        {
            get
            {
                return this._TargetEndDate;
            }
            set
            {
                this._TargetEndDate = value;
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

