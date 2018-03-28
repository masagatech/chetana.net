#region NameSpace

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
using Idv.Chetana.BAL;
using Idv.Chetana.Common;

#endregion
public partial class UserControls_uc_JVView : System.Web.UI.UserControl
{
    #region Variables
    string TJVDetailID = "0";
    string TJVMasterID = "0";
    string TAccountCode;
    string TAccountName;
    string TReportCode;
    string TDebit;
    string TCredit;
    string TComment;
    int DocNo;
    int JVMID;
    string docdate;
    DateTime ddt;
    string cramt;
    string dramt;
    string JVMID1;
    string JVDID1;
    int JVDID;
    static Decimal Debit1;
    static Decimal Credit1;

    decimal Dbt = 0;
    decimal Cdt = 0;
    decimal TDbt = 0;
    decimal TCdt = 0;
    int flag1;

    string strChetanaCompanyName = "cppl";
    string strFY;
    #endregion

    #region Page_Load
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
            Txtdocno.Focus();
        }
    }
    #endregion

    #region Events

    #region Click
    
    #endregion

    #region TextChanged
    
    protected void Txtdocno_TextChanged(object sender, EventArgs e)
    {
        string DocNost = Txtdocno.Text.Trim();
        int DocNo2 = Convert.ToInt32(DocNost);
        int strFY2 = Convert.ToInt32(strFY);
        DataTable dt1 = new DataTable();
        dt1 = JVDetail.GetJV(DocNo2, strFY2).Tables[2];

        if (dt1.Rows.Count != 0)
        {
            //TxtCmpycode.Text = "";
            //TxtBookcode.Text = "";
            //LblBookName.Text = "";
            //Txtdocno.Text = "";
            TxtdocDate.Text = Convert.ToString(JVDetail.GetJV(DocNo2, strFY2).Tables[0].Rows[0]["JVDocDate"]);
            LblJVMasterID.Text = Convert.ToString(JVDetail.GetJV(DocNo2, strFY2).Tables[0].Rows[0]["JVMasterID"]);

            GrdJV.DataSource = JVDetail.GetJV(DocNo2, strFY2).Tables[2];
            GrdJV.DataBind();
        }
        else
        {
            MessageBox("Invalid Document No.");
            //TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //GrdJV.DataSource = JVDetail.GetJV(DocNo2, strFY2).Tables[2];
            //GrdJV.DataBind();
        }
    }
    #endregion

    #region Grid Events
    protected void GrdJV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            Debit1 = 0;
            Credit1 = 0;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtD1 = (TextBox)e.Row.FindControl("TxtDebit");
            Decimal d1 = Convert.ToDecimal(txtD1.Text.Trim());
            Debit1 = Debit1 + d1;

            TextBox txtC1 = (TextBox)e.Row.FindControl("TxtCredit");
            Decimal c1 = Convert.ToDecimal(txtC1.Text.Trim());
            Credit1 = Credit1 + c1;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTD1 = (Label)e.Row.FindControl("LblTotalDebit");
            lblTD1.Text = Debit1.ToString().Trim();

            Label lblTC1 = (Label)e.Row.FindControl("LblTotalCredit");
            lblTC1.Text = Credit1.ToString().Trim();

        }
    }

  
    #endregion

    #endregion

    #region Methods

    #region MessageBox
    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    #endregion

}
