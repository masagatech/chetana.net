namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class BrokerMaster
    {
        private int _BrokerID = Constants.NullInt;
        private string _BrokerCode = Constants.NullString;
        private string _FirstName = Constants.NullString;
        private string _MiddleName = Constants.NullString;
        private string _LastName = Constants.NullString;
        private string _Address = Constants.NullString;
        private string _Zip = Constants.NullString;
        private int _CityID = Constants.NullInt;
        private string _Phone1 = Constants.NullString;
        private string _Phone2 = Constants.NullString;
        private string _Gender = Constants.NullString;
        private string _DOB = Constants.NullString;
        private string _EmailID = Constants.NullString;
        private int _BrokerageRate = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;

        public static DataSet GetBrokerMaster()
        {
            return new AdminDataService_DC().GetBrokerMaster();
        }

        public void Save()
        {
            new AdminDataService_DC().SaveBrokerMaster(this._BrokerID, this._BrokerCode, this._FirstName, this._MiddleName, this._LastName, this._Address, this._Zip, this._CityID, this._Phone1, this._Phone2, this._Gender, this._DOB, this._EmailID, this._BrokerageRate, this._IsActive, this._IsDeleted, this._CreatedBy, this._UpdatedBy);
        }

        public int BrokerID
        {
            get
            {
                return this._BrokerID;
            }
            set
            {
                this._BrokerID = value;
            }
        }

        public string BrokerCode
        {
            get
            {
                return this._BrokerCode;
            }
            set
            {
                this._BrokerCode = value;
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

        public int BrokerageRate
        {
            get
            {
                return this._BrokerageRate;
            }
            set
            {
                this._BrokerageRate = value;
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
    }
}

