namespace Idv.Chetana.BAL
{
    using Idv.Chetana.DAL;
    using System;
    using System.Data;

    public class Masters
    {
        public static DataSet Get_AreaZone_Zone_SuperZone(int Code1, string Flag1)
        {
            return new AdminDataService().Get_AreaZone_Zone_SuperZone(Code1, Flag1);
        }

        public static DataSet Get_Masters_Code_ID_Name(string flag)
        {
            return new AdminDataService().Get_Masters_Code_ID_Name(flag);
        }

        public static bool GetCodeValidation(string Group, string code)
        {
            DataTable table = new DataTable();
            table = new AdminDataService().GetCodeValidation(Group, code).Tables[0];
            return (table.Rows.Count > 0);
        }

        public static DataSet Idv_Chetana_Get_ZoneCustomer(int Code1)
        {
            return new AdminDataService().Idv_Chetana_Get_ZoneCustomer(Code1);
        }

        public static DataSet Idv_Chetana_Get_ZoneCustomerAdditionalCommission(int Code1)
        {
            return new AdminDataService().Idv_Chetana_Get_ZoneCustomerAdditionalCommission(Code1);
        }

        public static DataSet Idv_Chetana_Get_ZoneCustomerBlackList(int Code1)
        {
            return new AdminDataService().Idv_Chetana_Get_ZoneCustomerBlackList(Code1);
        }

        public static DataSet Idv_Chetana_Get_ZoneCustomerBookSeller(int Code1)
        {
            return new AdminDataService().Idv_Chetana_Get_ZoneCustomerBookSeller(Code1);
        }

        public static DataSet Idv_Chetana_Get_ZoneCustomerTOD(int SZone, int Zone)
        {
            return new AdminDataService().Idv_Chetana_Get_ZoneCustomerTOD(SZone, Zone);
        }
    }
}

