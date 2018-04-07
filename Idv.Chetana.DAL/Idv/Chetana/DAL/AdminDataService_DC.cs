namespace Idv.Chetana.DAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class AdminDataService_DC : DataServiceBase
    {
        public AdminDataService_DC()
        {
        }

        public AdminDataService_DC(IDbTransaction txn)
            : base(txn)
        {
        }

        public DataSet BindInqtypeIsDefault()
        {
            string paramValue = "IsDefaultInqType";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] { base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet BindInquiery()
        {
            string paramValue = "InquieryType";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] { base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet BindSeverity()
        {
            string paramValue = "Severity";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] { base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet BindSeverityIsDefault()
        {
            string paramValue = "IsDefaultSeverity";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] { base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet BindStatus()
        {
            string paramValue = "Status";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] { base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet BindStatusIsDefault()
        {
            string paramValue = "IsDefaultStus";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] { base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet DC_Get_DCDetails_for_MultiPrint(int SubDocId, string DocNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Details_MultiPrint", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, SubDocId), base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo) });
        }

        public DataSet DC_Get_InvoiceDetails_On_subdocID(decimal subDocNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_InvoiceDetails_On_subdocID", new IDataParameter[] { base.CreateParameter("@subDocNo", SqlDbType.Decimal, subDocNo) });
        }

        public DataSet DC_Get_InvoiceDetails_On_subdocID(string DocNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Multi_Invoiceprint", new IDataParameter[] { base.CreateParameter("@subDocNo", SqlDbType.Decimal, (ParameterDirection)0), base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo) });
        }

        public DataSet DC_Get_InvoiceDetails_On_subdocID(decimal subDocNo, int DocNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_InvoiceDetails_On_subdocID", new IDataParameter[] { base.CreateParameter("@subDocNo", SqlDbType.Decimal, subDocNo), base.CreateParameter("@DocNo", SqlDbType.Int, DocNo) });
        }

        public DataSet DC_Get_InvoiceDetails_On_subdocID(decimal SubDocId, string DocNo, string CreatedBy)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Multi_Invoiceprint", new IDataParameter[] { base.CreateParameter("@subDocNo", SqlDbType.Decimal, SubDocId), base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public void DELETE_DATA_FROM_MODULE(string ID, string Module, bool Is_Restore, string CreatedBy, int FY)
        {
            base.ExecuteNonQuery("SP_DELETE_DATA_FROM_MODULE", new IDataParameter[] { base.CreateParameter("@ID", SqlDbType.NVarChar, ID), base.CreateParameter("@Created_BY", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Module", SqlDbType.NVarChar, Module), base.CreateParameter("@Is_Restore", SqlDbType.Bit, Is_Restore), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public void DeleteActual_InvoiceDetails(int GanerateinvoiceId, bool IsActive, bool Isdeleted, int Documentno, decimal amount, decimal subocid, string flag)
        {
            base.ExecuteNonQuery("Idv_Chetana_DC_Update_ActualInvoiceDetails", new IDataParameter[] { base.CreateParameter("@GanerateinvoiceId", SqlDbType.Int, GanerateinvoiceId), base.CreateParameter("@Isactive", SqlDbType.Bit, IsActive), base.CreateParameter("@Isdelete", SqlDbType.Bit, Isdeleted), base.CreateParameter("@Documentno", SqlDbType.Int, Documentno), base.CreateParameter("@Amount", SqlDbType.Money, amount), base.CreateParameter("@subdocid", SqlDbType.Decimal, subocid), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public void DeleteActual_InvoiceDetails(int GanerateinvoiceId, bool IsActive, bool Isdeleted, int Documentno, decimal amount, decimal subocid, string flag, string strFy)
        {
            base.ExecuteNonQuery("Idv_Chetana_DC_Update_ActualInvoiceDetails", new IDataParameter[] { base.CreateParameter("@GanerateinvoiceId", SqlDbType.Int, GanerateinvoiceId), base.CreateParameter("@Isactive", SqlDbType.Bit, IsActive), base.CreateParameter("@Isdelete", SqlDbType.Bit, Isdeleted), base.CreateParameter("@Documentno", SqlDbType.Int, Documentno), base.CreateParameter("@Amount", SqlDbType.Money, amount), base.CreateParameter("@subdocid", SqlDbType.Decimal, subocid), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@fy", SqlDbType.NVarChar, strFy) });
        }

        public void DeleteCN(int CNNo, int strFY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Delete_CN", new IDataParameter[] { base.CreateParameter("@CNNo", SqlDbType.Int, CNNo), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
            command.Dispose();
        }

        public void DeleteDNRecord(string Flag, int ID, bool IsActive, bool IsDeleted)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Delete_ByID", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@ID", SqlDbType.Int, ID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted) });
            command.Dispose();
        }

        public void DeleteJV(int JVMasterID, int JVDocNo, string UpdatedBy, int strFY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Delete_JV", new IDataParameter[] { base.CreateParameter("@JVMasterID", SqlDbType.Int, JVMasterID), base.CreateParameter("@JVDocNo", SqlDbType.Int, JVDocNo), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
            command.Dispose();
        }

        public void DeleteJVRecord(string Flag, int ID, bool Isactive, bool IsDeleted)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Delete_ByID", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@ID", SqlDbType.Int, ID), base.CreateParameter("@IsActive", SqlDbType.Bit, Isactive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted) });
            command.Dispose();
        }

        public DataSet DeletePOD(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_deltePOD", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy), base.CreateParameter("@GeneralCourierID", SqlDbType.Int, GeneralCourierID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet DeleteSendcourier(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DeleteSendCourier", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet EditCN(int CNNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Edit_CN", new IDataParameter[] { base.CreateParameter("@CNNo", SqlDbType.Int, CNNo) });
        }

        public DataSet EditCN(int strFY, int CNNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Edit_CN", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CNNo", SqlDbType.Int, CNNo) });
        }

        public DataSet Faculty_DetailsBySuperZoneID(string flag, string show, string sdz, string sz, string z, int fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Faculty_DetailsBySuperZoneID", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@show", SqlDbType.NVarChar, show), base.CreateParameter("@sdz", SqlDbType.NVarChar, sdz), base.CreateParameter("@sz", SqlDbType.NVarChar, sz), base.CreateParameter("@z", SqlDbType.NVarChar, z), base.CreateParameter("@Fy", SqlDbType.Int, fy) });
        }

        public DataSet Get_All_PettyCashDetals(string FromDate, string Todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PettyCashEntery", new IDataParameter[] { base.CreateParameter("FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("Todate", SqlDbType.NVarChar, Todate) });
        }

        public DataSet Get_AppraisalForm(int SuperZone, int FY, DateTime FromDt, DateTime ToDt, string Flag, int SuperDuperZone)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_AppraisalForm", new IDataParameter[] { base.CreateParameter("@SuperzoneID", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDt), base.CreateParameter("@toDate", SqlDbType.DateTime, ToDt), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@SDzoneID", SqlDbType.Int, SuperDuperZone) });
        }

        public DataSet Get_BalanceSheet(DateTime fromDate, DateTime todate, string flag, int FY, string AorL)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BalanceSheet", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, todate), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@AorL", SqlDbType.VarChar, AorL) });
        }

        public DataSet Get_Bank_Ledger(string Bankcode, string FromDate, string TOdate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Bank_Ledger", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Bankcode), base.CreateParameter("@fromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@toDate", SqlDbType.NVarChar, TOdate) });
        }

        public DataSet Get_Bank_Ledger(string Bankcode, string FromDate, string TOdate, decimal OpenBal, decimal CloseBal, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Bank_Ledger", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Bankcode), base.CreateParameter("@fromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@toDate", SqlDbType.NVarChar, TOdate), base.CreateParameter("@openingBalance", SqlDbType.Decimal, OpenBal), base.CreateParameter("@closingBalance", SqlDbType.Decimal, CloseBal), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_BankPaymentDocNo(string Code)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_BankPaymentDocNo", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code) });
        }

        public DataSet Get_BankReceiptDocNo(string Code)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_BankReceiptDocNo", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code) });
        }

        public DataSet Get_BookSetDetailsOn_SetID_ForDC(int BookSetID, string srate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BookSetDetails-On-SetID1", new IDataParameter[] { base.CreateParameter("@BookSetID", SqlDbType.Int, BookSetID), base.CreateParameter("@price", SqlDbType.NVarChar, srate) });
        }

        public DataSet Get_Booktypewise_summary(string BkTypeCode, DateTime FromDt, DateTime ToDt, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Booktypewise_summary", new IDataParameter[] { base.CreateParameter("@BkTypeCode", SqlDbType.NVarChar, BkTypeCode), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_Booktypewise_Zonal(int SuperZoneID, DateTime FromDt, DateTime ToDt, string BkTypeCode, int ZoneID, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Booktypewise_Zonal", new IDataParameter[] { base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, BkTypeCode), base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_Booktypewise_ZonalDetail(int SuperZoneID, DateTime FromDt, DateTime ToDt, string BkTypeCode, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Booktypewise_ZonalDetail", new IDataParameter[] { base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, BkTypeCode), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_BooktypewiseCust_Sold(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_BooktypewiseCust_SoldQty", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_BooktypewiseCust_Sold(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY, int SuperZone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_BooktypewiseCust_SoldQty", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Get_BooktypewiseCust_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_BooktypewiseCust_summary", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_BooktypewiseCust_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY, int SuperZone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_BooktypewiseCust_summary", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Get_Bookwise_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Bookwise_summary", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_Bookwise_Zonal(int SuperZoneID, DateTime FromDt, DateTime ToDt, string Bkcode, int ZoneID, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Bookwise_Zonal", new IDataParameter[] { base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@ZoneID", SqlDbType.Int, ZoneID), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_Bookwise_ZonalDetail(int SuperZoneID, DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Bookwise_ZonalDetail", new IDataParameter[] { base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZoneID), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_BookwiseCust_SoldQty(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_BookwiseCust_SoldQty", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_BookwiseCust_SoldQty(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY, int SuperZone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_BookwiseCust_SoldQty", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet Get_BookwiseCust_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_BookwiseCust_summary", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_BookwiseCust_summary(DateTime FromDt, DateTime ToDt, string Bkcode, int strFY, int SuperZone, int Zone)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_BookwiseCust_summary", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt), base.CreateParameter("@code", SqlDbType.NVarChar, Bkcode), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@Zone", SqlDbType.Int, Zone) });
        }

        public DataSet get_CancelRecipt(string EmpCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ReciptCancelBook", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode) });
        }

        public DataSet Get_ChequeCashBounceDetails(int ReciptNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ChequeCashBounceDetails", new IDataParameter[] { base.CreateParameter("@ReciptNo", SqlDbType.Int, ReciptNo) });
        }

        public DataSet Get_ChequeChashDoCancel(DateTime Fromdate, DateTime Todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_FilterByDate_Cheque_Cash_Do_Cancel", new IDataParameter[] { base.CreateParameter("@Fromdate", SqlDbType.DateTime, Fromdate), base.CreateParameter("@Todate", SqlDbType.DateTime, Todate) });
        }

        public DataSet get_Count_Calender()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Receipt_Calender_Bind", null);
        }

        public DataSet Get_CourierDetails(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_CourierDetails", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_CourierDetailsCheck(string DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_CourierDetails", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_CourierDetailsCheckSave(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_CourierDetailsSave", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@CourierID", SqlDbType.Int, CourierID), base.CreateParameter("@BranchID", SqlDbType.Int, BranchID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_CourierDetailsGeneral(string DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierGeneral", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Customer_PendingDocNo(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Customer_PedingDocNo", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_Customer_PendingDocNo(string Flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Customer_PedingDocNo", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_DC_CNBkview(int strFY, string CustCode, string BookCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_DCCNBookView", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode) });
        }

        public DataSet Get_DC_CNBook(int strFY, string CustCode, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_DCCNBook", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_DC_Completed_IsApproved()
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_DC_Completed_IsApproved", null);
        }

        public DataSet Get_DC_Completed_IsApproved(int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_DC_Completed_IsApproved", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_DC_Completed_IsApproved_ONOption(int ID, string Flag, int FY, DateTime fromdate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_DC_Completed_IsApproved_ONOption", new IDataParameter[] { base.CreateParameter("@id", SqlDbType.Int, ID), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet Get_DC_CustAd(string CustCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_GetCustAd", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode) });
        }

        public DataSet Get_DC_RateByBook(string CustCode, string BookCode1)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_RateByBook_DCReturnBook", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode1", SqlDbType.NVarChar, BookCode1) });
        }

        public DataSet Get_DC_ReturnBkview(string CustCode, string BookCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_DCReturnBookView", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode) });
        }

        public DataSet Get_DC_ReturnBkview(int strFY, string CustCode, string BookCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_DCReturnBookView", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_DC_ReturnBook(string CustCode, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_DCReturnBook", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_DC_ReturnBook(int strFY, string CustCode, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_DCCNBook", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataTable Get_DCDetails_SubDocNo_ByDocID(int DocNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Details_SubDocNo_ByDocID", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo) }).Tables[0];
        }

        public DataTable Get_DCDetails_SubDocNo_ByDocID(int DocNo, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Details_SubDocNo_ByDocID", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@FY", SqlDbType.Int, FY) }).Tables[0];
        }

        public DataSet Get_DCMaster(int DocumentNo, string SalesmanCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DCMaster", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SalesmanCode", SqlDbType.NVarChar, SalesmanCode) });
        }

        public DataSet Get_DCMaster(int DocumentNo, string SalesmanCode, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DCMaster", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SalesmanCode", SqlDbType.NVarChar, SalesmanCode), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_Discount_On_CusomerAND_Booktype(string CustCode, string Bookcode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Discount_On_CusomerAND_Booktype", new IDataParameter[] { base.CreateParameter("@Custcode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@Bookcode", SqlDbType.NVarChar, Bookcode) });
        }

        public DataSet Get_DocumentNum_Authentication(int DocumentNo)
        {
            return base.ExecuteDataSet("[Idv_Chetana_DC_Get_DocumentNum_Authentication]", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo) });
        }

        public DataSet Get_DocumentNum_Authentication(int DocumentNo, int strFY)
        {
            return base.ExecuteDataSet("[Idv_Chetana_DC_Get_DocumentNum_Authentication]", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_Employee_By_Customer_Code(string CustCode, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Codes_Employee_By_Customer_Code", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, CustCode), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public int Get_EmployeeMaster_MaxId(out int MaxEmployeeId)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Get_EmployeeMaster_MaxId", new IDataParameter[] { base.CreateParameter("@MaxEmployeeId", SqlDbType.Int, ParameterDirection.Output) });
            MaxEmployeeId = Convert.ToInt32(command.Parameters["@MaxEmployeeId"].Value);
            int num = MaxEmployeeId;
            return num;
        }

        public DataSet Get_FacultyApproval(string flag, string show, string sdz, string sz, string z, int fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_FacultyApproval", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@show", SqlDbType.NVarChar, show), base.CreateParameter("@sdz", SqlDbType.NVarChar, sdz), base.CreateParameter("@sz", SqlDbType.NVarChar, sz), base.CreateParameter("@z", SqlDbType.NVarChar, z), base.CreateParameter("@Fy", SqlDbType.Int, fy) });
        }

        public DataSet Get_Invoice_OnDate(DateTime fromDate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_Invoice_OnDate", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet Get_Invoice_OnDateChecklist(DateTime fromDate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_Invoice_OnDateChecklist", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet get_LedgerDetails(string CustCode, string flag, string fromno, string tono)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_LedgerDetails", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FromNo", SqlDbType.NVarChar, fromno), base.CreateParameter("@ToNo", SqlDbType.NVarChar, tono) });
        }

        public DataSet get_LedgerDetails(string CustCode, string flag, string fromno, string tono, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_LedgerDetails", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FromNo", SqlDbType.NVarChar, fromno), base.CreateParameter("@ToNo", SqlDbType.NVarChar, tono), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet get_LedgerDetails(string CustCode, string flag, string fromno, string tono, int FY, DateTime fromDate, DateTime toDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_LedgerDetails_FrTo", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FromNo", SqlDbType.NVarChar, fromno), base.CreateParameter("@ToNo", SqlDbType.NVarChar, tono), base.CreateParameter("@FromDate", SqlDbType.DateTime, fromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, toDate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Name(string Code)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetName_By_Code", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code) });
        }

        public DataSet Get_Name(string Code, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetName_By_Code", new IDataParameter[] {
                base.CreateParameter("@Code", SqlDbType.NVarChar, Code),
                base.CreateParameter("@flag", SqlDbType.NVarChar, Flag)
            });
        }

        public DataSet Get_OutwardDetails(string InvoiceNo, string flag, string status, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_OutwardDetails", new IDataParameter[] { base.CreateParameter("@outwardNo", SqlDbType.NVarChar, InvoiceNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@IORD", SqlDbType.NVarChar, status), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet Get_OutwardDetails(string InvoiceNo, string flag, string status, int strFY, DateTime Fromdate, DateTime Todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_OutwardDetails", new IDataParameter[] { base.CreateParameter("@outwardNo", SqlDbType.NVarChar, InvoiceNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@IORD", SqlDbType.NVarChar, status), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@fromDate", SqlDbType.DateTime, Fromdate), base.CreateParameter("@todate", SqlDbType.DateTime, Todate) });
        }

        public DataSet Get_PDC_Details(DateTime FromDate, DateTime ToDate, string Flag)
        {
            return base.ExecuteDataSet("IDV_Chetana_PDC_Details", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_PettyCashEntry(string FromDate, string ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PettyCashEntery", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate) });
        }

        public DataSet Get_PrintCN_multiple(int strFY, string Selectedcn)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Multi_Print_CN", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CNNo", SqlDbType.NVarChar, Selectedcn) });
        }

        public DataSet Get_Profit_and_Loss(DateTime fromDate, DateTime todate, string flag, int FY, string AorL)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Profit_and_Loss", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, todate), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@AorL", SqlDbType.VarChar, AorL) });
        }

        public DataSet Get_ReceiptViewBookDetails(int ReciptNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ReceiptViewBookDetails", new IDataParameter[] { base.CreateParameter("@ReciptNo", SqlDbType.Int, ReciptNo) });
        }

        public DataSet Get_Report_ABC_Analysis(int Superzone, int Zone, int FY, int SuperDuperzone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_ABC_Analysis", new IDataParameter[] { base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@SuperDuperzone", SqlDbType.Int, SuperDuperzone) });
        }

        public DataSet Get_Report_BoardWise(int Board, int Superzone, int Zone, int SuperDuperzone, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_BoardWise", new IDataParameter[] { base.CreateParameter("@Board", SqlDbType.Int, Board), base.CreateParameter("@SuperZone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@SdZone", SqlDbType.Int, SuperDuperzone), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Report_SchoolWise_Target(int Superzone, int Zone, int FY, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SchoolwiseTarget", new IDataParameter[] { base.CreateParameter("@SuperZoneID", SqlDbType.Int, Superzone), base.CreateParameter("@ZoneID", SqlDbType.Int, Zone), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_SalesRegister(string flag, DateTime fromDate, DateTime toDate, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_SalesRegister", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FromDate", SqlDbType.DateTime, fromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, toDate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_SalesRegister(string flag, DateTime fromDate, DateTime toDate, int FY, string flag1, string Remark1)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_SalesRegister", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FromDate", SqlDbType.DateTime, fromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, toDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1) });
        }

        public DataSet Get_SubDocId_And_ItsRecords_By_DocNo(int DocNo, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_SubDocId_And_ItsRecords_By_DocNo", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Get_SubDocId_And_ItsRecords_By_DocNo(int DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_SubDocId_And_ItsRecords_By_DocNo", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_SuperZoneWise_Weekly_Collection(int SuperZone, DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SuperZoneWise_Weekly_Collection", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDt), base.CreateParameter("@toDate", SqlDbType.DateTime, ToDt) });
        }

        public DataSet Get_SuperZoneWise_Weekly_Collection(int SuperZone, DateTime FromDt, DateTime ToDt, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SuperZoneWise_Weekly_Collection", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDt), base.CreateParameter("@toDate", SqlDbType.DateTime, ToDt), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Get_SuperZoneWise_Weekly_Collection(int SuperZone, DateTime FromDt, DateTime ToDt, string Flag, int SuperDuperZone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_SuperZoneWise_Weekly_Collection", new IDataParameter[] { base.CreateParameter("@SuperZone", SqlDbType.Int, SuperZone), base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDt), base.CreateParameter("@toDate", SqlDbType.DateTime, ToDt), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@SuperDuperZone", SqlDbType.Int, SuperDuperZone) });
        }

        public DataSet Get_Trading_Profit_and_Loss(DateTime fromDate, DateTime todate, string flag, int FY, string AorL)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Trading_Profit_and_Loss", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, todate), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@AorL", SqlDbType.VarChar, AorL) });
        }

        public DataSet Get_Transporter(string CustCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Transport", new IDataParameter[] { base.CreateParameter("@Custcode", SqlDbType.NVarChar, CustCode) });
        }

        public DataSet Get_Trial_Balance_Individual(string AccountCode, bool isCustmer, DateTime FromDate, DateTime Todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Trial_Balance_Individual", new IDataParameter[] { base.CreateParameter("@Ac_Code", SqlDbType.NVarChar, AccountCode), base.CreateParameter("@isCustomer", SqlDbType.Bit, isCustmer), base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@toDate", SqlDbType.DateTime, Todate) });
        }

        public DataSet Get_Validate_PettyCash_Details(string VoucherNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_PettyCash", new IDataParameter[] { base.CreateParameter("@VoucherNo", SqlDbType.NVarChar, VoucherNo) });
        }

        public DataSet Get_Validate_ReceiptCancelBook(string EmpCode, int fromno)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_ReceiptCancelBook", new IDataParameter[] { base.CreateParameter("@Empcode", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@tmp", SqlDbType.Int, fromno) });
        }

        public DataSet Get_VoucherPayment(string FromVoc, string ToVoc)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PettyCashPayment", new IDataParameter[] { base.CreateParameter("@FromVoc", SqlDbType.NVarChar, FromVoc), base.CreateParameter("@ToVoc", SqlDbType.NVarChar, ToVoc) });
        }

        public DataSet Get_YearOnYeaGrowth(int SuperZone, int FY, DateTime FromDt, DateTime ToDt, string Flag, int SuperDuperZone)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_YearOnYeaGrowth", new IDataParameter[] { base.CreateParameter("@SuperzoneID", SqlDbType.Int, SuperZone), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDt), base.CreateParameter("@toDate", SqlDbType.DateTime, ToDt), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@SDzoneID", SqlDbType.Int, SuperDuperZone) });
        }

        public DataSet GetBankPayment(string BankCode, DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BankPayment", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public DataSet GetBankPayment(string BankCode, int DocNo, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BankPayment_DocumentWise", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@FromDt", SqlDbType.Int, DocNo), base.CreateParameter("@ToDt", SqlDbType.Int, FY) });
        }

        public DataSet GetBankReceipt(string BankCode, DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BankReceipt", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public DataSet GetBankReceiptPayment()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BankReceiptPaymentDetails", null);
        }

        public DataSet GetBooksMasterForDC(string BookCode, string srate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BookMaster1", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@price", SqlDbType.NVarChar, srate) });
        }

        public DataSet GetBrokerMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_BrokerMaster", null);
        }

        public DataSet getChequeCashDeposit(string ECode, string FromDate, string ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ChequeCashDeposit", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, ECode), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate) });
        }

        public DataSet GetChequeCashReport(string Fromdate, string Todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_FilterByDate_Cheque_Cash_Deposite_Details", new IDataParameter[] { base.CreateParameter("@Fromdate", SqlDbType.NVarChar, Fromdate), base.CreateParameter("@Todate", SqlDbType.NVarChar, Todate) });
        }

        public DataSet GetCNNo()
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_CNNo", null);
        }

        public DataSet GetCNNo(int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_CNNo", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet GetCNNo_byCust(string CustCode, string Flags, DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_GetCNNo_Bycust", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@Flags", SqlDbType.NVarChar, Flags), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public DataSet GetCNNo_byCust(int strFY, string CustCode, string Flags, DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_GetCNNo_Bycust", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@Flags", SqlDbType.NVarChar, Flags), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public DataSet GetCNNo_byCusts(int strFY, string CustCode, string Flags)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_GetCNNo_Bycusts", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@Flags", SqlDbType.NVarChar, Flags) });
        }

        public DataSet GetCNNo_Bydt(int strFY, DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_GetCNNo_Bydt", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public DataSet GetConvertion_fromnumber(decimal Number)
        {
            return base.ExecuteDataSet("GetString_FromNumber", new IDataParameter[] { base.CreateParameter("@Input", SqlDbType.Decimal, Number) });
        }

        public DataSet GetCourier(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CourierData", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetCourierBranch(int DocID, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CourierData", new IDataParameter[] { base.CreateParameter("@DocID", SqlDbType.Float, DocID), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetCourierValidation(string Group, string code)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_If_Exists", new IDataParameter[] { base.CreateParameter("@Group", SqlDbType.NVarChar, Group), base.CreateParameter("@code", SqlDbType.NVarChar, code) });
        }

        public DataSet GetCustAddress(string CustCode, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_GetCustAddress", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetCustEmail(string Code, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetName_By_Code", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetCustlist(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_GetCustlist", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetCustlist(int strFY, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DCCN_GetCustlist", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetCustlist_Bydt(DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_GetCustlist_Bydt", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public DataSet GetCustlist_Bydt(int strFY, DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_GetCustlist_Bydt", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public DataSet GetCustN_Doc(int DocNo, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetName_By_Docnew", new IDataParameter[] { base.CreateParameter("@Docnew", SqlDbType.Int, DocNo), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet GetCustN_Invoice(decimal InvoiceNo, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetName_By_Invoice", new IDataParameter[] { base.CreateParameter("@SubDocId", SqlDbType.Decimal, InvoiceNo), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet GetCustomer_OnView(int custid, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Customer_OnFlag", new IDataParameter[] { base.CreateParameter("@id", SqlDbType.Int, custid), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet GetCustomer_OnView(int custid, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Customer_OnFlag", new IDataParameter[] { base.CreateParameter("@id", SqlDbType.Int, custid), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet GetDCDatilsByCode(string EmpCode, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DCDetails", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetDCOrderNoAuthentication(string OrderNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DCOrderNo_Authentication", new IDataParameter[] { base.CreateParameter("@OrderNo", SqlDbType.NVarChar, OrderNo) });
        }

        public DataSet GetDCOrderNoAuthentication(string OrderNo, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DCOrderNo_Authentication", new IDataParameter[] { base.CreateParameter("@OrderNo", SqlDbType.NVarChar, OrderNo), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet getDepositDetails(string CustCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ChequeCashDEpositedDetails", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode) });
        }

        public DataSet getDepositDetails(string CustCode, string FromDate, string ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ChequeCashDEpositedDetails", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate) });
        }

        public DataSet GetDN(int DocNo, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_DN", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@strFY", SqlDbType.Int, strFY) });
        }

        public DataSet GetEmail(string Code, string Flag, int InqType)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetName_InqType", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@InqType", SqlDbType.Int, InqType), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet GetJV(int DocNo, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_JV", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@strFY", SqlDbType.Int, strFY) });
        }

        public DataSet GetLoanPartyMaster()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_LoanPartyMaster", null);
        }

        public DataSet getMiscellaneous(string Flag, int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Miscellaneous_CWE", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCateID", SqlDbType.Int, CustCateID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet GetMiscellaneousDAC(string Flag, int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Miscellaneous_DAC", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@CustCateID", SqlDbType.Int, CustCateID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet getMultipleCancel_details(string EmpCode, int FromNo, int ToNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_MultipalCancelDetails", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@fromNo", SqlDbType.Int, FromNo), base.CreateParameter("@toNo", SqlDbType.Int, ToNo) });
        }

        public DataSet GetOutward(int OdDocNo, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Outward", new IDataParameter[] { base.CreateParameter("@OdDoc", SqlDbType.Int, OdDocNo), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public DataSet GetPendingApprovedDocNo()
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_PedingDocNo_IsApproved", null);
        }

        public DataSet GetPendingApprovedDocNo(int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_PedingDocNo_IsApproved", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet GetPendingDocNo()
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_PedingDocNo", null);
        }

        public DataSet GetPendingDocNo(int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_PedingDocNo", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet GetPendingDocNo_ForView(int ID, string Flag, DateTime fromdate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_PedingDocNo_OnView", new IDataParameter[] { base.CreateParameter("@id", SqlDbType.Int, ID), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet GetPendingDocNo_ForView(int ID, string Flag, DateTime fromdate, DateTime todate, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_PedingDocNo_OnView", new IDataParameter[] { base.CreateParameter("@id", SqlDbType.Int, ID), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@todate", SqlDbType.DateTime, todate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet GetPendingDocNo_ForViewEmail(int ID, string Flag, DateTime fromdate, DateTime todate, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_PedingDocNo_OnViewEmail", new IDataParameter[] { base.CreateParameter("@id", SqlDbType.Int, ID), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@todate", SqlDbType.DateTime, todate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet GetPendingDocNoEmail(int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_PedingDocNoEmail", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet getPurchseRegister(DateTime FromDate, DateTime ToDate, int FY, string ID, string Flag)
        {
            return base.ExecuteDataSet("idv_chetana_report_purchase_register_new", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@ID", SqlDbType.NVarChar, ID), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet getReceiptBookDetails(string EmpCode, string fromno, string Tono, int ActualReceiptNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Receipt_Book_All_Details", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@fromno1", SqlDbType.NVarChar, fromno), base.CreateParameter("@Tono1", SqlDbType.NVarChar, Tono), base.CreateParameter("@ActualReceiptNo", SqlDbType.Int, ActualReceiptNo) });
        }

        public DataTable GetRecipt_Cancel_Used_Details(string EmpCode, int FromNo, int ToNo, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetRecipt_Cancel_Used_Details", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@FromNo", SqlDbType.Int, FromNo), base.CreateParameter("@ToNo", SqlDbType.Int, ToNo), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) }).Tables[0];
        }

        public DataSet GetRemarksAll(string TKTID)
        {
            string paramValue = "RemarkAllGrid";
            return base.ExecuteDataSet("Sp_TktHistory", new IDataParameter[] { base.CreateParameter("@TKTID", SqlDbType.NVarChar, TKTID), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet GetRemarksSelect(string TKTID)
        {
            string paramValue = "RemarksGrid";
            return base.ExecuteDataSet("Sp_TktHistory", new IDataParameter[] { base.CreateParameter("@TKTID", SqlDbType.NVarChar, TKTID), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet GetStockUpdate()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_StockUpdate", null);
        }

        public DataSet GetStockUpdateRep(string BookCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_Get_StockUpdate", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode) });
        }

        public DataSet GetTktSelect(string TKTID)
        {
            string paramValue = "SelecteGrid";
            return base.ExecuteDataSet("Sp_TktHistory", new IDataParameter[] { base.CreateParameter("@TKTID", SqlDbType.NVarChar, TKTID), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet GetTotalCN_Bydt(DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_TotalCN", new IDataParameter[] { base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public DataSet GetTotalCN_Bydt(int strFY, DateTime FromDt, DateTime ToDt)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_TotalCN", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@FromDt", SqlDbType.DateTime, FromDt), base.CreateParameter("@ToDt", SqlDbType.DateTime, ToDt) });
        }

        public DataSet Idv_Chetana_Broker_Ledger_Report(string BrokerCode, string flag, decimal amount, int FY, DateTime FromDate, DateTime Todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_Ledger_of_Broakerage", new IDataParameter[] { base.CreateParameter("@BrokerCode", SqlDbType.NVarChar, BrokerCode), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@amount", SqlDbType.Money, amount), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@Todate", SqlDbType.DateTime, Todate) });
        }

        public void Idv_Chetana_ChequeCashDeposited_Update_Delete(int CQ_ID, string BankCode, string DepositDate, string Description, string CreatedBy, int strFy, bool IsDelete)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_ChequeCashDeposited_Update_Delete", new IDataParameter[] { base.CreateParameter("@CQ_ID", SqlDbType.Int, CQ_ID), base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@DepositDate", SqlDbType.NVarChar, DepositDate), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@IsDelete", SqlDbType.Bit, IsDelete), base.CreateParameter("@Fy", SqlDbType.Int, strFy) });
            command.Dispose();
        }

        public DataSet Idv_Chetana_Customer_Aging_Report(string FromDate, string ToDate, int FY, int Zone, string CustCode)
        {
            return base.ExecuteDataSet("Idv_chetana_Report_Aging", new IDataParameter[] { base.CreateParameter("@custCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@zoneid", SqlDbType.Int, Zone) });
        }

        public DataSet Idv_Chetana_Customer_Commission_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_Commission", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode) });
        }

        public DataSet Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno1(int DocNo, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno1", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno2(int DocNo, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Details_By_DocNo_Report_allbydocno2", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_Dc_Status(string Flag, string DcNo, string Flag1, string Fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_Dc_Status", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@DcNo", SqlDbType.NVarChar, DcNo), base.CreateParameter("@Flag1", SqlDbType.NVarChar, Flag1), base.CreateParameter("@Fy", SqlDbType.Int, Convert.ToInt32(Fy)) });
        }

        public DataSet Idv_Chetana_Edit_Receipt_Book(string SalesManId_Old, int FromNo_Old, int ToNo_Old, string SalesManCode_New, int FromNo_New, int ToNo_New, int ReceiptBookID, int ActualReceiptNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Edit_Receipt_Book", new IDataParameter[] { base.CreateParameter("@SalesManId_Old", SqlDbType.NVarChar, SalesManId_Old), base.CreateParameter("@FromNo_Old", SqlDbType.Int, FromNo_Old), base.CreateParameter("@ToNo_Old", SqlDbType.Int, ToNo_Old), base.CreateParameter("@SalesManCode_New", SqlDbType.NVarChar, SalesManCode_New), base.CreateParameter("@FromNo_New ", SqlDbType.Int, FromNo_New), base.CreateParameter("@ToNo_New", SqlDbType.Int, ToNo_New), base.CreateParameter("@ReceiptBookID", SqlDbType.Int, ReceiptBookID), base.CreateParameter("@ActualReceiptNo", SqlDbType.Int, ActualReceiptNo) });
        }

        public DataSet Idv_Chetana_Get_ChequeCashDeposited_AfterPayment(string ECode, string FromDate, string ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ChequeCashDeposited_AfterPayment", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, ECode), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate) });
        }

        public DataSet Idv_Chetana_Get_Petty_Expance_CheckList(string FromDate, string ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Petty_Expance_CheckList", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate) });
        }

        public DataSet Idv_Chetana_Get_Petty_Expance_CheckList(string FromDate, string ToDate, int Fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Petty_Expance_CheckList", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, Fy) });
        }

        public DataSet Idv_Chetana_Get_Petty_Expance_View(string FromDate, string ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Petty_Expance_View", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate) });
        }

        public DataSet Idv_Chetana_Get_Petty_Expance_View(string FromDate, string ToDate, int Fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Petty_Expance_View", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, Fy) });
        }

        public DataSet Idv_Chetana_Get_Petty_Expence_View_by_VoucherNo(int VoucherNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Petty_Expence_View_by_VoucherNo", new IDataParameter[] { base.CreateParameter("@VoucherNo", SqlDbType.Int, VoucherNo) });
        }

        public DataSet Idv_Chetana_Get_PettyCashEnter(int Voucher)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_PettyCashEnter", new IDataParameter[] { base.CreateParameter("@Voucher", SqlDbType.Int, Voucher) });
        }

        public int IDV_CHETANA_Get_ReceiptBookDetails_MaxID(out int ActualReceiptNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "IDV_CHETANA_Get_ReceiptBookDetails_MaxID", new IDataParameter[] { base.CreateParameter("@ActualReceiptNo", SqlDbType.Int, ParameterDirection.Output) });
            ActualReceiptNo = Convert.ToInt32(command.Parameters["@ActualReceiptNo"].Value);
            int num = ActualReceiptNo;
            return num;
        }

        public DataSet Idv_Chetana_Get_ReceiptBookDetails_Report(int ActualReceiptNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ReceiptBookDetails_Report", new IDataParameter[] { base.CreateParameter("@ActualReceiptNo", SqlDbType.Int, ActualReceiptNo) });
        }

        public DataSet Idv_Chetana_Get_ReceiptView_AT_EntryTime(int ReciptNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_ReceiptView_AT_EntryTime", new IDataParameter[] { base.CreateParameter("@ReciptNo", SqlDbType.Int, ReciptNo) });
        }

        public DataSet idv_Chetana_Get_Trial_Balance()
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Trial_Balance", null);
        }

        public DataSet idv_Chetana_Get_Trial_Balance(DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Trial_Balance", new IDataParameter[] { base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@toDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet idv_Chetana_Get_Trial_Balance(DateTime FromDate, DateTime ToDate, string Flag, int FY, string Group)
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Trial_Balance", new IDataParameter[] { base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@toDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Group", SqlDbType.NVarChar, Group) });
        }

        public DataSet Idv_Chetana_Get_Trial_Balance_Summary(DateTime FromDate, DateTime ToDate, string Flag, int FY, string Group)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Trial_Balance_Summary", new IDataParameter[] { base.CreateParameter("@fromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@toDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Group", SqlDbType.NVarChar, Group) });
        }

        public DataSet Idv_Chetana_Get_Validate_PurchaseInvoice(int Invoice)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_PurchaseInvoice", new IDataParameter[] { base.CreateParameter("@Invoice", SqlDbType.Int, Invoice) });
        }

        public DataSet Idv_Chetana_GetJV_Report(DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetJV_Report", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public DataSet Idv_Chetana_REP_Collection_Report(int SuperZone, int FY, DateTime FromDate, DateTime Todate, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Collection_Report", new IDataParameter[] { base.CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZone), base.CreateParameter("@Fy", SqlDbType.Int, FY), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@Todate", SqlDbType.DateTime, Todate), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Idv_Chetana_Report_Get_DC_Confiramation(DateTime fromDate, DateTime todate, int Superzone, int Zone, int Fy, string Remark1, string Remark2, string Remark3)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_Get_DC_Confiramation", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, todate), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@Fy", SqlDbType.Int, Fy), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3) });
        }

        public DataSet Idv_Chetana_Report_ReceiptBook(int ReceiptBookId)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_ReceiptBook", new IDataParameter[] { base.CreateParameter("@ReceiptBookID", SqlDbType.Int, ReceiptBookId) });
        }

        public DataSet Idv_Chetana_Report_ReceiptBook(string ReceiptBookId)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_ReceiptBook", new IDataParameter[] { base.CreateParameter("@ReceiptBookID", SqlDbType.NVarChar, ReceiptBookId) });
        }

        public DataSet Idv_Chetana_Stock_Aging_Report(DateTime FromDate, DateTime ToDate, int FY, string Flag)
        {
            return base.ExecuteDataSet("Idv_chetana_Report_Stock_Aging", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public void Idv_Chetana_Update_TargetMaster_nd_Details(int FY, string CreatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Update_TargetMaster_nd_Details", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Createdby", SqlDbType.NVarChar, CreatedBy) });
            command.Dispose();
        }

        public void Idv_Chetana_UpdateChequeCashDetails(int CQ_ID, string EmpID, string CustId, int ReciptNo, string Deposite_Type, string ChequeNo, string ChequeDate, decimal Amount, string CreatedBy, string Description, string Payee_Bank, int strFy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_UpdateChequeCashDetails", new IDataParameter[] { base.CreateParameter("@CQ_ID", SqlDbType.Int, CQ_ID), base.CreateParameter("@EmpID", SqlDbType.NVarChar, EmpID), base.CreateParameter("@CustId", SqlDbType.NVarChar, CustId), base.CreateParameter("@ReciptNo", SqlDbType.Int, ReciptNo), base.CreateParameter("@Deposite_Type", SqlDbType.NVarChar, Deposite_Type), base.CreateParameter("@ChequeNo", SqlDbType.NVarChar, ChequeNo), base.CreateParameter("@ChequeDate", SqlDbType.NVarChar, ChequeDate), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@Payee_Bank", SqlDbType.NVarChar, Payee_Bank), base.CreateParameter("@Fy", SqlDbType.Int, strFy) });
            command.Dispose();
        }

        public void Idv_Chetana_UpdateChequeCashDetails(int CQ_ID, string EmpID, string CustId, int ReciptNo, string Deposite_Type, string ChequeNo, string ChequeDate, decimal Amount, string CreatedBy, string Description, string Payee_Bank, int strFy, bool IsDelete)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_UpdateChequeCashDetails", new IDataParameter[] { base.CreateParameter("@CQ_ID", SqlDbType.Int, CQ_ID), base.CreateParameter("@EmpID", SqlDbType.NVarChar, EmpID), base.CreateParameter("@CustId", SqlDbType.NVarChar, CustId), base.CreateParameter("@ReciptNo", SqlDbType.Int, ReciptNo), base.CreateParameter("@Deposite_Type", SqlDbType.NVarChar, Deposite_Type), base.CreateParameter("@ChequeNo", SqlDbType.NVarChar, ChequeNo), base.CreateParameter("@ChequeDate", SqlDbType.NVarChar, ChequeDate), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@Payee_Bank", SqlDbType.NVarChar, Payee_Bank), base.CreateParameter("@Fy", SqlDbType.Int, strFy), base.CreateParameter("@IsDelete", SqlDbType.Bit, IsDelete) });
            command.Dispose();
        }

        public DataSet Idv_Chetana_Validation_Invoice_Delivery_Status(decimal InvoiceNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Validation_Invoice_Delivery_Status", new IDataParameter[] { base.CreateParameter("@InvoiceNo", SqlDbType.Decimal, InvoiceNo) });
        }

        public DataSet Idv_Get_DCDetails_By_DocNo(int DocNo, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Details_By_DocNo", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public DataSet Idv_Get_DCDetails_By_DocNo(int DocNo, string Flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Details_By_DocNo", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet IdvChetana_EmailSms(int CustId, string flag, string flag1)
        {
            return base.ExecuteDataSet("get_ZonalPerson_ContactNo", new IDataParameter[] { base.CreateParameter("@cut_id", SqlDbType.Int, CustId), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1) });
        }

        public DataSet LastTktNo()
        {
            string paramValue = "LastRecord";
            string str2 = null;
            return base.ExecuteDataSet("Sp_LastTktNo", new IDataParameter[] { base.CreateParameter("@TKTID", SqlDbType.NVarChar, str2), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public void LedgerCN(int CNNo, int strFY, DateTime CNDate)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Ledger_CN", new IDataParameter[] { base.CreateParameter("@CNNo", SqlDbType.Int, CNNo), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Date", SqlDbType.DateTime, CNDate) });
            command.Dispose();
        }

        public void LedgerCN(int CNNo, int strFY, DateTime CNDate, string IsExciseApplicable)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Ledger_CN", new IDataParameter[] { base.CreateParameter("@CNNo", SqlDbType.Int, CNNo), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Date", SqlDbType.DateTime, CNDate), base.CreateParameter("@IsExciseApplicable", SqlDbType.NVarChar, IsExciseApplicable) });
            command.Dispose();
        }

        public DataSet PrintCN(int CNNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Print_CN", new IDataParameter[] { base.CreateParameter("@CNNo", SqlDbType.Int, CNNo) });
        }

        public DataSet PrintCN(int strFY, int CNNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Print_CN", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CNNo", SqlDbType.Int, CNNo) });
        }

        public void RejectFaculty(string factid)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_RejectFaculty", new IDataParameter[] { base.CreateParameter("@factid", SqlDbType.NVarChar, factid) });
        }

        public DataSet Rep_DC_Get_Datails_OnSubdocno(int DocNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_DC_Get_Datails_OnSubdocno", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo) });
        }

        public DataSet RepGetDN(int DocNo, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Get_DN", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@strFY", SqlDbType.Int, strFY) });
        }

        public DataSet RepGetJV(int DocNo, int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Get_JV", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@strFY", SqlDbType.Int, strFY) });
        }

        public DataSet Report_LoanInterest(string AcCode, DateTime FromDate, DateTime ToDate, int FY, string IntRate, string ReptCode)
        {
            return base.ExecuteDataSet("Idv_chetana_LoanInterest", new IDataParameter[] { base.CreateParameter("@AcCode", SqlDbType.NVarChar, AcCode), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@IntRate", SqlDbType.NVarChar, IntRate), base.CreateParameter("@ReptCode", SqlDbType.NVarChar, ReptCode) });
        }

        public void Save_CancelRecipt(int AutoCancelRecNo, int FromNo, int ToNo, string Resion, bool IsDelete, string CreatedBy, string EmpCode)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_ReciptCancelBook", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@AutoCancelRecNo", SqlDbType.Int, AutoCancelRecNo), base.CreateParameter("@FromNo", SqlDbType.Int, FromNo), base.CreateParameter("@ToNo", SqlDbType.Int, ToNo), base.CreateParameter("@Resion", SqlDbType.NVarChar, Resion), base.CreateParameter("@IsDelete", SqlDbType.Bit, IsDelete), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public void save_ChequeCashDetailsBounce(int CQ_ID, bool ISactive)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_ChequeCashDepositeBounceChequeDetails", new IDataParameter[] { base.CreateParameter("@CQ_ID", SqlDbType.Int, CQ_ID), base.CreateParameter("@ISactive", SqlDbType.Bit, ISactive) });
        }

        public void save_ChequeCashDetailsdal(int CQ_ID, string EmpID, string CustId, int ReciptNo, string Deposite_Type, string ChequeNo, string ChequeDate, string Deposited_By, decimal Amount, string CreatedBy, bool IsCancel, string Description, string CancelBy, DateTime CancelDate, string Payee_Bank, string DepositDate, bool ISactive, string BankCode, string OtherId)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_ChequeCashDepositeDetails", new IDataParameter[] { 
                base.CreateParameter("@CQ_ID", SqlDbType.Int, CQ_ID), base.CreateParameter("@EmpID", SqlDbType.NVarChar, EmpID), base.CreateParameter("@CustId", SqlDbType.NVarChar, CustId), base.CreateParameter("@ReciptNo", SqlDbType.Int, ReciptNo), base.CreateParameter("@Deposite_Type", SqlDbType.NVarChar, Deposite_Type), base.CreateParameter("@ChequeNo", SqlDbType.NVarChar, ChequeNo), base.CreateParameter("@ChequeDate", SqlDbType.NVarChar, ChequeDate), base.CreateParameter("@Deposited_By", SqlDbType.NVarChar, Deposited_By), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@IsCancel", SqlDbType.Bit, IsCancel), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@CancelBy", SqlDbType.NVarChar, CancelBy), base.CreateParameter("@CancelDate", SqlDbType.DateTime, CancelDate), base.CreateParameter("@Payee_Bank", SqlDbType.NVarChar, Payee_Bank), base.CreateParameter("@DepositDate", SqlDbType.NVarChar, DepositDate),
                base.CreateParameter("@ISactive", SqlDbType.Bit, ISactive), base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@OtherId", SqlDbType.NVarChar, OtherId)
            });
            command.Dispose();
        }

        public void save_ChequeCashDetailsdal(int CQ_ID, string EmpID, string CustId, int ReciptNo, string Deposite_Type, string ChequeNo, string ChequeDate, string Deposited_By, decimal Amount, string CreatedBy, bool IsCancel, string Description, string CancelBy, DateTime CancelDate, string Payee_Bank, string DepositDate, bool ISactive, string BankCode, string OtherId, int strFy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_ChequeCashDepositeDetails", new IDataParameter[] { 
                base.CreateParameter("@CQ_ID", SqlDbType.Int, CQ_ID), base.CreateParameter("@EmpID", SqlDbType.NVarChar, EmpID), base.CreateParameter("@CustId", SqlDbType.NVarChar, CustId), base.CreateParameter("@ReciptNo", SqlDbType.Int, ReciptNo), base.CreateParameter("@Deposite_Type", SqlDbType.NVarChar, Deposite_Type), base.CreateParameter("@ChequeNo", SqlDbType.NVarChar, ChequeNo), base.CreateParameter("@ChequeDate", SqlDbType.NVarChar, ChequeDate), base.CreateParameter("@Deposited_By", SqlDbType.NVarChar, Deposited_By), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@IsCancel", SqlDbType.Bit, IsCancel), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@CancelBy", SqlDbType.NVarChar, CancelBy), base.CreateParameter("@CancelDate", SqlDbType.DateTime, CancelDate), base.CreateParameter("@Payee_Bank", SqlDbType.NVarChar, Payee_Bank), base.CreateParameter("@DepositDate", SqlDbType.NVarChar, DepositDate),
                base.CreateParameter("@ISactive", SqlDbType.Bit, ISactive), base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@OtherId", SqlDbType.NVarChar, OtherId), base.CreateParameter("@Fy", SqlDbType.Int, strFy)
            });
            command.Dispose();
        }

        public void save_ChequeCashDetailsdal(int CQ_ID, string EmpID, string CustId, int ReciptNo, string Deposite_Type, string ChequeNo, string ChequeDate, string Deposited_By, decimal Amount, string CreatedBy, bool IsCancel, string Description, string CancelBy, DateTime CancelDate, string Payee_Bank, string DepositDate, bool ISactive, string BankCode, string OtherId, int strFy, out int IDNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_ChequeCashDepositeDetails", new IDataParameter[] { 
                base.CreateParameter("@CQ_ID", SqlDbType.Int, CQ_ID), base.CreateParameter("@EmpID", SqlDbType.NVarChar, EmpID), base.CreateParameter("@CustId", SqlDbType.NVarChar, CustId), base.CreateParameter("@ReciptNo", SqlDbType.Int, ReciptNo), base.CreateParameter("@Deposite_Type", SqlDbType.NVarChar, Deposite_Type), base.CreateParameter("@ChequeNo", SqlDbType.NVarChar, ChequeNo), base.CreateParameter("@ChequeDate", SqlDbType.NVarChar, ChequeDate), base.CreateParameter("@Deposited_By", SqlDbType.NVarChar, Deposited_By), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@IsCancel", SqlDbType.Bit, IsCancel), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@CancelBy", SqlDbType.NVarChar, CancelBy), base.CreateParameter("@CancelDate", SqlDbType.DateTime, CancelDate), base.CreateParameter("@Payee_Bank", SqlDbType.NVarChar, Payee_Bank), base.CreateParameter("@DepositDate", SqlDbType.NVarChar, DepositDate),
                base.CreateParameter("@ISactive", SqlDbType.Bit, ISactive), base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@OtherId", SqlDbType.NVarChar, OtherId), base.CreateParameter("@Fy", SqlDbType.Int, strFy), base.CreateParameter("@IDNo", SqlDbType.Int, ParameterDirection.Output)
            });
            IDNo = Convert.ToInt32(command.Parameters["@IDNo"].Value);
            command.Dispose();
        }

        public void Save_CN(int AutoID, int CNNo, string CustCode, string BookCode, decimal Rate, decimal Discount, int ReturnQty, string Comment, bool IsActive, string CreatedBy, string UpdatedBy, string Flag, int TotReturnQty, int GCN, int SCN, int DefectQty, DateTime CNDate)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_CN", new IDataParameter[] { 
                base.CreateParameter("@AutoID", SqlDbType.Int, AutoID), base.CreateParameter("@CNNo", SqlDbType.Int, CNNo), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@ReturnQty", SqlDbType.Int, ReturnQty), base.CreateParameter("@Comment", SqlDbType.NVarChar, Comment), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@TotReturnQty", SqlDbType.Int, TotReturnQty), base.CreateParameter("@DefectQty", SqlDbType.Int, DefectQty), base.CreateParameter("@GCN", SqlDbType.Int, GCN), base.CreateParameter("@SCN", SqlDbType.Int, SCN),
                base.CreateParameter("@CNDate", SqlDbType.DateTime, CNDate)
            });
            command.Dispose();
        }

        public void Save_CN(int AutoID, int CNNo, string CustCode, string BookCode, decimal Rate, decimal Discount, int ReturnQty, string Comment, bool IsActive, string CreatedBy, string UpdatedBy, string Flag, int TotReturnQty, int DefectQty, int GCN, int SCN, int strFY, DateTime CNDate, string TransportName, string LrNo, string Remark1, string Remark2, string Remark3, string Remark4, string Remark5)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_CN", new IDataParameter[] { 
                base.CreateParameter("@AutoID", SqlDbType.Int, AutoID), base.CreateParameter("@CNNo", SqlDbType.Int, CNNo), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@ReturnQty", SqlDbType.Int, ReturnQty), base.CreateParameter("@Comment", SqlDbType.NVarChar, Comment), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@TotReturnQty", SqlDbType.Int, TotReturnQty), base.CreateParameter("@DefectQty", SqlDbType.Int, DefectQty), base.CreateParameter("@GCN", SqlDbType.Int, GCN), base.CreateParameter("@SCN", SqlDbType.Int, SCN),
                base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CNDate", SqlDbType.DateTime, CNDate), base.CreateParameter("@TransportName", SqlDbType.NVarChar, TransportName), base.CreateParameter("@LrNo", SqlDbType.NVarChar, LrNo), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3), base.CreateParameter("@Remark4", SqlDbType.NVarChar, Remark4), base.CreateParameter("@Remark5", SqlDbType.NVarChar, Remark5)
            });
            command.Dispose();
        }

        public void Save_DC_Email(int DocumentNo, string CreatedBy, bool IsActive)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Email", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive) });
            command.Dispose();
        }

        public void Save_DC_PrintInvoiceDetails(int PrintInvoiceDetails, decimal SubDocId, bool IsPrintInvoice, int PrintCount, string CreatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_PrintInvoiceDetails", new IDataParameter[] { base.CreateParameter("@PrintInvoiceDetails", SqlDbType.Int, PrintInvoiceDetails), base.CreateParameter("@SubDocId", SqlDbType.Decimal, SubDocId), base.CreateParameter("@IsPrintInvoice", SqlDbType.Bit, IsPrintInvoice), base.CreateParameter("@PrintCount", SqlDbType.Int, PrintCount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
            command.Dispose();
        }

        public void Save_DC_PrintInvoiceDetails(int PrintInvoiceDetails, decimal SubDocId, bool IsPrintInvoice, int PrintCount, string CreatedBy, int strFY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_PrintInvoiceDetails", new IDataParameter[] { base.CreateParameter("@PrintInvoiceDetails", SqlDbType.Int, PrintInvoiceDetails), base.CreateParameter("@SubDocId", SqlDbType.Decimal, SubDocId), base.CreateParameter("@IsPrintInvoice", SqlDbType.Bit, IsPrintInvoice), base.CreateParameter("@PrintCount", SqlDbType.Int, PrintCount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
            command.Dispose();
        }

        public void Save_DC_ReturnBook(int DCReturnBkID, string CustCode, string BookCode, int ReturnQty, string Comment, string CreatedBy, string Flag, int DefectQty)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_DC_ReturnBook", new IDataParameter[] { base.CreateParameter("@DCReturnBkID", SqlDbType.Int, DCReturnBkID), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@ReturnQty", SqlDbType.Int, ReturnQty), base.CreateParameter("@Comment", SqlDbType.NVarChar, Comment), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@DefectQty", SqlDbType.Int, DefectQty) });
            command.Dispose();
        }

        public void Save_DC_ReturnBook(int DCReturnBkID, string CustCode, string BookCode, int ReturnQty, string Comment, string CreatedBy, string Flag, int DefectQty, int strFY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_DC_ReturnBook", new IDataParameter[] { base.CreateParameter("@DCReturnBkID", SqlDbType.Int, DCReturnBkID), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@ReturnQty", SqlDbType.Int, ReturnQty), base.CreateParameter("@Comment", SqlDbType.NVarChar, Comment), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@DefectQty", SqlDbType.Int, DefectQty), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
            command.Dispose();
        }

        public void Save_DCConfirmQtyDetails(int ConfirmODcQtyId, int DCDetailID, int AvailableQty, decimal subDocNo, decimal parcel, decimal bundles, string CreatedBy)
        {
            base.ExecuteNonQuery("Idv_Chetana_DC_Save_ConfirmQtyDetails1", new IDataParameter[] { base.CreateParameter("@ConfirmDcQtyId", SqlDbType.Int, ConfirmODcQtyId), base.CreateParameter("@DCDetailID", SqlDbType.Int, DCDetailID), base.CreateParameter("@AvailableQty", SqlDbType.Int, AvailableQty), base.CreateParameter("@SubDocNo", SqlDbType.Decimal, subDocNo), base.CreateParameter("@Bundles", SqlDbType.Decimal, bundles), base.CreateParameter("@Parcel", SqlDbType.Decimal, parcel), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public void Save_DCToGodown(decimal DCDetailID, int DocumentNo, string EmpID, string CreatedBy, string UpdatedBy)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_DCToGodown", new IDataParameter[] { base.CreateParameter("@DCDetailID", SqlDbType.Money, DCDetailID), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@EmpID", SqlDbType.NVarChar, EmpID), base.CreateParameter("@CreatedBy ", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
        }

        public void Save_FrightTax_Details(int Autoid, int DocumentNo, decimal SubConfirmID, decimal fright, decimal tax, decimal tamount, DateTime invoicedate, string Lrno, string CreatedBy)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_FreightTax", new IDataParameter[] { base.CreateParameter("@Auto_ID", SqlDbType.Int, Autoid), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SubConfirmID", SqlDbType.Decimal, SubConfirmID), base.CreateParameter("@Freight", SqlDbType.Decimal, fright), base.CreateParameter("@Tax", SqlDbType.Decimal, tax), base.CreateParameter("@TotalAmount", SqlDbType.Decimal, tamount), base.CreateParameter("@invoicedate", SqlDbType.DateTime, invoicedate), base.CreateParameter("@lrno", SqlDbType.NVarChar, Lrno), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public void Save_FrightTax_Details(int Autoid, int DocumentNo, decimal SubConfirmID, decimal fright, decimal tax, decimal tamount, DateTime invoicedate, string Lrno, string CreatedBy, int strfy)
        {
            base.ExecuteNonQuery("Idv_Chetana_Save_FreightTax", new IDataParameter[] { base.CreateParameter("@Auto_ID", SqlDbType.Int, Autoid), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SubConfirmID", SqlDbType.Decimal, SubConfirmID), base.CreateParameter("@Freight", SqlDbType.Decimal, fright), base.CreateParameter("@Tax", SqlDbType.Decimal, tax), base.CreateParameter("@TotalAmount", SqlDbType.Decimal, tamount), base.CreateParameter("@invoicedate", SqlDbType.DateTime, invoicedate), base.CreateParameter("@lrno", SqlDbType.NVarChar, Lrno), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@fy", SqlDbType.Int, strfy) });
        }

        public void Save_GenerateInvoice_Details(decimal SubDocId, bool IsCreateInvoice, string CreatedInvoiceBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_GenerateInvoice_Details", new IDataParameter[] { base.CreateParameter("@SubDocId", SqlDbType.Decimal, SubDocId), base.CreateParameter("@IsCreateInvoice", SqlDbType.Bit, IsCreateInvoice), base.CreateParameter("@CreatedInvoiceBy", SqlDbType.NVarChar, CreatedInvoiceBy) });
            command.Dispose();
        }

        public void Save_GenerateInvoice_Details(decimal SubDocId, bool IsCreateInvoice, string CreatedInvoiceBy, int strfy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_GenerateInvoice_Details", new IDataParameter[] { base.CreateParameter("@SubDocId", SqlDbType.Decimal, SubDocId), base.CreateParameter("@IsCreateInvoice", SqlDbType.Bit, IsCreateInvoice), base.CreateParameter("@CreatedInvoiceBy", SqlDbType.NVarChar, CreatedInvoiceBy), base.CreateParameter("@fy", SqlDbType.Int, strfy) });
            command.Dispose();
        }

        public void save_ReceiptBookDetailsdal(int ReceiptBookID, string EmpCode, int FromNo, int ToNo, int ActualReceiptNo, bool IsActive, bool IsCancel, string CreatedBy, int FY, out int IDNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_ReceiptBookDetails", new IDataParameter[] { base.CreateParameter("@ReceiptBookID", SqlDbType.Int, ReceiptBookID), base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@FromNo", SqlDbType.Int, FromNo), base.CreateParameter("@ToNo", SqlDbType.Int, ToNo), base.CreateParameter("@ActualReceiptNo", SqlDbType.Int, ActualReceiptNo), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsCancel", SqlDbType.Bit, IsCancel), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Fy", SqlDbType.Int, FY), base.CreateParameter("@IDNo", SqlDbType.Int, ParameterDirection.Output) });
            IDNo = Convert.ToInt32(command.Parameters["@IDNo"].Value);
            command.Dispose();
        }

        public string Save_SchoolwiseTarget(int AutoID, string CustCode, string CurrentYrTarget, string Achieved, string NextYrtarget, string SchoolPotential, int FY, bool IsActive, bool Isdeleted, string CreatedBy, string Remark1, string Remark2, string Remark3, string Remark4, string Remark5, int Zoneid, int SuperZoneid)
        {
            SqlCommand command;
            string str = "";
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_SchoolwiseTarget", new IDataParameter[] { 
                base.CreateParameter("@AutoID", SqlDbType.Int, AutoID), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@CurrentYrTarget", SqlDbType.VarChar, CurrentYrTarget), base.CreateParameter("@Achieved", SqlDbType.NVarChar, Achieved), base.CreateParameter("@NextYrtarget", SqlDbType.NVarChar, NextYrtarget), base.CreateParameter("@SchoolPotential", SqlDbType.NVarChar, SchoolPotential), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3), base.CreateParameter("@Remark4", SqlDbType.NVarChar, Remark4), base.CreateParameter("@Remark5", SqlDbType.NVarChar, Remark5), base.CreateParameter("@Zoneid", SqlDbType.Int, Zoneid),
                base.CreateParameter("@SuperZoneid", SqlDbType.Int, SuperZoneid), base.CreateParameter("@return", SqlDbType.NVarChar, ParameterDirection.Output, 20)
            });
            str = command.Parameters["@return"].Value.ToString();
            command.Dispose();
            return str;
        }

        public void SaveActual_InvoiceDetails(int GanerateinvoiceId, int DocumentNo, decimal SubDocId, string BookCode, string BookName, string Standard, string Medium, int Quantity, decimal Rate, decimal Discount, decimal Amount, decimal fright, decimal tax, decimal tamount, DateTime InvoiceDate, string Lrno, string Transporter, bool IsActive, bool Isdeleted, string Bundles, string CreatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_ActualInvoiceDetails", new IDataParameter[] { 
                base.CreateParameter("@GanerateinvoiceId", SqlDbType.Int, GanerateinvoiceId), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SubDocId", SqlDbType.Decimal, SubDocId), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@BookName", SqlDbType.VarChar, BookName), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@Medium", SqlDbType.VarChar, Medium), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Freight", SqlDbType.Decimal, fright), base.CreateParameter("@Tax", SqlDbType.Decimal, tax), base.CreateParameter("@TotalAmount", SqlDbType.Money, tamount), base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, InvoiceDate), base.CreateParameter("@lrno", SqlDbType.NVarChar, Lrno),
                base.CreateParameter("@Transporter", SqlDbType.NVarChar, Transporter), base.CreateParameter("@Isactive", SqlDbType.Bit, IsActive), base.CreateParameter("@Isdelete", SqlDbType.Bit, Isdeleted), base.CreateParameter("@Bundles", SqlDbType.NVarChar, Bundles), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy)
            });
            command.Dispose();
        }

        public void SaveActual_InvoiceDetails(int GanerateinvoiceId, int DocumentNo, decimal SubDocId, string BookCode, string BookName, string Standard, string Medium, int Quantity, decimal Rate, decimal Discount, decimal Amount, decimal fright, decimal tax, decimal tamount, DateTime InvoiceDate, string Lrno, string Transporter, bool IsActive, bool Isdeleted, string Bundles, string CreatedBy, string strfy, DateTime Lrdate, string Remark1, string Remark2, string Remark3)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_ActualInvoiceDetails", new IDataParameter[] { 
                base.CreateParameter("@GanerateinvoiceId", SqlDbType.Int, GanerateinvoiceId), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@SubDocId", SqlDbType.Decimal, SubDocId), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@BookName", SqlDbType.VarChar, BookName), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@Medium", SqlDbType.VarChar, Medium), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Freight", SqlDbType.Decimal, fright), base.CreateParameter("@Tax", SqlDbType.Decimal, tax), base.CreateParameter("@TotalAmount", SqlDbType.Money, tamount), base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, InvoiceDate), base.CreateParameter("@lrno", SqlDbType.NVarChar, Lrno),
                base.CreateParameter("@Transporter", SqlDbType.NVarChar, Transporter), base.CreateParameter("@Isactive", SqlDbType.Bit, IsActive), base.CreateParameter("@Isdelete", SqlDbType.Bit, Isdeleted), base.CreateParameter("@Bundles", SqlDbType.NVarChar, Bundles), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@fy", SqlDbType.NVarChar, strfy), base.CreateParameter("@LRDate", SqlDbType.DateTime, Lrdate), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3)
            });
            command.Dispose();
        }

        public void SaveBankPayment(int BankPaymentID, string BankCode, int Documentno, int Serialno, DateTime DocumentDate, string AccountCode, string PersonInCharge, string ReportCode, string Cash_Cheque_DD, string Cheque_DD_NO, string Type, decimal Amount, string DrawnOn, string Remarks, bool IsActive, string CreatedBy, string UpdatedBy, out int DocNo, int strFY, string Paymode, bool IsChequeBounce)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BankPayment", new IDataParameter[] { 
                base.CreateParameter("@BankPaymentID", SqlDbType.Int, BankPaymentID), base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@Documentno", SqlDbType.Int, Documentno), base.CreateParameter("@Serialno", SqlDbType.Int, Serialno), base.CreateParameter("@DocumentDate", SqlDbType.DateTime, DocumentDate), base.CreateParameter("@AccountCode", SqlDbType.NVarChar, AccountCode), base.CreateParameter("@PersonInCharge", SqlDbType.NVarChar, PersonInCharge), base.CreateParameter("@ReportCode", SqlDbType.NVarChar, ReportCode), base.CreateParameter("@Cash_Cheque_DD", SqlDbType.NVarChar, Cash_Cheque_DD), base.CreateParameter("@Cheque_DD_NO", SqlDbType.NVarChar, Cheque_DD_NO), base.CreateParameter("@Type", SqlDbType.NVarChar, Type), base.CreateParameter("@Amount", SqlDbType.Decimal, Amount), base.CreateParameter("@DrawnOn", SqlDbType.NVarChar, DrawnOn), base.CreateParameter("@Remarks", SqlDbType.NVarChar, Remarks), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@Paymode", SqlDbType.NVarChar, Paymode), base.CreateParameter("@IsChequeBounce", SqlDbType.Bit, IsChequeBounce)
            });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public void SaveBankReceipt(int BankReceiptID, string BankCode, int Documentno, int Serialno, DateTime DocumentDate, string AccountCode, string PersonInCharge, string ReportCode, int SalesmanReceiptNo, string Cash_Cheque_DD, string Cheque_DD_NO, string Type, decimal Amount, string DrawnOn, string Remarks, bool IsActive, string CreatedBy, string UpdatedBy, out int DocNo, int strFY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BankReceipt", new IDataParameter[] { 
                base.CreateParameter("@BankReceiptID", SqlDbType.Int, BankReceiptID), base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@Documentno", SqlDbType.Int, Documentno), base.CreateParameter("@Serialno", SqlDbType.Int, Serialno), base.CreateParameter("@DocumentDate", SqlDbType.DateTime, DocumentDate), base.CreateParameter("@AccountCode", SqlDbType.NVarChar, AccountCode), base.CreateParameter("@PersonInCharge", SqlDbType.NVarChar, PersonInCharge), base.CreateParameter("@ReportCode", SqlDbType.NVarChar, ReportCode), base.CreateParameter("@SalesmanReceiptNo", SqlDbType.Int, SalesmanReceiptNo), base.CreateParameter("@Cash_Cheque_DD", SqlDbType.NVarChar, Cash_Cheque_DD), base.CreateParameter("@Cheque_DD_NO", SqlDbType.NVarChar, Cheque_DD_NO), base.CreateParameter("@Type", SqlDbType.NVarChar, Type), base.CreateParameter("@Amount", SqlDbType.Decimal, Amount), base.CreateParameter("@DrawnOn", SqlDbType.NVarChar, DrawnOn), base.CreateParameter("@Remarks", SqlDbType.NVarChar, Remarks), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@FY", SqlDbType.Int, strFY)
            });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public void SaveBankReceiptPaymentDetails(int Bank_RecPayID, int AccBookID, int AccDocumentNo, int AccDocSerialNo, string CustomerCode, string SalesmanCode, string SalesmanReceipt, string Cash_Cheque_DD, string Cheque_DDNo, string Type, decimal Amount, string DrawnOn, int NarrationID, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_ReceiptPaymentDetails", new IDataParameter[] { 
                base.CreateParameter("@Bank_RecPayID", SqlDbType.Int, Bank_RecPayID), base.CreateParameter("@AccBookID", SqlDbType.Int, AccBookID), base.CreateParameter("@AccDocumentNo", SqlDbType.Int, AccDocumentNo), base.CreateParameter("@AccDocSerialNo", SqlDbType.Int, AccDocSerialNo), base.CreateParameter("@CustomerCode", SqlDbType.NVarChar, CustomerCode), base.CreateParameter("@SalesmanCode", SqlDbType.NVarChar, SalesmanCode), base.CreateParameter("@SalesmanReceipt", SqlDbType.NVarChar, SalesmanReceipt), base.CreateParameter("@Cash_Cheque_DD", SqlDbType.NVarChar, Cash_Cheque_DD), base.CreateParameter("@Cheque_DDNo", SqlDbType.NVarChar, Cheque_DDNo), base.CreateParameter("@Type", SqlDbType.NVarChar, Type), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@DrawnOn", SqlDbType.NVarChar, DrawnOn), base.CreateParameter("@NarrationID", SqlDbType.Int, NarrationID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy)
            });
            command.Dispose();
        }

        public void SaveBankReceiptPaymentMaster(int AccDocumentNo, DateTime AccDocumentDate, string ReceiptPayment, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy, out int DocNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_ReceiptPaymentMaster", new IDataParameter[] { base.CreateParameter("@AccDocumentNo", SqlDbType.Int, AccDocumentNo), base.CreateParameter("@AccDocumentDate", SqlDbType.DateTime, AccDocumentDate), base.CreateParameter("@ReceiptPayment", SqlDbType.NVarChar, ReceiptPayment), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public void SaveBrokerMaster(int BrokerID, string BrokerCode, string FirstName, string MiddleName, string LastName, string Address, string Zip, int CityID, string Phone1, string Phone2, string Gender, string DOB, string EmailID, int BrokerageRate, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BrokerMaster", new IDataParameter[] { 
                base.CreateParameter("@BrokerID", SqlDbType.Int, BrokerID), base.CreateParameter("@BrokerCode", SqlDbType.NVarChar, BrokerCode), base.CreateParameter("@FirstName", SqlDbType.NVarChar, FirstName), base.CreateParameter("@MiddleName", SqlDbType.NVarChar, MiddleName), base.CreateParameter("@LastName", SqlDbType.NVarChar, LastName), base.CreateParameter("@Address", SqlDbType.NVarChar, Address), base.CreateParameter("@Zip", SqlDbType.NVarChar, Zip), base.CreateParameter("@CityID", SqlDbType.Int, CityID), base.CreateParameter("@Phone1", SqlDbType.NVarChar, Phone1), base.CreateParameter("@Phone2", SqlDbType.NVarChar, Phone2), base.CreateParameter("@Gender", SqlDbType.NVarChar, Gender), base.CreateParameter("@DOB", SqlDbType.NVarChar, DOB), base.CreateParameter("@EmailID", SqlDbType.NVarChar, EmailID), base.CreateParameter("@BrokerageRate", SqlDbType.Int, BrokerageRate), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy)
            });
            command.Dispose();
        }

        public DataSet SaveChequebounceDetails(int AutoId, int ReceiptNo, string ChequeNo, string ChequeReturnDate, decimal ReturnAmount, string ReturnRemark, decimal Amount, int cq_id, int FYfrom, int FYto)
        {
            return base.ExecuteDataSet("Idv_Chetana_Save_BounceCheque", new IDataParameter[] { base.CreateParameter("@AutoId", SqlDbType.Int, AutoId), base.CreateParameter("@ReceiptNo", SqlDbType.Int, ReceiptNo), base.CreateParameter("@ChequeNo", SqlDbType.NVarChar, ChequeNo), base.CreateParameter("@ChequeReturnDate", SqlDbType.NVarChar, ChequeReturnDate), base.CreateParameter("@ReturnAmount", SqlDbType.Money, ReturnAmount), base.CreateParameter("@ReturnRemark", SqlDbType.NVarChar, ReturnRemark), base.CreateParameter("@DebitAmount", SqlDbType.Money, Amount), base.CreateParameter("@cq_id", SqlDbType.Int, cq_id), base.CreateParameter("@FYfrom", SqlDbType.Int, FYfrom), base.CreateParameter("@FYto", SqlDbType.Int, FYto) });
        }

        public DataSet saveChequeCash_valid(int ReciptNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_ChequeCashDetails", new IDataParameter[] { base.CreateParameter("@tmp", SqlDbType.Int, ReciptNo) });
        }

        public void SaveCNProgrammeChartDetails(string ActualKey, string Value, string GroupKey, int SuperZoneId, int PreviousCount, int NewCount, string CreatedBy, string flag)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_MoM", new IDataParameter[] { base.CreateParameter("@ActualKey", SqlDbType.VarChar, ActualKey), base.CreateParameter("@Value", SqlDbType.VarChar, Value), base.CreateParameter("@GroupKey", SqlDbType.VarChar, GroupKey), base.CreateParameter("@SuperZoneId", SqlDbType.Int, SuperZoneId), base.CreateParameter("@PreviousCount", SqlDbType.Int, PreviousCount), base.CreateParameter("@NewCount", SqlDbType.Int, NewCount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
            command.Dispose();
        }

        public void SaveCourierDetail(string DocNo, string flag, int FY, int CourierID, int BranchID, string Address, string CreatedBy, out int SCD)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CourierDetails", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@CourierID", SqlDbType.Int, CourierID), base.CreateParameter("@BranchID", SqlDbType.Int, BranchID), base.CreateParameter("@Address", SqlDbType.NVarChar, Address), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@SCD", SqlDbType.Int, ParameterDirection.Output) });
            SCD = Convert.ToInt32(command.Parameters["@SCD"].Value);
            command.Dispose();
        }

        public void SaveCourierDetails(string DocNo, string flag, int FY, int CourierID, int BranchID, string BranchAdd, string Department, string Address, string Remark1, string CreatedBy, string Weight, DateTime Courierdate, out int SCD)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_CourierDetails", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@CourierID", SqlDbType.Int, CourierID), base.CreateParameter("@BranchID", SqlDbType.Int, BranchID), base.CreateParameter("@BranchAdd", SqlDbType.NVarChar, BranchAdd), base.CreateParameter("@Department", SqlDbType.NVarChar, Department), base.CreateParameter("@Address", SqlDbType.NVarChar, Address), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Weight", SqlDbType.NVarChar, Weight), base.CreateParameter("@courierdate", SqlDbType.DateTime, Courierdate), base.CreateParameter("@SCD", SqlDbType.Int, ParameterDirection.Output) });
            SCD = Convert.ToInt32(command.Parameters["@SCD"].Value);
            command.Dispose();
        }

        public void SaveDC(int DocumentNo, DateTime DocumentDate, string ChallanNo, DateTime ChallanDate, string OrderNo, DateTime OrderDate, string SalesmanCode, string Custcode, string PIncharge, string Transporter, string TransportID, string Bankcode, string SpInstruction, string CreatedBy, string UpdatedBy, bool IsActive, bool IsDeleted, string strChetanaCompanyName, out int DocNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DCMaster", new IDataParameter[] { 
                base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@DocumentDate", SqlDbType.DateTime, DocumentDate), base.CreateParameter("@ChallanNo", SqlDbType.NVarChar, ChallanNo), base.CreateParameter("@ChallanDate", SqlDbType.DateTime, ChallanDate), base.CreateParameter("@OrderNo", SqlDbType.NVarChar, OrderNo), base.CreateParameter("@OrderDate", SqlDbType.DateTime, OrderDate), base.CreateParameter("@SalesmanCode", SqlDbType.NVarChar, SalesmanCode), base.CreateParameter("@CustCode", SqlDbType.NVarChar, Custcode), base.CreateParameter("@PIncharge", SqlDbType.NVarChar, PIncharge), base.CreateParameter("@Transporter", SqlDbType.NVarChar, Transporter), base.CreateParameter("@transportid", SqlDbType.NVarChar, TransportID), base.CreateParameter("@Bankcode", SqlDbType.NVarChar, Bankcode), base.CreateParameter("@SpInstruction", SqlDbType.NVarChar, SpInstruction), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive),
                base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@ChetanaCompanyName", SqlDbType.NVarChar, strChetanaCompanyName), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output)
            });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public void SaveDC(int DocumentNo, DateTime DocumentDate, string ChallanNo, DateTime ChallanDate, string OrderNo, DateTime OrderDate, string SalesmanCode, string Custcode, string PIncharge, string Transporter, string TransportID, string Bankcode, string SpInstruction, string CreatedBy, string UpdatedBy, bool IsActive, bool IsDeleted, string strChetanaCompanyName, int strFY, out int DocNo, out int DocNewNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DCMaster", new IDataParameter[] { 
                base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@DocumentDate", SqlDbType.DateTime, DocumentDate), base.CreateParameter("@ChallanNo", SqlDbType.NVarChar, ChallanNo), base.CreateParameter("@ChallanDate", SqlDbType.DateTime, ChallanDate), base.CreateParameter("@OrderNo", SqlDbType.NVarChar, OrderNo), base.CreateParameter("@OrderDate", SqlDbType.DateTime, OrderDate), base.CreateParameter("@SalesmanCode", SqlDbType.NVarChar, SalesmanCode), base.CreateParameter("@CustCode", SqlDbType.NVarChar, Custcode), base.CreateParameter("@PIncharge", SqlDbType.NVarChar, PIncharge), base.CreateParameter("@Transporter", SqlDbType.NVarChar, Transporter), base.CreateParameter("@transportid", SqlDbType.NVarChar, TransportID), base.CreateParameter("@Bankcode", SqlDbType.NVarChar, Bankcode), base.CreateParameter("@SpInstruction", SqlDbType.NVarChar, SpInstruction), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive),
                base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@ChetanaCompanyName", SqlDbType.NVarChar, strChetanaCompanyName), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@DocNewNo", SqlDbType.Int, ParameterDirection.Output)
            });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            DocNewNo = Convert.ToInt32(command.Parameters["@DocNewNo"].Value);
            command.Dispose();
        }

        public void SaveDCDetails(int DCDetailID, int DocumentNo, string BookCode, string BookName, string Standard, string Medium, int Quantity, decimal Rate, decimal Amount, decimal Discount, string Publisher, bool IsActive, bool Isdeleted, string CreatedBy, string UpdatedBy, DateTime DeliveryDate)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DCDetails", new IDataParameter[] { base.CreateParameter("@DCDetailID", SqlDbType.Int, DCDetailID), base.CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@BookName", SqlDbType.VarChar, BookName), base.CreateParameter("@Standard", SqlDbType.NVarChar, Standard), base.CreateParameter("@Medium", SqlDbType.VarChar, Medium), base.CreateParameter("@Quantity", SqlDbType.Int, Quantity), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@Publisher", SqlDbType.NVarChar, Publisher), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, Isdeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@DeliveryDate", SqlDbType.DateTime, DeliveryDate) });
            command.Dispose();
        }

        public void SaveDispatchEmailDetails(int DocNo, string flag, int FY, string CreatedBy, out int SCD)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DispatchEmail", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@SCD", SqlDbType.Int, ParameterDirection.Output) });
            SCD = Convert.ToInt32(command.Parameters["@SCD"].Value);
            command.Dispose();
        }

        public void SaveDNDetail(int DNDetailID, int DNMasterID, string AccountCode, decimal DebitAmount, decimal CreditAmount, string Remarks, bool IsActive, string CreatedBy, string UpdatedBy, int strFY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DNDetail", new IDataParameter[] { base.CreateParameter("@DNDetailID", SqlDbType.Int, DNDetailID), base.CreateParameter("@DNMasterID", SqlDbType.Int, DNMasterID), base.CreateParameter("@AccountCode", SqlDbType.NVarChar, AccountCode), base.CreateParameter("@DebitAmount", SqlDbType.Money, DebitAmount), base.CreateParameter("@CreditAmount", SqlDbType.Money, CreditAmount), base.CreateParameter("@Remarks", SqlDbType.NVarChar, Remarks), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
            command.Dispose();
        }

        public void SaveDNMaster(int DNMasterID, int DNDocNo, DateTime DNDocDate, string BookCode, string DNAccountCode, bool IsActive, string CreatedBy, string UpdatedBy, out int DocNo, out int DNMID, int strFY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DNMaster", new IDataParameter[] { base.CreateParameter("@DNMasterID", SqlDbType.Int, DNMasterID), base.CreateParameter("@DNDocNo", SqlDbType.Int, DNDocNo), base.CreateParameter("@DNDocDate", SqlDbType.DateTime, DNDocDate), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@DNAccountCode", SqlDbType.NVarChar, DNAccountCode), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@DNMID", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            DNMID = Convert.ToInt32(command.Parameters["@DNMID"].Value);
            command.Dispose();
        }

        public void SaveFaculty(int Fct_ID, string Name, string Schl_Name, string Res_Add, string Pincode, string Contact, string Res_No, string Qualification, string Tch_Exp, string Spec_Sub, string Sub_Intrs_Wrt, string Prvs_Exp_Wrt, string Pls_Mnt_bk_Pub, string CreatedBy, string UpdatedBy, int Fy, string Remark1, string Remark2, int SDZ, int SZ, int Z)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Faculty_Details", new IDataParameter[] { 
                base.CreateParameter("@Fct_ID", SqlDbType.Int, Fct_ID), base.CreateParameter("@Name", SqlDbType.NVarChar, Name), base.CreateParameter("@Schl_Name", SqlDbType.NVarChar, Schl_Name), base.CreateParameter("@Res_Add", SqlDbType.NVarChar, Res_Add), base.CreateParameter("@Pincode", SqlDbType.NVarChar, Pincode), base.CreateParameter("@Contact", SqlDbType.NVarChar, Contact), base.CreateParameter("@Res_No", SqlDbType.NVarChar, Res_No), base.CreateParameter("@Qualification", SqlDbType.NVarChar, Qualification), base.CreateParameter("@Tch_Exp", SqlDbType.NVarChar, Tch_Exp), base.CreateParameter("@Spec_Sub", SqlDbType.NVarChar, Spec_Sub), base.CreateParameter("@Sub_Intrs_Wrt", SqlDbType.NVarChar, Sub_Intrs_Wrt), base.CreateParameter("@Prvs_Exp_Wrt", SqlDbType.NVarChar, Prvs_Exp_Wrt), base.CreateParameter("@Pls_Mnt_bk_Pub", SqlDbType.NVarChar, Pls_Mnt_bk_Pub), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1),
                base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Fy", SqlDbType.Int, Fy), base.CreateParameter("@SDZ", SqlDbType.Int, SDZ), base.CreateParameter("@SZ", SqlDbType.Int, SZ), base.CreateParameter("@Z", SqlDbType.Int, Z)
            });
        }

        public void SaveIdv_Chetana_Cheque_Cash_Deposite_Details(int CQ_ID, int EmpID, string CustId, int ReciptNo, string Deposite_Type, string ChequeNo, DateTime ChequeDate, string Deposited_By, decimal Amount, string CreatedBy, DateTime createdon, bool IsCancel, string Description, string CancelBy, DateTime CancelDate, string BankName)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_ChequeCashDepositeDetails", new IDataParameter[] { base.CreateParameter("@CQ_ID", SqlDbType.Int, CQ_ID), base.CreateParameter("@EmpID", SqlDbType.Int, EmpID), base.CreateParameter("@CustId", SqlDbType.NVarChar, CustId), base.CreateParameter("@ReciptNo", SqlDbType.Int, ReciptNo), base.CreateParameter("@Deposite_Type", SqlDbType.NVarChar, Deposite_Type), base.CreateParameter("@ChequeNo", SqlDbType.NVarChar, ChequeNo), base.CreateParameter("@ChequeDate", SqlDbType.DateTime, ChequeDate), base.CreateParameter("@Deposited_By", SqlDbType.NVarChar, Deposited_By), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@createdon", SqlDbType.DateTime, createdon), base.CreateParameter("@IsCancel", SqlDbType.Bit, IsCancel), base.CreateParameter("@Description", SqlDbType.NVarChar, Description), base.CreateParameter("@CancelBy", SqlDbType.NVarChar, CancelBy), base.CreateParameter("@CancelDate", SqlDbType.DateTime, CancelDate), base.CreateParameter("@BankName", SqlDbType.NVarChar, BankName) });
            command.Dispose();
        }

        public void SaveIdv_Chetana_LedgerDetails(int LedgerId, string Particulass, decimal DebitAmount, decimal CreditAmount, decimal balance, DateTime CreaditDate, string FinancialYearFrom, string FinancialYearTo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_LedgerDetails", new IDataParameter[] { base.CreateParameter("@LedgerId", SqlDbType.Int, LedgerId), base.CreateParameter("@Particulass", SqlDbType.NVarChar, Particulass), base.CreateParameter("@DebitAmount", SqlDbType.Money, DebitAmount), base.CreateParameter("@CreditAmount", SqlDbType.Money, CreditAmount), base.CreateParameter("@balance", SqlDbType.Money, balance), base.CreateParameter("@CreaditDate", SqlDbType.DateTime, CreaditDate), base.CreateParameter("@FinancialYearFrom", SqlDbType.NVarChar, FinancialYearFrom), base.CreateParameter("@FinancialYearTo", SqlDbType.NVarChar, FinancialYearTo) });
            command.Dispose();
        }

        public void SaveIdv_Chetana_PettyCash_Details(int AutoID, string VoucherNo, int ExpenseHead, string EmpCode, decimal Amount, string VoucherBillSubmitDate, decimal TotalAmount, bool IsPaid, string CreatedBy, string Remark, bool IsActive)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_PettyCashEntry", new IDataParameter[] { base.CreateParameter("@AutoID", SqlDbType.Int, AutoID), base.CreateParameter("@VoucherNo", SqlDbType.NVarChar, VoucherNo), base.CreateParameter("@ExpenseHead", SqlDbType.Int, ExpenseHead), base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EmpCode), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@VoucherBillSubmitDate", SqlDbType.NVarChar, VoucherBillSubmitDate), base.CreateParameter("@TotalAmount", SqlDbType.Money, TotalAmount), base.CreateParameter("@IsPaid", SqlDbType.Bit, IsPaid), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@Remark", SqlDbType.NVarChar, Remark), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive) });
            command.Dispose();
        }

        public void SaveIdv_Chetana_PettyCashEntry(int VoucherNo, int VoucherNo_New, string PartyCode, string PartyName, string MainRemark, DateTime VoucherDate, string Created_By, DateTime Updated_On, string Updated_By, bool Is_Active, decimal TotalAmount, int FY, out int IDNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_New_PettyCashEntry", new IDataParameter[] { base.CreateParameter("@VoucherNo", SqlDbType.Int, VoucherNo), base.CreateParameter("@VoucherNo_New", SqlDbType.Int, VoucherNo_New), base.CreateParameter("@PartyCode", SqlDbType.NVarChar, PartyCode), base.CreateParameter("@PartyName", SqlDbType.NVarChar, PartyName), base.CreateParameter("@MainRemark", SqlDbType.NVarChar, MainRemark), base.CreateParameter("@VoucherDate", SqlDbType.DateTime, VoucherDate), base.CreateParameter("@Created_By", SqlDbType.NVarChar, Created_By), base.CreateParameter("@Updated_On", SqlDbType.DateTime, Updated_On), base.CreateParameter("@Updated_By", SqlDbType.NVarChar, Updated_By), base.CreateParameter("@Is_Active", SqlDbType.Bit, Is_Active), base.CreateParameter("@TotalAmount", SqlDbType.Money, TotalAmount), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@IDNo", SqlDbType.Int, ParameterDirection.Output) });
            IDNo = Convert.ToInt32(command.Parameters["@IDNo"].Value);
            command.Dispose();
        }

        public void SaveIdv_Chetana_PettyCashEntry(int VoucherNo, int VoucherNo_New, string PartyCode, string PartyName, string MainRemark, DateTime VoucherDate, string Created_By, DateTime Updated_On, string Updated_By, bool Is_Active, decimal TotalAmount, int FY, out int IDNo, out int DocNewNo)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_New_PettyCashEntry", new IDataParameter[] { base.CreateParameter("@VoucherNo", SqlDbType.Int, VoucherNo), base.CreateParameter("@VoucherNo_New", SqlDbType.Int, VoucherNo_New), base.CreateParameter("@PartyCode", SqlDbType.NVarChar, PartyCode), base.CreateParameter("@PartyName", SqlDbType.NVarChar, PartyName), base.CreateParameter("@MainRemark", SqlDbType.NVarChar, MainRemark), base.CreateParameter("@VoucherDate", SqlDbType.DateTime, VoucherDate), base.CreateParameter("@Created_By", SqlDbType.NVarChar, Created_By), base.CreateParameter("@Updated_On", SqlDbType.DateTime, Updated_On), base.CreateParameter("@Updated_By", SqlDbType.NVarChar, Updated_By), base.CreateParameter("@Is_Active", SqlDbType.Bit, Is_Active), base.CreateParameter("@TotalAmount", SqlDbType.Money, TotalAmount), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@IDNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@DocNewNo", SqlDbType.Int, ParameterDirection.Output) });
            IDNo = Convert.ToInt32(command.Parameters["@IDNo"].Value);
            DocNewNo = Convert.ToInt32(command.Parameters["@DocNewNo"].Value);
            command.Dispose();
        }

        public void SaveIdv_Chetana_PettyCashExpences(int Voucher_Detail, int VoucherNo, string ExpenseCode, DateTime Date, decimal Amount, string Remark, DateTime CreatedOn, string CreatedBy, DateTime UpdatedOn, string UpdatedBy, bool IsActive, string ExpenceName)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_PettyCashExpence", new IDataParameter[] { base.CreateParameter("@Voucher_Detail", SqlDbType.Int, Voucher_Detail), base.CreateParameter("@VoucherNo", SqlDbType.Int, VoucherNo), base.CreateParameter("@ExpenseCode", SqlDbType.NVarChar, ExpenseCode), base.CreateParameter("@Date", SqlDbType.DateTime, Date), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@Remark", SqlDbType.NVarChar, Remark), base.CreateParameter("@CreatedOn", SqlDbType.DateTime, CreatedOn), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedOn", SqlDbType.DateTime, UpdatedOn), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@ExpenceName", SqlDbType.NVarChar, ExpenceName) });
            command.Dispose();
        }

        public void SaveJVDetail(int JVDetailID, int JVMasterID, string AccountCode, string ReportCode, decimal DebitAmount, decimal CreditAmount, string Remarks, bool Isactive, string CreatedBy, string UpdatedBy, int strFY, string flag)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_JVDetail", new IDataParameter[] { base.CreateParameter("@JVDetailID", SqlDbType.Int, JVDetailID), base.CreateParameter("@JVMasterID", SqlDbType.Int, JVMasterID), base.CreateParameter("@AccountCode", SqlDbType.NVarChar, AccountCode), base.CreateParameter("@ReportCode", SqlDbType.NVarChar, ReportCode), base.CreateParameter("@DebitAmount", SqlDbType.Money, DebitAmount), base.CreateParameter("@CreditAmount", SqlDbType.Money, CreditAmount), base.CreateParameter("@Remarks", SqlDbType.NVarChar, Remarks), base.CreateParameter("@Isactive", SqlDbType.Bit, Isactive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
            command.Dispose();
        }

        public void SaveJVMaster(int JVMasterID, int JVDocNo, DateTime JVDocDate, string CompanyCode, string BookCode, bool Isactive, string CreatedBy, string UpdatedBy, out int DocNo, out int JVMID, int strFY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_JVMaster", new IDataParameter[] { base.CreateParameter("@JVMasterID", SqlDbType.Int, JVMasterID), base.CreateParameter("@JVDocNo", SqlDbType.Int, JVDocNo), base.CreateParameter("@JVDocDate", SqlDbType.DateTime, JVDocDate), base.CreateParameter("@CompanyCode", SqlDbType.NVarChar, CompanyCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@Isactive", SqlDbType.Bit, Isactive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@JVMID", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@FY", SqlDbType.Int, strFY) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            JVMID = Convert.ToInt32(command.Parameters["@JVMID"].Value);
            command.Dispose();
        }

        public DataSet saveLedgerPaymentDetails(int Autoid, int ReceiptNo, int CQ_ID, decimal InvoiceNo, decimal debitAmount, decimal ReceiptAmount)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Save_PaymentLedger", new IDataParameter[] { base.CreateParameter("@Autoid", SqlDbType.Int, Autoid), base.CreateParameter("@ReceiptNo", SqlDbType.Int, ReceiptNo), base.CreateParameter("@CQ_ID", SqlDbType.Int, CQ_ID), base.CreateParameter("@InvoiceNo", SqlDbType.Money, InvoiceNo), base.CreateParameter("@debitAmount", SqlDbType.Money, debitAmount), base.CreateParameter("@ReceiptAmount", SqlDbType.Money, ReceiptAmount) });
        }

        public void SaveLoanPartyMaster(int PartyID, string PartyCode, string PartyName, string LoanReceivedGiven, string Address, string Zip, int CityID, string Phone1, string Phone2, string EmailID, decimal CreditLimit, string CreditDays, int InterestRate, bool IsActive, bool IsDeleted, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Loan_PartyMaster", new IDataParameter[] { 
                base.CreateParameter("@PartyID", SqlDbType.Int, PartyID), base.CreateParameter("@PartyCode", SqlDbType.NVarChar, PartyCode), base.CreateParameter("@PartyName", SqlDbType.NVarChar, PartyName), base.CreateParameter("@LoanReceivedGiven", SqlDbType.NVarChar, LoanReceivedGiven), base.CreateParameter("@Address", SqlDbType.NVarChar, Address), base.CreateParameter("@Zip", SqlDbType.NVarChar, Zip), base.CreateParameter("@CityID", SqlDbType.Int, CityID), base.CreateParameter("@Phone1", SqlDbType.NVarChar, Phone1), base.CreateParameter("@Phone2", SqlDbType.NVarChar, Phone2), base.CreateParameter("@EmailID", SqlDbType.NVarChar, EmailID), base.CreateParameter("@CreditLimit", SqlDbType.Money, CreditLimit), base.CreateParameter("@CreditDays", SqlDbType.NVarChar, CreditDays), base.CreateParameter("@InterestRate", SqlDbType.Int, InterestRate), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy)
            });
            command.Dispose();
        }

        public void SaveODDetail(int OdDAutoId, int OdMAutoId, int FY, string InvoiceNo, string InvoiceOrDC, string CustomerName, bool IsActive, bool IsDeleted, string CustArea)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Doc_Outward_Details", new IDataParameter[] { base.CreateParameter("@OdDAutoId", SqlDbType.Int, OdDAutoId), base.CreateParameter("@OdMAutoId", SqlDbType.Int, OdMAutoId), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@InvoiceNo", SqlDbType.NVarChar, InvoiceNo), base.CreateParameter("@InvoiceOrDC", SqlDbType.NVarChar, InvoiceOrDC), base.CreateParameter("@CustomerName", SqlDbType.NVarChar, CustomerName), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CustArea", SqlDbType.NVarChar, CustArea) });
            command.Dispose();
        }

        public void SaveODMaster(int OdMAutoId, int FY, DateTime OutWardDate, string HandOverTo, string CreatedBy, string UpdatedBy, bool IsActive, bool IsDeleted, string Remarks, out int DocNo, out int OdMID)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Doc_Outward_Master", new IDataParameter[] { base.CreateParameter("@OdMAutoId", SqlDbType.Int, OdMAutoId), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@OutWardDate", SqlDbType.DateTime, OutWardDate), base.CreateParameter("@HandOverTo", SqlDbType.NVarChar, HandOverTo), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@Remarks", SqlDbType.NVarChar, Remarks), base.CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@OdMID", SqlDbType.Int, ParameterDirection.Output) });
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            OdMID = Convert.ToInt32(command.Parameters["@OdMID"].Value);
            command.Dispose();
        }

        public DataSet saveReciptbook_valid(int receiptNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_ReceiptBookDetails", new IDataParameter[] { base.CreateParameter("@receiptNo", SqlDbType.Int, receiptNo) });
        }

        public DataSet saveReciptbook_valid(string EMcode, int receiptNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_ReceiptBookDetails", new IDataParameter[] { base.CreateParameter("@EmpCode", SqlDbType.NVarChar, EMcode), base.CreateParameter("@receiptNo", SqlDbType.Int, receiptNo) });
        }

        public DataSet saveReciptbookEntry2_valid(int FromNo, int ToNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_ReceiptEntryDetails", new IDataParameter[] { base.CreateParameter("@FromNo", SqlDbType.Int, FromNo), base.CreateParameter("@ToNo", SqlDbType.Int, ToNo) });
        }

        public void SaveStockUpdate(int StockUpdateID, string BookCode, int OldStock, int NewStock, int TotalStock, string Comment, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_StockUpdate", new IDataParameter[] { base.CreateParameter("@StockUpdateID", SqlDbType.Int, StockUpdateID), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@OldStock", SqlDbType.Int, OldStock), base.CreateParameter("@NewStock", SqlDbType.Int, NewStock), base.CreateParameter("@TotalStock", SqlDbType.Int, TotalStock), base.CreateParameter("@Comment", SqlDbType.NVarChar, Comment), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }

        public void SaveVirtualBook(string BookCode, int OpeningStock, int VirtualStock, int TotalStock, int CurrentStock, string Comment, string FinancialYear, string CreatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Book_VirtualStock", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@OpeningStock", SqlDbType.Int, OpeningStock), base.CreateParameter("@VirtualStock", SqlDbType.Int, VirtualStock), base.CreateParameter("@TotalStock", SqlDbType.Int, TotalStock), base.CreateParameter("@CurrentStock", SqlDbType.Int, CurrentStock), base.CreateParameter("@Comment", SqlDbType.NVarChar, Comment), base.CreateParameter("@FinancialYear", SqlDbType.NVarChar, FinancialYear), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
            command.Dispose();
        }

        public DataSet SendCourierEmail(float DocNo, string flag1, string flag2, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierEmail", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet SendCourierEmail(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierEmail", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo), base.CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromID", SqlDbType.NVarChar, FromID), base.CreateParameter("@PWD", SqlDbType.NVarChar, PWD), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public DataSet SendCourierPrint(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierPrint", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet SendCourierPrintGeneral(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierPrint", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet SendDispatchEmail(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendDispatchEmail", new IDataParameter[] { base.CreateParameter("@DispatchMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromID", SqlDbType.NVarChar, FromID), base.CreateParameter("@PWD", SqlDbType.NVarChar, PWD), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public DataSet SrcUpdateTktNo(string TKTID)
        {
            string paramValue = "TKTUPDATE";
            return base.ExecuteDataSet("Sp_LastTktNo", new IDataParameter[] { base.CreateParameter("@TKTID", SqlDbType.NVarChar, TKTID), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet UnPaidLedgerDetailForClient(int ClientId)
        {
            return base.ExecuteDataSet("IDV_Chetana_Get_UnPaidLedgerDetailForClient", new IDataParameter[] { base.CreateParameter("@ClientId", SqlDbType.Int, ClientId) });
        }

        public void Update(bool IsConfirm, bool IsApproved, bool IsCanceled, int DocNo, string Remark)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Update_DCMaster_IsAcCoCa", new IDataParameter[] { base.CreateParameter("@IsConfirm", SqlDbType.Bit, IsConfirm), base.CreateParameter("@IsApporved", SqlDbType.Bit, IsApproved), base.CreateParameter("@IsCanceled", SqlDbType.Bit, IsCanceled), base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@Remark", SqlDbType.NVarChar, Remark) });
        }

        public void Update(bool IsConfirm, bool IsApproved, bool IsCanceled, int DocNo, string Remark, int FY)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Update_DCMaster_IsAcCoCa", new IDataParameter[] { base.CreateParameter("@IsConfirm", SqlDbType.Bit, IsConfirm), base.CreateParameter("@IsApporved", SqlDbType.Bit, IsApproved), base.CreateParameter("@IsCanceled", SqlDbType.Bit, IsCanceled), base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@Remark", SqlDbType.NVarChar, Remark), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public void Update_BankRaconcilation(int Recoid, bool IsReco, DateTime RecoDate, string flag)
        {
            base.ExecuteNonQuery("Idv_Chetana_Update_BankRaconcilation", new IDataParameter[] { base.CreateParameter("@Recoid", SqlDbType.Int, Recoid), base.CreateParameter("@IsReco", SqlDbType.Bit, IsReco), base.CreateParameter("@RecoDate", SqlDbType.DateTime, RecoDate), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public void Update_CN(int AutoID, int CNNo, string CustCode, string BookCode, decimal Rate, decimal Discount, int ReturnQty, string Comment, bool IsActive, string UpdatedBy, string Flag, int TotReturnQty, int DefectQty, bool IsDeleted, DateTime CNDate)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Update_CN", new IDataParameter[] { base.CreateParameter("@AutoID", SqlDbType.Int, AutoID), base.CreateParameter("@CNNo", SqlDbType.Int, CNNo), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@ReturnQty", SqlDbType.Int, ReturnQty), base.CreateParameter("@Comment", SqlDbType.NVarChar, Comment), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@TotReturnQty", SqlDbType.Int, TotReturnQty), base.CreateParameter("@DefectQty", SqlDbType.Int, DefectQty), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@CNDate", SqlDbType.DateTime, CNDate) });
            command.Dispose();
        }

        public void Update_CN(int AutoID, int CNNo, string CustCode, string BookCode, decimal Rate, decimal Discount, int ReturnQty, string Comment, bool IsActive, string UpdatedBy, string Flag, int TotReturnQty, int DefectQty, bool IsDeleted, int strFY, DateTime CNDate, string TransportName, string LrNo, string Remark1, string Remark2, string Remark3, string Remark4, string Remark5, int GCN, int SCN)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Update_CN", new IDataParameter[] { 
                base.CreateParameter("@AutoID", SqlDbType.Int, AutoID), base.CreateParameter("@CNNo", SqlDbType.Int, CNNo), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode), base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@Rate", SqlDbType.Money, Rate), base.CreateParameter("@Discount", SqlDbType.Money, Discount), base.CreateParameter("@ReturnQty", SqlDbType.Int, ReturnQty), base.CreateParameter("@Comment", SqlDbType.NVarChar, Comment), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@TotReturnQty", SqlDbType.Int, TotReturnQty), base.CreateParameter("@DefectQty", SqlDbType.Int, DefectQty), base.CreateParameter("@IsDeleted", SqlDbType.Bit, IsDeleted), base.CreateParameter("@FY", SqlDbType.Int, strFY), base.CreateParameter("@CNDate", SqlDbType.DateTime, CNDate),
                base.CreateParameter("@TransportName", SqlDbType.NVarChar, TransportName), base.CreateParameter("@LrNo", SqlDbType.NVarChar, LrNo), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Remark3", SqlDbType.NVarChar, Remark3), base.CreateParameter("@Remark4", SqlDbType.NVarChar, Remark4), base.CreateParameter("@Remark5", SqlDbType.NVarChar, Remark5), base.CreateParameter("@GCN", SqlDbType.Int, GCN), base.CreateParameter("@SCN", SqlDbType.Int, SCN)
            });
            command.Dispose();
        }

        public DataSet Update_PettyCashPayment(string GivenFrom, decimal PaidAmount, string PaymentDate, int EmpID, string VoucherNo, bool IsPaid, string ChequeNo, string BankCode, string PaymentRemar)
        {
            return base.ExecuteDataSet("Idv_Chetana_Update_PettyCashPayment", new IDataParameter[] { base.CreateParameter("GivenFrom", SqlDbType.NVarChar, GivenFrom), base.CreateParameter("PaidAmount", SqlDbType.Money, PaidAmount), base.CreateParameter("PaymentDate", SqlDbType.NVarChar, PaymentDate), base.CreateParameter("EmpID", SqlDbType.Int, EmpID), base.CreateParameter("VoucherNo", SqlDbType.NVarChar, VoucherNo), base.CreateParameter("IsPaid", SqlDbType.Bit, IsPaid), base.CreateParameter("@ChequeNo", SqlDbType.NVarChar, ChequeNo), base.CreateParameter("@BankCode", SqlDbType.NVarChar, BankCode), base.CreateParameter("@PaymentRemar", SqlDbType.NVarChar, PaymentRemar) });
        }

        public void UpdateDCDetails(int DCDetailID, int CanceledQty, bool Cancel, bool PCancel)
        {
            base.ExecuteNonQuery("Idv_Chetana_DC_Update_DCDetails", new IDataParameter[] { base.CreateParameter("@DCDetailID", SqlDbType.Int, DCDetailID), base.CreateParameter("@CanceledQty", SqlDbType.Int, CanceledQty), base.CreateParameter("@Cancel", SqlDbType.Bit, Cancel), base.CreateParameter("@PCancel", SqlDbType.Bit, PCancel) });
        }

        public void UpdateFaculty(string factid)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_UpdateFaculty", new IDataParameter[] { base.CreateParameter("@factid", SqlDbType.NVarChar, factid) });
        }

        public DataSet updatePaymentPending(string CustId, decimal Amount, string OtherId)
        {
            return base.ExecuteDataSet("IDV_Chetana_SavePaymentPending", new IDataParameter[] { base.CreateParameter("@CustId", SqlDbType.NVarChar, CustId), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@OtherId", SqlDbType.NVarChar, OtherId) });
        }

        public DataSet updatePaymentPending(string CustId, decimal Amount, string OtherId, int strFy)
        {
            return base.ExecuteDataSet("IDV_Chetana_SavePaymentPending", new IDataParameter[] { base.CreateParameter("@CustId", SqlDbType.NVarChar, CustId), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@OtherId", SqlDbType.NVarChar, OtherId), base.CreateParameter("@Fy", SqlDbType.Int, strFy) });
        }

        public DataSet UpdatePOD(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ChetanaUpdatePOD", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@Branch", SqlDbType.NVarChar, Branch), base.CreateParameter("@Courier", SqlDbType.NVarChar, CourierCompany), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet UpdatePODNo(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_UpdatePODNo", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo), base.CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@No", SqlDbType.Int, No), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet UpdateSms(string DocumentNo)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierEmail", new IDataParameter[] { base.CreateParameter("@DocumentNo", SqlDbType.NVarChar, DocumentNo) });
        }

        public DataSet ViewCourier(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ViewCourier", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet ViewCourierDate(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ViewCourier", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@Branch", SqlDbType.NVarChar, Branch), base.CreateParameter("@Courier", SqlDbType.NVarChar, CourierCompany), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }
    }
}

