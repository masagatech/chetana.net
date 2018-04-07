namespace Idv.Chetana.DAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class AdminDataService : DataServiceBase
    {
        public AdminDataService()
        {
        }

        public AdminDataService(IDbTransaction txn)
            : base(txn)
        {
        }

        public DataSet ACCodeGet(string AcCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Account_main", new IDataParameter[] { base.CreateParameter("@AcCode", SqlDbType.NVarChar, AcCode) });
        }

        public DataSet ACCodeValidaton(string AcCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_AcCode", new IDataParameter[] {
                base.CreateParameter("@AcCode", SqlDbType.NVarChar, AcCode)
            });
        }

        public DataSet AllRecordRepordTicketHistory(DateTime InqFDate, DateTime InqTDATE, string TKTNOFrom, string TKTNOTo, string CustomerName, string EmpName, string CustNo, string Status, string Action)
        {
            return base.ExecuteDataSet("SP_RptTicketHistory", new IDataParameter[] {
                base.CreateParameter("@InqFromDate", SqlDbType.DateTime, InqFDate),
                base.CreateParameter("@InqToDate", SqlDbType.DateTime, InqTDATE),
                base.CreateParameter("@TKTNOFrom", SqlDbType.NVarChar, TKTNOFrom),
                base.CreateParameter("@TKTTODate", SqlDbType.NVarChar, TKTNOTo),
                base.CreateParameter("@CustomerName", SqlDbType.NVarChar, CustomerName),
                base.CreateParameter("@EmpName", SqlDbType.NVarChar, EmpName),
                base.CreateParameter("@CustNo", SqlDbType.NVarChar, CustNo),
                base.CreateParameter("@Status", SqlDbType.NVarChar, Status),
                base.CreateParameter("@Action", SqlDbType.NVarChar, Action)
            });
        }

        public void DeletePurchaseDetails(int purchaseDetailID, bool IsActive, bool Isdeleted, decimal Amount, decimal Rate, decimal Discount, int Quantity, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Delete_PurchaseDetails", new IDataParameter[] { base.CreateParameter("@purchaseDetailID", SqlDbType.Int, purchaseDetailID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void DeleteRecord(string Flag, int ID, bool IsActive, bool IsDeleted)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Delete_ByID", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@ID", SqlDbType.Int, ID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted) });
            command.Dispose();
        }

        public DataSet Get_AddDiscount_On_Cusomer(string CustCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_AddDiscount_On_Customer", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode) });
        }

        public DataSet Get_All_Active_Menu_Head()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MenuHeadMaster", null);
        }

        public DataSet Get_AllocateKRA(string EmpCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_AllocateKRA", new IDataParameter[] { base.CreateParameter("@code", SqlDbType.NVarChar, EmpCode) });
        }

        public DataSet Get_AllocateKRA(string EmpCode, int fy, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_AllocateKRA", new IDataParameter[] { base.CreateParameter("@code", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@fy", SqlDbType.Int, fy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_AllotedSpecimenDetailId(int SpecimenDetailId)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Alloted_BookDetails-On-SpecimenDetailId", new IDataParameter[] { base.CreateParameter("@SpecimenDetailId", SqlDbType.Int, SpecimenDetailId) });
        }

        public DataSet Get_ApprovedDocNo_Employee(int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Approved_Employee", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_AreaZone_Zone_SuperZone(int Code1, string Flag1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_AreaZone_Zone_SuperZone", new IDataParameter[] { base.CreateParameter("@Para", SqlDbType.Int, Code1), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag1) });
        }

        public DataSet Get_Bank_Checklist(string Code, DateTime Fdate, DateTime Tdate, int FY, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Bank_Checklist", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Code), base.CreateParameter("@fromDate", SqlDbType.DateTime, Fdate), base.CreateParameter("@toDate", SqlDbType.DateTime, Tdate), base.CreateParameter("@Fy", SqlDbType.Int, FY), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_Bank_LedgerNew(string Code, int Frommonth, int FY, decimal OpenBal)
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Bank_Ledger1", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Code), base.CreateParameter("@frommonth", SqlDbType.Int, Frommonth), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@openingBalance", SqlDbType.Decimal, OpenBal) });
        }

        public DataSet Get_Bank_LedgerNew(string Code, int Frommonth, int FY, decimal OpenBal, string flag, string remark1, string remark2, string remark3)
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Bank_Ledger1", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Code), base.CreateParameter("@frommonth", SqlDbType.Int, Frommonth), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@openingBalance", SqlDbType.Decimal, OpenBal), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@remark1", SqlDbType.NVarChar, remark1), base.CreateParameter("@remark2", SqlDbType.NVarChar, remark2), base.CreateParameter("@remark3", SqlDbType.NVarChar, remark3) });
        }

        public DataSet Get_Bank_Reco(string Code, int Frommonth, int FY, decimal OpenBal)
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Bank_Reco", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Code), base.CreateParameter("@frommonth", SqlDbType.Int, Frommonth), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@openingBalance", SqlDbType.Decimal, OpenBal) });
        }

        public DataSet Get_Bank_Reco(string Code, int Frommonth, int FY, decimal OpenBal, string flag)
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Bank_Reco", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Code), base.CreateParameter("@frommonth", SqlDbType.Int, Frommonth), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@openingBalance", SqlDbType.Decimal, OpenBal), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_BankBookSummary(int FY, string Code)
        {
            return base.ExecuteDataSet("idv_chetana_Get_BankSummary", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@AC_Code", SqlDbType.NVarChar, Code) });
        }

        public DataSet Get_BankBookSummary(int FY, string Code, DateTime Fdate, DateTime Tdate)
        {
            return base.ExecuteDataSet("idv_chetana_Get_BankSummary", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@AC_Code", SqlDbType.NVarChar, Code), base.CreateParameter("@fromDate", SqlDbType.DateTime, Fdate), base.CreateParameter("@toDate", SqlDbType.DateTime, Tdate) });
        }

        public DataSet Get_BankPaymentReport(string BankCode, int DocumentNo, string strFY)
        {
            return base.ExecuteDataSet("Idev_Chetana_BankPayment_Report", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@FY", SqlDbType.NVarChar, strFY) });
        }

        public DataSet Get_BankPaymentReport_MultiPrint(string BankCode, string strFY, string flag, int fromDocumentNo, int todocumentno)
        {
            return base.ExecuteDataSet("Idev_Chetana_MultiPrint_Report", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@FY", SqlDbType.NVarChar, strFY), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@fromDocumentNo", SqlDbType.Int, fromDocumentNo), base.CreateParameter("@todocumentno", SqlDbType.Int, todocumentno) });
        }

        public DataSet Get_BookSetDetailsOn_SetID(int BookSetID)
        {
            return base.ExecuteDataSet("dbo.Idv_Chetana_Get_BookSetDetails-On-SetID", new IDataParameter[] { base.CreateParameter("@BookSetID", SqlDbType.Int, BookSetID) });
        }

        public DataSet Get_BookSetDetailsOn_SetIDForSpec(int BookSetID, string srate)
        {
            return base.ExecuteDataSet("dbo.Idv_Chetana_Get_BookSetDetails-On-SetIDForSpec", new IDataParameter[] { base.CreateParameter("@BookSetID", SqlDbType.Int, BookSetID), base.CreateParameter("@srate", SqlDbType.NVarChar, srate) });
        }

        public DataSet Get_BooksMasterForspecimen(string BookCode, string srate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BookMasterForSpec", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@srate", SqlDbType.NVarChar, srate) });
        }

        public DataSet Get_Codes_Customer_By_Employee_Code(string Code, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Codes_Customer_By_Employee_Code", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_Codes_ForPettyCash(string Code, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Codes_ForPettyCash", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_CollectionTarget(int SuperZoneId, string ZoneID, string Flag1, string Flag2)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CollectionTarget", new IDataParameter[] { base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneId), base.CreateParameter("@ZoneID", SqlDbType.NVarChar, ZoneID), base.CreateParameter("@Flag1", SqlDbType.NVarChar, Flag1), base.CreateParameter("@Flag2", SqlDbType.NVarChar, Flag2) });
        }

        public DataSet Get_CollectionTarget_FromPercent(int ZoneID, string Month, int FY, decimal TargetPercent, string Remark1, string Remark2, string Remark3)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetCollectionTarget_FromPercent", new IDataParameter[] { base.CreateParameter("@ZoneId", SqlDbType.Int, ZoneID), base.CreateParameter("@Month", SqlDbType.NVarChar, Month), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@TargetPercent", SqlDbType.Decimal, TargetPercent), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3) });
        }

        public DataSet Get_CustList()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerMaster_Details", null);
        }

        public DataSet Get_CustList(string Flag, string ID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerMaster_Details_flag", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@ID", SqlDbType.NVarChar, ID) });
        }

        public DataSet Get_CustList(string Flag, string ID, string ZoneID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerMaster_Details_flag", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@ID", SqlDbType.NVarChar, ID), base.CreateParameter("@ZoneID", SqlDbType.NVarChar, ZoneID) });
        }

        public DataSet Get_CustListReport(string Flag, string CustCateID, string ID, string ZoneID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerMaster_Details_Flag", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@CustCateID", SqlDbType.NVarChar, CustCateID), base.CreateParameter("@ID", SqlDbType.NVarChar, ID), base.CreateParameter("@ZoneID", SqlDbType.NVarChar, ZoneID) });
        }

        public DataSet Get_Customer_SalesmanwiseBooks(string code, DateTime fromdate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_Get_Customer_SalesmanwiseBooks", new IDataParameter[] { base.CreateParameter("@code", SqlDbType.NVarChar, code), base.CreateParameter("@fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet Get_CustomerandTransporterValueAD(string CustCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_CustomerTransporter_Mapping", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode) });
        }

        public DataSet Get_CustomerDiscountBy_BookType(string Custcode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerDiscountBy_BookType", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, Custcode) });
        }

        public DataSet Get_Dasboard_ForOrderValuation(DateTime FromDate, DateTime ToDate, int SZone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_Dasboard_ForOrderValuation", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@SZone", SqlDbType.Int, SZone) });
        }

        public DataSet Get_Dasboard_ForOrderValuation(DateTime FromDate, DateTime ToDate, int SZone, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_Dasboard_ForOrderValuation", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@SZone", SqlDbType.Int, SZone), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_DC_Completed_IsApproved()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DC_Completed_IsApproved", null);
        }

        public DataSet Get_DC_Completed_IsApproved(string flag, DateTime frmDate, DateTime toDate, int fy, string flag1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DC_Completed_IsApproved", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@frmDate", SqlDbType.DateTime, frmDate), base.CreateParameter("@toDate", SqlDbType.DateTime, toDate), base.CreateParameter("@fy", SqlDbType.Int, fy), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1) });
        }

        public DataSet Get_DestinationMaster(string Flag)
        {
            return base.ExecuteDataSet("dbo.Idv_Chetana_Get_DestinationMaster", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_DocumentNO(string EmpCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_getDocumentID_SpecimenMaster", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode) });
        }

        public DataSet Get_DocumentNum_Authentication(int DocumentNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DocumentNum_Authentication", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo) });
        }

        public DataSet Get_EmpList()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_EmployeeMaster_Details", null);
        }

        public DataSet Get_EmpList(string flag, string id, string flag1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_EmployeeMaster_Details", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@id", SqlDbType.NVarChar, id), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1) });
        }

        public DataSet Get_Employee_onUserLogin(string Empcode, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Employee_onUserLogin", new IDataParameter[] { base.CreateParameter("@code", SqlDbType.NVarChar, Empcode), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_EmployeeArea_Mapping(int empid)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_EmployeeArea_Mapping", new IDataParameter[] { base.CreateParameter("@empid", SqlDbType.Int, empid) });
        }

        public DataSet Get_EmployeeName(string EmpCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetNAme_EmployeeMaster", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode) });
        }

        public DataSet Get_Main_Menu_By_MenuHead_ID(int MH_ID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MenuMain_Master_By_MHid", new IDataParameter[] { base.CreateParameter("@MH_ID", SqlDbType.Int, MH_ID) });
        }

        public DataSet Get_MasterOfMaster_ByGroup(string Group)
        {
            return base.ExecuteDataSet("dbo.Idv_Chetana_Get_MasterOfMaster_ByGroup", new IDataParameter[] { base.CreateParameter("@Group", SqlDbType.NVarChar, Group) });
        }

        public DataSet Get_MasterOfMaster_ByGroup_ForDropdown(string Group, string Flag2)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MasterOfMaster_ByGroup1", new IDataParameter[] { base.CreateParameter("@Group", SqlDbType.NVarChar, Group), base.CreateParameter("@Flag2", SqlDbType.NVarChar, Flag2) });
        }

        public DataSet Get_Masters_Code_ID_Name(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Masters_Code_ID_Name", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_Menu_By_Level_and_ParentID(int level, int parentID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Menu_By_Level_and_ParentID", new IDataParameter[] { base.CreateParameter("@level", SqlDbType.Int, level), base.CreateParameter("@parentID", SqlDbType.Int, parentID) });
        }

        public DataSet Get_MenuList()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MenuMaster", null);
        }

        public DataSet Get_MultiYear_SalesAnalysis(int SuperZone, int strFY, int Zone, int Customer, string flag1, string flag2, string flag3)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_MultiYear_SalesAnalysis", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@Customer", SqlDbType.Int, Customer), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@flag3", SqlDbType.NVarChar, flag3) });
        }

        public DataSet Get_OrderValuation(int SuperZone, int strFY, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_OrderValuation", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Get_OrderValuation(int SuperZone, int strFY, int Zone, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_OrderValuation", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet Get_OrderValuation(int SuperZone, int strFY, int Zone, DateTime FromDate, DateTime ToDate, string flag, string CustCateID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_OrderValuation", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@CustCateID", SqlDbType.NVarChar, CustCateID) });
        }

        public DataSet Get_PedingDocNo_Employee(int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PedingDocNo_Employee", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_PedingDocNo_EmployeeWise(int FY, int EmpId)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PedingDocNo_EmployeeWise", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@EmpId", SqlDbType.Int, EmpId) });
        }

        public DataSet Get_PurchaseDetails(int InvoiceNo, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PurchaseDatails", new IDataParameter[] { base.CreateParameter("@InvoiceNo", SqlDbType.Int, InvoiceNo), base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@todate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet Get_PurchaseDetails(int InvoiceNo, DateTime FromDate, DateTime ToDate, int FY, string FLAG, int MONTH, int YEAR)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PurchaseDatails", new IDataParameter[] { base.CreateParameter("@InvoiceNo", SqlDbType.Int, InvoiceNo), base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@todate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FLAG", SqlDbType.NVarChar, FLAG), base.CreateParameter("@MONTH", SqlDbType.Int, MONTH), base.CreateParameter("@YEAR", SqlDbType.Int, YEAR) });
        }

        public DataSet Get_QtyDetails_By_SpecimenDetailsID(int SpecimendetailsID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_QtyDetails_By_SpecimenDetailsID", new IDataParameter[] { base.CreateParameter("@specimenDetId", SqlDbType.Int, SpecimendetailsID) });
        }

        public DataSet Get_Rep_Scheme(int CustID, string FromDate, string ToDate, int FY, int SuperDuperzone, int Superzone, int Zone, string Flags, int schemeID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Scheme", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@SuperDuperzone", SqlDbType.Int, SuperDuperzone), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@Flag", SqlDbType.VarChar, Flags), base.CreateParameter("@schemeID", SqlDbType.Int, schemeID) });
        }

        public DataSet Get_Rep_Scheme(int CustID, string FromDate, string ToDate, int FY, int SuperDuperzone, int Superzone, int Zone, string Flags, int schemeID, string CustCateID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Scheme", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@SuperDuperzone", SqlDbType.Int, SuperDuperzone), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@Flag", SqlDbType.VarChar, Flags), base.CreateParameter("@schemeID", SqlDbType.Int, schemeID), base.CreateParameter("@CustCateID", SqlDbType.NVarChar, CustCateID) });
        }

        public DataSet Get_Report_SalesPerformance(int EmployeeID, int SZID)
        {
            return base.ExecuteDataSet("idv_Chetana_REP_SalesPerformance", new IDataParameter[] { base.CreateParameter("@EmployeeID", SqlDbType.Int, EmployeeID), base.CreateParameter("@SZID", SqlDbType.Int, SZID) });
        }

        public DataSet Get_Report_SalesPerformance(int EmployeeID, int SZID, int FY)
        {
            return base.ExecuteDataSet("idv_Chetana_REP_SalesPerformance_For_TargetDetails", new IDataParameter[] { base.CreateParameter("@EmployeeID", SqlDbType.Int, EmployeeID), base.CreateParameter("@SZID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Report_SalesPerformance(int EmployeeID, int SZID, int FY, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("idv_Chetana_REP_SalesPerformance", new IDataParameter[] { base.CreateParameter("@EmployeeID", SqlDbType.Int, EmployeeID), base.CreateParameter("@SZID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet Get_Report_SalesPerformance(int EmployeeID, int SZID, int FY, DateTime FromDate, DateTime ToDate, int CustCateID)
        {
            return base.ExecuteDataSet("idv_Chetana_REP_SalesPerformance7", new IDataParameter[] { base.CreateParameter("@EmployeeID", SqlDbType.Int, EmployeeID), base.CreateParameter("@SZID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@CustCateID", SqlDbType.Int, CustCateID) });
        }

        public DataSet Get_Report_SalesPerformance_Customer1(int EmployeeID, int FY)
        {
            return base.ExecuteDataSet("idv_Chetana_REP_SalesPerformance_Customer1", new IDataParameter[] { base.CreateParameter("@empid", SqlDbType.Int, EmployeeID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Report_SalesPerformance_OnCustomer(int empid)
        {
            return base.ExecuteDataSet("idv_Chetana_REP_SalesPerformance_Customer", new IDataParameter[] { base.CreateParameter("@empid", SqlDbType.Int, empid) });
        }

        public DataSet Get_Report_SalesPerformance_OnCustomer(int empid, int FY)
        {
            return base.ExecuteDataSet("idv_Chetana_REP_SalesPerformance_Customer", new IDataParameter[] { base.CreateParameter("@empid", SqlDbType.Int, empid), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Report_SalesPerformance_OnCustomer(int empid, int FY, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("idv_Chetana_REP_SalesPerformance_Customer", new IDataParameter[] { base.CreateParameter("@empid", SqlDbType.Int, empid), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet Get_Report_SalesPerformance_OnEmployee(int ZID)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_SalesPerformance_Employee", new IDataParameter[] { base.CreateParameter("@ZoneId", SqlDbType.Int, ZID) });
        }

        public DataSet Get_Report_SalesPerformanceForBookSet(int SZID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_SalesPerformance_ForBookSet", new IDataParameter[] { base.CreateParameter("@SZID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Report_SalesPerformanceForBookSet(int SZID, int FY, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_SalesPerformance_ForBookSet", new IDataParameter[] { base.CreateParameter("@SZID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet Get_Report_SalesPerformanceForDiscountParties(int SZID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_SalesPerformance_ForDiscountParties", new IDataParameter[] { base.CreateParameter("@SZID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Report_SalesPerformanceForDiscountParties(int SZID, int FY, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_SalesPerformance_ForDiscountParties", new IDataParameter[] { base.CreateParameter("@SZID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet Get_Report_TargetAchievement(int SZID, int FY, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_TargetAchievement", new IDataParameter[] { base.CreateParameter("@SuperzoneID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet Get_Report_TargetAchievement(int SZID, int FY, DateTime FromDate, DateTime ToDate, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_TargetAchievement", new IDataParameter[] { base.CreateParameter("@SuperzoneID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_Reports_SpecimenDashBoard(string flag, string flag1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Reports_SpecimenDashBoard", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1) });
        }

        public DataSet Get_RoleList()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_RoleMaster", null);
        }

        public DataSet Get_SalesAnalysis_PART_II(int SuperZone, int strFY, DateTime fromdate, DateTime todate, int Zone, string flag, int SDZone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_SalesAnalysis_PART_II", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@FromDate", SqlDbType.DateTime, fromdate), base.CreateParameter("@toDate", SqlDbType.DateTime, todate), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@SDZone", SqlDbType.Int, SDZone) });
        }

        public DataSet Get_SalesAnalysisReport(int SuperZone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_SalesAnalysis", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone) });
        }

        public DataSet Get_SalesAnalysisReport(int SuperZone, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_SalesAnalysis", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_SalesAnalysisReport(int SuperZone, int strFY, DateTime fromdate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_SalesAnalysis", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@FromDate", SqlDbType.DateTime, fromdate), base.CreateParameter("@toDate", SqlDbType.DateTime, todate) });
        }

        public DataSet Get_SalesAnalysisReport(int SuperZone, int strFY, DateTime fromdate, DateTime todate, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_SalesAnalysis", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@FromDate", SqlDbType.DateTime, fromdate), base.CreateParameter("@toDate", SqlDbType.DateTime, todate), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Get_SalesAnalysisReport(int SuperZone, int strFY, DateTime fromdate, DateTime todate, int Zone, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_SalesAnalysis", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@FromDate", SqlDbType.DateTime, fromdate), base.CreateParameter("@toDate", SqlDbType.DateTime, todate), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_SalesAnalysisReport(int SuperZone, int strFY, DateTime fromdate, DateTime todate, int Zone, string flag, int SDZone, string CustCateID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_SalesAnalysis", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@FromDate", SqlDbType.DateTime, fromdate), base.CreateParameter("@toDate", SqlDbType.DateTime, todate), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@SDZone", SqlDbType.Int, SDZone), base.CreateParameter("@CustCateID", SqlDbType.NVarChar, CustCateID) });
        }

        public DataSet Get_SalesmanwiseBooks(string code, DateTime fromdate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_Get_SalesmanwiseBooks", new IDataParameter[] { base.CreateParameter("@code", SqlDbType.NVarChar, code), base.CreateParameter("@fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet Get_Scheme_Customer_Mapping(string Flag, string Flag1, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Scheme_Customer_Mapping", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@flag1", SqlDbType.NVarChar, Flag1), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Specimen_NotConfirmed_Books()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Specimen_NotConfirmed_Books", null);
        }

        public DataTable Get_SpecimenDetails_SubDocNo_ByDocID(int DocNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecimenDetails_SubDocNo_ByDocID", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo) }).Tables[0];
        }

        public DataSet Get_SpecimenDetailsForInvoice(int DocumentNo, decimal SubConfirmID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecimenDetailsForInvoice", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SubConfirmID", SqlDbType.Decimal, SubConfirmID) });
        }

        public DataSet Get_SpecimenDetailsForInvoice_BookWise(string BookCode, DateTime fromdate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecimenDetailsForInvoice_Bookwise", new IDataParameter[] { base.CreateParameter("@bookcode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet Get_SpecimenDetailsForInvoice_Customerwise(string CustID, DateTime fromdate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecimenDetailsForInvoice_Customerwise", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.NVarChar, CustID), base.CreateParameter("@fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet Get_SpecimenMaster(int DocumentNo, string SalesmanCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecimenMaster", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SalesmanCode", SqlDbType.NVarChar, SalesmanCode) });
        }

        public DataSet Get_SpecTransporterAndDetails(decimal subDocid, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecTransporterAndDetails", new IDataParameter[] { base.CreateParameter("@Subdocid", SqlDbType.Decimal, subDocid), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_StockReport()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_StockReport", null);
        }

        public DataSet Get_Sub_Menu_By_MainMenu_ID(int SubMenuId)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MenuSub_Master_By_MainMenuId", new IDataParameter[] { base.CreateParameter("@MainMenuId", SqlDbType.Int, SubMenuId) });
        }

        public DataSet Get_SubConfirmID_onDocumentNo(int DocumentNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SubConfirmID_onDocumentNo", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo) });
        }

        public DataSet Get_SubDocId_And_ItsRecords_By_DocNo(int DocNo, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SubDocId_And_ItsRecords_By_DocNo", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_Summary_SalesAnalysis(int SuperZone, int strFY, int Zone, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_Summary_SalesAnalysis", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_Summary_SalesAnalysis(int SuperZone, int strFY, int Zone, string flag, int SDZone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_Summary_SalesAnalysis", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@SDZone", SqlDbType.Int, SDZone) });
        }

        public DataSet get_Target_validateh_valid()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SalesHierarchy", null);
        }

        public DataSet get_Target_validateh_valid(int empid, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Target_validate", new IDataParameter[] { base.CreateParameter("@empid", SqlDbType.Int, empid), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_TargetMaster(int Fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_TargetMaster", new IDataParameter[] { base.CreateParameter("@Fy", SqlDbType.Int, Fy) });
        }

        public DataSet Get_TOD(int CustID, int FY, int Superzone, string Flags)
        {
            return base.ExecuteDataSet("Idv_Chetana_TOD", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Flag", SqlDbType.VarChar, Flags) });
        }

        public DataSet Get_TStyle_Report(string custCode, int zoneid, int FY, string Flag, DateTime Fromdate, DateTime Todate)
        {
            return base.ExecuteDataSet("Idv_chetana_Report_T_Style", new IDataParameter[] { base.CreateParameter("@custCode", SqlDbType.NVarChar, custCode), base.CreateParameter("@zoneid", SqlDbType.Int, zoneid), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@FromDate", SqlDbType.DateTime, Fromdate), base.CreateParameter("@ToDate", SqlDbType.DateTime, Todate) });
        }

        public DataSet Get_UserAccess(string Access, string RoleId)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_UserAccess", new IDataParameter[] { base.CreateParameter("@RoleId", SqlDbType.NVarChar, RoleId), base.CreateParameter("@access", SqlDbType.NVarChar, Access) });
        }

        public DataSet Get_UserLogin(string EmpCode, string Password)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_UserLogin", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode) });
        }

        public DataSet Get_UserLoginDetails(string EmpCode)
        {
            return base.ExecuteDataSet("idv_chetana_get_LoginUser_visibility", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode) });
        }

        public DataSet Get_Validate_VirtualInvoice(int Invoice, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_VirtualInvoiceNo", new IDataParameter[] { base.CreateParameter("@Invoice", SqlDbType.Int, Invoice), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_VirtualStockDatails(int InvoiceNo, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_VirtualStockDatails", new IDataParameter[] { base.CreateParameter("@InvoiceNo", SqlDbType.Int, InvoiceNo), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataTable GetAlphabets()
        {
            return base.ExecuteDataSet("Idv_Chetana_Other_GetAlphabets", null).Tables[0];
        }

        public DataSet GetAreaMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_AreaMaster", null);
        }

        public DataSet GetAreazoneMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_AreaZoneMaster", null);
        }

        public DataSet GetBankMaster(string BankCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BankMaster", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode) });
        }

        public DataSet GetBookKind(string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BookKindMaster", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet GetBookMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_All_BookMaster", null);
        }

        public DataSet GetBookMaster(string strChetanaCompanyName)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_All_BookMaster", new IDataParameter[] { base.CreateParameter("@ChetanaCompanyName", SqlDbType.NVarChar, strChetanaCompanyName) });
        }

        public DataSet GetBooksetdetails_ByBooksetID(int BookSetID)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetBooksetdetails_ByBooksetID", new IDataParameter[] { base.CreateParameter("@booksetID", SqlDbType.Int, BookSetID) });
        }

        public DataSet GetBooksMaster(string BookCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BookMaster", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode) });
        }

        public DataSet GetChallanNoAuthentication(string ChallanNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ChallanNoAuthentication", new IDataParameter[] { base.CreateParameter("@ChallanNo", SqlDbType.NVarChar, ChallanNo) });
        }

        public DataSet GetCMSCodeValidation(string Group, string code)
        {
            return base.ExecuteDataSet("SP_Get_Validate_If_Exists", new IDataParameter[] { base.CreateParameter("@Group", SqlDbType.NVarChar, Group), base.CreateParameter("@code", SqlDbType.NVarChar, code) });
        }

        public DataSet GetCodeValidation(string Group, string code)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_If_Exists", new IDataParameter[] { base.CreateParameter("@Group", SqlDbType.NVarChar, Group), base.CreateParameter("@code", SqlDbType.NVarChar, code) });
        }

        public DataSet GetCompanyMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CompanyMaster", null);
        }

        public DataSet GetCustomerandTransporter()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Customer_Transport", null);
        }

        public DataSet GetCustomerCategoryMaster(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerCategoryMaster", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataTable GetDashboard()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Dashboard", null).Tables[0];
        }

        public DataSet GetDashBoardAllotQty(string EmpCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Dashboard_AllotQty", new IDataParameter[] { base.CreateParameter("@empcode", SqlDbType.NVarChar, EmpCode) });
        }

        public DataTable GetDashboardgrid()
        {
            return base.ExecuteDataSet("Sp_RecentEnquires", null).Tables[0];
        }

        public DataTable GetDashboardhelpdesk(string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_HelpDeskDashboard", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag) }).Tables[0];
        }

        public DataTable GetDashboardhelpdesk2(string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_HelpDeskDashboard", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag) }).Tables[0];
        }

        public DataSet GetDescription_Of_bookset(int booksetid, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetDescription_Of_bookset", new IDataParameter[] { base.CreateParameter("@Booksetid", SqlDbType.Int, booksetid), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetDestination(string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DestinationMaster", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet GetDestinationMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DestinationMaster", null);
        }

        public DataSet GetEmployeeByFlag(int flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_All_EmployeeMaster_Flag", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.Int, flag) });
        }

        public DataSet GetEmployeemaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_EmployeeMaster", null);
        }

        public DataSet GetEmployeeOnAreaWise(string EmpCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_AreaName_onUserLogin", new IDataParameter[] { base.CreateParameter("@code", SqlDbType.NVarChar, EmpCode) });
        }

        public DataSet GetExpenseHead()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ExpenseHead", null);
        }

        public DataSet GetFinancialYear()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_FinancialYear", null);
        }

        public DataSet GetGroupmaster(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_GroupMaster", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetIDByCode(string Code, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ID_ON_code", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataTable getLoginLogDetails(string userID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_LoginLogDetails", new IDataParameter[] { base.CreateParameter("@LoginUserID", SqlDbType.NVarChar, userID) }).Tables[0];
        }

        public DataSet GetMasterOfMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MasterOfMaster", null);
        }

        public DataSet getMenu_By_RoleId(int RoleId, int MenuLevel, int ParentId)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetMenues_By_Role", new IDataParameter[] { base.CreateParameter("@RoleId", SqlDbType.Int, RoleId), base.CreateParameter("@MenuLevel", SqlDbType.Int, MenuLevel), base.CreateParameter("@ParentId", SqlDbType.Int, ParentId) });
        }

        public DataSet GetMenudisplayAndRole(int RoleId)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MenuDisplayAndForRole", new IDataParameter[] { base.CreateParameter("@RoleId", SqlDbType.Int, RoleId) });
        }

        public DataSet GetMenuFunctions(int GroupId, int RoleID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Menu_Functions", new IDataParameter[] { base.CreateParameter("@GroupId", SqlDbType.Int, GroupId), base.CreateParameter("@RoleID", SqlDbType.Int, RoleID) });
        }

        public DataSet GetMenuMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MenuMaster", null);
        }

        public DataSet GetMenuRoleMapping()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MenuRoleMapping", null);
        }

        public DataSet GetMenuUserMapping(int RoleId)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MenuUserMapping", new IDataParameter[] { base.CreateParameter("@RoleId", SqlDbType.Int, RoleId) });
        }

        public DataSet GetNameByCode(string Code, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Codes", new IDataParameter[] {
                base.CreateParameter("@Code", SqlDbType.NVarChar, Code),
                base.CreateParameter("@Flag", SqlDbType.NVarChar, flag)
            });
        }

        public DataSet GetNameHelp(string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Codes_Help", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet GetOrderNoAuthentication(string OrderNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_OrderNo_Authentication", new IDataParameter[] { base.CreateParameter("@OrderNo", SqlDbType.NVarChar, OrderNo) });
        }

        public DataSet GetPendingApprovedDocNo()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PedingDocNo_IsApproved", null);
        }

        public DataSet GetPendingDocNo()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PedingDocNo", null);
        }

        public DataSet GetPendingDocNo(string flag, DateTime frmDate, DateTime toDate, int fy, string flag1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PedingDocNo", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@frmDate", SqlDbType.DateTime, frmDate), base.CreateParameter("@toDate", SqlDbType.DateTime, toDate), base.CreateParameter("@fy", SqlDbType.Int, fy), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1) });
        }

        public DataSet GetRemarksDashBoard(string TktNumber)
        {
            string paramValue = "RemarkAllDashboard";
            return base.ExecuteDataSet("Sp_TktHistory", new IDataParameter[] { base.CreateParameter("@TktNumber", SqlDbType.NVarChar, TktNumber), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet GetReturnBook()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ReturnBook", null);
        }

        public DataSet GetReturnBookR(int SalesManId, string flag)
        {
            return base.ExecuteDataSet("IDV_Chetana_Get_ReturnBookSummary", new IDataParameter[] { base.CreateParameter("@SalesManId", SqlDbType.Int, SalesManId), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet GetRoleMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_RoleMaster", null);
        }

        public DataSet GetSchool_Names(string EmpCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Customers", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode) });
        }

        public DataSet GetSDZonemaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SDZoneMaster", null);
        }

        public DataSet GetSectionMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SectionMaster", null);
        }

        public DataSet GetSepcimanMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecimenMaster", null);
        }

        public DataSet GetSeverityMaster(string Flag)
        {
            return base.ExecuteDataSet("SP_SelectSeverity_Master", new IDataParameter[] { base.CreateParameter("@Action", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetSpecimenDatilsByEmpCode(string EmpCode, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecimenDetails", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetStatusMaster(string Flag)
        {
            return base.ExecuteDataSet("SP_SelectStatus_Master", new IDataParameter[] { base.CreateParameter("@Action", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetSuperzonemaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SuperZoneMaster", null);
        }

        public DataSet GetTypeMaster(string Flag)
        {
            return base.ExecuteDataSet("SP_SelectInquiryTypeMaster", new IDataParameter[] { base.CreateParameter("@Action", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetZonemaster(int ZoneID, int Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ZoneMaster", new IDataParameter[] { base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@Flag", SqlDbType.Int, Flag) });
        }

        public DataSet GetZoneMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Zone_For_SuperZone", null);
        }

        public DataSet Idev_Chetana_BankReceipt_Report(string BankCode, int DocumentNo, string strFY)
        {
            return base.ExecuteDataSet("Idev_Chetana_BankReceipt_Report", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@FY", SqlDbType.NVarChar, strFY) });
        }

        public DataSet Idv_check_Customer_for_delete(string Flag, string Code)
        {
            return base.ExecuteDataSet("Idv_chetana_check_for_delete", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@Code", SqlDbType.NVarChar, Code) });
        }

        public DataSet Idv_Chetana_CMS_Check()
        {
            return base.ExecuteDataSet("Idv_Chetana_CMS_Check", new IDataParameter[0]);
        }

        public DataSet Idv_Chetana_CMS_TKTESCALATE(string Flag)
        {
            return base.ExecuteDataSet("SP_CMS_TKTESCALATELevel", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Idv_Chetana_Customer_BlackList(int CustID, string FromDate, string ToDate, decimal FromAmt, int FY, int Superzone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Customer_BlackList", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FromAmount", SqlDbType.Money, FromAmt), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Idv_Chetana_Customer_HelpDesk(string custcode, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Customer_Quick_DashBoard", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, custcode), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Idv_Chetana_Customer_Summary_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Customer_Summary_Report", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Idv_Chetana_Customer_Summary_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Customer_Summary_Report", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode) });
        }

        public DataSet Idv_Chetana_Customer_Summary_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode, decimal Amount, string Flags, string iszero)
        {
            return base.ExecuteDataSet("Idv_Chetana_Customer_Summary_Report", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Flags", SqlDbType.VarChar, Flags), base.CreateParameter("@iszero", SqlDbType.NVarChar, iszero) });
        }

        public DataSet Idv_Chetana_Customer_WisePendingDC(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_CustomerWise_PendingDC", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Idv_Chetana_Customer_WisePendingDC(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, int flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_CustomerWise_PendingDC", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@flagWhat", SqlDbType.Int, flag) });
        }

        public DataSet Idv_Chetana_Customer_ZoneDate_Report(int CustID, string FromDate, string ToDate, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Customer_ZoneDate_Report", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_Customer_ZoneDate_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Customer_ZoneDate_Report", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone ", SqlDbType.Int, Zone) });
        }

        public DataSet Idv_Chetana_Customer_ZoneDate_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Customer_ZoneDate_Report", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone ", SqlDbType.Int, Zone), base.CreateParameter("@CustCode ", SqlDbType.NVarChar, CustCode) });
        }

        public DataSet Idv_Chetana_Customer_ZoneDate_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode, string iszero)
        {
            return base.ExecuteDataSet("Idv_Chetana_Customer_ZoneDate_Report", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone ", SqlDbType.Int, Zone), base.CreateParameter("@CustCode ", SqlDbType.NVarChar, CustCode), base.CreateParameter("@iszero", SqlDbType.NVarChar, iszero) });
        }

        public DataSet Idv_Chetana_DC_Get_Details_By_DocNO_Report3(int DocNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Details_By_DocNO_Report3", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo) });
        }

        public DataSet Idv_Chetana_DC_Report_Get_PedingDocNo_ForDCConfirmation(int SuperDuperZoneId, int SuperZoneId, DateTime FromDate, DateTime ToDate, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Report_Get_PedingDocNo_ForDCConfirmation", new IDataParameter[] { base.CreateParameter("@SuperDuperZoneId", SqlDbType.Int, SuperDuperZoneId), base.CreateParameter("@SuperZoneId", SqlDbType.Int, SuperZoneId), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_EditInvoiceDelivery_Status(decimal InvoiceNo, int Fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_EditInvoiceDelivery_Status", new IDataParameter[] { base.CreateParameter("@InvoiceNo", SqlDbType.Decimal, InvoiceNo), base.CreateParameter("@FY", SqlDbType.Int, Fy) });
        }

        public DataSet Idv_Chetana_Get_AccountMain()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_AccountMain", null);
        }

        public DataSet Idv_Chetana_Get_CustomerDetailsForReport(int CustID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerDetailsForReport", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID) });
        }

        public DataSet Idv_Chetana_Get_idv_chetana_main_group_Sub()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_idv_chetana_main_group_Sub", null);
        }

        public DataSet Idv_Chetana_Get_main_group()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_main_group", null);
        }

        public DataSet Idv_Chetana_Get_Main_group_sub()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Main_group_sub", null);
        }

        public DataSet Idv_chetana_Get_Month()
        {
            return base.ExecuteDataSet("Idv_chetana_Get_Month", null);
        }

        public DataSet Idv_Chetana_Get_PettyCashBook(string Code, int FY, string remark1, string remark2, string remark3, string remark4)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PettyCashBook", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@remark1", SqlDbType.NVarChar, remark1), base.CreateParameter("@remark2", SqlDbType.NVarChar, remark2), base.CreateParameter("@remark3", SqlDbType.NVarChar, remark3), base.CreateParameter("@remark4", SqlDbType.NVarChar, remark4) });
        }

        public DataSet Idv_Chetana_Get_SpecimenDetails_By_DocNo_Report(int DocNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecimenDetails_By_DocNo_Report", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo) });
        }

        public DataSet Idv_Chetana_Get_SpecTransporterAndDetails_Report1(decimal subDocid)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecTransporterAndDetails_Report1", new IDataParameter[] { base.CreateParameter("@Subdocid", SqlDbType.Decimal, subDocid) });
        }

        public DataSet Idv_Chetana_Get_StatusFor_Report(int SZID, DateTime FromDate, DateTime ToDate, int Fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_InvoiceDelivery_Status", new IDataParameter[] { base.CreateParameter("@Szid", SqlDbType.Int, SZID), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, Fy) });
        }

        public DataSet Idv_Chetana_Get_StatusFor_Report(int SZID, DateTime FromDate, DateTime ToDate, int Fy, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_InvoiceDelivery_Status", new IDataParameter[] { base.CreateParameter("@Szid", SqlDbType.Int, SZID), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, Fy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Idv_Chetana_Get_StatusFor_Report(int SZID, DateTime FromDate, DateTime ToDate, int Fy, string Flag, int ZoneID, string Flag1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_InvoiceDelivery_Status", new IDataParameter[] { base.CreateParameter("@Szid", SqlDbType.Int, SZID), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, Fy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@Flag1", SqlDbType.NVarChar, Flag1) });
        }

        public DataSet Idv_Chetana_Get_SubDocId_And_ItsRecords_By_DocNo_forReport(decimal subDocid)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SubDocId_And_ItsRecords_By_DocNo_forReport", new IDataParameter[] { base.CreateParameter("@Subdocid", SqlDbType.Decimal, subDocid) });
        }

        public DataSet Idv_Chetana_Get_SubGroup(int SubGroup)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SubGroup", new IDataParameter[] { base.CreateParameter("@MainCode", SqlDbType.Int, SubGroup) });
        }

        public DataSet Idv_Chetana_Get_ZoneCustomer(int Code1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ZoneCustomer", new IDataParameter[] { base.CreateParameter("@Zone", SqlDbType.Int, Code1) });
        }

        public DataSet Idv_Chetana_Get_ZoneCustomerAdditionalCommission(int Code1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ZoneAdditionalCommission", new IDataParameter[] { base.CreateParameter("@Zone", SqlDbType.Int, Code1) });
        }

        public DataSet Idv_Chetana_Get_ZoneCustomerBlackList(int Code1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ZoneCustomerBlackList", new IDataParameter[] { base.CreateParameter("@Zone", SqlDbType.Int, Code1) });
        }

        public DataSet Idv_Chetana_Get_ZoneCustomerBookSeller(int Code1)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ZoneCustomerBookSeller", new IDataParameter[] { base.CreateParameter("@Zone", SqlDbType.Int, Code1) });
        }

        public DataSet Idv_Chetana_Get_ZoneCustomerTOD(int SZone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SZoneCustomer", new IDataParameter[] { base.CreateParameter("@SZone", SqlDbType.Int, SZone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Idv_Chetana_GetInvoiceDeliveryStatusDetails(decimal InvoiceNo, int Fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetInvoiceDeliveryStatusDetails", new IDataParameter[] { base.CreateParameter("@InvoiceNo", SqlDbType.Decimal, InvoiceNo), base.CreateParameter("@FY", SqlDbType.Int, Fy) });
        }

        public DataSet Idv_Chetana_Rep_BookSeller(int CustID, int FY, int Superzone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_BookSeller", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Idv_Chetana_Rep_CallReport(string FromDate, string ToDate, string TicketNoFrom, string TicketNoTo, string Status, int CustID, string Action)
        {
            return base.ExecuteDataSet("SP_RptTicketHistory", new IDataParameter[] { base.CreateParameter("@InqFromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@InqToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@TKTNOFrom", SqlDbType.NVarChar, TicketNoFrom), base.CreateParameter("@TKTTODate", SqlDbType.NVarChar, TicketNoTo), base.CreateParameter("@Status", SqlDbType.NVarChar, Status), base.CreateParameter("@CustNo", SqlDbType.Int, CustID), base.CreateParameter("@Action", SqlDbType.NVarChar, Action) });
        }

        public DataSet Idv_Chetana_Rep_Customer_AdditionalCommission(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Customer_AdditionalCommission", new IDataParameter[] { base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCateID", SqlDbType.Int, CustCateID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_Rep_Customer_AdditionalCommissionamt(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Customer_AdditionalCommissionamt", new IDataParameter[] { base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCateID", SqlDbType.Int, CustCateID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_Rep_Customer_AdditionalCommissionatreport(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Customer_AdditionalCommissionamt", new IDataParameter[] { base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCateID", SqlDbType.Int, CustCateID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_Rep_Customer_AdditionalCommissionCal(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Customer_AdditionalCommissionCAL7", new IDataParameter[] { base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCateID", SqlDbType.Int, CustCateID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_Rep_Customer_BlacklistedParty(string CustCateID, int CustID, int FY, int Superzone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Customer_BlacklistedParty", new IDataParameter[] { base.CreateParameter("@CustCateID", SqlDbType.NVarChar, CustCateID), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Idv_Chetana_Rep_Customer_DisburseAdditionalCommission(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Customer_DisburseAdditionalCommission", new IDataParameter[] { base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCateID", SqlDbType.Int, CustCateID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public void Idv_Chetana_Rep_Customer_SaveDisburseAdditionalCommission(string CustCode, decimal NETBILLAMT, decimal NETCNAMT, decimal NETAMT, decimal NETADDDIS, decimal GROSSBILLAMT, decimal GROSSCNAMT, decimal GROSSNETAMT, decimal GROSSADDDIS, decimal Amount, string Details, int FY, string CreatedBy, out int DACId)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DisburseAdditionalCommission", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@NETBILLAMT", SqlDbType.Decimal, NETBILLAMT), base.CreateParameter("@NETCNAMT", SqlDbType.Decimal, NETCNAMT), base.CreateParameter("@NETAMT", SqlDbType.Decimal, NETAMT), base.CreateParameter("@NETADDDIS", SqlDbType.Decimal, NETADDDIS), base.CreateParameter("@GROSSBILLAMT", SqlDbType.Decimal, GROSSBILLAMT), base.CreateParameter("@GROSSCNAMT", SqlDbType.Decimal, GROSSCNAMT), base.CreateParameter("@GROSSNETAMT", SqlDbType.Decimal, GROSSNETAMT), base.CreateParameter("@GROSSADDDIS", SqlDbType.Decimal, GROSSADDDIS), base.CreateParameter("@Amount", SqlDbType.Decimal, Amount), base.CreateParameter("@Details", SqlDbType.NVarChar, Details), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@DACId", SqlDbType.Int, ParameterDirection.Output) });
            DACId = Convert.ToInt32(command.Parameters["@DACId"].Value);
            command.Dispose();
        }

        public DataSet Idv_Chetana_Rep_Customer_TODReport(int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Customer_TODReport", new IDataParameter[] { base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCateID", SqlDbType.Int, CustCateID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_Rep_CustomerWise_Sales(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_CustomerWise_Sales", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Idv_Chetana_Rep_CustomerWise_Sales(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, int Percent)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_CustomerWise_Sales", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@percent", SqlDbType.Int, Percent) });
        }

        public DataSet Idv_Chetana_Rep_CustomerWise_SalesReport(string CustCateID, int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, int Percent)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_CustomerWise_Sales", new IDataParameter[] { base.CreateParameter("@CustCateID", SqlDbType.NVarChar, CustCateID), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@percent", SqlDbType.Int, Percent) });
        }

        public void Idv_Chetana_Save_InvoiceDelivery_Status(int AutoId, decimal InvoiceNo, DateTime InvoiceDate, string CustCode, string CustName, string Area, string DeliveryStatus, decimal TotalAmount, string CreatedBy, bool IsActive, int FY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_InvoiceDelivery_Status", new IDataParameter[] { base.CreateParameter("@AutoId", SqlDbType.Int, AutoId), base.CreateParameter("@InvoiceNo", SqlDbType.Decimal, InvoiceNo), base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, InvoiceDate), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@CustName", SqlDbType.NVarChar, CustName), base.CreateParameter("@Area", SqlDbType.NVarChar, Area), base.CreateParameter("@DeliveryStatus", SqlDbType.NVarChar, DeliveryStatus), base.CreateParameter("@TotalAmount", SqlDbType.Decimal, TotalAmount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@FY", SqlDbType.Int, FY) });
            command.Dispose();
        }

        public void idv_chetana_Save_main_group(int AutoId, int Main_Code, string MAIN_HEAD, bool Inactive, string createdby)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "idv_chetana_Save_main_group", new IDataParameter[] { base.CreateParameter("@AutoId", SqlDbType.Int, AutoId), base.CreateParameter("@Main_Code", SqlDbType.Int, Main_Code), base.CreateParameter("@MAIN_HEAD", SqlDbType.NVarChar, MAIN_HEAD), base.CreateParameter("@Inactive", SqlDbType.Bit, Inactive), base.CreateParameter("@createdby", SqlDbType.NVarChar, createdby) });
            command.Dispose();
        }

        public void Idv_chetana_Save_main_group_Sub(int Main_Code, string Sub_HEAD, bool Inactive, int AutoId)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_chetana_Save_main_group_Sub", new IDataParameter[] { base.CreateParameter("@Main_Code", SqlDbType.Int, Main_Code), base.CreateParameter("@Sub_HEAD", SqlDbType.NVarChar, Sub_HEAD), base.CreateParameter("@Inactive", SqlDbType.Bit, Inactive), base.CreateParameter("@AutoId", SqlDbType.Int, AutoId) });
            command.Dispose();
        }

        public DataSet Idv_Chetana_TokenWise_Sales_Report(DateTime FromDate, DateTime ToDate, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_TokenWise_Sales_Report", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_TokenWise_Sales_Report(DateTime FromDate, DateTime ToDate, int FY, string Flag1, string Flag2, string Flag3)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_TokenWise_Sales_Report", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Flag1", SqlDbType.NVarChar, Flag1), base.CreateParameter("@Flag2", SqlDbType.NVarChar, Flag2), base.CreateParameter("@Flag3", SqlDbType.NVarChar, Flag3) });
        }

        public void Idv_Chetana_Upload_Opening_Balance(string createdBy, int Fy, string Flag, string remark1, string remark2, string remark3)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Upload_Opening_Balance", new IDataParameter[] { base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@Fy", SqlDbType.Int, Fy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@Remark1", SqlDbType.NVarChar, remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, remark3) });
            command.Dispose();
        }

        public DataSet Idv_Get_SpecimenDetails_By_DocNo(int DocNo, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SpecimenDetails_By_DocNo", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet REP_Physical_STOCK(string BookCode)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Physical_STOCK", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode) });
        }

        public DataSet REP_Physical_STOCK(string BookCode, int FY)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Physical_STOCK", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet REP_Physical_STOCK(string BookCode, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Physical_STOCK", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet REP_Physical_STOCK(string BookCode, DateTime FromDate, DateTime ToDate, int FY)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Physical_STOCK", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet REP_Physical_STOCK_ReOrder_Level(string BookCode)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Physical_STOCK_ReOrder_Level", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode) });
        }

        public DataSet REP_Physical_STOCK_ReOrder_Level(string BookCode, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Physical_STOCK_ReOrder_Level", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet REP_Virtual_STOCK(string BookCode)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Virtual_STOCK", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode) });
        }

        public DataSet REP_Virtual_STOCK(string BookCode, int FY)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Virtual_STOCK", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet REP_Virtual_STOCK(string BookCode, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Virtual_STOCK", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet REP_Virtual_STOCK(string BookCode, DateTime FromDate, DateTime ToDate, int FY)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Virtual_STOCK", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet REP_Virtual_STOCK_ReOrder_Level(string BookCode)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Virtual_STOCK_ReOrder_Level", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode) });
        }

        public DataSet REP_Virtual_STOCK_ReOrder_Level(string BookCode, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_Virtual_STOCK_ReOrder_Level", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public void Save_booktype_Custmer_discount_Mapping(int BKTYPCustDisID, string Custcode, int BookType, decimal Discount, decimal AdDiscount, bool IsActive, bool IsDeleted)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_booktype_Custmer_discount_Mapping", new IDataParameter[] { base.CreateParameter("@BKTYPCustDisID", SqlDbType.Int, BKTYPCustDisID), base.CreateParameter("@CustCode", SqlDbType.NVarChar, Custcode), base.CreateParameter("@BookType", SqlDbType.Int, BookType), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@AddDisc", SqlDbType.Money, AdDiscount), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted) });
            command.Dispose();
        }

        public void Save_CMS_Email(string TktNumber, string CreatedBy, bool IsActive)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_CMS_Email", new IDataParameter[] { base.CreateParameter("@TktNumber", SqlDbType.NVarChar, TktNumber), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive) });
            command.Dispose();
        }

        public void Save_CollectionTarget(int _AutoID, int _SuperZoneID, string _MonthName, decimal _TargetPercent, int _FY, bool _IsActive, bool _IsDelete, string _CreatedBy, string _Remark1, string _Remark2, string _Remark3, string _Remark4, string _Remark5, decimal TargetAmt)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CollectionTarget", new IDataParameter[] { base.CreateParameter("@AutoID", SqlDbType.Int, _AutoID), base.CreateParameter("@SuperZoneID", SqlDbType.Int, _SuperZoneID), base.CreateParameter("@MonthName", SqlDbType.NVarChar, _MonthName), base.CreateParameter("@TargetPercent", SqlDbType.Decimal, _TargetPercent), base.CreateParameter("@FY", SqlDbType.Int, _FY), base.CreateParameter("@IsActive", SqlDbType.Bit, _IsActive), base.CreateParameter("@IsDelete", SqlDbType.Bit, _IsDelete), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, _CreatedBy), base.CreateParameter("@Remark1", SqlDbType.NVarChar, _Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, _Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, _Remark3), base.CreateParameter("@Remark4", SqlDbType.NVarChar, _Remark4), base.CreateParameter("@Remark5", SqlDbType.NVarChar, _Remark5), base.CreateParameter("@TargetAmt", SqlDbType.Decimal, TargetAmt) });
            command.Dispose();
        }

        public void Save_CustomerDetails(int CustDetailID, string CustCode, string CreditLimit, bool BlackList, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy, string PrincipalName, string PrincipalMobile, string PrincipalDOB, string KeyPersonName, string KeyPersonMobile, string KeyPersonDOB, string AdditinalDis, string VIPRemark, string Medium, int SectionID, int custid, string CreditDays, int BoardID, decimal Business_Potential, decimal CGP, string Association, string Payment_Track, string Remark1, string Remark2, string Remark3, string Remark4, string Remark5, string BlackListDate, string BlackListRemark)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CustomerDetails", new IDataParameter[] { 
                base.CreateParameter("@CustDetailID", SqlDbType.Int, CustDetailID), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@CreditLimit", SqlDbType.NVarChar, CreditLimit), base.CreateParameter("@BlackList", SqlDbType.Bit, BlackList), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@PrincipalName", SqlDbType.NVarChar, PrincipalName), base.CreateParameter("@PrincipalMobile", SqlDbType.NVarChar, PrincipalMobile), base.CreateParameter("@PrincipalDOB", SqlDbType.NVarChar, PrincipalDOB), base.CreateParameter("@KeyPersonName", SqlDbType.NVarChar, KeyPersonName), base.CreateParameter("@KeyPersonMobile", SqlDbType.NVarChar, KeyPersonMobile), base.CreateParameter("@KeyPersonDOB", SqlDbType.NVarChar, KeyPersonDOB), base.CreateParameter("@AdditinalDis", SqlDbType.NVarChar, AdditinalDis), base.CreateParameter("@VIPRemark", SqlDbType.NVarChar, VIPRemark),
                base.CreateParameter("@Medium", SqlDbType.NVarChar, Medium), base.CreateParameter("@SectionID", SqlDbType.Int, SectionID), base.CreateParameter("@CustId", SqlDbType.Int, custid), base.CreateParameter("@CreditDays", SqlDbType.NVarChar, CreditDays), base.CreateParameter("@BoardID", SqlDbType.Int, BoardID), base.CreateParameter("@Business_Potential", SqlDbType.Money, Business_Potential), base.CreateParameter("@CGP", SqlDbType.Money, CGP), base.CreateParameter("@Association", SqlDbType.NVarChar, Association), base.CreateParameter("@Payment_Track", SqlDbType.NVarChar, Payment_Track), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3), base.CreateParameter("@Remark4", SqlDbType.NVarChar, Remark4), base.CreateParameter("@Remark5", SqlDbType.NVarChar, Remark5), base.CreateParameter("@BlacklistDate", SqlDbType.NVarChar, BlackListDate), base.CreateParameter("@Blacklistremark", SqlDbType.NVarChar, BlackListRemark)
            });
            command.Dispose();
        }

        public void Save_DiscountamountDetails(string CustCode, decimal ADDITIONALAMT)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "IDV_CHETANA_UPDATEDISCOUNTAMOUNT", new IDataParameter[] { base.CreateParameter("@CODE", SqlDbType.NVarChar, CustCode), base.CreateParameter("@AMOUNT", SqlDbType.Decimal, ADDITIONALAMT) });
            command.Dispose();
        }

        public void Save_FrightTax_Details(int DocumentNo, decimal SubConfirmID, decimal fright, decimal tax, decimal tamount, string CreatedBy)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_FreightTax", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SubConfirmID", SqlDbType.Decimal, SubConfirmID), base.CreateParameter("@Freight", SqlDbType.Decimal, fright), base.CreateParameter("@Tax", SqlDbType.Decimal, tax), base.CreateParameter("@TotalAmount", SqlDbType.Decimal, tamount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public void Save_GenerateInvoice_Details(decimal SubDocId, bool IsCreateInvoice, string CreatedInvoiceBy, string Transporter, string Lrno, string Bundles, DateTime InvoiceDate)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_GenerateInvoice_Details", new IDataParameter[] { base.CreateParameter("@SubDocId", SqlDbType.Decimal, SubDocId), base.CreateParameter("@IsCreateInvoice", SqlDbType.Bit, IsCreateInvoice), base.CreateParameter("@CreatedInvoiceBy", SqlDbType.NVarChar, CreatedInvoiceBy), base.CreateParameter("@Transporter", SqlDbType.NVarChar, Transporter), base.CreateParameter("@Lrno", SqlDbType.NVarChar, Lrno), base.CreateParameter("@Bundles", SqlDbType.NVarChar, Bundles), base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, InvoiceDate) });
            command.Dispose();
        }

        public void Save_Scheme_Customer_Mapping(int SchemeMappingID, int SchemeID, string CustID, string Years, decimal Discount, int FY, bool ISS, bool IsActive, bool Isdeleted, string CreatedBy, string Remark1, string Remark2, string Remark3, decimal Amount, string startYear)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Scheme_Customer_Mapping", new IDataParameter[] { base.CreateParameter("@SchemeMappingID", SqlDbType.Int, SchemeMappingID), base.CreateParameter("@SchemeID", SqlDbType.Int, SchemeID), base.CreateParameter("@CustID", SqlDbType.NVarChar, CustID), base.CreateParameter("@Years", SqlDbType.NVarChar, Years), base.CreateParameter("@Discount", SqlDbType.Decimal, Discount), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@ISS", SqlDbType.Bit, ISS), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@startYear", SqlDbType.NVarChar, startYear) });
            command.Dispose();
        }

        public void Save_Scheme_Customer_Mapping(int SchemeMappingID, int SchemeID, string CustID, string Years, decimal Discount, int FY, bool ISS, bool IsActive, bool Isdeleted, string CreatedBy, string Remark1, string Remark2, string Remark3, decimal Amount, string startYear, bool IsDelivered, bool IsReceived, DateTime DeliveredDate, DateTime ReceivedDate)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Scheme_Customer_Mapping", new IDataParameter[] { 
                base.CreateParameter("@SchemeMappingID", SqlDbType.Int, SchemeMappingID), base.CreateParameter("@SchemeID", SqlDbType.Int, SchemeID), base.CreateParameter("@CustID", SqlDbType.NVarChar, CustID), base.CreateParameter("@Years", SqlDbType.NVarChar, Years), base.CreateParameter("@Discount", SqlDbType.Decimal, Discount), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@ISS", SqlDbType.Bit, ISS), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@startYear", SqlDbType.NVarChar, startYear), base.CreateParameter("@IsDelivered", SqlDbType.Bit, IsDelivered),
                base.CreateParameter("@IsReceived", SqlDbType.Bit, IsReceived), base.CreateParameter("@DeliveredDate", SqlDbType.DateTime, DeliveredDate), base.CreateParameter("@ReceivedDate", SqlDbType.Bit, ReceivedDate)
            });
            command.Dispose();
        }

        public void Save_Specimen_AllotQty_To_Customer(int AllotCustID, int SpecimenDetailId, int CustID, int AllotQty, bool IsDelete, DateTime CreatedOn, string CreatedBy, DateTime UpdatedOn, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Specimen_AllotQty_To_Customer", new IDataParameter[] { base.CreateParameter("@AllotCustID", SqlDbType.Int, AllotCustID), base.CreateParameter("@SpecimenDetailId", SqlDbType.Int, SpecimenDetailId), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@AllotQty", SqlDbType.Int, AllotQty), base.CreateParameter("@IsDelete", SqlDbType.Bit, IsDelete), base.CreateParameter("@CreatedOn", SqlDbType.DateTime, CreatedOn), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedOn", SqlDbType.DateTime, UpdatedOn), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void Save_Specimen_PrintInvoiceDetails(int PrintInvoiceDetails, decimal SubDocId, bool IsPrintInvoice, int PrintCount, string CreatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Specimen_PrintInvoiceDetails", new IDataParameter[] { base.CreateParameter("@PrintInvoiceDetails", SqlDbType.Int, PrintInvoiceDetails), base.CreateParameter("@SubDocId", SqlDbType.Decimal, SubDocId), base.CreateParameter("@IsPrintInvoice", SqlDbType.Bit, IsPrintInvoice), base.CreateParameter("@PrintCount", SqlDbType.Int, PrintCount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
            command.Dispose();
        }

        public void Save_SpecimenConfirmQtyDetails(int ConfirmDcQtyId, int SpecimenDetailID, int AvailableQty, decimal subDocNo)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_SpecimenConfirmQtyDetails1", new IDataParameter[] { base.CreateParameter("@ConfirmDcQtyId", SqlDbType.Int, ConfirmDcQtyId), base.CreateParameter("@SpecimenDetailID", SqlDbType.Int, SpecimenDetailID), base.CreateParameter("@AvailableQty", SqlDbType.Int, AvailableQty), base.CreateParameter("@SubDocNo", SqlDbType.Decimal, subDocNo) });
        }

        public void Save_SpecimenToGodown(int SpecimenDetailID, int DocumentNo, string EmpID, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SpecimenToGodown", new IDataParameter[] { base.CreateParameter("@SpecimenDetailID", SqlDbType.Int, SpecimenDetailID), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@EmpID", SqlDbType.NVarChar, EmpID), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void save_team(int teamautid, decimal teamid, int empid, bool isact, out int teamautidO)
        {
            SqlCommand command;
            teamautidO = 0;
            base.ExecuteNonQuery(out command, "idv_chetana_save_emp_team", new IDataParameter[] { base.CreateParameter("@teamautid", SqlDbType.Int, teamautid), base.CreateParameter("@teamid", SqlDbType.Money, teamid), base.CreateParameter("@empid", SqlDbType.Int, empid), base.CreateParameter("@checked", SqlDbType.Bit, isact), base.CreateParameter("@teamautidO", SqlDbType.Int, (int)teamautidO, ParameterDirection.Output) });
            teamautidO = Convert.ToInt32(command.Parameters["@teamautidO"].Value.ToString());
            command.Dispose();
        }

        public void SaveAllocate(int TargetdetailsId, int TargetId, int TargetPersonId, decimal TargetAmt, int Personlevel, DateTime TargetStartDate, DateTime TargetEndDate, string CreatedBy, bool IsActive)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_AllocateKRA", new IDataParameter[] { base.CreateParameter("@TargetdetailsId", SqlDbType.Int, TargetdetailsId), base.CreateParameter("@TargetId", SqlDbType.Int, TargetId), base.CreateParameter("@TargetPersonId", SqlDbType.Int, TargetPersonId), base.CreateParameter("@TargetAmt", SqlDbType.Decimal, TargetAmt), base.CreateParameter("@Personlevel", SqlDbType.Int, Personlevel), base.CreateParameter("@TargetStartDate", SqlDbType.DateTime, TargetStartDate), base.CreateParameter("@TargetEndDate", SqlDbType.DateTime, TargetEndDate), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Isactive", SqlDbType.Bit, IsActive) });
        }

        public void SaveAreaEmployee_Mapping(int EAmapping, int Empid, int Aid, bool Isactive)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_EmployeeAndArea_Mapping", new IDataParameter[] { base.CreateParameter("@EAmappingID", SqlDbType.Int, EAmapping), base.CreateParameter("@EmpID", SqlDbType.Int, Empid), base.CreateParameter("@AreaID", SqlDbType.Int, Aid), base.CreateParameter("@IsActive", SqlDbType.Bit, Isactive) });
            command.Dispose();
        }

        public void SaveAreaMaster(int AreaID, string AreaCode, int AreaZoneID, string AreaName, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_AreaMaster", new IDataParameter[] { base.CreateParameter("@AreaID", SqlDbType.Int, AreaID), base.CreateParameter("@AreaCode", SqlDbType.NVarChar, AreaCode), base.CreateParameter("@AreaName", SqlDbType.NVarChar, AreaName), base.CreateParameter("@AreaZoneID", SqlDbType.Int, AreaZoneID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@createdBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveAreaZoneMaster(int AreaZoneID, string AreaZoneCode, string AreaZoneName, int ZoneID, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_AreaZoneMaster", new IDataParameter[] { base.CreateParameter("@AreaZoneID", SqlDbType.Int, AreaZoneID), base.CreateParameter("@AreaZoneCode", SqlDbType.NVarChar, AreaZoneCode), base.CreateParameter("@AreaZoneName", SqlDbType.NVarChar, AreaZoneName), base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
        }

        public void SaveBank(int BankID, string BankCode, string BankName, string BankDescription, string Country, int State, int City, string CreatedBy, bool IsActive, bool IsDelete)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BankMaster", new IDataParameter[] { base.CreateParameter("@BankID", SqlDbType.Int, BankID), base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@BankName", SqlDbType.NVarChar, BankName), base.CreateParameter("@BankDescription", SqlDbType.NVarChar, BankDescription), base.CreateParameter("@Country", SqlDbType.NVarChar, Country), base.CreateParameter("@State", SqlDbType.Int, State), base.CreateParameter("@City", SqlDbType.Int, City), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDelete", SqlDbType.Bit, IsDelete) });
            command.Dispose();
        }

        public void Savebook(int BookID, string BookCode, string BookName, string BookType, string Bookgroup, string Standard, decimal PurchasePrice, decimal SellingPrice, decimal OMPrice, decimal OIPrice, string Medium, bool UpdateRate, int Quantity, bool IsActive, bool IsDeleted, string CreatedBy, string Description, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BookMaster", new IDataParameter[] { 
                base.CreateParameter("@BookID", SqlDbType.Int, BookID), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@BookName", SqlDbType.NVarChar, BookName), base.CreateParameter("@BookType", SqlDbType.NVarChar, BookType), base.CreateParameter("@Bookgroup", SqlDbType.NVarChar, Bookgroup), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@PurchasePrice", SqlDbType.Money, PurchasePrice), base.CreateParameter("@SellingPrice", SqlDbType.Money, SellingPrice), base.CreateParameter("@OMPrice", SqlDbType.Money, OMPrice), base.CreateParameter("OIPrice", SqlDbType.Money, OIPrice), base.CreateParameter("@Medium", SqlDbType.NVarChar, Medium), base.CreateParameter("@UpdateRate", SqlDbType.Bit, UpdateRate), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy)
            });
            command.Dispose();
        }

        public void Savebook(int BookID, string BookCode, string BookName, string BookType, string Bookgroup, string Standard, decimal PurchasePrice, decimal SellingPrice, decimal OMPrice, decimal OIPrice, string Medium, bool UpdateRate, int Quantity, bool IsActive, bool IsDeleted, string CreatedBy, string Description, string UpdatedBy, string strChetanaCompnayName)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BookMaster", new IDataParameter[] { 
                base.CreateParameter("@BookID", SqlDbType.Int, BookID), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@BookName", SqlDbType.NVarChar, BookName), base.CreateParameter("@BookType", SqlDbType.NVarChar, BookType), base.CreateParameter("@Bookgroup", SqlDbType.NVarChar, Bookgroup), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@PurchasePrice", SqlDbType.Money, PurchasePrice), base.CreateParameter("@SellingPrice", SqlDbType.Money, SellingPrice), base.CreateParameter("@OMPrice", SqlDbType.Money, OMPrice), base.CreateParameter("OIPrice", SqlDbType.Money, OIPrice), base.CreateParameter("@Medium", SqlDbType.NVarChar, Medium), base.CreateParameter("@UpdateRate", SqlDbType.Bit, UpdateRate), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@ChetanaCompnayName", SqlDbType.NVarChar, strChetanaCompnayName)
            });
            command.Dispose();
        }

        public void Savebook(int BookID, string BookCode, string BookName, string BookType, string Bookgroup, string Standard, decimal PurchasePrice, decimal SellingPrice, decimal OMPrice, decimal OIPrice, string Medium, bool UpdateRate, int Quantity, bool IsActive, bool IsDeleted, string CreatedBy, string Description, string UpdatedBy, string strChetanaCompnayName, int FY, int PhysicalStock, int VirtualStock, bool IsBlock)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BookMaster", new IDataParameter[] { 
                base.CreateParameter("@BookID", SqlDbType.Int, BookID), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@BookName", SqlDbType.NVarChar, BookName), base.CreateParameter("@BookType", SqlDbType.NVarChar, BookType), base.CreateParameter("@Bookgroup", SqlDbType.NVarChar, Bookgroup), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@PurchasePrice", SqlDbType.Money, PurchasePrice), base.CreateParameter("@SellingPrice", SqlDbType.Money, SellingPrice), base.CreateParameter("@OMPrice", SqlDbType.Money, OMPrice), base.CreateParameter("OIPrice", SqlDbType.Money, OIPrice), base.CreateParameter("@Medium", SqlDbType.NVarChar, Medium), base.CreateParameter("@UpdateRate", SqlDbType.Bit, UpdateRate), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@ChetanaCompnayName", SqlDbType.NVarChar, strChetanaCompnayName), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@PhysicalStock", SqlDbType.Int, PhysicalStock), base.CreateParameter("@VirtualStock", SqlDbType.Int, VirtualStock), base.CreateParameter("@IsBlock", SqlDbType.Bit, IsBlock)
            });
            command.Dispose();
        }

        public void SaveBookKindmaster(int BMID, string Name, int ParentID, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy, string BMCode)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BookKindMaster", new IDataParameter[] { base.CreateParameter("@BMID", SqlDbType.Int, BMID), base.CreateParameter("@Name", SqlDbType.NVarChar, Name), base.CreateParameter("@ParentID", SqlDbType.Int, ParentID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@createdBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@BMCode", SqlDbType.NVarChar, BMCode) });
            command.Dispose();
        }

        public void SaveCompanyMaster(int CompanyID, string CompanyCode, string CompanyName, string CompanyShortform, string Address, int AreaID, int CityID, string Zip, string Phone1, string Phone2, string EmailID, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CompanyMaster", new IDataParameter[] { base.CreateParameter("@CompanyID", SqlDbType.Int, CompanyID), base.CreateParameter("@CompanyCode", SqlDbType.NVarChar, CompanyCode), base.CreateParameter("@CompanyName", SqlDbType.NVarChar, CompanyName), base.CreateParameter("@CompanyShortform", SqlDbType.NVarChar, CompanyShortform), base.CreateParameter("@Address", SqlDbType.NVarChar, Address), base.CreateParameter("@AreaID", SqlDbType.Int, AreaID), base.CreateParameter("@CityID", SqlDbType.Int, AreaID), base.CreateParameter("@Zip", SqlDbType.NVarChar, Zip), base.CreateParameter("@Phone1", SqlDbType.NVarChar, Phone1), base.CreateParameter("@Phone2", SqlDbType.NVarChar, Phone2), base.CreateParameter("@EmailID", SqlDbType.NVarChar, EmailID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveConfirmDC(int SpecimenDetailID, int DocumentNo, string BookCode, string BookName, string Standard, string Medium, int Quantity, int AvaliableQty, string Publisher)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SpecimenDetails", new IDataParameter[] { base.CreateParameter("@SpecimenDetailID", SqlDbType.Int, SpecimenDetailID), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@BookName", SqlDbType.VarChar, BookName), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@Medium", SqlDbType.VarChar, Medium), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@AvaliableQty", SqlDbType.Int, AvaliableQty), base.CreateParameter("@Publisher", SqlDbType.NVarChar, Publisher) });
            command.Dispose();
        }

        public void SaveCustomerCategoryMaster(int CMID, string Name, int ParentID, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy, string CMCode)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CustomerCategoryMaster", new IDataParameter[] { base.CreateParameter("@CMID", SqlDbType.Int, CMID), base.CreateParameter("@Name", SqlDbType.NVarChar, Name), base.CreateParameter("@ParentID", SqlDbType.Int, ParentID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@CMCode", SqlDbType.NVarChar, CMCode) });
            command.Dispose();
        }

        public void SaveCustomerMaster(int CustID, string CustCode, string ShortForm, string FamilyCode, int AreaId, string Address, string Zip, string Phone1, string Phone2, string EmailID, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy, string CustName, string CUSTOMERTYPE, int SuperZoneID, int ZoneID, int AreaZoneID, int DMID, out int CID, int City, int CustRating, int Year, int CMID, int CMIDsub, string SchAdditionalDis, string TODValue1, string TODValue2, string TODValue3, string TODDisc1, string TODDisc2, string TODDisc3)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CustomerMaster", new IDataParameter[] { 
                base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@ShortForm", SqlDbType.NVarChar, ShortForm), base.CreateParameter("@FamilyCode", SqlDbType.NVarChar, FamilyCode), base.CreateParameter("@AreaId", SqlDbType.Int, AreaId), base.CreateParameter("@Address", SqlDbType.NVarChar, Address), base.CreateParameter("@Zip", SqlDbType.NVarChar, Zip), base.CreateParameter("@Phone1", SqlDbType.NVarChar, Phone1), base.CreateParameter("@Phone2", SqlDbType.NVarChar, Phone2), base.CreateParameter("@EmailID", SqlDbType.NVarChar, EmailID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@CustName", SqlDbType.NVarChar, CustName), base.CreateParameter("@CUSTOMERTYPE", SqlDbType.NVarChar, CUSTOMERTYPE),
                base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@AreaZoneID", SqlDbType.Int, AreaZoneID), base.CreateParameter("@DMID", SqlDbType.Int, DMID), base.CreateParameter("@CID", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@City", SqlDbType.Int, City), base.CreateParameter("@CustRating", SqlDbType.Int, CustRating), base.CreateParameter("@Fy", SqlDbType.Int, Year), base.CreateParameter("@CMID", SqlDbType.Int, CMID), base.CreateParameter("@CMIDsub", SqlDbType.Int, CMIDsub), base.CreateParameter("@SchAdditionalDis", SqlDbType.NVarChar, SchAdditionalDis), base.CreateParameter("@TODValue1", SqlDbType.NVarChar, TODValue1), base.CreateParameter("@TODValue2", SqlDbType.NVarChar, TODValue2), base.CreateParameter("@TODValue3", SqlDbType.NVarChar, TODValue3), base.CreateParameter("@TODDisc1", SqlDbType.NVarChar, TODDisc1), base.CreateParameter("@TODDisc2", SqlDbType.NVarChar, TODDisc2),
                base.CreateParameter("@TODDisc3", SqlDbType.NVarChar, TODDisc3)
            });
            CID = Convert.ToInt32(command.Parameters["@CID"].Value);
            command.Dispose();
        }

        public void SaveDestination(int DMID, string DMCode, string Name, int ParentID, int IsActive, int IsDeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DestinationMaster", new IDataParameter[] { base.CreateParameter("@DMID", SqlDbType.Int, DMID), base.CreateParameter("@DMCode", SqlDbType.NVarChar, DMCode), base.CreateParameter("@Name", SqlDbType.NVarChar, Name), base.CreateParameter("@ParentID", SqlDbType.Int, ParentID), base.CreateParameter("@IsActive", SqlDbType.Int, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Int, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void Savedestinationmaster(int DMID, string Name, int ParentID, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy, string DMCode)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DestinationMaster", new IDataParameter[] { base.CreateParameter("@DMID", SqlDbType.Int, DMID), base.CreateParameter("@Name", SqlDbType.NVarChar, Name), base.CreateParameter("@ParentID", SqlDbType.Int, ParentID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@createdBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@DMCode", SqlDbType.NVarChar, DMCode) });
            command.Dispose();
        }

        public void SaveDetails(int DetailID, int MasterID, string Code, string Name, int Quantity, bool IsActive, bool Isdeleted, string CreatedBy, string UpdatedBy, string Standard, int FY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_VirualStockDetails", new IDataParameter[] { base.CreateParameter("@DetailID", SqlDbType.Int, DetailID), base.CreateParameter("@MasterID", SqlDbType.Int, MasterID), base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@Name", SqlDbType.NVarChar, Name), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@FY", SqlDbType.Int, FY) });
            command.Dispose();
        }

        public void SaveEmployee(string EmpCode, string FirstName, string MiddleName, string LastName, string Address, string City, string Zip, string Phone1, string Phone2, string Gender, string DOB, string Qualification, string Designation, string EmailID, string DepartmentID, int ZoneID, int SuperZoneID, int AreaZoneID, int AreaID, string State, string Photo, DateTime JoinDate, DateTime ResignationDate, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy, int EmpID, int SDZoneID, out int EId)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_EmployeeMaster", new IDataParameter[] { 
                base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@FirstName", SqlDbType.NVarChar, FirstName), base.CreateParameter("@MiddleName", SqlDbType.NVarChar, MiddleName), base.CreateParameter("@LastName", SqlDbType.NVarChar, LastName), base.CreateParameter("@Address", SqlDbType.NVarChar, Address), base.CreateParameter("@City", SqlDbType.NVarChar, City), base.CreateParameter("@Zip", SqlDbType.NVarChar, Zip), base.CreateParameter("@Phone1", SqlDbType.NVarChar, Phone1), base.CreateParameter("@Phone2", SqlDbType.NVarChar, Phone2), base.CreateParameter("@Gender", SqlDbType.NVarChar, Gender), base.CreateParameter("@DOB", SqlDbType.NVarChar, DOB), base.CreateParameter("@Qualification", SqlDbType.NVarChar, Qualification), base.CreateParameter("@Designation", SqlDbType.NVarChar, Designation), base.CreateParameter("@EmailID", SqlDbType.NVarChar, EmailID), base.CreateParameter("@DepartmentID", SqlDbType.NVarChar, DepartmentID), base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID),
                base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@AreaZoneID", SqlDbType.Int, AreaZoneID), base.CreateParameter("@AreaID", SqlDbType.Int, AreaID), base.CreateParameter("@State", SqlDbType.NVarChar, State), base.CreateParameter("@Photo", SqlDbType.NVarChar, Photo), base.CreateParameter("@JoinDate", SqlDbType.DateTime, JoinDate), base.CreateParameter("@ResignationDate", SqlDbType.DateTime, ResignationDate), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@EmpID", SqlDbType.Int, EmpID), base.CreateParameter("@SDZoneID", SqlDbType.Int, SDZoneID), base.CreateParameter("@EId", SqlDbType.Int, ParameterDirection.Output)
            });
            EId = Convert.ToInt32(command.Parameters["@EId"].Value);
            command.Dispose();
        }

        public void SaveExpenseHead(int ExpenseId, string ExpenseCode, string ExpenseName, int ExpenseType, int ExpenseGroup, string Description, bool IsActive, bool IsDeleted, string createdBy, string EType, string Egroup)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_ExpenseHead", new IDataParameter[] { base.CreateParameter("@AutoId", SqlDbType.Int, ExpenseId), base.CreateParameter("@ExpenseCode", SqlDbType.NVarChar, ExpenseCode), base.CreateParameter("@ExpenseName", SqlDbType.NVarChar, ExpenseName), base.CreateParameter("@Expensetype", SqlDbType.Int, ExpenseType), base.CreateParameter("@ExpenseGroup", SqlDbType.Int, ExpenseGroup), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDelete", SqlDbType.Bit, IsDeleted), base.CreateParameter("@createdBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@Type", SqlDbType.NVarChar, EType), base.CreateParameter("@Group", SqlDbType.NVarChar, Egroup) });
            command.Dispose();
        }

        public void SaveFinancialYear(int yearAutoId, string FromYear, string ToYear, bool IsActive, string CreatedBy, string UpdatedBy)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_FinancialYear", new IDataParameter[] { base.CreateParameter("@yearID", SqlDbType.Int, yearAutoId), base.CreateParameter("@fromyear", SqlDbType.NVarChar, FromYear), base.CreateParameter("@toyear", SqlDbType.NVarChar, ToYear), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
        }

        public void SaveGroupMaster(int GroupId, string GroupCode, string GroupName, string Remark, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_GroupMaster", new IDataParameter[] { base.CreateParameter("@@GrpID", SqlDbType.Int, GroupId), base.CreateParameter("@GrpCode", SqlDbType.NVarChar, GroupCode), base.CreateParameter("@GrpName", SqlDbType.NVarChar, GroupName), base.CreateParameter("@Remark", SqlDbType.NVarChar, Remark), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveIdv_chetana_Account_main(int AutoID, string AC_CODE, string AC_NAME, string AC_GROUP, string AC_ADD1, string AC_ADD2, string AC_ADD3,
            string TEL1, string TEL2, string TELR, string CITY_CODE, string PIN_CODE, string STATE_CODE, string COUNTRY, string ZONE_CODE, string BROKER, string MEDIUM,
            decimal BROK_PERC, string PRIN_int, string BLACKLIST, string AC_TYPE, string AC_ST_NO, string AC_PA_NO, string AC_CST_NO, decimal AC_int_RAT, decimal AC_TDS_LIM,
            decimal AC_TDS_RAT, bool AC_H15, decimal AC_DEPR_C, decimal AC_DEPR_N, string GST_NO, string APPLICABLE_GST, string TRANSPORT, string PAYEE_BANK, int CR_DAYS,
            decimal DISC_PREC, string TAX_TYPE, string AREA, int SR_ORDER, decimal OPEN_BAL, decimal PROFIT, decimal REMUNA, decimal CR_LIMIT, decimal SP_DISC, string EMAIL_NO,
            string MOR_TIME, string EVE_TIME, string IN_CHARGE, string CTYPE_CODE, string L_O, string FAM_CODE, string CF_CODE, string INSTRCTION, string VIC_REMARK,
            string DELETEREC, bool ACTIVE, string INSTRUCT2, string INSTRUCT3, string INSTRUCT4, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_chetana_Save_Account_main", new IDataParameter[] { 
                base.CreateParameter("@AutoID", SqlDbType.Int, AutoID),
                base.CreateParameter("@AC_CODE", SqlDbType.NVarChar, AC_CODE),
                base.CreateParameter("@AC_NAME", SqlDbType.NVarChar, AC_NAME),
                base.CreateParameter("@AC_GROUP", SqlDbType.NVarChar, AC_GROUP),
                base.CreateParameter("@AC_ADD1", SqlDbType.NVarChar, AC_ADD1),
                base.CreateParameter("@AC_ADD2", SqlDbType.NVarChar, AC_ADD2),
                base.CreateParameter("@AC_ADD3", SqlDbType.NVarChar, AC_ADD3),
                base.CreateParameter("@TEL1", SqlDbType.NVarChar, TEL1),
                base.CreateParameter("@TEL2", SqlDbType.NVarChar, TEL2),
                base.CreateParameter("@TELR", SqlDbType.NVarChar, TELR),
                base.CreateParameter("@CITY_CODE", SqlDbType.NVarChar, CITY_CODE),
                base.CreateParameter("@PIN_CODE", SqlDbType.NVarChar, PIN_CODE),
                base.CreateParameter("@STATE_CODE", SqlDbType.NVarChar, STATE_CODE),
                base.CreateParameter("@COUNTRY", SqlDbType.NVarChar, COUNTRY),
                base.CreateParameter("@ZONE_CODE", SqlDbType.NVarChar, ZONE_CODE),
                base.CreateParameter("@BROKER", SqlDbType.NVarChar, BROKER),
                base.CreateParameter("@MEDIUM", SqlDbType.NVarChar, MEDIUM),
                base.CreateParameter("@BROK_PERC", SqlDbType.Decimal, BROK_PERC),
                base.CreateParameter("@PRIN_int", SqlDbType.NVarChar, PRIN_int),
                base.CreateParameter("@BLACKLIST", SqlDbType.NVarChar, BLACKLIST),
                base.CreateParameter("@AC_TYPE", SqlDbType.NVarChar, AC_TYPE),
                base.CreateParameter("@AC_ST_NO", SqlDbType.NVarChar, AC_ST_NO),
                base.CreateParameter("@AC_PA_NO", SqlDbType.NVarChar, AC_PA_NO),
                base.CreateParameter("@AC_CST_NO", SqlDbType.NVarChar, AC_CST_NO),
                base.CreateParameter("@AC_int_RAT", SqlDbType.Decimal, AC_int_RAT),
                base.CreateParameter("@AC_TDS_LIM", SqlDbType.Decimal, AC_TDS_LIM),
                base.CreateParameter("@AC_TDS_RAT", SqlDbType.Decimal, AC_TDS_RAT),
                base.CreateParameter("@AC_H15", SqlDbType.Bit, AC_H15),
                base.CreateParameter("@AC_DEPR_C", SqlDbType.Decimal, AC_DEPR_C),
                base.CreateParameter("@AC_DEPR_N", SqlDbType.Decimal, AC_DEPR_N),
                base.CreateParameter("@GST_NO", SqlDbType.NVarChar, GST_NO),
                base.CreateParameter("@APPLICABLE_GST", SqlDbType.NVarChar, APPLICABLE_GST),
                base.CreateParameter("@TRANSPORT", SqlDbType.NVarChar, TRANSPORT),
                base.CreateParameter("@PAYEE_BANK", SqlDbType.NVarChar, PAYEE_BANK),
                base.CreateParameter("@CR_DAYS", SqlDbType.Int, CR_DAYS),
                base.CreateParameter("@DISC_PREC", SqlDbType.Decimal, DISC_PREC),
                base.CreateParameter("@TAX_TYPE", SqlDbType.NVarChar, TAX_TYPE),
                base.CreateParameter("@AREA", SqlDbType.NVarChar, AREA),
                base.CreateParameter("@SR_ORDER", SqlDbType.Int, SR_ORDER),
                base.CreateParameter("@OPEN_BAL", SqlDbType.Decimal, OPEN_BAL),
                base.CreateParameter("@PROFIT", SqlDbType.Decimal, PROFIT),
                base.CreateParameter("@REMUNA", SqlDbType.Decimal, REMUNA),
                base.CreateParameter("@CR_LIMIT", SqlDbType.Decimal, CR_LIMIT),
                base.CreateParameter("@SP_DISC", SqlDbType.Decimal, SP_DISC),
                base.CreateParameter("@EMAIL_NO", SqlDbType.NVarChar, EMAIL_NO),
                base.CreateParameter("@MOR_TIME", SqlDbType.NVarChar, MOR_TIME),
                base.CreateParameter("@EVE_TIME", SqlDbType.NVarChar, EVE_TIME),
                base.CreateParameter("@IN_CHARGE", SqlDbType.NVarChar, IN_CHARGE),
                base.CreateParameter("@CTYPE_CODE", SqlDbType.NVarChar, CTYPE_CODE),
                base.CreateParameter("@L_O", SqlDbType.NVarChar, L_O),
                base.CreateParameter("@FAM_CODE", SqlDbType.NVarChar, FAM_CODE),
                base.CreateParameter("@CF_CODE", SqlDbType.NVarChar, CF_CODE),
                base.CreateParameter("@INSTRCTION", SqlDbType.NVarChar, INSTRCTION),
                base.CreateParameter("@VIC_REMARK", SqlDbType.NVarChar, VIC_REMARK),
                base.CreateParameter("@DELETEREC", SqlDbType.NVarChar, DELETEREC),
                base.CreateParameter("@ACTIVE", SqlDbType.Bit, ACTIVE),
                base.CreateParameter("@INSTRUCT2", SqlDbType.NVarChar, INSTRUCT2),
                base.CreateParameter("@INSTRUCT3", SqlDbType.NVarChar, INSTRUCT3),
                base.CreateParameter("@INSTRUCT4", SqlDbType.NVarChar, INSTRUCT4),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy)
            });

            command.Dispose();
        }

        public void SaveIDV_Chetana_sub_group(int MAIN_Code, string GR_HEAD, int SR_ORDER, string SCHEDULE, string TYPE, string CONTROL, int AutoId)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "IDV_Chetana_Save_sub_group", new IDataParameter[] { base.CreateParameter("@MAIN_Code", SqlDbType.Int, MAIN_Code), base.CreateParameter("@GR_HEAD", SqlDbType.NVarChar, GR_HEAD), base.CreateParameter("@SR_ORDER", SqlDbType.Int, SR_ORDER), base.CreateParameter("@SCHEDULE", SqlDbType.NVarChar, SCHEDULE), base.CreateParameter("@TYPE", SqlDbType.NVarChar, TYPE), base.CreateParameter("@CONTROL", SqlDbType.NVarChar, CONTROL), base.CreateParameter("@AutoId", SqlDbType.Int, AutoId) });
            command.Dispose();
        }

        public void SaveLoginLog(int LoginLogId, string LoginPersonName, string LoginPesonId, DateTime LoginTime, DateTime LoggOutTime, string IpAddress, string ResonToLoggOut, out int outLoginLogId)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Login_Insert_LginLog", new IDataParameter[] { base.CreateParameter("@LoginLogId", SqlDbType.Int, LoginLogId), base.CreateParameter("@LoginPersonName", SqlDbType.NVarChar, LoginPersonName), base.CreateParameter("@LoginPesonId", SqlDbType.NVarChar, LoginPesonId), base.CreateParameter("@LoginTime", SqlDbType.DateTime, LoginTime), base.CreateParameter("@LoggOutTime", SqlDbType.DateTime, LoggOutTime), base.CreateParameter("@IpAddress", SqlDbType.NVarChar, IpAddress), base.CreateParameter("@ResonToLoggOut", SqlDbType.NVarChar, ResonToLoggOut), base.CreateParameter("@outLoginLogId", SqlDbType.Int, ParameterDirection.Output) });
            outLoginLogId = Convert.ToInt32(command.Parameters["@outLoginLogId"].Value);
            command.Dispose();
        }

        public void Savemasterofmaster(int AutoId, string key, string Value, string Group, string Description, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy, int BKID)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_MasterOfMaster", new IDataParameter[] { base.CreateParameter("@AutoId", SqlDbType.Int, AutoId), base.CreateParameter("@key", SqlDbType.NVarChar, key), base.CreateParameter("@Value", SqlDbType.NVarChar, Value), base.CreateParameter("@Group", SqlDbType.NVarChar, Group), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@BKID", SqlDbType.Int, BKID) });
            command.Dispose();
        }

        public void Savemenumaster(int MenuId, string MenuName, string Link, bool IsActive, bool IsDeleted)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_MenuMaster", new IDataParameter[] { base.CreateParameter("@MenuId", SqlDbType.Int, MenuId), base.CreateParameter("@MenuName", SqlDbType.NVarChar, MenuName), base.CreateParameter("@Link", SqlDbType.NVarChar, Link), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted) });
            command.Dispose();
        }

        public void SaveMenuusermapping(int UserMenuMappId, string GroupId, int MenuId, int RoleId, bool Add, bool View, bool Edit, bool Delete, bool show)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_MenuUserMapping", new IDataParameter[] { base.CreateParameter("@UserMenuMappId", SqlDbType.Int, UserMenuMappId), base.CreateParameter("@GroupId", SqlDbType.NVarChar, GroupId), base.CreateParameter("@MenuId", SqlDbType.Int, MenuId), base.CreateParameter("@RoleId", SqlDbType.Int, RoleId), base.CreateParameter("@Add", SqlDbType.Bit, Add), base.CreateParameter("@View", SqlDbType.Bit, View), base.CreateParameter("@Edit", SqlDbType.Bit, Edit), base.CreateParameter("@Delete", SqlDbType.Bit, Delete), base.CreateParameter("@Show", SqlDbType.Bit, show) });
            command.Dispose();
        }

        public void SavePurchaseDetails(int purchaseDetailID, int PurchaseMasterID, string Code, string Description, int Quantity, decimal Rate, decimal Amount, decimal Discount, string Per, bool IsActive, bool Isdeleted, string CreatedBy, string UpdatedBy, string Standard)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_PurchaseDetails", new IDataParameter[] { base.CreateParameter("@purchaseDetailID", SqlDbType.Int, purchaseDetailID), base.CreateParameter("@PurchaseMasterID", SqlDbType.Int, PurchaseMasterID), base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@Per", SqlDbType.NVarChar, Per), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard) });
            command.Dispose();
        }

        public void SavePurchaseDetails(int purchaseDetailID, int PurchaseMasterID, string Code, string Description, int Quantity, decimal Rate, decimal Amount, decimal Discount, string Per, bool IsActive, bool Isdeleted, string CreatedBy, string UpdatedBy, string Standard, int OriginalQty)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_PurchaseDetails", new IDataParameter[] { base.CreateParameter("@purchaseDetailID", SqlDbType.Int, purchaseDetailID), base.CreateParameter("@PurchaseMasterID", SqlDbType.Int, PurchaseMasterID), base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@Per", SqlDbType.NVarChar, Per), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@originalQuantity", SqlDbType.Int, OriginalQty) });
            command.Dispose();
        }

        public void SavePurchaseMaster(int PMId, int InvoiceNo, string SuppliersRef, DateTime InvoiceDate, string CreatedBy, string UpdatedBy, bool IsActive, bool IsDeleted, string SuppliersRefCode, string PurchaseCode, string PurchaseName, out int DocNo, int FY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_PurchaseMaster", new IDataParameter[] { base.CreateParameter("@AutoID", SqlDbType.Int, PMId), base.CreateParameter("@InvoiceNo", SqlDbType.Int, InvoiceNo), base.CreateParameter("@SuppliersRef", SqlDbType.NVarChar, SuppliersRef), base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, InvoiceDate), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@SuppliersRefCode", SqlDbType.NVarChar, SuppliersRefCode), base.CreateParameter("@PurchaseCode", SqlDbType.NVarChar, PurchaseCode), base.CreateParameter("@PurchaseName", SqlDbType.NVarChar, PurchaseName), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@FY", SqlDbType.Int, FY) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public void SavePurchaseMaster(int PMId, int InvoiceNo, string SuppliersRef, DateTime InvoiceDate, string CreatedBy, string UpdatedBy, bool IsActive, bool IsDeleted, string SuppliersRefCode, string PurchaseCode, string PurchaseName, out int DocNo, int FY, string oms, decimal ms)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_PurchaseMaster", new IDataParameter[] { base.CreateParameter("@AutoID", SqlDbType.Int, PMId), base.CreateParameter("@InvoiceNo", SqlDbType.Int, InvoiceNo), base.CreateParameter("@SuppliersRef", SqlDbType.NVarChar, SuppliersRef), base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, InvoiceDate), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@SuppliersRefCode", SqlDbType.NVarChar, SuppliersRefCode), base.CreateParameter("@PurchaseCode", SqlDbType.NVarChar, PurchaseCode), base.CreateParameter("@PurchaseName", SqlDbType.NVarChar, PurchaseName), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@ms_oms", SqlDbType.NVarChar, oms), base.CreateParameter("@vat", SqlDbType.Money, ms) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public void SaveReturnBook(int ReturnBkID, int DocumentNo, int SpecimenDetailID, int EmpID, int ReturnQty, string Comment, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_save_ReturnBook", new IDataParameter[] { base.CreateParameter("@ReturnBkID", SqlDbType.Int, ReturnBkID), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SpecimenDetailID", SqlDbType.Int, SpecimenDetailID), base.CreateParameter("@EmpID", SqlDbType.Int, EmpID), base.CreateParameter("@ReturnQty", SqlDbType.Int, ReturnQty), base.CreateParameter("@Comment", SqlDbType.NVarChar, Comment), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void Saverolemapping(int AutoId, int MenuId, int RoleId, bool IsActive)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_MenuRoleMapping", new IDataParameter[] { base.CreateParameter("@AutoId", SqlDbType.Int, AutoId), base.CreateParameter("@MenuId", SqlDbType.Int, MenuId), base.CreateParameter("@RoleId", SqlDbType.Int, RoleId), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive) });
            command.Dispose();
        }

        public void Saverolemaster(int RoleId, string RoleName, bool IsActive, bool IsDeleted)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_RoleMaster", new IDataParameter[] { base.CreateParameter("@RoleId", SqlDbType.Int, RoleId), base.CreateParameter("@RoleName", SqlDbType.NVarChar, RoleName), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted) });
            command.Dispose();
        }

        public void SaveSDZoneMaster(int SDZoneID, string SDZoneCode, string SDZoneName, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SDZoneMaster", new IDataParameter[] { base.CreateParameter("@SDZoneID", SqlDbType.Int, SDZoneID), base.CreateParameter("@SDZoneCode", SqlDbType.NVarChar, SDZoneCode), base.CreateParameter("@SDZoneName", SqlDbType.NVarChar, SDZoneName), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@createdBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveSectionMaster(int SectionID, string Sectioncode, string SectionName, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SectionMaster", new IDataParameter[] { base.CreateParameter("@SectionID", SqlDbType.Int, SectionID), base.CreateParameter("@Sectioncode", SqlDbType.NVarChar, Sectioncode), base.CreateParameter("@SectionName", SqlDbType.NVarChar, SectionName), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveSetofbooks(int BooksetDetailID, int BookSetCode, string BookCode, int Quantity, decimal SellingPrice, decimal OMPrice, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_SetofBooks", new IDataParameter[] { base.CreateParameter("@BooksetDetailID", SqlDbType.Int, BooksetDetailID), base.CreateParameter("@BookSetCode", SqlDbType.Int, BookSetCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@SellingPrice", SqlDbType.Money, SellingPrice), base.CreateParameter("@OMPrice", SqlDbType.Money, OMPrice), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
        }

        public void SaveSeverityMaster(int SeverityID, string Severity_Name, bool IsDefault, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "SP_InsertSeverity_Master", new IDataParameter[] { base.CreateParameter("@SeverityID", SqlDbType.Int, SeverityID), base.CreateParameter("@Severity_Name", SqlDbType.NVarChar, Severity_Name), base.CreateParameter("@IsDefault", SqlDbType.Bit, IsDefault), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void Savespeciman(int DocumentNo, DateTime DocumentDate, string ChallanNo, DateTime ChallanDate, string OrderNo, DateTime OrderDate, string SalesmanCode, string SpInstruction, string CreatedBy, string UpdatedBy, bool IsActive, bool IsDeleted, string Description, out int DocNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SpecimenMaster", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@DocumentDate", SqlDbType.DateTime, DocumentDate), base.CreateParameter("@ChallanNo", SqlDbType.NVarChar, ChallanNo), base.CreateParameter("@ChallanDate", SqlDbType.DateTime, ChallanDate), base.CreateParameter("@OrderNo", SqlDbType.NVarChar, OrderNo), base.CreateParameter("@OrderDate", SqlDbType.DateTime, OrderDate), base.CreateParameter("@SalesmanCode", SqlDbType.NVarChar, SalesmanCode), base.CreateParameter("@SpInstruction", SqlDbType.NVarChar, SpInstruction), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public void Savespeciman(int DocumentNo, DateTime DocumentDate, string ChallanNo, DateTime ChallanDate, string OrderNo, DateTime OrderDate, string SalesmanCode, string SpInstruction, string CreatedBy, string UpdatedBy, bool IsActive, bool IsDeleted, string Description, int strFY, out int DocNo, out int DocNoNew)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SpecimenMaster", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@DocumentDate", SqlDbType.DateTime, DocumentDate), base.CreateParameter("@ChallanNo", SqlDbType.NVarChar, ChallanNo), base.CreateParameter("@ChallanDate", SqlDbType.DateTime, ChallanDate), base.CreateParameter("@OrderNo", SqlDbType.NVarChar, OrderNo), base.CreateParameter("@OrderDate", SqlDbType.DateTime, OrderDate), base.CreateParameter("@SalesmanCode", SqlDbType.NVarChar, SalesmanCode), base.CreateParameter("@SpInstruction", SqlDbType.NVarChar, SpInstruction), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@DocNewNo", SqlDbType.Int, ParameterDirection.Output) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            DocNoNew = Convert.ToInt32(command.Parameters["@DocNewNo"].Value);
            command.Dispose();
        }

        public void SaveSpecimenDetails(int SpecimenDetailID, int DocumentNo, string BookCode, string BookName, string Standard, string Medium, int Quantity, decimal Rate, decimal Amount, decimal Discount, string Publisher, bool IsActive, bool Isdeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SpecimenDetails", new IDataParameter[] { base.CreateParameter("@SpecimenDetailID", SqlDbType.Int, SpecimenDetailID), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@BookName", SqlDbType.VarChar, BookName), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@Medium", SqlDbType.VarChar, Medium), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@Publisher", SqlDbType.NVarChar, Publisher), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveStatusMaster(int SeverityID, string Severity_Name, bool IsDefault, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "SP_InsertStatus_Master", new IDataParameter[] { base.CreateParameter("@Status_ID", SqlDbType.Int, SeverityID), base.CreateParameter("@Status_Name", SqlDbType.NVarChar, Severity_Name), base.CreateParameter("@IsDefault", SqlDbType.Bit, IsDefault), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveSuperZoneMaster(int SuperZoneID, string SuperZoneCode, string SuperZoneName, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy, string SEmailID, int SDZoneID)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SuperZoneMaster", new IDataParameter[] { base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@SuperZoneCode", SqlDbType.NVarChar, SuperZoneCode), base.CreateParameter("@SuperZoneName", SqlDbType.NVarChar, SuperZoneName), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@createdBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@SEmailID", SqlDbType.NVarChar, SEmailID), base.CreateParameter("@SDZoneID", SqlDbType.Int, SDZoneID) });
            command.Dispose();
        }

        public void SaveTarget(int TargetId, int TargetPersonId, decimal TargetAmt, int Personlevel, DateTime TargetStartDate, DateTime TargetEndDate, string CreatedBy, bool IsActive)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_TargetMaster", new IDataParameter[] { base.CreateParameter("@TargetId", SqlDbType.Int, TargetId), base.CreateParameter("@TargetPersonId", SqlDbType.Int, TargetPersonId), base.CreateParameter("@TargetAmt", SqlDbType.Decimal, TargetAmt), base.CreateParameter("@Personlevel", SqlDbType.Int, Personlevel), base.CreateParameter("@TargetStartDate", SqlDbType.DateTime, TargetStartDate), base.CreateParameter("@TargetEndDate", SqlDbType.DateTime, TargetEndDate), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Isactive", SqlDbType.Bit, IsActive) });
        }

        public void SaveTeamMaster(int TMID, string TNAME, string TDESC, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_TeamMaster", new IDataParameter[] { base.CreateParameter("@TMID", SqlDbType.Int, TMID), base.CreateParameter("@TName", SqlDbType.VarChar, TNAME), base.CreateParameter("@TDESC", SqlDbType.NVarChar, TDESC), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveTeamMember(int TMBID, string TeamGrpID, string TNAME, string EmpID, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_TeamMember", new IDataParameter[] { base.CreateParameter("@TMBID", SqlDbType.Int, TMBID), base.CreateParameter("@TeamGrpID", SqlDbType.VarChar, TeamGrpID), base.CreateParameter("@TNAME", SqlDbType.NVarChar, TNAME), base.CreateParameter("@EmpID", SqlDbType.NVarChar, EmpID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveTransporter(int CustTransportID, string CustCode, int TransportID, bool IsActive, bool Isdeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CustomerTransporter_Mapping", new IDataParameter[] { base.CreateParameter("@CustTransportID", SqlDbType.Int, CustTransportID), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@TransportID", SqlDbType.Int, TransportID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
        }

        public void SaveTypeMaster(int ITM_ID, string ITM_Name, string EmailFrom, string EmailSub, string EmailBody, string EmailSign, bool IsDefault, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "SP_InsertInquiryTypeMaster", new IDataParameter[] { base.CreateParameter("@ITM_ID", SqlDbType.Int, ITM_ID), base.CreateParameter("@ITM_Name", SqlDbType.NVarChar, ITM_Name), base.CreateParameter("@EmailFrom", SqlDbType.NVarChar, EmailFrom), base.CreateParameter("@EmailSub", SqlDbType.NVarChar, EmailSub), base.CreateParameter("@EmailBody", SqlDbType.NVarChar, EmailBody), base.CreateParameter("@EmailSign", SqlDbType.NVarChar, EmailSign), base.CreateParameter("@IsDefault", SqlDbType.Bit, IsDefault), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveUpdateBookStock(string BookCode, int stock, int Fy, string createdBy, string remark1, string remark2, string remark3)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BoookStock", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@stock", SqlDbType.Int, stock), base.CreateParameter("@Fy", SqlDbType.Int, Fy), base.CreateParameter("@createdBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@remark1", SqlDbType.NVarChar, remark1), base.CreateParameter("@remark2", SqlDbType.NVarChar, remark2), base.CreateParameter("@remark3", SqlDbType.NVarChar, remark3) });
            command.Dispose();
        }

        public void SaveUserLoginDetails(int AutoId, int EmpID, int RoleID, bool IsActive, string Password, bool sysadmin)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_UserLoginDetails", new IDataParameter[] { base.CreateParameter("@AutoId", SqlDbType.Int, AutoId), base.CreateParameter("@EmpID", SqlDbType.Int, EmpID), base.CreateParameter("@RoleID", SqlDbType.Int, RoleID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@Password", SqlDbType.NVarChar, Password), base.CreateParameter("@IsSysadmin", SqlDbType.Bit, sysadmin) });
            command.Dispose();
        }

        public void SaveVirtualMaster(int VMId, int InvoiceNo, string Remark, DateTime InvoiceDate, string CreatedBy, string UpdatedBy, bool IsActive, bool IsDeleted, int FY, out int DocNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_VirualStockMaster", new IDataParameter[] { base.CreateParameter("@AutoID", SqlDbType.Int, VMId), base.CreateParameter("@InvoiceNo", SqlDbType.Int, InvoiceNo), base.CreateParameter("@Remark", SqlDbType.NVarChar, Remark), base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, InvoiceDate), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public void SaveZonemaster(int ZoneID, int Flag, string ZoneCode, string ZoneName, int SuperZoneID, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_ZoneMaster", new IDataParameter[] { base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@Flag", SqlDbType.Int, Flag), base.CreateParameter("@ZoneCode", SqlDbType.NVarChar, ZoneCode), base.CreateParameter("@ZoneName", SqlDbType.NVarChar, ZoneName), base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveZoneMaster(int ZoneID, string ZoneCode, string ZoneName, int SuperZoneID, bool IsActive, bool IsDeleted, string createdBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_save_ZoneMaster", new IDataParameter[] { base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@ZoneCode", SqlDbType.NVarChar, ZoneCode), base.CreateParameter("@ZoneName", SqlDbType.NVarChar, ZoneName), base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, createdBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public DataSet TeamMaster(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_TeamMaster", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet TempData(int SZID, int FY, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Save_SaveTemp", new IDataParameter[] { base.CreateParameter("@SZID", SqlDbType.Int, SZID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public void Update(bool IsConfirm, bool IsApproved, bool IsCanceled, int DocNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Update_SpecimenMaster_IsAcCoCa", new IDataParameter[] { base.CreateParameter("@IsConfirm", SqlDbType.Bit, IsConfirm), base.CreateParameter("@IsApporved", SqlDbType.Bit, IsApproved), base.CreateParameter("@IsCanceled", SqlDbType.Bit, IsCanceled), base.CreateParameter("@DocNo", SqlDbType.Int, DocNo) });
        }

        public void Update_CustomerMaster(int CustID, string CustCode, string ShortForm, string FamilyCode, int AreaId, string Address, string Zip, string Phone1, string Phone2, string EmailID, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy, string CustName, int CustDetailID, string CreditDays, int CreditLimit, bool BlackList, bool IsDeleted1, string PrincipalName, string PrincipalMobile, string PrincipalDOB, string KeyPersonName, string KeyPersonMobile, string KeyPersonDOB, string AdditinalDis, string VIPRemark, int SectionID, string Medium, int City, int DMID, int CustRating, int SuperZoneID, int ZoneID, int AreaZoneID, int BoardID, decimal Business_Potential, decimal CGP, string Association, string Payment_Track, string Remark1, string Remark2, string Remark3, string Remark4, string Remark5, int CMID, int CMIDsub, string SchAdditionalDis, string TODValue1, string TODValue2, string TODValue3, string TODDisc1, string TODDisc2, string TODDisc3, string BlackListDate, string BlackListRemark)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Update_CustomerMaster", new IDataParameter[] { 
                base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@ShortForm", SqlDbType.NVarChar, ShortForm), base.CreateParameter("@FamilyCode", SqlDbType.NVarChar, FamilyCode), base.CreateParameter("@AreaId", SqlDbType.Int, AreaId), base.CreateParameter("@Address", SqlDbType.NVarChar, Address), base.CreateParameter("@City", SqlDbType.Int, City), base.CreateParameter("@DMID", SqlDbType.Int, DMID), base.CreateParameter("@Zip", SqlDbType.NVarChar, Zip), base.CreateParameter("@Phone1", SqlDbType.NVarChar, Phone1), base.CreateParameter("@Phone2", SqlDbType.NVarChar, Phone2), base.CreateParameter("@EmailID", SqlDbType.NVarChar, EmailID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy),
                base.CreateParameter("@CustName", SqlDbType.NVarChar, CustName), base.CreateParameter("@CustDetailID", SqlDbType.Int, CustDetailID), base.CreateParameter("@CreditDays", SqlDbType.NVarChar, CreditDays), base.CreateParameter("@CreditLimit", SqlDbType.Int, CreditLimit), base.CreateParameter("@BlackList", SqlDbType.Bit, BlackList), base.CreateParameter("@IsDeleted1", SqlDbType.Bit, IsDeleted1), base.CreateParameter("@PrincipalName", SqlDbType.NVarChar, PrincipalName), base.CreateParameter("@PrincipalMobile", SqlDbType.NVarChar, PrincipalMobile), base.CreateParameter("@PrincipalDOB", SqlDbType.NVarChar, PrincipalDOB), base.CreateParameter("@KeyPersonName", SqlDbType.NVarChar, KeyPersonName), base.CreateParameter("@KeyPersonMobile", SqlDbType.NVarChar, KeyPersonMobile), base.CreateParameter("@KeyPersonDOB", SqlDbType.NVarChar, KeyPersonDOB), base.CreateParameter("@AdditinalDis", SqlDbType.NVarChar, AdditinalDis), base.CreateParameter("@VIPRemark", SqlDbType.NVarChar, VIPRemark), base.CreateParameter("@SectionID", SqlDbType.Int, SectionID), base.CreateParameter("@Medium", SqlDbType.NVarChar, Medium),
                base.CreateParameter("@CustRating", SqlDbType.Int, CustRating), base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@AreaZoneID", SqlDbType.Int, AreaZoneID), base.CreateParameter("@BoardID", SqlDbType.Int, BoardID), base.CreateParameter("@Business_Potential", SqlDbType.Money, Business_Potential), base.CreateParameter("@CGP", SqlDbType.Money, CGP), base.CreateParameter("@Association", SqlDbType.NVarChar, Association), base.CreateParameter("@Payment_Track", SqlDbType.NVarChar, Payment_Track), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3), base.CreateParameter("@Remark4", SqlDbType.NVarChar, Remark4), base.CreateParameter("@Remark5", SqlDbType.NVarChar, Remark5), base.CreateParameter("@CMID", SqlDbType.Int, CMID), base.CreateParameter("@CMIDsub", SqlDbType.Int, CMIDsub),
                base.CreateParameter("@SchAdditionalDis", SqlDbType.NVarChar, SchAdditionalDis), base.CreateParameter("@TODValue1", SqlDbType.NVarChar, TODValue1), base.CreateParameter("@TODValue2", SqlDbType.NVarChar, TODValue2), base.CreateParameter("@TODValue3", SqlDbType.NVarChar, TODValue3), base.CreateParameter("@TODDisc1", SqlDbType.NVarChar, TODDisc1), base.CreateParameter("@TODDisc2", SqlDbType.NVarChar, TODDisc2), base.CreateParameter("@TODDisc3", SqlDbType.NVarChar, TODDisc3), base.CreateParameter("@BlacklistDate", SqlDbType.NVarChar, BlackListDate), base.CreateParameter("@Blacklistremark", SqlDbType.NVarChar, BlackListRemark)
            });
            command.Dispose();
        }

        public void Update_New_Dc_Rate(int FY, string Confirm, out int DocNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "idv_chetana_Update_New_Dc_Rate", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Confirm", SqlDbType.NVarChar, Confirm), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public void update_SpecimenInvoice(int DetailID, decimal SubdocID, int DocumentNo, int Qty, decimal Rate, decimal Price)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "idv_chetana_UpdateSpecimenInv", new IDataParameter[] { base.CreateParameter("@DetailID", SqlDbType.Int, DetailID), base.CreateParameter("@SubdocID", SqlDbType.Money, SubdocID), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@Qty", SqlDbType.Int, Qty), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Price", SqlDbType.Money, Price) });
            command.Dispose();
        }

        public void UpdateEmployee(int EmpID, string EmpCode, string FirstName, string MiddleName, string LastName, string Address, string City, string Zip, string Phone1, string Phone2, string Gender, string DOB, string Qualification, string Designation, string EmailID, string DepartmentID, int ZoneID, int SuperZoneID, int AreaZoneID, int AreaID, string State, string Photo, DateTime JoinDate, DateTime ResignationDate, bool IsActive, bool IsDeleted, string UpdatedBy, int SDZoneID)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Update_EmployeeMaster", new IDataParameter[] { 
                base.CreateParameter("@EmpID", SqlDbType.Int, EmpID), base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@FirstName", SqlDbType.NVarChar, FirstName), base.CreateParameter("@MiddleName", SqlDbType.NVarChar, MiddleName), base.CreateParameter("@LastName", SqlDbType.NVarChar, LastName), base.CreateParameter("@Address", SqlDbType.NVarChar, Address), base.CreateParameter("@City", SqlDbType.NVarChar, City), base.CreateParameter("@Zip", SqlDbType.NVarChar, Zip), base.CreateParameter("@Phone1", SqlDbType.NVarChar, Phone1), base.CreateParameter("@Phone2", SqlDbType.NVarChar, Phone2), base.CreateParameter("@Gender", SqlDbType.NVarChar, Gender), base.CreateParameter("@DOB", SqlDbType.NVarChar, DOB), base.CreateParameter("@Qualification", SqlDbType.NVarChar, Qualification), base.CreateParameter("@Designation", SqlDbType.NVarChar, Designation), base.CreateParameter("@EmailID", SqlDbType.NVarChar, EmailID), base.CreateParameter("@DepartmentID", SqlDbType.NVarChar, DepartmentID),
                base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@AreaZoneID", SqlDbType.Int, AreaZoneID), base.CreateParameter("@AreaID", SqlDbType.Int, AreaID), base.CreateParameter("@State", SqlDbType.NVarChar, State), base.CreateParameter("@Photo", SqlDbType.NVarChar, Photo), base.CreateParameter("@JoinDate", SqlDbType.DateTime, JoinDate), base.CreateParameter("@ResignationDate", SqlDbType.DateTime, ResignationDate), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@SDZoneID", SqlDbType.Int, SDZoneID)
            });
            command.Dispose();
        }

        public DataSet UpdateIsSms(string BankCode, int DocumentNo, string strFY)
        {
            return base.ExecuteDataSet("Idev_Chetana_BankReceipt_SMS", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@FY", SqlDbType.NVarChar, strFY) });
        }

        public void UpdatePurchaseDetails(int purchaseDetailID, int PurchaseMasterID, string Code, string Description, int Quantity, decimal Rate, decimal Amount, decimal Discount, string Per, bool IsActive, bool Isdeleted, string CreatedBy, string UpdatedBy, string Standard, int OriginalQty)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_update_PurchaseDetails", new IDataParameter[] { base.CreateParameter("@purchaseDetailID", SqlDbType.Int, purchaseDetailID), base.CreateParameter("@PurchaseMasterID", SqlDbType.Int, PurchaseMasterID), base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@Per", SqlDbType.NVarChar, Per), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@originalQuantity", SqlDbType.Int, OriginalQty) });
            command.Dispose();
        }

        public void UpdateUserlog(int EmpID, bool IsBlocked)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Update_Userlog", new IDataParameter[] { base.CreateParameter("@EmpID", SqlDbType.Int, EmpID), base.CreateParameter("@IsBlocked", SqlDbType.Bit, IsBlocked) });
            command.Dispose();
        }
    }
}

