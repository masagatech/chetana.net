#region Namespace
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Linq;
using Idv.Chetana.BAL;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Others;
using System.IO;
#endregion
public partial class UserControls_uc_Edit_Global_Comm : System.Web.UI.UserControl
{
    string strChetanaCompanyName = "cppl";
    string strFY;
    string Tdisfrm;
    string Tdisto;
    string Ttarfrm;
    string Ttarto;
    string Tscomm;
    string Tzcomm;
    Boolean TIsActive;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
            //Response.Write(strFY);

        }

        if (!Page.IsPostBack)
        {
            Session["tempCommData"] = null;
            GetData();
        }

    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    public void GetData()
    {
        DataSet ds = new DataSet();
        DataTable tbl;

        ds = OtherClass.Idv_Chetana_Get_Global_Commission(0, 0, Convert.ToInt32(strFY));

        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdComm.DataSource = ds.Tables[0];
            GrdComm.DataBind();
            tbl = ds.Tables[0];
            DataRow dr = tbl.Rows[0];
            txtcnper.Text = dr["CNPer"].ToString() == "" ? "0.00" : Convert.ToDecimal(dr["CNPer"]).ToString("0.00");
        }
        else
        {
            MessageBox("Kindly SET COMMISSION...");
        }
        //btnSave.Visible = true;
    }

    public DataTable fillTempData()
    {
        DataTable dt = new DataTable();
        int Aid = Convert.ToInt32(GetAutoId());
        if (Session["tempCommData"] == null)
        {

            dt.Columns.Add("AutoId");
            dt.Columns.Add("Superzoneid");
            dt.Columns.Add("Zoneid");
            dt.Columns.Add("discfromamt");
            dt.Columns.Add("disctoamt");
            dt.Columns.Add("targperfrom");
            dt.Columns.Add("targperto");
            dt.Columns.Add("zoneprcent");
            dt.Columns.Add("superzoneprcent");
            dt.Columns.Add("IsActive");
            dt.Rows.Add(Aid, 0, 0, Tdisfrm, Tdisto, Ttarfrm, Ttarto, Tzcomm, Tscomm, TIsActive);
         }

        else
        {
            dt = (DataTable)Session["tempCommData"];
            dt.Rows.Add(Aid, 0, 0, Tdisfrm, Tdisto, Ttarfrm, Ttarto, Tzcomm, Tscomm, TIsActive);
        }
        return dt;
    }
    public int GetAutoId()
    {
        DataSet ds = new DataSet();
        int AId;
        ds = OtherClass.Idv_Chetana_GetAutoId();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable tbl = ds.Tables[0];
            DataRow dr = tbl.Rows[0];
            AId = Convert.ToInt32(dr[0].ToString());
        }
        else
        {
            AId = 0;
        }
        AId = AId + 1;
        return AId;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();		//Object cmlDocument
        XmlElement nd;
        XmlNode node = doc.CreateElement("Root");	//Root Note
        int flag = 0;
        foreach (GridViewRow item in GrdComm.Rows)
        {
            XmlNode element = doc.CreateElement("Items");
 
            nd = doc.CreateElement("Id");
            nd.InnerText = ((Label)item.FindControl("lbl1")).Text.Trim();
            element.AppendChild(nd);
 
            nd = doc.CreateElement("DisFrm");
            nd.InnerText = ((TextBox)item.FindControl("TxtDisF")).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("DisTo");
            nd.InnerText = ((TextBox)item.FindControl("txtdisTo")).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("tarfrm");
            nd.InnerText = ((TextBox)item.FindControl("txttarfrm")).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("tarto");
            nd.InnerText = ((TextBox)item.FindControl("txttarto")).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("commz");
            nd.InnerText = ((TextBox)item.FindControl("txtzcomm")).Text.Trim();
            element.AppendChild(nd);

            nd = doc.CreateElement("comms");
            nd.InnerText = ((TextBox)item.FindControl("txtscomm")).Text.Trim();
            element.AppendChild(nd);


            nd = doc.CreateElement("a");
            if (((CheckBox)item.FindControl("chkActive")).Checked)
            {
                nd.InnerText = "True";
            }
            else
            {
                nd.InnerText = "False";
            }
            element.AppendChild(nd);

            nd = doc.CreateElement("cnper");
            nd.InnerText = txtcnper.Text.Trim();
            element.AppendChild(nd);
        
        
            node.AppendChild(element);

        }

        OtherClass.Idv_Chetana_Save_Update_Commission(0, 0, Convert.ToInt32(strFY), node.OuterXml.ToString(), flag);
        MessageBox("Records updated successfully...");
        GetData();

    }
}
