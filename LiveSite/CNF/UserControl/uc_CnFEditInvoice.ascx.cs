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

public partial class CNF_UserControl_uc_CnFEditInvoice : System.Web.UI.UserControl
{
    #region Variables
    string strFY = "0";
    DataSet stDS;
    int quantity = 0;
    decimal tamount = 0;
    decimal totalamount = 0;
    string strChetanaCompanyName = "cppl";
    int invoiceId;
    int cnftabindex = 9;
    int docnewno = 0;
    string RdBValue;
    DateTime fdate;
    DateTime tdate;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != "" || Session["FY"] != null)
        {
            strFY = Session["FY"].ToString();
        }
        if (!Page.IsPostBack)
        {
            BindInvoice();
            pnlDetails.Visible = false;
            GetDdlCnF();
        }
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        pnlDetails.Visible = true;
        stDS = new DataSet();
        //   docno.InnerHtml = txtDocno.Text.Trim();
        stDS = CnFInvoice.GetInvoiceDetails(Convert.ToInt32(txtDocno.Text), "print", Convert.ToInt32(strFY));
        ddlCnF.SelectedValue = stDS.Tables[1].Rows[0]["CustId"].ToString();
        txtLRDate.Text = stDS.Tables[1].Rows[0]["LRDate"].ToString();
        txtdocDate.Text = stDS.Tables[1].Rows[0]["Invoicedate"].ToString();
        txttransporter.Text = stDS.Tables[1].Rows[0]["Transporter"].ToString();
        lblDocumentno.Text = stDS.Tables[1].Rows[0]["DocumentNo"].ToString();
        grdapproval.DataSource = stDS.Tables[0];
        grdapproval.DataBind();
        //  SetInitialRow();

    }
    public void BindInvoice()
    {
        Rptrpending.DataSource = CnFInvoice.GetInvoiceNos(Convert.ToInt32(strFY));
        Rptrpending.DataBind();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
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
            date1 = txtdocDate.Text.Split('/')[2] + "/" + txtdocDate.Text.Split('/')[1] + "/" + txtdocDate.Text.Split('/')[0];
        }
        if (txtLRDate.Text == "")
        {
            lrdate = "1/1/2001";
        }
        else
        {
            lrdate = txtLRDate.Text.Split('/')[2] + "/" + txtLRDate.Text.Split('/')[1] + "/" + txtLRDate.Text.Split('/')[0];
        }
        _objInvoice.DocumentNo = Convert.ToInt32(txtDocno.Text.ToString());
        _objInvoice.InvoiceDate = Convert.ToDateTime(date1);
        _objInvoice.LRDate = Convert.ToDateTime(lrdate);
        _objInvoice.LRNo = txtlrno.Text.Trim();
        _objInvoice.Remark1 = txtremark.Text.Trim();
        _objInvoice.Transporter = txttransporter.Text.Trim();
        _objInvoice.CreatedBy = Session["UserName"].ToString();
        string strdetails = "";

        //if (ViewState["CurrentTable"] != null)
        //{
        //    DataTable dt = (DataTable)ViewState["CurrentTable"];
        //    strdetails = ConvertDatatableToXML(dt);
        //}
        DataTable dt = setStateGridview();
        dt.TableName = "mytable";
        strdetails = ConvertDatatableToXML(dt).ToString();
        _objInvoice.Details = strdetails.ToString();

        // _objInvoice.NewDetails = ConvertDatatableToXML(GetDataTable(grdBookDetails)).ToString(); ;
        _objInvoice.flag = "I";
        _objInvoice.FinancialYearFrom = Convert.ToInt32(Session["FY"].ToString());
        _objInvoice.UpdateCnFInvoice();
        ClearAll();
        MessageBox("Record updated successfully , Doument No. : " + txtDocno.Text.ToString());

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
       // SetInitialRow();
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('CNF/print/CPrintInvoice.aspx?d=" + ((Button)(sender)).CommandArgument.Trim() + "&fy=" + strFY + "&type=with" + "')", true);

    }
    #region Grid Event

    protected void grdapproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox txtrate;
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox lblqty = (TextBox)e.Row.FindControl("lblqunty");
            quantity = quantity + Convert.ToInt32(lblqty.Text.Trim());
            Label lblamt = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt.Text.Trim());

            txtrate = (TextBox)e.Row.FindControl("lblrate");

            lblqty.Attributes.Add("onkeyup", "multiplyQty('" + lblqty.ClientID + "','" + txtrate.ClientID + "','" + lblamt.ClientID + "')");
            // cnftabindex = cnftabindex + 1;
            // lbl.Attributes.Add("TabIndex", cnftabindex.ToString());

            txtrate.Attributes.Add("onkeyup", "multiplyQty('" + lblqty.ClientID + "','" + txtrate.ClientID + "','" + lblamt.ClientID + "')");
            // cnftabindex = cnftabindex + 1;
            // txtrate.Attributes.Add("TabIndex", cnftabindex.ToString());


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalAmt");
            lblamt1.Text = tamount.ToString().Trim();
            totalamount = Convert.ToDecimal(tamount.ToString().Trim());

            lblTotalqtyId.Text = lbl1.ClientID.ToString();
            lblTotalamtId.Text = lblamt1.ClientID.ToString();

        }
    }

    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label SubConfirmID = (Label)e.Item.FindControl("SubConfirmID");
        GridView grdView = (GridView)e.Item.FindControl("grdapproval");
        DataView dv = new DataView(stDS.Tables[0]);

        dv.RowFilter = "DocumentNo = " + SubConfirmID.Text.Trim();
        grdView.DataSource = dv;
        grdView.DataBind();
        //lblempname1.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["FirstName"]) + " " + Convert.ToString(stDS.Tables[2].Rows[0]["LastName"]) + "   ";
        //lblcustname.InnerHtml = "  " + Convert.ToString(stDS.Tables[2].Rows[0]["CustDetails"]);
        //lblspinstruction.InnerHtml = Convert.ToString(stDS.Tables[2].Rows[0]["SpInstruction"]);
        //docnewno = Convert.ToInt32(stDS.Tables[2].Rows[0]["DocumentNo"]);
        //DataView dv1 = new DataView(stDS.Tables[1]);
        //dv1.RowFilter = "SubConfirmID = " + SubConfirmID.Text.Trim();
        //if (dv1.Count > 0)
        //{
        //    ((Label)e.Item.FindControl("lblfright")).Text = dv1[0].Row["Freight"].ToString();
        //    ((Label)e.Item.FindControl("lbltax")).Text = dv1[0].Row["Tax"].ToString();
        //    decimal frt = Convert.ToDecimal(dv1[0].Row["Freight"].ToString());
        //    decimal tx = Convert.ToDecimal(dv1[0].Row["Tax"].ToString());
        //    decimal tamt = frt + tx + totalamount;
        //    ((Label)e.Item.FindControl("lbltotalamt")).Text = tamt.ToString();
        //}
        //else
        //{
        //    ((Label)e.Item.FindControl("lblfright")).Text = "0";
        //    ((Label)e.Item.FindControl("lbltax")).Text = "0";
        //    ((Label)e.Item.FindControl("lbltotalamt")).Text = totalamount.ToString();
        //}

    }
    protected void RepDetailsApprove_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void grdapproval_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CnFInvoice _objinvoice = new CnFInvoice();
        invoiceId = Convert.ToInt32(((Label)grdapproval.Rows[e.RowIndex].FindControl("lblivoiceId")).Text);

        _objinvoice.IsDeleted = true;
        _objinvoice.IsActive = false;
        _objinvoice.CnFId = invoiceId;
        _objinvoice.DeleteCnFInvoice();

        stDS = CnFInvoice.GetInvoiceDetails(Convert.ToInt32(txtDocno.Text), "print", Convert.ToInt32(strFY));
        grdapproval.DataSource = stDS.Tables[0];
        grdapproval.DataBind();

    }
    #endregion

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
                        if (txtrate.Text != "")
                        {
                            drCurrentRow["Rate"] = txtrate.Text.ToString();
                        }
                        else
                        {
                            drCurrentRow["Rate"] = tempGetData.Rows[0]["SellingPrice"];
                        }
                        // drCurrentRow["Discount"] = txtDiscount.Text;
                        drCurrentRow["Amount"] = (Convert.ToInt32(txtbookqty.Text) * Convert.ToDecimal(tempGetData.Rows[0]["SellingPrice"]));

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
        ViewState["CurrentTable"] = "";
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
            int i = 0;
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

    #region Grid Event

    TextBox txtqty;

    TextBox txtdisc;
    TextBox txtbkcodtb;

    Label lbladddisc;

    protected void grdBookDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblAmt;
        TextBox txtrate;


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

            txtrate = (TextBox)e.Row.FindControl("txtrate");
            lblAmt = (Label)e.Row.FindControl("lblAmt");
            if (lblAmt.Text == "")
            {
                lblAmt.Text = "0";
            }
            if (txtrate.Text == "")
            {
                txtrate.Text = "0";
            }
            tamount = tamount + Convert.ToDecimal(lblAmt.Text.Trim());
            // txtdisc = (TextBox)e.Row.FindControl("txtDiscount");
            //  lbladddisc = (Label)e.Row.FindControl("txtAddDiscount");
            txtbkcodtb.Attributes.Add("TabIndex", cnftabindex.ToString());
            cnftabindex = cnftabindex + 1;

            //txtqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "')");
            //cnftabindex = cnftabindex + 1;
            //txtqty.Attributes.Add("TabIndex", cnftabindex.ToString());

            //txtrate.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "')");
            //cnftabindex = cnftabindex + 1;
            //txtrate.Attributes.Add("TabIndex", cnftabindex.ToString());

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
            lblTotalqtyId.Text = lbl1.ClientID.ToString();
            lblTotalamtId.Text = lblamt1.ClientID.ToString();

        }

    }

    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {

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

    #endregion


    #region Datatable from Grid View
    DataTable GetDataTable(GridView dtg)
    {
        DataTable dt = new DataTable();

        // add the columns to the datatable            
        if (dtg.HeaderRow != null)
        {
            for (int i = 0; i < dtg.HeaderRow.Cells.Count; i++)
            {
                PrepareControlForExport(dtg.HeaderRow.Cells[i]);
                //dt.Rows.Add(dtg.HeaderRow);
                dt.Columns.Add(dtg.HeaderRow.Cells[i].Text);
            }

        }
        foreach (GridViewRow row in dtg.Rows)
        {
            // PrepareControlForExport(row);
            //  dt.Rows.Add(row);
            DataRow dr;
            dr = dt.NewRow();

            for (int i = 0; i < row.Cells.Count; i++)
            {
                PrepareControlForExport(row.Cells[i]);
                // dr[i] = row.Cells[i].Text;
                dt.Columns.Add(row.Cells[i].Text);

            }
            // dt.Rows.Add(dr);
        }

        //if (dtg.FooterRow != null)
        //{
        //    PrepareControlForExport(dtg.FooterRow);
        //    dt.Rows.Add(dtg.FooterRow);
        //}
        //if (dtg.HeaderRow != null)
        //{

        //    for (int i = 0; i < dtg.HeaderRow.Cells.Count; i++)
        //    {
        //        dt.Columns.Add(dtg.HeaderRow.Cells[i].Text);
        //    }
        //}

        ////  add each of the data rows to the table
        //foreach (GridViewRow row in dtg.Rows)
        //{
        //    DataRow dr;
        //    dr = dt.NewRow();

        //    for (int i = 0; i < row.Cells.Count; i++)
        //    {
        //        dr[i] = row.Cells[i].Text;
        //    }
        //    dt.Rows.Add(dr);
        //}
        return dt;
    }

    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is Label)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
            }
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }


    private DataTable setStateGridview()
    {
        DataColumn colTax = new DataColumn();
        colTax.DataType = System.Type.GetType("System.String");
        colTax.ColumnName = "Rate";
        DataTable _d = new DataTable();
        _d.Columns.Add("invoiceId");
        _d.Columns.Add("BookCode");
        _d.Columns.Add("BookName");
        _d.Columns.Add("Standard");
        _d.Columns.Add("Medium");
        _d.Columns.Add(colTax);
        _d.Columns.Add("Quantity");
        _d.Columns.Add("Amount");


        foreach (GridViewRow row in grdapproval.Rows)
        {
            decimal amt1, rate1, qty1;
            decimal discount1;
            decimal Tdiscount1;
            //  string amt1;


            if (((Label)row.FindControl("lblamt")).Text != "")
            {
                rate1 = Convert.ToDecimal(((TextBox)row.FindControl("lblrate")).Text);
                qty1 = Convert.ToDecimal(((TextBox)row.FindControl("lblqunty")).Text);
                amt1 = rate1 * qty1;
              
            }
            else
            {
                amt1 = 0;
            }

            _d.Rows.Add(Convert.ToInt32(((Label)row.FindControl("lblivoiceId")).Text),
            ((Label)row.FindControl("lblbookC")).Text,
            ((Label)row.FindControl("lblbookN")).Text,
            ((Label)row.FindControl("lblStandard")).Text,
            ((Label)row.FindControl("lblMedium")).Text,
             ((TextBox)row.FindControl("lblrate")).Text,
            ((TextBox)row.FindControl("lblqunty")).Text,
             String.Format("{0:0.00}", amt1)
            
            );



        }
       
       return _d;
    }
    #endregion
    //Table table = new Table();

    //            if (gv.HeaderRow != null)
    //            {
    //                PrepareControlForExport(gv.HeaderRow);
    //                table.Rows.Add(gv.HeaderRow);
    //            }
    //            foreach (GridViewRow row in gv.Rows)
    //            {
    //                PrepareControlForExport(row);
    //                table.Rows.Add(row);
    //            }

    //            if (gv.FooterRow != null)
    //            {
    //                PrepareControlForExport(gv.FooterRow);
    //                table.Rows.Add(gv.FooterRow);
    //            }
}
