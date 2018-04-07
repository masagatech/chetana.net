namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Market_Review
    {
        private int _Market_ID = Constants.NullInt;
        private string _Super_Duper_Zone = Constants.NullString;
        private string _Super_Zone = Constants.NullString;
        private string _Zone = Constants.NullString;
        private string _Market_View = Constants.NullString;
        private string _Competitor_View = Constants.NullString;
        private int _Fyfrom = Constants.NullInt;
        private int _Fyto = Constants.NullInt;
        private DateTime _Created_On = Constants.NullDateTime;
        private string _Created_By = Constants.NullString;
        private DateTime _Updated_On = Constants.NullDateTime;
        private string _Updated_By = Constants.NullString;
        private bool _Is_Deleted = Constants.NullBoolean;

        public static DataSet Get_Mark_Review_DetailsBy_Zone(string flag, string show, string SDZ, string SZ, string ZoneID, int fy)
        {
            return new AdminDataService_Go().Get_Mark_Review_DetailsBy_Zone(flag, show, SDZ, SZ, ZoneID, fy);
        }

        public static DataSet Get_Mark_ReviewDetails(string flag, string ZoneID)
        {
            return new AdminDataService_Go().Get_Mark_ReviewDetails(flag, ZoneID);
        }

        public void Save()
        {
            this.Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new AdminDataService_Go().Save_Chetana_Market_Review(this._Market_ID, this._Super_Duper_Zone, this._Super_Zone, this._Zone, this._Market_View, this._Competitor_View, this._Fyfrom, this._Created_On, this._Created_By, this._Updated_On, this._Updated_By, this._Is_Deleted);
        }

        public int Market_ID
        {
            get
            {
                return this._Market_ID;
            }
            set
            {
                this._Market_ID = value;
            }
        }

        public string Super_Duper_Zone
        {
            get
            {
                return this._Super_Duper_Zone;
            }
            set
            {
                this._Super_Duper_Zone = value;
            }
        }

        public string Super_Zone
        {
            get
            {
                return this._Super_Zone;
            }
            set
            {
                this._Super_Zone = value;
            }
        }

        public string Zone
        {
            get
            {
                return this._Zone;
            }
            set
            {
                this._Zone = value;
            }
        }

        public string Market_View
        {
            get
            {
                return this._Market_View;
            }
            set
            {
                this._Market_View = value;
            }
        }

        public string Competitor_View
        {
            get
            {
                return this._Competitor_View;
            }
            set
            {
                this._Competitor_View = value;
            }
        }

        public int Fyfrom
        {
            get
            {
                return this._Fyfrom;
            }
            set
            {
                this._Fyfrom = value;
            }
        }

        public int Fyto
        {
            get
            {
                return this._Fyto;
            }
            set
            {
                this._Fyto = value;
            }
        }

        public DateTime Created_On
        {
            get
            {
                return this._Created_On;
            }
            set
            {
                this._Created_On = value;
            }
        }

        public string Created_By
        {
            get
            {
                return this._Created_By;
            }
            set
            {
                this._Created_By = value;
            }
        }

        public DateTime Updated_On
        {
            get
            {
                return this._Updated_On;
            }
            set
            {
                this._Updated_On = value;
            }
        }

        public string Updated_By
        {
            get
            {
                return this._Updated_By;
            }
            set
            {
                this._Updated_By = value;
            }
        }

        public bool Is_Deleted
        {
            get
            {
                return this._Is_Deleted;
            }
            set
            {
                this._Is_Deleted = value;
            }
        }
    }
}

