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
public partial class UserControls_Edit_Indivisual_Comm : System.Web.UI.UserControl
{
    string strChetanaCompanyName = "cppl";
    string strFY;
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
            Bind_DDL_SuperZone();
            Session["tempCommData"] = null;
            PnllGrdComm.Visible = false;
        }
    }

    #region BindData
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();

        }
        else
        {
            Bind_DDL_Zone();
            DDLZone.Focus();
        }
    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("< Select SuperZone -", "0"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    #region GetAutoId
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

    #endregion


    protected void btnget_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(DDLSuperZone.SelectedValue) <= 0)
        {
            MessageBox("Kindly select Superzone and Zone...");
        }
        else
        {
            PnllGrdComm.Visible = true;
            DataSet ds = new DataSet();
            DataTable tbl;
            ds = OtherClass.Idv_Chetana_Get_Global_Commission(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), Convert.ToInt32(strFY));

            if (ds.Tables[1].Rows.Count > 0)
            {
                GrdComm.DataSource = ds.Tables[1];
                GrdComm.DataBind();
                tbl = ds.Tables[1];
                DataRow dr = tbl.Rows[0];
                txtcnper.Text = dr["CNPer"].ToString() == "" ? "0.00" : Convert.ToDecimal(dr["CNPer"]).ToString("0.00");
            }
            else if (ds.Tables[0].Rows.Count > 0)
            {
                GrdComm.DataSource = ds.Tables[0];
                GrdComm.DataBind();
                tbl = ds.Tables[0];
                DataRow dr = tbl.Rows[0];
                txtcnper.Text = dr["CNPer"].ToString() == "" ? "0.00" : Convert.ToDecimal(dr["CNPer"]).ToString("0.00");
            }
            else
            {
                //MessageBox("Kindly SET COMMISSION...");
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            XmlDocument doc = new XmlDocument();		//Object cmlDocument
            XmlElement nd;
            XmlNode node = doc.CreateElement("Root");	//Root Note
            int flag = 1;
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

            OtherClass.Idv_Chetana_Save_Update_Commission(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), Convert.ToInt32(DDLZone.SelectedValue.ToString()), Convert.ToInt32(strFY), node.OuterXml.ToString(), flag);
            MessageBox("Record saved successfully...");
            //DDLSuperZone.Text = DDLSuperZone.Items[0].ToString();
            PnllGrdComm.Visible = false;
        }
        catch (Exception ex)
        { 

        }
    }


}

