namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Company
    {
        private int _CompanyID = Constants.NullInt;
        private string _CompanyCode = Constants.NullString;
        private string _CompanyName = Constants.NullString;
        private string _CompanyShortform = Constants.NullString;
        private string _Address = Constants.NullString;
        private int _AreaID = Constants.NullInt;
        private int _CityID = Constants.NullInt;
        private string _Zip = Constants.NullString;
        private string _Phone1 = Constants.NullString;
        private string _Phone2 = Constants.NullString;
        private string _EmailID = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _Flag = Constants.NullString;
        private int _ID = Constants.NullInt;

        public void delete()
        {
            new AdminDataService().DeleteRecord(this._Flag, this._ID, this._IsActive, this._IsDeleted);
        }

        public static DataSet GetCompanyMaster()
        {
            return new AdminDataService().GetCompanyMaster();
        }

        public void Save()
        {
            new AdminDataService().SaveCompanyMaster(this._CompanyID, this._CompanyCode, this._CompanyName, this._CompanyShortform, this._Address, this._AreaID, this._CityID, this._Zip, this._Phone1, this._Phone2, this._EmailID, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int CompanyID
        {
            get
            {
                return this._CompanyID;
            }
            set
            {
                this._CompanyID = value;
            }
        }

        public string CompanyCode
        {
            get
            {
                return this._CompanyCode;
            }
            set
            {
                this._CompanyCode = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                this._CompanyName = value;
            }
        }

        public string CompanyShortform
        {
            get
            {
                return this._CompanyShortform;
            }
            set
            {
                this._CompanyShortform = value;
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

        public int CityID
        {
            get
            {
                return this._CityID;
            }
            set
            {
                this._CityID = value;
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

        public string Flag
        {
            get
            {
                return this._Flag;
            }
            set
            {
                this._Flag = value;
            }
        }

        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }
    }
}

