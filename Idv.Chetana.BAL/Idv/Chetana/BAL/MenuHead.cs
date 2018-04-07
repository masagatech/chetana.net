namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class MenuHead
    {
        public static DataSet Get_All_Active_Menu_Head()
        {
            return new AdminDataService().Get_All_Active_Menu_Head();
        }
    }
}

