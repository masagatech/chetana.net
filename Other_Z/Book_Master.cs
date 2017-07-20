using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Idv.Chetana;
using System.Data.SqlClient;
using System.Data;

namespace Other_Z
{
    public class Book_Master : Idv.Chetana.DAL.DataServiceBase
    {
        #region Book Master Prop
        public class BookMasterProp
        {
            public string BookCode { get; set; }
            public string Bookgroup { get; set; }
            public int bookID { get; set; }
            public string BookName { get; set; }
            public string BookType { get; set; }
            public string ChetanaCompanyName { get; set; }
            public string Confirm { get; set; }
            public string CreatedBy { get; set; }
            public string Description { get; set; }
            public int DocNo { get; set; }
            public int FY { get; set; }
            public bool IsActive { get; set; }
            public bool IsBlock { get; set; }
            public bool IsDeleted { get; set; }
            public string Medium { get; set; }
            public decimal OIPrice { get; set; }
            public decimal OMPrice { get; set; }
            public int PhysicalStock { get; set; }
            public decimal PurchasePrice { get; set; }
            public int Quantity { get; set; }
            public decimal SellingPrice { get; set; }
            public string Standard { get; set; }
            public string UpdatedBy { get; set; }
            public bool UpdateRate { get; set; }
            public int VirtualStock { get; set; }

            public string HSNCode { get; set; }
            public decimal GST { get; set; }
        }
        #endregion

        #region Book Master Save

        public static void Save_BookMaster(BookMasterProp reqprop)
        {
             new Book_Master().SaveBookMaster(reqprop);
        }

        public void SaveBookMaster(BookMasterProp reqprop)
        {
            SqlCommand command;
            base.ExecuteNonQuery(out command, "Idv_Chetana_Save_BookMaster", new IDataParameter[] {
                base.CreateParameter("@BookID", SqlDbType.Int, reqprop.bookID),
                base.CreateParameter("@BookCode", SqlDbType.NVarChar, reqprop.BookCode),
                base.CreateParameter("@BookName", SqlDbType.NVarChar, reqprop.BookName),
                base.CreateParameter("@BookType", SqlDbType.NVarChar, reqprop.BookType),
                base.CreateParameter("@Bookgroup", SqlDbType.NVarChar, reqprop.Bookgroup),
                base.CreateParameter("@Standard", SqlDbType.NVarChar, reqprop.Standard),
                base.CreateParameter("@PurchasePrice", SqlDbType.Money, reqprop.PurchasePrice),
                base.CreateParameter("@SellingPrice", SqlDbType.Money, reqprop.SellingPrice),
                base.CreateParameter("@OMPrice", SqlDbType.Money, reqprop.OMPrice),
                base.CreateParameter("@OIPrice", SqlDbType.Money, reqprop.OIPrice),
                base.CreateParameter("@Medium", SqlDbType.NVarChar, reqprop.Medium),
                base.CreateParameter("@UpdateRate", SqlDbType.Bit, reqprop.UpdateRate),
                base.CreateParameter("@Quantity", SqlDbType.Int, reqprop.Quantity),
                base.CreateParameter("@IsActive", SqlDbType.Bit, reqprop.IsActive),
                base.CreateParameter("@IsBlock", SqlDbType.Bit, reqprop.IsBlock),
                base.CreateParameter("@IsDeleted", SqlDbType.Bit, reqprop.IsDeleted),
                base.CreateParameter("@CreatedBy", SqlDbType.NVarChar, reqprop.CreatedBy),
                base.CreateParameter("@Description", SqlDbType.NVarChar, reqprop.Description),
                base.CreateParameter("@UpdatedBy", SqlDbType.NVarChar, reqprop.UpdatedBy),
                base.CreateParameter("@HSNCode", SqlDbType.NVarChar, reqprop.HSNCode),
                base.CreateParameter("@GST", SqlDbType.Decimal, reqprop.GST),
             });
            command.Dispose();
        }

        #endregion
    }
}
