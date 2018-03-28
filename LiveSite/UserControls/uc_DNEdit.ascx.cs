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

public partial class UserControls_uc_DNEdit : System.Web.UI.UserControl
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
    string cramt;
    string dramt;
    string DNMID1;
    string DNDID1;
    int DNDID;
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
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
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
            Txtdocno.Focus();
            // Txtdebitamt.Text = "0";
            //Txtcreditamt.Text = "0";
        }
    }
    #endregion

    #region Events

    #region Click Events
    protected void btnSave_Click(object sender, EventArgs e)
    {
        docdate = TxtdocDate.Text.Split('/')[2] + "/" + TxtdocDate.Text.Split('/')[1] + "/" + TxtdocDate.Text.Split('/')[0];
        ddt = Convert.ToDateTime(docdate);
        flag0 = 0;
        getTotalCD();
       // if (flag0 == 1)
        // if ((TDbt > 0) && (TCdt > 0 ) && (TDbt == TCdt))
      //  {
            if (Session["UserName"] != null)
            {
                try
                {
                    DNMaster objdnm = new DNMaster();
                    int docno1 = Convert.ToInt32(Txtdocno.Text.Trim());
                    //  objcmpy.CompanyID = Convert.ToInt32(LblCmpID.Text);
                    DNMID1 = LblDNMasterID.Text.Trim();
                    //objdnm DNMasterID = Convert.ToInt32(LblDNMasterID.Text.Trim());
                    objdnm.DNMasterID = Convert.ToInt32(DNMID1);
                    objdnm.BookCode = TxtBookcode.Text.Trim();
                    objdnm.DNAccountCode = txtDNAccode.Text.Trim();
                    objdnm.DNDocDate = ddt;
                    objdnm.DNDocNo = docno1;
                    objdnm.IsActive = true;
                    //objdnm.CreatedBy = Session["UserName"].ToString();
                    objdnm.UpdatedBy = Session["UserName"].ToString();
                    objdnm.strFY = Convert.ToInt32(strFY);
                    objdnm.Save(out DocNo, out DNMID);
                    //Txtdocno.Text = Convert.ToString(DocNo);
                    SaveDNDetails();
                    MessageBox(Constants.save + "\\r\\n Document No: " + (Txtdocno.Text));
                    loder("Last saved Document no. : " + Txtdocno.Text);
                    txtDNAccode.Text = "";
                    lblDNacname.Text = "";
                    Txtdocno.Text = "";
                    LblDNMasterID.Text = "";
                    TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    Session["tempDNData"] = null;
                    btnSave.Visible = false;
                    GrdDN.DataBind();
                }
                catch
                {
                }
            }
       // }
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
        //string DocNost = Txtdocno.Text.Trim();
        int DocNo1 = Convert.ToInt32(Txtdocno.Text.Trim());
        int strFY1 = Convert.ToInt32(strFY);
        DataTable dt1 = new DataTable();
        dt1 = DNDetail.GetDN(DocNo1, strFY1).Tables[2];
        DataTable dt11 = new DataTable();
        dt11 = DNDetail.GetDN(DocNo1, strFY1).Tables[0];

        if ((dt1.Rows.Count != 0) && (dt1.Rows.Count != 0)) 
        {
            //TxtCmpycode.Text = "";
            //TxtBookcode.Text = "";
            //LblBookName.Text = "";
            //Txtdocno.Text = "";
            TxtdocDate.Text = Convert.ToString(dt11.Rows[0]["DNDocDate"]);
            LblDNMasterID.Text = Convert.ToString(dt11.Rows[0]["DNMasterID"]);
            txtDNAccode.Text = Convert.ToString(dt11.Rows[0]["DNAccountCode"]);
            lblDNacname.Text = Convert.ToString(dt11.Rows[0]["DNAccountName"]);

            GrdDN.DataSource = dt1;
            GrdDN.DataBind();
            btnSave.Visible = true;
            Session["tempDNData"] = dt1;
        }
        else
        {
            MessageBox("Invalid Document No.");
            TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            GrdDN.DataSource = DNDetail.GetDN(DocNo1, strFY1).Tables[2];
            GrdDN.DataBind();
        }
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

        DNDetail objdnd1 = new DNDetail();

        int dndid = Convert.ToInt32(((Label)GrdDN.Rows[e.RowIndex].FindControl("LblDNDID")).Text.Trim());

        if (dndid != 0)
        {
            objdnd1.Flag = "DNDetail";
            objdnd1.ID = dndid;
            objdnd1.IsActive = false;
            objdnd1.IsDeleted = true;
            objdnd1.deleteDNRec();
        }
        else
        {
        }

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
            Debit1 = Debit1 + Convert.ToDecimal(txtD1.Text.Trim());

            TextBox txtC1 = (TextBox)e.Row.FindControl("TxtCredit");
            Credit1 = Credit1 + Convert.ToDecimal(txtC1.Text.Trim());
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
            btnSave.Visible = true;
        }
        return dt;

    }
    #endregion

    #region SaveDNDetails
    public void SaveDNDetails()
    {
        if (Session["UserName"] != null)
        {
            try
            {
                DNDetail objdnd = new DNDetail();
                DNMID1 = LblDNMasterID.Text.Trim();
                foreach (GridViewRow Row in GrdDN.Rows)
                {
                    //objdnd.DNDetailID = Convert.ToInt32(((Label)Row.FindControl("LblDNDID")).Text.Trim());
                    //objdnd.DNMasterID = Convert.ToInt32(((Label)Row.FindControl("LblDNMID")).Text.Trim());
                    DNDID1 = ((Label)Row.FindControl("LblDNDID")).Text.Trim();
                    DNDID = Convert.ToInt32(DNDID1);
                    objdnd.DNDetailID = DNDID;
                    objdnd.DNMasterID = Convert.ToInt32(DNMID1);
                    objdnd.AccountCode = ((Label)Row.FindControl("LblAcode")).Text.Trim();
                     dramt = ((TextBox)Row.FindControl("TxtDebit")).Text.Trim();
                     cramt = ((TextBox)Row.FindControl("TxtCredit")).Text.Trim();
                    objdnd.CreditAmount = Convert.ToDecimal(cramt);
                    objdnd.DebitAmount = Convert.ToDecimal(dramt);
                    objdnd.Remarks = ((TextBox)Row.FindControl("TxtCmmt")).Text.Trim();
                    objdnd.IsActive = true;
                    objdnd.UpdatedBy = Session["UserName"].ToString();
                    objdnd.strFY = Convert.ToInt32(strFY);
                    if (DNDID > 0)
                    {
                        objdnd.UpdatedBy = Session["UserName"].ToString();
                    }
                    else
                    {
                        objdnd.CreatedBy = Session["UserName"].ToString();
                    }
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
        if (TDbt < TCdt)
        {
            //MessageBox("Total Credit Amount is Greater than Total Debit Amount");
            flag0 = 1;
        }
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
