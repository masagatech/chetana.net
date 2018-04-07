namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Month_Target
    {
        private int _AutoID = Constants.NullInt;
        private int _SuperZoneID = Constants.NullInt;
        private string _MonthName = Constants.NullString;
        private decimal _TargetPercent = Constants.NullDecimal;
        private int _FY = Constants.NullInt;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDelete = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private string _Remark3 = Constants.NullString;
        private string _Remark4 = Constants.NullString;
        private string _Remark5 = Constants.NullString;
        private decimal _TargetAmount = Constants.NullDecimal;

        public static DataSet Get_CollectionTarget(int SuperZoneID, string ZoneID, string Flag1, string Flag2)
        {
            return new AdminDataService().Get_CollectionTarget(SuperZoneID, ZoneID, Flag1, Flag2);
        }

        public static DataSet Get_CollectionTarget_FromPercent(int ZoneID, string Month, int FY, decimal TargetPercent, string Remark1, string Remark2, string Remark3)
        {
            return new AdminDataService().Get_CollectionTarget_FromPercent(ZoneID, Month, FY, TargetPercent, Remark1, Remark2, Remark3);
        }

        public void Save()
        {
            this.Save(null);
        }

        public void Save(IDbTransaction txn)
        {
            new AdminDataService().Save_CollectionTarget(this._AutoID, this._SuperZoneID, this._MonthName, this._TargetPercent, this._FY, this._IsActive, this._IsDelete, this._CreatedBy, this._Remark1, this._Remark2, this._Remark3, this._Remark4, this._Remark5, this.TargetAmount);
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

        public string MonthName
        {
            get
            {
                return this._MonthName;
            }
            set
            {
                this._MonthName = value;
            }
        }

        public decimal TargetPercent
        {
            get
            {
                return this._TargetPercent;
            }
            set
            {
                this._TargetPercent = value;
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

        public bool IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {
                this._IsDelete = value;
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

        public decimal TargetAmount
        {
            get
            {
                return this._TargetAmount;
            }
            set
            {
                this._TargetAmount = value;
            }
        }
    }
}

