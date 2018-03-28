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

public partial class UserControls_ODC_uc_DC_GenerateCN : System.Web.UI.UserControl
{
    #region Variables
    static int CNNo = 0;
    string CustCode;
    //static int quantity = 0;
    //static decimal tamount = 0;
    static decimal tnamount = 0;

    string Qty = "1";
   // string Dqty = "0";
    int Reqty, givqty;
    decimal amt;
    string rqty = "1";
    string bookname = "";
    string gqty = "0";
    string dcid = "0";
    string price;
    int DCDid;
    static string srate = "";
    decimal discount;
    decimal Adddiscount;
    decimal Tdiscount;
    string flag1;
    static int tabindex = 20;
    static int rquantity = 0;
    //static int dquantity = 0;
    static int quantity = 0;
    static decimal tamount = 0;
    //int GCN;
    //int SCN;
    string cndate;
    DateTime cndt;

    string strChetanaCompanyName = "cppl";
    string strFY;
    
    #endregion

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
            BindDDLstd();
            // string std = "Standard";
            Session["tempDCData"] = null;
            quantity = 0;
            tamount = 0;
           // PnlAddBook.Visible = false;
           // btn_Save.Visible = false;
            PnlAddbk.Visible = false;
            PnlPrint.Visible = false;
            btnPrint.Visible = false;

            txtcustomer.Focus();
            try
            {
            txtCNDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch 
            {


            }
        }
    }
 
    #region Events

    #region SelectedIndexChanged
    protected void DDLstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        AutoCompleteExtender1.ContextKey = "book_" + DDLstandard.SelectedItem.Text;
        txtbkcod.Focus();
    }

    #endregion

    #region TextChangedEvents
    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        //PnlAddbk.Visible = false;
        grdBookDetails.DataBind();
        PnlPrint.Visible = false;
        btnPrint.Visible = false;
        txtbkcod.Text = "";
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "CustomerNAC").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustNameCA"]);
            PnlAddBook.Visible = true;

            if (dt.Rows[0]["State"].ToString().ToLower() == "maharashtra")
            {
                srate = "l";
            }
            else
            {
                srate = "m";
            }
        }
        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
            srate = "";
        }

        btngetRec.Focus();

    }

    protected void lbltransporter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (lbltransporter.Text != "")
            {
                string TransCode = (lbltransporter.Text.ToString().Split(':', '[', ']')[0].Trim());
                flag1 = (lbltransporter.Text.ToString().Split('[', ']')[1].Trim());

                if (flag1 == "Emp")
                {
                    string Empname = (lbltransporter.Text.ToString().Split(':', '[')[2].Trim());
                    (lbltransporter.Text) = Empname;
                }
                else if (flag1 == "Trans")
                {
                    (lbltransporter.Text) = TransCode;
                }
                else
                {
                    (lbltransporter.Text) = "No such record found";
                }

            }
        }

        catch
        {

        }
    }

    protected void txtbkcod_TextChanged(object sender, EventArgs e)
    {
        txtbookqty.Focus();
    }
    
    #endregion

    #region AddBook
    protected void btnaddBooks_Click(object sender, EventArgs e)
    {
        grdBookDetails.Focus();
        if (srate == "")
        {
            MessageBox("Kindly select Customer");
            txtcustomer.Focus();
        }
        else
        {
            setStateGridview();
            Qty = Convert.ToString(txtbookqty.Text.Trim());
            rqty = Convert.ToString(txtbookqty.Text.Trim());
            if (Qty == "" || Qty == "0")
            {
                Qty = "1";
                rqty = "1";
               // Dqty = "0";

            }
            if (txtbookqty.Text != "")
            {
                rqty = Convert.ToString(txtbookqty.Text);
                Qty = Convert.ToString(txtbookqty.Text);
            }
            try
            {
                string bookcode = txtbkcod.Text.Split(':')[0].Trim();
                bookname = txtbkcod.Text.Split(':')[2].Trim();

                DataTable dt1 = new DataTable();
                if (Session["tempDCData"] != null)
                {
                    dt1 = (DataTable)Session["tempDCData"];
                    DataView dv = new DataView(dt1);
                    dv.RowFilter = "BookCode = '" + bookcode.Trim() + "'";
                    int i = 0;
                    foreach (DataRowView row in dv)
                    {
                        i++;
                    }
                    if (i == 0)
                    {
                        Session["tempDCData"] = fillTempBookData(bookcode.Trim(), "");
                        dt1 = (DataTable)Session["tempDCData"];
                        loder(bookname + " added successfully", "3000");
                    }
                    else
                    {
                        loder(bookname + " already added!", "3000");
                    }
                }
                else
                {
                    Session["tempDCData"] = fillTempBookData(bookcode.Trim(), "");
                    dt1 = (DataTable)Session["tempDCData"];
                    loder(bookname + " added successfully", "3000");
                }
                grdBookDetails.DataSource = dt1;
                grdBookDetails.DataBind();
                if (grdBookDetails.Rows.Count > 0)
                {
                    btn_Save.Visible = true;
                }
                else
                {
                    btn_Save.Visible = false;
                }

                string jv = "clearAddbook()";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "as", jv, true);
                txtbkcod.Focus();
            }
            catch
            {
            }
        }
       txtbkcod.Focus();
    }
    
    #endregion

    #region Save
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        btn_Save.Enabled = false;
        cndate = txtCNDate.Text.Split('/')[2] + "/" + txtCNDate.Text.Split('/')[1] + "/" + txtCNDate.Text.Split('/')[0];
        cndt = Convert.ToDateTime(cndate);

        CNNo = 0;
        bool flag = false;
        CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        int GCN;
        int SCN;
        if (Txtgcn.Text.Trim() == "")
        {
            Txtgcn.Text = "0";
        }
        if (Txtscn.Text.Trim() == "")
        {
            Txtscn.Text = "0";
        }

        GCN = Convert.ToInt32(Txtgcn.Text.Trim());
        SCN = Convert.ToInt32(Txtscn.Text.Trim());


        if (Session["UserName"] != null)
        {
            DCReturnBook _obdcrtbk1 = new DCReturnBook();
            CreditNote _obcn1 = new CreditNote();
            LedgerCN _oblcn1 = new LedgerCN();
            CNNo = Convert.ToInt32(CreditNote.GetCNNo(Convert.ToInt32(strFY)));
            lblCNNo.Text = CreditNote.GetCNNo(Convert.ToInt32(strFY));

            try
            {
                if (grdBookDetails.Rows.Count == 0)
                {
                    MessageBox("Kindly fill Book details");
                }
                else
                {
                    //Response.Write("HERE");
                    foreach (GridViewRow Row in grdBookDetails.Rows)
                    {
                        string RQty = ((TextBox)Row.FindControl("txtretquty")).Text.Trim();
                        // string DfQty = ((TextBox)Row.FindControl("txtdefquty")).Text.Trim();
                        string CrQty = ((TextBox)Row.FindControl("txtquty")).Text.Trim();

                        _obdcrtbk1.DCReturnBkID = 0;
                        _obdcrtbk1.CustCode = CustCode;
                        _obdcrtbk1.BookCode = (((Label)Row.FindControl("lblBookCode")).Text.Trim());
                        _obdcrtbk1.ReturnQty = Convert.ToInt32(RQty);
                        // _obdcrtbk1.DefectQty = Convert.ToInt32(DfQty);
                        _obdcrtbk1.DefectQty = 0;
                        _obdcrtbk1.Comment = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();
                        _obdcrtbk1.CreatedBy = Session["UserName"].ToString();
                        _obdcrtbk1.Flag = "Manual";

                        _obcn1.AutoID = 0;
                        _obcn1.CNNo = CNNo;
                        _obcn1.CustCode = CustCode;
                        _obcn1.BookCode = (((Label)Row.FindControl("lblBookCode")).Text.Trim());
                        _obcn1.Rate = Convert.ToDecimal(((TextBox)Row.FindControl("txtrate")).Text.Trim());
                        _obcn1.Discount = Convert.ToDecimal(((TextBox)Row.FindControl("txtDiscount")).Text.Trim());
                        _obcn1.ReturnQty = Convert.ToInt32(CrQty);
                        _obcn1.DefectQty = 0;
                        _obcn1.TotReturnQty = Convert.ToInt32(RQty);
                        _obcn1.Flag = "Manual";
                        _obcn1.Comment = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();
                        _obcn1.IsActive = true;
                        _obcn1.GCN = GCN;
                        _obcn1.SCN = SCN;
                        _obcn1.CreatedBy = Session["UserName"].ToString();
                        _obcn1.strFY = Convert.ToInt32(strFY);
                        _oblcn1.CNNo = CNNo;
                        _oblcn1.strFY = Convert.ToInt32(strFY);
                        _oblcn1.CNDate = cndt;
                        _obcn1.CNDate = cndt;

                        _obcn1.TransportName = lbltransporter.Text.ToString();
                        _obcn1.LrNo = txtlrno.Text.ToString();
                        _obcn1.Remark1 = "";
                        _obcn1.Remark2 = "";
                        _obcn1.Remark3 = "";
                        _obcn1.Remark4 = "";
                        _obcn1.Remark5 = "";
                        _obdcrtbk1.Save_DC_ReturnBook();
                       // Response.Write("Save_DC_ReturnBook");
                        _obcn1.Save_CN(Convert.ToInt32(strFY));
                       // Response.Write("Save_CN");
                        flag = true;
                    }
                }
                if (flag)
                {
                    _oblcn1.Ledger_CN();
                   // Response.Write("Ledger_CN");
                    //MessageBox(Constants.save);
                    MessageBox(Constants.save + "\\r\\n CreditNote No: " + CNNo);
                    Bindgrdcn();
                    //Session["tempDCData"].;
                    Session["tempDCData"] = null;
                    // grdBookDetails.DataSource = Session["tempDCData"];
                    grdBookDetails.DataBind();
                    quantity = 0;
                    tamount = 0;
                    ClearFields();

                    DataTable dt1 = new DataTable();
                    dt1 = DCReturnBook.GetCustAddress(CustCode, "CNCustlist").Tables[0];
                    if (dt1.Rows.Count > 0)
                    {
                        lblCustName1.Text = dt1.Rows[0]["CustName"].ToString();
                        lblCustAddress.Text = dt1.Rows[0]["Address"].ToString();
                    }
                    PnlAddBook.Visible = false;
                    btn_Save.Visible = false;
                    PnlPrint.Visible = true;
                    btnPrint.Visible = true;
                }
            }
            //catch(Exception ex)
            //{
            //    Response.Write(ex.Message.ToString());
            //    Response.End();
            //}
            catch (Exception ex)
            {
               
                txtcustomer.Text = ex.Message.ToString();
            }
        }
    }
    #endregion
    #region Print
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintCreditNote.aspx?d=" + lblCNNo.Text.Trim() + "&fy=" + strFY + "')", true);
    }
    
    #endregion
    #region Clear
    protected void btnclear_Click(object sender, EventArgs e)
    {
        Session["tempDCData"] = null;
        grdBookDetails.Dispose();
    }
    
    #endregion

    #region GridEvents

    TextBox txtrqty;
   // TextBox txtdqty;
    TextBox txtqty;
    TextBox txtrate;

    Label lblAmt;
    TextBox txtdisc;
   // Label lbladddisc;

    protected void grdBookDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            rquantity = 0;
          //  dquantity = 0;
            quantity = 0;
            tamount = 0;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            txtrqty = (TextBox)e.Row.FindControl("txtretquty");
            rquantity = rquantity + Convert.ToInt32(txtrqty.Text.Trim());

           // txtdqty = (TextBox)e.Row.FindControl("txtdefquty");
          //  dquantity = dquantity + Convert.ToInt32(txtdqty.Text.Trim());
            
            txtqty = (TextBox)e.Row.FindControl("txtquty");
            quantity = quantity + Convert.ToInt32(txtqty.Text.Trim());
            
            txtrate = (TextBox)e.Row.FindControl("txtrate");
            lblAmt = (Label)e.Row.FindControl("lblAmt");

            tamount = tamount + Convert.ToDecimal(lblAmt.Text.Trim());
            txtdisc = (TextBox)e.Row.FindControl("txtDiscount");
            //  lbladddisc = (Label)e.Row.FindControl("txtAddDiscount");

            //txtrqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "')");
            //tabindex = tabindex + 1;
            //txtrqty.Attributes.Add("TabIndex", tabindex.ToString());

           // txtdqty.Attributes.Add("onkeyup", "SetMaxNum('" + txtdqty.ClientID + "','" + txtrqty.ClientID + "')");
            txtqty.Attributes.Add("onkeyup", "SetMaxNum('" + txtqty.ClientID + "','" + txtrqty.ClientID + "')," + "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "')");

            //txtdqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "')");
            //tabindex = tabindex + 1;
            //txtdqty.Attributes.Add("TabIndex", tabindex.ToString());

            //txtqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "')");
            tabindex = tabindex + 1;
            txtqty.Attributes.Add("TabIndex", tabindex.ToString());

            // txtDeldate.Attributes.Add("onkeyup", "multiplyQty(this," + txtrate.ClientID + "," + lblAmt.ClientID + "," + txtdisc.ClientID + ")");

            txtrate.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "')");
            tabindex = tabindex + 1;
            txtrate.Attributes.Add("TabIndex", tabindex.ToString());

            txtdisc.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID +  "')");
            tabindex = tabindex + 1;
            txtdisc.Attributes.Add("TabIndex", tabindex.ToString());

            if (e.Row.FindControl("lblgivedqty") != null)
            {
                Label lblconfirmQty = (Label)e.Row.FindControl("lblgivedqty");
                if (lblconfirmQty.Text != "0")
                {
                    ImageButton imgremovw = (ImageButton)e.Row.FindControl("btnRemove");
                    imgremovw.Visible = false;
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl2 = (Label)e.Row.FindControl("lblTotalretqty");
            lbl2.Text = rquantity.ToString().Trim();
            //Label lbl3 = (Label)e.Row.FindControl("lblTotaldefqty");
           // lbl3.Text = dquantity.ToString().Trim();
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalamt");
            lblamt1.Text = tamount.ToString().Trim();
            lblTotalqtyId.Text = lbl1.ClientID.ToString();
            lblTotalamtId.Text = lblamt1.ClientID.ToString();
        }
    }
   
    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            setStateGridview();
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["tempDCData"];
            dt1.Rows[e.RowIndex].Delete();
            grdBookDetails.DataSource = dt1;
            grdBookDetails.DataBind();
            Session["tempDCData"] = dt1;
            loder("Successfully Deleted...", "3000");
        }
        catch
        {
        }
    }
    protected void grdcn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
            tnamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqty1 = (Label)e.Row.FindControl("lblqty");
            quantity = quantity + Convert.ToInt32(lblqty1.Text.Trim());
            Label lblamt1 = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt1.Text.Trim());
            Label lblnamt1 = (Label)e.Row.FindControl("lblnamt");
            tnamount = tnamount + Convert.ToDecimal(lblnamt1.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblqty2 = (Label)e.Row.FindControl("lbltqty");
            lblqty2.Text = quantity.ToString().Trim();
            Label lblamt2 = (Label)e.Row.FindControl("lbltamt");
            lblamt2.Text = tamount.ToString().Trim();
            Label lblnamt2 = (Label)e.Row.FindControl("lbltnamt");
            lblnamt2.Text = tnamount.ToString().Trim();
        }
    }

    #endregion

    #endregion

    #region Methods

    #region Fill grid data for books
    public DataTable fillTempBookData(string bookcode, string flag)
    {

        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();

        DataColumn colTax = new DataColumn();
        colTax.DataType = System.Type.GetType("System.String");
        colTax.ColumnName = "Rate";
        DataColumn Discount = new DataColumn();
        Discount.DataType = System.Type.GetType("System.String");
        Discount.ColumnName = "Discount";
        DataColumn AdditionalDiscount = new DataColumn();
        AdditionalDiscount.DataType = System.Type.GetType("System.String");
        AdditionalDiscount.ColumnName = "AdditionalDiscount";
        DataColumn Amount = new DataColumn();
        Amount.DataType = System.Type.GetType("System.String");
        Amount.ColumnName = "Amount";

        if (Session["tempDCData"] == null)
        {
            //CREATE NEW DATATABLE
            //ADD COLUMNS IN DATATABLE
            dt.Columns.Add("DCDetailID");
            dt.Columns.Add("BookCode");
            dt.Columns.Add("BookName");
            //dt.Columns.Add("BookType");
            dt.Columns.Add("Standard");
            dt.Columns.Add("Medium");
            // dt.Columns.Add("Quantity");
            dt.Columns.Add("ReturnQty");
           // dt.Columns.Add("DefectQty");
            dt.Columns.Add("RemainQty");
            
            dt.Columns.Add(colTax);
            dt.Columns.Add(Amount);
            dt.Columns.Add(Discount);
            dt.Columns.Add(AdditionalDiscount);
            dt.Columns.Add("Comment");
            //ADD DATA AS PER COLUMNS
            //Books _objBooks = new Books();
        }
        else
        {
            dt = (DataTable)Session["tempDCData"];
        }

        tempGetData = Books.Get_BooksMasterForDC(bookcode, srate).Tables[0];

        foreach (DataRow row in tempGetData.Rows)
        {
            price = row["SellingPrice"].ToString();
            if (price == "")
            {
                price = "0";
            }
            amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(price);

            if (dt.Rows.Count != 0)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "BookCode = '" + row["BookCode"].ToString() + "'";
                int i = 0;
                price = row["SellingPrice"].ToString();
                amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(price);
                foreach (DataRowView row1 in dv)
                {
                    i++;
                }

                if (i == 0)
                {
                    DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString(), row["BookCode"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                        Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                        Tdiscount = amt * (discount / 100);
                        amt = amt - Tdiscount;
                    }
                    dt.Rows.Add(dcid, row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), rqty, Qty,  
                        String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:0.00}", Convert.ToDecimal(amt)), 
                        String.Format("{0:0.00}", Convert.ToDecimal(discount)), String.Format("{0:0.00}", Convert.ToDecimal(Adddiscount)),"");
                }
            }
            else
            {
                DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString(), row["BookCode"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                    Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                    //  Totaldiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][2]);
                    Tdiscount = amt * (discount / 100);
                    amt = amt - Tdiscount;
                }

                dt.Rows.Add(dcid, row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), rqty, Qty, 
                    String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:0.00}", Convert.ToDecimal(amt)), 
                    String.Format("{0:0.00}", Convert.ToDecimal(discount)), String.Format("{0:0.00}", Convert.ToDecimal(Adddiscount)),"");
            }
        }
        return dt;
    }
    #endregion

    public void ClearFields()
    {
       // txtcustomer.Text = "";
      //  lblCustName.Text = "";
        BindDDLstd();
    }
    private void setStateGridview()
    {
        DataColumn colTax = new DataColumn();
        colTax.DataType = System.Type.GetType("System.String");
        colTax.ColumnName = "Rate";
        DataTable _d = new DataTable();
        _d.Columns.Add("DCDetailID");
        _d.Columns.Add("BookCode");
        _d.Columns.Add("BookName");
        //dt.Columns.Add("BookType");
        _d.Columns.Add("Standard");
        _d.Columns.Add("Medium");
        // _d.Columns.Add("Quantity");
        _d.Columns.Add("ReturnQty");
       // _d.Columns.Add("DefectQty");
        _d.Columns.Add("RemainQty");
        _d.Columns.Add(colTax);
        _d.Columns.Add("Amount");
        _d.Columns.Add("Discount");
        _d.Columns.Add("AdditionalDiscount");
        _d.Columns.Add("Comment");


        foreach (GridViewRow row in grdBookDetails.Rows)
        {
            decimal amt1, rate1, qty1;
            decimal discount1;
            decimal Tdiscount1;
            //  string amt1;
            if (((TextBox)row.FindControl("txtDiscount")).Text != "")
            {
                discount1 = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
            }
            else
            {
                discount1 = 0;
            }

            if (((Label)row.FindControl("lblAmt")).Text != "")
            {
                rate1 = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text);
                qty1 = Convert.ToDecimal(((TextBox)row.FindControl("txtquty")).Text);
                amt1 = rate1 * qty1;
                Tdiscount1 = amt1 * (discount1 / 100);
                amt1 = amt1 - Tdiscount1;
            }
            else
            {
                amt1 = 0;
            }

            _d.Rows.Add(Convert.ToInt32(((Label)row.FindControl("lblDCDetailID")).Text),
            ((Label)row.FindControl("lblBookCode")).Text,
            ((Label)row.FindControl("lblBookName")).Text,
            ((Label)row.FindControl("lblStandard")).Text,
            ((Label)row.FindControl("lblMedium")).Text,
             ((TextBox)row.FindControl("txtretquty")).Text,
             // ((TextBox)row.FindControl("txtdefquty")).Text,
            ((TextBox)row.FindControl("txtquty")).Text,
            ((TextBox)row.FindControl("txtrate")).Text,
             String.Format("{0:0.00}", amt1),
            ((TextBox)row.FindControl("txtDiscount")).Text,
            ((Label)row.FindControl("txtAddDiscount")).Text,
            ((TextBox)row.FindControl("txtcmmt")).Text
            );
        }
        Session["tempDCData"] = null;
        Session["tempDCData"] = _d;
    }
    public void Bindgrdcn()
    {
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        grdcn.DataSource = CreditNote.PrintCN(Convert.ToInt32(strFY), CNNo);
        grdcn.DataBind();
    }
    public void BindDDLstd()
    {
        string std = "Standard";
        DDLstandard.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(std, "DropDown");
        DDLstandard.DataBind();
        DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
    }

    #endregion

    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    public void loder(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    public void cloder()
    {
        string jv = "cloder();";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    protected void btngetRec_Click(object sender, EventArgs e)
    {
        PnlAddbk.Visible = true;
        PnlAddbk.Focus();
    }

    //protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (RdbtnSelect.SelectedValue == "DC")
    //    {
    //        Response.Redirect("DCReturnBook.aspx?");
    //    }
    //}
    protected void txtCNDate_TextChanged(object sender, EventArgs e)
    {

    }
}
