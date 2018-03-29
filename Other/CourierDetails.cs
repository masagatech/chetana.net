namespace Others
{
    using Idv.Chetana.Common;
    using Idv.Chetana.DAL;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class CourierDetails : DataServiceBase
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

        public DataSet DeletePOD(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_deltePOD", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy), base.CreateParameter("@GeneralCourierID", SqlDbType.Int, GeneralCourierID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public void DeletePODBAL(float SCMasterAutoId, string flag, bool IsActive, string UpDateBy, int GeneralCourierID, int FY)
        {
            new CourierDetails().DeletePOD(SCMasterAutoId, flag, IsActive, UpDateBy, GeneralCourierID, FY);
        }

        public DataSet DeleteSendcourier(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_DeleteSendCourier", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@IsActive", SqlDbType.Bit, IsActive), base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, UpDateBy), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public void DeleteSendcourierBAL(float SCMasterAutoId, bool IsActive, string UpDateBy, int FY)
        {
            new CourierDetails().DeleteSendcourier(SCMasterAutoId, IsActive, UpDateBy, FY);
        }

        public DataSet Get_CourierDetails(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_CourierDetails", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet Get_CourierDetailsBAL(float DocNo, string flag, int FY)
        {
            return new CourierDetails().Get_CourierDetails(DocNo, flag, FY);
        }

        public DataSet Get_CourierDetailsCheck(string DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_CourierDetails", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet Get_CourierDetailsCheckSave(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_CourierDetailsSave", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@CourierID", SqlDbType.Int, CourierID), base.CreateParameter("@BranchID", SqlDbType.Int, BranchID), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet Get_CourierDetailsCheckSaveBAL(string DocNo, string flag, int CourierID, int BranchID, int FY)
        {
            return new CourierDetails().Get_CourierDetailsCheckSave(DocNo, flag, CourierID, BranchID, FY);
        }

        public DataSet Get_CourierDetailsGeneral(string DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierGeneral", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.NVarChar, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet Get_CourierDetailsGeneralBAL(string DocNo, string flag, int FY)
        {
            return new CourierDetails().Get_CourierDetailsGeneral(DocNo, flag, FY);
        }

        public DataSet Get_Invoice_OnDateChecklist(DateTime fromDate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_Invoice_OnDateChecklist", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet Get_Invoice_OnDateChecklist(string DocNo, DateTime fromDate, DateTime todate)
        {
            return base.ExecuteDataSet("Idv_Chetana_Rep_Get_Invoice_OnDateChecklist", new IDataParameter[] { base.CreateParameter("@fromdate", SqlDbType.DateTime, fromDate), base.CreateParameter("@todate", SqlDbType.DateTime, todate) });
        }

        public DataSet GetCourier(string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CourierData", new IDataParameter[] { base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public static DataSet GetCourierBAL(string flag)
        {
            return new CourierDetails().GetCourier(flag);
        }

        public DataSet GetCourierBranch(int DocID, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_CourierData", new IDataParameter[] { base.CreateParameter("@DocID", SqlDbType.Float, DocID), base.CreateParameter("@Flag", SqlDbType.NVarChar, Flag) });
        }

        public static DataSet GetCourierBranchBAL(int DocID, string flag)
        {
            return new CourierDetails().GetCourierBranch(DocID, flag);
        }

        public DataSet GetCourierValidation(string Group, string code)
        {
            return base.ExecuteDataSet("Idv_Chetana_Get_Validate_If_Exists", new IDataParameter[] { base.CreateParameter("@Group", SqlDbType.NVarChar, Group), base.CreateParameter("@code", SqlDbType.NVarChar, code) });
        }

        public static DataSet GetCourierValidationBAL(string Group, string code)
        {
            return new CourierDetails().GetCourierValidation(Group, code);
        }

        public void SaveBAL(string DocNo, string flag, int FY, int CourierID, int BranchID, string BranchAdd, string Department, string Address, string Remark1, string CreatedBy, string Weight, DateTime Courierdate, out int _SCD)
        {
            new CourierDetails().SaveCourierDetails(DocNo, flag, FY, CourierID, BranchID, BranchAdd, Department, Address, Remark1, CreatedBy, Weight, Courierdate, out _SCD);
        }

        public void SavecourierBAL(string DocNo, string flag, int FY, int CourierID, int BranchID, string Address, string CreatedBy, out int _SCD)
        {
            new CourierDetails().SaveCourierDetail(DocNo, flag, FY, CourierID, BranchID, Address, CreatedBy, out _SCD);
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

        public void SaveDispatchEmailDetails(int DocNo, string flag, int FY, string CreatedBy, out int SCD)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_DispatchEmail", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Int, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy), base.CreateParameter("@SCD", SqlDbType.Int, ParameterDirection.Output) });
            SCD = Convert.ToInt32(command.Parameters["@SCD"].Value);
            command.Dispose();
        }

        public void SaveDispatchEmailDetailsBAL(int DocNo, string flag, int FY, string CreatedBy, out int _SCD)
        {
            new CourierDetails().SaveDispatchEmailDetails(DocNo, flag, FY, CreatedBy, out _SCD);
        }

        public DataSet SendCourierEmail(float DocNo, string flag1, string flag2, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierEmail", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public DataSet SendCourierEmail(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierEmail", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo), base.CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromID", SqlDbType.NVarChar, FromID), base.CreateParameter("@PWD", SqlDbType.NVarChar, PWD), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public static DataSet SendCourierEmailBAL(float DocNo, string flag1, string flag2, int FY)
        {
            return new CourierDetails().SendCourierEmail(DocNo, flag1, flag2, FY);
        }

        public static DataSet SendCourierEmailBAL(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return new CourierDetails().SendCourierEmail(SCMasterAutoId, DocumentNo, InvoiceNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }

        public DataSet SendCourierPrint(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierPrint", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet SendCourierPrintBAL(float DocNo, string flag, int FY)
        {
            return new CourierDetails().SendCourierPrint(DocNo, flag, FY);
        }

        public DataSet SendCourierPrintGeneral(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendCourierPrint", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet SendCourierPrintGeneralBAL(float DocNo, string flag, int FY)
        {
            return new CourierDetails().SendCourierPrintGeneral(DocNo, flag, FY);
        }

        public DataSet SendDispatchEmail(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return base.ExecuteDataSet("Idv_Chetana_SendDispatchEmail", new IDataParameter[] { base.CreateParameter("@DispatchMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo), base.CreateParameter("@flag1", SqlDbType.NVarChar, flag1), base.CreateParameter("@flag2", SqlDbType.NVarChar, flag2), base.CreateParameter("@FY", SqlDbType.Int, FY), base.CreateParameter("@FromID", SqlDbType.NVarChar, FromID), base.CreateParameter("@PWD", SqlDbType.NVarChar, PWD), base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, CreatedBy) });
        }

        public static DataSet SendDispatchEmailBAL(float SCMasterAutoId, float DocumentNo, string flag1, string flag2, int FY, string FromID, string PWD, string CreatedBy)
        {
            return new CourierDetails().SendDispatchEmail(SCMasterAutoId, DocumentNo, flag1, flag2, FY, FromID, PWD, CreatedBy);
        }

        public DataSet UpdatePOD(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ChetanaUpdatePOD", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@Branch", SqlDbType.NVarChar, Branch), base.CreateParameter("@Courier", SqlDbType.NVarChar, CourierCompany), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet UpdatePODBAL(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return new CourierDetails().UpdatePOD(DocNo, FromDate, ToDate, Branch, CourierCompany, flag, FY);
        }

        public DataSet UpdatePODNo(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_UpdatePODNo", new IDataParameter[] { base.CreateParameter("@SCMasterAutoId", SqlDbType.Float, SCMasterAutoId), base.CreateParameter("@DocumentNo", SqlDbType.Float, DocumentNo), base.CreateParameter("@InvoiceNo", SqlDbType.Float, InvoiceNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@No", SqlDbType.Int, No), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public void UpdatePODNoBAL(float SCMasterAutoId, float DocumentNo, float InvoiceNo, string flag, int No, int FY)
        {
            new CourierDetails().UpdatePODNo(SCMasterAutoId, DocumentNo, InvoiceNo, flag, No, FY);
        }

        public DataSet ViewCourier(float DocNo, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ViewCourier", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet ViewCourierBAL(float DocNo, string flag, int FY)
        {
            return new CourierDetails().ViewCourier(DocNo, flag, FY);
        }

        public DataSet ViewCourierDate(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return base.ExecuteDataSet("Idv_Chetana_ViewCourier", new IDataParameter[] { base.CreateParameter("@DocNo", SqlDbType.Float, DocNo), base.CreateParameter("@FromDate", SqlDbType.NVarChar, FromDate), base.CreateParameter("@ToDate", SqlDbType.NVarChar, ToDate), base.CreateParameter("@Branch", SqlDbType.NVarChar, Branch), base.CreateParameter("@Courier", SqlDbType.NVarChar, CourierCompany), base.CreateParameter("@flag", SqlDbType.NVarChar, flag), base.CreateParameter("@FY", SqlDbType.Int, FY) });
        }

        public static DataSet ViewCourierDateBAL(float DocNo, string FromDate, string ToDate, string Branch, string CourierCompany, string flag, int FY)
        {
            return new CourierDetails().ViewCourierDate(DocNo, FromDate, ToDate, Branch, CourierCompany, flag, FY);
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

