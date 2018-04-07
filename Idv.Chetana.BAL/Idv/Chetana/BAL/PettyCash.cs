namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class PettyCash
    {
        private int _VoucherNo = Constants.NullInt;
        private int _VoucherNo_New = Constants.NullInt;
        private string _PartyCode = Constants.NullString;
        private string _PartyName = Constants.NullString;
        private string _MainRemark = Constants.NullString;
        private DateTime _VoucherDate = Constants.NullDateTime;
        private int _FYFrom = Constants.NullInt;
        private int _FYTo = Constants.NullInt;
        private DateTime _Created_On = Constants.NullDateTime;
        private string _Created_By = Constants.NullString;
        private DateTime _Updated_On = Constants.NullDateTime;
        private string _Updated_By = Constants.NullString;
        private bool _Is_Active = Constants.NullBoolean;
        private decimal _TotalAmount = Constants.NullDecimal;
        private int _FY = Constants.NullInt;

        public static DataSet Idv_Chetana_Get_Petty_Expance_CheckList(string FromDate, string ToDate)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_Petty_Expance_CheckList(FromDate, ToDate);
        }

        public static DataSet Idv_Chetana_Get_Petty_Expance_CheckList(string FromDate, string ToDate, int Fy)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_Petty_Expance_CheckList(FromDate, ToDate, Fy);
        }

        public static DataSet Idv_Chetana_Get_Petty_Expance_View(string FromDate, string ToDate)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_Petty_Expance_View(FromDate, ToDate);
        }

        public static DataSet Idv_Chetana_Get_Petty_Expance_View(string FromDate, string ToDate, int Fy)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_Petty_Expance_View(FromDate, ToDate, Fy);
        }

        public static DataSet Idv_Chetana_Get_PettyCashEnter(int Voucher)
        {
            return new AdminDataService_DC().Idv_Chetana_Get_PettyCashEnter(Voucher);
        }

        public void Save(out int _IDNo)
        {
            this.Save((IDbTransaction) null, out _IDNo);
        }

        public void Save(IDbTransaction txn, out int _IDNo)
        {
            new AdminDataService_DC().SaveIdv_Chetana_PettyCashEntry(this._VoucherNo, this._VoucherNo_New, this._PartyCode, this._PartyName, this._MainRemark, this._VoucherDate, this._Created_By, this._Updated_On, this._Updated_By, this._Is_Active, this._TotalAmount, this._FY, out _IDNo);
        }

        public void Save(out int _IDNo, out int _DocNewNo)
        {
            this.Save(null, out _IDNo, out _DocNewNo);
        }

        public void Save(IDbTransaction txn, out int _IDNo, out int _DocNewNo)
        {
            new AdminDataService_DC().SaveIdv_Chetana_PettyCashEntry(this._VoucherNo, this._VoucherNo_New, this._PartyCode, this._PartyName, this._MainRemark, this._VoucherDate, this._Created_By, this._Updated_On, this._Updated_By, this._Is_Active, this._TotalAmount, this._FY, out _IDNo, out _DocNewNo);
        }

        public int VoucherNo
        {
            get
            {
                return this._VoucherNo;
            }
            set
            {
                this._VoucherNo = value;
            }
        }

        public int VoucherNo_New
        {
            get
            {
                return this._VoucherNo_New;
            }
            set
            {
                this._VoucherNo_New = value;
            }
        }

        public string PartyCode
        {
            get
            {
                return this._PartyCode;
            }
            set
            {
                this._PartyCode = value;
            }
        }

        public string PartyName
        {
            get
            {
                return this._PartyName;
            }
            set
            {
                this._PartyName = value;
            }
        }

        public string MainRemark
        {
            get
            {
                return this._MainRemark;
            }
            set
            {
                this._MainRemark = value;
            }
        }

        public DateTime VoucherDate
        {
            get
            {
                return this._VoucherDate;
            }
            set
            {
                this._VoucherDate = value;
            }
        }

        public int FYFrom
        {
            get
            {
                return this._FYFrom;
            }
            set
            {
                this._FYFrom = value;
            }
        }

        public int FYTo
        {
            get
            {
                return this._FYTo;
            }
            set
            {
                this._FYTo = value;
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

        public bool Is_Active
        {
            get
            {
                return this._Is_Active;
            }
            set
            {
                this._Is_Active = value;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return this._TotalAmount;
            }
            set
            {
                this._TotalAmount = value;
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
    }
}

