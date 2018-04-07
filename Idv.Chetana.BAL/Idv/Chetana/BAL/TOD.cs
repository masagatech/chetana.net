namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class TOD
    {
        public static DataSet Get_TOD(int CustID, int FY, int Superzone, string Flags)
        {
            return new AdminDataService().Get_TOD(CustID, FY, Superzone, Flags);
        }
    }
}

