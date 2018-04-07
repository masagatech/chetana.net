namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class G_Driver
    {
        private int _DR_ID = Constants.NullInt;
        private string _NAME = Constants.NullString;
        private string _ADD1 = Constants.NullString;
        private string _ADD2 = Constants.NullString;
        private string _ADD3 = Constants.NullString;
        private int _AREACODE = Constants.NullInt;
        private string _CITY = Constants.NullString;
        private string _TEL1 = Constants.NullString;
        private string _TEL2 = Constants.NullString;
        private string _MOBILE = Constants.NullString;
        private string _PINCODE = Constants.NullString;
        private int _VEH_ID = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDelete = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _Licence = Constants.NullString;
        private DateTime _LicenceExpDate = Constants.NullDateTime;

        public static DataSet GetDriver(string flag, int ID, string flag1)
        {
            return new AdminDataService_Go().getDriver(flag, ID, flag1);
        }

        public void Save()
        {
            new AdminDataService_Go().SaveIdv_Chetana_Driver(this._DR_ID, this._NAME, this._ADD1, this._ADD2, this._ADD3, this._AREACODE, this._CITY, this._TEL1, this._TEL2, this._MOBILE, this._PINCODE, this._VEH_ID, this._IsActive, this._CreatedBy, this._UpdatedBy, this._Licence, this._LicenceExpDate);
        }

        public int DR_ID
        {
            get
            {
                return this._DR_ID;
            }
            set
            {
                this._DR_ID = value;
            }
        }

        public string NAME
        {
            get
            {
                return this._NAME;
            }
            set
            {
                this._NAME = value;
            }
        }

        public string ADD1
        {
            get
            {
                return this._ADD1;
            }
            set
            {
                this._ADD1 = value;
            }
        }

        public string ADD2
        {
            get
            {
                return this._ADD2;
            }
            set
            {
                this._ADD2 = value;
            }
        }

        public string ADD3
        {
            get
            {
                return this._ADD3;
            }
            set
            {
                this._ADD3 = value;
            }
        }

        public int AREACODE
        {
            get
            {
                return this._AREACODE;
            }
            set
            {
                this._AREACODE = value;
            }
        }

        public string CITY
        {
            get
            {
                return this._CITY;
            }
            set
            {
                this._CITY = value;
            }
        }

        public string TEL1
        {
            get
            {
                return this._TEL1;
            }
            set
            {
                this._TEL1 = value;
            }
        }

        public string TEL2
        {
            get
            {
                return this._TEL2;
            }
            set
            {
                this._TEL2 = value;
            }
        }

        public string MOBILE
        {
            get
            {
                return this._MOBILE;
            }
            set
            {
                this._MOBILE = value;
            }
        }

        public string PINCODE
        {
            get
            {
                return this._PINCODE;
            }
            set
            {
                this._PINCODE = value;
            }
        }

        public int VEH_ID
        {
            get
            {
                return this._VEH_ID;
            }
            set
            {
                this._VEH_ID = value;
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

        public string Licence
        {
            get
            {
                return this._Licence;
            }
            set
            {
                this._Licence = value;
            }
        }

        public DateTime LicenceExpDate
        {
            get
            {
                return this._LicenceExpDate;
            }
            set
            {
                this._LicenceExpDate = value;
            }
        }
    }
}

