using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Add Refrence 2 Dll File
using Idv.Chetana.DAL;
using System.Data;
using System.Data.SqlClient;



namespace Other_KycForm
{
    public class OtherKycFormBAL : DataServiceBase
    {
        #region Idv_Chetana_Token_Register Property
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
            public float TitleCurrentYear { get; set; }
            public int ChkSchemeLetter { get; set; }
            public int ChkAddCommFrm { get; set; }
            public int ChkDisForm { get; set; }
            public string Remark { get; set; }
            public string CreatedBy { get; set; }
            public int FY { get; set; }
            public string R1 { get; set; }
            public string R2 { get; set; }
            public string R3 { get; set; }
            public string R4 { get; set; }
        }
        #endregion

        #region Idv_Chetana_KycForm Save Method

        public void Idv_Chetana_Save_KycForm(KycForm_Property ObjKycProperty, out int KycNo)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd, "Idv_Chetana_Save_KycForm",
                CreateParameter("@SrNo", SqlDbType.Int, ObjKycProperty.KycNo),
                CreateParameter("@OrderDate", SqlDbType.DateTime, ObjKycProperty.OrderDate),
                CreateParameter("@OrderNo", SqlDbType.Int, ObjKycProperty.OrderNo),
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
                CreateParameter("@TitleCurrentYear", SqlDbType.Money, ObjKycProperty.TitleCurrentYear),
                CreateParameter("@chkSchemeLetter", SqlDbType.Int, ObjKycProperty.ChkSchemeLetter),
                CreateParameter("@AddCommFrm", SqlDbType.Int, ObjKycProperty.ChkAddCommFrm),
                CreateParameter("@DisForm", SqlDbType.Int, ObjKycProperty.ChkDisForm),
                CreateParameter("@createdBy", SqlDbType.VarChar, ObjKycProperty.CreatedBy),
                CreateParameter("@FY", SqlDbType.Int, ObjKycProperty.FY),
                CreateParameter("@Remark", SqlDbType.VarChar, ObjKycProperty.Remark),
                CreateParameter("@R1", SqlDbType.VarChar, ObjKycProperty.R1),
                CreateParameter("@R2", SqlDbType.VarChar, ObjKycProperty.R2),
                CreateParameter("@R3", SqlDbType.VarChar, ObjKycProperty.R3),
                CreateParameter("@R4", SqlDbType.VarChar, ObjKycProperty.R4),
                CreateParameter("@KycId", SqlDbType.Int, 0, ParameterDirection.Output));
            KycNo = Convert.ToInt32(cmd.Parameters["@KycId"].Value);
        }
        #endregion

        #region Get Data Edit Mode

        public DataSet Idv_Chetana_Get_KycForm(int OrderNo, int FY)
        {
            return ExecuteDataSet("Idv_Chetana_Get_KycForm",
                CreateParameter("@OrderNo", SqlDbType.Int, OrderNo),
                CreateParameter("@FY", SqlDbType.Int, FY));
        }

        #endregion

        #region Get Customer Code All Data With Master Table

        public DataSet Idv_Chetana_Get_KycForm_CusCode(string CustCode)
        {
            return ExecuteDataSet("Idv_Chetana_Get_KycForm_GetMasterCust",
                CreateParameter("@CustCode", System.Data.SqlDbType.VarChar, CustCode));
        }

        #endregion
    }
}
