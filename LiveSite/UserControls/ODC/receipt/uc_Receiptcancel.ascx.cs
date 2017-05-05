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

public partial class UserControls_Receiptcancel : System.Web.UI.UserControl
{
    #region Variables
    static string ECode;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            //  PnlCustDiscDetails.Enabled = false;
            txtEMcode.Visible = true;
           
            textboxchangeevent();
            SetView();
        }
        else
        {
        }

    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                txtEMcode.Focus();
                pnlbutt.Visible = true;
                pnlCust.Visible = true;
                PnlCustDiscDetails.Visible = true;
                UpanelGrd.Visible = false;
                PnlCustDiscDetails.Enabled = false;
                btn_Save.Visible = true;
                view.Visible = true;
                Redio();

            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    txtempcode.Focus();
                    pnlCust.Visible = false;
                    PnlCustDiscDetails.Visible = false;
                    UpanelGrd.Visible = true;
                    btn_Save.Visible = false;
                    view.Visible = false;

                }
        }
    }
    public void Redio()
    {

        if (redio.Items[0].Selected)
        {
            txtEMcode.Focus();
            pnlCust.Visible = true;
            PnlCustDiscDetails.Visible = true;
            lblFrom.Text = "ReceiptNo";
            //btn_Save.Visible = true;
            lblTo.Visible = false;
            txtFrom.Visible = true;
            txtTo.Visible = false;
            view.Visible = false;
            restrict.Visible = false;
            Pnlmultiplecancel.Visible = false;
            gvMultipleCancel.Visible = false;
            btn_Save.Visible = true;
            txtTo.Text = "";
            txtFrom.Text = "";
            txtResion.Text = "";
        }
        else
        {
            txtEMcode.Focus();
            restrict.Visible = true;
            pnlbutt.Visible = true;
            pnlCust.Visible = true;
            PnlCustDiscDetails.Visible = true;
            view.Visible = true;
            txtResion.Visible = true;
            Pnlmultiplecancel.Visible = true;
            gvMultipleCancel.Visible = true;
            lblFrom.Text = "FromNo";
            lblTo.Visible = true;
            lblReion.Visible = true;
            lblTo.Text = "ToNo";
            txtTo.Visible = true;
            btn_Save.Visible = false;
            gvMultipleCancel.Visible = false;

            txtFrom.Text = "";
            txtTo.Text = "";
            txtResion.Text = "";
            
             btn_Save.Visible = false;

        }

    }
    protected void txtEMcode_TextChanged(object sender, EventArgs e)
    {
        ECode = txtEMcode.Text.ToString().Split(':')[0].Trim();


        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode, "Employee").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtEMcode.Text = ECode;
            lblshow.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
            txtFrom.Focus();

            textboxchangeevent();
        }
        else
        {

            lblshow.Text = "No such salesman code";
            txtEMcode.Focus();
            txtEMcode.Text = "";
            txtFrom.Enabled = false;
            txtResion.Enabled = false;
            txtFrom.Text = "";
            txtResion.Text = "";
        }

    }

    protected void btn_Save_Click1(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {



            string ECode = txtEMcode.Text.ToString().Split(':')[0].Trim();
            //txtempcode.Text = ECode;
            int FromNo = Convert.ToInt32(txtFrom.Text);

            int ToNo = Convert.ToInt32(txtTo.Text);
            DataSet ds = new DataSet();
            ds = ReciptBookDetails.Get_Multiplecanceldetails(ECode, FromNo, ToNo);
            if (ds.Tables[0].Columns.Count > 1 & redio.SelectedIndex == 0)
            {

                ReciptCancelBook reccan = new ReciptCancelBook();
                reccan.AutoCancelRecNo = Convert.ToInt32("0");
                reccan.EmpCode = txtEMcode.Text.Trim();
                reccan.FromNo = Convert.ToInt32(txtFrom.Text.Trim());
                reccan.ToNo = Convert.ToInt32(txtFrom.Text.Trim());
                reccan.Resion = txtResion.Text.Trim();

                reccan.CreatedBy = Session["UserName"].ToString();
                reccan.Save();
                message("Record Saved Successfully");

                //pnlCust.Visible = true;
                //PnlCustDiscDetails.Visible = true;
                //UpanelGrd.Visible = false;
                txtEMcode.Text = "";
                txtFrom.Text = "";
                txtTo.Text = "";
                txtResion.Text = "";
                gvMultipleCancel.DataSource = null;
                gvMultipleCancel.DataBind();
                multipal.Update();
                //btn_Save.Visible = false; 
            }

            else
            {
                if (gvMultipleCancel.Rows.Count > 0)
                {

                    Label lblReceiptNo = null;
                    TextBox txtReasonGrd = null;
                    CheckBox chkSelect = null;
                    foreach (GridViewRow row in gvMultipleCancel.Rows)
                    {

                        lblReceiptNo = (Label)row.FindControl("lblFromNo");
                        txtReasonGrd = (TextBox)row.FindControl("remarktext");
                        chkSelect = (CheckBox)row.FindControl("check");
                        if (chkSelect.Checked == true)
                        {
                            if (lblReceiptNo.Text != "")
                            {
                                ReciptCancelBook reccan = new ReciptCancelBook();
                                reccan.AutoCancelRecNo = Convert.ToInt32("0");
                                reccan.EmpCode = txtEMcode.Text.Trim();
                                reccan.FromNo = Convert.ToInt32(lblReceiptNo.Text.Trim());
                                reccan.ToNo = Convert.ToInt32(lblReceiptNo.Text.Trim());
                                if (txtReasonGrd.Text != "")
                                {
                                    reccan.Resion = txtReasonGrd.Text;
                                }
                                else
                                {
                                    reccan.Resion = txtResion.Text.Trim();
                                }

                                reccan.CreatedBy = Session["UserName"].ToString();
                                reccan.Save();
                                message("Record Saved Successfully");

                            }
                        }
                    }
                    message("Receipt No not found");
                    txtEMcode.Text = "";
                    txtFrom.Text = "";
                    txtTo.Text = "";
                    lblshow.Text = "";
                    txtResion.Text = "";
                    gvMultipleCancel.DataSource = null;
                    gvMultipleCancel.DataBind();
                    multipal.Update();
                    //btn_Save.Visible = false; 
                }
            }

            message("Receipt not found between entered Receipt no.");

        }
    }

    protected void txtempcode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtempcode.Text.ToString().Split(':')[0].Trim();


        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(ECode, "Employee").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtempcode.Text = ECode;
            lblempname.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];

            DataSet ds = new DataSet();
            ds = ReciptCancelBook.get_ReciptCancel_book(ECode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdViewRegion.DataSource = ds;
                GrdViewRegion.DataBind();
                GrdViewRegion.Visible = true;
                txtFrom.Focus();
            }
            else
            {
                message("NO Record Found");
            }
        }
        else
        {

            lblempname.Text = "No such salesman code";
            txtempcode.Focus();
            txtempcode.Text = "";
           
        }
    }
    protected void view_Click(object sender, EventArgs e)
    {
        if ((Convert.ToInt32(txtFrom.Text.Trim())) > (Convert.ToInt32(txtTo.Text.Trim())))
        {
            message("FromNo should be greater than ToNo");
            txtFrom.Focus();
        }
        else
        {
            //pnlCust.Visible = false;
            // PnlCustDiscDetails.Visible = false;
            //UpanelGrd.Visible = true;

            string ECode = txtEMcode.Text.ToString().Split(':')[0].Trim();
            //txtempcode.Text = ECode;
            int FromNo = Convert.ToInt32(txtFrom.Text);

            int ToNo = Convert.ToInt32(txtTo.Text);
            DataSet ds = new DataSet();
            ds = ReciptBookDetails.Get_Multiplecanceldetails(ECode, FromNo, ToNo);
            if (ds.Tables[0].Columns.Count > 1)
            {
                gvMultipleCancel.DataSource = ds;
                gvMultipleCancel.DataBind();
                btn_Save.Visible = true;
                gvMultipleCancel.Visible = true;

            }
            else
            {
                message("Record not found between entered Receipt no.");
            }
            // Pnlmultiplecancel.Visible = true;
            //  gvMultipleCancel.Visible = true;
            //  btn_Save.Visible = true;
        }
        // message("Select Correct allocation Ranges Receipt No");
    }

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
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
    public void textboxchangeevent()
    {
        if (txtEMcode.Text != null)
        {
            PnlCustDiscDetails.Enabled = true;
            txtEMcode.Visible = true;
            txtFrom.Enabled = true;
            txtTo.Enabled = true;
            txtResion.Enabled = true;
        }
        else
        {
            PnlCustDiscDetails.Enabled = false;
            txtEMcode.Visible = true;

        }

    }

    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        txtTo.Enabled = true;
        txtTo.Text = txtFrom.Text;
        txtTo.Focus();

        if (redio.SelectedIndex == 0)
        {

            string EMCode = txtEMcode.Text.ToString();
            DataTable dt = new DataTable();
            dt = ReciptCancelBook.Get_Validate_ReceiptCancelBook(EMCode, Convert.ToInt32(txtFrom.Text)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox("Receipt No. Already Canceled");
                txtFrom.Text = "";
               
                txtTo.Focus();
            }
        }


        //try
        //{

        //    int FromNo = Convert.ToInt32(txtFrom.Text.Trim());
        //    bool Auth = true;
        //    if (Auth)
        //    {
        //        MessageBox(" No. is Already Exist");
        //        txtFrom.Text = "";
        //        txtTo.Focus();

        //    }
        //    else
        //    {

        //    }
        //}
        //catch (Exception ex)
        //{
        //}
    }

    protected void redio_SelectedIndexChanged(object sender, EventArgs e)
    {
        Redio();
    }

    protected void gvMultipleCancel_SelectedIndexChanged(object sender, EventArgs e)
    {

        Button gv = (Button)sender;
        TextBox remarktext = (TextBox)gv.Parent.FindControl("remarktext");

        ReciptCancelBook reccan2 = new ReciptCancelBook();
        reccan2.EmpCode = (((Label)gv.Parent.FindControl("lblEmpId")).Text);
        reccan2.FromNo = Convert.ToInt32(((Label)((Button)(sender)).Parent.FindControl("lblFromNo")).Text);
        reccan2.ToNo = Convert.ToInt32(((Label)gv.Parent.FindControl("lblFromNo")).Text);
        reccan2.Resion = remarktext.Text.Trim();
        reccan2.Save();
    }
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        txtResion.Focus();
    }
}


