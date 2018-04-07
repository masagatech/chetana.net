namespace Idv.Chetana.DAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class AdminDataService_Go : DataServiceBase
    {
        public AdminDataService_Go()
        {
        }

        public AdminDataService_Go(IDbTransaction txn) : base(txn)
        {
        }

        public DataSet CustEmail_LocalEntry(int CustID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CustEmail_LocalEntry", new IDataParameter[] { base.CreateParameter("@CustId", SqlDbType.Int, CustID) });
        }

        public void DeleteCN(int GCNID)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_G_DeleteCN", new IDataParameter[] { base.CreateParameter("@GCN_ID", SqlDbType.Int, GCNID) });
        }

        public void DeleteModule(string Id, string Flag, string Flag1)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_G_Delete_Entries", new IDataParameter[] { base.CreateParameter("@Id", SqlDbType.NVarChar, Id), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag), base.CreateParameter("@Flag1", SqlDbType.NVarChar, Flag1) });
            command.Dispose();
        }

        public DataSet Get_Mark_Review_DetailsBy_Zone(string flag, string show, string SDZ, string SZ, string ZoneID, int fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Mark_Review_DetailsBy_Zone", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@show", SqlDbType.NVarChar, show), base.CreateParameter("@SuperDuperZoneID", SqlDbType.NVarChar, SDZ), base.CreateParameter("@SuperZoneID", SqlDbType.NVarChar, SZ), base.CreateParameter("@ZoneID", SqlDbType.NVarChar, ZoneID), base.CreateParameter("@Fy", SqlDbType.Int, fy) });
        }

        public DataSet Get_Mark_ReviewDetails(string flag, string ZoneID)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Mark_ReviewDetails", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@ZoneID", SqlDbType.NVarChar, ZoneID) });
        }

        public DataSet GetCNOnDocNo(int fy, int DocNo, string flag)
        {
            return base.ExecuteDataSet("Idv_chetana_G_Get_GetCN", new IDataParameter[] { base.CreateParameter("@Fy", SqlDbType.Int, fy), base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet GetDispatchEmail(int fy, int DocNo, string flag)
        {
            return base.ExecuteDataSet("Idv_chetana_DispatchEmail", new IDataParameter[] { base.CreateParameter("@Fy", SqlDbType.Int, fy), base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet getDriver(string flag, int id, string flag1)
        {
            return base.ExecuteDataSet("idv_chetana_Get_G_Driver", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, flag), base.CreateParameter("@ID", SqlDbType.Int, id), base.CreateParameter("@Flag1", SqlDbType.NVarChar, flag1) });
        }

        public DataSet getInfoNoForGodown(int fy, int DcNo, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_GetDocInfo", new IDataParameter[] { base.CreateParameter("@Fy", SqlDbType.Int, fy), base.CreateParameter("@DcNo", SqlDbType.Int, DcNo), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet GetNameByCode(string Code, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_Get_Codes", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet GetpassOnDCNo(int fy, int DC, string flag)
        {
            return base.ExecuteDataSet("Idv_chetana_G_Get_GetPassDCNo", new IDataParameter[] { base.CreateParameter("@Fy", SqlDbType.Int, fy), base.CreateParameter("@Dc", SqlDbType.Int, DC), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet GetpassOnDocNo(int fy, int DocNo, string flag)
        {
            return base.ExecuteDataSet("Idv_chetana_G_Get_GetPass", new IDataParameter[] { base.CreateParameter("@Fy", SqlDbType.Int, fy), base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet getVehicle(string flag, int id, string flag1)
        {
            return base.ExecuteDataSet("idv_chetana_Get_G_Vehicle", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, flag), base.CreateParameter("@ID", SqlDbType.Int, id), base.CreateParameter("@Flag1", SqlDbType.NVarChar, flag1) });
        }

        public DataSet Local_Date_Report(string mode, DateTime fromdate, DateTime todate, string delivery, string fromdetails, int fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_Report_LocCustDel", new IDataParameter[] { base.CreateParameter("@Mode", SqlDbType.NVarChar, mode), base.CreateParameter("@Fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@Todate", SqlDbType.DateTime, todate), base.CreateParameter("@Delivery", SqlDbType.NVarChar, delivery), base.CreateParameter("@FrmDeatails", SqlDbType.NVarChar, fromdetails), base.CreateParameter("@Fy", SqlDbType.Int, fy) });
        }

        public DataSet Local_GetPass_DCNo_BillNo_Validation(decimal Dc_No, string Bill_No, int fy, string flag)
        {
            return base.ExecuteDataSet("Local_GetPass_DCNo_BillNo_Validation", new IDataParameter[] { base.CreateParameter("@DC_No", SqlDbType.Decimal, Dc_No), base.CreateParameter("@Bill_No", SqlDbType.NVarChar, Bill_No), base.CreateParameter("@Fy", SqlDbType.Int, fy), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Local_Report(int Doc_ID, string Local_Out, int Fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_Pass_Main_Local_Report", new IDataParameter[] { base.CreateParameter("@Doc_ID", SqlDbType.Int, Doc_ID), base.CreateParameter("@Local_Out", SqlDbType.NVarChar, Local_Out), base.CreateParameter("@Fy", SqlDbType.Int, Fy) });
        }

        public DataSet LocalOut_PassReport(string mode, string flag, int fdcno, int tdcno, DateTime fromdate, DateTime todate, int fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_LocalOut_PassReport", new IDataParameter[] { base.CreateParameter("@Mode", SqlDbType.NVarChar, mode), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@fdocno", SqlDbType.Int, fdcno), base.CreateParameter("@tdocno", SqlDbType.Int, tdcno), base.CreateParameter("@fdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@tdate", SqlDbType.DateTime, todate), base.CreateParameter("@Fy", SqlDbType.Int, fy) });
        }

        public DataSet Out_Report(int Doc_ID, string Local_Out, int Fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_Pass_Main_Out_Report", new IDataParameter[] { base.CreateParameter("@Doc_ID", SqlDbType.Int, Doc_ID), base.CreateParameter("@Local_Out", SqlDbType.NVarChar, Local_Out), base.CreateParameter("@Fy", SqlDbType.Int, Fy) });
        }

        public DataSet Out_Transporter_Report(string flag, DateTime fromdate, DateTime todate, string Code, int fy, string flag1)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_Report_Outside_Cust", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@Fromdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@Todate", SqlDbType.DateTime, todate), base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@Fy", SqlDbType.Int, fy), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1) });
        }

        public DataSet Packing_Report(string mode, DateTime fromdate, DateTime todate, int supzone, int zone, int fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_Packing_Report", new IDataParameter[] { base.CreateParameter("@Mode", SqlDbType.NVarChar, mode), base.CreateParameter("@fdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@tdate", SqlDbType.DateTime, todate), base.CreateParameter("@supzone", SqlDbType.Int, supzone), base.CreateParameter("@zone", SqlDbType.Int, zone), base.CreateParameter("@Fy", SqlDbType.Int, fy) });
        }

        public DataSet Railway_Report(string flag, int fdcno, int tdcno, DateTime fromdate, DateTime todate, int fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_Railway_Report", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@fdcno", SqlDbType.Int, fdcno), base.CreateParameter("@tdcno", SqlDbType.Int, tdcno), base.CreateParameter("@fdate", SqlDbType.DateTime, fromdate), base.CreateParameter("@tdate", SqlDbType.DateTime, todate), base.CreateParameter("@Fy", SqlDbType.Int, fy) });
        }

        public DataSet Report_Outside_Credit(string flag, DateTime fromdate, DateTime todate, int GCNfNo, int GCNtNo, int fy)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_Report_Credit_Note", new IDataParameter[] { base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FromDate", SqlDbType.DateTime, fromdate), base.CreateParameter("@ToDate", SqlDbType.DateTime, todate), base.CreateParameter("@GCNfNo", SqlDbType.Int, GCNfNo), base.CreateParameter("@GCNtNo", SqlDbType.Int, GCNtNo), base.CreateParameter("@Fy", SqlDbType.Int, fy) });
        }

        public DataSet Report_PackingDetails(DateTime fromDate, DateTime toDate, int fy, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_G_Report_PackingDetails", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, toDate), base.CreateParameter("@fy", SqlDbType.Int, fy), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public DataSet Report_TeamProductvity(DateTime fromDate, DateTime toDate, int fy, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_TeamProductvity", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, toDate), base.CreateParameter("@fy", SqlDbType.Int, fy), base.CreateParameter("@flag", SqlDbType.NVarChar, flag) });
        }

        public void Save_Chetana_Market_Review(int Market_ID, string Super_Duper_Zone, string Super_Zone, string Zone, string Market_View, string Competitor_View, int Fyfrom, DateTime Created_On, string Created_By, DateTime Updated_On, string Updated_By, bool Is_Deleted)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_Chetana_Market_Review", new IDataParameter[] { base.CreateParameter("@Market_ID", SqlDbType.Int, Market_ID), base.CreateParameter("@Super_Duper_Zone", SqlDbType.NVarChar, Super_Duper_Zone), base.CreateParameter("@Super_Zone", SqlDbType.NVarChar, Super_Zone), base.CreateParameter("@Zone", SqlDbType.NVarChar, Zone), base.CreateParameter("@Market_View", SqlDbType.NVarChar, Market_View), base.CreateParameter("@Competitor_View", SqlDbType.NVarChar, Competitor_View), base.CreateParameter("@Fyfrom", SqlDbType.Int, Fyfrom), base.CreateParameter("@Created_On", SqlDbType.DateTime, Created_On), base.CreateParameter("@Created_By", SqlDbType.NVarChar, Created_By), base.CreateParameter("@Updated_On", SqlDbType.DateTime, Updated_On), base.CreateParameter("@Updated_By", SqlDbType.NVarChar, Updated_By), base.CreateParameter("@Is_Deleted", SqlDbType.Bit, Is_Deleted) });
            command.Dispose();
        }

        public void SaveIdv_Chetana_Driver(int DR_ID, string NAME, string ADD1, string ADD2, string ADD3, int AREACODE, string CITY, string TEL1, string TEL2, string MOBILE, string PINCODE, int VEH_ID, bool IsActive, string CreatedBy, string UpdatedBy, string Licence, DateTime LicenceExpDate)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "idv_chetana_Save_G_Driver", new IDataParameter[] { 
                base.CreateParameter("@DR_ID", SqlDbType.Int, DR_ID), base.CreateParameter("@NAME", SqlDbType.NVarChar, NAME), base.CreateParameter("@ADD1", SqlDbType.NVarChar, ADD1), base.CreateParameter("@ADD2", SqlDbType.NVarChar, ADD2), base.CreateParameter("@ADD3", SqlDbType.NVarChar, ADD3), base.CreateParameter("@AREACODE", SqlDbType.Int, AREACODE), base.CreateParameter("@CITY", SqlDbType.NVarChar, CITY), base.CreateParameter("@TEL1", SqlDbType.NVarChar, TEL1), base.CreateParameter("@TEL2", SqlDbType.NVarChar, TEL2), base.CreateParameter("@MOBILE", SqlDbType.NVarChar, MOBILE), base.CreateParameter("@PINCODE", SqlDbType.NVarChar, PINCODE), base.CreateParameter("@VEH_ID", SqlDbType.Int, VEH_ID), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy), base.CreateParameter("@Licence", SqlDbType.NVarChar, Licence),
                base.CreateParameter("@LicenceExpDate", SqlDbType.DateTime, LicenceExpDate)
            });
            command.Dispose();
        }

        public int SaveIdv_Chetana_G_GetPass_Main(int Doc_ID, string Local_Out, DateTime Doc_Date, int Veh_ID, string Driver_Name, int Driver_ID, string Area, string Deliveruy_Boy, int Deliveruy_Boy_ID, int Cust_ID, int Transporter_ID, string No_Bundles, decimal Value_Goods, string Sent_By, string Bill_Nos, string LR_No, string Pay_Paid, decimal Amount, DateTime LR_Date, decimal DC_No, int DR_ID, int DB_ID, bool Delivery, string Created_By, string Updated_By, int FY, string Remark1, string Remark2, out int Doc_No_New)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_G_Save_GetPass_Main", new IDataParameter[] { 
                base.CreateParameter("@Doc_ID", SqlDbType.Int, Doc_ID), base.CreateParameter("@Local_Out", SqlDbType.NVarChar, Local_Out), base.CreateParameter("@Doc_Date", SqlDbType.DateTime, Doc_Date), base.CreateParameter("@Veh_ID", SqlDbType.Int, Veh_ID), base.CreateParameter("@Driver_Name", SqlDbType.NVarChar, Driver_Name), base.CreateParameter("@Driver_ID", SqlDbType.Int, Driver_ID), base.CreateParameter("@Area", SqlDbType.NVarChar, Area), base.CreateParameter("@Deliveruy_Boy", SqlDbType.NVarChar, Deliveruy_Boy), base.CreateParameter("@Deliveruy_Boy_ID", SqlDbType.Int, Deliveruy_Boy_ID), base.CreateParameter("@Cust_ID", SqlDbType.Int, Cust_ID), base.CreateParameter("@Transporter_ID", SqlDbType.Int, Transporter_ID), base.CreateParameter("@No_Bundles", SqlDbType.NVarChar, No_Bundles), base.CreateParameter("@Value_Goods", SqlDbType.Money, Value_Goods), base.CreateParameter("@Sent_By", SqlDbType.NVarChar, Sent_By), base.CreateParameter("@Bill_Nos", SqlDbType.NVarChar, Bill_Nos), base.CreateParameter("@LR_No", SqlDbType.NVarChar, LR_No),
                base.CreateParameter("@Pay_Paid", SqlDbType.NVarChar, Pay_Paid), base.CreateParameter("@Amount", SqlDbType.Money, Amount), base.CreateParameter("@LR_Date", SqlDbType.DateTime, LR_Date), base.CreateParameter("@DC_No", SqlDbType.Decimal, DC_No), base.CreateParameter("@DR_ID", SqlDbType.Int, DR_ID), base.CreateParameter("@DB_ID", SqlDbType.Int, DB_ID), base.CreateParameter("@Delivery", SqlDbType.Bit, Delivery), base.CreateParameter("@Created_By", SqlDbType.NVarChar, Created_By), base.CreateParameter("@Updated_By", SqlDbType.NVarChar, Updated_By), base.CreateParameter("@Fy ", SqlDbType.Int, FY), base.CreateParameter("@Doc_No", SqlDbType.Int, ParameterDirection.Output), base.CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1), base.CreateParameter("@Remark2", SqlDbType.NVarChar, Remark2), base.CreateParameter("@Doc_No_New", SqlDbType.Int, ParameterDirection.Output)
            });
            int num = Convert.ToInt32(command.Parameters["@Doc_No"].Value);
            Doc_No_New = Convert.ToInt32(command.Parameters["@Doc_No_New"].Value);
            command.Dispose();
            return num;
        }

        public void SaveIdv_Chetana_G_GetPass_Sub(int DOC_SUB_ID, int DOC_ID, string BILL_NO, string SCHL_NAME, string SCHL_AREA, string NO_OF_BUNDLES, bool DELIVERY, decimal DC_NO, string Created_By, string Updated_By, int Cust_ID)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_G_Save_GetPass_Sub", new IDataParameter[] { base.CreateParameter("@DOC_SUB_ID", SqlDbType.Int, DOC_SUB_ID), base.CreateParameter("@DOC_ID", SqlDbType.Int, DOC_ID), base.CreateParameter("@BILL_NO", SqlDbType.NVarChar, BILL_NO), base.CreateParameter("@SCHL_NAME", SqlDbType.NVarChar, SCHL_NAME), base.CreateParameter("@SCHL_AREA", SqlDbType.NVarChar, SCHL_AREA), base.CreateParameter("@NO_OF_BUNDLES", SqlDbType.NVarChar, NO_OF_BUNDLES), base.CreateParameter("@DELIVERY", SqlDbType.Bit, DELIVERY), base.CreateParameter("@DC_NO", SqlDbType.Decimal, DC_NO), base.CreateParameter("@Created_By", SqlDbType.NVarChar, Created_By), base.CreateParameter("@Updated_By", SqlDbType.NVarChar, Updated_By), base.CreateParameter("@Cust_Id", SqlDbType.Int, Cust_ID) });
            command.Dispose();
        }

        public void SaveIdv_Chetana_G_GodownCN(int GCN_ID, DateTime GCN_DATE, string GCN_NO, string SALES_REPRESENTATIVE, int SCHL_ID, string SCHL_NAME, string AREA, string SALESMAN_CN_NO, int Fy, string Created_By, string Updated_By, string narration)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_G_GodownCN", new IDataParameter[] { base.CreateParameter("@GCN_ID", SqlDbType.Int, GCN_ID), base.CreateParameter("@GCN_DATE", SqlDbType.DateTime, GCN_DATE), base.CreateParameter("@GCN_NO", SqlDbType.NVarChar, GCN_NO), base.CreateParameter("@SALES_REPRESENTATIVE", SqlDbType.NVarChar, SALES_REPRESENTATIVE), base.CreateParameter("@SCHL_ID", SqlDbType.Int, SCHL_ID), base.CreateParameter("@SCHL_NAME", SqlDbType.NVarChar, SCHL_NAME), base.CreateParameter("@AREA", SqlDbType.NVarChar, AREA), base.CreateParameter("@SALESMAN_CN_NO", SqlDbType.NVarChar, SALESMAN_CN_NO), base.CreateParameter("@Narration", SqlDbType.NVarChar, narration), base.CreateParameter("@Fy", SqlDbType.Int, Fy), base.CreateParameter("@Created_By", SqlDbType.NVarChar, Created_By), base.CreateParameter("@Updated_By", SqlDbType.NVarChar, Updated_By) });
            command.Dispose();
        }

        public void SaveIdv_Chetana_Vehicle(int Veh_id, string Veh_desc, string Veh_no, string veh_type, string I_M, bool IsActive, string CreatedBy, string UpdatedBy)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "idv_chetana_Save_G_Vehicle", new IDataParameter[] { base.CreateParameter("@Veh_id", SqlDbType.Int, Veh_id), base.CreateParameter("@Veh_desc", SqlDbType.NVarChar, Veh_desc), base.CreateParameter("@Veh_no", SqlDbType.NVarChar, Veh_no), base.CreateParameter("@veh_type", SqlDbType.NVarChar, veh_type), base.CreateParameter("@I_M", SqlDbType.NVarChar, I_M), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpdatedBy) });
            command.Dispose();
        }
    }
}

