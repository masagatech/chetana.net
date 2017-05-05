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
using System.IO;
using System.Text;
#endregion

public partial class UserControls_uc_UpdateBooksStock : System.Web.UI.UserControl
{
    string strFY;
    protected void Page_Load(object sender, EventArgs e)
    {

        btnsave.Visible = false;

        if (Session["FY"] != null)
        {
            

            strFY = Session["FY"].ToString();
            //  HidFY.Value = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
        }
        if (!Page.IsPostBack)
        {
            txtFromDate.Focus();
            // Grdstockreport.DataSource = DCMaster.REP_Physical_STOCK("gdvgd",Convert.ToInt32(strFY)).Tables[0];
            //Grdstockreport.DataBind();

            // lblTotalBooksInGodown.Text = DCMaster.REP_Physical_STOCK("gdvgd", Convert.ToDateTime(""), Convert.ToDateTime(""), Convert.ToInt32(strFY)).Tables[1].Rows[0][0].ToString();
        }
        //if (IsPostBack)
        //{
        //    Bind();
        //}
    }
    public void Bind()
    {
        string from = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        DateTime FromDate = Convert.ToDateTime(from);
        DateTime ToDate = Convert.ToDateTime(To);
        Grdstockreport.DataSource = DCMaster.REP_Physical_STOCK("gdvgd", FromDate, ToDate, Convert.ToInt32(strFY)).Tables[0];
        Grdstockreport.DataBind();

        //lblTotalBooksInGodown.Text = DCMaster.REP_Physical_STOCK("gdvgd", FromDate, ToDate, Convert.ToInt32(strFY)).Tables[1].Rows[0][0].ToString();
    }
   

 
   
    protected void btngetdate_Click(object sender, EventArgs e)
    {
        Bind();
        
       btnsave.Visible = true;
       //btngetdate.Visible = false;
        
    }
    
    protected void btnsave_Click(object sender, EventArgs e)
    {
        UpdateBooksStock updatestock = new UpdateBooksStock();
       
        btnsave.Visible = false;
        foreach (GridViewRow g1 in Grdstockreport.Rows)
        {

            if ((g1.FindControl("chkselect") as CheckBox).Checked)
            {
                updatestock.BookCode = (g1.FindControl("lblbkcode") as Label).Text;
                updatestock.stock = Convert.ToInt32((g1.FindControl("txtavailable") as TextBox).Text);
                updatestock.Fy = Convert.ToInt32(strFY.ToString());
                updatestock.createdBy = Session["UserName"].ToString();
                updatestock.Save();
            }
          

        }
        message("Record Save Successfully");
      }

    #region MessageBox

    public void message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    #endregion
}

