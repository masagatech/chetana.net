namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Miscellaneous
    {
        public static DataSet GetMiscellaneous(string Flag, int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return new AdminDataService_DC().getMiscellaneous(Flag, Superzone, Zone, CustID, CustCateID, FY);
        }

        public static DataSet GetMiscellaneousDAC(string Flag, int Superzone, int Zone, int CustID, int CustCateID, int FY)
        {
            return new AdminDataService_DC().GetMiscellaneousDAC(Flag, Superzone, Zone, CustID, CustCateID, FY);
        }
    }
}

