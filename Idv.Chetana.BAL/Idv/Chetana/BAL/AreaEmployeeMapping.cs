namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class AreaEmployeeMapping
    {
        private int _EAmappingID = Constants.NullInt;
        private int _EmpID = Constants.NullInt;
        private int _AreaID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;

        public static DataSet Get_EmployeeArea_Mapping(int Empid)
        {
            return new AdminDataService().Get_EmployeeArea_Mapping(Empid);
        }

        public void Save()
        {
            new AdminDataService().SaveAreaEmployee_Mapping(this._EAmappingID, this._EmpID, this._AreaID, this._IsActive);
        }

        public int EAmappingID
        {
            get
            {
                return this._EAmappingID;
            }
            set
            {
                this._EAmappingID = value;
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
    }
}

