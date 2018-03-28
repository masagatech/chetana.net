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
using System.IO;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;

public partial class UserControls_uc_VirtualStock : System.Web.UI.UserControl
{
    #region Variables
    int IDNo;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    string Description;
    string BookCode;
    static decimal amount;
    string date;
    static decimal amount2;
    int VoucherNo;
    int DocNo;
    string VQty = "0";
    #endregion

    #region Page Load
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
        }
        SetView();
        if (!IsPostBack)
        {
            //SetView();
            // BindExpensehead();
           
            //lbl2ID.Text = "0";
            Session["tempdata"] = null;
         //   pnlVirtual.Visible = true;
         //   btn_Save.Visible = true;
         //   gvDetails.Visible = true;
            lblDescriptionofGoods.Visible = true;
            SetView();
        }
        
    }
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

    public void cloder()
    {
        string jv = "cloder();";
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
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                txtInvoiceNo.Enabled = true;
                btn_Save.Visible = true;
                pnlVirtual.Visible = true;
                btnAdd.Visible = true;
                gvDetails.Visible = true;
                pnlArea.Visible = false;
                grdvirualDetails.Visible = false;
                lblID.Text = "0";
                lblID1.Text = "0";
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    btn_Save.Visible = false;
                    pnlVirtual.Visible = false;
                    btnAdd.Visible = false;
                    gvDetails.Visible = false;
                    pnlArea.Visible = true;
                    grdvirualDetails.Visible = false;
                    if (IsPostBack)
                    {
                        BindReport("Report");
                    }
        
                }
                else
                    if (Request.QueryString["a"] == "e")
                    {
                        btn_Save.Visible = false;
                        pnlVirtual.Visible = false;
                        PnlBook.Visible = false;
                        btnAdd.Visible = false;
                        gvDetails.Visible = false;
                        pnlArea.Visible = true;
                        grdvirualDetails.Visible = true;
                    }
        }
    }
    #endregion
    
    protected void btn_Save_Click(object sender, EventArgs e)
    {
       
            if (Session["UserName"] != null)
            {
                if (gvDetails.Rows.Count > 0 || grdvirualDetails.Rows.Count > 0)
                {
                    VirtualStockMaster vm = new VirtualStockMaster();
                    vm.AutoID = Convert.ToInt32(lblID.Text.Trim());
                    vm.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
                    string date = txtDate.Text.Split('/')[1] + "/" + txtDate.Text.Split('/')[0] + "/" + txtDate.Text.Split('/')[2];
                    vm.InvoiceDate = Convert.ToDateTime(date);
                    vm.CreatedBy = Session["UserName"].ToString();
                    vm.UpdatedBy = Session["UserName"].ToString();

                    vm.Remark = txtRemark.Text.ToString();
                    vm.IsActive = true;
                    vm.FinancialYearFrom = Convert.ToInt32(strFY);
                   
                    vm.Save(out DocNo);
                    SaveDetails(DocNo);
                    message("Record save successfully \\r\\n InvoiceNo:" + DocNo);
                    Session["tempdata"] = null;
                    gvDetails.DataBind();
                    txtDate.Text = "";
                    txtInvoiceNo.Text = "";
                    txtRemark.Text = "";
                    lblDescriptionofGoods.Text = "";
                    txtinvoice.Text = "";
                    grdvirualDetails.DataBind();
                    
                }
                else
                {
                    message("Enter Details");
                }
            }
        
    }
    public void SaveDetails(int DocNo)
    {
        try
        {
            if (Session["UserName"] != null)
            {
                VirtualStockDetails vd = new VirtualStockDetails();
                vd.VMasterID = DocNo;
                vd.CreatedBy = Session["UserName"].ToString();
                vd.UpdatedBy = Session["UserName"].ToString();
                if (Request.QueryString["a"] == "a")
                {
                    foreach (GridViewRow gv in gvDetails.Rows)
                    {
                        vd.IsActive = true;
                        vd.DetailID = Convert.ToInt32(((Label)gv.FindControl("lblDetailId")).Text);
                        vd.BookCode = ((Label)gv.FindControl("lblCode")).Text;
                        vd.BookName = ((Label)gv.FindControl("lblName")).Text;
                        vd.Quantity = Convert.ToInt32(((Label)gv.FindControl("lblQuantity")).Text);
                        vd.Standard = ((Label)gv.FindControl("lblstandard")).Text;
                        vd.FY = Convert.ToInt32(strFY);
                        vd.Save();

                    }
                }
                else if (Request.QueryString["a"] == "e")
                {
                    foreach (GridViewRow gv in grdvirualDetails.Rows)
                    {
                        vd.IsActive = true;
                        vd.DetailID = Convert.ToInt32(((Label)gv.FindControl("lblDetailId")).Text);
                        vd.BookCode = ((Label)gv.FindControl("lblCode")).Text;
                        vd.BookName = ((Label)gv.FindControl("lblName")).Text;
                        vd.Quantity = Convert.ToInt32(((TextBox)gv.FindControl("lblQuantity")).Text);
                        vd.Standard = ((Label)gv.FindControl("lblstandard")).Text;
                        vd.FY = Convert.ToInt32(strFY);
                        vd.Save();

                    }
                }
            }
        }
        catch
        { }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtCode.Text != "" &&  txtQuantity.Text != "")
            {
                Enter();
                txtCode.Focus();
            }
            else
            {

            }
        }
        catch { }
    }

    public void Enter()
    {

        btn_Save.Visible = true;
        Description = lblDescriptionofGoods.Text.Trim().ToString();
        BookCode = txtCode.Text.Trim().ToString();

        DataTable dt = new DataTable();
        if (Session["tempdata"] != null)
        {
            dt = (DataTable)Session["tempdata"];
            DataView dv = new DataView(dt);
            dv.RowFilter = "Code = '" + BookCode + "'";
            //  if (bookcode =
            int i = 0;
            foreach (DataRowView row in dv)
            {
                i++;
            }
            if (i == 0)
            {
                Session["tempdata"] = fillExpense();
                dt = (DataTable)Session["tempdata"];

                loder(BookCode + " add successfully");
                message("add successfully");
                txtCode.Focus();


            }
            else
            {

                message("already added!");
                txtCode.Text = "";
                txtQuantity.Text = "";
                lblDescriptionofGoods.Text = "";

            }
        }
        else
        {
            Session["tempdata"] = fillExpense();
            dt = (DataTable)Session["tempdata"];
            loder(BookCode + " add successfully");
            message("add successfully");
            txtCode.Focus();
        }

        gvDetails.DataSource = dt;
        gvDetails.DataBind();
        gvDetails.Visible = true;
        txtCode.Text = "";
        txtQuantity.Text = "";
       
        lblDescriptionofGoods.Text = "";

    }
    public DataTable fillExpense()
    {
        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();

        if (Session["tempdata"] == null)
        {

            dt.Columns.Add("DetailId");
            dt.Columns.Add("Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Standard");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("VQuantity");
            dt.Columns.Add("TQuantity");
            
        }
        else
        {
            dt = (DataTable)Session["tempdata"];
        }


        if (dt.Rows.Count == 0)
        {
            int Qty = Convert.ToInt32(txtQuantity.Text);
            DataTable dt1 = new DataTable();
           
            dt1 = DCMaster.Get_Name(txtCode.Text.ToString() , "VBook").Tables[0];
            if (dt1.Rows.Count != 0)
            {
                VQty = Convert.ToString(dt1.Rows[0]["VirtualStock"]);
              
            }
            dt.Rows.Add(0,txtCode.Text.Trim().ToString(), lblDescriptionofGoods.Text.Trim().ToString(), lblStandard.Text.ToString(), txtQuantity.Text.ToString(), VQty, Convert.ToInt32(txtQuantity.Text.ToString())+ Convert.ToInt32(VQty)) ;
        }
        else
        {
            int Qty = Convert.ToInt32(txtQuantity.Text);
            DataTable dt1 = new DataTable();

            dt1 = DCMaster.Get_Name(txtCode.Text.ToString(), "VBook").Tables[0];
            if (dt1.Rows.Count != 0)
            {
                VQty = Convert.ToString(dt1.Rows[0]["VirtualStock"]);

            }
            dt.Rows.Add(0,txtCode.Text.Trim().ToString(), lblDescriptionofGoods.Text.Trim().ToString(), lblStandard.Text.ToString(), txtQuantity.Text.ToString(), VQty, Convert.ToInt32(txtQuantity.Text.ToString()) + Convert.ToInt32(VQty));
        }

        return dt;
    }
    protected void txtCode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtCode.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode, "BookName").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtCode.Text = ECode;
            lblDescriptionofGoods.Text = dt.Rows[0]["BookName"].ToString();
            lblStandard.Text = dt.Rows[0]["Standard"].ToString();
           
           // lblDescriptionofGoods.Visible = true;
            txtQuantity.Focus();
        }
        else
        {

            lblDescriptionofGoods.Text = "No such Book code";
            txtCode.Focus();
            txtCode.Text = "";
        }
        txtQuantity.Focus();
    }
    protected void txtInvoiceNo_TextChanged(object sender, EventArgs e)
    {
        int Invoice = Convert.ToInt32(txtInvoiceNo.Text.Trim());
        bool Auth = VirtualStockMaster.Idv_Chetana_Get_Validate_PurchaseInvoice(Invoice,Convert.ToInt32(strFY));
        if (Auth)
        {
            MessageBox(" No. is Already Exist");
            txtInvoiceNo.Text = "";
            txtInvoiceNo.Focus();

        }
        else
        {
            txtRemark.Focus();
        }
    }
    protected void btnget_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["a"] == "v")
        {
            BindReport("Report");
        }
        else if (Request.QueryString["a"] == "e")
        {
            BindReport("Edit");
        }

    }
    public void BindReport(string Flag)
    {
        //Get_VirtualStockDatails
        DataTable dt = new DataTable();
        dt = VirtualStockDetails.Get_VirtualStockDatails(Convert.ToInt32(txtinvoice.Text), Convert.ToInt32(strFY)).Tables[0];
        if (dt.Rows.Count > 0)
        {
            if (Flag == "Report")
            {
                ReportDocument rd = new ReportDocument();
                rd.Load(Server.MapPath("Report/printVirtualStock.rpt"));
                rd.Database.Tables[0].SetDataSource(dt);
                // rd.Database.Tables[1].SetDataSource(dv2);
                //rd.SetDataSource(ds);
                VirtualstockView.ReportSource = rd;
                //  grdvirualDetails.DataSource = VirtualStockDetails.Get_VirtualStockDatails(Convert.ToInt32(txtinvoice.Text), Convert.ToInt32(strFY));
                //   grdvirualDetails.DataBind();
            }
            else
            {
                grdvirualDetails.DataSource = dt;
                grdvirualDetails.DataBind();
                pnlVirtual.Visible = true;
                txtInvoiceNo.Text = dt.Rows[0]["InvoiceNo"].ToString();
                txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                txtDate.Text = dt.Rows[0]["InvoiceDate"].ToString();
                lblID.Text = dt.Rows[0]["AutoID"].ToString();
                btn_Save.Visible = true;
                txtInvoiceNo.Enabled = false;
            }
        }
        else
        {
            // grdvirualDetails.DataBind();
            MessageBox("Record Not Found");
            txtinvoice.Focus();
        }
    
    }
    protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["tempdata"];
        dt1.Rows[e.RowIndex].Delete();
        gvDetails.DataSource = dt1;
        gvDetails.DataBind();
        Session["tempdata"] = dt1;
    }
}
