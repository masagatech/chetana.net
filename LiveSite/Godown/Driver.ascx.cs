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

public partial class Godown_Driver : System.Web.UI.UserControl
{
    #region Variables
    string UserName = string.Empty;
    string strChetanaCompanyName = string.Empty;
    string strFY = string.Empty;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
  {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                UserName = Session["UserName"].ToString();
                if (!Page.IsPostBack)
                {
                    SetView();
                }
            }
            else
            {
                Session.Clear();
              
            }
            //Response.Write(strFY);
           
        }

    }

    #region Methods

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Add Driver ";
                lblID.Text = "0";
                txtName.Focus();
                pnlAddForm.Visible = true;
                pnlViewForm.Visible = false;
                btn_Save.Visible = true;
                fillVehicle();
                //filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Driver";
                    pnlViewForm.Visible = true;
                    pnlAddForm.Visible = false;
                    // btnAdd.Visible = true;
                    btn_Save.Visible = false;
                    BindGetDriver();
                    //filter.Visible = true;
                    //filter.Focus();
                }
        }
    }

    public void SaveDriverMaster()
    {
        string newDate = "";
        try
        {
            if (txtLicenceExpDate.Text.Trim() == "")
            {
                 newDate = DateTime.Now.ToString("MM/dd/yyyy");
            }
            else
            {
                 newDate = txtLicenceExpDate.Text.Split('/')[1] + "/" + txtLicenceExpDate.Text.Split('/')[0] + "/" + txtLicenceExpDate.Text.Split('/')[2];
            }
            G_Driver _ObjDriver = new G_Driver();
            _ObjDriver.DR_ID = Convert.ToInt32(lblID.Text);
            _ObjDriver.NAME = txtName.Text.Trim();
            _ObjDriver.ADD1 = txtAdd1.Text.Trim();
            _ObjDriver.ADD2 = txtAdd2.Text.Trim();
            _ObjDriver.ADD3 = txtAdd3.Text.ToString();
            _ObjDriver.Licence = txtLicence.Text.Trim();
            _ObjDriver.LicenceExpDate = Convert.ToDateTime(newDate);
            _ObjDriver.VEH_ID = Convert.ToInt32(ddlVehicle.SelectedValue.ToString());
            _ObjDriver.MOBILE = txtMobile.Text;
            _ObjDriver.TEL1 = txtMobile1.Text.Trim();
            _ObjDriver.CreatedBy = UserName;
            _ObjDriver.UpdatedBy = UserName;
            _ObjDriver.AREACODE = 1;
            _ObjDriver.IsActive = chkActive.Checked;
            _ObjDriver.Save();
            if (Convert.ToInt32(lblID.Text) > 0)
            {
                MessageBox("Record updated successfully");
            }
            else
            {
                MessageBox("Record saved successfully");
            }
            BindGetDriver();

            if (btn_Save.Text == "Update")
            {
                pnlViewForm.Visible = true;
                pnlAddForm.Visible = false;
                btn_Save.Visible = false;
                btn_Save.Text = "Save";
                //filter.Visible = true;
            }
            else
            {
                pnlAddForm.Visible = true;
                pnlViewForm.Visible = false;
                //DDLZone.SelectedValue = null;
            }
        }
        catch(Exception ex)
        {

        }
    }

    private void BindGetDriver()
    {
        grdDriver.DataSource = G_Driver.GetDriver("all", 0, "");
        grdDriver.DataBind();

    }


    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        SaveDriverMaster();
    }

    #region Bind Vehicle

    public void fillVehicle()
    {
        ddlVehicle.DataSource = G_Vehicle.GetVehicle("active",0,"");
        ddlVehicle.DataBind();
    }

    #endregion
    protected void grdDriver_RowEditing(object sender, GridViewEditEventArgs e)
    {

        pnlViewForm.Visible = false;
        pnlAddForm.Visible = true;
        btn_Save.Visible = true;
        btn_Save.Text = "Update";
        try
        {
            lblID.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblDrID")).Text;
            fillVehicle();
            
            txtName.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblDriverName")).Text;
            txtAdd1.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblAdd1")).Text;
            txtAdd2.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblAdd2")).Text;
            txtAdd3.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblAdd3")).Text;
            txtArea.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblAreaCode")).Text;
            txtCity.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblCityCode")).Text;

            txtMobile.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblMob")).Text;
            txtMobile1.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblMob1")).Text;
            txtLicence.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblLicence")).Text;
            chkActive.Checked = ((CheckBox)grdDriver.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
            txtLicenceExpDate.Text = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblLicExpDate")).Text;
            ddlVehicle.SelectedValue = ((Label)grdDriver.Rows[e.NewEditIndex].FindControl("lblVehId")).Text;
        }
        catch
        {
        }
    }

    protected void grdDriver_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {   
        Label lblDRiverhID = (Label)grdDriver.Rows[e.RowIndex].FindControl("lblDrID");
        Other_G obj = new Other_G();
        obj.DeleteModule(lblDRiverhID.Text.Trim(), "driver", "");
        MessageBox("Info ! \\r\\n Record Deleted!!!");
        grdDriver.Rows[e.RowIndex].Visible = false;
    }
}
