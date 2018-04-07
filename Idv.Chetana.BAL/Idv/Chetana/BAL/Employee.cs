namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class Employee
    {
        private string _EmpCode = Constants.NullString;
        private string _FirstName = Constants.NullString;
        private string _MiddleName = Constants.NullString;
        private string _LastName = Constants.NullString;
        private string _Address = Constants.NullString;
        private string _City = Constants.NullString;
        private string _Zip = Constants.NullString;
        private string _Phone1 = Constants.NullString;
        private string _Phone2 = Constants.NullString;
        private string _Gender = Constants.NullString;
        private string _DOB = Constants.NullString;
        private string _Qualification = Constants.NullString;
        private string _Designation = Constants.NullString;
        private string _EmailID = Constants.NullString;
        private string _DepartmentID = Constants.NullString;
        private int _ZoneID = Constants.NullInt;
        private int _SuperZoneID = Constants.NullInt;
        private int _AreaZoneID = Constants.NullInt;
        private int _AreaID = Constants.NullInt;
        private string _state = Constants.NullString;
        private string _Photo = Constants.NullString;
        private DateTime _JoinDate = Constants.NullDateTime;
        private DateTime _ResignationDate = Constants.NullDateTime;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private int _EmpID = Constants.NullInt;
        private int _EId = Constants.NullInt;
        private int _SDZoneID = Constants.NullInt;
        private int _teamautid = Constants.NullInt;
        private int _teamid = Constants.NullInt;
        private int _empid = Constants.NullInt;

        public static DataSet Get_DocumentNO(string EmpCode)
        {
            return new AdminDataService().Get_DocumentNO(EmpCode);
        }

        public static DataTable Get_EmpList()
        {
            DataSet set = new DataSet();
            set = new AdminDataService().Get_EmpList();
            DataTable table = new DataTable();
            return set.Tables[0];
        }

        public static DataTable Get_EmpList(string flag, string id, string flag1)
        {
            return new AdminDataService().Get_EmpList(flag, id, flag1).Tables[0];
        }

        public static DataSet Get_EmployeeMaster()
        {
            return new AdminDataService().GetEmployeemaster();
        }

        public static int Get_EmployeeMaster_MaxId(out int MaxEmployeeId)
        {
            return new AdminDataService_DC().Get_EmployeeMaster_MaxId(out MaxEmployeeId);
        }

        public static DataSet Get_EmployeeName(string EmpCode)
        {
            return new AdminDataService().Get_EmployeeName(EmpCode);
        }

        public static DataSet Get_EmployeeOnAreaWise(string EmpCode)
        {
            return new AdminDataService().GetEmployeeOnAreaWise(EmpCode);
        }

        public static DataSet GetEmployeeByFlag(int Flag)
        {
            return new AdminDataService().GetEmployeeByFlag(Flag);
        }

        public void Save(out int _EId)
        {
            this.Save(null, out _EId);
        }

        public void Save(IDbTransaction txn, out int _EId)
        {
            new AdminDataService().SaveEmployee(this._EmpCode, this._FirstName, this._MiddleName, this._LastName, this._Address, this._City, this._Zip, this._Phone1, this._Phone2, this._Gender, this._DOB, this._Qualification, this._Designation, this._EmailID, this._DepartmentID, this._ZoneID, this._SuperZoneID, this._AreaZoneID, this._AreaID, this._state, this._Photo, this._JoinDate, this._ResignationDate, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy, this._EmpID, this._SDZoneID, out _EId);
        }

        public void saveTeam(out int _teamautidO)
        {
            new AdminDataService().save_team(this._teamautid, this._teamid, this._empid, this._IsActive, out _teamautidO);
        }

        public void Update()
        {
            this.Update(null);
        }

        public void Update(IDbTransaction txn)
        {
            new AdminDataService(txn).UpdateEmployee(this._EmpID, this._EmpCode, this._FirstName, this._MiddleName, this._LastName, this._Address, this._City, this._Zip, this._Phone1, this._Phone2, this._Gender, this._DOB, this._Qualification, this._Designation, this._EmailID, this._DepartmentID, this._ZoneID, this._SuperZoneID, this._AreaZoneID, this._AreaID, this._state, this._Photo, this._JoinDate, this._ResignationDate, this._IsActive, this._IsDeleted, this._UpdatedBy, this._SDZoneID);
        }

        public int Teamautid
        {
            get
            {
                return this._teamautid;
            }
            set
            {
                this._teamautid = value;
            }
        }

        public int Teamid
        {
            get
            {
                return this._teamid;
            }
            set
            {
                this._teamid = value;
            }
        }

        public int Empid
        {
            get
            {
                return this._empid;
            }
            set
            {
                this._empid = value;
            }
        }

        public string EmpCode
        {
            get
            {
                return this._EmpCode;
            }
            set
            {
                this._EmpCode = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this._FirstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this._MiddleName;
            }
            set
            {
                this._MiddleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this._LastName = value;
            }
        }

        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }

        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this._City = value;
            }
        }

        public string Zip
        {
            get
            {
                return this._Zip;
            }
            set
            {
                this._Zip = value;
            }
        }

        public string Phone1
        {
            get
            {
                return this._Phone1;
            }
            set
            {
                this._Phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this._Phone2;
            }
            set
            {
                this._Phone2 = value;
            }
        }

        public string Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this._Gender = value;
            }
        }

        public string DOB
        {
            get
            {
                return this._DOB;
            }
            set
            {
                this._DOB = value;
            }
        }

        public string Qualification
        {
            get
            {
                return this._Qualification;
            }
            set
            {
                this._Qualification = value;
            }
        }

        public string Designation
        {
            get
            {
                return this._Designation;
            }
            set
            {
                this._Designation = value;
            }
        }

        public string EmailID
        {
            get
            {
                return this._EmailID;
            }
            set
            {
                this._EmailID = value;
            }
        }

        public string DepartmentID
        {
            get
            {
                return this._DepartmentID;
            }
            set
            {
                this._DepartmentID = value;
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

        public int AreaZoneID
        {
            get
            {
                return this.AreaZoneID;
            }
            set
            {
                this._AreaZoneID = value;
            }
        }

        public int AreaID
        {
            get
            {
                return this._AreaID;
            }
            set
            {
                this._AreaID = value;
            }
        }

        public string State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }

        public string Photo
        {
            get
            {
                return this._Photo;
            }
            set
            {
                this._Photo = value;
            }
        }

        public DateTime JoinDate
        {
            get
            {
                return this._JoinDate;
            }
            set
            {
                this._JoinDate = value;
            }
        }

        public DateTime ResignationDate
        {
            get
            {
                return this._ResignationDate;
            }
            set
            {
                this._ResignationDate = value;
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

        public int EId
        {
            get
            {
                return this._EId;
            }
            set
            {
                this._EId = value;
            }
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
    }
}

