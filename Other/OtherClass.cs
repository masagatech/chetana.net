using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Idv.Chetana.Common;
using System.Data;
using System.Data.SqlClient;
using Idv.Chetana.DAL;


namespace Others
{
    public class OtherClass : DataServiceBase
    {
        #region Private Fields
        private float _SCMasterAutoId = Constants.NullFloat;
        private float _DocumentNo = Constants.NullFloat;
        private float _InvoiceNo = Constants.NullFloat;
        private int _SCD = Constants.NullInt;
        private int _POD = Constants.NullInt;
        private int _GeneralCourierID = Constants.NullInt;
        private decimal _Weight = Constants.NullDecimal;
        private DateTime _courierdate = Constants.NullDateTime;

        public DateTime Courierdate
        {
            get { return _courierdate; }
            set { _courierdate = value; }
        }
        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }


        public int GeneralCourierID
        {
            get { return _GeneralCourierID; }
            set { _GeneralCourierID = value; }
        }
        private bool _IsActive = Constants.NullBoolean;

        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }


        public int POD
        {
            get { return _GeneralCourierID; }
            set { _GeneralCourierID = value; }
        }
        public int SCD
        {
            get { return _SCD; }
            set { _SCD = value; }
        }
        public float SCMasterAutoId
        {
            get { return _SCMasterAutoId; }
            set { _SCMasterAutoId = value; }
        }
        public float DocumentNo
        {
            get { return _DocumentNo; }
            set { _DocumentNo = value; }
        }
        public float InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value; }
        }


        private string _CreatedBy = Constants.NullString;
        private string _UpDateBy = Constants.NullString;

        public string UpDateBy
        {
            get { return _UpDateBy; }
            set { _UpDateBy = value; }
        }
        #endregion
        #region Public Properties
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        #endregion
        //#region SepeimenDetailsForInvoice_Bookwise
        //public static DataSet Get_SpecimenDetailsForInvoice_Bookwise(string bookCode2, string BookCode, DateTime fromdate, DateTime todate)
        //{
        //    DataSet ds = new OtherClass().Get_SpecimenDetailsForInvoice_BookWise(bookCode2, BookCode, fromdate, todate);
        //    return ds;
        //}
        //#endregion

        //#region SepeimenDetailsForInvoice_Bookwise
        //public DataSet Get_SpecimenDetailsForInvoice_BookWise(string bookCode2, string BookCode, DateTime fromdate, DateTime todate)
        //{
        //    return ExecuteDataSet("Idv_Chetana_Get_SpecimenDetailsForInvoice_Bookwise",
        //                CreateParameter("@bookCode2", SqlDbType.NVarChar, bookCode2),
        //                CreateParameter("bookcode", SqlDbType.NVarChar, BookCode),
        //                CreateParameter("@fromdate", SqlDbType.DateTime, fromdate),
        //                CreateParameter("@todate", SqlDbType.DateTime, todate)
        //   );
        //}
        //#endregion


        public static DataSet Idv_Chetana_Stock_Ledger_Report(string CustCode, DateTime FromDate, DateTime ToDate, int FY)
        {
            return new OtherClass().Idv_Chetana_Customer_Ledger_Report(CustCode, FromDate, ToDate, FY);
        }

        public DataSet Idv_Chetana_Customer_Ledger_Report(string BookCode, DateTime FromDate, DateTime ToDate, int FY)
        {
            return ExecuteDataSet("IDV_Chetana_REP_STOCKLEDGER",
                CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode),
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
                CreateParameter("@FY", SqlDbType.Int, FY));
        }

        public static DataSet Get_Bank_Ballance(string Code, int Frommonth, int FY, decimal OpenBal, string flag)
        {
            return new OtherClass().Get_Bank_Balance(Code, Frommonth, FY, OpenBal, flag);
        }

        public DataSet Get_Bank_Balance(string Code, int Frommonth, int FY, decimal OpenBal, string flag)
        {
            return ExecuteDataSet("idv_Chetana_Get_Bank_Reco_Sum",
                   CreateParameter("@BankCode", SqlDbType.NVarChar, Code),
                   CreateParameter("@frommonth", SqlDbType.Int, Frommonth),
                   CreateParameter("@FY", SqlDbType.Int, FY),
                   CreateParameter("@openingBalance", SqlDbType.Decimal, OpenBal),
                   CreateParameter("@flag", SqlDbType.NVarChar, flag));
        }

        #region AuditLock
        //Usha

        public void SaveAudit(string FinY, int FY, DateTime CutoffDate)
        {
            new OtherClass().Idv_chetana_Save_AuditCutOff(FinY, FY, CutoffDate);
        }

        public void Idv_chetana_Save_AuditCutOff(string FinY, int FY, DateTime CutoffDate)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_chetana_Save_AuditCutOffDate",
                CreateParameter("@FinY", SqlDbType.NVarChar, FinY),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@CutoffDate", SqlDbType.DateTime, CutoffDate));
            cmd.Dispose();
        }

        public static DataSet Get_IsEditable(string Case, int DocNo,int FY)
        {
            return new OtherClass().Idv_Chetana_GetIsEditable(Case, DocNo,FY);
        }
        public DataSet Idv_Chetana_GetIsEditable(string Case, int DocNo,int FY)
        {
            return ExecuteDataSet("Idv_Chetana_GetIsEditableBit",
                   CreateParameter("@Case", SqlDbType.NVarChar, Case),
                   CreateParameter("@DocNo", SqlDbType.Int, DocNo),
                   CreateParameter("@FY", SqlDbType.Int, FY));
        }

        public static DataSet GetInitialData(string Data1, string Data2, string Data3, string Data4, string Data5, string Case, int FY)
        {
            return new OtherClass().Idv_Chetana_GetInitialData_Fun(Data1, Data2, Data3, Data4, Data5, Case, FY);
        }
        public DataSet Idv_Chetana_GetInitialData_Fun(string Data1, string Data2, string Data3, string Data4, string Data5, string Case, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_GetInitialData",
                 CreateParameter("@Data1", SqlDbType.NVarChar, Data1),
                  CreateParameter("@Data2", SqlDbType.NVarChar, Data2),
                   CreateParameter("@Data3", SqlDbType.NVarChar, Data3),
                    CreateParameter("@Data4", SqlDbType.NVarChar, Data4),
                     CreateParameter("@Data5", SqlDbType.NVarChar, Data5),
                    CreateParameter("@Case", SqlDbType.NVarChar, Case),
                    CreateParameter("@FY", SqlDbType.Int, FY));

        }

        #endregion

        #region CourierDetails
        public static DataSet GetCourier(string flag)
        {
            return new OtherClass().GetCourier1(flag);
        }

        public DataSet GetCourier1(string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_CourierData",
            CreateParameter("@Flag", SqlDbType.NVarChar, Flag));
        }

        public static DataSet GetCourierValidation(string Group, string code)
        {
            return new OtherClass().GetCourierValidation1(Group, code);
        }
        public DataSet GetCourierValidation1(string Group, string code)
        {
            return ExecuteDataSet("Idv_Chetana_Get_Validate_If_Exists",
                CreateParameter("@Group", SqlDbType.NVarChar, Group),
                CreateParameter("@code", SqlDbType.NVarChar, code));
        }
        public void Save(string DocNo, string flag, int FY, int CourierID, int BranchID, string BranchAdd, string Department, string Address, string Remark1, string CreatedBy, string Weight, DateTime Courierdate, out int _SCD)
        {

            new OtherClass().SaveCourierDetails(DocNo, flag, FY, CourierID, BranchID, BranchAdd, Department, Address, Remark1, CreatedBy, Weight, Courierdate, out _SCD);
        }
        public void SaveCourierDetails(string DocNo, string flag, int FY, int CourierID, int BranchID, string BranchAdd, string Department, string Address, string Remark1, string CreatedBy, string Weight, DateTime Courierdate, out int SCD)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_CourierDetails",
                 CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY),
                   CreateParameter("@CourierID", SqlDbType.Int, CourierID),
                   CreateParameter("@BranchID", SqlDbType.Int, BranchID),
                   CreateParameter("@BranchAdd", SqlDbType.NVarChar, BranchAdd),
                 CreateParameter("@Department", SqlDbType.NVarChar, Department),
                  CreateParameter("@Address", SqlDbType.NVarChar, Address),
                 CreateParameter("@Remark1", SqlDbType.NVarChar, Remark1),
                  CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                    CreateParameter("@Weight", SqlDbType.NVarChar, Weight),
                      CreateParameter("@courierdate", SqlDbType.DateTime, Courierdate),

                  CreateParameter("@SCD", SqlDbType.Int, ParameterDirection.Output)
             );
            SCD = Convert.ToInt32(cmd.Parameters["@SCD"].Value);
            cmd.Dispose();
        }
        public void SaveCourierDetail(string DocNo, string flag, int FY, int CourierID, int BranchID, string Address, string CreatedBy, out int SCD)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_CourierDetails",
                 CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY),
                   CreateParameter("@CourierID", SqlDbType.Int, CourierID),
                   CreateParameter("@BranchID", SqlDbType.Int, BranchID),


                  CreateParameter("@Address", SqlDbType.NVarChar, Address),

                  CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),


                  CreateParameter("@SCD", SqlDbType.Int, ParameterDirection.Output)
             );
            SCD = Convert.ToInt32(cmd.Parameters["@SCD"].Value);
            cmd.Dispose();
        }

        public static DataSet Get_CourierDetailsGeneral(string DocNo, string flag, int FY)
        {
            return new OtherClass().Get_CourierDetailsGeneral1(DocNo, flag, FY);
        }
        public DataSet Get_CourierDetailsGeneral1(string DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_SendCourierGeneral",
                CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public static DataSet GetCourierBranch(int DocID, string flag)
        {
            return new OtherClass().GetCourierBranch1(DocID, flag);
        }
        public DataSet GetCourierBranch1(int DocID, string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_CourierData",
                 CreateParameter("@DocID", SqlDbType.Float, DocID),
                 CreateParameter("@Flag", SqlDbType.NVarChar, Flag));
        }
        public static DataSet Get_CourierDetails(float DocNo, string flag, int FY)
        {
            return new OtherClass().Get_CourierDetails1(DocNo, flag, FY);
        }
        public DataSet Get_CourierDetails1(float DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_CourierDetails",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public static DataSet Get_CourierDetailsCheck(string DocNo, string flag, int FY)
        {
            return new OtherClass().Get_CourierDetailsCheck1(DocNo, flag, FY);
        }
        public DataSet Get_CourierDetailsCheck1(string DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_CourierDetails",
                CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public static DataSet UpdatePOD(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return new OtherClass().UpdatePOD1(DocNo, FromDate, ToDate, Branch, CourierCompany, flag, FY);
        }
        public DataSet UpdatePOD1(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_ChetanaUpdatePOD",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate),
                  CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate),
                  CreateParameter("@Branch", SqlDbType.NVarChar, Branch),
                  CreateParameter("@Courier", SqlDbType.NVarChar, CourierCompany),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public void UpdatePODNo(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {

            new OtherClass().UpdatePODNo1(SCMasterAutoId, DocumentNo, InvoiceNo, flag, No, FY);
        }
        public DataSet UpdatePODNo1(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_UpdatePODNo",
                CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId),
                 CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo),
                  CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@No", SqlDbType.Int, No),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public void DeletePOD(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {

            new OtherClass().DeletePOD1(SCMasterAutoId, flag, IsActive, UpDateBy, GeneralCourierID, FY);
        }
        public DataSet DeletePOD1(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_deltePOD",
                CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId),
                CreateParameter("@flag", SqlDbType.NVarChar, flag),
                CreateParameter("@IsActive", SqlDbType.Bit, IsActive),
                CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy),
                CreateParameter("@GeneralCourierID", SqlDbType.Int, GeneralCourierID),
                CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public static DataSet ViewCourier(float DocNo, string flag, int FY)
        {
            return new OtherClass().ViewCourier1(DocNo, flag, FY);
        }
        public DataSet ViewCourier1(float DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_ViewCourier",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public static DataSet ViewCourierDate(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return new OtherClass().ViewCourierDate1(DocNo, FromDate, ToDate, Branch, CourierCompany, flag, FY);
        }
        public DataSet ViewCourierDate1(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_ViewCourier",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                  CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate),
                  CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate),
                  CreateParameter("@Branch", SqlDbType.NVarChar, Branch),
                  CreateParameter("@Courier", SqlDbType.NVarChar, CourierCompany),
                  CreateParameter("@flag", SqlDbType.NVarChar, flag),
                  CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public void Savecourier(string DocNo, string flag, int FY, int CourierID, int BranchID, string Address, string CreatedBy, out int _SCD)
        {
            new OtherClass().SaveCourierDetail(DocNo, flag, FY, CourierID, BranchID, Address, CreatedBy, out _SCD);
        }
        public void DeleteSendcourier(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {

            new OtherClass().DeleteSendcourier1(SCMasterAutoId, IsActive, UpDateBy, FY);
        }
        public DataSet DeleteSendcourier1(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_DeleteSendCourier",
                CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId),
                CreateParameter("@IsActive", SqlDbType.Bit, IsActive),
                CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy),
                CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public static DataSet Get_CourierDetailsCheckSave(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
            return new OtherClass().Get_CourierDetailsCheckSave1(DocNo, flag, CourierID, BranchID, FY);
        }
        public DataSet Get_CourierDetailsCheckSave1(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_CourierDetailsSave",
                CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                  CreateParameter("@CourierID", SqlDbType.Int, CourierID),
                   CreateParameter("@BranchID", SqlDbType.Int, BranchID),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public void SaveDispatchEmailDetails(int DocNo, string flag, int FY, string CreatedBy, out int _SCD)
        {

            new OtherClass().SaveDispatchEmailDetails1(DocNo, flag, FY, CreatedBy, out _SCD);
        }
        public void SaveDispatchEmailDetails1(int DocNo, string flag, int FY, string CreatedBy, out int SCD)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_DispatchEmail",
                 CreateParameter("@DocNo", SqlDbType.Int, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY),
                 CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy),
                  CreateParameter("@SCD", SqlDbType.Int, ParameterDirection.Output)
             );
            SCD = Convert.ToInt32(cmd.Parameters["@SCD"].Value);
            cmd.Dispose();
        }
        public static DataSet SendCourierPrint(float DocNo, string flag, int FY)
        {
            return new OtherClass().SendCourierPrint1(DocNo, flag, FY);
        }
        public DataSet SendCourierPrint1(float DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_SendCourierPrint",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public static DataSet SendCourierEmail(float DocNo, string flag1, string flag2, int FY)
        {
            return new OtherClass().SendCourierEmail1(DocNo, flag1, flag2, FY);
        }
        public DataSet SendCourierEmail1(float DocNo, string flag1, string flag2, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_SendCourierEmail",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                CreateParameter("@flag1", SqlDbType.NVarChar, flag1),
                CreateParameter("@flag2", SqlDbType.NVarChar, flag2),
                CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public static DataSet SendCourierEmail(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return new OtherClass().SendCourierEmail1(SCMasterAutoId, DocumentNo, InvoiceNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }
        public DataSet SendCourierEmail1(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return ExecuteDataSet("Idv_Chetana_SendCourierEmail",
                CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId),
                 CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo),
                  CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo),
                CreateParameter("@flag1", SqlDbType.NVarChar, flag1),
                CreateParameter("@flag2", SqlDbType.NVarChar, flag2),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@FromID", SqlDbType.NVarChar, FromID),
                 CreateParameter("@PWD", SqlDbType.NVarChar, PWD),
                  CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy));


        }
        public static DataSet SendDispatchEmail(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return new OtherClass().SendDispatchEmail1(SCMasterAutoId, DocumentNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }
        public DataSet SendDispatchEmail1(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return ExecuteDataSet("Idv_Chetana_SendDispatchEmail",
                CreateParameter("@DispatchMasterAutoId", SqlDbType.Float, SCMasterAutoId),
                 CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo),
                //CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo),
                CreateParameter("@flag1", SqlDbType.NVarChar, flag1),
                CreateParameter("@flag2", SqlDbType.NVarChar, flag2),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@FromID", SqlDbType.NVarChar, FromID),
                 CreateParameter("@PWD", SqlDbType.NVarChar, PWD),
                  CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy)
                );

        }
        //public static DataSet Get_CourierDetailsGeneral(string DocNo, string flag, int FY)
        //{
        //    return new OtherClass().Get_CourierDetailsGeneral1(DocNo, flag, FY);
        //}
        public static DataSet SendCourierPrintGeneral(float DocNo, string flag, int FY)
        {
            return new OtherClass().SendCourierPrintGeneral1(DocNo, flag, FY);
        }
        public DataSet SendCourierPrintGeneral1(float DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_SendCourierPrint",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }

        #endregion




        //Usha14/08/15

        public static DataSet Get_Bookwise_DC_Rep1(string BookCode, DateTime FromDate, DateTime ToDate,int SDZone,int SZone)
        {
            return new OtherClass().Get_Bookwise_DC_Rep(BookCode, FromDate, ToDate,SDZone,SZone);
        }
        public DataSet Get_Bookwise_DC_Rep(string BookCode, DateTime FromDate, DateTime ToDate, int SDZone, int SZone)
        {
            return ExecuteDataSet("Idv_Chetana_Bookwise_DC_Report",
                     CreateParameter("@BookCode", SqlDbType.NVarChar, BookCode),
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
                CreateParameter("@SDZone", SqlDbType.Int, SDZone),
                CreateParameter("@SZone", SqlDbType.Int, SZone));
        }
        //Usha 14/09/2015
        public static DataSet Get_Booktypewise_DC_Rep1(string Booktype, DateTime FromDate, DateTime ToDate, int SDZone, int SZone)
        {
            return new OtherClass().Get_Booktypewise_DC_Rep(Booktype, FromDate, ToDate, SDZone, SZone);
        }
        public DataSet Get_Booktypewise_DC_Rep(string Booktype, DateTime FromDate, DateTime ToDate, int SDZone, int SZone)
        {
            return ExecuteDataSet("Idv_Chetana_Booktype_DC_Report",
                CreateParameter("@Booktype", SqlDbType.NVarChar, Booktype),
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
                CreateParameter("@SDZone", SqlDbType.Int, SDZone),
                CreateParameter("@SZone", SqlDbType.Int, SZone));
        }
        

        //Usha 12Aug15
        public static DataSet Get_Order_Compare(int SDZone, int Superzone, int zone, int CustID, int FY, string month)
        {
            return new OtherClass().Get_Order_Compare1(SDZone, Superzone, zone, CustID, FY, month);
        }
        public DataSet Get_Order_Compare1(int SDZone, int Superzone, int Zone, int CustID, int FY, string  month)
        {
            return ExecuteDataSet("idv_chetana_REP_Order_Comparision",
                   CreateParameter("@SDZone", SqlDbType.Int, SDZone),
                   CreateParameter("@Superzone", SqlDbType.Int, Superzone),
                   CreateParameter("@Zone", SqlDbType.Int, Zone),
                   CreateParameter("@CustID", SqlDbType.Int, CustID),
                   CreateParameter("@FY", SqlDbType.Int, FY),
                    CreateParameter("@Months", SqlDbType.NVarChar, month));

        }
        public static DataSet GetFY(int strFY)
        {
            return new OtherClass().GetFY1(strFY);
        }

        public DataSet GetFY1(int strFY)
        {
            return ExecuteDataSet("Idv_Chetana_Get_FY",
                CreateParameter("@FY", SqlDbType.Int, strFY));
        }


        public DataSet CustEmail_LocalEntry(int CustID)
        {
            return ExecuteDataSet("Idv_Chetana_Get_CustEmail_LocalEntry",
            CreateParameter("@CustId", SqlDbType.Int, CustID));
        }

        public static DataSet Get_CustomerDiscountBy_BookType(string Custcode, int FY, string flag1, string flag2)
        {
            return new OtherClass().Get_CustomerDiscountBy_BookType1(Custcode, FY, flag1, flag2);
        }

        public DataSet Get_CustomerDiscountBy_BookType1(string Custcode, int FY, string flag1, string flag2)
        {
            return ExecuteDataSet("Idv_Chetana_Get_CustomerDiscountBy_BookType",
            CreateParameter("@CustCode", SqlDbType.NVarChar, Custcode),
            CreateParameter("@FY", SqlDbType.Int, FY),
            CreateParameter("@Flag1", SqlDbType.NVarChar, flag1),
            CreateParameter("@Flag2", SqlDbType.NVarChar, flag2));
        }

        public static DataSet Get_Bank_ReconsileData(string Code, int Frommonth, int FY)
        {
            return new OtherClass().Get_Bank_ReconsileDataDAL(Code, Frommonth, FY);
        }

        // function to retrive recosileddata of the given month

        public DataSet Get_Bank_ReconsileDataDAL(string Code, int Frommonth, int FY)
        {
            return ExecuteDataSet("idv_Chetana_Get_Bank_ReconsiledData",
                   CreateParameter("@BankCode", SqlDbType.NVarChar, Code),
                   CreateParameter("@frommonth", SqlDbType.Int, Frommonth),
                   CreateParameter("@FY", SqlDbType.Int, FY));
        }


        #region OrderValuation
            public static DataSet Get_OrderValuation_SummaryExcel(DateTime FromDate, DateTime ToDate,int SDZone, int SZone,int Zone, int FY)
            {
                return new OtherClass().Get_OrderValuation_SummaryExcelD(FromDate,ToDate,SDZone,SZone,Zone,FY);
            }
            public DataSet Get_OrderValuation_SummaryExcelD(DateTime FromDate, DateTime ToDate, int SDZone, int SZone, int Zone, int FY)
            {
                return ExecuteDataSet("Idv_Chetana_Rep_Get_Dasboard_ForOrderValuation_SummaryExcel",
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
                CreateParameter("@SDZone", SqlDbType.Int, SDZone),
                CreateParameter("@SZone", SqlDbType.Int,SZone),
                CreateParameter("@Zone", SqlDbType.Int,Zone),
                CreateParameter("@FY", SqlDbType.Int, FY));
            }

        #endregion

        #region Get Customer Data for Export purpose

        public static DataTable Get_CustomerData_For_Export(string Flag, string CustCategoryID, string SuperDuperZoneID, string ZoneID)
        {
            return new OtherClass().Get_CustListDAL(Flag, CustCategoryID, SuperDuperZoneID, ZoneID).Tables[0];
        }


        public DataSet Get_CustListDAL(string Flag, string CustCategoryID, string SuperDuperZoneID, string ZoneID)
        {
            return ExecuteDataSet("Idv_Chetana_Get_CustomerMaster_Details_flag",
                CreateParameter("@flag", SqlDbType.NVarChar, Flag),
                CreateParameter("@CustCateID", SqlDbType.NVarChar, CustCategoryID),
                CreateParameter("@ID", SqlDbType.NVarChar, SuperDuperZoneID),
                CreateParameter("@ZoneID", SqlDbType.NVarChar, ZoneID));
        }

        #endregion


        public static DataSet Idv_Chetana_Report_ReceiptDatewise(DateTime FromDate, DateTime ToDate)
        {
            return new OtherClass().Idv_Chetana_Report_Receipt_BookDatewise(FromDate, ToDate);
        }


        public DataSet Idv_Chetana_Report_Receipt_BookDatewise(DateTime FromDate, DateTime ToDate)
        {
            return ExecuteDataSet("Idv_Chetana_Report_ReceiptBookDatewise",
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate));

        }

    }
}
