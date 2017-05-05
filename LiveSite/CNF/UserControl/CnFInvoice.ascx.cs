#region Namespace
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
using System.IO;
using Idv.Chetana.CnF;

#endregion
public partial class CNF_CnFInvoice : System.Web.UI.UserControl
{
    string flag1;
    decimal Tdiscount;
    decimal amt;
    decimal tamount = 0;
    decimal totalamount = 0;

    decimal discount;
    int quantity = 0;
    int cnftabindex = 9;
    int DocNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["CurrentTable"] = null;
            SetInitialRow();
            GetDdlCnF();
            //
            // txtdocDate.Text = DateTime.Now.ToString();
        }
    }


    //public void GetBookDetails()
    //{
    //    DataTable tempGetData = new DataTable();
    //    string bookcode, srate;
    //    bookcode = "";
    //    srate = "m";
    //    bookcode = ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbkcod")).Text.Split(':')[0].Trim();
    //    //txtbkcod.Text.Split(':')[0].Trim();
    //    AddNewRowToGrid(bookcode, srate);
    //}

    #region Methods

    public void GetDdlCnF()
    {
        CnFCustomer objcnf = new CnFCustomer();
        objcnf.Remark1 = "ddlCnF";
        objcnf.Remark2 = "";
        objcnf.Remark3 = "";
        objcnf.CnFID = 0;

        ddlCnF.DataSource = objcnf.GetCnF_Master().Tables[0];
        ddlCnF.DataBind();
        ddlCnF.Items.Insert(0, new ListItem("--Select CnF--", "0"));
    }
    #endregion
    #region Add Data to grid
    #region Methods


    private void AddNewRowToGrid(string bookcode, string srate)
    {
        int rowIndex = 0;
        DataTable tempGetData = new DataTable();
        tempGetData = Books.Get_BooksMasterForDC(bookcode, srate).Tables[0];

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox txtbkcod = (TextBox)grdBookDetails.Rows[rowIndex].Cells[1].FindControl("txtbkcod");
                    Label lblBookName = (Label)grdBookDetails.Rows[rowIndex].Cells[2].FindControl("lblBookName");
                    Label lblStandard = (Label)grdBookDetails.Rows[rowIndex].Cells[3].FindControl("lblStandard");
                    Label lblMedium = (Label)grdBookDetails.Rows[rowIndex].Cells[4].FindControl("lblMedium");
                    TextBox txtbookqty = (TextBox)grdBookDetails.Rows[rowIndex].Cells[5].FindControl("txtbookqty");
                    TextBox txtrate = (TextBox)grdBookDetails.Rows[rowIndex].Cells[6].FindControl("txtrate");
                    // TextBox txtDiscount = (TextBox)grdBookDetails.Rows[rowIndex].Cells[7].FindControl("txtDiscount");
                    Label lblAmt = (Label)grdBookDetails.Rows[rowIndex].Cells[7].FindControl("lblAmt");

                    if (i == dtCurrentTable.Rows.Count)
                    {
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["BookCode"] = tempGetData.Rows[0]["BookCode"];
                        drCurrentRow["BookName"] = tempGetData.Rows[0]["BookName"];
                        drCurrentRow["Standard"] = tempGetData.Rows[0]["Standard"];
                        drCurrentRow["Medium"] = tempGetData.Rows[0]["Medium"];
                        drCurrentRow["Quantity"] = txtbookqty.Text.ToString();
                        if (txtrate.Text != "0")
                        {
                            drCurrentRow["Rate"] = txtrate.Text.ToString();
                            drCurrentRow["Amount"] = (Convert.ToInt32(txtbookqty.Text) * Convert.ToDecimal(txtrate.Text.ToString()));

                        }
                        else
                        {
                            drCurrentRow["Rate"] = tempGetData.Rows[0]["SellingPrice"];
                            drCurrentRow["Amount"] = (Convert.ToInt32(txtbookqty.Text) * Convert.ToDecimal(tempGetData.Rows[0]["SellingPrice"]));

                        }
                        // drCurrentRow["Discount"] = txtDiscount.Text;

                    }
                    else
                    {
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["BookCode"] = txtbkcod.Text;
                        drCurrentRow["BookName"] = lblBookName.Text;
                        drCurrentRow["Standard"] = lblStandard.Text;
                        drCurrentRow["Medium"] = lblMedium.Text;
                        drCurrentRow["Quantity"] = txtbookqty.Text;
                        drCurrentRow["Rate"] = txtrate.Text;
                        //drCurrentRow["Discount"] = txtDiscount.Text;
                        drCurrentRow["Amount"] = lblAmt.Text;

                    }
                    rowIndex++;
                }
                //add new row to DataTable
                dtCurrentTable.Rows.Add(drCurrentRow);
                //Store the current data to ViewState
                ViewState["CurrentTable"] = dtCurrentTable;
                //Rebind the Grid with the current data
                grdBookDetails.DataSource = dtCurrentTable;
                grdBookDetails.DataBind();
                //grdpreview.DataSource = dtCurrentTable;
                //grdpreview.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousData();

        ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbkcod")).Focus();
    }
    public decimal ReturnAmt(int Qty, decimal rate, decimal discount)
    {

        //amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(price);
        //Tdiscount = amt * (discount / 100);
        //amt = amt - Tdiscount;
        return amt;
    }
    private void SetPreviousData()
    {
        // short cnftabindex = 7;
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    TextBox txtbkcod = (TextBox)grdBookDetails.Rows[rowIndex].Cells[1].FindControl("txtbkcod");
                    Label lblBookName = (Label)grdBookDetails.Rows[rowIndex].Cells[2].FindControl("lblBookName");
                    Label lblStandard = (Label)grdBookDetails.Rows[rowIndex].Cells[3].FindControl("lblStandard");
                    Label lblMedium = (Label)grdBookDetails.Rows[rowIndex].Cells[4].FindControl("lblMedium");
                    TextBox txtbookqty = (TextBox)grdBookDetails.Rows[rowIndex].Cells[5].FindControl("txtbookqty");
                    TextBox txtrate = (TextBox)grdBookDetails.Rows[rowIndex].Cells[6].FindControl("txtrate");
                    // TextBox txtDiscount = (TextBox)grdBookDetails.Rows[rowIndex].Cells[7].FindControl("txtDiscount");
                    Label lblAmt = (Label)grdBookDetails.Rows[rowIndex].Cells[7].FindControl("lblAmt");

                    if (i == dt.Rows.Count)
                    {

                        lblBookName.Text = "";
                        lblStandard.Text = "";
                        lblMedium.Text = "";
                        txtrate.Text = "0";
                        //  txtDiscount.Text = "";
                        lblAmt.Text = "0";
                        //  txtbookqty.TabIndex = cnftabindex;
                        //  cnftabindex = +1;

                    }
                    else
                    {
                        txtbkcod.Text = dt.Rows[i]["BookCode"].ToString();
                        //   txtbkcod.TabIndex = cnftabindex ;
                        //cnftabindex =+ 1;
                        lblBookName.Text = dt.Rows[i]["BookName"].ToString();
                        lblStandard.Text = dt.Rows[i]["Standard"].ToString();
                        lblMedium.Text = dt.Rows[i]["Medium"].ToString();
                        txtbookqty.Text = dt.Rows[i]["Quantity"].ToString();
                        // txtbookqty.TabIndex = cnftabindex ;
                        // cnftabindex = +1;

                        txtrate.Text = String.Format("{0:0.00}", Convert.ToDecimal(dt.Rows[i]["Rate"].ToString()));
                        // txtDiscount.Text = dt.Rows[i]["Discount"].ToString();
                        lblAmt.Text = String.Format("{0:0.00}", Convert.ToDecimal(dt.Rows[i]["Amount"].ToString()));
                        txtbkcod.Enabled = false;
                        txtbookqty.Enabled = false;
                    }

                    rowIndex++;
                    // txtbkcod.Focus();
                }


                //TextBox boxf = (TextBox)Gridview1.Rows[0].Cells[1].FindControl("TextBox1");
                //boxf.Focus();
            }
        }
    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("BookCode", typeof(string)));
        dt.Columns.Add(new DataColumn("BookName", typeof(string)));
        dt.Columns.Add(new DataColumn("Standard", typeof(string)));
        dt.Columns.Add(new DataColumn("Medium", typeof(string)));
        dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
        dt.Columns.Add(new DataColumn("Rate", typeof(string)));
        //  dt.Columns.Add(new DataColumn("Discount", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));

        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["BookCode"] = string.Empty;
        dr["BookName"] = string.Empty;
        dr["Standard"] = string.Empty;

        dr["Medium"] = string.Empty;
        dr["Quantity"] = string.Empty;
        dr["Rate"] = string.Empty;
        // dr["Discount"] = string.Empty;
        dr["Amount"] = string.Empty;

        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        grdBookDetails.DataSource = dt;
        grdBookDetails.DataBind();
    }
    public string ConvertDatatableToXML(DataTable dt)
    {
        MemoryStream str = new MemoryStream();
        dt.WriteXml(str, true);
        str.Seek(0, SeekOrigin.Begin);
        StreamReader sr = new StreamReader(str);
        string xmlstr;
        xmlstr = sr.ReadToEnd();
        return (xmlstr);
    }

    #endregion



    #region Events
    protected void txtbkcod_TextChanged(object sender, EventArgs e)
    {
        ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbookqty")).Focus();
    }

    protected void txtrate_TextChanged(object sender, EventArgs e)
    {
        DataTable dt1;
        TextBox txtrate = ((TextBox)((TextBox)sender).FindControl("txtrate"));
        TextBox txtbookcode = ((TextBox)((TextBox)sender).FindControl("txtbkcod"));
        Label lblamount = ((Label)((TextBox)sender).FindControl("lblAmt"));
        TextBox txtqunty = ((TextBox)((TextBox)sender).FindControl("txtbookqty"));

        string rate = txtrate.Text.ToString();
        string bkcod = txtbookcode.Text.Trim();
        string qunty = txtqunty.Text.Trim();
        string amount = (Convert.ToInt32(qunty) * Convert.ToDecimal(rate)).ToString();
        lblamount.Text = amount;
        if (ViewState["CurrentTable"] != null)
        {
            // dt1 = (DataTable)ViewState["CurrentTable"];
            DataView dv = new DataView((DataTable)ViewState["CurrentTable"]);
            dv.RowFilter = "BookCode = '" + bkcod.Trim() + "'";
            
            foreach (DataRowView row in dv)
            {
                row["Rate"] = rate;
                row["Amount"] = amount;
            }
        }

        ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbkcod")).Focus();
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        DataTable dt1;
        string bookcode, srate, bookname;
        bookcode = "";
        srate = "m";
        // setStateGridview();
        bookcode = ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbkcod")).Text.Split(':')[0].Trim();
        bookname = ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbkcod")).Text.Split(':')[2].Trim();
        //   txtbkcod.Text.Split(':')[2].Trim();
        //txtbkcod.Text.Split(':')[0].Trim();
        if (ViewState["CurrentTable"] != null)
        {
            dt1 = (DataTable)ViewState["CurrentTable"];
            DataView dv = new DataView(dt1);
            dv.RowFilter = "BookCode = '" + bookcode.Trim() + "'";
            int i = 0;
            foreach (DataRowView row in dv)
            {
                i++;
            }
            if (i == 0)
            {
                AddNewRowToGrid(bookcode, srate);

                loder(bookname + " added successfully", "3000");
            }
            else
            {
                loder(bookname + " already added!", "3000");
                ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbkcod")).Text = "";
                ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbkcod")).Focus();
                ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbookqty")).Text = "";

            }
        }
        else
        {
            AddNewRowToGrid(bookcode, srate);

            loder(bookname + " added successfully", "3000");
        }



    }
    #endregion
    #endregion

    protected void btn_Save_Click(object sender, EventArgs e)
    {
  btn_Save.Enabled = false;
        CnFInvoice _objInvoice = new CnFInvoice();
        _objInvoice.CnFId = Convert.ToInt32(ddlCnF.SelectedValue.ToString());
        string date1;
        string lrdate;

        if (txtdocDate.Text == "")
        {
            date1 = "1/1/2001";
        }
        else
        {
            date1 = txtdocDate.Text.Split('/')[1] + "/" + txtdocDate.Text.Split('/')[0] + "/" + txtdocDate.Text.Split('/')[2];
        }
        if (txtLRDate.Text == "")
        {
            lrdate = "1/1/2001";
        }
        else
        {
            lrdate = txtLRDate.Text.Split('/')[1] + "/" + txtLRDate.Text.Split('/')[0] + "/" + txtLRDate.Text.Split('/')[2];
        }

        _objInvoice.InvoiceDate = Convert.ToDateTime(date1);
        _objInvoice.LRDate = Convert.ToDateTime(lrdate);
        _objInvoice.LRNo = txtlrno.Text.Trim();
        _objInvoice.Remark1 = txtremark.Text.Trim();
        _objInvoice.Transporter = txttransporter.Text.Trim();
        _objInvoice.CreatedBy = Session["UserName"].ToString();
        string strdetails = "";
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            strdetails = ConvertDatatableToXML(dt);
        }
        _objInvoice.Details = strdetails;
        _objInvoice.flag = "I";
        _objInvoice.FinancialYearFrom = Convert.ToInt32(Session["FY"].ToString());
        _objInvoice.Save(out DocNo);
        ClearAll();
        MessageBox("Record saved successfully , Doument No. : " + DocNo.ToString());
	 btn_Save.Enabled = true;

    }

    #region MsgBox

    public void ClearAll()
    {
        ddlCnF.SelectedValue = "0";
        txtdocDate.Text = DateTime.Now.ToString();
        txtlrno.Text = "";
        txtLRDate.Text = DateTime.Now.ToString();
        txttransporter.Text = "";
        txtremark.Text = "";

        grdBookDetails.DataSource = null;
        grdBookDetails.DataBind();
        SetInitialRow();
        //grdpreview.DataSource = null;
        //grdpreview.DataBind();
    }
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    public void loder(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    #endregion

    #region Grid Event

    TextBox txtqty;

    TextBox txtdisc;
    TextBox txtbkcodtb;
    Label lblAmount;
    TextBox txtrate1;
    Label lbladddisc;

    protected void grdBookDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       


        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            txtbkcodtb = (TextBox)e.Row.FindControl("txtbkcod");

            txtqty = (TextBox)e.Row.FindControl("txtbookqty");
            if (txtqty.Text.Trim() == "")
            {
                txtqty.Text = "0";
            }

            quantity = quantity + Convert.ToInt32(txtqty.Text.Trim());

            txtrate1 = (TextBox)e.Row.FindControl("txtrate");
            lblAmount = (Label)e.Row.FindControl("lblAmt");
            if (lblAmount.Text == "")
            {
                lblAmount.Text = "0";
            }
            if (txtrate1.Text == "")
            {
                txtrate1.Text = "0";
            }
            tamount = tamount + Convert.ToDecimal(lblAmount.Text.Trim());
            // txtdisc = (TextBox)e.Row.FindControl("txtDiscount");
            //  lbladddisc = (Label)e.Row.FindControl("txtAddDiscount");
            txtbkcodtb.Attributes.Add("TabIndex", cnftabindex.ToString());
            cnftabindex = cnftabindex + 1;

            txtqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate1.ClientID + "','" + lblAmount.ClientID + "')");
            cnftabindex = cnftabindex + 1;
            txtqty.Attributes.Add("TabIndex", cnftabindex.ToString());

            txtrate1.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate1.ClientID + "','" + lblAmount.ClientID + "')");
            cnftabindex = cnftabindex + 1;
            txtrate1.Attributes.Add("TabIndex", cnftabindex.ToString());

            //ImageButton imgremovw1 = (ImageButton)e.Row.FindControl("btnRemove");
            //imgremovw1.Visible = true;

            //if (((Label)e.Row.FindControl("lblBookName")).Text == "")
            //{
            //    //last row
            //    ImageButton imgremovw = (ImageButton)e.Row.FindControl("btnRemove");
            //    imgremovw.Visible = false;
            //}


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalamt");
            lblamt1.Text = String.Format("{0:0.00}", Convert.ToDecimal(tamount.ToString().Trim()));
            totalamount = Convert.ToDecimal(tamount.ToString().Trim());
            lblTotalqtyId.Text = lbl1.ClientID.ToString();
            lblTotalamtId.Text = lblamt1.ClientID.ToString();

        }

    }

    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {
            //if (DCDid != 0)
            //{
            //    _objdcd.DCDetailID = DCDid;
            //    _objdcd.IsActive = false;
            //    _objdcd.Amount = 0;
            //    _objdcd.Rate = 0;
            //    _objdcd.Discount = 0;

            //    _objdcd.Save();
            //}
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)ViewState["CurrentTable"];
            //drCurrentRow["RowNumber"]
            dt1.Rows[e.RowIndex + 1].Delete();
            grdBookDetails.DataSource = dt1;
            grdBookDetails.DataBind();
            ViewState["CurrentTable"] = dt1;
            SetPreviousData();
            // loder("Successfully Deleted...", "3000");


        }
        catch
        {


        }

    }
    //protected void grdpreview_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    Label lblQty;
    //    Label lblrate;
    //    if (e.Row.RowType == DataControlRowType.Header)
    //    {
    //        quantity = 0;
    //        tamount = 0;
    //    }

    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {

    //        lblQty = (Label)e.Row.FindControl("lblQty");
    //        if (lblQty.Text.Trim() == "")
    //        {
    //            lblQty.Text = "0";
    //        }

    //        quantity = quantity + Convert.ToInt32(lblQty.Text.Trim());

    //        lblrate = (Label)e.Row.FindControl("lblrate");
    //        lblAmt = (Label)e.Row.FindControl("lblAmt");
    //        if (lblAmt.Text == "")
    //        {
    //            lblAmt.Text = "0";
    //        }
    //        if (lblrate.Text == "")
    //        {
    //            lblrate.Text = "0";
    //        }
    //        tamount = tamount + Convert.ToDecimal(lblAmt.Text.Trim());



    //    }
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
    //        lbl1.Text = quantity.ToString().Trim();
    //        Label lblamt1 = (Label)e.Row.FindControl("lblTotalamt");
    //        lblamt1.Text = String.Format("{0:0.00}", Convert.ToDecimal(tamount.ToString().Trim()));
    //        lblTotalqtyId.Text = lbl1.ClientID.ToString();
    //        lblTotalamtId.Text = lblamt1.ClientID.ToString();

    //    }

    //} 
    #endregion

}
