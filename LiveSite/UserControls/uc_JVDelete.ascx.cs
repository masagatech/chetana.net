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

public partial class UserControls_uc_JVDelete : System.Web.UI.UserControl
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
        //SetView();
        if (!Page.IsPostBack)
        {
            //GrdJV.DataBind();
            //TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
           // Session["tempJVData"] = null;
            Txtdocno.Focus();
            btnDelete.Visible = false;
            // Txtdebitamt.Text = "0";
            //Txtcreditamt.Text = "0";
        }
    }
    #endregion

    #region Events

    #region Click
    protected void btnDelete_Click(object sender, EventArgs e)
    {
         if (Session["UserName"] != null)
            {
                try
                {
                    JVMaster objjdel = new JVMaster();
                    int docno1 = Convert.ToInt32(Txtdocno.Text.Trim());
                    int JVMID1 = Convert.ToInt32(LblJVMasterID.Text.Trim());
                    objjdel.JVMasterID = JVMID1;
                    objjdel.JVDocNo = docno1;
                    objjdel.UpdatedBy = Session["UserName"].ToString();
                    objjdel.strFY = Convert.ToInt32(strFY);
                    //AuditCutOffDate check
                    int i;
                    i = Global.Check_IsEditable("JVDel", Convert.ToInt32(JVMID1),Convert.ToInt32(strFY));
                    if (i == 1)
                    {

                        objjdel.DeleteJV();
                        MessageBox("Record Deleted Successfully " + (Txtdocno.Text));
                        //MessageBox("Record saved successfully");
                        GrdJV.DataBind();
                        btnDelete.Visible = false;
                        Txtdocno.Text = "";
                        Txtdocno.Focus();
                    }
                    else
                    {
                        MessageBox("You cannot delete JV with date less than CutOffDate:" + HttpContext.Current.Session["AuditCutOffDate"].ToString());
                    }
                }
             catch
                {
                }
            }
    }
    
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
            PnllGrdJv.Visible = true;
            btnDelete.Visible = true;
            TxtdocDate.Text = Convert.ToString(JVDetail.GetJV(DocNo2, strFY2).Tables[0].Rows[0]["JVDocDate"]);
            LblJVMasterID.Text = Convert.ToString(JVDetail.GetJV(DocNo2, strFY2).Tables[0].Rows[0]["JVMasterID"]);

            GrdJV.DataSource = JVDetail.GetJV(DocNo2, strFY2).Tables[2];
            GrdJV.DataBind();
            btnDelete.Focus();
        }
        else
        {
            MessageBox("Invalid Document No.");
            btnDelete.Visible = false;
            PnllGrdJv.Visible = false;
            //TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //GrdJV.DataSource = JVDetail.GetJV(DocNo2, strFY2).Tables[2];
            //GrdJV.DataBind();
            Txtdocno.Focus();
        }
        bool i = Global.ValidateDate(TxtdocDate.Text.ToString());
        if (i == true)
        { }
        else
        {
            btnDelete.Visible = false;
            //btnaddEntry.Visible = false;
            lblAuditMsg.Text = "You cannot Edit JV with date less than Audit CutOffDate:" + Session["AuditCutOffDate"].ToString();
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

 
    #region SetView
    //public void SetView()
    //{
    //    if (Request.QueryString["a"] != null)
    //    {
    //        if (Request.QueryString["a"] == "a")
    //        {
    //            pageName.InnerHtml = "View JV";
    //            btnDelete.Visible = false;
    //            Txtdocno.Focus();
    //        }
    //        else
    //            if (Request.QueryString["a"] == "v")
    //            {
    //                pageName.InnerHtml = "Delete JV";
    //                btnDelete.Visible = true;
    //                Txtdocno.Focus();
    //            }
    //    }
    //}
    #endregion

    // Method to Validate Total Debit is equal to Total Credit

    //#region getTotalCD
    ////public string getTotalCD(GridView GrdJV)
    ////{
    ////    foreach (GridViewRow row in GrdJV.Rows)
    ////    {
    ////        if (((TextBox)row.FindControl("TxtDebit")).Text != "")
    ////        {
    ////            Dbt = Convert.ToDecimal(((TextBox)row.FindControl("TxtDebit")).Text);
    ////        }
    ////        else
    ////        {
    ////            Dbt = 0;
    ////        }

    ////        if (((TextBox)row.FindControl("TxtCredit")).Text != "")
    ////        {
    ////            Cdt = Convert.ToDecimal(((TextBox)row.FindControl("TxtCredit")).Text);
    ////        }
    ////        else
    ////        {
    ////            Cdt = 0;
    ////        }

    ////        TDbt = TDbt + Dbt;
    ////        TCdt = TCdt + Cdt;
    ////    }
    ////    return TDbt.ToString();
    ////    return TCdt.ToString();
    ////}

    //public int getTotalCD()
    //{
    //    Dbt = 0;
    //    Cdt = 0;
    //    TDbt = 0;
    //    TCdt = 0;
    //    flag1 = 0;

    //    foreach (GridViewRow row in GrdJV.Rows)
    //    {
    //        if (((TextBox)row.FindControl("TxtDebit")).Text != "")
    //        {
    //            Dbt = Convert.ToDecimal(((TextBox)row.FindControl("TxtDebit")).Text);
    //        }
    //        else
    //        {
    //            Dbt = 0;
    //        }

    //        if (((TextBox)row.FindControl("TxtCredit")).Text != "")
    //        {
    //            Cdt = Convert.ToDecimal(((TextBox)row.FindControl("TxtCredit")).Text);
    //        }
    //        else
    //        {
    //            Cdt = 0;
    //        }

    //        TDbt = TDbt + Dbt;
    //        TCdt = TCdt + Cdt;


    //    }
    //    if (TDbt > TCdt)
    //    {
    //        MessageBox("Total Debit Amount And Total Credit Amount Should Be Equal");
    //        flag1 = 0;
    //    }
    //    if (TDbt < TCdt)
    //    {
    //        MessageBox("Total Debit Amount And Total Credit Amount Should Be Equal");
    //        flag1 = 0;
    //    }
    //    if ((TDbt > 0) && (TCdt > 0) && (TDbt == TCdt))
    //    {
    //        flag1 = 1;
    //    }
    //    //return TDbt ;
    //    //return TCdt ;
    //    return flag1;
    //}
    //#endregion

    #endregion

}
