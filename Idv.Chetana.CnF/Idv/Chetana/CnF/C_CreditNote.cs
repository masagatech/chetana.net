namespace Idv.Chetana.CnF
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class C_CreditNote : DataServiceBase
    {
        private int _AutoID = Constants.NullInt;
        private int _CNNo = Constants.NullInt;
        private string _CustCode = Constants.NullString;
        private string _BookCode = Constants.NullString;
        private decimal _Rate = Constants.NullDecimal;
        private decimal _Discount = Constants.NullDecimal;
        private int _ReturnQty = Constants.NullInt;
        private string _Comment = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private string _Flag = Constants.NullString;
        private int _TotReturnQty = Constants.NullInt;
        private int _DefectQty = Constants.NullInt;
        private bool _IsDeleted = Constants.NullBoolean;
        private int _strFY = Constants.NullInt;
        private int _GCN = Constants.NullInt;
        private int _SCN = Constants.NullInt;
        private DateTime _CNDate = Constants.NullDateTime;
        private string _ActualKey = Constants.NullString;
        private string _Value = Constants.NullString;
        private string _GroupKey = Constants.NullString;
        private int _SuperZoneId = Constants.NullInt;
        private int _PreviousCount = Constants.NullInt;
        private int _NewCount = Constants.NullInt;
        private string _TransportName = Constants.NullString;
        private string _LrNo = Constants.NullString;
        private string _Remark1 = Constants.NullString;
        private string _Remark2 = Constants.NullString;
        private string _Remark3 = Constants.NullString;
        private string _Remark4 = Constants.NullString;
        private string _Remark5 = Constants.NullString;

        public DataSet C_Get_DC_CNBook(int strFY, string CustCode, string flag)
        {
            return base.ExecuteDataSet("C_Idv_Chetana_DC_Get_DCCNBook", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public static DataSet C_GetCNNo_Bydt(int strFY, DateTime FromDt, DateTime ToDt)
        {
            return new C_CreditNote().GetCNNo_Bydt(strFY, FromDt, ToDt);
        }

        public DataSet C_PrintCN(int strFY, int CNNo)
        {
            return base.ExecuteDataSet("C_Idv_Chetana_DC_Print_CN", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CNNo", SqlDbType.Int, CNNo) });
        }

        public static DataSet Get_DC_CNBook(int strFY, string CustCode, string flag)
        {
            return new C_CreditNote().C_Get_DC_CNBook(strFY, CustCode, flag);
        }

        public DataSet GetCNNo_Bydt(int strFY, DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("C_Idv_Chetana_DC_GetCNNo_Bydt", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public static DataSet PrintCN(int strFY, int CNNo)
        {
            return new C_CreditNote().C_PrintCN(strFY, CNNo);
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

        public int CNNo
        {
            get
            {
                return this._CNNo;
            }
            set
            {
                this._CNNo = value;
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

        public string BookCode
        {
            get
            {
                return this._BookCode;
            }
            set
            {
                this._BookCode = value;
            }
        }

        public decimal Rate
        {
            get
            {
                return this._Rate;
            }
            set
            {
                this._Rate = value;
            }
        }

        public decimal Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this._Discount = value;
            }
        }

        public int ReturnQty
        {
            get
            {
                return this._ReturnQty;
            }
            set
            {
                this._ReturnQty = value;
            }
        }

        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                this._Comment = value;
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

        public int TotReturnQty
        {
            get
            {
                return this._TotReturnQty;
            }
            set
            {
                this._TotReturnQty = value;
            }
        }

        public int DefectQty
        {
            get
            {
                return this._DefectQty;
            }
            set
            {
                this._DefectQty = value;
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

        public int GCN
        {
            get
            {
                return this._GCN;
            }
            set
            {
                this._GCN = value;
            }
        }

        public int SCN
        {
            get
            {
                return this._SCN;
            }
            set
            {
                this._SCN = value;
            }
        }

        public DateTime CNDate
        {
            get
            {
                return this._CNDate;
            }
            set
            {
                this._CNDate = value;
            }
        }

        public string ActualKey
        {
            get
            {
                return this._ActualKey;
            }
            set
            {
                this._ActualKey = value;
            }
        }

        public string GroupKey
        {
            get
            {
                return this._GroupKey;
            }
            set
            {
                this._GroupKey = value;
            }
        }

        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }

        public int SuperZoneId
        {
            get
            {
                return this._SuperZoneId;
            }
            set
            {
                this._SuperZoneId = value;
            }
        }

        public int PreviousCount
        {
            get
            {
                return this._PreviousCount;
            }
            set
            {
                this._PreviousCount = value;
            }
        }

        public int NewCount
        {
            get
            {
                return this._NewCount;
            }
            set
            {
                this._NewCount = value;
            }
        }

        public string TransportName
        {
            get
            {
                return this._TransportName;
            }
            set
            {
                this._TransportName = value;
            }
        }

        public string LrNo
        {
            get
            {
                return this._LrNo;
            }
            set
            {
                this._LrNo = value;
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
    }
}

