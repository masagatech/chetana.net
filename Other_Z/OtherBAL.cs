using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Idv.Chetana.DAL;
using System.Data;
using System.Data.SqlClient;

namespace Other_Z
{
    public class OtherBAL : DataServiceBase
    {
        #region Idv_Chetana_Token_Register Property

        public class Token_Register_Property
        {
            public int TokenNo { get; set; }
            public string KYC_No { get; set; }
            public string CustCode { get; set; }
            public DateTime Ord_Rec_Date { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string ReceivedVia { get; set; }
            public string HandOver { get; set; }
            public string Remark { get; set; }
            public string createdBy { get; set; }
            public int IsActive { get; set; }
            public int FY { get; set; }
            public string R1 { get; set; }
            public string R2 { get; set; }
            public string R3 { get; set; }
        }
        #endregion

        #region Idv_Chetana_Token_Register Save Method
        public void Idv_Chetana_Save_Token_Register(Token_Register_Property model, out int TokenId)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_Token_Register",
                CreateParameter("@TokenNo", SqlDbType.Int, model.TokenNo),
                CreateParameter("@KYC_No", SqlDbType.Int, Convert.ToInt32(model.KYC_No)),
                CreateParameter("@CustCode", SqlDbType.NVarChar, model.CustCode),
                CreateParameter("@Ord_Rec_Date", SqlDbType.DateTime, model.Ord_Rec_Date),
                CreateParameter("@Delevery_Date", SqlDbType.DateTime, model.DeliveryDate),
                CreateParameter("@ReceivedVia", SqlDbType.NVarChar, model.ReceivedVia),
                CreateParameter("@HandOver", SqlDbType.NVarChar, model.HandOver),
                CreateParameter("@Remark", SqlDbType.NVarChar, model.Remark),
                CreateParameter("@Uid", SqlDbType.NVarChar, model.createdBy),
                CreateParameter("@isActive", SqlDbType.Int, model.IsActive),
                CreateParameter("@FY", SqlDbType.Int, model.FY),
                CreateParameter("@R1", SqlDbType.NVarChar, model.R1),
                CreateParameter("@R2", SqlDbType.VarChar, model.R2),
                CreateParameter("@R3", SqlDbType.NVarChar, model.R3),
                CreateParameter("@TokenId", SqlDbType.Int, 0, ParameterDirection.Output));
            TokenId = Convert.ToInt32(cmd.Parameters["@TokenId"].Value);


        }
        #endregion

        #region Idv_Chetana_Get_Token_Register
        public DataSet Idv_Chetana_Get_Token_Register(string id, string R1, string R2, string R3, int FY, int KycNo, string PrintId, DateTime FromDate, DateTime ToDate)
        {
            return ExecuteDataSet("Idv_Chetana_Get_Token_Register",
                 CreateParameter("@Id", SqlDbType.NVarChar, id),
                 CreateParameter("@R1", SqlDbType.NVarChar, R1),
                 CreateParameter("@R2", SqlDbType.NVarChar, R2),
                 CreateParameter("@R3", SqlDbType.NVarChar, R3),
                 CreateParameter("@FY", SqlDbType.Int, FY),
                 CreateParameter("@KycNo", SqlDbType.Int, KycNo),
                 CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                 CreateParameter("@FromTo", SqlDbType.DateTime, ToDate),
                 CreateParameter("@PrintID", SqlDbType.VarChar, PrintId));
        }
        #endregion

        #region Kyc Property
        public class KycForm_Property
        {
            public int KycNo { get; set; }
            public DateTime OrderDate { get; set; }
            public int OrderNo { get; set; }
            public string CustCode { get; set; }
            public string CustName { get; set; }
            public string CustAdd { get; set; }
            public string Area { get; set; }
            public string City { get; set; }
            public string ZipCode { get; set; }
            public string ZoneCode { get; set; }
            public string Telepone { get; set; }
            public string MobileNo { get; set; }
            public string IfBookseller { get; set; }
            public string rbtnSch { get; set; }
            public string DelAdd { get; set; }
            public string Transport { get; set; }
            public float DisCurrentYear { get; set; }
            public int TitleCurrentYear { get; set; }
            public float PrevDic { get; set; }
            public int PrevTitle { get; set; }
            public int ChkSchemeLetter { get; set; }
            public int ChkAddCommFrm { get; set; }
            public int ChkDisForm { get; set; }
            public string Remark { get; set; }
            public string CreatedBy { get; set; }
            public int FY { get; set; }
            public float OS { get; set; }
            public string R1 { get; set; }
            public string R2 { get; set; }
            public string R3 { get; set; }
            public string R4 { get; set; }
        }
        #endregion

        #region Idv_Chetana_KycForm Save Method

        public void Idv_Chetana_Save_KycForm(KycForm_Property ObjKycProperty, out int KycNo, out int KycMax)
        {
            //
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_KycForm",
                CreateParameter("@KycNo", SqlDbType.Int, ObjKycProperty.KycNo),
                CreateParameter("@CustCode", SqlDbType.VarChar, ObjKycProperty.CustCode),
                CreateParameter("@CustName", SqlDbType.VarChar, ObjKycProperty.CustName),
                CreateParameter("@CustAddress", SqlDbType.VarChar, ObjKycProperty.CustAdd),
                CreateParameter("@Area", SqlDbType.VarChar, ObjKycProperty.Area),
                CreateParameter("@City", SqlDbType.VarChar, ObjKycProperty.City),
                CreateParameter("@ZipCode", SqlDbType.VarChar, ObjKycProperty.ZipCode),
                CreateParameter("@ZoneCode", SqlDbType.VarChar, ObjKycProperty.ZoneCode),
                CreateParameter("@Telepone", SqlDbType.VarChar, ObjKycProperty.Telepone),
                CreateParameter("@MobileNo", SqlDbType.VarChar, ObjKycProperty.MobileNo),
                CreateParameter("@IfBookseller", SqlDbType.VarChar, ObjKycProperty.IfBookseller),
                CreateParameter("@DelAdd", SqlDbType.VarChar, ObjKycProperty.DelAdd),
                CreateParameter("@Transport", SqlDbType.VarChar, ObjKycProperty.Transport),
                CreateParameter("@DisCurrentYear", SqlDbType.Money, ObjKycProperty.DisCurrentYear),
                CreateParameter("@TitleCurrentYear", SqlDbType.Int, ObjKycProperty.TitleCurrentYear),

                CreateParameter("@PrevDis", SqlDbType.Money, ObjKycProperty.PrevDic),
                CreateParameter("@PrevTitle", SqlDbType.Int, ObjKycProperty.PrevTitle),

                CreateParameter("@chkSchemeLetter", SqlDbType.Int, ObjKycProperty.ChkSchemeLetter),
                CreateParameter("@AddCommFrm", SqlDbType.Int, ObjKycProperty.ChkAddCommFrm),
                CreateParameter("@DisForm", SqlDbType.Int, ObjKycProperty.ChkDisForm),
                CreateParameter("@createdBy", SqlDbType.VarChar, ObjKycProperty.CreatedBy),
                CreateParameter("@OS", SqlDbType.Money, ObjKycProperty.OS),
                CreateParameter("@FY", SqlDbType.Int, ObjKycProperty.FY),
                CreateParameter("@Remark", SqlDbType.VarChar, ObjKycProperty.Remark),
                CreateParameter("@R1", SqlDbType.VarChar, ObjKycProperty.R1),
                CreateParameter("@R2", SqlDbType.VarChar, ObjKycProperty.R2),
                CreateParameter("@R3", SqlDbType.VarChar, ObjKycProperty.R3),
                CreateParameter("@R4", SqlDbType.VarChar, ObjKycProperty.R4),
                CreateParameter("@KycId", SqlDbType.Int, 0, ParameterDirection.Output),
                CreateParameter("@KycMax", SqlDbType.Int, 0, ParameterDirection.Output));
            KycNo = Convert.ToInt32(cmd.Parameters["@KycId"].Value);
            KycMax = Convert.ToInt32(cmd.Parameters["@KycMax"].Value);
        }
        #endregion

        #region Checked KycForm Table Exsists Are Not
        public DataSet Idv_Chetana_Get_KycForm_GetMasterCust(string CustCode, int FY, string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_KycForm_GetMasterCust",
                CreateParameter("@CustCode", SqlDbType.VarChar, CustCode),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag));
        }
        #endregion

        #region Kyc Form Print

        public DataSet Idv_Chetana_Report_KycForm(int KycNo)
        {
            return ExecuteDataSet("Idv_Chetana_Report_KycForm",
                CreateParameter("@KycNo", SqlDbType.Int, KycNo));
        }
        #endregion

        #region KycForm Report
        public DataSet Idv_Chetana_Report_KycForm(int KycNo, int FY, string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Report_KycForm",
                CreateParameter("@KycNo", SqlDbType.Int, KycNo),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag", SqlDbType.NVarChar, Flag));
        }
        #endregion

        #region Get BookId Book Master
        public DataSet GetBookIdWithBookType(string Bookcode, int FY, string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_AssortedDiscount",
                CreateParameter("@BookCode", SqlDbType.VarChar, Bookcode),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag));
        }
        #endregion

        #region Get Data Edit Mode

        public DataSet Idv_Chetana_Get_KycForm(int KycNo, int FY, int FromKyc, int ToKyc, string Flag1, string Flag2, string Flag3, string Flag4)
        {
            return ExecuteDataSet("Idv_Chetana_Get_KycForm",
                CreateParameter("@KycNo", SqlDbType.Int, KycNo),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@FromKyc", SqlDbType.Int, FromKyc),
                CreateParameter("@ToKyc", SqlDbType.Int, ToKyc),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1),
                CreateParameter("@Flag2", SqlDbType.VarChar, Flag2),
                CreateParameter("@Flag3", SqlDbType.VarChar, Flag3),
                CreateParameter("@Flag4", SqlDbType.VarChar, Flag4));
        }

        #endregion

        #region Get Customer Code All Data With Master Table

        public DataSet Idv_Chetana_Get_KycForm_CusCode(string CustCode, int FY, string Flag1)
        {
            return ExecuteDataSet("Idv_Chetana_Get_KycForm_GetMasterCust",
                CreateParameter("@CustCode", System.Data.SqlDbType.VarChar, CustCode),
                CreateParameter("@FY", System.Data.SqlDbType.Int, FY),
                CreateParameter("@Flag1", System.Data.SqlDbType.VarChar, Flag1));
        }

        #endregion

        #region Godown Speciman Property
        public class Speciman_Property
        {
            public int SpecId { get; set; }
            public int SpecSeqNo { get; set; }
            public DateTime SpeDate { get; set; }
            public string BranchCode { get; set; }
            public string BranchName { get; set; }
            public string TranspotCode { get; set; }
            public string TranspportName { get; set; }
            public int NoOfParcels { get; set; }
            public double valueOfGood { get; set; }
            public string Remark { get; set; }
            public string SendBy { get; set; }
            public string LRNO { get; set; }
            public DateTime LDDate { get; set; }
            public int Paid { get; set; }
            public double Amount { get; set; }
            public int Delivery { get; set; }
            public string CreatedBy { get; set; }
            public int FY { get; set; }
            public int IsActive { get; set; }
            public string R1 { get; set; }
            public string R2 { get; set; }
            public string R3 { get; set; }
            public string R4 { get; set; }
            public string Details { get; set; }

        }
        #endregion

        #region Idv_Chetana_Save_Godown_Speciman_Head
        public void Idv_Chetana_Save_Godown_Speciman_Head(Speciman_Property Objproperty, out int SpeMaxNo, out int SpecAutoNo)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_Godown_Speciman_Head",
                CreateParameter("@SpecId", SqlDbType.Int, Objproperty.SpecId),
                CreateParameter("@SpecSeqNo", SqlDbType.Int, Objproperty.SpecSeqNo),
                CreateParameter("@SpeDate", SqlDbType.DateTime, Objproperty.SpeDate),
                CreateParameter("@BranchCode", SqlDbType.NVarChar, Objproperty.BranchCode),
                CreateParameter("@BranchName", SqlDbType.NVarChar, Objproperty.BranchName),
                CreateParameter("@TranspotCode", SqlDbType.NVarChar, Objproperty.TranspotCode),
                CreateParameter("@TranspportName", SqlDbType.NVarChar, Objproperty.TranspportName),
                CreateParameter("@NoOfParcels", SqlDbType.Int, Objproperty.NoOfParcels),
                CreateParameter("@valueOfGood", SqlDbType.Money, Objproperty.valueOfGood),
                CreateParameter("@Remark", SqlDbType.NVarChar, Objproperty.Remark),
                CreateParameter("@SendBy", SqlDbType.NVarChar, Objproperty.SendBy),
                CreateParameter("@LRNO", SqlDbType.NVarChar, Objproperty.LRNO),
                CreateParameter("@LDDate", SqlDbType.DateTime, Objproperty.LDDate),
                CreateParameter("@Paid", SqlDbType.Bit, Objproperty.Paid),
                CreateParameter("@Amount", SqlDbType.Money, Objproperty.Amount),
                CreateParameter("@Delivery", SqlDbType.Bit, Objproperty.Delivery),
                CreateParameter("@CreatedBy", SqlDbType.NVarChar, Objproperty.CreatedBy),
                CreateParameter("@FY", SqlDbType.Int, Objproperty.FY),
                CreateParameter("@R1", SqlDbType.NVarChar, Objproperty.R1),
                CreateParameter("@R2", SqlDbType.NVarChar, Objproperty.R2),
                CreateParameter("@R3", SqlDbType.NVarChar, Objproperty.R3),
                CreateParameter("@R4", SqlDbType.NVarChar, Objproperty.R4),
                CreateParameter("@Details", SqlDbType.Xml, Objproperty.Details),
                CreateParameter("@R_SpecMaxId", SqlDbType.Int, 0, ParameterDirection.Output),
                CreateParameter("@R_SpeAutoNo", SqlDbType.Int, 0, ParameterDirection.Output));
            SpeMaxNo = Convert.ToInt32(cmd.Parameters["@R_SpecMaxId"].Value);
            SpecAutoNo = Convert.ToInt32(cmd.Parameters["@R_SpeAutoNo"].Value);
        }
        #endregion

        #region Idv_Chetana_Get_Godown_Speciman_Head
        public DataSet Idv_Chetana_Get_Godown_Speciman_Head(int SpecNo, int FY, string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_Godown_Speciman_Head",
                CreateParameter("@SpecSeqNo", SqlDbType.Int, SpecNo),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag));
        }
        #endregion

        #region Get Dc Onchange Event
        public DataSet Idv_Chetana_Get_DcNoChnage(int DcNo, int FY, string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_Godown_Speciman_Head",
                CreateParameter("@DcNo", SqlDbType.Int, DcNo),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag", SqlDbType.Int, Flag));
        }
        #endregion

        #region Get Customer Name
        public DataSet Idv_Chetana_Get_CustomerName(string CusCode, string Flag)
        {
            return ExecuteDataSet("",
                CreateParameter("", SqlDbType.VarChar, Flag),
                CreateParameter("", SqlDbType.VarChar, CusCode));
        }
        #endregion

        #region CNF Ledger Report Data Print
        public DataSet Idv_Chetana_C_AccountingLedger(string Cnfcode, DateTime Fromdate, DateTime Todate, string Flag, int FY)
        {
            return ExecuteDataSet("C_AccountingLedger",
                CreateParameter("@cnfcode", SqlDbType.VarChar, Cnfcode),
                CreateParameter("@fromdate", SqlDbType.DateTime, Fromdate),
                CreateParameter("@todate", SqlDbType.DateTime, Todate),
                CreateParameter("@flag", SqlDbType.VarChar, Flag),
                CreateParameter("@fy", SqlDbType.Int, FY));
        }
        #endregion

        #region Idv_Chetana_Get_Token_Register Token No Exists
        public DataSet Idv_Chetana_Get_Token_Exists(string CustCode, int FY, string R3)
        {
            return ExecuteDataSet("Idv_Chetana_Get_Token_Register",
                CreateParameter("@KycNo", SqlDbType.Int, 0),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@R2", SqlDbType.VarChar, CustCode),
                CreateParameter("@R3", SqlDbType.VarChar, R3),
                CreateParameter("@R1", SqlDbType.VarChar, ""),
                CreateParameter("@Id", SqlDbType.Int, 1),
                CreateParameter("@FromDate", SqlDbType.DateTime, DateTime.Now),
                CreateParameter("@FromTo", SqlDbType.DateTime, DateTime.Now),
                CreateParameter("@PrintID", SqlDbType.VarChar, ""));
        }
        #endregion

        #region Token Register Validation

        public DataSet Token_Register_Validation(string CustCode, int KycNo, int FY, string Flag1, string Flag2)
        {
            return ExecuteDataSet("Idv_Chetana_ValidateTokeregister",
                CreateParameter("@custcode", SqlDbType.VarChar, CustCode),
                CreateParameter("@KycNo", SqlDbType.Int, KycNo),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@flag1", SqlDbType.VarChar, Flag1),
                CreateParameter("@flag2", SqlDbType.VarChar, Flag2));
        }

        #endregion

        #region Customers Tod Property
        public class CustomerTodProp
        {
            public string CustCode { get; set; }
            public string R1 { get; set; }
        }
        #endregion

        #region All CNF Stock Transfer

        //#region All Property CNF Stock Transfer
        //public class CnfStockTransfer_Property
        //{
        //    public string Flag { get; set; }
        //    public int FY { get; set; }
        //    public string OtherFieldXML { get; set; }
        //    public string R1 { get; set; }
        //    public string R2 { get; set; }
        //    public string R3 { get; set; }
        //    public string R4 { get; set; }
        //    public string R5 { get; set; }
        //}
        //#endregion

        //#region CNF Stock Transfer Save
        //public void Idv_Chetana_Save_StockTransfer_Cnf(CnfStockTransfer_Property Prop)
        //{
        //    ExecuteNonQuery("Idv_Chetana_Save_BoookStock_Cnf",
        //        CreateParameter("@Flag", SqlDbType.VarChar, Prop.Flag),
        //        CreateParameter("@FY", SqlDbType.Int, Prop.FY),
        //        CreateParameter("@OtherFieldXML", SqlDbType.Xml, Prop.OtherFieldXML),
        //        CreateParameter("@R1", SqlDbType.VarChar, Prop.R1),
        //        CreateParameter("@R2", SqlDbType.VarChar, Prop.R2),
        //        CreateParameter("@R3", SqlDbType.VarChar, Prop.R3),
        //        CreateParameter("@R4", SqlDbType.VarChar, Prop.R4),
        //        CreateParameter("@R5", SqlDbType.VarChar, Prop.R5));
        //}
        //#endregion

        #endregion

        #region All Ticket Details DAL

        #region Ticket FillGrid
        public DataSet GetGridRemarks(string TKTID)
        {
            string paramValue = "RemarksGrid";
            return base.ExecuteDataSet("Sp_TktHistory", new IDataParameter[]{
            base.CreateParameter("@TKTID", SqlDbType.NVarChar, TKTID),
            base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue)
            });
        }
        #endregion

        #region Get Last Ticket Number
        public DataSet GetLastTktNo()
        {
            string paramValue = "LastRecord";
            string str2 = null;
            return base.ExecuteDataSet("Sp_LastTktNo", new IDataParameter[] {
            base.CreateParameter("@TKTID", SqlDbType.NVarChar, str2), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue)
            });
        }
        #endregion

        #region  Update Last Ticket No
        public DataSet UpdateLastTktNo(string TKTID)
        {
            string paramValue = "TKTUPDATE";
            return base.ExecuteDataSet("Sp_LastTktNo", new IDataParameter[] {
            base.CreateParameter("@TKTID", SqlDbType.NVarChar, TKTID), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue)
            });
        }
        #endregion

        #region Get Seleted Ticket
        public DataSet GetGridTktSelect(string TKTID)
        {
            string paramValue = "SelecteGrid";
            return base.ExecuteDataSet("Sp_TktHistory", new IDataParameter[] {
            base.CreateParameter("@TKTID", SqlDbType.NVarChar, TKTID), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue)
            });
        }
        #endregion

        #region Get Ticket Remark Lable All
        public DataSet GetGridRmkAll(string TKTID)
        {
            string paramValue = "RemarkAllGrid";
            return base.ExecuteDataSet("Sp_TktHistory", new IDataParameter[] { 
            base.CreateParameter("@TKTID", SqlDbType.NVarChar, TKTID), base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue)
            });
        }
        #endregion

        #region Get Customer Code With
        public DataSet Get_Name(string Code, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetName_By_Code", new IDataParameter[] {
            base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag) 
            });
        }
        #endregion

        #region Customer Help Desk
        public DataSet getAllHelpDesk(string custcode, string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Customer_Quick_DashBoard", new IDataParameter[] {
            base.CreateParameter("@CustCode", SqlDbType.NVarChar, custcode), base.CreateParameter("@Flag", SqlDbType.NVarChar, flag)
            });
        }
        #endregion

        #region Dropdown Bind Escalation
        public DataSet Get_MasterOfMaster_ByGroup_ForDropdown(string Group, string Flag2)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_MasterOfMaster_ByGroup1", new IDataParameter[] {
            base.CreateParameter("@Group", SqlDbType.NVarChar, Group), base.CreateParameter("@Flag2", SqlDbType.NVarChar, Flag2) });
        }
        #endregion

        public DataSet Idv_Get_DCDetails_By_DocNo(int DocNo, string Flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_Details_By_DocNo", new IDataParameter[] {
            base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag),
            base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_SubDocId_And_ItsRecords_By_DocNo(int DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DC_Get_SubDocId_And_ItsRecords_By_DocNo", new IDataParameter[] {
            base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@flag",
            SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet GetStatus()
        {
            string paramValue = "Status";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] {
            base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet GetStatusIsDefault()
        {
            string paramValue = "IsDefaultStus";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] { 
            base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet GetSeverity()
        {
            string paramValue = "Severity";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] {
            base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet GetInqType()
        {
            string paramValue = "InquieryType";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] { 
            base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet GetSeverityIsDefault()
        {
            string paramValue = "IsDefaultSeverity";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] {
            base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet GetInqiryIsDefault()
        {
            string paramValue = "IsDefaultInqType";
            return base.ExecuteDataSet("Sp_BindStatusSeverityType", new IDataParameter[] {
            base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }

        public DataSet InqTypeEmailID(string Code, string Flag, int InqType)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetName_InqType", new IDataParameter[] { base.CreateParameter("@Code", SqlDbType.NVarChar, Code), base.CreateParameter("@InqType", SqlDbType.Int, InqType), base.CreateParameter("@flag", SqlDbType.NVarChar, Flag) });
        }

        #region CMS Dashboard View Pending
        public DataSet GetDashboardgrid(string Flag)
        {
            return ExecuteDataSet("Sp_RecentEnquires",
            CreateParameter("@Flag", SqlDbType.VarChar, Flag));
        }
        #endregion

        #region
        public DataSet Idv_Chetana_Help_PendingCompleted(string Flag, string FromDate, string ToDate, string R3, string R4, string R5)
        {
            return ExecuteDataSet("Idv_Chetana_Help_PendingCompleted",
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@FromDate", SqlDbType.VarChar, FromDate),
                CreateParameter("@ToDate", SqlDbType.VarChar, ToDate),
                CreateParameter("@R3", SqlDbType.VarChar, R3),
                CreateParameter("@R4", SqlDbType.VarChar, R4),
                CreateParameter("@R5", SqlDbType.VarChar, R5));
        }
        #endregion View Link Button Click Event
        public DataSet GetDashboardRemarks(string TktNumber)
        {
            string paramValue = "RemarkAllDashboard";
            return base.ExecuteDataSet("Sp_TktHistory", new IDataParameter[] {
            base.CreateParameter("@TktNumber", SqlDbType.NVarChar, TktNumber),
            base.CreateParameter("@Action", SqlDbType.NVarChar, paramValue) });
        }
        public DataSet GetDashboardhelpdesk(string flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_HelpDeskDashboard",
                CreateParameter("@flag", SqlDbType.VarChar, flag));
        }
        public DataSet GetDashboardhelpdesk2(string flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_HelpDeskDashboard", new IDataParameter[] {
            base.CreateParameter("@flag",SqlDbType.VarChar,flag) });
        }
        public DataSet Get_Pending_Godown(string Flag, int FY, DateTime FromDate, DateTime ToDate, string Flag1, string Flag2)
        {
            return ExecuteDataSet("Idv_Chetana_HelpDesk_Godown_History",
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1),
                CreateParameter("@Flag2", SqlDbType.VarChar, Flag2));

        }

        public void Idv_Chetana_Update_HelpDesk_Godown(string Remark, int Tkt_Id, int FY, string Flag, string R1, string R2, string R3, string R4, string R5)
        {
            ExecuteNonQuery("Idv_Chetana_Update_HelpDesk_Godown",
                CreateParameter("@Remark", SqlDbType.VarChar, Remark),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@R1", SqlDbType.VarChar, R1),
                CreateParameter("@R2", SqlDbType.VarChar, R2),
                CreateParameter("@R3", SqlDbType.VarChar, R3),
                CreateParameter("@R4", SqlDbType.VarChar, R4),
                CreateParameter("@R5", SqlDbType.VarChar, R5),
                CreateParameter("@Tkt_ID", SqlDbType.Int, Tkt_Id));
        }
        #endregion

        #region Cnf Pending CRM
        public DataSet C_GetPendingDocNo(int FY, string Flag)
        {
            return ExecuteDataSet("C_Idv_Chetana_DC_Get_PedingDocNo",
              CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@Flag", SqlDbType.VarChar, Flag));
        }
        #endregion

        #region
        public DataSet C_GetPendingApprovedDocNo(int FY, string Flag)
        {
            return ExecuteDataSet("C_Idv_Chetana_DC_Get_PedingDocNo_IsApproved",
            CreateParameter("@FY", SqlDbType.Int, FY),
            CreateParameter("@Flag", SqlDbType.VarChar, Flag));
        }
        #endregion

        #region
        public bool Get_DocumentNum_Authentication(int DocumentNo, int strFY)
        {
            DataTable table = new DataTable();
            table = ExecuteDataSet("[Idv_Chetana_DC_Get_DocumentNum_Authentication]",
            CreateParameter("@DocumentNo", SqlDbType.Int, DocumentNo),
            CreateParameter("@FY", SqlDbType.Int, strFY)).Tables[0];
            if (table.Rows.Count > 0)
            {
                return ((table.Rows[0]["DocumentNo"].ToString() == Convert.ToString(DocumentNo)) && false);
            }
            return true;
        }

        #endregion

        #region Relway Register With CnF Data Show Only
        public DataSet Idv_Chetana_G_Railway_Report_CnF(int CnfId, DateTime FromDate, DateTime ToDate, int DocFrom, int DocTo, string Flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_G_Railway_Report_CnF",
                CreateParameter("@CnfID", SqlDbType.Int, CnfId),
                CreateParameter("@fdate", SqlDbType.DateTime, FromDate),
                CreateParameter("@tdate", SqlDbType.DateTime, ToDate),
                CreateParameter("@DcoFrom", SqlDbType.Int, DocFrom),
                CreateParameter("@DcoTo", SqlDbType.Int, DocTo),
                CreateParameter("@Falg", SqlDbType.VarChar, Flag),
                CreateParameter("@Fy", SqlDbType.Int, FY));
        }
        #endregion

        #region Outstanding Auto mail All Property
        public class outstandingAutomailProp
        {
            public int id { get; set; }
            public int Amount { get; set; }
            public string Emailids { get; set; }
            public int SendTo { get; set; }
            public int FY { get; set; }
            public string CreatedBy { get; set; }
            public string CC { get; set; }
            public string R1 { get; set; }
            public string R2 { get; set; }
            public string R3 { get; set; }
            public string R4 { get; set; }
            public string R5 { get; set; }
            public string Flag { get; set; }
        }
        #endregion

        #region Outstanding Auto mail Save
        public void Idv_Chetana_Save_AutoOutStandingConfig(outstandingAutomailProp ObjProp, out int Maxid)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_AutoOutStandingConfig",
                CreateParameter("@OutstandingId", SqlDbType.Int, ObjProp.id),
                CreateParameter("@Amount", SqlDbType.Int, ObjProp.Amount),
                CreateParameter("@CC", SqlDbType.NVarChar, ObjProp.CC),
                CreateParameter("@SendTo", SqlDbType.Int, ObjProp.SendTo),
                CreateParameter("@EmailIds", SqlDbType.VarChar, ObjProp.Emailids),
                CreateParameter("@FY", SqlDbType.Int, ObjProp.FY),
                CreateParameter("@CreatedBy", SqlDbType.VarChar, ObjProp.CreatedBy),
                CreateParameter("@R1", SqlDbType.VarChar, ObjProp.R1),
                CreateParameter("@R2", SqlDbType.VarChar, ObjProp.R2),
                CreateParameter("@R3", SqlDbType.VarChar, ObjProp.R3),
                CreateParameter("@R4", SqlDbType.VarChar, ObjProp.R4),
                CreateParameter("@R5", SqlDbType.VarChar, ObjProp.R5),
                CreateParameter("@Flag", SqlDbType.VarChar, ObjProp.Flag),
                CreateParameter("@MaxId", SqlDbType.Int, 0, ParameterDirection.Output));
            Maxid = Convert.ToInt32(cmd.Parameters["@MaxId"].Value);
        }
        #endregion

        #region Get All Data Outstanding Auto Mail
        public DataSet Idv_Chetana_Get_AutoOutStandingConfig(outstandingAutomailProp ObjProp)
        {
            return ExecuteDataSet("Idv_Chetana_Get_AutoOutStandingConfig",
                CreateParameter("@OutstandingId", SqlDbType.Int, ObjProp.id),
                CreateParameter("@FY", SqlDbType.Int, ObjProp.FY),
                CreateParameter("@Flag", SqlDbType.VarChar, ObjProp.Flag));
        }
        #endregion

        #region Outstanding Auto Save Email With Customer
        public void Idv_Chetana_Save_AutoOutStandingCustomer(outstandingAutomailProp ObjProp)
        {
            ExecuteNonQuery("Idv_Chetana_Save_AutoOutStandingCustomer",
                 CreateParameter("@OutstandingId", SqlDbType.Int, ObjProp.id),
                CreateParameter("@CC", SqlDbType.VarChar, ObjProp.CC),
                CreateParameter("@SendTo", SqlDbType.Int, ObjProp.SendTo),
                CreateParameter("@EmailIds", SqlDbType.VarChar, ObjProp.Emailids),
                CreateParameter("@FY", SqlDbType.Int, ObjProp.FY),
                CreateParameter("@CreatedBy", SqlDbType.VarChar, ObjProp.CreatedBy),
                CreateParameter("@R1", SqlDbType.VarChar, ObjProp.R1),
                CreateParameter("@R2", SqlDbType.VarChar, ObjProp.R2),
                CreateParameter("@R3", SqlDbType.VarChar, ObjProp.R3),
                CreateParameter("@R4", SqlDbType.VarChar, ObjProp.R4),
                CreateParameter("@R5", SqlDbType.VarChar, ObjProp.R5),
                CreateParameter("@Flag", SqlDbType.VarChar, ObjProp.Flag));
        }
        #endregion

        #region Get All Data Outstanding Auto Mail With Customer
        public DataSet Idv_Chetana_Get_AutoOutStandingCustomer(outstandingAutomailProp ObjProp)
        {
            return ExecuteDataSet("Idv_Chetana_Get_AutoOutStandingCustomer",
                CreateParameter("@OutstandingId", SqlDbType.Int, ObjProp.id),
                CreateParameter("@FY", SqlDbType.Int, ObjProp.FY),
                CreateParameter("@Flag", SqlDbType.VarChar, ObjProp.Flag));
        }
        #endregion

        #region CN Dropdwon Bind With SuperZone
        public DataSet Idv_Chetana_DC_GetCustlist_Bydt(int FY, DateTime FromDt, DateTime ToDt, string UserLogin, string Flag, string Flag1)
        {
            return ExecuteDataSet("Idv_Chetana_DC_GetCustlist_Bydt",
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@FromDt", SqlDbType.DateTime, FromDt),
                CreateParameter("@ToDt", SqlDbType.DateTime, ToDt),
                CreateParameter("@UserName", SqlDbType.VarChar, UserLogin),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region Report Commission Book Seller
        public DataSet Idv_Chetana_Commission_BkSeller(int ZoneId, int SuperZoneId, string FromDate, string ToDate, int FY, string Flage, string Flag1)
        {
            return ExecuteDataSet("Idv_Chetana_CommissionBkSeller",
                CreateParameter("@ZoneId", SqlDbType.Int, ZoneId),
                CreateParameter("@SuperZone", SqlDbType.Int, SuperZoneId),
                CreateParameter("@FromDate", SqlDbType.VarChar, FromDate),
                CreateParameter("@ToDate", SqlDbType.VarChar, ToDate),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag", SqlDbType.VarChar, Flage),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region Unuser Receipt No (Missing)
        public DataSet Idv_Chetana_Missing_UnuseReceiptNo(string FromDate, string Todate, int FY, int Empid, int ReceptNo, int Superzone, int Zone, string R3, string R4)
        {
            return ExecuteDataSet("Idv_Chetana_Missing_UnuseReceiptNo",
                CreateParameter("@FromDate", SqlDbType.VarChar, FromDate),
                CreateParameter("@Todate", SqlDbType.VarChar, Todate),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@EmpId", SqlDbType.Int, Empid),
                CreateParameter("@ReceptNo", SqlDbType.Int, ReceptNo),
                CreateParameter("@SuperZone", SqlDbType.Int, Superzone),
                CreateParameter("@Zone", SqlDbType.Int, Zone),
                CreateParameter("@R3", SqlDbType.VarChar, R3),
                CreateParameter("@R4", SqlDbType.VarChar, R4));
        }
        #endregion

        #region Update POD All Module

        #region Courier Property
        public class Courier_Property
        {
            public DateTime Courierdate { get; set; }
            public string CreatedBy { get; set; }
            public float DocumentNo { get; set; }
            public int GeneralCourierID { get; set; }
            public float InvoiceNo { get; set; }
            public bool IsActive { get; set; }
            public int POD { get; set; }
            public int SCD { get; set; }
            public float SCMasterAutoId { get; set; }
            public string UpDateBy { get; set; }
            public decimal Weight { get; set; }
            public string XMLData { get; set; }
        }
        #endregion

        #region Get Branch Dropdown
        public DataSet GetBranch(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CourierData",
            CreateParameter("@Flag", SqlDbType.NVarChar, Flag));
        }
        #endregion

        #region Get Data With From Date And To Date And Invoice
        public DataSet GetUpdatePOD(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ChetanaUpdatePOD",
            CreateParameter("@DocNo", SqlDbType.Float, DocNo),
            CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate),
            CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate),
            CreateParameter("@Branch", SqlDbType.NVarChar, Branch),
            CreateParameter("@Courier", SqlDbType.NVarChar, CourierCompany),
            CreateParameter("@flag", SqlDbType.NVarChar, flag),
            CreateParameter("@FY", SqlDbType.Int, FY));
        }
        #endregion

        #region Update UpdatePOD With XML
        public void Idv_Chetana_UpdatePODNo(string ScMasterAutoId, string Document, string InvoiceNo, string flag, string XMLData, string NO, int FY)
        {
            ExecuteNonQuery("Idv_Chetana_UpdatePODNo",
                CreateParameter("@SCMasterAutoId", SqlDbType.VarChar, ScMasterAutoId),
                CreateParameter("@DocumentNo", SqlDbType.VarChar, Document),
                CreateParameter("@InvoiceNo", SqlDbType.VarChar, InvoiceNo),
                CreateParameter("@flag", SqlDbType.VarChar, flag),
                CreateParameter("@XMLData", SqlDbType.Xml, XMLData),
                CreateParameter("@NO", SqlDbType.VarChar, NO),
                CreateParameter("@FY", SqlDbType.Int, FY));
        }
        #endregion

        #endregion

        #region Get Bank Cash Entries
        public DataSet idv_Chetana_Get_Bank_Cash_Entries(string BankCode, int Month, int FY, Decimal Amount, string Flag, string Remark1, string Remark2, string Remark3)
        {
            return ExecuteDataSet("idv_Chetana_Get_Bank_Cash_Entries",
                CreateParameter("@BankCode", SqlDbType.VarChar, BankCode),
                CreateParameter("@frommonth", SqlDbType.Int, Month),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@openingBalance", SqlDbType.Money, Amount),
                CreateParameter("@flag", SqlDbType.VarChar, Flag),
                CreateParameter("@remark1", SqlDbType.VarChar, Remark1),
                CreateParameter("@remark2", SqlDbType.VarChar, Remark2),
                CreateParameter("@remark3", SqlDbType.VarChar, Remark3));
        }
        #endregion

        #region Cmd Ticket History Report
        public DataSet BindStatus()
        {
            return base.ExecuteDataSet("Sp_BindStatusSeverityType",
            CreateParameter("@Action", SqlDbType.NVarChar, "Status"));
        }
        #endregion

        #region Ticket Status And Escalation Bind
        public DataSet BindStatus(string Flag)
        {
            return base.ExecuteDataSet("Sp_BindStatusSeverityType",
            CreateParameter("@Action", SqlDbType.NVarChar, Flag));
        }
        #endregion

        #region Call Report Bind And Call History Bind
        public DataSet AllRecordRepordTicketHistory(DateTime InqFDate, DateTime InqTDATE, string TKTNOFrom, string TKTNOTo, string CustomerName, string EmpName, string CustNo, string Status, string Action)
        {
            return base.ExecuteDataSet("SP_RptTicketHistory",
            CreateParameter("@InqFromDate", SqlDbType.DateTime, InqFDate),
            CreateParameter("@InqToDate", SqlDbType.DateTime, InqTDATE),
            CreateParameter("@TKTNOFrom", SqlDbType.NVarChar, TKTNOFrom),
            CreateParameter("@TKTTODate", SqlDbType.NVarChar, TKTNOTo),
            CreateParameter("@CustomerName", SqlDbType.NVarChar, CustomerName),
            CreateParameter("@EmpName", SqlDbType.NVarChar, EmpName),
            CreateParameter("@CustNo", SqlDbType.NVarChar, CustNo),
            CreateParameter("@Status", SqlDbType.NVarChar, Status),
            CreateParameter("@Action", SqlDbType.NVarChar, Action));
        }
        #endregion

        #region Disbures Customr Dropdown Bind
        public DataSet Idv_Chetana_Get_ZoneCustomerAdditionalCommissionOtherZ(int Code1)
        {
            return ExecuteDataSet("Idv_Chetana_Get_ZoneAdditionalCommission",
            CreateParameter("@Zone", SqlDbType.Int, Code1));
        }
        #endregion

        #region Pending DC
        public void Idv_Chetana_DC_Save_ConfirmQtyDetails1(int ConfirmODcQtyId, int DCDetailID, int AvailableQty, decimal subDocNo, decimal parcel, decimal bundles, string CreatedBy, string XMlData, string Flag, string Flag1)
        {
            ExecuteNonQuery("Idv_Chetana_DC_Save_ConfirmQtyDetails1_New",
            CreateParameter("@ConfirmDcQtyId", SqlDbType.Int, ConfirmODcQtyId),
            CreateParameter("@DCDetailID", SqlDbType.Int, DCDetailID),
            CreateParameter("@AvailableQty", SqlDbType.Int, AvailableQty),
            CreateParameter("@SubDocNo", SqlDbType.Decimal, subDocNo),
            CreateParameter("@Bundles", SqlDbType.Decimal, bundles),
            CreateParameter("@Parcel", SqlDbType.Decimal, parcel),
            CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
            CreateParameter("@XMLDATA", SqlDbType.Xml, XMlData),
            CreateParameter("@Flag", SqlDbType.VarChar, Flag),
            CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region User Tikeck Map Save
        public void Idv_Chetana_UserTicketMap_Save(string EmpCode, string SuperZoneId, int FY, string createdBy, string R1, string R2, string R3, string R4, string R5, string Flag, string Flag1)
        {
            ExecuteNonQuery("Idv_Chetana_UserTicketMap_Save",
                CreateParameter("@EmpCode", SqlDbType.VarChar, EmpCode),
                CreateParameter("@SuperZoneId", SqlDbType.VarChar, SuperZoneId),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@CreatedBy", SqlDbType.VarChar, createdBy),
                CreateParameter("@R1", SqlDbType.VarChar, R1),
                CreateParameter("@R2", SqlDbType.VarChar, R2),
                CreateParameter("@R3", SqlDbType.VarChar, R3),
                CreateParameter("@R4", SqlDbType.VarChar, R4),
                CreateParameter("@R5", SqlDbType.VarChar, R5),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }

        #endregion

        #region Dc Book Returen
        //int DCReturnBkID, string CustCode, string BookCode, int ReturnQty, string Comment, string CreatedBy, string Flag, int DefectQty, int strFY
        public void Save_DC_ReturnBook_OtherZ(string XmlData, string UserName, int FY, string CustCode, string Flag1, string Flag2)
        {
            ExecuteNonQuery("Idv_Chetana_DC_Save_DC_ReturnBook_New",
            CreateParameter("@CreatedBy", SqlDbType.VarChar, UserName),
            CreateParameter("@FY", SqlDbType.Int, FY),
            CreateParameter("@CustCode", SqlDbType.VarChar, CustCode),
            CreateParameter("@Flag1", SqlDbType.VarChar, Flag1),
            CreateParameter("@Flag2", SqlDbType.VarChar, Flag2),
            CreateParameter("@XML", SqlDbType.Xml, XmlData));

        }
        #endregion

        #region Inquery Update Details Appent Button Click
        public void InqueryUpdateDetails(string tKTID, string enqType, string severity, string status, string remarks, string empname)
        {
            ExecuteNonQuery("Sp_InquiryUpdate",
               CreateParameter("@empname", SqlDbType.VarChar, empname),
               CreateParameter("@Remarks", SqlDbType.VarChar, remarks),
               CreateParameter("@Status", SqlDbType.VarChar, status),
               CreateParameter("@Severity", SqlDbType.VarChar, severity),
               CreateParameter("@EnqType", SqlDbType.VarChar, enqType),
               CreateParameter("@TKTID", SqlDbType.VarChar, tKTID));
        }
        #endregion

        #region Usha Mam Outstanding Report
        public static DataSet Idv_Chetana_Customer_Outstanding_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode, decimal amount, string Flags, string iszero)
        {
            return new OtherBAL().Idv_Chetana_Customer_OutstandingAna_Report(CustID, FromDate, ToDate, FY, Superzone, Zone, CustCode, amount, Flags, iszero);
        }

        public DataSet Idv_Chetana_Customer_OutstandingAna_Report(int CustID, string FromDate, string ToDate, int FY, int Superzone, int Zone, string CustCode, decimal Amount, string Flags, string iszero)
        {
            return ExecuteDataSet("Idv_Chetana_Customer_Outstanding_AnalysisReport",
                CreateParameter("@CustID", SqlDbType.Int, CustID),
                CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate),
                CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Superzone", SqlDbType.Int, Superzone),
                CreateParameter("@Zone", SqlDbType.Int, Zone),
                CreateParameter("@CustCode", SqlDbType.NVarChar, CustCode),
                CreateParameter("@Amount", SqlDbType.Money, Amount),
                CreateParameter("@Flags", SqlDbType.VarChar, Flags),
                CreateParameter("@iszero", SqlDbType.NVarChar, iszero)

                );
        }
        #endregion

        #region Get PAN Report
        public static DataSet Idv_Chetana_PANReport(int SuperZone, int Zone, int FY, string Flag, string Flag1, string Flag2, string Flag3)
        {
            return new OtherBAL().Idv_Chetana_PANWithReport(SuperZone, Zone, FY, Flag, Flag1, Flag2, Flag3);
        }
        public DataSet Idv_Chetana_PANWithReport(int SuperZone, int Zone, int FY, string Flag, string Flag1, string Flag2, string Flag3)
        {
            return ExecuteDataSet("Idv_Chetana_Rep_PanReport",
                CreateParameter("@Superzone", SqlDbType.Int, SuperZone),
                CreateParameter("@Zone", SqlDbType.Int, Zone),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@flag", SqlDbType.VarChar, Flag),
                CreateParameter("@flag1", SqlDbType.VarChar, Flag1),
                CreateParameter("@flag2", SqlDbType.VarChar, Flag2),
                CreateParameter("@flag3", SqlDbType.VarChar, Flag3));
        }
        #endregion

        #region CollectionReport
        public static DataSet GetCollectionReport(int Superzone, int FY, DateTime FromDate, DateTime ToDate, string Flag)
        {
            return new OtherBAL().Collection_Report(Superzone, FY, FromDate, ToDate, Flag);
        }
        public DataSet Collection_Report(int SuperZone, int FY, DateTime FromDate, DateTime Todate, string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_REP_Collection_Report",
            CreateParameter("@SuperZoneID", SqlDbType.Int, SuperZone),
            CreateParameter("@Fy", SqlDbType.Int, FY),
            CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
            CreateParameter("@Todate", SqlDbType.DateTime, Todate),
            CreateParameter("@Flag", SqlDbType.NVarChar, Flag));
        }
        #endregion

        #region Book Stock

        public static DataSet C_IDV_Chetana_REP_STOCK_Get(string BookCode, DateTime FromDate, DateTime ToDate, int FY, string Flag, string Flag1)
        {
            return new OtherBAL().C_IDV_Chetana_REP_STOCK(BookCode, FromDate, ToDate, FY, Flag, Flag1);
        }

        public DataSet C_IDV_Chetana_REP_STOCK(string BookCode, DateTime FromDate, DateTime ToDate, int FY, string Flag, string Flag1)
        {
            return ExecuteDataSet("Idv_Chetana_CNFBookStock",
                CreateParameter("@BookCode", SqlDbType.VarChar, BookCode),
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region Bank Payment
        public class SaveBankPay
        {
            public int BankPaymentID { get; set; }
            public string BankCode { get; set; }
            public int Documentno { get; set; }
            public int Serialno { get; set; }
            public DateTime DocumentDate { get; set; }
            public string AccountCode { get; set; }
            public string PersonInCharge { get; set; }
            public string ReportCode { get; set; }
            public string Cash_Cheque_DD { get; set; }
            public string Cheque_DD_NO { get; set; }
            public string Type { get; set; }
            public Decimal Amount { get; set; }
            public string DrawnOn { get; set; }
            public string Remarks { get; set; }

            public bool IsActive { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
            public int DocNo { get; set; }
            public int strFY { get; set; }
            public string Paymode { get; set; }
            public bool IsChequeBounce { get; set; }
        }

        public void SaveBankPayment(SaveBankPay ObjProp, out int DocNo)
        {
            SqlCommand command;
            ExecuteNonQuery(out command, "Idv_Chetana_Save_BankPayment",
                CreateParameter("@BankPaymentID", SqlDbType.Int, ObjProp.BankPaymentID),
                CreateParameter("@BankCode", SqlDbType.NVarChar, ObjProp.BankCode),
                CreateParameter("@Documentno", SqlDbType.Int, ObjProp.Documentno),
                CreateParameter("@Serialno", SqlDbType.Int, ObjProp.Serialno),
                CreateParameter("@DocumentDate", SqlDbType.DateTime, ObjProp.DocumentDate),
                CreateParameter("@AccountCode", SqlDbType.NVarChar, ObjProp.AccountCode),
                CreateParameter("@PersonInCharge", SqlDbType.NVarChar, ObjProp.PersonInCharge),
                CreateParameter("@ReportCode", SqlDbType.NVarChar, ObjProp.ReportCode),
                CreateParameter("@Cash_Cheque_DD", SqlDbType.NVarChar, ObjProp.Cash_Cheque_DD),
                CreateParameter("@Cheque_DD_NO", SqlDbType.NVarChar, ObjProp.Cheque_DD_NO),
                CreateParameter("@Type", SqlDbType.NVarChar, ObjProp.Type),
                CreateParameter("@Amount", SqlDbType.Decimal, ObjProp.Amount),
                CreateParameter("@DrawnOn", SqlDbType.NVarChar, ObjProp.DrawnOn),
                CreateParameter("@Remarks", SqlDbType.NVarChar, ObjProp.Remarks),
                CreateParameter("@IsActive", SqlDbType.Bit, ObjProp.IsActive),
                CreateParameter("@CreatedBy", SqlDbType.NVarChar, ObjProp.CreatedBy),
                CreateParameter("@UpdatedBy", SqlDbType.NVarChar, ObjProp.UpdatedBy),
                CreateParameter("@DocNo", SqlDbType.Int, ParameterDirection.Output),
                CreateParameter("@FY", SqlDbType.Int, ObjProp.strFY),
                CreateParameter("@Paymode", SqlDbType.NVarChar, ObjProp.Paymode),
                CreateParameter("@IsChequeBounce", SqlDbType.Bit, ObjProp.IsChequeBounce)
             );
            DocNo = Convert.ToInt32(command.Parameters["@DocNo"].Value);
            command.Dispose();
        }

        public static DataSet GetDebitVsCreditReport(string CustCode, DateTime FromDate, DateTime ToDate, int FY, string Flag, string Flag1)
        {
            return new OtherBAL().GetDebitVsCredit(CustCode, FromDate, ToDate, FY, Flag, Flag1);
        }

        public DataSet GetDebitVsCredit(string CustCode, DateTime FromDate, DateTime ToDate, int FY, string Flag, string Flag1)
        {
            return ExecuteDataSet("Idv_Chetana_DebitVsCredit",
                CreateParameter("@CustCode", SqlDbType.VarChar, CustCode),
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region Get Speciman Book Set Limit
        public static DataSet SalesmanBook_Get(string Salesman, int FY, string Flag, string Flag1)
        {
            return new OtherBAL().GetSalesmanBook(Salesman, FY, Flag, Flag1);
        }
        public DataSet GetSalesmanBook(string Salesman, int FY, string Flag, string Flag1)
        {
            return ExecuteDataSet("Idv_Chetana_SalesmanBookSetLimit_Get",
                CreateParameter("@SalesCode", SqlDbType.VarChar, Salesman),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region Speciman Book Set Validate
        public static DataSet GetValidate_Speciman(int BooksetId, string Qty, string salesmancode, int FY, string Flag, string Flag1)
        {
            return new OtherBAL().SpecimanValidate(BooksetId, Qty, salesmancode, FY, Flag, Flag1);
        }
        public DataSet SpecimanValidate(int BooksetId, string Qty, string salesmancode, int FY, string Flag, string Flag1)
        {
            return ExecuteDataSet("SaveSalesmnBookSetLimit_Valid",
               CreateParameter("@BooksetId", SqlDbType.Int, BooksetId),
               CreateParameter("@Qty", SqlDbType.VarChar, Qty),
               CreateParameter("@SalesmanCode", SqlDbType.VarChar, salesmancode),
               CreateParameter("@FY", SqlDbType.Int, FY),
               CreateParameter("@Flag", SqlDbType.VarChar, Flag),
               CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region Save Speciman Book Set Limit

        public void SaveSalesmnBookSetLimit(string xmldata, string salesmancode, int FY, string Createdby, string Flag, string Flag1)
        {
            ExecuteNonQuery("Idv_Chetana_SET_SpecimanBookSetLimit",
               CreateParameter("@xmldata", SqlDbType.Xml, xmldata),
               CreateParameter("@SalesmanCode", SqlDbType.VarChar, salesmancode),
               CreateParameter("@FY", SqlDbType.Int, FY),
               CreateParameter("@CreatedBy", SqlDbType.VarChar, Createdby),
               CreateParameter("@Flag", SqlDbType.VarChar, Flag),
               CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region Save Speciman Book Set
        public class SpecimenDCNew
        {
            public DateTime ChallanDate { get; set; }
            public string ChallanNo { get; set; }
            public string CreatedBy { get; set; }
            public string Description { get; set; }
            public int DocNewNo { get; set; }
            public int DocNo { get; set; }
            public DateTime DocumentDate { get; set; }
            public int DocumentNo { get; set; }
            public int FinancialYearFrom { get; set; }
            public int FinancialYearTo { get; set; }
            public bool IsActive { get; set; }
            public bool IsApproved { get; set; }
            public bool IsCanceled { get; set; }
            public bool IsConfirm { get; set; }
            public bool IsDeleted { get; set; }
            public DateTime OrderDate { get; set; }
            public string OrderNo { get; set; }
            public string SalesmanCode { get; set; }
            public string SpInstruction { get; set; }
            public string UpdatedBy { get; set; }
            public string xmlstr { get; set; }
        }

        public void SaveSpecimanNew(SpecimenDCNew reqprop, out int DocNo)//out int DocNewNo
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_SpecimenMasterDetails",
                CreateParameter("@DocumentNo", SqlDbType.Int, reqprop.DocumentNo),
                CreateParameter("@DocumentDate", SqlDbType.DateTime, reqprop.DocumentDate),
                CreateParameter("@ChallanNo", SqlDbType.VarChar, reqprop.ChallanNo),
                CreateParameter("@ChallanDate", SqlDbType.DateTime, reqprop.ChallanDate),
                CreateParameter("@OrderNo", SqlDbType.VarChar, reqprop.OrderNo),
                CreateParameter("@OrderDate", SqlDbType.DateTime, reqprop.OrderDate),
                CreateParameter("@SalesmanCode", SqlDbType.VarChar, reqprop.SalesmanCode),
                CreateParameter("@SpInstruction", SqlDbType.VarChar, reqprop.SpInstruction),
                CreateParameter("@CreatedBy", SqlDbType.VarChar, reqprop.CreatedBy),
                CreateParameter("@IsActive", SqlDbType.Bit, reqprop.IsActive),
                CreateParameter("@IsDeleted", SqlDbType.Bit, reqprop.IsDeleted),
                CreateParameter("@Description", SqlDbType.VarChar, reqprop.Description),
                CreateParameter("@FY", SqlDbType.Int, reqprop.FinancialYearFrom),
                CreateParameter("@Xmldata", SqlDbType.Xml, reqprop.xmlstr),
                CreateParameter("@DocNo", SqlDbType.Int, 0, ParameterDirection.Output));
            DocNo = Convert.ToInt32(cmd.Parameters["@DocNo"].Value);
        }
        #endregion

        #region Speciman Ledger Report
        public static DataSet ReportSpecimanLedger(string SalesmanCode, int FY, string BookSetCode, string FromDate, string ToDate, string Flag, string Flag1)
        {
            return new OtherBAL().SpecimanLedgerReport(SalesmanCode, FY, BookSetCode, FromDate, ToDate, Flag, Flag1);
        }
        public DataSet SpecimanLedgerReport(string SalesmanCode, int FY, string BookSetCode, string FromDate, string ToDate, string Flag, string Flag1)
        {
            return ExecuteDataSet("SpecimanLedger_Report",
                CreateParameter("@SalesmanCode", SqlDbType.VarChar, SalesmanCode),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@BookSetCode", SqlDbType.VarChar, BookSetCode),
                CreateParameter("@FromDate", SqlDbType.VarChar, FromDate),
                CreateParameter("@ToDate", SqlDbType.VarChar, ToDate),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region Get Return Speciman

        public static DataSet SpecimanReturn(string Salesman, int FY, int BooksetId, string srate, string Flag, string Flag1)
        {
            return new OtherBAL().GetSpecimanReturn(Salesman, FY, BooksetId, srate, Flag, Flag1);
        }

        public DataSet GetSpecimanReturn(string Salesman, int FY, int BooksetId, string srate, string Flag, string Flag1)
        {
            return ExecuteDataSet("Idv_Chetana_Speciman_Return",
                CreateParameter("@Salesman", SqlDbType.VarChar, Salesman),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@BooksetId", SqlDbType.Int, BooksetId),
                CreateParameter("@srate", SqlDbType.VarChar, srate),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag),
                CreateParameter("@Flag1", SqlDbType.VarChar, Flag1));
        }

        #endregion

        #region Speciman Return Save
        public class SpecimanCN
        {
            public int DocumentNo { get; set; }
            public int GCN { get; set; }
            public int SCN { get; set; }
            public DateTime CNDate { get; set; }
            public string SalesmanId { get; set; }
            public string TrasportCode { get; set; }
            public int LrNo { get; set; }
            public string SpInstruction { get; set; }
            public int BooksetId { get; set; }
            public int BooksetQty { get; set; }
            public string XmlData { get; set; }
            public string CreatedBy { get; set; }
            public int FY { get; set; }

        }
        public void SaveReturnSpeciman(SpecimanCN reqprop, out int docno)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_SpecimanCNSave",
                CreateParameter("@DocumentNo", SqlDbType.Int, reqprop.DocumentNo),
                CreateParameter("@GCN", SqlDbType.Int, reqprop.GCN),
                CreateParameter("@SCN", SqlDbType.Int, reqprop.SCN),
                CreateParameter("@CNDate", SqlDbType.DateTime, reqprop.CNDate),
                CreateParameter("@LRNo", SqlDbType.Int, reqprop.LrNo),
                CreateParameter("@FY", SqlDbType.Int, reqprop.FY),
                CreateParameter("@SalesmanCode", SqlDbType.VarChar, reqprop.SalesmanId),
                CreateParameter("@BooksetId", SqlDbType.Int, reqprop.BooksetId),
                CreateParameter("@BooksetQty", SqlDbType.Int, reqprop.BooksetQty),
                CreateParameter("@TransportCode", SqlDbType.VarChar, reqprop.TrasportCode),
                CreateParameter("@SpInstruction", SqlDbType.VarChar, reqprop.SpInstruction),
                CreateParameter("@CreatedBy", SqlDbType.VarChar, reqprop.CreatedBy),
                CreateParameter("@xmldata", SqlDbType.Xml, reqprop.XmlData),
                CreateParameter("@docno", SqlDbType.Int, 0, ParameterDirection.Output));
            docno = Convert.ToInt32(cmd.Parameters["@docno"].Value);
        }
        #endregion

        #region Speciman Return Print
        public static DataSet SpecimanReturnPrint(int FY, int docno, string Flag, string Flag1)
        {
            return new OtherBAL().PrintSpecimanReturn(FY, docno, Flag, Flag1);
        }
        public DataSet PrintSpecimanReturn(int FY, int docno, string Flag, string Flag1)
        {
            return ExecuteDataSet("Idv_Chetana_SpecimanCNPrint",
                CreateParameter("@docNo", SqlDbType.Int, docno),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@flag", SqlDbType.VarChar, Flag),
                CreateParameter("@flag1", SqlDbType.VarChar, Flag1));
        }
        #endregion

        #region Get Scheme Report
        public static DataSet Report_scheme(int custid, string fromdate, string todate, int fy, int superduperzone, int superzone, int zone, string flag, int schemeid, string custcateid)
        {
            return new OtherBAL().Scheme_Report(custid, fromdate, todate, fy, superduperzone, superzone, zone, flag, schemeid, custcateid);
        }
        public DataSet Scheme_Report(int custid, string fromdate, string todate, int fy, int superduperzone, int superzone, int zone, string flag, int schemeid, string custcateid)
        {
            return ExecuteDataSet("Idv_Chetana_Rep_Scheme_Revised",
                CreateParameter("@CustID", SqlDbType.Int, custid),
                CreateParameter("@FromDate", SqlDbType.VarChar, fromdate),
                CreateParameter("@ToDate", SqlDbType.VarChar, todate),
                CreateParameter("@FY", SqlDbType.Int, fy),
                CreateParameter("@SuperDuperzone", SqlDbType.Int, superduperzone),
                CreateParameter("@Superzone", SqlDbType.Int, superzone),
                CreateParameter("@Zone", SqlDbType.Int, zone),
                CreateParameter("@Flag", SqlDbType.VarChar, flag),
                CreateParameter("@schemeID", SqlDbType.Int, schemeid),
                CreateParameter("@CustCateID", SqlDbType.VarChar, custcateid));
        }
        #endregion

        #region Email Log Insert And Update

        public void SaveEmailLog(string xmldata, string flag1, string flag2, string flag3)
        {
            ExecuteNonQuery("EmailLog_Save",
                CreateParameter("@xmldata", SqlDbType.Xml, xmldata),
                CreateParameter("@flag1", SqlDbType.NVarChar, flag1),
                CreateParameter("@flag2", SqlDbType.NVarChar, flag2),
                CreateParameter("@flag3", SqlDbType.NVarChar, flag3));
        }

        #endregion

        #region Auto Invoice email

        public static DataSet GetInvoiceLog(string Cretedby, string flag1, string flag2, string flag3)
        {
            return new OtherBAL().GetInvoiceMail(Cretedby, flag1, flag2, flag3);
        }

        public DataSet GetInvoiceMail(string Cretedby, string flag1, string flag2, string flag3)
        {
            return ExecuteDataSet("SendInvoice",
            CreateParameter("@createdby", SqlDbType.NVarChar, Cretedby),
            CreateParameter("@flag1", SqlDbType.NVarChar, flag1),
            CreateParameter("@flag2", SqlDbType.NVarChar, flag2),
            CreateParameter("@flag3", SqlDbType.NVarChar, flag3));
        }

        public void UpdateEmailLog(string xmldata, string flag1, string flag2, string flag3)
        {
            ExecuteNonQuery("UpdateEmailLog",
            CreateParameter("@xmldata", SqlDbType.Xml, xmldata),
            CreateParameter("@flag1", SqlDbType.NVarChar, flag1),
            CreateParameter("@flag2", SqlDbType.NVarChar, flag2),
            CreateParameter("@flag3", SqlDbType.NVarChar, flag3));
        }

        #endregion

        #region Update Customer Master SplitDC

        public void UpdateCustomermaster(string xmldata, string flag1, string flag2, string flag3)
        {
            ExecuteNonQuery("ImportCustomerSplit",
                CreateParameter("@xmldata", SqlDbType.Xml, xmldata),
                CreateParameter("@flag1", SqlDbType.NVarChar, flag1),
                CreateParameter("@flag2", SqlDbType.NVarChar, flag2),
                CreateParameter("@flag3", SqlDbType.NVarChar, flag3));
        }

        #endregion

        #region Bank Check List Report

        public static DataSet GetCheckList(string Code, DateTime Fdate, DateTime Tdate, int FY, int superid, int zoneid, string Flag, string flag1, string flag2, string flag3)
        {
            return new OtherBAL().GetBankCheckList(Code, Fdate, Tdate, FY, superid, zoneid, Flag, flag1, flag2, flag3);
        }

        public DataSet GetBankCheckList(string Code, DateTime Fdate, DateTime Tdate, int FY, int superid, int zoneid, string Flag, string flag1, string flag2, string flag3)
        {
            return ExecuteDataSet("Idv_Chetana_Get_Bank_Checklist",
                base.CreateParameter("@BankCode", SqlDbType.NVarChar, Code),
                base.CreateParameter("@fromDate", SqlDbType.DateTime, Fdate),
                base.CreateParameter("@toDate", SqlDbType.DateTime, Tdate),
                base.CreateParameter("@Fy", SqlDbType.Int, FY),
                base.CreateParameter("@flag", SqlDbType.NVarChar, Flag),
                base.CreateParameter("@superzone", SqlDbType.Int, superid),
                base.CreateParameter("@zone", SqlDbType.Int, zoneid),
                base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1),
                base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2),
                base.CreateParameter("@flag3", SqlDbType.NVarChar, flag3));
        }
        #endregion
    }
}
