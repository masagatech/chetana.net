namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Other_G
    {
        public void DeleteModule(string Id, string Flag, string Flag1)
        {
            new AdminDataService_Go().DeleteModule(Id, Flag, Flag1);
        }

        public static DataSet getInfoNoForGodown(int fy, int DcNo, string flag)
        {
            return new AdminDataService_Go().getInfoNoForGodown(fy, DcNo, flag);
        }

        public DataSet GetNameByCode(string code, string flag)
        {
            return new AdminDataService_Go().GetNameByCode(code, flag);
        }
    }
}

