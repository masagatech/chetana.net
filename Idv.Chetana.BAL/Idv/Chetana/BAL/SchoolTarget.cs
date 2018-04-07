namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class SchoolTarget
    {
        private int _AutoID = Constants.NullInt;
        private int _CustID = Constants.NullInt;
        private string _CustCode = Constants.NullString;
        private string _CurrentYrTarget = Constants.NullString;
        private string _Achieved = Constants.NullString;
        private string _NextYrtarget = Constants.NullString;
        private string _FinancialYearFrom = Constants.NullString;
        private string _FinancialYearTo = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _Createdby = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _SchoolPotential = Constants.NullString;
        private int _FY = Constants.NullInt;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private string _Remark3 = Constants.NullString;
        private string _Remark4 = Constants.NullString;
        private string _Remark5 = Constants.NullString;
        private int _ZoneID = Constants.NullInt;
        private int _SuperZoneID = Constants.NullInt;

        public static DataSet Get_Report_SchoolWise_Target(int SuperZone, int Zone, int FY, string flag)
        {
            return new AdminDataService_DC().Get_Report_SchoolWise_Target(SuperZone, Zone, FY, flag);
        }

        public void Idv_Chetana_Update_TargetMaster_nd_Details()
        {
            new AdminDataService_DC().Idv_Chetana_Update_TargetMaster_nd_Details(this._FY, this._Createdby);
        }

        public string Save()
        {
            return new AdminDataService_DC().Save_SchoolwiseTarget(this._AutoID, this._CustCode, this._CurrentYrTarget, this._Achieved, this._NextYrtarget, this._SchoolPotential, this._FY, this._IsActive, this._IsDeleted, this._Createdby, this._Remark1, this._Remark2, this._Remark3, this._Remark4, this._Remark5, this._ZoneID, this._SuperZoneID);
        }

        public string Save(int FY)
        {
            return new AdminDataService_DC().Save_SchoolwiseTarget(this._AutoID, this._CustCode, this._CurrentYrTarget, this._Achieved, this._NextYrtarget, this._SchoolPotential, this._FY, this._IsActive, this._IsDeleted, this._Createdby, this._Remark1, this._Remark2, this._Remark3, this._Remark4, this._Remark5, this._ZoneID, this._SuperZoneID);
        }

        public int AutoID
        {
            get
            {
                return this._AutoID;
            }
            set
            {
                this._AutoID = value;
            }
        }

        public int CustID
        {
            get
            {
                return this._CustID;
            }
            set
            {
                this._CustID = value;
            }
        }

        public string CustCode
        {
            get
            {
                return this._CustCode;
            }
            set
            {
                this._CustCode = value;
            }
        }

        public string CurrentYrTarget
        {
            get
            {
                return this._CurrentYrTarget;
            }
            set
            {
                this._CurrentYrTarget = value;
            }
        }

        public string Achieved
        {
            get
            {
                return this._Achieved;
            }
            set
            {
                this._Achieved = value;
            }
        }

        public string NextYrtarget
        {
            get
            {
                return this._NextYrtarget;
            }
            set
            {
                this._NextYrtarget = value;
            }
        }

        public string FinancialYearFrom
        {
            get
            {
                return this._FinancialYearFrom;
            }
            set
            {
                this._FinancialYearFrom = value;
            }
        }

        public string FinancialYearTo
        {
            get
            {
                return this._FinancialYearTo;
            }
            set
            {
                this._FinancialYearTo = value;
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

        public string Createdby
        {
            get
            {
                return this._Createdby;
            }
            set
            {
                this._Createdby = value;
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

        public string SchoolPotential
        {
            get
            {
                return this._SchoolPotential;
            }
            set
            {
                this._SchoolPotential = value;
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
    }
}

