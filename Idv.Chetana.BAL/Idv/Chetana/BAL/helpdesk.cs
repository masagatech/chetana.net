namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class helpdesk
    {
        public static DataSet getAllHelpDesk(string custcode, string flag)
        {
            return new AdminDataService().Idv_Chetana_Customer_HelpDesk(custcode, flag);
        }
    }
}

