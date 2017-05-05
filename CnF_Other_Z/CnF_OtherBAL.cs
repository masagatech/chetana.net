using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Idv.Chetana.DAL;
using System.Data;

namespace CnF_Other_Z
{
   public class CnF_BAL:DataServiceBase
    {
        #region All CNF Stock Transfer

        #region All Property CNF Stock Transfer
        public class CnfStockTransfer_Property
        {
            public string Flag { get; set; }
            public int FY { get; set; }
            public string OtherFieldXML { get; set; }
            public string R1 { get; set; }
            public string R2 { get; set; }
            public string R3 { get; set; }
            public string R4 { get; set; }
            public string R5 { get; set; }
        }
        #endregion

        #region CNF Stock Transfer Get
        public DataSet IDV_Chetana_REP_Physical_STOCK_Cnf(string bookcode, DateTime FromDate, DateTime ToDate, int FY, string Flag)
        {
            //IDV_Chetana_REP_Physical_STOCK_Cnf
            return ExecuteDataSet("C_IDV_Chetana_REP_STOCK",
                CreateParameter("@BookCode", SqlDbType.VarChar, bookcode),
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Flag", SqlDbType.VarChar, Flag));
        }

        #endregion

        #region CNF Stock Transfer Save
        public void Idv_Chetana_Save_StockTransfer_Cnf(CnfStockTransfer_Property Prop)
        {
            ExecuteNonQuery("Idv_Chetana_Save_BoookStock_Cnf",
                CreateParameter("@Flag", SqlDbType.VarChar, Prop.Flag),
                CreateParameter("@FY", SqlDbType.Int, Prop.FY),
                CreateParameter("@OtherFieldXML", SqlDbType.Xml, Prop.OtherFieldXML),
                CreateParameter("@R1", SqlDbType.VarChar, Prop.R1),
                CreateParameter("@R2", SqlDbType.VarChar, Prop.R2),
                CreateParameter("@R3", SqlDbType.VarChar, Prop.R3),
                CreateParameter("@R4", SqlDbType.VarChar, Prop.R4),
                CreateParameter("@R5", SqlDbType.VarChar, Prop.R5));
        }
        #endregion

        #endregion

    }
}
