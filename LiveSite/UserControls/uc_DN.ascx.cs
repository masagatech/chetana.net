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


public partial class UserControls_uc_DN : System.Web.UI.UserControl
{
    #region Variables
    string TDNDetailID = "0";
    string TDNMasterID = "0";
    string TAccountCode;
    string TAccountName;
    string TDebit;
    string TCredit;
    string TComment;
    int DocNo;
    int DNMID;
    string docdate;
    DateTime ddt;
    static decimal Debit1;
    static decimal Credit1;

    decimal Dbt;
    decimal Cdt;
    decimal TDbt;
    decimal TCdt;
    int flag0;

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
            //GrdJV.DataBind();
            TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Session["tempDNData"] = null;
            btnSave.Visible = false;
            txtDNAccode.Focus();
            // Txtdebitamt.Text = "0";
            //Txtcreditamt.Text = "0";

        }
    }
    #endregion

    #region Events

    #region Click Events
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //docdate = TxtdocDate.Text.Split('/')[2] + "/" + TxtdocDate.Text.Split('/')[1] + "/" + TxtdocDate.Text.Split('/')[0];
        docdate = TxtdocDate.Text.Split('/')[1] + "/" + TxtdocDate.Text.Split('/')[0] + "/" + TxtdocDate.Text.Split('/')[2];
       // string date = txtDate.Text.Split('/')[1] + "/" + txtDate.Text.Split('/')[0] + "/" + txtDate.Text.Split('/')[2];

        ddt = Convert.ToDateTime(docdate);
        flag0 = 0;
        getTotalCD();
        //if (flag0 == 0)
        // if ((TDbt > 0) && (TCdt > 0 ) && (TDbt == TCdt))
        //{
            if (Session["UserName"] != null)
            {
                try
                {
                    DNMaster objdnm = new DNMaster();

                    //  objcmpy.CompanyID = Convert.ToInt32(LblCmpID.Text);

                    //objdnm DNMasterID = Convert.ToInt32(LblDNMasterID.Text.Trim());
                    objdnm.DNMasterID = 0;
                    objdnm.BookCode = TxtBookcode.Text.Trim();
                    objdnm.DNAccountCode = txtDNAccode.Text.Trim();
                    objdnm.DNDocDate = ddt;
                    objdnm.DNDocNo = 0;
                    objdnm.IsActive = true;
                    objdnm.CreatedBy = Session["UserName"].ToString();
                    objdnm.strFY = Convert.ToInt32(strFY);
                   
                    //Validate date against Audit CutOffDate

                   bool i = Global.ValidateDate(ddt.ToString());
                   if (i == true)
                   {

                       objdnm.Save(out DocNo, out DNMID);
                       Txtdocno.Text = Convert.ToString(DocNo);
                       SaveDNDetails(DNMID);
                       MessageBox(Constants.save + "\\r\\n Document No: " + (Txtdocno.Text));
                       loder("Last saved Document no. : " + Txtdocno.Text);
                       txtDNAccode.Text = "";
                       lblDNacname.Text = "";
                       Txtdocno.Text = "";
                       TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                       Session["tempDNData"] = null;
                       btnSave.Visible = false;
                       GrdDN.DataBind();
                   }
                   else
                   {
                       MessageBox("You cannot create DC with Order Date less than CutOffDate:" + HttpContext.Current.Session["AuditCutOffDate"].ToString() + " and should in current financial year.");
                   }
                }
                catch
                {
                }
            }
        //}
        else
        {
            //if (TDbt > TCdt)
            //{

            //    MessageBox("Debit Amount is Greater than Credit Amount");
            //}
            //if (TDbt < TCdt)
            //{

            //    MessageBox("Credit Amount is Greater than Debit Amount");
            //}
        }
    }
    protected void btnaddEntry_Click(object sender, EventArgs e)
    {
        //if (Txtdebitamt.Text == "" &&  Txtcreditamt.Text == "")
        //{
        //    MessageBox("Enter Debit or Credit Amount");
        //}
        //else
        //{
        if (Txtdebitamt.Text == "")
        {
            Txtdebitamt.Text = "0";
        }
        if (Txtcreditamt.Text == "")
        {
            Txtcreditamt.Text = "0";
        }

        int da = Convert.ToInt32(Txtdebitamt.Text.Trim());
        int ca = Convert.ToInt32(Txtcreditamt.Text.Trim());

        try
        {
            if (da > 0 & ca > 0)
            {
                MessageBox(" Enter Only Debit Amount or Credit Amount");
            }
            if ((da == 0 & ca == 0) || (Txtdebitamt.Text == "" && Txtcreditamt.Text == ""))
            {
                MessageBox(" Enter Debit Amount or Credit Amount");
            }
            if ((da > 0 & ca == 0) || (da == 0 & ca > 0))
            {

                TDNDetailID = "0";
                TDNMasterID = "0";

                TAccountCode = txtAccode.Text.Trim();
                TAccountName = lblaccname.Text.Trim();
                TDebit = Txtdebitamt.Text.Trim();
                TCredit = Txtcreditamt.Text.Trim();
                TComment = TxtComment.Text.Trim();

                DataTable dt1 = new DataTable();
                if (Session["tempDNData"] != null)
                {
                    Session["tempDNData"] = fillTempDNData();
                    dt1 = (DataTable)Session["tempDNData"];
                }
                else
                {
                    Session["tempDNData"] = fillTempDNData();
                    dt1 = (DataTable)Session["tempDNData"];
                }
                GrdDN.DataSource = dt1;
                GrdDN.DataBind();

                // TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                Txtdebitamt.Text = "";
                Txtcreditamt.Text = "";
                txtAccode.Text = "";
                lblaccname.Text = "";
                TxtComment.Text = "";

                txtAccode.Focus();
            }
        }
        catch
        {
        }
        //}
    }

    #endregion

    #region TextChanged Events
    protected void txtDNAccode_TextChanged(object sender, EventArgs e)
    {
        string DNAccode = txtDNAccode.Text.ToString().Split(':')[0].Trim();
        string flag1 = txtDNAccode.Text.ToString().Split(':', '[', ']')[3].Trim();
        DataTable dt11 = new DataTable();
        dt11 = DCMaster.Get_Name(DNAccode, flag1).Tables[0];
        if (dt11.Rows.Count != 0)
        {
            if (flag1 == "AC")
            {
                txtDNAccode.Text = DNAccode;
                lblDNacname.Text = Convert.ToString(dt11.Rows[0]["AC_NAME"]);
                //txtperson.Focus();
            }
            else
                if (flag1 == "Cust")
                {
                    txtDNAccode.Text = DNAccode;
                    lblDNacname.Text = Convert.ToString(dt11.Rows[0]["CustName"]);
                    // txtperson.Focus();
                }
        }
        else
        {
            lblDNacname.Text = "No such Account code";
            txtDNAccode.Focus();
            txtDNAccode.Text = "";
        }
    }
    protected void txtAccode_TextChanged(object sender, EventArgs e)
    {
        string Accode = txtAccode.Text.ToString().Split(':')[0].Trim();
        string flag2 = txtAccode.Text.ToString().Split(':', '[', ']')[3].Trim();
        DataTable dt12 = new DataTable();
        dt12 = DCMaster.Get_Name(Accode, flag2).Tables[0];
        if (dt12.Rows.Count != 0)
        {
            if (flag2 == "AC")
            {
                txtAccode.Text = Accode;
                lblaccname.Text = Convert.ToString(dt12.Rows[0]["AC_NAME"]);
                //txtperson.Focus();
            }
            else
                if (flag2 == "Cust")
                {
                    txtAccode.Text = Accode;
                    lblaccname.Text = Convert.ToString(dt12.Rows[0]["CustName"]);
                    // txtperson.Focus();
                }
        }
        else
        {
            lblaccname.Text = "No such Account code";
            txtAccode.Focus();
            txtAccode.Text = "";
        }
    }
    protected void Txtdocno_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Txtdebitamt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Txtcreditamt_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TxtDebit_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TxtCredit_TextChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region Grid Events
    protected void GrdDN_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt2 = new DataTable();
        dt2 = (DataTable)Session["tempDNData"];
        dt2.Rows[e.RowIndex].Delete();
        GrdDN.DataSource = dt2;
        GrdDN.DataBind();
        Session["tempDNData"] = dt2;

        if (dt2.Rows.Count == 0)
        {
            btnSave.Visible = false;
        }
        else
        {
            btnSave.Visible = true;
        }
    }
    protected void GrdDN_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            Debit1 = 0;
            Credit1 = 0;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtD1 = (TextBox)e.Row.FindControl("TxtDebit");
            Debit1 = Debit1 + Convert.ToInt32(txtD1.Text.Trim());

            TextBox txtC1 = (TextBox)e.Row.FindControl("TxtCredit");
            Credit1 = Credit1 + Convert.ToInt32(txtC1.Text.Trim());
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

    #region Fill grid data for DNentry
    public DataTable fillTempDNData()
    {
        DataTable dt = new DataTable();

        if (Session["tempDNData"] == null)
        {
            //CREATE NEW DATATABLE
            //ADD COLUMNS IN DATATABLE
            dt.Columns.Add("DNDetailID");
            dt.Columns.Add("DNMasterID");
            dt.Columns.Add("AccountCode");
            dt.Columns.Add("AccountName");
            dt.Columns.Add("DebitAmount");
            dt.Columns.Add("CreditAmount");
            dt.Columns.Add("Comment");

            dt.Rows.Add(TDNDetailID, TDNMasterID, TAccountCode, TAccountName, TDebit, TCredit, TComment);
            btnSave.Visible = true;
            //return dt;
            //ADD DATA AS PER COLUMNS
        }
        else
        {
            dt = (DataTable)Session["tempDNData"];
            dt.Rows.Add(TDNDetailID, TDNMasterID, TAccountCode, TAccountName, TDebit, TCredit, TComment);
            //btnSave.Visible = true;
        }
        return dt;

    }
    #endregion

    #region SaveDNDetails
    public void SaveDNDetails(int DMMID)
    {
        if (Session["UserName"] != null)
        {
            try
            {
                DNDetail objdnd = new DNDetail();

                foreach (GridViewRow Row in GrdDN.Rows)
                {
                    //objdnd.DNDetailID = Convert.ToInt32(((Label)Row.FindControl("LblDNDID")).Text.Trim());
                    //objdnd.DNMasterID = Convert.ToInt32(((Label)Row.FindControl("LblDNMID")).Text.Trim());
                    objdnd.DNDetailID = 0;
                    objdnd.DNMasterID = DNMID;
                    objdnd.AccountCode = ((Label)Row.FindControl("LblAcode")).Text.Trim();
                    string dramt = ((TextBox)Row.FindControl("TxtDebit")).Text.Trim();
                    string cramt = ((TextBox)Row.FindControl("TxtCredit")).Text.Trim();
                    objdnd.CreditAmount = Convert.ToInt32(cramt);
                    objdnd.DebitAmount = Convert.ToInt32(dramt);
                    objdnd.Remarks = ((TextBox)Row.FindControl("TxtCmmt")).Text.Trim();
                    objdnd.IsActive = true;
                    objdnd.CreatedBy = Session["UserName"].ToString();
                    objdnd.strFY = Convert.ToInt32(strFY);
                    objdnd.Save();
                }

                //objjvd.AccountCode  = txtAccode.Text.Trim();
                //objjvd.ReportCode   = txtreportcode.Text.Trim();

                //objjvd.CreditAmount = Convert.ToInt32(Txtcreditamt.Text.Trim());
                //objjvd.DebitAmount  = Convert.ToInt32(Txtdebitamt.Text.Trim());
                //objjvd.Remarks      = TxtComment.Text.Trim();

                //MessageBox("Record saved successfully");
            }
            catch
            {
            }
        }
    }
    #endregion

    #region getTotalCD
    public int getTotalCD()
    {
        Dbt = 0;
        Cdt = 0;
        TDbt = 0;
        TCdt = 0;
        flag0 = 0;

        foreach (GridViewRow row in GrdDN.Rows)
        {
            if (((TextBox)row.FindControl("TxtDebit")).Text != "")
            {
                Dbt = Convert.ToDecimal(((TextBox)row.FindControl("TxtDebit")).Text);
            }
            else
            {
                Dbt = 0;
            }

            if (((TextBox)row.FindControl("TxtCredit")).Text != "")
            {
                Cdt = Convert.ToDecimal(((TextBox)row.FindControl("TxtCredit")).Text);
            }
            else
            {
                Cdt = 0;
            }

            TDbt = TDbt + Dbt;
            TCdt = TCdt + Cdt;


        }
        if (TDbt > TCdt)
        {
            // MessageBox("Total Debit Amount is Greater than Total Credit Amount");
            flag0 = 1;
        }
        //if (TDbt < TCdt)
        //{
        //    MessageBox("Total Credit Amount is Greater than Total Debit Amount");
        //    flag0 = 0;
        //}
        //if ((TDbt > 0) && (TCdt > 0) && (TDbt == TCdt))
        //{
        //    MessageBox("Total Credit Amount & Total Debit Amount Are Equal");
        //    flag0 = 0;
        //}
        //return TDbt ;
        //return TCdt ;
        return flag0;
    }
    #endregion

    #endregion
}

