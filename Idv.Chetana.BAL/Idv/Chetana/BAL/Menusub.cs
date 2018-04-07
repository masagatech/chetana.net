namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Menusub
    {
        public static DataSet Get_Sub_Menu_By_MainMenu_ID(int SubMenuId)
        {
            return new AdminDataService().Get_Sub_Menu_By_MainMenu_ID(SubMenuId);
        }
    }
}

