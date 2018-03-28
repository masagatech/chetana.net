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

public partial class UserControls_uc_TargetMaster : System.Web.UI.UserControl
{
    #region Variables
         public static string EmpCode;
         DateTime fdate;
         DateTime tdate;
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
            if (Session["UserName"] != null)
            {
                SetView();
                // lblID.Text = "0";
                EmpCode = Convert.ToString(Session["UserName"]);
                DDLtargetperson.Items.Insert(0, new ListItem("-- Select --", "0"));
                grdtargetDetails.DataSource = BindGvTargetDetail(Convert.ToInt32(strFY));
                grdtargetDetails.DataBind();
                BindSalesman();
                txtstartDate.Text = Session["FromDate"].ToString();
                txtendate.Text = Session["ToDate"].ToString();
            }
            else
            {
                Response.Redirect("Dashboard.aspx");
            }

        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        string from = txtstartDate.Text.Split('/')[1] + "/" + txtstartDate.Text.Split('/')[0] + "/" + txtstartDate.Text.Split('/')[2];
        string To = txtendate.Text.Split('/')[1] + "/" + txtendate.Text.Split('/')[0] + "/" + txtendate.Text.Split('/')[2];
        fdate = Convert.ToDateTime(from);
        tdate = Convert.ToDateTime(To);
        if (fdate > tdate)
        {
            MessageBox("Start Date Should be Greater than End Date");
            txtstartDate.Focus();
        }
        else
        {
            try
            {
                TargetMaster _objtarget = new TargetMaster();
                if (lblID.Text != "0")
                {
                    _objtarget.TargetId = Convert.ToInt32(lblID.Text.Trim());
                }
                else
                {
                    _objtarget.TargetId = 0;
                }
                _objtarget.TargetPersonId = Convert.ToInt32(DDLtargetperson.SelectedItem.Value);

                _objtarget.TargetAmt = Convert.ToDecimal(txttargetamt.Text.Trim());
                string StartDate = txtstartDate.Text.Split('/')[1] + "/" + txtstartDate.Text.Split('/')[0] + "/" + txtstartDate.Text.Split('/')[2];
                string endDate = txtendate.Text.Split('/')[1] + "/" + txtendate.Text.Split('/')[0] + "/" + txtendate.Text.Split('/')[2];
                _objtarget.TargetStartDate = Convert.ToDateTime(StartDate);
                _objtarget.TargetEndDate = Convert.ToDateTime(endDate);
                _objtarget.IsActive = true;
                _objtarget.FY = Convert.ToInt32(strFY);
                _objtarget.CreatedBy = Session["UserName"].ToString();
                string ID = TargetMaster.get_Target_validateh_valid(Convert.ToInt32(DDLtargetperson.SelectedItem.Value), strFY);
                if (ID.ToLower() != "not set!" && lblID.Text == "0")
                {
                    MessageBox("Already has target");
                    DDLtargetperson.Focus();
                    DDLtargetperson.SelectedIndex = 0;
                }
                else
                {

                    _objtarget.Save();
                    MessageBox(Constants.save);
                    if (btn_Save.Text == "Update")
                    {
                        pnlTargetdetails.Visible = true;
                        PnlTarget.Visible = false;
                        grdtargetDetails.DataSource = BindGvTargetDetail(Convert.ToInt32(strFY));
                        grdtargetDetails.DataBind();
                        btn_Save.Text = "Save";
                        btn_Save.Visible = false;
                    }
                    else
                    {
                        pnlTargetdetails.Visible = false;
                        PnlTarget.Visible = true;
                        btn_Save.Text = "Update";
                        txttargetamt.Text = "";
                        txtstartDate.Text = "";
                        txtendate.Text = "";
                        DDLtargetperson.SelectedValue = "0";


                    }

                }
            }

            catch { }
        }                        
    }
    protected void grdtargetDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #region Binddata method

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Set Target ";
                lblID.Text = "0";
                pnlTargetdetails.Visible = false;
                PnlTarget.Visible = true;
                btn_Save.Visible = true;
                DDLtargetperson.Focus();
              //  filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Target ";
                    pnlTargetdetails.Visible = true;
                    PnlTarget.Visible = false;
                    btn_Save.Visible = false;
                    BindGvTargetDetail(Convert.ToInt32(strFY));
                   // filter.Visible = true;
                }
        }
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    public DataView BindGvTargetDetail(int FY)
    {
       DataTable dt = new DataTable();
       dt = TargetMaster.Get_TargetMaster(FY);
       DataView dv = new DataView(dt);
       return dv;
    }
    #endregion

    #region Get All Salesman

    public void BindSalesman()
    {
        DDLtargetperson.DataSource = TargetMaster.Get_Employee_onUserLogin(EmpCode, "Target");
        DDLtargetperson.DataBind();
        DDLtargetperson.Items.Insert(0, new ListItem("-- Select --","0"));
    }

    #endregion




    protected void grdtargetDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PnlTarget.Visible = true;
        pnlTargetdetails.Visible = false;
        btn_Save.Visible = true;
        btn_Save.Text = "Update";

        try
        {
            lblID.Text = ((Label)grdtargetDetails.Rows[e.NewEditIndex].FindControl("lblTargetId")).Text;
            DDLtargetperson.SelectedValue = ((Label)grdtargetDetails.Rows[e.NewEditIndex].FindControl("lblTargetPersonId")).Text;
            txtstartDate.Text = ((Label)grdtargetDetails.Rows[e.NewEditIndex].FindControl("lblstartdate")).Text;
            txtendate.Text = ((Label)grdtargetDetails.Rows[e.NewEditIndex].FindControl("lblenddate")).Text;
            txttargetamt.Text = ((Label)grdtargetDetails.Rows[e.NewEditIndex].FindControl("lbltargetamt")).Text;
        }
        catch { }
    }

    protected void DDLtargetperson_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ID = TargetMaster.get_Target_validateh_valid(Convert.ToInt32(DDLtargetperson.SelectedItem.Value), strFY);
        if(ID.ToLower() != "not set!")
        {
            MessageBox("Already has target");
            DDLtargetperson.Focus();
            DDLtargetperson.SelectedIndex = 0;
        }
        else
        {
            txttargetamt.Focus();
        }
    }
}
