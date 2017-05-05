using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Idv.Chetana.DAL;
using System.Data;
using System.Data.SqlClient;

namespace Other_Godown_Speciman
{
    public class Other_GSpeciman:DataServiceBase
    {
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
        }
        #endregion

        #region Idv_Chetana_Save_Godown_Speciman_Head
        public void Idv_Chetana_Save_Godown_Speciman_Head(Speciman_Property Objproperty, out int SpeMaxNo,out int SpecAutoNo)
        {
            SqlCommand cmd;
            ExecuteNonQuery(out cmd,"Idv_Chetana_Save_Godown_Speciman_Head",
                CreateParameter("@SpecId", System.Data.SqlDbType.Int, Objproperty.SpecId),
                CreateParameter("@SpecSeqNo", System.Data.SqlDbType.Int, Objproperty.SpecSeqNo),
                CreateParameter("@SpeDate", System.Data.SqlDbType.DateTime, Objproperty.SpeDate),
                CreateParameter("@BranchCode", System.Data.SqlDbType.NVarChar, Objproperty.BranchCode),
                CreateParameter("@BranchName", System.Data.SqlDbType.NVarChar, Objproperty.BranchName),
                CreateParameter("@TranspotCode", System.Data.SqlDbType.NVarChar, Objproperty.TranspotCode),
                CreateParameter("@TranspportName", System.Data.SqlDbType.NVarChar, Objproperty.TranspportName),
                CreateParameter("@NoOfParcels", System.Data.SqlDbType.Int, Objproperty.NoOfParcels),
                CreateParameter("@valueOfGood", System.Data.SqlDbType.Money, Objproperty.valueOfGood),
                CreateParameter("@Remark", System.Data.SqlDbType.NVarChar, Objproperty.Remark),
                CreateParameter("@SendBy", System.Data.SqlDbType.NVarChar, Objproperty.SendBy),
                CreateParameter("@LRNO", System.Data.SqlDbType.NVarChar, Objproperty.LRNO),
                CreateParameter("@LDDate", System.Data.SqlDbType.DateTime, Objproperty.LDDate),
                CreateParameter("@Paid", System.Data.SqlDbType.Bit, Objproperty.Paid),
                CreateParameter("@Amount", System.Data.SqlDbType.Money, Objproperty.Amount),
                CreateParameter("@Delivery", System.Data.SqlDbType.Bit, Objproperty.Delivery),
                CreateParameter("@CreatedBy", System.Data.SqlDbType.NVarChar, Objproperty.CreatedBy),
                CreateParameter("@FY", System.Data.SqlDbType.Int, Objproperty.FY),
                CreateParameter("@R1", System.Data.SqlDbType.NVarChar, Objproperty.R1),
                CreateParameter("@R2", System.Data.SqlDbType.NVarChar, Objproperty.R2),
                CreateParameter("@R3", System.Data.SqlDbType.NVarChar, Objproperty.R3),
                CreateParameter("@R4", System.Data.SqlDbType.NVarChar, Objproperty.R4),
                CreateParameter("@R_SpecMaxId", System.Data.SqlDbType.Int, 0, ParameterDirection.Output),
                CreateParameter("@R_SpeAutoNo", System.Data.SqlDbType.Int, 0, ParameterDirection.Output));
                SpeMaxNo = Convert.ToInt32(cmd.Parameters["@R_SpecMaxId"].Value);
                SpecAutoNo = Convert.ToInt32(cmd.Parameters["@R_SpeAutoNo"].Value);
        }
        #endregion

        #region Idv_Chetana_Get_Godown_Speciman_Head
        public DataSet Idv_Chetana_Get_Godown_Speciman_Head(int SpecNo,int FY)
        {
            return ExecuteDataSet("Idv_Chetana_Get_Godown_Speciman_Head",
                CreateParameter("@SpecSeqNo", SqlDbType.Int, SpecNo),
                CreateParameter("@FY", SqlDbType.Int, FY));
        }
        #endregion
    }
}
