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
public partial class UserControls_uc_JV : System.Web.UI.UserControl
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
        static decimal Debit1;
        static decimal Credit1;

        decimal Dbt ;
        decimal Cdt ;
        decimal TDbt ;
        decimal TCdt ;
        int flag1 ;

        string strChetanaCompanyName = "cppl";
        string strFY;
    #endregion

    #region  Page_Load
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
            TxtdocDate.Focus();
            //txtAccode.Focus();
            // Txtdebitamt.Text = "0";
            //Txtcreditamt.Text = "0";
        }
    }
    #endregion

    #region Events

    #region GridEvents
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
    protected void GrdJV_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt2 = new DataTable();
        dt2 = (DataTable)Session["tempJVData"];
        dt2.Rows[e.RowIndex].Delete();
        GrdJV.DataSource = dt2;
        GrdJV.DataBind();
        Session["tempJVData"] = dt2;

        if (dt2.Rows.Count == 0)
        {
            btnSave.Visible = false;
        }
    }
    #endregion

    #region Click Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        docdate = TxtdocDate.Text.Split('/')[2] + "/" + TxtdocDate.Text.Split('/')[1] + "/" + TxtdocDate.Text.Split('/')[0];
        ddt = Convert.ToDateTime(docdate);
        flag1 = 0;
        getTotalCD();
        if(flag1 == 1)
       // if ((TDbt > 0) && (TCdt > 0 ) && (TDbt == TCdt))
        {
            if (Session["UserName"] != null)
            {
                try
                {
                    JVMaster objjvm = new JVMaster();

                    //  objcmpy.CompanyID = Convert.ToInt32(LblCmpID.Text);

                    //objjvm.JVMasterID = Convert.ToInt32(LblJVMasterID.Text.Trim());
                    objjvm.JVMasterID = 0;
                    objjvm.CompanyCode = TxtCmpycode.Text.Trim();
                    objjvm.BookCode = TxtBookcode.Text.Trim();
                    objjvm.JVDocDate = ddt;
                    objjvm.JVDocNo = 0;
                    objjvm.Isactive = true;
                    objjvm.CreatedBy = Session["UserName"].ToString();
                    objjvm.strFY = Convert.ToInt32(strFY);
                    objjvm.Save(out DocNo, out JVMID);
                    Txtdocno.Text = Convert.ToString(DocNo);
                    SaveJVDetails(JVMID);
                    MessageBox(Constants.save + "\\r\\n Document No: " + (Txtdocno.Text));
                    loder("Last saved Document no. : " + Txtdocno.Text);
                    Txtdocno.Text = "";
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
               // TxtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                txtAccode.Text = "";
                lblaccname.Text = "";
                txtreportcode.Text = "";
                lblacname.Text = "";
                Txtdebitamt.Text = "";
                Txtcreditamt.Text = "";


                txtAccode.Focus();
            }
        }
        catch
        {
        }
        //}
    }
    #endregion

    #region TextChanged
    protected void TxtDebit_TextChanged(object sender, EventArgs e)
    {
        Txtcreditamt.Text = "0";
    }
    protected void TxtCredit_TextChanged(object sender, EventArgs e)
    {
        Txtdebitamt.Text = "0";
    }
    protected void Txtdocno_TextChanged(object sender, EventArgs e)
    {

    }
    //public DataTable fillTempBookData(string bookcode, string flag)
    //{
    //    if (Session["tempDCData"] == null)
    //    {
    //        //CREATE NEW DATATABLE
    //        //ADD COLUMNS IN DATATABLE
    //        dt.Columns.Add("AccountCod");
    //        dt.Columns.Add("AccountName");
    //        dt.Columns.Add("ReportCode");
    //        dt.Columns.Add("Medium");
    //        dt.Columns.Add("Quantity");
    //        dt.Columns.Add("GivedQty");
    //        dt.Columns.Add("RemainQty");
    //        dt.Columns.Add("DeliveryDate");
    //        dt.Columns.Add(colTax);
    //        dt.Columns.Add(Amount);
    //        dt.Columns.Add(Discount);
    //        dt.Columns.Add(AdditionalDiscount);
    //        //ADD DATA AS PER COLUMNS
    //        //Books _objBooks = new Books();
    //    }
    //    return dt;
    //}

    protected void txtAccode_TextChanged(object sender, EventArgs e)
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
            //txtreportcode.Focus();
            Txtdebitamt.Focus();
        }
        else
        {
            lblaccname.Text = "No such Account code";
            txtAccode.Focus();
            txtAccode.Text = "";
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

    protected void Txtdebitamt_TextChanged(object sender, EventArgs e)
    {
        Txtcreditamt.Focus();
    }
    protected void Txtcreditamt_TextChanged(object sender, EventArgs e)
    {
        TxtComment.Focus();
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
            //return dt;
            //ADD DATA AS PER COLUMNS
        }
        else
        {  
            dt = (DataTable)Session["tempJVData"];
            dt.Rows.Add(TJVDetailID, TJVMasterID, TAccountCode, TAccountName, TReportCode, TDebit, TCredit, TComment);
           // btnSave.Visible = true;
        }
        return dt;
        //if (dt.Rows.Count < 1)
        //{
        //    dt.Rows.Add(TJVDetailID, TJVMasterID, TAccountCode, TAccountName, TReportCode, TDebit, TCredit, TComment);
        //}
        //else
        //if (dt.Rows.Count !=0)
        //{
        //    dt.Rows.Add(TJVDetailID, TJVMasterID, TAccountCode, TAccountName, TReportCode, TDebit, TCredit, TComment);
        //}
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
    public void SaveJVDetails(int JVMID)
    {
        if (Session["UserName"] != null)
        {
            try
            {
                JVDetail objjvd = new JVDetail();

                foreach (GridViewRow Row in GrdJV.Rows)
                {
                    //objjvd.JVDetailID = Convert.ToInt32(((Label)Row.FindControl("LblJVDID")).Text.Trim());
                    //objjvd.JVMasterID = Convert.ToInt32(((Label)Row.FindControl("LblJVMID")).Text.Trim());
                    objjvd.JVDetailID = 0;
                    objjvd.JVMasterID = JVMID;
                    objjvd.AccountCode = ((Label)Row.FindControl("LblAcode")).Text.Trim();
                    objjvd.ReportCode = ((Label)Row.FindControl("LblRcode")).Text.Trim();
                    string dramt = ((TextBox)Row.FindControl("TxtDebit")).Text.Trim();
                    string cramt = ((TextBox)Row.FindControl("TxtCredit")).Text.Trim();
                    objjvd.CreditAmount = Convert.ToDecimal(cramt);
                    objjvd.DebitAmount = Convert.ToDecimal(dramt);
                    objjvd.Remarks = ((TextBox)Row.FindControl("TxtCmmt")).Text.Trim();
                    objjvd.Isactive = true;
                    objjvd.CreatedBy = Session["UserName"].ToString();
                    objjvd.strFY = Convert.ToInt32(strFY);
                    objjvd.Save();
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
    public int getTotalCD()
    {
        Dbt = 0;
        Cdt = 0;
        TDbt = 0;
        TCdt = 0;
        flag1 = 0;

        foreach (GridViewRow row in GrdJV.Rows)
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
        return flag1 ;
    }
    #endregion

    #endregion
    
}
