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
using System.Xml.Linq;
using Other_Z;
using Idv.Chetana.BAL;
using System.Text;

public partial class Token_Register_View : System.Web.UI.Page
{
    #region ALl Veriable Declaretion
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    DataTable dt = new DataTable();
    DataTable newdt = new DataTable();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Page Load Session Validation
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                if (!IsPostBack)
                {
                    rbtnToken.Checked = true;
                    txtTokenFind.Focus();
                }
            }
        }
        else
        {
            Session.Clear();
        }
        #endregion
    }
    protected void rbtnKyc_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rbtn = sender as RadioButton;
        if (rbtn.ID == "rbtnToken")
        {
            txtTokenFind.Text = "";
            KycNoWise.Visible = false;
            DateWise.Visible = false;
            TokenWise.Visible = true;
            txtTokenFind.Focus();
        }
        else if (rbtn.ID == "rbtnKyc")
        {
            txtTokenFind.Text = "";
            txtKycFind.Text = "";
            KycNoWise.Visible = true;
            TokenWise.Visible = false;
            DateWise.Visible = false;
            txtKycFind.Focus();
        }
        else
        {
            txtTokenFind.Text = "";
            txtKycFind.Text = "";
            txtFromDate.Text ="01/04/201"+Convert.ToInt32(strFY);
            //txtFromDate.Text = "";
            txtToDate.Text ="31/03/201"+Convert.ToInt32(Convert.ToInt32(strFY)+1);
            DateWise.Visible = true;
            KycNoWise.Visible = false;
            TokenWise.Visible = false;
            txtFromDate.Focus();
        }
    }

    #region All Grid View Data Checked Method
    public void CheckedAllRecord()
    {
        foreach (GridViewRow item in grdTokenRegister.Rows)
        {
            //Grid View ChckedBox Id = gridchk
            CheckBox chk = (CheckBox)item.FindControl("gridChk");
            chk.Checked = false;
        }
    }
    #endregion

    #region Get Method Data With FY
    private DataTable updateGrid(string R3)
    {
        string Id = "";
        string R1 = "";
        string R2 = "";
        string PrintId = ""; 
        string strTemp="";
        string FromDate = DateTime.Now.ToString("MM/dd/yyyy");
        string ToDate = DateTime.Now.ToString("MM/dd/yyyy");
        int TokenKyc=0;
        int FY = Convert.ToInt32(Session["FY"]);
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        DataTable dtgrid = new DataTable();
        if (rbtnToken.Checked)
        {
            TokenKyc = Convert.ToInt32(txtTokenFind.Text.Trim());
            strTemp = "TokenNo";
        }
        else if (rbtnKyc.Checked)
        {
            TokenKyc = Convert.ToInt32(txtKycFind.Text.Trim());
            strTemp = "KycNo";
        }
        else if (rbtDatewise.Checked) {
             FromDate = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
            ToDate = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
           
        }
        DataSet ds = ObjBAL.Idv_Chetana_Get_Token_Register(Id, R1, R2, R3, FY, TokenKyc,PrintId,
            rbtDatewise.Checked == true ? Convert.ToDateTime(FromDate):Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")),
            rbtDatewise.Checked == true ? Convert.ToDateTime(ToDate): Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"))) ;
        dtgrid = ds.Tables[0];
        
        if (dtgrid.Rows.Count == 0)
        {
            if (rbtDatewise.Checked)
            {
                MessageBox("Record Not Found ");
                txtFromDate.Focus();
            }
            else if (rbtnKyc.Checked)
            {
                MessageBox("Record Not Found ");
                txtKycFind.Focus();
            }
            else if (rbtnToken.Checked)
            {
                MessageBox("Record Not Found ");
                txtTokenFind.Focus();
            }
            
        }
        return dtgrid;
    }
    #endregion

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    private void BindGridWithSession(DataTable dt)
    {
        grdTokenRegister.DataSource = dt;
        grdTokenRegister.DataBind();
    }

    protected void Get_Click(object sender, EventArgs e)
    {
        Button rbtn = sender as Button;
        DataTable dt = new DataTable();
        if (rbtn.ID == "kycbtnGet")
        {
            dt = updateGrid("KycNo");
            BindGridWithSession(dt);
            CheckedAllRecord();
            
        }
        else if (rbtn.ID == "btnToken")
        {
                dt = updateGrid("TokenNo");
                BindGridWithSession(dt);
                CheckedAllRecord();
                btnPrintKycNo.Visible = true;
        }
        else
        {
            txtKycFind.Text = "0";
            dt = updateGrid("");
            BindGridWithSession(dt);
            CheckedAllRecord();
            
        }
    }

    #region Data Print Method
    public DataTable DataPrint(string R3,string PrintId)
    {
        string Id = "";
        string R1 = "";
        string R2 = "";
        int TokenKyc=0;
        int FY = Convert.ToInt32(Session["FY"]);
        Other_Z.OtherBAL ObjBAL = new OtherBAL();
        DataTable dtgrid = new DataTable();
        DataSet ds = ObjBAL.Idv_Chetana_Get_Token_Register(Id, R1, R2, R3, FY, TokenKyc, PrintId,Convert.ToDateTime(null),
            Convert.ToDateTime(null));
       return dtgrid = ds.Tables[0];
    }
    #endregion

    protected void btnPrintChecked_Click(object sender, EventArgs e)
    {
        Session["TokenRegisterReport"] = null;
        string TokenNo="";
        StringBuilder sb = new StringBuilder();

        if (grdTokenRegister.Rows.Count > 0)
        {
            foreach (GridViewRow item in grdTokenRegister.Rows)
            {
                CheckBox chk = (CheckBox)item.FindControl("gridChk");
                if (chk.Checked == true)
                {
                    TokenNo = Convert.ToInt32(((Label)chk.Parent.FindControl("lblTokenNo")).Text).ToString();
                    sb.Append(TokenNo + ",");
                }
            }
            if (TokenNo == "")
            {
                    MessageBox("Please Select The Record");
                    txtFromDate.Focus();
                    return;
            }
        }
        else
        {
            if (rbtDatewise.Checked)
            {
                MessageBox("Record Not Found ");
                txtFromDate.Focus();
                return;
            }
            else if (rbtnKyc.Checked)
            {
                MessageBox("Record Not Found ");
                txtKycFind.Focus();
                return;
            }
            else if (rbtnToken.Checked)
            {
                MessageBox("Record Not Found ");
                txtTokenFind.Focus();
                return;
            }
        }
        
       DataTable dt = DataPrint("print",sb.ToString());
       Session["TokenRegisterReport"] = dt;
        //Response.Redirect("Token_Register_Report.aspx");
       Page.ClientScript.RegisterStartupScript(
       this.GetType(), "OpenWindow", "window.open('Token_Register_Report.aspx');", true);

    }
    protected void grdTokenRegister_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void grdTokenRegister_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
