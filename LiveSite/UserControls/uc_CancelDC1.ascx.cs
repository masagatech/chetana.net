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
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["tempBookData"] = null;
            btncancel.Visible = false;
        }
    }

    protected void BtnGetSpecimanDetails_Click(object sender, EventArgs e)
    {
        lblIsPartialC.Text = "false";
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

            dt = Specimen.Get_SpecimenMasterBy_DocNum(DocNum, "1").Tables[0];

            if (dt.Rows.Count > 0)
            {
                condition1 = Convert.ToBoolean(dt.Rows[0]["IsConfirm"]);
                condition1 = false;
                lblIsPartialC.Text = dt.Rows[0]["IsPartialConfirmed"].ToString();
            }
            if (condition1 == true)
            {
                // grdBookDetails.Visible = true;
                btncancel.Visible = false;
                message("Record not found for document no. " + TxtDocNo.Text);
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
            tempGetData = SpecimanDetails.GetSpecimenDatilsByEmpCode(bookcode, "documentno_n").Tables[0];
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
                _objspecimen.IsApproved = Convert.ToBoolean(lblIsPartialC.Text);
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

    
}
