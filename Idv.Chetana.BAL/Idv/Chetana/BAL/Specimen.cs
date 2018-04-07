namespace Idv.Chetana.BAL
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    public class Specimen
    {
        private int _DocumentNo = Constants.NullInt;
        private DateTime _DocumentDate = Constants.NullDateTime;
        private string _ChallanNo = Constants.NullString;
        private DateTime _ChallanDate = Constants.NullDateTime;
        private string _OrderNo = Constants.NullString;
        private DateTime _OrderDate = Constants.NullDateTime;
        private string _SalesmanCode = Constants.NullString;
        private string _CreatedBy = Constants.NullString;
        private string _UpdatedBy = Constants.NullString;
        private bool _IsActive = Constants.NullBoolean;
        private bool _IsDeleted = Constants.NullBoolean;
        private bool _IsConfirm = Constants.NullBoolean;
        private bool _IsApproved = Constants.NullBoolean;
        private bool _IsCanceled = Constants.NullBoolean;
        private int _DocNo = Constants.NullInt;
        private string _SpInstruction = Constants.NullString;
        private string _Description = Constants.NullString;
        private int _FinancialYearFrom = Constants.NullInt;
        private int _FinancialYearTo = Constants.NullInt;
        private int _DocNewNo = Constants.NullInt;

        public static DataSet Get_ApprovedDocNo()
        {
            return new AdminDataService().GetPendingApprovedDocNo();
        }

        public static DataSet Get_ApprovedDocNo_Employee(int FY)
        {
            return new AdminDataService().Get_ApprovedDocNo_Employee(FY);
        }

        public static DataSet Get_Customer_SalesmanwiseBooks(string code, DateTime fromdate, DateTime todate)
        {
            return new AdminDataService().Get_Customer_SalesmanwiseBooks(code, fromdate, todate);
        }

        public static bool Get_DocumentNum_Authentication(int DocumentNo)
        {
            DataTable table = new DataTable();
            table = new AdminDataService().Get_DocumentNum_Authentication(DocumentNo).Tables[0];
            if (table.Rows.Count > 0)
            {
                return ((table.Rows[0]["DocumentNo"].ToString() == Convert.ToString(DocumentNo)) && false);
            }
            return true;
        }

        public static DataSet Get_Name(string Code, string flag)
        {
            return new AdminDataService_DC().Get_Name(Code, flag);
        }

        public static DataSet Get_PedingDocNo_Employee(int FY)
        {
            return new AdminDataService().Get_PedingDocNo_Employee(FY);
        }

        public static DataSet Get_PedingDocNo_EmployeeWise(int FY, int EmpId)
        {
            return new AdminDataService().Get_PedingDocNo_EmployeeWise(FY, EmpId);
        }

        public static DataSet Get_PendingDocNo()
        {
            return new AdminDataService().GetPendingDocNo();
        }

        public static DataSet Get_PendingDocNo(string flag, DateTime frmDate, DateTime toDate, int fy, string flag1)
        {
            return new AdminDataService().GetPendingDocNo(flag, frmDate, toDate, fy, flag1);
        }

        public static DataSet Get_SalesmanWiseBooks(string code, DateTime fromdate, DateTime todate)
        {
            return new AdminDataService().Get_SalesmanwiseBooks(code, fromdate, todate);
        }

        public static DataSet Get_SepcimanMaster()
        {
            return new AdminDataService().GetSepcimanMaster();
        }

        public static DataSet Get_SpecimenDetailsForInvoice(int DocumentNo, decimal SubConfirmID)
        {
            return new AdminDataService().Get_SpecimenDetailsForInvoice(DocumentNo, SubConfirmID);
        }

        public static DataSet Get_SpecimenDetailsForInvoice_Bookwise(string BookCode, DateTime fromdate, DateTime todate)
        {
            return new AdminDataService().Get_SpecimenDetailsForInvoice_BookWise(BookCode, fromdate, todate);
        }

        public static DataSet Get_SpecimenDetailsForInvoice_Customerwise(string CustID, DateTime fromdate, DateTime todate)
        {
            return new AdminDataService().Get_SpecimenDetailsForInvoice_Customerwise(CustID, fromdate, todate);
        }

        public static DataSet Get_SpecimenMasterBy_DocNum(int DocumentNo, string SalesmanCode)
        {
            return new AdminDataService().Get_SpecimenMaster(DocumentNo, SalesmanCode);
        }

        public static DataSet Get_SubConfirmID_onDocumentNo(int DocumentNo)
        {
            return new AdminDataService().Get_SubConfirmID_onDocumentNo(DocumentNo);
        }

        public static bool GetChallanNoAuthentication(string ChallanNo)
        {
            DataTable table = new DataTable();
            table = new AdminDataService().GetChallanNoAuthentication(ChallanNo).Tables[0];
            return ((table.Rows.Count > 0) && (table.Rows[0]["ChallanNo"].ToString() == ChallanNo));
        }

        public static bool GetOrderNoAuthentication(string OrderNo)
        {
            DataTable table = new DataTable();
            table = new AdminDataService().GetOrderNoAuthentication(OrderNo).Tables[0];
            return ((table.Rows.Count > 0) && (table.Rows[0]["OrderNo"].ToString() == OrderNo));
        }

        public static DataSet Idv_Chetana_Customer_Summary_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone)
        {
            return new AdminDataService().Idv_Chetana_Customer_Summary_Report(CustID, FromDate, ToDate, FY, Superzone, Zone);
        }

        public static DataSet Idv_Chetana_Customer_Summary_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode)
        {
            return new AdminDataService().Idv_Chetana_Customer_Summary_Report(CustID, FromDate, ToDate, FY, Superzone, Zone, CustCode);
        }

        public static DataSet Idv_Chetana_Customer_Summary_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode, decimal amount, string Flags, string iszero)
        {
            return new AdminDataService().Idv_Chetana_Customer_Summary_Report(CustID, FromDate, ToDate, FY, Superzone, Zone, CustCode, amount, Flags, iszero);
        }

        public static DataSet Idv_Chetana_Customer_ZoneDate_Report(int CustID, string FromDate, string ToDate, int FY)
        {
            return new AdminDataService().Idv_Chetana_Customer_ZoneDate_Report(CustID, FromDate, ToDate, FY);
        }

        public static DataSet Idv_Chetana_Customer_ZoneDate_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone)
        {
            return new AdminDataService().Idv_Chetana_Customer_ZoneDate_Report(CustID, FromDate, ToDate, FY, Superzone, Zone);
        }

        public static DataSet Idv_Chetana_Customer_ZoneDate_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode)
        {
            return new AdminDataService().Idv_Chetana_Customer_ZoneDate_Report(CustID, FromDate, ToDate, FY, Superzone, Zone, CustCode);
        }

        public static DataSet Idv_Chetana_Customer_ZoneDate_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode, string iszero)
        {
            return new AdminDataService().Idv_Chetana_Customer_ZoneDate_Report(CustID, FromDate, ToDate, FY, Superzone, Zone, CustCode, iszero);
        }

        public static DataSet Idv_Chetana_DC_Report_Get_PedingDocNo_ForDCConfirmation(int SuperDuperZoneId, int SuperZoneId, DateTime FromDate, DateTime ToDate, int FY)
        {
            return new AdminDataService().Idv_Chetana_DC_Report_Get_PedingDocNo_ForDCConfirmation(SuperDuperZoneId, SuperZoneId, FromDate, ToDate, FY);
        }

        public static DataSet Idv_Chetana_Get_CustomerDetailsForReport(int CustID)
        {
            return new AdminDataService().Idv_Chetana_Get_CustomerDetailsForReport(CustID);
        }

        public static DataSet Idv_Chetana_Rep_CustomerWise_Sales(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone)
        {
            return new AdminDataService().Idv_Chetana_Rep_CustomerWise_Sales(CustID, FromDate, ToDate, FY, Superzone, Zone);
        }

        public static DataSet Idv_Chetana_Rep_CustomerWise_Sales(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, int Percent)
        {
            return new AdminDataService().Idv_Chetana_Rep_CustomerWise_Sales(CustID, FromDate, ToDate, FY, Superzone, Zone, Percent);
        }

        public static DataSet Idv_Chetana_Rep_CustomerWise_SalesReport(string CustCateID, int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, int Percent)
        {
            return new AdminDataService().Idv_Chetana_Rep_CustomerWise_SalesReport(CustCateID, CustID, FromDate, ToDate, FY, Superzone, Zone, Percent);
        }

        public void Save(out int _DocNo)
        {
            this.Save(null, out _DocNo);
        }

        public void Save(IDbTransaction txn, out int _DocNo)
        {
            new AdminDataService().Savespeciman(this._DocumentNo, this._DocumentDate, this._ChallanNo, this._ChallanDate, this._OrderNo, this._OrderDate, this._SalesmanCode, this._SpInstruction, this._CreatedBy, this._UpdatedBy, this._IsActive, this._IsDeleted, this._Description, out _DocNo);
        }

        public void Save(out int _DocNo, int FY, out int _DocNewNo)
        {
            this.Save(null, out _DocNo, FY, out _DocNewNo);
        }

        public void Save(IDbTransaction txn, out int _DocNo, int FY, out int _DocNewNo)
        {
            new AdminDataService().Savespeciman(this._DocumentNo, this._DocumentDate, this._ChallanNo, this._ChallanDate, this._OrderNo, this._OrderDate, this._SalesmanCode, this._SpInstruction, this._CreatedBy, this._UpdatedBy, this._IsActive, this._IsDeleted, this._Description, this._FinancialYearFrom, out _DocNo, out _DocNewNo);
        }

        public void update()
        {
            new AdminDataService().Update(this._IsConfirm, this._IsApproved, this._IsCanceled, this._DocNo);
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

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
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
    }
}

