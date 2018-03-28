#region NameSpaces
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

#endregion

public partial class UserControls_ODC_receipt_ReceiptnoView : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetView();
          
        }
    }
    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Receipt View"; 
                pnlreceiptno.Visible = true;
                gvBouncedetails.Visible = true;
                GrdViewChequedate.Visible = false;
                pnlcust.Visible = false;
                
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    //bindData();
                    pageName.InnerHtml = "Cheque Cancel"; 
                    pnlcust.Visible = true;
                    gvBouncedetails.Visible = false;
                    pnlreceiptno.Visible = false;
                    GrdViewChequedate.Visible = true;
                    
                   
                }
        }
    }
    protected void buttonsave_Click(object sender, EventArgs e)
    {
         int ReceiptNo;
         ReceiptNo = Convert.ToInt32(txtReceiptno.Text.Trim());
        DataTable dt12 = new DataTable();
        dt12 = ChequeBounceDetails.Get_ReceiptViewBookDetails(ReceiptNo).Tables[0];
        if (dt12.Rows.Count != 0)
        {
            gvBouncedetails.DataSource = dt12;
            gvBouncedetails.DataBind();
            gvBouncedetails.Visible = true;

        }
        else
        {
            message("Not in Record");
            gvBouncedetails.Visible = false;
        }
    }
    public void bindData()
    {
        string Fromdate1 = txtdate.Text.Split('/')[1].ToString() + "/" + txtdate.Text.Split('/')[0].ToString() + "/" + txtdate.Text.Split('/')[2].ToString();
        string Todate1 = txttodate.Text.Split('/')[1].ToString() + "/" + txttodate.Text.Split('/')[0].ToString() + "/" + txttodate.Text.Split('/')[2].ToString();

        //string Fromdate1 = txtdate.Text.Split('/')[1].ToString() + "/" + txtdate.Text.Split('/')[0].ToString() + "/" + txtdate.Text.Split('/')[2].ToString();
        DateTime Fromdate = Convert.ToDateTime(Fromdate1);

        // string Todate1 = txttodate.Text.Split('/')[1].ToString() + "/" + txttodate.Text.Split('/')[0].ToString() + "/" + txttodate.Text.Split('/')[2].ToString(); 
        DateTime Todate = Convert.ToDateTime(Todate1);
        DataTable dt = new DataTable();
        dt = Cheque_CashDetails.Get_ChequeChashDoCancel(Fromdate, Todate).Tables[0];

        lblmessage.Text = "";
        if (dt.Rows.Count != 0)
        {

            GrdViewChequedate.DataSource = dt;
            GrdViewChequedate.DataBind();
            // pnlchequedate.Visible = true;
            GrdViewChequedate.Visible = true;
        }
        else
        {
            message("No such ChequeDate");
            GrdViewChequedate.Visible = false;
            txtdate.Focus();
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
    protected void btnGet_Click(object sender, EventArgs e)
    {

        string Fromdate1 = txtdate.Text.Split('/')[1].ToString() + "/" + txtdate.Text.Split('/')[0].ToString() + "/" + txtdate.Text.Split('/')[2].ToString();
        string Todate1 = txttodate.Text.Split('/')[1].ToString() + "/" + txttodate.Text.Split('/')[0].ToString() + "/" + txttodate.Text.Split('/')[2].ToString();

        //string Fromdate1 = txtdate.Text.Split('/')[1].ToString() + "/" + txtdate.Text.Split('/')[0].ToString() + "/" + txtdate.Text.Split('/')[2].ToString();
        DateTime Fromdate = Convert.ToDateTime(Fromdate1);

        // string Todate1 = txttodate.Text.Split('/')[1].ToString() + "/" + txttodate.Text.Split('/')[0].ToString() + "/" + txttodate.Text.Split('/')[2].ToString(); 
        DateTime Todate = Convert.ToDateTime(Todate1);
        DataTable dt = new DataTable();
        dt = Cheque_CashDetails.Get_ChequeChashDoCancel(Fromdate, Todate).Tables[0];

        lblmessage.Text = "";
        if (dt.Rows.Count != 0)
        {

            GrdViewChequedate.DataSource = dt;
            GrdViewChequedate.DataBind();
            // pnlchequedate.Visible = true;
            GrdViewChequedate.Visible = true;
        }
        else
        {
            message("No such ChequeDate");
            GrdViewChequedate.Visible = false;
            txtdate.Focus();
        }

    }
    protected void GrdViewChequedate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
            Cheque_CashDetails cq = new Cheque_CashDetails();
            cq.CQ_ID = Convert.ToInt32(((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lblcqid")).Text);
            cq.EmpID = ((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lblEmpId")).Text;
            cq.CustId = ((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lblcustid")).Text;
            cq.Deposite_Type = ((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lbldepositType")).Text;
            cq.CreatedBy = ((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lblcreatedby")).Text;
            cq.ChequeDate = ((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lblChequeDate")).Text;
            cq.Payee_Bank = ((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lblPayee_Bank")).Text;
            cq.ReciptNo = Convert.ToInt32(((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lblrec")).Text);
            cq.ChequeNo = ((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lblChequeNo")).Text;
            cq.Amount = Convert.ToDecimal(((Label)GrdViewChequedate.Rows[e.RowIndex].FindControl("lblAmount")).Text);
            cq.IsCancel = Convert.ToBoolean(true);
            cq.CancelDate = System.DateTime.Now;
            cq.Save();
            message("Record Deleted successfully");
            bindData();
        
    }
}
