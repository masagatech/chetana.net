using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Idv.Chetana;
using System.Data.SqlClient;
using System.Data;

namespace Other_Z
{
   public class ActualInvoice_Details : Idv.Chetana.DAL.DataServiceBase
    {
        #region ActualInvoice Prop
        public class ActualInvoice_DetailsProp
        {
            public decimal  Amount { get; set; }
            public string BookCode { get; set; }
            public int BookID { get; set; }
            public string BookName { get; set; }
            public string Bundles { get; set; }
            public string CreatedBy { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime DeliveryDate { get; set; }
            public decimal Discount { get; set; }
            public int DocumentNo { get; set; }
            public string FinancialYearFrom { get; set; }
            public string flag { get; set; }
            public decimal Freight { get; set; }
            public int GanerateinvoiceId { get; set; }
            public DateTime InvoiceDate { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
            public DateTime LRDate { get; set; }
            public string LRNo { get; set; }
            public string Medium { get; set; }
            public string Publisher { get; set; }
            public int Quantity { get; set; }
            public decimal Rate { get; set; }
            public string Remark1 { get; set; }
            public string Remark2 { get; set; }
            public string Remark3 { get; set; }
            public string Standard { get; set; }
            public decimal SubDocId { get; set; }
            public decimal Tax { get; set; }
            public decimal TotalAmount { get; set; }
            public string Transporter { get; set; }
            public string UpdatedBy { get; set; }
            public DateTime Updatedon { get; set; }
            public string HSNCode { get; set; }

            public decimal GSTPer { get; set; }

            public decimal GSTAmt { get; set; }
            public string Typ { get; set; }
            public string Flag { get; set; }
            public string Flag1 { get; set; }
            public string WayBill { get; set; }

        }
        #endregion

        #region Save Confirm Invoice
        //public static void Save_ActualInvoiceDetails(ActualInvoice_DetailsProp reqprop)
        //{
        //    SaveActualInvoiceDetails(reqprop);
        //}
        public void SaveActualInvoiceDetails(ActualInvoice_DetailsProp reqprop)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_DC_Save_ActualInvoiceDetails", new IDataParameter[] {
                base.CreateParameter("@GanerateinvoiceId", SqlDbType.Int, reqprop.GanerateinvoiceId),
                base.CreateParameter("@DocumentNo", SqlDbType.Int, reqprop.DocumentNo),
                base.CreateParameter("@SubDocId", SqlDbType.Decimal, reqprop.SubDocId),
                base.CreateParameter("@BookCode", SqlDbType.NVarChar, reqprop.BookCode),
                base.CreateParameter("@BookName", SqlDbType.VarChar, reqprop.BookName),
                base.CreateParameter("@Standard", SqlDbType.NVarChar, reqprop.Standard),
                base.CreateParameter("@Medium", SqlDbType.VarChar, reqprop.Medium),
                base.CreateParameter("@Quantity", SqlDbType.Int, reqprop.Quantity),
                base.CreateParameter("@Rate", SqlDbType.Money, reqprop.Rate),
                base.CreateParameter("@Discount", SqlDbType.Money, reqprop.Discount),
                base.CreateParameter("@Amount", SqlDbType.Money, reqprop.Amount),
                base.CreateParameter("@Freight", SqlDbType.Decimal, reqprop.Freight),
                base.CreateParameter("@Tax", SqlDbType.Decimal, reqprop.Tax),
                base.CreateParameter("@TotalAmount", SqlDbType.Money, reqprop.TotalAmount),
                base.CreateParameter("@InvoiceDate", SqlDbType.DateTime, reqprop.InvoiceDate),
                base.CreateParameter("@lrno", SqlDbType.NVarChar, reqprop.LRNo),
                base.CreateParameter("@Transporter", SqlDbType.NVarChar, reqprop.Transporter),
                base.CreateParameter("@Isactive", SqlDbType.Bit, reqprop.IsActive),
                base.CreateParameter("@Isdelete", SqlDbType.Bit, reqprop.IsDeleted),
                base.CreateParameter("@Bundles", SqlDbType.NVarChar, reqprop.Bundles),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, reqprop.CreatedBy),
                base.CreateParameter("@fy", SqlDbType.NVarChar, reqprop.FinancialYearFrom),
                base.CreateParameter("@LRDate", SqlDbType.DateTime, reqprop.LRDate),
                base.CreateParameter("@Remark1", SqlDbType.NVarChar, reqprop.Remark1),
                base.CreateParameter("@Remark2", SqlDbType.NVarChar, reqprop.Remark2),
                base.CreateParameter("@Remark3", SqlDbType.NVarChar, reqprop.Remark3),
                base.CreateParameter("@GSTPer", SqlDbType.Decimal, reqprop.GSTPer),
                base.CreateParameter("@GSTAmt", SqlDbType.Decimal, reqprop.GSTAmt),
                base.CreateParameter("@HSNCode", SqlDbType.NVarChar, reqprop.HSNCode),
                base.CreateParameter("@Typ", SqlDbType.NVarChar, reqprop.Typ),
                base.CreateParameter("@Flag", SqlDbType.NVarChar, reqprop.Flag),
                base.CreateParameter("@Flag1", SqlDbType.NVarChar, reqprop.Flag1),
                base.CreateParameter("@WayBill", SqlDbType.NVarChar, reqprop.WayBill),
             });
            command.Dispose();
        }
        #endregion
    }
}
