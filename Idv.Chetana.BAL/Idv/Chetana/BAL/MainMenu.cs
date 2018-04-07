namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class MainMenu
    {
        public static DataSet Get_Main_Menu_By_MenuHead_ID(int MH_ID)
        {
            return new AdminDataService().Get_Main_Menu_By_MenuHead_ID(MH_ID);
        }
    }
}

