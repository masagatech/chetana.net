using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Other_Z;
using System.Data;

public partial class Outstandingemailcust : System.Web.UI.Page
{
    #region Goloval Variable
    string strChetanaCompanyName = "";
    string strFY = "";
    string UserName = "";
    Other_Z.OtherBAL.outstandingAutomailProp ObjProp = new OtherBAL.outstandingAutomailProp();
    Other_Z.OtherBAL ObjDAL = new OtherBAL();
    #endregion


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
                    GetDataOutstanding();
                }
            }
        }
        else
        {
            Session.Clear();
        }
    }

    #region Message Box

    private void MessageBox(string message)
    {
        string Javascript = "alert('" + message + "')";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", Javascript, true);
    }

    #endregion

    #region Method Get Data
    private void GetDataOutstanding()
    {
        ObjProp.id = Convert.ToInt32(lblId.Text);
        ObjProp.FY = Convert.ToInt32(Session["FY"]);
        ObjProp.Flag = "";
        DataTable dt = ObjDAL.Idv_Chetana_Get_AutoOutStandingCustomer(ObjProp).Tables[0];
        if (dt.Rows.Count > 0)
        {
            lblId.Text = dt.Rows[0]["Autoid"].ToString();
            txtcc.Text = dt.Rows[0]["CC"].ToString();
            rbtnSendTo.Checked = Convert.ToInt32(dt.Rows[0]["SendTo"]).ToString() == "0" ? false : true;
            txtEmailIds.Text = dt.Rows[0]["EmailIds"].ToString();
            txtcc.Focus();
        }
        else
        {
            txtcc.Text = "";
            txtEmailIds.Text = "";
            rbtnSendTo.Checked = false;
            txtcc.Focus();
        }
    }
    #endregion

    #region Button Save Click Event
    protected void btnsave_Click(object sender, EventArgs e)
    {
        ObjProp.id = Convert.ToInt32(lblId.Text);
        ObjProp.CC = txtcc.Text.Trim();
        ObjProp.SendTo = Convert.ToInt32(rbtnSendTo.Checked);
        ObjProp.Emailids = txtEmailIds.Text.Trim();
        ObjProp.FY = Convert.ToInt32(Session["FY"]);
        ObjProp.CreatedBy = Session["UserName"].ToString();
        ObjProp.Flag = "";
        ObjProp.R1 = "";
        ObjProp.R2 = "";
        ObjProp.R3 = "";
        ObjProp.R4 = "";
        ObjProp.R5 = "";
        ObjDAL.Idv_Chetana_Save_AutoOutStandingCustomer(ObjProp);
        MessageBox("Data Save Successfully");
    }
    #endregion
}