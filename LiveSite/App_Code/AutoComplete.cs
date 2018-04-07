using System;
using System.Collections.Generic;
using System.Web.Services;
using Idv.Chetana.BAL;
using System.Data;
// This tutorial is provided in part by Server Intellect Web Hosting Solutions http://www.serverintellect.com

// Visit http://www.ajaxtutorials.com for more AJAX Tutorials Tutorials

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]

public class AutoComplete : WebService
{
    public AutoComplete()
    {
    }

    [WebMethod]
    public string[] GetCodes(string prefixText, int count, string contextKey)
    {
        DataSet ds = new DataSet();
        string[] items = null;
        Other obj = new Other();

        ds = obj.GetNameByCode(prefixText, contextKey);
        int size = ds.Tables[0].Rows.Count;
        items = new string[size];
        int i = 0;
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                items.SetValue(dr["Name"].ToString(), i);
                i++;
            }
        }

        return items;
    }

    [WebMethod]
    public string[] GetCustomerCode_ByEmp(string prefixText, int count, string contextKey)
    {
        DataSet ds = new DataSet();
        string[] items = null;
        Other obj = new Other();

        ds = obj.Get_Codes_Customer_By_Employee_Code(prefixText, contextKey);
        int size = ds.Tables[0].Rows.Count;
        items = new string[size];
        int i = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                items.SetValue(dr["Name"].ToString(), i);
                i++;
            }
        }

        return items;
    }

    [WebMethod]
    public string[] Get_Codes_ForPettyCash(string prefixText, int count, string contextKey)
    {
        DataSet ds = new DataSet();
        string[] items = null;
        Other obj = new Other();

        ds = obj.Get_Codes_ForPettyCash(prefixText, contextKey);
        int size = ds.Tables[0].Rows.Count;
        items = new string[size];
        int i = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                items.SetValue(dr["Name"].ToString(), i);
                i++;
            }
        }

        return items;
    }

    [WebMethod(true)]
    public string[] GetStatesList121(string prefixText, int count, string contextKey)
    {
        Random random = new Random();
        List<string> items = new List<string>(count);

        for (int i = 0; i < count; i++)
        {
            char c1 = (char)random.Next(65, 90);
            char c2 = (char)random.Next(97, 122);
            char c3 = (char)random.Next(97, 122);
            items.Add(prefixText + c1 + c2 + c3);
        }
        return items.ToArray();
    }

    [WebMethod]
    public string[] GetGodownCodes(string prefixText, int count, string contextKey)
    {
        DataSet ds = new DataSet();
        string[] items = null;
        Other_G obj = new Other_G();

        ds = obj.GetNameByCode(prefixText, contextKey);
        int size = ds.Tables[0].Rows.Count;
        items = new string[size];
        int i = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                items.SetValue(dr["Name"].ToString(), i);
                i++;
            }
        }

        return items;
    }
}
