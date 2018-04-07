using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Idv.Chetana.Common;
using Idv.Chetana.DAL;

namespace Others
{
    public class Common : DataServiceBase
    {
        public DataSet GetDropDownMethod(string Group, string Extra)
        {
            return base.ExecuteDataSet("dbo.Idv_Chetana_Get_DropDown", new IDataParameter[] {
                base.CreateParameter("@Group", SqlDbType.NVarChar, Group),
                base.CreateParameter("@Extra", SqlDbType.NVarChar, Extra)
            });
        }

        public static DataSet GetDropDownFields(string Group, string Extra)
        {
            return new Common().GetDropDownMethod(Group, Extra);
        }

        public DataSet GetNames(string Code, string Flag)
        {
            return base.ExecuteDataSet("Idv_Chetana_GetName_By_Code", new IDataParameter[] {
                base.CreateParameter("@Code", SqlDbType.NVarChar, Code),
                base.CreateParameter("@flag", SqlDbType.NVarChar, Flag)
            });
        }

        public static DataSet Get_Name(string Code, string Flag)
        {
            return new Common().GetNames(Code, Flag);
        }
    }
}
