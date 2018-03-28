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
using System.Web.Services;
using Idv.Chetana.BAL;

public partial class UserControls_uc_CancelDC : System.Web.UI.UserControl
{
    #region Variables
    //int DocNo;
    string Qty = "1";
    string rqty = "0";
    //string bookname = "";

    string strFY = "0";

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != "" || Session["FY"] != null)
        {
           strFY = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
        }

        if (!Page.IsPostBack)
        {
            Session["tempBookData"] = null;
            btncancel.Visible = false;
            DDLCustomer.Focus();
            SetView();

        }

    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                Pnlcust.Visible = false;
               
                PnlInsertDocNum.Visible = true;
                lblcanceleddate_lbl.Visible = false;
                lblcanceleddate.Visible = false;
                Rptrpending.Visible = false;
                upOrderNO.Visible = false;
                //DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Customer", Convert.ToInt32(strFY));
                //DDLCustomer.DataBind();
                //DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
                //DDLCustomer.Focus();
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    Pnlcust.Visible = true;
                    PnlInsertDocNum.Visible = false;

                    DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("SpecimenCanceled", Convert.ToInt32(strFY));
                    DDLCustomer.DataBind();
                    DDLCustomer.Items.Insert(0, new ListItem("-Select -", "0"));
                    DDLCustomer.Focus();
                    lblcanceleddate_lbl.Visible = true;
                    lblcanceleddate.Visible = true;
                    // Rptrpending.DataSource = DCMaster.Get_Customer_PendingDocNo("Pending");
                    // Rptrpending.DataBind();
                  
                    Rptrpending.Visible = true;
                    upOrderNO.Visible = true;
                }
        }
    }


    protected void BtnGetSpecimanDetails_Click(object sender, EventArgs e)
    {
        Session["tempBookData"] = null;
        if (TxtDocNo.Text == "")
        {
            message("Please enter Document no.");
            ClearData();
        }
        else
        {
            int DocNum = Convert.ToInt32(TxtDocNo.Text.ToString());
            DataTable dt = new DataTable();
            bool condition1 = false;

            dt = Specimen.Get_SpecimenMasterBy_DocNum(DocNum, "0").Tables[0];

            if (dt.Rows.Count > 0)
            {
                condition1 = false;//Convert.ToBoolean(dt.Rows[0]["IsConfirm"]);
            }
            if (condition1 == true)
            {
                // grdBookDetails.Visible = true;
                btncancel.Visible = false;
                message("Document no. " + TxtDocNo.Text + " cannot be cancelled.");
                TxtDocNo.Text = "";
                TxtDocNo.Focus();
                ClearData();
            }
            else if (dt.Rows.Count == 0)
            {
                message("Record not found for document no. " + TxtDocNo.Text);
                btncancel.Visible = false;
                TxtDocNo.Text = "";
                TxtDocNo.Focus();
                ClearData();
            }
            else
            {
                btncancel.Visible = true;

                if (dt.Rows.Count > 0)
                {
                    lbldocno.Text = dt.Rows[0]["DocumentNo"].ToString();
                    lblchalanno.Text = dt.Rows[0]["ChallanNo"].ToString();
                    lblchaldate.Text = dt.Rows[0]["ChallanDate"].ToString();
                    lblorderno.Text = dt.Rows[0]["OrderNo"].ToString();
                    //txtsalemanCode.Text = dt.Rows[0]["SalesmanCode"].ToString();
                    lblsalesman.Text = dt.Rows[0]["SalesmanName"].ToString();
                    lblorderdate.Text = dt.Rows[0]["OrderDate"].ToString();
                    lbldocdate.Text = dt.Rows[0]["DocumentDate"].ToString();

                    DataTable dt1 = new DataTable();
                    Session["tempBookData"] = fillTempBookData(DocNum.ToString(), "get");
                    dt1 = (DataTable)Session["tempBookData"];
                    grdBookDetails.DataSource = dt1;
                    grdBookDetails.DataBind();
                    grdBookDetails.Visible = true;
                    //btn_Save.Visible = false;
                    //btncancel.Visible = false;
                }
            }
        }  
   }

    public DataTable fillTempBookData(string bookcode, string flag)
    {

        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();

        DataColumn colTax = new DataColumn();
        colTax.DataType = System.Type.GetType("System.String");
        colTax.ColumnName = "Amount";


        if (Session["tempBookData"] == null)
        {
            //CREATE NEW DATATABLE
            //ADD COLUMNS IN DATATABLE
            dt.Columns.Add("SpecimenDetailId");
            dt.Columns.Add("BookCode");
            dt.Columns.Add("BookName");
            //dt.Columns.Add("BookType");
            dt.Columns.Add("Standard");
            dt.Columns.Add("Medium");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("RemainQty");
            dt.Columns.Add("Rate");
            dt.Columns.Add(colTax);
            dt.Columns.Add("Discount");
            //ADD DATA AS PER COLUMNS
            //Books _objBooks = new Books();
        }
        else
        {
            dt = (DataTable)Session["tempBookData"];
        }
        
        if (flag == "get")
        {
            tempGetData = SpecimanDetails.GetSpecimenDatilsByEmpCode(bookcode, "documentno").Tables[0];
        }
        
        foreach (DataRow row in tempGetData.Rows)
        {
            if (dt.Rows.Count != 0)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "BookCode = '" + row["BookCode"].ToString() + "'";
                int i = 0;
                foreach (DataRowView row1 in dv)
                {
                    i++;
                }

                if (i == 0)
                {
                    if (flag == "get")
                    {
                        Qty = row["Quantity"].ToString();
                        rqty = row["RemainQty"].ToString();
                    }
                    dt.Rows.Add(0, row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), Qty, rqty, "0.00", String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), "0.00");

                }
            }
            else
            {
                if (flag == "get")
                {
                    Qty = row["Quantity"].ToString();
                    rqty = row["RemainQty"].ToString();
                }
                dt.Rows.Add(0, row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), Qty, rqty, "0.00", String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), "0.00");
            }
        }
        return dt;
    }

    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
  
    #endregion

    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            Specimen _objspecimen = new Specimen();
          

            if (lbldocno.Text != "")
            {
                _objspecimen.DocNo = Convert.ToInt32(lbldocno.Text.ToString());
                _objspecimen.IsCanceled = true;
                _objspecimen.update();
            }
            
            ClearData();

        }

        catch
        {
        }

    }
    public void ClearData()
    {
            lbldocno.Text = "";
            lbldocdate.Text = "";
            lblchalanno.Text = "";
            lblchaldate.Text = "";
            lblorderno.Text = "";
            lblorderdate.Text = "";
            lblsalesman.Text = "";
            grdBookDetails.Visible = false;
            Session["tempBookData"] = null;
    }

    protected void btnget_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = SpecimanDetails.Idv_Get_SpecimenDetails_By_DocNo(Convert.ToInt32(txtdoc.Text), "CanceledSpecimen");

        if (ds.Tables[0].Rows.Count > 0)
        {
            lbldocno.Text = ds.Tables[0].Rows[0]["DocumentNo"].ToString();
            lblorderno.Text = ds.Tables[0].Rows[0]["OrderNo"].ToString();
            //txtsalemanCode.Text = dt.Rows[0]["SalesmanCode"].ToString();
            lblsalesman.Text = ds.Tables[0].Rows[0]["SalesmanName"].ToString();
            lblorderdate.Text = ds.Tables[0].Rows[0]["OrderDate"].ToString();
            lbldocdate.Text = ds.Tables[0].Rows[0]["DocumentDate"].ToString();
            lblcanceleddate.Text = ds.Tables[0].Rows[0]["CancelDate"].ToString();
        }
        grdBookDetails.DataSource = ds.Tables[1];
        grdBookDetails.DataBind();
    }

    protected void DDLCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        Rptrpending.DataSource = Specimen.Get_PendingDocNo("Canceled", System.DateTime.Now, System.DateTime.Now, Convert.ToInt32(strFY), DDLCustomer.SelectedValue.ToString());
        Rptrpending.DataBind();
        upOrderNO.Update();
    }
}
