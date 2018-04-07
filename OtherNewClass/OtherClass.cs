using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Idv.Chetana.DAL;

namespace Others
{
    public class OtherNewClass : DataServiceBase
    {
        public static DataSet Idv_Chetana_REP_Get_MonthlyGraph(DateTime FromDate, DateTime ToDate, int SDZoneId, int SZoneId, int ZoneId,
            int FY, string Remark1, string Remark2, string Remark3, string Remark4)
        {
            return new OtherNewClass().PreIdv_Chetana_REP_Get_MonthlyGraph(FromDate, ToDate, SDZoneId, SZoneId, ZoneId, FY, Remark1, Remark2, Remark3, Remark4);
        }


        public DataSet PreIdv_Chetana_REP_Get_MonthlyGraph(DateTime FromDate, DateTime ToDate, int SDZoneId, int SZoneId, int ZoneId,
            int FY, string Remark1, string Remark2, string Remark3, string Remark4)
        {
            return ExecuteDataSet("Idv_Chetana_REP_Get_MonthlyGraph",
                CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                CreateParameter("@ToDate", SqlDbType.DateTime, ToDate),
                CreateParameter("@SDZoneId", SqlDbType.Int, SDZoneId),
                CreateParameter("@SZoneId", SqlDbType.Int, SZoneId),
                CreateParameter("@ZoneId", SqlDbType.Int, ZoneId),
                CreateParameter("@FY", SqlDbType.Int, FY),
                CreateParameter("@Remark1", SqlDbType.VarChar, Remark1),
                CreateParameter("@Remark2", SqlDbType.VarChar, Remark2),
                CreateParameter("@Remark3", SqlDbType.VarChar, Remark3),
                CreateParameter("@Remark4", SqlDbType.VarChar, Remark4));
        }
    }
}
