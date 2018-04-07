namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class AccountLeadgerDetails
    {
        public static DataSet Get_Trial_Balance_Individual(string AccountCode, bool isCustmer, DateTime FromDate, DateTime Todate)
        {
            return new AdminDataService_DC().Get_Trial_Balance_Individual(AccountCode, isCustmer, FromDate, Todate);
        }
    }
}

