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

public partial class UserControls_uc_AllocateTarget : System.Web.UI.UserControl
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
            //lblID.Text = "0";
            SetView();
            EmpCode = Convert.ToString(Session["UserName"]);

            //grdallocateDetails.DataSource = BindGvAllocateDetail();
            //grdallocateDetails.DataBind();
            // BindSalesman();
            fillzones();

        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow rows in DDLtargetperson.Rows)
        {

            CheckBox chkSelect = (CheckBox)rows.FindControl("chkSelected");
            Label ZoneId = (Label)rows.FindControl("lblZoneID");
            Label ZoneName = (Label)rows.FindControl("lblZoneName");
            Label lblID = (Label)rows.FindControl("lblID");
            TextBox txtstartDate = (TextBox)rows.FindControl("txtstartDate");
            TextBox txtendate = (TextBox)rows.FindControl("txtendate");
            TextBox txtAmount = (TextBox)rows.FindControl("txtAmount");

            if (chkSelect.Checked == true)
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
                        if (Convert.ToInt32(lblID.Text.ToString()) != 0)
                        {
                            _objtarget.TargetdetailsId = Convert.ToInt32(lblID.Text.Trim());
                        }
                        else
                        {
                            _objtarget.TargetdetailsId = 0;
                        }
                        //_objtarget.TargetPersonId = Convert.ToInt32(DDLtargetperson.SelectedItem.Value);
                        _objtarget.TargetAmt = Convert.ToDecimal(txtAmount.Text.Trim());

                        _objtarget.FY = Convert.ToInt32(strFY);
                        _objtarget.TargetId = Convert.ToInt32(DDLsuperzone.SelectedValue.ToString());
                        _objtarget.TargetPersonId = Convert.ToInt32(ZoneId.Text);
                        _objtarget.TargetStartDate = Convert.ToDateTime(fdate);
                        _objtarget.TargetEndDate = Convert.ToDateTime(tdate);
                        _objtarget.IsActive = true;
                        _objtarget.CreatedBy = Session["UserName"].ToString();
                        _objtarget.SaveAllocate();
                        MessageBox(Constants.save);
                        if (btn_Save.Text == "Update")
                        {
                            pnlallocatedetails.Visible = true;
                            Pnlallocate.Visible = false;
                            //grdallocateDetails.DataSource = BindGvAllocateDetail();
                            //grdallocateDetails.DataBind();
                            btn_Save.Text = "Save";
                            btn_Save.Visible = false;
                        }
                        else
                        {
                            pnlallocatedetails.Visible = false;
                            Pnlallocate.Visible = true;

                            //txttargetamt.Text = "";
                            //txtstartDate.Text = "";
                            // txtendate.Text = "";



                        }

                    }

                    catch (Exception ex) { MessageBox("Error " + ex.Message.ToString()); }
                }
                DDLtargetperson.DataSource = BindGvAllocateDetail(DDLsuperzone.SelectedValue.ToString(), Convert.ToInt32(strFY), "");
            }
        }
    }
    #region Binddata method

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Allocate Target ";
                // lblID.Text = "0";

                pnlallocatedetails.Visible = false;
                Pnlallocate.Visible = true;
                btn_Save.Visible = true;
                //  filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Target ";
                    pnlallocatedetails.Visible = true;
                    Pnlallocate.Visible = false;
                    btn_Save.Visible = false;
                    //BindGvAllocateDetail();
                    grdallocateDetails.Visible = true;
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
    #region Get All Salesman

    public void BindSalesman()
    {
        DDLtargetperson.DataSource = TargetMaster.Get_Employee_onUserLogin(EmpCode, "Allocate");
        DDLtargetperson.DataBind();

        DataTable dt = new DataTable();
        dt = TargetMaster.Get_Employee_onUserLogin(Session["UserName"].ToString(), "Allocate").Tables[1];
        if (dt.Rows.Count > 0)
        {
            lbltargetid.Text = dt.Rows[0]["TargetID"].ToString();
        }
    }

    #endregion
    public DataView BindGvAllocateDetail()
    {
        DataTable dt = new DataTable();
        dt = TargetMaster.Get_AllocateKRA(EmpCode);
        DataView dv = new DataView(dt);
        return dv;
    }

    public DataTable BindGvAllocateDetail(string empcode, int FY, string Flag)
    {
        DataTable dt = new DataTable();
        dt = TargetMaster.Get_AllocateKRA(empcode, FY, Flag);
        return dt;
    }
    #endregion

    protected void grdallocateDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Pnlallocate.Visible = true;
        pnlallocatedetails.Visible = false;
        btn_Save.Visible = true;
        btn_Save.Text = "Update";

        try
        {
            //lblID.Text = ((Label)grdallocateDetails.Rows[e.NewEditIndex].FindControl("lblTargetdetailsId")).Text;
            //lbltargetid.Text = ((Label)grdallocateDetails.Rows[e.NewEditIndex].FindControl("lblTargetId")).Text;
            //txtstartDate.Text = ((Label)grdallocateDetails.Rows[e.NewEditIndex].FindControl("lblstartdate")).Text;
            //txtendate.Text = ((Label)grdallocateDetails.Rows[e.NewEditIndex].FindControl("lblenddate")).Text;
            //txttargetamt.Text = ((Label)grdallocateDetails.Rows[e.NewEditIndex].FindControl("lbltargetamt")).Text;
            //DDLtargetperson.SelectedValue = ((Label)grdallocateDetails.Rows[e.NewEditIndex].FindControl("lblTargetPersonId")).Text;

        }
        catch { }
    }
    protected void DDLtargetperson_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bool Auth = 
        //if (Auth)
        //{
        //    MessageBox("Already has target");
        //    DDLtargetperson.Focus();

        //}
        //else
        //{
        //    txttargetamt.Focus();
        //}
    }
    protected void DDLsuperzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strsts = TargetMaster.get_Target_validateh_valid(Convert.ToInt32(DDLsuperzone.SelectedItem.Value), strFY);
        lblDetails.Text = "Target Amount is " + strsts;


        if (strsts.ToLower() == "not set!")
        {
            btn_Save.Visible = false;
        }
        else
        {
            btn_Save.Visible = true;
        }
        getDDLdata();
    }



    public void fillzones()
    {
        DDLsuperzone.DataSource = TargetMaster.Get_Employee_onUserLogin(EmpCode, "Target");
        DDLsuperzone.DataBind();
        DDLsuperzone.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public void getDDLdata()
    {
        DDLtargetperson.DataSource = BindGvAllocateDetail(DDLsuperzone.SelectedValue.ToString(), Convert.ToInt32(strFY), "");
        //Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLsuperzone.SelectedValue.ToString()), "Zone");
        DDLtargetperson.DataBind();

        DDLtargetperson.Enabled = true;
        DDLtargetperson.Focus();
    }
    protected void DDLtargetperson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtstartDate = (TextBox)e.Row.FindControl("txtstartDate");
            TextBox txtendate = (TextBox)e.Row.FindControl("txtendate");
            TextBox txtAmount = (TextBox)e.Row.FindControl("txtAmount");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelected");

            txtAmount.Attributes.Add("onkeyup", "chec('" + chkSelect.ClientID + "','" + txtAmount.ClientID + "');");
            txtAmount.Attributes.Add("onblur", "chec('" + chkSelect.ClientID + "','" + txtAmount.ClientID + "');");
            if (txtstartDate.Text == "")
            {
                txtstartDate.Text = Session["FromDate"].ToString();
            }
            if (txtendate.Text == "")
            {
                txtendate.Text = Session["ToDate"].ToString();
            }
        }
    }
}
