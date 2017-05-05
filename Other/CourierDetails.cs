using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Idv.Chetana.Common;
using Idv.Chetana.DAL;
using System.Data.SqlClient;

namespace Others
{
    public class CourierDetails : DataServiceBase
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

        #region Courier Details BAL
        
        public static DataSet Get_CourierDetailsBAL(float DocNo, string flag, int FY)
        {
            return new CourierDetails().Get_CourierDetails(DocNo, flag, FY);
        }
        //public static DataSet Get_CourierDetailsCheckBAL(string DocNo, string flag, int FY)
        //{
        //    return new CourierDetails().Get_Invoice_OnDateChecklist(DocNo, flag, FY);
        //}
        //public static DataSet Get_CourierDetailsCheckBAL(string flag, int FY)
        //{
        //    return new CourierDetails().Get_Invoice_OnDateChecklist(flag, FY);
        //}
        public static DataSet Get_CourierDetailsCheckSaveBAL(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
             return new CourierDetails().Get_CourierDetailsCheckSave(DocNo, flag, CourierID, BranchID, FY);
        }

        public void SaveDispatchEmailDetailsBAL(int DocNo, string flag, int FY, string CreatedBy, out int _SCD)
        {

            new CourierDetails().SaveDispatchEmailDetails(DocNo, flag, FY, CreatedBy, out _SCD);
        }
        public static DataSet UpdatePODBAL(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
             return new CourierDetails().UpdatePOD(DocNo, FromDate, ToDate, Branch, CourierCompany, flag, FY);
        }
        public static DataSet ViewCourierBAL(float DocNo, string flag, int FY)
        {
             return new CourierDetails().ViewCourier(DocNo, flag, FY);
        }
        public static DataSet ViewCourierDateBAL(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
             return new CourierDetails().ViewCourierDate(DocNo,FromDate, ToDate, Branch,CourierCompany, flag, FY);
        }
        public static DataSet GetCourierValidationBAL(string Group, string code)
        {
             return new CourierDetails().GetCourierValidation(Group, code);
        }
        public void UpdatePODNoBAL(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {

            new CourierDetails().UpdatePODNo(SCMasterAutoId, DocumentNo, InvoiceNo, flag, No, FY);
        }
        public void DeletePODBAL(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {

            new CourierDetails().DeletePOD(SCMasterAutoId, flag, IsActive, UpDateBy, GeneralCourierID, FY);
        }
        public void DeleteSendcourierBAL(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {

            new CourierDetails().DeleteSendcourier(SCMasterAutoId, IsActive, UpDateBy, FY);
        }
        public static DataSet SendCourierPrintBAL(float DocNo, string flag, int FY)
        {
             return new CourierDetails().SendCourierPrint(DocNo, flag, FY);
        }
        public static DataSet SendCourierEmailBAL(float DocNo, string flag1, string flag2, int FY)
        {
             return new CourierDetails().SendCourierEmail(DocNo, flag1, flag2, FY);
        }
        public static DataSet SendCourierEmailBAL(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
             return new CourierDetails().SendCourierEmail(SCMasterAutoId, DocumentNo, InvoiceNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }
        public static DataSet SendDispatchEmailBAL(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
             return new CourierDetails().SendDispatchEmail(SCMasterAutoId, DocumentNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }
        public static DataSet GetCourierBAL(string flag)
        {
             return new CourierDetails().GetCourier( flag);
        }
        public static DataSet GetCourierBranchBAL(int DocID, string flag)
        {
             return new CourierDetails().GetCourierBranch(DocID, flag);
        }
        public void SaveBAL(string DocNo, string flag, int FY, int CourierID, int BranchID, string BranchAdd, string Department, string Address, string Remark1, string CreatedBy, string Weight, DateTime Courierdate, out int _SCD)
        {

            new CourierDetails().SaveCourierDetails(DocNo, flag, FY, CourierID, BranchID, BranchAdd, Department, Address, Remark1, CreatedBy, Weight, Courierdate, out _SCD);
        }

        public void SavecourierBAL(string DocNo, string flag, int FY, int CourierID, int BranchID, string Address, string CreatedBy, out int _SCD)
        {
            new CourierDetails().SaveCourierDetail(DocNo, flag, FY, CourierID, BranchID, Address, CreatedBy, out _SCD);
        }
        public static DataSet Get_CourierDetailsGeneralBAL(string DocNo, string flag, int FY)
        {
             return new CourierDetails().Get_CourierDetailsGeneral(DocNo, flag, FY);
        }
        public static DataSet SendCourierPrintGeneralBAL(float DocNo, string flag, int FY)
        {
             return new CourierDetails().SendCourierPrintGeneral(DocNo, flag, FY);
        }

        #endregion

        #region CourierDetails DAL part

        public void SaveDispatchEmailDetails(int DocNo, string flag, int FY, string CreatedBy, out int SCD)
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
        public DataSet Get_CourierDetails(float DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_CourierDetails",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public DataSet Get_CourierDetailsCheck(string DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_CourierDetails",
                CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public DataSet Get_CourierDetailsCheckSave(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_CourierDetailsSave",
                CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                  CreateParameter("@CourierID", SqlDbType.Int, CourierID),
                   CreateParameter("@BranchID", SqlDbType.Int, BranchID),
                 CreateParameter("@FY", SqlDbType.Int, FY));

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
        public DataSet UpdatePOD(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
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
        public DataSet ViewCourier(float DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_ViewCourier",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public DataSet ViewCourierDate(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
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
        public DataSet UpdatePODNo(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_UpdatePODNo",
                CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId),
                 CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo),
                  CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@No", SqlDbType.Int, No),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public DataSet DeletePOD(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_deltePOD",
                CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId),
                CreateParameter("@flag", SqlDbType.NVarChar, flag),
                CreateParameter("@IsActive", SqlDbType.Bit, IsActive),
                CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy),
                CreateParameter("@GeneralCourierID", SqlDbType.Int, GeneralCourierID),
                CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public DataSet DeleteSendcourier(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_DeleteSendCourier",
                CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId),
                CreateParameter("@IsActive", SqlDbType.Bit, IsActive),
                CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy),
                CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public DataSet GetCourierValidation(string Group, string code)
        {
            return ExecuteDataSet("Idv_Chetana_Get_Validate_If_Exists",
                CreateParameter("@Group", SqlDbType.NVarChar, Group),
                CreateParameter("@code", SqlDbType.NVarChar, code));
        }
        public DataSet SendCourierPrint(float DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_SendCourierPrint",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public DataSet SendCourierEmail(float DocNo, string flag1, string flag2, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_SendCourierEmail",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                CreateParameter("@flag1", SqlDbType.NVarChar, flag1),
                CreateParameter("@flag2", SqlDbType.NVarChar, flag2),
                CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public DataSet SendCourierEmail(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
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
                  CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy)
                );

        }
        public DataSet SendDispatchEmail(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
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
        public DataSet GetCourier(string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_CourierData",
                 CreateParameter("@Flag", SqlDbType.NVarChar, Flag));
        }
        public DataSet GetCourierBranch(int DocID, string Flag)
        {
            return ExecuteDataSet("Idv_Chetana_Get_CourierData",
                 CreateParameter("@DocID", SqlDbType.Float, DocID),
                 CreateParameter("@Flag", SqlDbType.NVarChar, Flag));
        }

        public DataSet Get_Invoice_OnDateChecklist(DateTime fromDate, DateTime todate)
        {
            return ExecuteDataSet("Idv_Chetana_Rep_Get_Invoice_OnDateChecklist",
                    CreateParameter("@fromdate", SqlDbType.DateTime, fromDate),
                    CreateParameter("@todate", SqlDbType.DateTime, todate));
        }

        public DataSet Get_Invoice_OnDateChecklist(string DocNo,DateTime fromDate, DateTime todate)
        {
            return ExecuteDataSet("Idv_Chetana_Rep_Get_Invoice_OnDateChecklist",
                    CreateParameter("@fromdate", SqlDbType.DateTime, fromDate),
                    CreateParameter("@todate", SqlDbType.DateTime, todate));
        }

        public DataSet Get_CourierDetailsGeneral(string DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_SendCourierGeneral",
                CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }
        public DataSet SendCourierPrintGeneral(float DocNo, string flag, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_SendCourierPrint",
                CreateParameter("@DocNo", SqlDbType.Float, DocNo),
                 CreateParameter("@flag", SqlDbType.NVarChar, flag),
                 CreateParameter("@FY", SqlDbType.Int, FY));

        }

        #endregion

    }

     
        
}
