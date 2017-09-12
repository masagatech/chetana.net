using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Idv.Chetana.Common;
using System.Data.SqlClient;
using Idv.Chetana.DAL;

namespace Other_Z
{
   public class SalesPerformance : DataServiceBase
    {
        #region Sales Performance Report

        public static DataSet Get_OtherZ_SalesPerformanceReport(int EmployeeID, int SZID, int SDID, int FY, DateTime FromDate, DateTime ToDate)
        {
            return new SalesPerformance().OtherZ_Get_Report_SalesPerformance(EmployeeID, SZID, SDID, FY, FromDate, ToDate);
        }

        public DataSet OtherZ_Get_Report_SalesPerformance(int EmployeeID, int SZID,int SDID, int FY, DateTime FromDate, DateTime ToDate)
        {
            return base.ExecuteDataSet("idv_Chetana_REP_SalesPerformance", new IDataParameter[] {
                base.CreateParameter("@EmployeeID", SqlDbType.Int, EmployeeID),
                base.CreateParameter("@SZID", SqlDbType.Int, SZID),
                base.CreateParameter("@SDID", SqlDbType.Int, SDID),
                base.CreateParameter("@FY", SqlDbType.Int, FY),
                base.CreateParameter("@FromDate", SqlDbType.DateTime, FromDate),
                base.CreateParameter("@ToDate", SqlDbType.DateTime, ToDate)
            });
        }
        #endregion
    }
}
