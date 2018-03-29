namespace Others
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class OtherClass : DataServiceBase
    {
        private float _SCMasterAutoId = Constants.NullFloat;
        private float _DocumentNo = Constants.NullFloat;
        private float _InvoiceNo = Constants.NullFloat;
        private int _SCD = Constants.NullInt;
        private int _POD = Constants.NullInt;
        private int _GeneralCourierID = Constants.NullInt;
        private decimal _Weight = Constants.NullDecimal;
        private DateTime _courierdate = Constants.NullDateTime;
        private bool _IsActive = Constants.NullBoolean;
        private string _CreatedBy = Constants.NullString;
        private string _UpDateBy = Constants.NullString;

        public DataSet CustEmail_LocalEntry(int CustID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustEmail_LocalEntry", new IDataParameter[] { base.CreateParameter("@CustId", SqlDbType.Int, CustID) });
        }

        public void DeletePOD(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {
            new OtherClass().DeletePOD1(SCMasterAutoId, flag, IsActive, UpDateBy, GeneralCourierID, FY);
        }

        public DataSet DeletePOD1(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_deltePOD", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy), base.CreateParameter("@GeneralCourierID", SqlDbType.Int, GeneralCourierID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public void DeleteSendcourier(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {
            new OtherClass().DeleteSendcourier1(SCMasterAutoId, IsActive, UpDateBy, FY);
        }

        public DataSet DeleteSendcourier1(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DeleteSendCourier", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Bank_Balance(string Code, int Frommonth, int FY, decimal OpenBal, string flag)
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Bank_Reco_Sum", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Code), base.CreateParameter("@frommonth", SqlDbType.Int, Frommonth), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@openingBalance", SqlDbType.Decimal, OpenBal), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public static DataSet Get_Bank_Ballance(string Code, int Frommonth, int FY, decimal OpenBal, string flag)
        {
            return new OtherClass().Get_Bank_Balance(Code, Frommonth, FY, OpenBal, flag);
        }

        public static DataSet Get_Bank_MonthwiseReconsileData(string Code, int Frommonth, int FY, int FlagBit)
        {
            return new OtherClass().Get_Bank_ReconsileDataM(Code, Frommonth, FY, FlagBit);
        }

        public static DataSet Get_Bank_ReconsileData(string Code, int Frommonth, int FY)
        {
            return new OtherClass().Get_Bank_ReconsileDataDAL(Code, Frommonth, FY);
        }

        public DataSet Get_Bank_ReconsileDataDAL(string Code, int Frommonth, int FY)
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Bank_ReconsiledData", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Code), base.CreateParameter("@frommonth", SqlDbType.Int, Frommonth), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_Bank_ReconsileDataM(string Code, int Frommonth, int FY, int FlagBit)
        {
            return base.ExecuteDataSet("idv_Chetana_Get_Bank_MonthwiseReconsiledData", new IDataParameter[] { base.CreateParameter("@BankCode", SqlDbType.NVarChar, Code), base.CreateParameter("@frommonth", SqlDbType.Int, Frommonth), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FlagBit", SqlDbType.Int, FlagBit) });
        }

        public DataSet Get_Booktypewise_DC_Rep(string Booktype, DateTime FromDate, DateTime ToDate, int SDZone, int SZone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Booktype_DC_Report", new IDataParameter[] { base.CreateParameter("@Booktype", SqlDbType.NVarChar, Booktype), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@SDZone", SqlDbType.Int, SDZone), base.CreateParameter("@SZone", SqlDbType.Int, SZone) });
        }

        public static DataSet Get_Booktypewise_DC_Rep1(string Booktype, DateTime FromDate, DateTime ToDate, int SDZone, int SZone)
        {
            return new OtherClass().Get_Booktypewise_DC_Rep(Booktype, FromDate, ToDate, SDZone, SZone);
        }

        public DataSet Get_Bookwise_DC_Rep(string BookCode, DateTime FromDate, DateTime ToDate, int SDZone, int SZone)
        {
            return base.ExecuteDataSet("Idv_Chetana_Bookwise_DC_Report", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@SDZone", SqlDbType.Int, SDZone), base.CreateParameter("@SZone", SqlDbType.Int, SZone) });
        }

        public static DataSet Get_Bookwise_DC_Rep1(string BookCode, DateTime FromDate, DateTime ToDate, int SDZone, int SZone)
        {
            return new OtherClass().Get_Bookwise_DC_Rep(BookCode, FromDate, ToDate, SDZone, SZone);
        }

        public static DataSet Get_CourierDetails(float DocNo, string flag, int FY)
        {
            return new OtherClass().Get_CourierDetails1(DocNo, flag, FY);
        }

        public DataSet Get_CourierDetails1(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_CourierDetails", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet Get_CourierDetailsCheck(string DocNo, string flag, int FY)
        {
            return new OtherClass().Get_CourierDetailsCheck1(DocNo, flag, FY);
        }

        public DataSet Get_CourierDetailsCheck1(string DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_CourierDetails", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet Get_CourierDetailsCheckSave(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
            return new OtherClass().Get_CourierDetailsCheckSave1(DocNo, flag, CourierID, BranchID, FY);
        }

        public DataSet Get_CourierDetailsCheckSave1(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_CourierDetailsSave", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@CourierID", SqlDbType.Int, CourierID), base.CreateParameter("@BranchID", SqlDbType.Int, BranchID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet Get_CourierDetailsGeneral(string DocNo, string flag, int FY)
        {
            return new OtherClass().Get_CourierDetailsGeneral1(DocNo, flag, FY);
        }

        public DataSet Get_CourierDetailsGeneral1(string DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierGeneral", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_CustListDAL(string Flag, string CustCategoryID, string SuperDuperZoneID, string ZoneID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerMaster_Details_flag", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@CustCateID", SqlDbType.NVarChar, CustCategoryID), base.CreateParameter("@ID", SqlDbType.NVarChar, SuperDuperZoneID), base.CreateParameter("@ZoneID", SqlDbType.NVarChar, ZoneID) });
        }

        public static DataTable Get_CustomerData_For_Export(string Flag, string CustCategoryID, string SuperDuperZoneID, string ZoneID)
        {
            return new OtherClass().Get_CustListDAL(Flag, CustCategoryID, SuperDuperZoneID, ZoneID).Tables[0];
        }

        public static DataSet Get_CustomerDiscountBy_BookType(string Custcode, int FY, string flag1, string flag2)
        {
            return new OtherClass().Get_CustomerDiscountBy_BookType1(Custcode, FY, flag1, flag2);
        }

        public DataSet Get_CustomerDiscountBy_BookType1(string Custcode, int FY, string flag1, string flag2)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustomerDiscountBy_BookType", new IDataParameter[] { base.CreateParameter("@CustCode", SqlDbType.NVarChar, Custcode), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@Flag2", SqlDbType.NVarChar, flag2) });
        }

        public static DataSet Get_IsEditable(string Case, int DocNo, int FY)
        {
            return new OtherClass().Idv_Chetana_GetIsEditable(Case, DocNo, FY);
        }

        public static DataSet Get_Order_Compare(int SDZone, int Superzone, int zone, int CustID, int FY, string month)
        {
            return new OtherClass().Get_Order_Compare1(SDZone, Superzone, zone, CustID, FY, month);
        }

        public DataSet Get_Order_Compare1(int SDZone, int Superzone, int Zone, int CustID, int FY, string month)
        {
            return base.ExecuteDataSet("idv_chetana_REP_Order_Comparision", new IDataParameter[] { base.CreateParameter("@SDZone", SqlDbType.Int, SDZone), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Months", SqlDbType.NVarChar, month) });
        }

        public static DataSet Get_OrderValuation_SummaryExcel(DateTime FromDate, DateTime ToDate, int SDZone, int SZone, int Zone, int FY)
        {
            return new OtherClass().Get_OrderValuation_SummaryExcelD(FromDate, ToDate, SDZone, SZone, Zone, FY);
        }

        public DataSet Get_OrderValuation_SummaryExcelD(DateTime FromDate, DateTime ToDate, int SDZone, int SZone, int Zone, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_Dasboard_ForOrderValuation_SummaryExcel", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@SDZone", SqlDbType.Int, SDZone), base.CreateParameter("@SZone", SqlDbType.Int, SZone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet GetCourier(string flag)
        {
            return new OtherClass().GetCourier1(flag);
        }

        public DataSet GetCourier1(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CourierData", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public static DataSet GetCourierBranch(int DocID, string flag)
        {
            return new OtherClass().GetCourierBranch1(DocID, flag);
        }

        public DataSet GetCourierBranch1(int DocID, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CourierData", new IDataParameter[] { base.CreateParameter("@DocID", SqlDbType.Float, DocID), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public static DataSet GetCourierValidation(string Group, string code)
        {
            return new OtherClass().GetCourierValidation1(Group, code);
        }

        public DataSet GetCourierValidation1(string Group, string code)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_If_Exists", new IDataParameter[] { base.CreateParameter("@Group", SqlDbType.NVarChar, Group), base.CreateParameter("@code", SqlDbType.NVarChar, code) });
        }

        public static DataSet GetFY(int strFY)
        {
            return new OtherClass().GetFY1(strFY);
        }

        public DataSet GetFY1(int strFY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_FY", new IDataParameter[] { base.CreateParameter("@FY", SqlDbType.Int, strFY) });
        }

        public static DataSet GetInitialData(string Data1, string Data2, string Data3, string Data4, string Data5, string Case, int FY)
        {
            return new OtherClass().Idv_Chetana_GetInitialData_Fun(Data1, Data2, Data3, Data4, Data5, Case, FY);
        }

        public DataSet Idv_Chetana_Customer_Ledger_Report(string BookCode, DateTime FromDate, DateTime ToDate, int FY)
        {
            return base.ExecuteDataSet("IDV_Chetana_REP_STOCKLEDGER", new IDataParameter[] { base.CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode), base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_Get_AutoId1()
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_AutoId", new IDataParameter[0]);
        }

        public static DataSet Idv_Chetana_Get_Global_Commission(int SDZoneId, int SuperZone, int Zone, int FY)
        {
            return new OtherClass().Idv_Chetana_Get_Global_Commission_M(SDZoneId, SuperZone, Zone, FY);
        }

        public DataSet Idv_Chetana_Get_Global_Commission_M(int SDZoneId, int SuperZone, int Zone, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Global_Comm", new IDataParameter[] {
                base.CreateParameter("@SDZoneId", SqlDbType.Int, SDZoneId),
                base.CreateParameter("@Superzone", SqlDbType.Int, SuperZone),
                base.CreateParameter("@Zone", SqlDbType.Int, Zone),
                base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet Idv_Chetana_GetAutoId()
        {
            return new OtherClass().Idv_Chetana_Get_AutoId1();
        }

        public DataSet Idv_Chetana_GetInitialData_Fun(string Data1, string Data2, string Data3, string Data4, string Data5, string Case, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetInitialData", new IDataParameter[] { base.CreateParameter("@Data1", SqlDbType.NVarChar, Data1), base.CreateParameter("@Data2", SqlDbType.NVarChar, Data2), base.CreateParameter("@Data3", SqlDbType.NVarChar, Data3), base.CreateParameter("@Data4", SqlDbType.NVarChar, Data4), base.CreateParameter("@Data5", SqlDbType.NVarChar, Data5), base.CreateParameter("@Case", SqlDbType.NVarChar, Case), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Idv_Chetana_GetIsEditable(string Case, int DocNo, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetIsEditableBit", new IDataParameter[] { base.CreateParameter("@Case", SqlDbType.NVarChar, Case), base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet Idv_Chetana_Rep_Booktypewise_A_Report(string BookTypeCode, DateTime FDate, DateTime TDate, int SDZone, int SZone, int Zone, int FY)
        {
            return new OtherClass().Idv_Chetana_Rep_Booktypewise_Amt_Report(BookTypeCode, FDate, TDate, SDZone, SZone, Zone, FY);
        }

        public DataSet Idv_Chetana_Rep_Booktypewise_Amt_Report(string BookTypeCode, DateTime FDate, DateTime TDate, int SDZone, int SZone, int Zone, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_REP_Booktypewise_Amtwise_summary", new IDataParameter[] { base.CreateParameter("@BkTypeCode", SqlDbType.NVarChar, BookTypeCode), base.CreateParameter("@FromDt", SqlDbType.DateTime, FDate), base.CreateParameter("@ToDt", SqlDbType.DateTime, TDate), base.CreateParameter("@SDZone", SqlDbType.Int, SDZone), base.CreateParameter("@SuperZone", SqlDbType.Int, SZone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet Idv_Chetana_Report_Comm(int SuperZone, int Zone, string FromDate, string ToDate, int FY)
        {
            return new OtherClass().Idv_Chetana_Report_Comm_F(0, FromDate, ToDate, FY, SuperZone, Zone, "");
        }

        public DataSet Idv_Chetana_Report_Comm_F(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_Commission_1", new IDataParameter[] { base.CreateParameter("@CustID", SqlDbType.Int, CustID), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Superzone", SqlDbType.Int, Superzone), base.CreateParameter("@Zone", SqlDbType.Int, Zone), base.CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode) });
        }

        public DataSet Idv_Chetana_Report_Receipt_BookDatewise(DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Report_ReceiptBookDatewise", new IDataParameter[] { base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate), base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate) });
        }

        public static DataSet Idv_Chetana_Report_ReceiptDatewise(DateTime FromDate, DateTime ToDate)
        {
            return new OtherClass().Idv_Chetana_Report_Receipt_BookDatewise(FromDate, ToDate);
        }

        public void Idv_chetana_Save_AuditCutOff(string FinY, int FY, DateTime CutoffDate, string createduser)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_chetana_Save_AuditCutOffDate", new IDataParameter[] { base.CreateParameter("@FinY", SqlDbType.NVarChar, FinY), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@CutoffDate", SqlDbType.DateTime, CutoffDate), base.CreateParameter("@CreatedBy", SqlDbType.DateTime, CutoffDate) });
            command.Dispose();
        }

        public static DataSet Idv_Chetana_Save_Update_Commission(int SDZone, int SuperZone, int Zone, int FY, string Xdoc, int flag)
        {
            return new OtherClass().Idv_Chetana_Save_Update_Commission_1(SDZone, SuperZone, Zone, FY, Xdoc, flag);
        }

        public DataSet Idv_Chetana_Save_Update_Commission_1(int SDZone, int SuperZone, int Zone, int FY, string Xdoc, int flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Save_Update_Comm", new IDataParameter[] {
                base.CreateParameter("@SDZone", SqlDbType.Int, SDZone),
                base.CreateParameter("@Superzone", SqlDbType.Int, SuperZone),
                base.CreateParameter("@Zone", SqlDbType.Int, Zone),
                base.CreateParameter("@FY", SqlDbType.Int, FY),
                base.CreateParameter("@xml", SqlDbType.Xml, Xdoc),
                base.CreateParameter("@flag", SqlDbType.Int, flag) });
        }

        public static DataSet Idv_Chetana_Stock_Ledger_Report(string CustCode, DateTime FromDate, DateTime ToDate, int FY)
        {
            return new OtherClass().Idv_Chetana_Customer_Ledger_Report(CustCode, FromDate, ToDate, FY);
        }

        public void Save(string DocNo, string flag, int FY, int CourierID, int BranchID, string BranchAdd, string Department, string Address, string Remark1, string CreatedBy, string Weight, DateTime Courierdate, out int _SCD)
        {
            new OtherClass().SaveCourierDetails(DocNo, flag, FY, CourierID, BranchID, BranchAdd, Department, Address, Remark1, CreatedBy, Weight, Courierdate, out _SCD);
        }

        public void SaveAudit(string FinY, int FY, DateTime CutoffDate, string createduser)
        {
            new OtherClass().Idv_chetana_Save_AuditCutOff(FinY, FY, CutoffDate, createduser);
        }

        public void Savecourier(string DocNo, string flag, int FY, int CourierID, int BranchID, string Address, string CreatedBy, out int _SCD)
        {
            new OtherClass().SaveCourierDetail(DocNo, flag, FY, CourierID, BranchID, Address, CreatedBy, out _SCD);
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

        public void SaveDispatchEmailDetails(int DocNo, string flag, int FY, string CreatedBy, out int _SCD)
        {
            new OtherClass().SaveDispatchEmailDetails1(DocNo, flag, FY, CreatedBy, out _SCD);
        }

        public void SaveDispatchEmailDetails1(int DocNo, string flag, int FY, string CreatedBy, out int SCD)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DispatchEmail", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@SCD", SqlDbType.Int, ParameterDirection.Output) });
            SCD = Convert.ToInt32(command.Parameters["@SCD"].Value);
            command.Dispose();
        }

        public static DataSet SendCourierEmail(float DocNo, string flag1, string flag2, int FY)
        {
            return new OtherClass().SendCourierEmail1(DocNo, flag1, flag2, FY);
        }

        public static DataSet SendCourierEmail(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return new OtherClass().SendCourierEmail1(SCMasterAutoId, DocumentNo, InvoiceNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }

        public DataSet SendCourierEmail1(float DocNo, string flag1, string flag2, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierEmail", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet SendCourierEmail1(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierEmail", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo), base.CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromID", SqlDbType.NVarChar, FromID), base.CreateParameter("@PWD", SqlDbType.NVarChar, PWD), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public static DataSet SendCourierPrint(float DocNo, string flag, int FY)
        {
            return new OtherClass().SendCourierPrint1(DocNo, flag, FY);
        }

        public DataSet SendCourierPrint1(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierPrint", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet SendCourierPrintGeneral(float DocNo, string flag, int FY)
        {
            return new OtherClass().SendCourierPrintGeneral1(DocNo, flag, FY);
        }

        public DataSet SendCourierPrintGeneral1(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierPrint", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet SendDispatchEmail(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return new OtherClass().SendDispatchEmail1(SCMasterAutoId, DocumentNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }

        public DataSet SendDispatchEmail1(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendDispatchEmail", new IDataParameter[] { base.CreateParameter("@DispatchMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromID", SqlDbType.NVarChar, FromID), base.CreateParameter("@PWD", SqlDbType.NVarChar, PWD), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public static DataSet UpdatePOD(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return new OtherClass().UpdatePOD1(DocNo, FromDate, ToDate, Branch, CourierCompany, flag, FY);
        }

        public DataSet UpdatePOD1(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ChetanaUpdatePOD", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@Branch", SqlDbType.NVarChar, Branch), base.CreateParameter("@Courier", SqlDbType.NVarChar, CourierCompany), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public void UpdatePODNo(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {
            new OtherClass().UpdatePODNo1(SCMasterAutoId, DocumentNo, InvoiceNo, flag, No, FY);
        }

        public DataSet UpdatePODNo1(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_UpdatePODNo", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo), base.CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@No", SqlDbType.Int, No), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet ViewCourier(float DocNo, string flag, int FY)
        {
            return new OtherClass().ViewCourier1(DocNo, flag, FY);
        }

        public DataSet ViewCourier1(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ViewCourier", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet ViewCourierDate(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return new OtherClass().ViewCourierDate1(DocNo, FromDate, ToDate, Branch, CourierCompany, flag, FY);
        }

        public DataSet ViewCourierDate1(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ViewCourier", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@Branch", SqlDbType.NVarChar, Branch), base.CreateParameter("@Courier", SqlDbType.NVarChar, CourierCompany), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DateTime Courierdate
        {
            get
            {
                return this._courierdate;
            }
            set
            {
                this._courierdate = value;
            }
        }

        public decimal Weight
        {
            get
            {
                return this._Weight;
            }
            set
            {
                this._Weight = value;
            }
        }

        public int GeneralCourierID
        {
            get
            {
                return this._GeneralCourierID;
            }
            set
            {
                this._GeneralCourierID = value;
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

        public int POD
        {
            get
            {
                return this._GeneralCourierID;
            }
            set
            {
                this._GeneralCourierID = value;
            }
        }

        public int SCD
        {
            get
            {
                return this._SCD;
            }
            set
            {
                this._SCD = value;
            }
        }

        public float SCMasterAutoId
        {
            get
            {
                return this._SCMasterAutoId;
            }
            set
            {
                this._SCMasterAutoId = value;
            }
        }

        public float DocumentNo
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

        public float InvoiceNo
        {
            get
            {
                return this._InvoiceNo;
            }
            set
            {
                this._InvoiceNo = value;
            }
        }

        public string UpDateBy
        {
            get
            {
                return this._UpDateBy;
            }
            set
            {
                this._UpDateBy = value;
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
    }
}

