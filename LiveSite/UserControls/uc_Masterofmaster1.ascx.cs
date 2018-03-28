#region NameSpace

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

#endregion

public partial class UserControls_uc_Masterofmaster : System.Web.UI.UserControl
{
    #region Variables

    public static string Group;

    #endregion

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        
        SetView();
        if (!Page.IsPostBack)
        {
            BindGvDetail();
        }
        else
            setActiveUrl();
    }
    #endregion

    #region Methods

    private void setActiveUrl()
    {
        string pagename = Request.Url.Segments[Request.Url.Segments.Length - 1].ToLower();
        if (pagename == "booktype.aspx")
        {
            if (Request.QueryString["a"] != null)
            {
                if (Request.QueryString["a"] == "a")
                {
                    pageName.InnerHtml = "ADD Book Type ";
                }
                else
                    if (Request.QueryString["a"] == "v")
                    {
                        pageName.InnerHtml = "View / Edit Book Type ";
                    }
            }
            Group = "BookType";
            lblkey.Text = "BookType Code :";
            lblvalue.Text = "BookType Name :";
        }
        else
            if (pagename == "bookgroup.aspx")
            {
                if (Request.QueryString["a"] != null)
                {
                    if (Request.QueryString["a"] == "a")
                    {
                        pageName.InnerHtml = "ADD Book Group ";
                    }
                    else
                        if (Request.QueryString["a"] == "v")
                        {
                            pageName.InnerHtml = "View / Edit Book Group ";
                        }
                }
                Group = "BookGroup";
                lblkey.Text = "BookGroup Code :";
                lblvalue.Text = "BookGroup Name :";
            }
            else
                if (pagename == "department.aspx")
                {
                    if (Request.QueryString["a"] != null)
                    {
                        if (Request.QueryString["a"] == "a")
                        {
                            pageName.InnerHtml = "ADD Department ";
                        }
                        else
                            if (Request.QueryString["a"] == "v")
                            {
                                pageName.InnerHtml = "View / Edit Department ";
                            }
                    }
                    Group = "Department";
                    lblkey.Text = "Department Code :";
                    lblvalue.Text = "Department Name :";
                }
                else
                    if (pagename == "family.aspx")
                    {
                        if (Request.QueryString["a"] != null)
                        {
                            if (Request.QueryString["a"] == "a")
                            {
                                pageName.InnerHtml = "ADD Family ";
                            }
                            else
                                if (Request.QueryString["a"] == "v")
                                {
                                    pageName.InnerHtml = "View / Edit Family ";
                                }
                        }
                        Group = "Family";
                        lblkey.Text = "Family Code :";
                        lblvalue.Text = "Family Name :";
                    }
                    else
                        if (pagename == "bookset.aspx")
                        {
                            if (Request.QueryString["a"] != null)
                            {
                                if (Request.QueryString["a"] == "a")
                                {
                                    pageName.InnerHtml = "ADD Bookset ";
                                }
                                else
                                    if (Request.QueryString["a"] == "v")
                                    {
                                        pageName.InnerHtml = "View / Edit Bookset ";
                                    }
                            }
                            Group = "Bookset";
                            lblkey.Text = "BookSet Code :";
                            lblvalue.Text = "BookSet Name :";
                        }
                        else
                            if (pagename == "qualification.aspx")
                            {
                                if (Request.QueryString["a"] != null)
                                {
                                    if (Request.QueryString["a"] == "a")
                                    {
                                        pageName.InnerHtml = "ADD Qualification ";
                                    }
                                    else
                                        if (Request.QueryString["a"] == "v")
                                        {
                                            pageName.InnerHtml = "View / Edit Qualification ";
                                        }
                                }
                                Group = "Qualification";
                                lblkey.Text = "Qualification Code :";
                                lblvalue.Text = "Qualification Name :";
                            }
                            else
                                if (pagename == "medium.aspx")
                                {
                                    if (Request.QueryString["a"] != null)
                                    {
                                        if (Request.QueryString["a"] == "a")
                                        {
                                            pageName.InnerHtml = "ADD Medium ";
                                        }
                                        else
                                            if (Request.QueryString["a"] == "v")
                                            {
                                                pageName.InnerHtml = "View / Edit Medium ";
                                            }
                                    }
                                    Group = "Medium";
                                    lblkey.Text = "Medium Code";
                                    lblvalue.Text = "Medium Name";
                                }
                                else
                                    if (pagename == "standard.aspx")
                                    {
                                        if (Request.QueryString["a"] != null)
                                        {
                                            if (Request.QueryString["a"] == "a")
                                            {
                                                pageName.InnerHtml = "ADD Standard ";
                                            }
                                            else
                                                if (Request.QueryString["a"] == "v")
                                                {
                                                    pageName.InnerHtml = "View / Edit Standard ";
                                                }
                                        }
                                        Group = "Standard";
                                        lblkey.Text = "Standard Code";
                                        lblvalue.Text = "Standard Name";
                                    }
                                    else
                                        if (pagename == "transport.aspx")
                                        {
                                            if (Request.QueryString["a"] != null)
                                            {
                                                if (Request.QueryString["a"] == "a")
                                                {
                                                    pageName.InnerHtml = "ADD Transport ";
                                                }
                                                else
                                                    if (Request.QueryString["a"] == "v")
                                                    {
                                                        pageName.InnerHtml = "View / Edit Transport ";
                                                    }
                                            }
                                            Group = "Transport";
                                            lblkey.Text = "Transport Code";
                                            lblvalue.Text = "Transport Name";
                                        }
                                        else
                                            if (pagename == "narration.aspx")
                                            {
                                                if (Request.QueryString["a"] != null)
                                                {
                                                    if (Request.QueryString["a"] == "a")
                                                    {
                                                        pageName.InnerHtml = "ADD Narration ";
                                                    }
                                                    else
                                                        if (Request.QueryString["a"] == "v")
                                                        {
                                                            pageName.InnerHtml = "View / Edit Narration ";
                                                        }
                                                }
                                                pageName.InnerHtml = "Narration";
                                                Group = "Narration";
                                                lblkey.Text = "Narration Code";
                                                lblvalue.Text = "Narration Name";
                                            }
                                            else
                                                if (pagename == "designation.aspx")
                                                {
                                                    if (Request.QueryString["a"] != null)
                                                    {
                                                        if (Request.QueryString["a"] == "a")
                                                        {
                                                            pageName.InnerHtml = "ADD Designation ";
                                                        }
                                                        else
                                                            if (Request.QueryString["a"] == "v")
                                                            {
                                                                pageName.InnerHtml = "View / Edit Designation ";
                                                            }
                                                    }
                                                    Group = "Designation";
                                                    lblkey.Text = "Designation Code";
                                                    lblvalue.Text = "Designation Name";
                                                }
                                                else
                                                    if (pagename == "customertype.aspx")
                                                    {
                                                        if (Request.QueryString["a"] != null)
                                                        {
                                                            if (Request.QueryString["a"] == "a")
                                                            {
                                                                pageName.InnerHtml = "ADD Customer Type ";
                                                            }
                                                            else
                                                                if (Request.QueryString["a"] == "v")
                                                                {
                                                                    pageName.InnerHtml = "View / Edit Customer Type ";
                                                                }
                                                        }
                                                        Group = "CUSTOMERTYPE";
                                                        lblkey.Text = "Customer Type Code";
                                                        lblvalue.Text = "Customer Type Name";
                                                    }
                                                    else
                                                        if (pagename == "customerrating.aspx")
                                                        {
                                                            if (Request.QueryString["a"] != null)
                                                            {
                                                                if (Request.QueryString["a"] == "a")
                                                                {
                                                                    pageName.InnerHtml = "ADD Customer Rating";
                                                                }
                                                                else
                                                                    if (Request.QueryString["a"] == "v")
                                                                    {
                                                                        pageName.InnerHtml = "View / Edit Customer Rating";
                                                                    }
                                                            }
                                                            Group = "CustRating";
                                                            lblkey.Text = "Customer Rating Code";
                                                            lblvalue.Text = "Customer Rating";
                                                        }
                                                        else
                                                            if (pagename == "expensehead.aspx")
                                                            {
                                                                if (Request.QueryString["a"] != null)
                                                                {
                                                                    if (Request.QueryString["a"] == "a")
                                                                    {
                                                                        pageName.InnerHtml = "ADD ExpenseHead";
                                                                    }
                                                                    else
                                                                        if (Request.QueryString["a"] == "v")
                                                                        {
                                                                            pageName.InnerHtml = "View / Edit ExpenseHead";
                                                                        }
                                                                }
                                                                Group = "ExpenseHead";
                                                                lblkey.Text = "ExpenseHead Code";
                                                                lblvalue.Text = "ExpenseHead Name";
                                                            }
                                                            else
                                                                if (pagename == "board.aspx")
                                                                {
                                                                    if (Request.QueryString["a"] != null)
                                                                    {
                                                                        if (Request.QueryString["a"] == "a")
                                                                        {
                                                                            pageName.InnerHtml = "ADD Board ";
                                                                        }
                                                                        else
                                                                            if (Request.QueryString["a"] == "v")
                                                                            {
                                                                                pageName.InnerHtml = "View / Edit Board ";
                                                                            }
                                                                    }
                                                                    Group = "Board";
                                                                    lblkey.Text = "Board Code";
                                                                    lblvalue.Text = "Board Name";
                                                                }
                                                                else
                                                                    if (pagename == "scheme.aspx")
                                                                    {
                                                                        if (Request.QueryString["a"] != null)
                                                                        {
                                                                            if (Request.QueryString["a"] == "a")
                                                                            {
                                                                                pageName.InnerHtml = "ADD Scheme ";
                                                                            }
                                                                            else
                                                                                if (Request.QueryString["a"] == "v")
                                                                                {
                                                                                    pageName.InnerHtml = "View / Edit Scheme ";
                                                                                }
                                                                        }
                                                                        Group = "Scheme";
                                                                        lblkey.Text = "Scheme Code";
                                                                        lblvalue.Text = "Scheme Name";
                                                                    }
                                                                    else
                                                                        if (pagename == "teamcreate.aspx")
                                                                        {
                                                                            if (Request.QueryString["a"] != null)
                                                                            {
                                                                                if (Request.QueryString["a"] == "a")
                                                                                {
                                                                                    pageName.InnerHtml = "ADD Team ";
                                                                                }
                                                                                else
                                                                                    if (Request.QueryString["a"] == "v")
                                                                                    {
                                                                                        pageName.InnerHtml = "View / Edit Team ";
                                                                                    }
                                                                            }
                                                                            Group = "Team";
                                                                            lblkey.Text = "Team Code";
                                                                            lblvalue.Text = "Team Name";
                                                                        }
                                                                        else
                                                                            if (pagename == "purchasevatmaster.aspx")
                                                                            {
                                                                                if (Request.QueryString["a"] != null)
                                                                                {
                                                                                    if (Request.QueryString["a"] == "a")
                                                                                    {
                                                                                        pageName.InnerHtml = "Purchase VAT Master";
                                                                                        msoms.Visible = true;
                                                                                    }
                                                                                    else
                                                                                        if (Request.QueryString["a"] == "v")
                                                                                        {
                                                                                            pageName.InnerHtml = "View / Edit Purchase VAT Master ";
                                                                                        }
                                                                                }
                                                                                Group = "PVM";
                                                                                lblkey.Text = "Code";
                                                                                lblvalue.Text = "%";
                                                                            }



    }


    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                txtkey.Focus();
                lblID.Text = "0";
                Panel1.Visible = true;
                Panel2.Visible = false;
                btnSave.Visible = true;
                filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    filter.Focus();
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    btnSave.Visible = false;
                    filter.Visible = true;
                }
        }
    }
    #endregion

    #region Binddata method

    public void BindGvDetail()
    {
        setActiveUrl();
        if (Group == "PVM")
        {
            GrdDetails.Columns[2].Visible = true;
            GrdDetails.Columns[1].HeaderStyle.Width = 20;
            GrdDetails.Columns[1].HeaderText = "(%)";
        }
        else
        {

            GrdDetails.Columns[2].Visible = false;
        }
        GrdDetails.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup(Group);
        GrdDetails.DataBind();
     
        
    }

    #endregion

    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    #region Events

    protected void btnSave_Click(object sender, EventArgs e)
    {
        setActiveUrl();
        Masterofmaster _objMoM = new Masterofmaster();
        _objMoM.AutoId = Convert.ToInt32(lblID.Text);
        _objMoM.key = txtkey.Text.Trim();
        _objMoM.Value = txtvalue.Text.Trim();
        if (Group == "PVM")
        {
            _objMoM.Description = txtdecp.Text.Trim() + "#" + ddlMSOms.SelectedValue.ToString();
        }
        else
        {
            _objMoM.Description = txtdecp.Text.Trim();
        }
        _objMoM.Group = Group;
        _objMoM.IsActive = chkActive.Checked;
        //  txtkey.Enabled = false;

        try
        {

            if (lblID.Text == "0")
            {
                if (txtkey.Text != "")
                {
                    _objMoM.Save();
                }
                MessageBox("Record saved successfully");
                txtkey.Text = "";
                txtvalue.Text = "";
                txtdecp.Text = "";
                chkActive.Checked = false;
                filter.Visible = false;
                BindGvDetail();
                Panel2.Visible = false;
                Panel1.Visible = true;
                btnSave.Text = "Save";
            }
            else
            {
                if (lblID.Text != "0")
                {
                    if (txtkey.Text != "")
                    {
                        _objMoM.Save();
                    }
                    MessageBox("Record updated successfully");
                    chkActive.Checked = false;
                    filter.Visible = true;
                    BindGvDetail();
                    Panel2.Visible = true;
                    Panel1.Visible = false;
                }

            }
            //  filter.Visible = true;
        }
        catch
        {

        }
    }

    #endregion

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
    }

    protected void GrdDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        btnSave.Visible = true;
        filter.Visible = false;
        btnSave.Text = "Update";

        lblID.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblAutoID")).Text;
        txtkey.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblCode")).Text;
        txtkey.Enabled = false;
        txtvalue.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblName")).Text;
        txtdecp.Text = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblDesc")).Text;
        chkActive.Checked = ((CheckBox)GrdDetails.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;
        if (Group == "PVM")
        {
            msoms.Visible = true;
            
        }
        else
        {
            msoms.Visible = false;
        }
        try
        {
            ddlMSOms.SelectedValue = ((Label)GrdDetails.Rows[e.NewEditIndex].FindControl("lblOS_OMS")).Text;
        }
        catch (Exception ex)
        {

         
        }
    }

    protected void GrdDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Masterofmaster _objMM = new Masterofmaster();
        _objMM.AutoId = Convert.ToInt32(((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblAutoID")).Text);
        _objMM.Value = ((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblName")).Text;
        _objMM.key = ((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblCode")).Text;
        _objMM.Group = ((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblGroup")).Text;
        _objMM.Description = ((Label)GrdDetails.Rows[e.RowIndex].FindControl("lblDesc")).Text;
        _objMM.IsActive = ((CheckBox)GrdDetails.Rows[e.RowIndex].FindControl("chkIsActive")).Checked;

        _objMM.IsActive = Convert.ToBoolean(false);
        _objMM.IsDeleted = Convert.ToBoolean(true);
        try
        {
            _objMM.Save();
            //  MessageBox("Your record is Deleted");
            BindGvDetail();
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        catch
        {

        }
    }

    protected void GrdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDetails.PageIndex = e.NewPageIndex;

        BindGvDetail();
    }

    protected void txtkey_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Masters.GetCodeValidation("MOM", txtkey.Text.Trim());
        if (Auth)
        {
            MessageBox("Code already exist");
            txtkey.Text = "";
            txtkey.Focus();
        }
        else
        {
            txtvalue.Focus();
        }
    }
}



