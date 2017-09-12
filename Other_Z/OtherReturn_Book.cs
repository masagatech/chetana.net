using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Idv.Chetana.DAL;
using System.Data;
using System.Data.SqlClient;

namespace Other_Z
{
    public class OtherReturn_Book : DataServiceBase
    {
        #region Property Book Return
        public class ReturnBook_Prop
        {
            public string BookCode { get; set; }
            public string  Comment { get; set; }
            public string  CreatedBy { get; set; }
            public DateTime  CreatedOn { get; set; }
            public string  CustCode { get; set; }
            public int  DCReturnBkID { get; set; }
            public int  DefectQty { get; set; }
            public string  Flag { get; set; }
            public int  ReturnQty { get; set; }
            public int  strFY { get; set; }
            public string  UpdatedBy { get; set; }
            public DateTime  Updatedon { get; set; }
            public string HSNCode { get; set; }
            public decimal GSTAmount { get; set; }
            public decimal GSTPer { get; set; }
            public string Typ { get; set; }
        }
        #endregion

        #region Book Return Save
        public void Save_ReturnBook(ReturnBook_Prop reqprop)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_DC_ReturnBook", new IDataParameter[] 
            {
                base.CreateParameter("@DCReturnBkID", SqlDbType.Int, reqprop.DCReturnBkID),
                base.CreateParameter("@CustCode", SqlDbType.NVarChar, reqprop.CustCode),
                base.CreateParameter("@BookCode", SqlDbType.NVarChar, reqprop.BookCode),
                base.CreateParameter("@ReturnQty", SqlDbType.Int, reqprop.ReturnQty),
                base.CreateParameter("@Comment", SqlDbType.NVarChar, reqprop.Comment),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, reqprop.CreatedBy),
                base.CreateParameter("@Flag", SqlDbType.NVarChar, reqprop.Flag),
                base.CreateParameter("@DefectQty", SqlDbType.Int, reqprop.DefectQty),
                base.CreateParameter("@HSNCode", SqlDbType.NVarChar, reqprop.HSNCode),
                base.CreateParameter("@GSTAmt", SqlDbType.Decimal, reqprop.GSTAmount),
                base.CreateParameter("@GSTPer", SqlDbType.Decimal, reqprop.GSTPer),
                base.CreateParameter("@FY", SqlDbType.Int, reqprop.strFY),
                base.CreateParameter("@Typ", SqlDbType.NVarChar, reqprop.Typ)
            });
            command.Dispose();
        }
        #endregion

        #region DC CN Property
        public class DCCNProp
        {
            public string ActualKey { get; set; }
            public int AutoID { get; set; }
            public string BookCode { get; set; }
            public DateTime CNDate { get; set; }
            public int CNNo { get; set; }
            public string Comment { get; set; }
            public string CreatedBy { get; set; }
            public string CustCode { get; set; }
            public int DefectQty { get; set; }
            public decimal Discount { get; set; }
            public string Flag { get; set; }
            public int GCN { get; set; }
            public string GroupKey { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
            public string LrNo { get; set; }
            public int NewCount { get; set; }
            public int PreviousCount { get; set; }
            public decimal Rate { get; set; }
            public string Remark1 { get; set; }
            public string Remark2 { get; set; }
            public string Remark3 { get; set; }
            public string Remark4 { get; set; }
            public string Remark5 { get; set; }
            public int ReturnQty { get; set; }
            public int SCN { get; set; }
            public int strFY { get; set; }
            public int SuperZoneId { get; set; }
            public int TotReturnQty { get; set; }
            public string TransportName { get; set; }
            public string UpdatedBy { get; set; }
            public string Value { get; set; }
            public string HSNCode { get; set; }
            public decimal GSTAmount { get; set; }
            public decimal GSTPer { get; set; }
            public string Typ { get; set; }
        }
        #endregion

        #region DC CN Save

        public void SaveDCCN(DCCNProp reqprop)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_CN", new IDataParameter[] {
                base.CreateParameter("@AutoID", SqlDbType.Int, reqprop.AutoID),
                base.CreateParameter("@CNNo", SqlDbType.Int, reqprop.CNNo),
                base.CreateParameter("@CustCode", SqlDbType.NVarChar, reqprop.CustCode),
                base.CreateParameter("@BookCode", SqlDbType.NVarChar, reqprop.BookCode),
                base.CreateParameter("@Rate", SqlDbType.Money, reqprop.Rate),
                base.CreateParameter("@Discount", SqlDbType.Money, reqprop.Discount),
                base.CreateParameter("@ReturnQty", SqlDbType.Int, reqprop.ReturnQty),
                base.CreateParameter("@Comment", SqlDbType.NVarChar, reqprop.Comment),
                base.CreateParameter("@IsActive", SqlDbType.Bit, reqprop.IsActive),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, reqprop.CreatedBy),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, reqprop.UpdatedBy),
                base.CreateParameter("@Flag", SqlDbType.NVarChar, reqprop.Flag),
                base.CreateParameter("@TotReturnQty", SqlDbType.Int, reqprop.TotReturnQty),
                base.CreateParameter("@DefectQty", SqlDbType.Int, reqprop.DefectQty),
                base.CreateParameter("@GCN", SqlDbType.Int, reqprop.GCN),
                base.CreateParameter("@SCN", SqlDbType.Int, reqprop.SCN),
                base.CreateParameter("@FY", SqlDbType.Int, reqprop.strFY),
                base.CreateParameter("@CNDate", SqlDbType.DateTime, reqprop.CNDate),
                base.CreateParameter("@TransportName", SqlDbType.NVarChar, reqprop.TransportName),
                base.CreateParameter("@LrNo", SqlDbType.NVarChar, reqprop.LrNo),
                base.CreateParameter("@Remark1", SqlDbType.NVarChar, reqprop.Remark1),
                base.CreateParameter("@Remark2", SqlDbType.NVarChar, reqprop.Remark2),
                base.CreateParameter("@Remark3", SqlDbType.NVarChar, reqprop.Remark3),
                base.CreateParameter("@Remark4", SqlDbType.NVarChar, reqprop.Remark4),
                base.CreateParameter("@Remark5", SqlDbType.NVarChar, reqprop.Remark5),
                base.CreateParameter("@HSNCode", SqlDbType.NVarChar, reqprop.HSNCode),
                base.CreateParameter("@GSTAmt", SqlDbType.Decimal, reqprop.GSTAmount),
                base.CreateParameter("@GSTPer", SqlDbType.Decimal, reqprop.GSTPer),
                base.CreateParameter("@Typ", SqlDbType.NVarChar, reqprop.Typ),
             });
            command.Dispose();
        }
        #endregion
    }
}
