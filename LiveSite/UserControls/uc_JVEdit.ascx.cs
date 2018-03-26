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

public partial class UserControls_uc_JVEdit : System.Web.UI.UserControl
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
    bool IscustomerEdit = false;
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
            Session["tempJVData"] = null;
            btnSave.Visible = false;
            Txtdocno.Focus();
            // Txtdebitamt.Text = "0";
            //Txtcreditamt.Text = "0";
        }
    }
    #endregion

    #region Events

    #region Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        docdate = TxtdocDate.Text.Split('/')[2] + "/" + TxtdocDate.Text.Split('/')[1] + "/" + TxtdocDate.Text.Split('/')[0];
        ddt = Convert.ToDateTime(docdate);

        flag1 = 0;
        getTotalCD();
        if (flag1 == 1)
        {
            if (Session["UserName"] != null)
            {
                try
                {
                    JVMaster objjvm = new JVMaster();
                    int docno1 = Convert.ToInt32(Txtdocno.Text.Trim());
                    //  objcmpy.CompanyID = Convert.ToInt32(LblCmpID.Text);

                    //objjvm.JVMasterID = Convert.ToInt32(LblJVMasterID.Text.Trim());

                    JVMID1 = LblJVMasterID.Text.Trim();
                    //if (((LblJVMasterID.Text)== "" )||((LblJVMasterID.Text) != "0" ))
                    //{
                    //    objjvm.JVMasterID = 0;
                    //}
                    //else
                    //{
                    //    objjvm.JVMasterID = Convert.ToInt32(JVMID1);
                    //}
                    objjvm.JVMasterID = Convert.ToInt32(JVMID1);
                    objjvm.CompanyCode = TxtCmpycode.Text.Trim();
                    objjvm.BookCode = TxtBookcode.Text.Trim();
                    objjvm.JVDocDate = ddt;
                    objjvm.JVDocNo = docno1;
                    objjvm.Isactive = Convert.ToBoolean(true);
                    //objjvm.CreatedBy = Session["UserName"].ToString();
                    objjvm.UpdatedBy = Session["UserName"].ToString();
                    objjvm.strFY = Convert.ToInt32(strFY);
                    objjvm.Save(out DocNo, out JVMID);
                    //Txtdocno.Text = Convert.ToString(DocNo);
                    SaveJVDetails();
                    MessageBox(Constants.save + "\\r\\n Document No: " + (Txtdocno.Text));
                    loder("Last saved Document no. : " + Txtdocno.Text);
                    Txtdocno.Text = "";
                    LblJVMasterID.Text = "";
                    TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    Session["tempJVData"] = null;
                    btnSave.Visible = false;
                    GrdJV.DataBind();
                }
                catch
                {
                }
            }
        }
        else
        {
        }
    }
    protected void btnaddEntry_Click(object sender, EventArgs e)
    {
        if (Txtdebitamt.Text == "" && Txtcreditamt.Text == "")
        {
            MessageBox("Enter Debit or Credit Amount");
        }

        else
        {
            if (Txtdebitamt.Text != "")
            {
                if (Txtcreditamt.Text == "")
                {
                    Txtcreditamt.Text = "0";
                }
            }
            if (Txtcreditamt.Text != "")
            {
                if (Txtdebitamt.Text == "")
                {
                    Txtdebitamt.Text = "0";
                }
            }

            decimal da = Convert.ToDecimal(Txtdebitamt.Text.Trim());
            decimal ca = Convert.ToDecimal(Txtcreditamt.Text.Trim());

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

                    TJVDetailID = "0";
                    TJVMasterID = "0";

                    TAccountCode = txtAccode.Text.Trim();
                    TAccountName = lblaccname.Text.Trim();
                    TReportCode = txtreportcode.Text.Trim();
                    TDebit = Txtdebitamt.Text.Trim();
                    TCredit = Txtcreditamt.Text.Trim();
                    TComment = TxtComment.Text.Trim();

                    DataTable dt1 = new DataTable();
                    if (Session["tempJVData"] != null)
                    {
                        Session["tempJVData"] = fillTempJVData();
                        dt1 = (DataTable)Session["tempJVData"];
                    }
                    else
                    {
                        Session["tempJVData"] = fillTempJVData();
                        dt1 = (DataTable)Session["tempJVData"];
                    }
                    GrdJV.DataSource = dt1;
                    GrdJV.DataBind();

                    //  TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    txtAccode.Text = "";
                    lblaccname.Text = "";
                    txtreportcode.Text = "";
                    lblacname.Text = "";
                    Txtdebitamt.Text = "";
                    Txtcreditamt.Text = "";
                    TxtComment.Text = "";

                    txtAccode.Focus();
                }
            }
            catch
            {

            }
        }
    }
    #endregion

    #region TextChanged
    protected void txtAccode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string Accode = txtAccode.Text.ToString().Split(':')[0].Trim();
            string flag = txtAccode.Text.ToString().Split(':', '[', ']')[3].Trim();
            DataTable dt1 = new DataTable();
            dt1 = DCMaster.Get_Name(Accode, flag).Tables[0];
            if (dt1.Rows.Count != 0)
            {
                if (flag == "AC")
                {
                    txtAccode.Text = Accode;
                    lblaccname.Text = Convert.ToString(dt1.Rows[0]["AC_NAME"]);
                    //txtperson.Focus();
                }
                else
                    if (flag == "Cust")
                    {
                        txtAccode.Text = Accode;
                        lblaccname.Text = Convert.ToString(dt1.Rows[0]["CustName"]);
                        // txtperson.Focus();
                    }
                txtreportcode.Focus();
            }
            else
            {
                lblaccname.Text = "No such Account code";
                txtAccode.Focus();
                txtAccode.Text = "";
            }
        }
        catch
        {
            lblaccname.Text = "No such Account code";
        }
    }

    protected void txtcode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox txtcode = ((TextBox)((TextBox)sender).FindControl("txtcode"));
            Label lblname = ((Label)((TextBox)sender).FindControl("LblAname1"));
            string Accode = txtcode.Text.ToString().Split(':')[0].Trim();
            string flag = txtcode.Text.ToString().Split(':', '[', ']')[3].Trim();
            DataTable dtcode = new DataTable();
            dtcode = DCMaster.Get_Name(Accode, flag).Tables[0];
            if (dtcode.Rows.Count != 0)
            {
                if (flag == "AC")
                {
                    txtcode.Text = Accode;
                    lblname.Text = Convert.ToString(dtcode.Rows[0]["AC_NAME"]);
                    //txtperson.Focus();
                }
                else if (flag == "Cust")
                {
                    txtcode.Text = Accode;
                    lblname.Text = Convert.ToString(dtcode.Rows[0]["CustName"]);
                    // txtperson.Focus();
                }
                IscustomerEdit = true;
            }
            else
            {
                lblname.Text = "No such Account code";

                txtcode.Text = "";
            }
        }
        catch
        {
            //lblname.Text = "No such Account code";
        }
    }


    protected void txtreportcode_TextChanged(object sender, EventArgs e)
    {
        string Reportcode = txtreportcode.Text.ToString().Split(':')[0].Trim();
        string flag = txtreportcode.Text.ToString().Split(':', '[', ']')[3].Trim();
        DataTable dt2 = new DataTable();
        dt2 = DCMaster.Get_Name(Reportcode, flag).Tables[0];
        if (dt2.Rows.Count != 0)
        {
            if (flag == "AC")
            {
                txtreportcode.Text = Reportcode;
                lblacname.Text = Convert.ToString(dt2.Rows[0]["AC_NAME"]);
                // DDLCCDD.Focus();
            }
            else
                if (flag == "Cust")
                {
                    txtreportcode.Text = Reportcode;
                    lblacname.Text = Convert.ToString(dt2.Rows[0]["CustName"]);
                    //   DDLCCDD.Focus();
                }
            Txtdebitamt.Focus();
        }
        else
        {
            lblacname.Text = "No such Report code";
            txtreportcode.Focus();
            txtreportcode.Text = "";
        }
    }
    protected void Txtcreditamt_TextChanged(object sender, EventArgs e)
    {
        TxtComment.Focus();
    }
    protected void Txtdebitamt_TextChanged(object sender, EventArgs e)
    {
        Txtcreditamt.Focus();
    }

    protected void Txtdocno_TextChanged(object sender, EventArgs e)
    {
        txtAccode.Text = "";
        Txtdebitamt.Text = "";
        Txtcreditamt.Text = "";

        string DocNost = Txtdocno.Text.Trim();
        int DocNo2 = Convert.ToInt32(DocNost);
        int strFY2 = Convert.ToInt32(strFY);

        DataTable dt1 = new DataTable();
        dt1 = JVDetail.GetJV(DocNo2, strFY2).Tables[2];
        DataTable dt11 = new DataTable();
        dt11 = JVDetail.GetJV(DocNo2, strFY2).Tables[0];
        if (dt11.Rows.Count != 0)
        {
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
                btnSave.Visible = true;
                Session["tempJVData"] = dt1;
            }

            if (dt1.Rows.Count == 0)
            {
                TxtdocDate.Text = Convert.ToString(JVDetail.GetJV(DocNo2, strFY2).Tables[0].Rows[0]["JVDocDate"]);
                LblJVMasterID.Text = Convert.ToString(JVDetail.GetJV(DocNo2, strFY2).Tables[0].Rows[0]["JVMasterID"]);

                GrdJV.DataBind();
                btnSave.Visible = false;
            }

            bool i = Global.ValidateDate(TxtdocDate.Text.ToString());
            if (i == true)
            { }
            else
            {
                btnSave.Visible = false;
                btnaddEntry.Visible = false;
             
               lblmsg1.Text  = "You cannot Edit JV with date less than Audit CutOffDate:" + Session["AuditCutOffDate"].ToString();
            }


        }
        else
        {
            MessageBox("Invalid Document No.");
            TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnSave.Visible = false;
            //GrdJV.DataSource = JVDetail.GetJV(DocNo2, strFY2).Tables[2];
            GrdJV.DataBind();
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
        Decimal d1;
        Decimal c1;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TextBox txtD1 = (TextBox)e.Row.FindControl("txtDebit");
            d1 = Convert.ToDecimal(txtD1.Text.Trim());
            Debit1 = Debit1 + d1;
            txtD1.Attributes.Add("onkeyup", "TOTAL()");
            TextBox txtC1 = (TextBox)e.Row.FindControl("txtCredit");
            c1 = Convert.ToDecimal(txtC1.Text.Trim());
            Credit1 = Credit1 + c1;
            txtC1.Attributes.Add("onkeyup", "TOTAL()");


        }


        if (e.Row.RowType == DataControlRowType.Footer)
        {

            TextBox lblTD1 = (TextBox)e.Row.FindControl("LblTotalDebit");
            lblTD1.Text = Debit1.ToString().Trim();

            TextBox lblTC1 = (TextBox)e.Row.FindControl("LblTotalCredit");
            lblTC1.Text = Credit1.ToString().Trim();

        }
    }

    protected void GrdJV_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt2 = new DataTable();
        dt2 = (DataTable)Session["tempJVData"];
        JVDetail objjvd1 = new JVDetail();

        int jvdid = Convert.ToInt32(((Label)GrdJV.Rows[e.RowIndex].FindControl("LblJVDID")).Text.Trim());

        if (jvdid != 0)
        {
            objjvd1.Flag = "JVDetail";
            objjvd1.ID = jvdid;
            objjvd1.Isactive = Convert.ToBoolean(false);
            objjvd1.IsDeleted = Convert.ToBoolean(true);
            objjvd1.deleteJVRec();
        }
        else
        {
        }

        //dt2.Rows[e.RowIndex].Delete();
        //GrdJV.DataSource = dt2;
        //GrdJV.DataBind();
        //Session["tempJVData"] = dt2;

        dt2.Rows[e.RowIndex].Delete();
        DataView dv = new DataView(dt2);
        dv.RowFilter = "JVDetailID is not null";
        GrdJV.DataSource = dv;
        GrdJV.DataBind();

        Session["tempJVData"] = dv.ToTable();

        dt2 = (DataTable)Session["tempJVData"];
        if (dt2.Rows.Count == 0)
        {
            btnSave.Visible = false;
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

    #region Fill grid data for JV entry
    public DataTable fillTempJVData()
    {
        DataTable dt = new DataTable();
        //DataTable tempGetData = new DataTable();

        //DataColumn colTax = new DataColumn();
        //colTax.DataType = System.Type.GetType("System.String");
        //colTax.ColumnName = "Rate";
        //DataColumn Discount = new DataColumn();
        //Discount.DataType = System.Type.GetType("System.String");
        //Discount.ColumnName = "Discount";
        //DataColumn AdditionalDiscount = new DataColumn();
        //AdditionalDiscount.DataType = System.Type.GetType("System.String");
        //AdditionalDiscount.ColumnName = "AdditionalDiscount";
        //DataColumn Amount = new DataColumn();
        //Amount.DataType = System.Type.GetType("System.String");
        //Amount.ColumnName = "Amount";

        if (Session["tempJVData"] == null)
        {
            //CREATE NEW DATATABLE
            //ADD COLUMNS IN DATATABLE
            dt.Columns.Add("JVDetailID");
            dt.Columns.Add("JVMasterID");
            dt.Columns.Add("AccountCode");
            dt.Columns.Add("AccountName");
            dt.Columns.Add("ReportCode");
            dt.Columns.Add("DebitAmount");
            dt.Columns.Add("CreditAmount");
            dt.Columns.Add("Comment");

            dt.Rows.Add(TJVDetailID, TJVMasterID, TAccountCode, TAccountName, TReportCode, TDebit, TCredit, TComment);
            btnSave.Visible = true;
            //  return dt;
            //  ADD DATA AS PER COLUMNS
        }
        else
        {
            dt = (DataTable)Session["tempJVData"];
            dt.Rows.Add(TJVDetailID, TJVMasterID, TAccountCode, TAccountName, TReportCode, TDebit, TCredit, TComment);
            btnSave.Visible = true;
        }
        return dt;
        //if (dt.Rows.Count < 1)
        //{
        //    dt.Rows.Add(TJVDetailID, TJVMasterID, TAccountCode, TAccountName, TReportCode, TDebit, TCredit, TComment);
        //}
        //else
        //    if (dt.Rows.Count != 0)
        //    {
        //        dt.Rows.Add(TJVDetailID, TJVMasterID, TAccountCode, TAccountName, TReportCode, TDebit, TCredit, TComment);
        //    }
        //return dt;
        //tempGetData = Books.Get_BooksMasterForDC(bookcode, srate).Tables[0];

        //foreach (DataRow row in tempGetData.Rows)
        //{
        //    price = row["SellingPrice"].ToString();
        //    if (price == "")
        //    {
        //        price = "0";
        //    }
        //    amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(price);
        //  int i = 0;
        //if (dt.Rows.Count != 0)
        //{
        //if (i == 0)
        //{
        //DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString(), row["BookCode"].ToString());

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        //    Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
        //    Tdiscount = amt * (discount / 100);
        //    amt = amt - Tdiscount;
        //}
        //dt.Rows.Add(dcid, row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), rqty, Qty,
        //    String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:0.00}", Convert.ToDecimal(amt)),
        //    String.Format("{0:0.00}", Convert.ToDecimal(discount)), String.Format("{0:0.00}", Convert.ToDecimal(Adddiscount)), "");
        //}
        // }
        //else
        //{
        //DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString(), row["BookCode"].ToString());

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        //    Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
        //    //  Totaldiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][2]);
        //    Tdiscount = amt * (discount / 100);
        //    amt = amt - Tdiscount;
        //}
        //    dt.Rows.Add(dcid, row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), rqty, Qty,
        //        String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:0.00}", Convert.ToDecimal(amt)),
        //        String.Format("{0:0.00}", Convert.ToDecimal(discount)), String.Format("{0:0.00}", Convert.ToDecimal(Adddiscount)), "");
        //}
        //}
        //return dt;
    }
    #endregion

    #region SaveJVDetails
    public void SaveJVDetails()
    {
        if (Session["UserName"] != null)
        {
            try
            {
                JVDetail objjvd = new JVDetail();
                JVMID1 = LblJVMasterID.Text.Trim();
                foreach (GridViewRow Row in GrdJV.Rows)
                {
                    //objjvd.JVDetailID = Convert.ToInt32(((Label)Row.FindControl("LblJVDID")).Text.Trim());
                    //objjvd.JVMasterID = Convert.ToInt32(((Label)Row.FindControl("LblJVMID")).Text.Trim());
                    JVDID1 = ((Label)Row.FindControl("LblJVDID")).Text.Trim();
                    JVDID = Convert.ToInt32(JVDID1);
                    objjvd.JVDetailID = JVDID;
                    objjvd.JVMasterID = Convert.ToInt32(JVMID1);
                    objjvd.AccountCode = ((TextBox)Row.FindControl("txtcode")).Text.Trim();
                    objjvd.ReportCode = ((Label)Row.FindControl("LblRcode")).Text.Trim();
                    dramt = ((TextBox)Row.FindControl("txtDebit")).Text.Trim();
                    cramt = ((TextBox)Row.FindControl("txtCredit")).Text.Trim();
                    objjvd.CreditAmount = Convert.ToDecimal(cramt);
                    objjvd.DebitAmount = Convert.ToDecimal(dramt);
                    objjvd.Remarks = ((TextBox)Row.FindControl("txtCmmt")).Text.Trim();
                    objjvd.Isactive = true;
                    objjvd.strFY = Convert.ToInt32(strFY);
                    if (JVDID > 0)
                    {
                        objjvd.UpdatedBy = Session["UserName"].ToString();
                    }
                    else
                    {
                        objjvd.CreatedBy = Session["UserName"].ToString();
                    }

                    //AuditCutOffDate check
                    int i;
                    i = Global.Check_IsEditable("JV", Convert.ToInt32(JVDID),Convert.ToInt32(strFY));
                    if (i == 1)
                    {
                        objjvd.Save();
                    }
                    else
                    {
                        MessageBox("You cannot edit JV with date less than CutOffDate:" + HttpContext.Current.Session["AuditCutOffDate"].ToString());
                    }
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

    // Method to Validate Total Debit is equal to Total Credit

    #region getTotalCD
    //public string getTotalCD(GridView GrdJV)
    //{
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
    //    return TDbt.ToString();
    //    return TCdt.ToString();
    //}

    public decimal getTotalCD()
    {
        Dbt = 0;
        Cdt = 0;
        TDbt = 0;
        TCdt = 0;
        flag1 = 0;

        foreach (GridViewRow row in GrdJV.Rows)
        {
            if (((TextBox)row.FindControl("txtDebit")).Text != "")
            {
                Dbt = Convert.ToDecimal(((TextBox)row.FindControl("txtDebit")).Text);
            }
            else
            {
                Dbt = 0;
            }

            if (((TextBox)row.FindControl("txtCredit")).Text != "")
            {
                Cdt = Convert.ToDecimal(((TextBox)row.FindControl("txtCredit")).Text);
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
            MessageBox("Total Debit Amount And Total Credit Amount Should Be Equal");
            flag1 = 0;
        }
        if (TDbt < TCdt)
        {
            MessageBox("Total Debit Amount And Total Credit Amount Should Be Equal");
            flag1 = 0;
        }
        if ((TDbt > 0) && (TCdt > 0) && (TDbt == TCdt))
        {
            flag1 = 1;
        }
        //return TDbt ;
        //return TCdt ;
        return flag1;
    }
    #endregion

    #endregion

    //protected void GrdJV_RowEditing(object sender, GridViewEditEventArgs e)
    //{

    //    GrdJV.EditIndex = e.NewEditIndex;
    //    GrdJV.DataSource = (DataTable)Session["tempJVData"];
    //    GrdJV.DataBind();
    //    Txtdocno.Enabled = false;

    //}

    //protected void GrdJV_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    GrdJV.EditIndex = -1;

    //    if (IscustomerEdit == true)
    //    {
    //        try
    //        {
    //            JVDetail objjvd = new JVDetail();
    //            JVMID1 = LblJVMasterID.Text.Trim();
    //            JVDID1 = ((Label)GrdJV.Rows[e.RowIndex].FindControl("LblJVDIDedit")).Text.Trim();
    //            JVDID = Convert.ToInt32(JVDID1);
    //            objjvd.JVDetailID = JVDID;
    //            objjvd.JVMasterID = Convert.ToInt32(JVMID1);
    //            objjvd.AccountCode = ((TextBox)GrdJV.Rows[e.RowIndex].FindControl("txtcode")).Text.Trim();
    //            objjvd.ReportCode = "";
    //            dramt = ((TextBox)GrdJV.Rows[e.RowIndex].FindControl("TxtDebit")).Text.Trim();
    //            cramt = ((TextBox)GrdJV.Rows[e.RowIndex].FindControl("TxtCredit")).Text.Trim();
    //            objjvd.CreditAmount = Convert.ToDecimal(cramt);
    //            objjvd.DebitAmount = Convert.ToDecimal(dramt);
    //            objjvd.Remarks = ((TextBox)GrdJV.Rows[e.RowIndex].FindControl("TxtCmmt")).Text.Trim();
    //            objjvd.Isactive = true;
    //            objjvd.strFY = Convert.ToInt32(strFY);
    //            if (JVDID > 0)
    //            {
    //                objjvd.UpdatedBy = Session["UserName"].ToString();
    //            }
    //            else
    //            {
    //                objjvd.CreatedBy = Session["UserName"].ToString();
    //            }
    //            objjvd.Flag = "Customer";
    //            objjvd.Save();
    //            DataTable dtedit = new DataTable();
    //            dtedit = JVDetail.GetJV(Convert.ToInt32(Txtdocno.Text), Convert.ToInt32(strFY)).Tables[2];
    //            GrdJV.DataSource = dtedit;
    //            GrdJV.DataBind();
    //            Session["tempJVData"] = dtedit;
    //            Txtdocno.Enabled = true;
    //        }
    //        catch { }
    //    }
    //    else
    //    {

    //        Txtdocno.Enabled = true;
    //    }




    //}
    //protected void GrdJV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    GrdJV.EditIndex = -1;
    //    DataTable dtedit = new DataTable();
    //    dtedit = JVDetail.GetJV(Convert.ToInt32(Txtdocno.Text), Convert.ToInt32(strFY)).Tables[2];
    //    GrdJV.DataSource = dtedit;
    //    GrdJV.DataBind();
    //    Txtdocno.Enabled = true;
    //}
}
