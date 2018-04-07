namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Report
    {
        public static DataSet Idv_Chetana_Broker_Ledger_Report(string BrokerCode, string flag, decimal amount, int FY, DateTime FromDate, DateTime Todate)
        {
            return new AdminDataService_DC().Idv_Chetana_Broker_Ledger_Report(BrokerCode, flag, amount, FY, FromDate, Todate);
        }
    }
}

