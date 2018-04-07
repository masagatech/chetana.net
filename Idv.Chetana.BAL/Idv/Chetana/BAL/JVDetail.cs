namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class JVDetail
    {
        private int _JVDetailID = Constants.NullInt;
        private int _JVMasterID = Constants.NullInt;
        private string _AccountCode = Constants.NullString;
        private string _ReportCode = Constants.NullString;
        private decimal _DebitAmount = Constants.NullDecimal;
        private decimal _CreditAmount = Constants.NullDecimal;
        private string _Remarks = Constants.NullString;
        private bool _Isactive = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsDeleted = Constants.NullBoolean;
        private int _strFY = Constants.NullInt;
        private string _Flag = Constants.NullString;
        private int _ID = Constants.NullInt;

        public void deleteJVRec()
        {
            new AdminDataService_DC().DeleteJVRecord(this._Flag, this._ID, this._Isactive, this._IsDeleted);
        }

        public static DataSet GetJV(int DocNo, int strFY)
        {
            return new AdminDataService_DC().GetJV(DocNo, strFY);
        }

        public static DataSet Idv_Chetana_GetJV_Report(DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService_DC().Idv_Chetana_GetJV_Report(FromDate, ToDate);
        }

        public static DataSet RepGetJV(int DocNo, int strFY)
        {
            return new AdminDataService_DC().RepGetJV(DocNo, strFY);
        }

        public void Save()
        {
            new AdminDataService_DC().SaveJVDetail(this._JVDetailID, this._JVMasterID, this._AccountCode, this._ReportCode, this._DebitAmount, this._CreditAmount, this._Remarks, this._Isactive, this._CreatedBy, this._UpdatedBy, this._strFY, this._Flag);
        }

        public int JVDetailID
        {
            get
            {
                return this._JVDetailID;
            }
            set
            {
                this._JVDetailID = value;
            }
        }

        public int JVMasterID
        {
            get
            {
                return this._JVMasterID;
            }
            set
            {
                this._JVMasterID = value;
            }
        }

        public string AccountCode
        {
            get
            {
                return this._AccountCode;
            }
            set
            {
                this._AccountCode = value;
            }
        }

        public string ReportCode
        {
            get
            {
                return this._ReportCode;
            }
            set
            {
                this._ReportCode = value;
            }
        }

        public decimal DebitAmount
        {
            get
            {
                return this._DebitAmount;
            }
            set
            {
                this._DebitAmount = value;
            }
        }

        public decimal CreditAmount
        {
            get
            {
                return this._CreditAmount;
            }
            set
            {
                this._CreditAmount = value;
            }
        }

        public string Remarks
        {
            get
            {
                return this._Remarks;
            }
            set
            {
                this._Remarks = value;
            }
        }

        public bool Isactive
        {
            get
            {
                return this._Isactive;
            }
            set
            {
                this._Isactive = value;
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

        public int strFY
        {
            get
            {
                return this._strFY;
            }
            set
            {
                this._strFY = value;
            }
        }
    }
}

