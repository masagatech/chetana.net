using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using Others;

public class Global
{
    public Global()
    {

    }

    //public static int Check_IsEditable(string Case, int DocNo, int FY)
    //{
    //    try
    //    {
    //        int i;

    //        DataSet ds = new DataSet();
    //        ds = OtherClass.Get_IsEditable(Case, DocNo, FY);
    //        DataTable dt = ds.Tables[0];
    //        DataRow dr = dt.Rows[0];
    //        i = Convert.ToInt32(dr[0].ToString());
    //        return i;

    //    }
    //    catch (Exception ex)
    //    {
    //        return 0;
    //    }
    //}

    //public static bool Check_IsEditable(char p, int docNo)
    //{
    //    throw new NotImplementedException();
    //}

    public static bool ValidateDate(string CheckDate)
    {

        try
        {
            DateTime dt_StartDate = new DateTime();
            DateTime dt_CutOffDate = new DateTime();
            DateTime dt_Date = new DateTime();
            int isvalid = 0;
            if (HttpContext.Current.Session["AuditCutOffDate"] != null)
            {
                dt_StartDate = DateTime.ParseExact(HttpContext.Current.Session["AuditCutOffDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                isvalid += 1;
            }
            if (HttpContext.Current.Session["ToDate"] != null)
            {
                dt_CutOffDate = DateTime.ParseExact(HttpContext.Current.Session["ToDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                isvalid += 1;
            }
            if (CheckDate != null)
            {
                dt_Date = DateTime.ParseExact(CheckDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                isvalid += 1;
            }

            if (isvalid == 3 && dt_Date > dt_StartDate && dt_Date <= dt_CutOffDate)
            {
                return true;

            }
            else
            {
                return false;
            }


        }
        catch (Exception ex)
        {

            return false;
        }


        return false;
    }
}
