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

public partial class CNF_CnFInvoice : System.Web.UI.UserControl
{
    string flag1;
    decimal Tdiscount;
    decimal amt;
    decimal tamount = 0;
    decimal discount;
    int quantity = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetInitialRow();
        }
    }

    protected void txtbkcod_TextChanged(object sender, EventArgs e)
    {
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
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        string bookcode, srate;
        bookcode = "";
        srate = "m";
        bookcode = ((TextBox)grdBookDetails.Rows[grdBookDetails.Rows.Count - 1].Cells[1].FindControl("txtbkcod")).Text.Split(':')[0].Trim();
        //txtbkcod.Text.Split(':')[0].Trim();
        AddNewRowToGrid(bookcode, srate);

    }

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
                            drCurrentRow["Amount"] = (Convert.ToInt32(txtbookqty.Text) * Convert.ToDecimal(txtrate.Text.ToString()));

                        }
                        else
                        {
                            drCurrentRow["Rate"] = tempGetData.Rows[0]["SellingPrice"];
                            drCurrentRow["Amount"] = (Convert.ToInt32(txtbookqty.Text) * Convert.ToDecimal(tempGetData.Rows[0]["SellingPrice"]));

                        }
                        
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
    public decimal ReturnAmt(int Qty , decimal rate , decimal discount)
    {

        //amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(price);
        //Tdiscount = amt * (discount / 100);
        //amt = amt - Tdiscount;
        return amt;
    }
    private void SetPreviousData()
    {

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
                       
                        lblBookName.Text ="";
                        lblStandard.Text = "";
                        lblMedium.Text = "";
                        txtrate.Text = "0";
                      //  txtDiscount.Text = "";
                        lblAmt.Text = "0";

                    }
                    else
                    {
                        txtbkcod.Text = dt.Rows[i]["BookCode"].ToString();
                        lblBookName.Text = dt.Rows[i]["BookName"].ToString();
                        lblStandard.Text = dt.Rows[i]["Standard"].ToString();
                        lblMedium.Text = dt.Rows[i]["Medium"].ToString();
                        txtbookqty.Text = dt.Rows[i]["Quantity"].ToString();
                        txtrate.Text = dt.Rows[i]["Rate"].ToString();
                       // txtDiscount.Text = dt.Rows[i]["Discount"].ToString();
                        lblAmt.Text = dt.Rows[i]["Amount"].ToString(); 
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

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        CnFInvoice _objInvoice = new CnFInvoice();
        _objInvoice.CnFId = 0;//Convert.ToInt32(ddlCnF.SelectedValue.ToString());
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

        _objInvoice.InvoiceDate = Convert.ToDateTime(date1);
        _objInvoice.LRDate = Convert.ToDateTime(lrdate);
        _objInvoice.LRNo = txtlrno.Text.Trim();
        _objInvoice.Remark1 = "";
        _objInvoice.Transporter = lbltransporter.Text.Trim();
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
        int l = 0;
        _objInvoice.Save(out l);
 MessageBox("Record saved successfully");
    } 
 #region MsgBox

    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion
  
    // By using this method we can convert datatable to xml
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
    protected void txttransporter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txttransporter.Text != "")
            {
                string TransCode = txttransporter.Text.ToString().Split(':', '[', ']')[0].Trim();
                flag1 = txttransporter.Text.ToString().Split('[', ']')[1].Trim();
                txttransporter.Text = TransCode;
                if (flag1 == "Emp")
                {
                    lbltransporter.Visible = true;
                    DataTable dt = new DataTable();
                    dt = DCMaster.Get_Name(TransCode, flag1).Tables[0];

                    if (dt.Rows.Count != 0)
                    {
                        if (flag1 == "Emp")
                        {
                            lbltransporter.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
                        }
                    }
                    else
                    {
                        lbltransporter.Text = "No such record found";
                        txttransporter.Focus();
                        txttransporter.Text = "";
                    }
                }
                else
                {
                    lbltransporter.Visible = false;
                    lbltransporter.Text = flag1;
                }
            }
            else
            {
                lbltransporter.Text = "No such record found";
                txttransporter.Text = "";
            }
        }
        catch
        {
            txttransporter.Text = "";
            lbltransporter.Text = "No such record found";
        }

    }

    TextBox txtqty;
    TextBox txtrate;
    Label lblAmt;
    TextBox txtdisc;
    Label lbladddisc;
    int tabindex = 20;

    protected void grdBookDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            txtqty = (TextBox)e.Row.FindControl("txtbookqty");
            if (txtqty.Text.Trim() == "")
            {
                txtqty.Text = "0";
            }
          
            quantity = quantity +  Convert.ToInt32(txtqty.Text.Trim());
            
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
            txtqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + lblAmt.ClientID + "')");
            tabindex = tabindex + 1;
            txtqty.Attributes.Add("TabIndex", tabindex.ToString());

            // txtDeldate.Attributes.Add("onkeyup", "multiplyQty(this," + txtrate.ClientID + "," + lblAmt.ClientID + "," + txtdisc.ClientID + ")");
            tabindex = tabindex + 1;


            txtrate.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + lblAmt.ClientID + "')");
            tabindex = tabindex + 1;
            txtrate.Attributes.Add("TabIndex", tabindex.ToString());

           



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
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalamt");
            lblamt1.Text = tamount.ToString().Trim();
            lblTotalqtyId.Text = lbl1.ClientID.ToString();
            lblTotalamtId.Text = lblamt1.ClientID.ToString();

        }

    }
}
