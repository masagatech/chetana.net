namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class CreditNote
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

        public void DeleteCN()
        {
            new AdminDataService_DC().DeleteCN(this._CNNo, this._strFY);
        }

        public static DataSet EditCN(int CNNo)
        {
            return new AdminDataService_DC().EditCN(CNNo);
        }

        public static DataSet EditCN(int strFY, int CNNo)
        {
            return new AdminDataService_DC().EditCN(strFY, CNNo);
        }

        public static DataSet Get_DC_CNBkview(int strFY, string CustCode, string BookCode)
        {
            return new AdminDataService_DC().Get_DC_CNBkview(strFY, CustCode, BookCode);
        }

        public static DataSet Get_DC_CNBook(int strFY, string CustCode, string flag)
        {
            return new AdminDataService_DC().Get_DC_CNBook(strFY, CustCode, flag);
        }

        public static DataSet Get_PrintCN_multiple(int strFY, string Selectedcn)
        {
            return new AdminDataService_DC().Get_PrintCN_multiple(strFY, Selectedcn);
        }

        public static string GetCNNo()
        {
            return new AdminDataService_DC().GetCNNo().Tables[0].Rows[0][0].ToString();
        }

        public static string GetCNNo(int strFY)
        {
            return new AdminDataService_DC().GetCNNo(strFY).Tables[0].Rows[0][0].ToString();
        }

        public static DataSet GetCNNo_byCust(string CustCode, string Flags, DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().GetCNNo_byCust(CustCode, Flags, FromDt, ToDt);
        }

        public static DataSet GetCNNo_byCust(int strFY, string CustCode, string Flags, DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().GetCNNo_byCust(strFY, CustCode, Flags, FromDt, ToDt);
        }

        public static DataSet GetCNNo_byCusts(int strFY, string CustCode, string Flags)
        {
            return new AdminDataService_DC().GetCNNo_byCusts(strFY, CustCode, Flags);
        }

        public static DataSet GetCNNo_Bydt(int strFY, DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().GetCNNo_Bydt(strFY, FromDt, ToDt);
        }

        public static DataSet GetCustlist(string Flag)
        {
            return new AdminDataService_DC().GetCustlist(Flag);
        }

        public static DataSet GetCustlist(int strFY, string Flag)
        {
            return new AdminDataService_DC().GetCustlist(strFY, Flag);
        }

        public static DataSet GetCustlist_Bydt(DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().GetCustlist_Bydt(FromDt, ToDt);
        }

        public static DataSet GetCustlist_Bydt(int strFY, DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().GetCustlist_Bydt(strFY, FromDt, ToDt);
        }

        public static DataSet GetTotalCN_Bydt(DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().GetTotalCN_Bydt(FromDt, ToDt);
        }

        public static DataSet GetTotalCN_Bydt(int strFY, DateTime FromDt, DateTime ToDt)
        {
            return new AdminDataService_DC().GetTotalCN_Bydt(strFY, FromDt, ToDt);
        }

        public static DataSet PrintCN(int CNNo)
        {
            return new AdminDataService_DC().PrintCN(CNNo);
        }

        public static DataSet PrintCN(int strFY, int CNNo)
        {
            return new AdminDataService_DC().PrintCN(strFY, CNNo);
        }

        public void Save_CN()
        {
            new AdminDataService_DC().Save_CN(this._AutoID, this._CNNo, this._CustCode, this._BookCode, this._Rate, this._Discount, this._ReturnQty, this._Comment, this._IsActive, this._CreatedBy, this._UpdatedBy, this._Flag, this._TotReturnQty, this._DefectQty, this._GCN, this._SCN, this._CNDate);
        }

        public void Save_CN(int strFY)
        {
            new AdminDataService_DC().Save_CN(this._AutoID, this._CNNo, this._CustCode, this._BookCode, this._Rate, this._Discount, this._ReturnQty, this._Comment, this._IsActive, this._CreatedBy, this._UpdatedBy, this._Flag, this._TotReturnQty, this._DefectQty, this._GCN, this._SCN, this._strFY, this._CNDate, this._TransportName, this._LrNo, this._Remark1, this._Remark2, this._Remark3, this._Remark4, this._Remark5);
        }

        public void SaveCNProgrammeChartDetails()
        {
            new AdminDataService_DC().SaveCNProgrammeChartDetails(this._ActualKey, this._Value, this._GroupKey, this._SuperZoneId, this._PreviousCount, this._NewCount, this._CreatedBy, this._Flag);
        }

        public void Update_CN()
        {
            new AdminDataService_DC().Update_CN(this._AutoID, this._CNNo, this._CustCode, this._BookCode, this._Rate, this._Discount, this._ReturnQty, this._Comment, this._IsActive, this._UpdatedBy, this._Flag, this._TotReturnQty, this._DefectQty, this._IsDeleted, this._CNDate);
        }

        public void Update_CN(int strFY)
        {
            new AdminDataService_DC().Update_CN(this._AutoID, this._CNNo, this._CustCode, this._BookCode, this._Rate, this._Discount, this._ReturnQty, this._Comment, this._IsActive, this._UpdatedBy, this._Flag, this._TotReturnQty, this._DefectQty, this._IsDeleted, this._strFY, this._CNDate, this._TransportName, this._LrNo, this._Remark1, this._Remark2, this._Remark3, this._Remark4, this._Remark5, this._GCN, this._SCN);
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

