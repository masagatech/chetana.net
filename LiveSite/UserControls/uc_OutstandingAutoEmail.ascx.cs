using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Other_Z;
using System.Data;

public partial class UserControls_OutstandingAutoEmail : System.Web.UI.UserControl
{
    #region Goloval Variable
    string strChetanaCompanyName = "";
    string strFY = "";
    string UserName = "";
    Other_Z.OtherBAL.outstandingAutomailProp ObjProp = new OtherBAL.outstandingAutomailProp();
    Other_Z.OtherBAL ObjDAL = new OtherBAL();
    #endregion

    #region
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                if (!Page.IsPostBack)
                {
                    
                    strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                    strFY = Session["FY"].ToString();
                    UserName = Session["UserName"].ToString();
                    if (Request.QueryString["For"] != null)
                    {
                        if (Request.QueryString["For"]=="a" )
                        {
                            GetDataOutstanding("a");
                            lblFlag.Text = "Amount";
                            txtCC.Visible = false;
                            txtEmailIds.Visible = false;
                            rbtnSendTo.Visible = false;
                            txtAmount.Visible = true;
                            label2.Visible = false;
                            label1.Visible = false;
                            txtAmount.Focus();
                        }
                        else
                        {
                            GetDataOutstanding("c");
                            lblFlag.Text = "CC";
                            txtAmount.Visible = false;
                            txtCC.Visible = true;
                            txtCC.Focus();
                        }
                    }
                    else
                    {
                        Session.Clear();
                    }
                }
            }
        }
        else
        {
            Session.Clear();
        }

    }
    #endregion

    #region Method Get Data
    private void GetDataOutstanding(string Flag)
    {
        ObjProp.id = Convert.ToInt32(lblId.Text);
        ObjProp.FY = Convert.ToInt32(Session["FY"]);
        ObjProp.Flag = "";
        ObjProp.Flag = Flag;
        DataTable dt = ObjDAL.Idv_Chetana_Get_AutoOutStandingConfig(ObjProp).Tables[0];
        if (dt.Rows.Count > 0)
        {
            lblId.Text = dt.Rows[0]["Autoid"].ToString();
            txtAmount.Text = dt.Rows[0]["Amount"].ToString();
            txtCC.Text = dt.Rows[0]["CC"].ToString();
            rbtnSendTo.Checked = Convert.ToInt32(dt.Rows[0]["SendTo"]).ToString() == "0" ? false : true;
            //txtEmailIds.Text = dt.Rows[0]["EmailIds"].ToString();
        }
        else
        {
            txtAmount.Text = "";
            //txtEmailIds.Text = "";
            txtCC.Text = "";
            rbtnSendTo.Checked = false;
        }
    }
    #endregion

    #region Message Box
    private void MessageBox(string message)
    {
        string Javascript = "alert('" + message + "')";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", Javascript, true);
    }
    #endregion

    #region Save Button Click Event
    protected void btnsave_Click(object sender, EventArgs e)
    {
        ObjProp.id = Convert.ToInt32(lblId.Text);
        ObjProp.Amount = Convert.ToInt32(txtAmount.Text =="" ? "0" : txtAmount.Text);
        ObjProp.SendTo = Convert.ToInt32(rbtnSendTo.Checked);
        //ObjProp.Emailids = txtEmailIds.Text.Trim();
        ObjProp.FY = Convert.ToInt32(Session["FY"]);
        ObjProp.CreatedBy = Session["UserName"].ToString();
        ObjProp.Flag = "a";
        ObjProp.R1 = "";
        ObjProp.R2 = "";
        ObjProp.R3 = "";
        ObjProp.R4 = "";
        ObjProp.R5 = "";
        int MaxId;
        if (Request.QueryString["For"] == "a")
        {
            ObjDAL.Idv_Chetana_Save_AutoOutStandingConfig(ObjProp,out MaxId);
            lblId.Text = MaxId.ToString();
            txtAmount.Focus();
        }
        else
        {
            ObjProp.Amount = Convert.ToInt32("0");
            ObjProp.CC = txtCC.Text;
            ObjProp.Flag = "c";
            ObjDAL.Idv_Chetana_Save_AutoOutStandingConfig(ObjProp, out MaxId);
            lblId.Text = MaxId.ToString();
            txtCC.Focus();
        }
        MessageBox("Data Save Successfully");
    }
    #endregion
}