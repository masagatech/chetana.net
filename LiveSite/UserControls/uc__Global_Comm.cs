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
public partial class UserControls_uc_Set_Comm : System.Web.UI.UserControl
{
    string strChetanaCompanyName = "cppl";
    string strFY;
    string Tdisfrm;
    string Tdisto;
    string Ttarfrm;
    string Ttarto;
    string Tscomm;
    string Tzcomm;
    Boolean  TIsActive;

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
            SetView();
            txtDisFrm.Focus();
            Session["tempCommData"] = null;
            GetData();
        }
        
    }

    #region SetView
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "s")
            {
                string page = Request.Url.Segments[Request.Url.Segments.Length - 1].ToString().ToLower();
                if (page == "set_global_comm.aspx")
                {
                    pageName.InnerHtml = "Set Global Commission";
                    btnSave.Text = "Save";
                    btnSave.Visible = false;
                    PnlAdd.Visible=true;
                    PnllGrdComm.Visible = true;

                }
                else
                {
                    //pageName.InnerHtml = "Add Bank Payment";
                    //LblBankPID.Text = "0";
                    //PnlAddBankP.Visible = true;
                    //Pnldate.Visible = false;
                    //PnlBankPDetails.Visible = false;

                    //btn_Save.Visible = true;
                    //btnDelete.Visible = false;
                    //filter.Visible = false;
                    //txtbankcode.Focus();
                    //txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                }
            }
            else
                if (Request.QueryString["a"] == "u")
                {

                    pageName.InnerHtml = "Edit Global Commission";
                    btnSave.Text = "Update";
                    btnSave.Visible = true;
                    PnlAdd.Visible =false;
                    PnllGrdComm.Visible = true;
                }

           else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View Global Commission";
                    btnSave.Visible = false;
                    PnlAdd.Visible = false;
                    PnllGrdComm.Visible = true;
                    btnadd.Visible = false;
                }
        }
        else
        {
            Response.Redirect("~/dashboard.aspx");

        }
    }
    #endregion

    public void GetData()
    {
        DataSet ds = new DataSet();

        ds = OtherClass.Idv_Chetana_Get_Global_Commission(0, 0,Convert.ToInt32(strFY));
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdComm.DataSource = ds.Tables[0];
            GrdComm.DataBind();
        }
        else
        {
            MessageBox("Kindly SET COMMISSION...");
        }
        //btnSave.Visible = true;
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void chkActive_CheckedChanged(object sender, EventArgs e)
    {

    }


    protected void btnadd_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        if (txtDisFrm.Text != "" || txtDisTo.Text != "" || txtTarFrm.Text != "" || txtTarTo.Text != "" || txtCommSZone.Text != "" || txtCommZone.Text != "")
        {
            Tdisfrm = txtDisFrm.Text.Trim();
            Tdisto = txtDisTo.Text.Trim();
            Ttarfrm = txtTarFrm.Text.Trim();
            Ttarto = txtTarTo.Text.Trim();
            Tscomm = txtCommSZone.Text.Trim();
            Tzcomm = txtCommZone.Text.Trim();
            if (chkActive.Checked)
            {
                TIsActive =true ;
            }
            else
            {
                TIsActive = false ;
            }
            DataTable dt1 = new DataTable();
            if (Session["tempCommData"] != null)
            {
                Session["tempCommData"] = fillTempData();
                dt1 = (DataTable)Session["tempCommData"];
            }

            else
            {
                Session["tempCommData"] = fillTempData();
                dt1 = (DataTable)Session["tempCommData"];
            }
            GrdComm.DataSource = dt1;
            GrdComm.DataBind();
            txtDisFrm.Text="";
            txtDisTo.Text = "";
            txtTarFrm.Text = "";
            txtTarTo.Text = "";
            txtCommSZone.Text = "";
            txtCommZone.Text = "";
            txtDisFrm.Focus();
        }
        else
        {
            MessageBox("Fill all text fields..");
        }
    }

    public DataTable  fillTempData()
    {
        DataTable dt = new DataTable();
        int Aid=Convert.ToInt32(GetAutoId());
        if(Session["tempCommData"] == null)
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
            dt.Rows.Add(Aid,0,0,Tdisfrm, Tdisto, Ttarfrm, Ttarto, Tzcomm, Tscomm, TIsActive);
            btnSave.Visible = true;
        
        }

        else
        {
            dt = (DataTable)Session["tempCommData"];
            dt.Rows.Add(Aid,0,0,Tdisfrm, Tdisto, Ttarfrm, Ttarto, Tzcomm, Tscomm, TIsActive);
            //btnSave.Visible = true;
        }
        return dt;
    }

    public int GetAutoId()
    {
        DataSet ds = new DataSet();
        int AId;
        ds=OtherClass.Idv_Chetana_GetAutoId();
        if (ds.Tables[0].Rows.Count> 0)
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


    protected void btnSave_Click(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();		//Object cmlDocument
        XmlElement nd;
        XmlNode node = doc.CreateElement("Root");	//Root Note
        int flag = 0;
        foreach (GridViewRow item in GrdComm.Rows)
        {
            XmlNode element = doc.CreateElement("Items");

            //nd = doc.CreateElement("Disc");
            //nd.SetAttribute("frm", ((TextBox)item.FindControl("TxtDisF")).Text.Trim());
            //nd.SetAttribute("to", ((TextBox)item.FindControl("txtdisTo")).Text.Trim());
            //element.AppendChild(nd);

            //nd = doc.CreateElement("Target");
            //nd.SetAttribute("frm", ((TextBox)item.FindControl("txttarfrm")).Text.Trim());
            //nd.SetAttribute("to", ((TextBox)item.FindControl("txttarto")).Text.Trim());
            //element.AppendChild(nd);

            //nd = doc.CreateElement("Comm");
            //nd.SetAttribute("f(zcom", ((TextBox)item.FindControl("txtzcomm")).Text.Trim());
            //nd.SetAttribute("scomm", ((TextBox)item.FindControl("txtscomm")).Text.Trim());
            //element.AppendChild(nd);

            //nd = doc.CreateElement("IsActive");
            //nd.InnerText = ((TextBox)item.FindControl("txtact")).Text.Trim();
            //element.AppendChild(nd);

            //node.AppendChild(element);

            //OtherClass.Idv_Chetana_InserXML(0, 0, 5, node.OuterXml.ToString());
            if (btnSave.Text == "Save")
            {
                nd = doc.CreateElement("Id");
                nd.InnerText = Convert.ToString(GetAutoId());
                element.AppendChild(nd);
                flag = 1;
            }
            else
            {
                nd = doc.CreateElement("Id");
                nd.InnerText = ((Label)item.FindControl("lbl1")).Text.Trim();
                element.AppendChild(nd);
            }

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

            //nd = doc.CreateElement("f");
            //nd.InnerText = Convert.ToInt32(strFY).ToString();
            //element.AppendChild(nd);

            nd = doc.CreateElement("a");
            nd.InnerText = ((TextBox)item.FindControl("txtact")).Text.Trim();
            element.AppendChild(nd);
            node.AppendChild(element);

          }

        OtherClass.Idv_Chetana_InserXML(0, 0,Convert.ToInt32(strFY), node.OuterXml.ToString(),flag );
        MessageBox("Records saved successfully...");
        GetData();
    }
}
