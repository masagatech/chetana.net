namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class DCMaster
    {
        private int _DocumentNo = Constants.NullInt;
        private DateTime _DocumentDate = Constants.NullDateTime;
        private string _ChallanNo = Constants.NullString;
        private DateTime _ChallanDate = Constants.NullDateTime;
        private string _OrderNo = Constants.NullString;
        private DateTime _OrderDate = Constants.NullDateTime;
        private string _SalesmanCode = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private DateTime _CreatedOn = Constants.NullDateTime;
        private string _UpdatedBy = Constants.NullString;
        private DateTime _UpdatedOn = Constants.NullDateTime;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private int _FinancialYearFrom = Constants.NullInt;
        private int _FinancialYearTo = Constants.NullInt;
        private bool _IsConfirm = Constants.NullBoolean;
        private bool _IsApproved = Constants.NullBoolean;
        private bool _IsCanceled = Constants.NullBoolean;
        private bool _IsPartialConfirmed = Constants.NullBoolean;
        private bool _IsApprove = Constants.NullBoolean;
        private string _CustCode = Constants.NullString;
        private string _PIncharge = Constants.NullString;
        private string _Transporter = Constants.NullString;
        private string _TransportID = Constants.NullString;
        private string _BankCode = Constants.NullString;
        private string _BankName = Constants.NullString;
        private string _SpInstruction = Constants.NullString;
        private int _DocNo = Constants.NullInt;
        private string _Remark = Constants.NullString;
        private string _ChetanaCompanyName = Constants.NullString;
        private int _DocNewNo = Constants.NullInt;

        public static DataSet CustEmailID(string Code, string flag)
        {
            return new AdminDataService_DC().GetCustEmail(Code, flag);
        }

        public static DataSet Get_ApprovedDocNo()
        {
            return new AdminDataService_DC().GetPendingApprovedDocNo();
        }

        public static DataSet Get_ApprovedDocNo(int FY)
        {
            return new AdminDataService_DC().GetPendingApprovedDocNo(FY);
        }

        public static DataSet Get_Customer_PendingDocNo(string Flag)
        {
            return new AdminDataService_DC().Get_Customer_PendingDocNo(Flag);
        }

        public static DataSet Get_Customer_PendingDocNo(string Flag, int FY)
        {
            return new AdminDataService_DC().Get_Customer_PendingDocNo(Flag, FY);
        }

        public static DataSet Get_DC_Completed_IsApproved_ONOption(int ID, string Flag, int FY, DateTime fromdate, DateTime todate)
        {
            return new AdminDataService_DC().Get_DC_Completed_IsApproved_ONOption(ID, Flag, FY, fromdate, todate);
        }

        public static DataSet Get_DCMasterBy_DocNum(int DocumentNo, string SalesmanCode)
        {
            return new AdminDataService_DC().Get_DCMaster(DocumentNo, SalesmanCode);
        }

        public static DataSet Get_DCMasterBy_DocNum(int DocumentNo, string SalesmanCode, int FY)
        {
            return new AdminDataService_DC().Get_DCMaster(DocumentNo, SalesmanCode, FY);
        }

        public static DataSet Get_Discount_On_CusomerAND_Booktype(string CustCode, string Bookcode)
        {
            return new AdminDataService_DC().Get_Discount_On_CusomerAND_Booktype(CustCode, Bookcode);
        }

        public static bool Get_DocumentNum_Authentication(int DocumentNo)
        {
            DataTable table = new DataTable();
            table = new AdminDataService_DC().Get_DocumentNum_Authentication(DocumentNo).Tables[0];
            if (table.Rows.Count > 0)
            {
                return ((table.Rows[0]["DocumentNo"].ToString() == Convert.ToString(DocumentNo)) && false);
            }
            return true;
        }

        public static bool Get_DocumentNum_Authentication(int DocumentNo, int FY)
        {
            DataTable table = new DataTable();
            table = new AdminDataService_DC().Get_DocumentNum_Authentication(DocumentNo, FY).Tables[0];
            if (table.Rows.Count > 0)
            {
                return ((table.Rows[0]["DocumentNo"].ToString() == Convert.ToString(DocumentNo)) && false);
            }
            return true;
        }

        public static DataSet Get_Employee_By_Customer_Code(string Code, string flag)
        {
            return new AdminDataService_DC().Get_Employee_By_Customer_Code(Code, flag);
        }

        public static DataSet Get_Name(string Code)
        {
            return new AdminDataService_DC().Get_Name(Code);
        }

        public static DataSet Get_Name(string Code, string flag)
        {
            return new AdminDataService_DC().Get_Name(Code, flag);
        }

        public static DataSet Get_Pending_DocNo()
        {
            return new AdminDataService_DC().GetPendingDocNo();
        }

        public static DataSet Get_Pending_DocNo(int FY)
        {
            return new AdminDataService_DC().GetPendingDocNo(FY);
        }

        public static DataSet Get_Transporter(string CustCode)
        {
            return new AdminDataService_DC().Get_Transporter(CustCode);
        }

        public static bool GetDCOrderNoAuthentication(string OrderNo)
        {
            DataTable table = new DataTable();
            table = new AdminDataService_DC().GetDCOrderNoAuthentication(OrderNo).Tables[0];
            return ((table.Rows.Count > 0) && (table.Rows[0]["OrderNo"].ToString() == OrderNo));
        }

        public static bool GetDCOrderNoAuthentication(string OrderNo, int FY)
        {
            DataTable table = new DataTable();
            table = new AdminDataService_DC().GetDCOrderNoAuthentication(OrderNo, FY).Tables[0];
            return ((table.Rows.Count > 0) && (table.Rows[0]["OrderNo"].ToString() == OrderNo));
        }

        public static DataSet GetGridRemarks(InquiryDetail eq)
        {
            string tKTID = eq.TKTID;
            return new AdminDataService_DC().GetRemarksSelect(tKTID);
        }

        public static DataSet GetGridRmkAll(InquiryDetail eq)
        {
            string tKTID = eq.TKTID;
            return new AdminDataService_DC().GetRemarksAll(tKTID);
        }

        public static DataSet GetGridTktSelect(InquiryDetail eq)
        {
            string tKTID = eq.TKTID;
            return new AdminDataService_DC().GetTktSelect(tKTID);
        }

        public static DataSet GetInqiryIsDefault()
        {
            return new AdminDataService_DC().BindInqtypeIsDefault();
        }

        public static DataSet GetInqType()
        {
            return new AdminDataService_DC().BindInquiery();
        }

        public static DataSet GetLastTktNo()
        {
            return new AdminDataService_DC().LastTktNo();
        }

        public static DataSet GetPendingDocNo_ForView(int ID, string Flag, DateTime fromdate, DateTime todate)
        {
            return new AdminDataService_DC().GetPendingDocNo_ForView(ID, Flag, fromdate, todate);
        }

        public static DataSet GetPendingDocNo_ForView(int ID, string Flag, DateTime fromdate, DateTime todate, int FY)
        {
            return new AdminDataService_DC().GetPendingDocNo_ForView(ID, Flag, fromdate, todate, FY);
        }

        public static DataSet GetPendingDocNo_ForViewEmail(int ID, string Flag, DateTime fromdate, DateTime todate, int FY)
        {
            return new AdminDataService_DC().GetPendingDocNo_ForViewEmail(ID, Flag, fromdate, todate, FY);
        }

        public static DataSet GetPendingDocNoEmail(int FY)
        {
            return new AdminDataService_DC().GetPendingDocNoEmail(FY);
        }

        public static DataSet GetSeverity()
        {
            return new AdminDataService_DC().BindSeverity();
        }

        public static DataSet GetSeverityIsDefault()
        {
            return new AdminDataService_DC().BindSeverityIsDefault();
        }

        public static DataSet GetStatus()
        {
            return new AdminDataService_DC().BindStatus();
        }

        public static DataSet GetStatusIsDefault()
        {
            return new AdminDataService_DC().BindStatusIsDefault();
        }

        public static DataSet Idv_Chetana_Customer_WisePendingDC(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone)
        {
            return new AdminDataService().Idv_Chetana_Customer_WisePendingDC(CustID, FromDate, ToDate, FY, Superzone, Zone);
        }

        public static DataSet Idv_Chetana_Customer_WisePendingDC(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, int flag)
        {
            return new AdminDataService().Idv_Chetana_Customer_WisePendingDC(CustID, FromDate, ToDate, FY, Superzone, Zone, flag);
        }

        public static DataSet Idv_Chetana_TokenWise_Sales_Report(DateTime FromDate, DateTime ToDate, int FY)
        {
            return new AdminDataService().Idv_Chetana_TokenWise_Sales_Report(FromDate, ToDate, FY);
        }

        public static DataSet Idv_Chetana_TokenWise_Sales_Report(DateTime FromDate, DateTime ToDate, int FY, string Flag1, string Flag2, string Flag3)
        {
            return new AdminDataService().Idv_Chetana_TokenWise_Sales_Report(FromDate, ToDate, FY, Flag1, Flag2, Flag3);
        }

        public static DataSet InqTypeEmailID(string Code, string flag, int InqType)
        {
            return new AdminDataService_DC().GetEmail(Code, flag, InqType);
        }

        public static DataSet REP_Physical_STOCK(string bookcode)
        {
            return new AdminDataService().REP_Physical_STOCK(bookcode);
        }

        public static DataSet REP_Physical_STOCK(string bookcode, int FY)
        {
            return new AdminDataService().REP_Physical_STOCK(bookcode, FY);
        }

        public static DataSet REP_Physical_STOCK(string bookcode, DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService().REP_Physical_STOCK(bookcode, FromDate, ToDate);
        }

        public static DataSet REP_Physical_STOCK(string bookcode, DateTime FromDate, DateTime ToDate, int FY)
        {
            return new AdminDataService().REP_Physical_STOCK(bookcode, FromDate, ToDate, FY);
        }

        public static DataSet REP_Physical_STOCK_ReOrder_Level(string bookcode)
        {
            return new AdminDataService().REP_Physical_STOCK_ReOrder_Level(bookcode);
        }

        public static DataSet REP_Physical_STOCK_ReOrder_Level(string bookcode, DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService().REP_Physical_STOCK_ReOrder_Level(bookcode, FromDate, ToDate);
        }

        public static DataSet REP_Virtual_STOCK(string bookcode)
        {
            return new AdminDataService().REP_Virtual_STOCK(bookcode);
        }

        public static DataSet REP_Virtual_STOCK(string bookcode, int FY)
        {
            return new AdminDataService().REP_Virtual_STOCK(bookcode, FY);
        }

        public static DataSet REP_Virtual_STOCK(string bookcode, DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService().REP_Virtual_STOCK(bookcode, FromDate, ToDate);
        }

        public static DataSet REP_Virtual_STOCK(string bookcode, DateTime FromDate, DateTime ToDate, int FY)
        {
            return new AdminDataService().REP_Virtual_STOCK(bookcode, FromDate, ToDate, FY);
        }

        public static DataSet REP_Virtual_STOCK_ReOrder_Level(string bookcode)
        {
            return new AdminDataService().REP_Virtual_STOCK_ReOrder_Level(bookcode);
        }

        public static DataSet REP_Virtual_STOCK_ReOrder_Level(string bookcode, DateTime FromDate, DateTime ToDate)
        {
            return new AdminDataService().REP_Virtual_STOCK_ReOrder_Level(bookcode, FromDate, ToDate);
        }

        public void Save(out int _DocNo)
        {
            this.Save(null, out _DocNo);
        }

        public void Save(IDbTransaction txn, out int _DocNo)
        {
            new AdminDataService_DC().SaveDC(this._DocumentNo, this._DocumentDate, this._ChallanNo, this._ChallanDate, this._OrderNo, this._OrderDate, this._SalesmanCode, this._CustCode, this._PIncharge, this._Transporter, this._TransportID, this._BankCode, this._SpInstruction, this._CreatedBy, this._UpdatedBy, this._IsActive, this._IsDeleted, this._ChetanaCompanyName, out _DocNo);
        }

        public void Save(out int _DocNo, int FY, out int _DocNewNo)
        {
            this.Save(null, out _DocNo, FY, out _DocNewNo);
        }

        public void Save(IDbTransaction txn, out int _DocNo, int FY, out int _DocNewNo)
        {
            new AdminDataService_DC().SaveDC(this._DocumentNo, this._DocumentDate, this._ChallanNo, this._ChallanDate, this._OrderNo, this._OrderDate, this._SalesmanCode, this._CustCode, this._PIncharge, this._Transporter, this._TransportID, this._BankCode, this._SpInstruction, this._CreatedBy, this._UpdatedBy, this._IsActive, this._IsDeleted, this._ChetanaCompanyName, this._FinancialYearFrom, out _DocNo, out _DocNewNo);
        }

        public void Save_DC_Email()
        {
            new AdminDataService_DC().Save_DC_Email(this._DocNo, this._CreatedBy, this._IsActive);
        }

        public void update()
        {
            new AdminDataService_DC().Update(this._IsConfirm, this._IsApproved, this._IsCanceled, this._DocNo, this._Remark);
        }

        public void update(int FY)
        {
            new AdminDataService_DC().Update(this._IsConfirm, this._IsApproved, this._IsCanceled, this._DocNo, this._Remark, this._FinancialYearFrom);
        }

        public static DataSet UpdateLastTktNo(InquiryDetail eq)
        {
            string tKTID = eq.TKTID;
            return new AdminDataService_DC().SrcUpdateTktNo(tKTID);
        }

        public string ChetanaCompanyName
        {
            get
            {
                return this._ChetanaCompanyName;
            }
            set
            {
                this._ChetanaCompanyName = value;
            }
        }

        public int DocumentNo
        {
            get
            {
                return this._DocumentNo;
            }
            set
            {
                this._DocumentNo = value;
            }
        }

        public DateTime DocumentDate
        {
            get
            {
                return this._DocumentDate;
            }
            set
            {
                this._DocumentDate = value;
            }
        }

        public string ChallanNo
        {
            get
            {
                return this._ChallanNo;
            }
            set
            {
                this._ChallanNo = value;
            }
        }

        public DateTime ChallanDate
        {
            get
            {
                return this._ChallanDate;
            }
            set
            {
                this._ChallanDate = value;
            }
        }

        public string OrderNo
        {
            get
            {
                return this._OrderNo;
            }
            set
            {
                this._OrderNo = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return this._OrderDate;
            }
            set
            {
                this._OrderDate = value;
            }
        }

        public string SalesmanCode
        {
            get
            {
                return this._SalesmanCode;
            }
            set
            {
                this._SalesmanCode = value;
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

        public DateTime CreatedOn
        {
            get
            {
                return this._CreatedOn;
            }
            set
            {
                this._CreatedOn = value;
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

        public DateTime UpdatedOn
        {
            get
            {
                return this._UpdatedOn;
            }
            set
            {
                this._UpdatedOn = value;
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

        public int FinancialYearFrom
        {
            get
            {
                return this._FinancialYearFrom;
            }
            set
            {
                this._FinancialYearFrom = value;
            }
        }

        public int FinancialYearTo
        {
            get
            {
                return this._FinancialYearTo;
            }
            set
            {
                this._FinancialYearTo = value;
            }
        }

        public bool IsConfirm
        {
            get
            {
                return this._IsConfirm;
            }
            set
            {
                this._IsConfirm = value;
            }
        }

        public bool IsApproved
        {
            get
            {
                return this._IsApproved;
            }
            set
            {
                this._IsApproved = value;
            }
        }

        public bool IsCanceled
        {
            get
            {
                return this._IsCanceled;
            }
            set
            {
                this._IsCanceled = value;
            }
        }

        public bool IsPartialConfirmed
        {
            get
            {
                return this._IsPartialConfirmed;
            }
            set
            {
                this._IsPartialConfirmed = value;
            }
        }

        public bool IsApprove
        {
            get
            {
                return this._IsApprove;
            }
            set
            {
                this._IsApprove = value;
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

        public string PIncharge
        {
            get
            {
                return this._PIncharge;
            }
            set
            {
                this._PIncharge = value;
            }
        }

        public string Transporter
        {
            get
            {
                return this._Transporter;
            }
            set
            {
                this._Transporter = value;
            }
        }

        public string TransportID
        {
            get
            {
                return this._TransportID;
            }
            set
            {
                this._TransportID = value;
            }
        }

        public string BankCode
        {
            get
            {
                return this._BankCode;
            }
            set
            {
                this._BankCode = value;
            }
        }

        public string BankName
        {
            get
            {
                return this._BankName;
            }
            set
            {
                this._BankName = value;
            }
        }

        public string SpInstruction
        {
            get
            {
                return this._SpInstruction;
            }
            set
            {
                this._SpInstruction = value;
            }
        }

        public int DocNo
        {
            get
            {
                return this._DocNo;
            }
            set
            {
                this._DocNo = value;
            }
        }

        public int DocNewNo
        {
            get
            {
                return this._DocNewNo;
            }
            set
            {
                this._DocNewNo = value;
            }
        }

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
            }
        }
    }
}

