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

public partial class Godown_Vehicle : System.Web.UI.UserControl
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
                pageName.InnerHtml = "Add Vehicle ";
                lblID.Text = "0";
                txtVNo.Focus();
                pnlAddForm.Visible = true;
                pnlViewForm.Visible = false;
                btn_Save.Visible = true;
                //filter.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "View / Edit Vehicle";
                    pnlViewForm.Visible = true;
                    pnlAddForm.Visible = false;
                    // btnAdd.Visible = true;
                    btn_Save.Visible = false;
                    BindGetVehicle();
                    //filter.Visible = true;
                    //filter.Focus();
                }
        }
    }

    public void SaveVehicleMaster()
    {
        try
        {
            G_Vehicle _ObjVeh = new G_Vehicle();
            _ObjVeh.Veh_id = Convert.ToInt32(lblID.Text);
            _ObjVeh.Veh_no = txtVNo.Text.Trim();
            _ObjVeh.Veh_desc = txtVDisc.Text.Trim();
            _ObjVeh.I_M = txtIm.Text.ToString();
            _ObjVeh.veh_type = txtVehType.Text.ToString();
            _ObjVeh.CreatedBy = UserName;
            _ObjVeh.UpdatedBy = UserName;
            _ObjVeh.IsActive = chkActive.Checked;
            _ObjVeh.Save();
            MessageBox("Record saved successfully");
            BindGetVehicle();

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
                txtVNo.Text = "";
                txtVDisc.Text = "";
                //DDLZone.SelectedValue = null;
            }
        }
        catch
        {

        }
    }

    private void BindGetVehicle()
    {
        grdVehicle.DataSource = G_Vehicle.GetVehicle("all", 0, "");
        grdVehicle.DataBind();

    }


    #endregion

    #region Edit - Delete

    protected void grdVehicle_RowEditing(object sender, GridViewEditEventArgs e)
    {

        pnlViewForm.Visible = false;
        pnlAddForm.Visible = true;
        btn_Save.Visible = true;
        btn_Save.Text = "Update";
        try
        {
            lblID.Text = ((Label)grdVehicle.Rows[e.NewEditIndex].FindControl("lblVehID")).Text;
            txtVNo.Text = ((Label)grdVehicle.Rows[e.NewEditIndex].FindControl("lblVehNo")).Text;
            txtVDisc.Text = ((Label)grdVehicle.Rows[e.NewEditIndex].FindControl("lblVehDesc")).Text;
            txtVehType.Text = ((Label)grdVehicle.Rows[e.NewEditIndex].FindControl("lblVehType")).Text;
            txtIm.Text = ((Label)grdVehicle.Rows[e.NewEditIndex].FindControl("lblIM")).Text;
            chkActive.Checked = ((CheckBox)grdVehicle.Rows[e.NewEditIndex].FindControl("chkIsActive")).Checked;

        }
        catch
        {
        }
        txtVNo.Focus();
    }

    protected void grdVehicle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblVehsID = (Label)grdVehicle.Rows[e.RowIndex].FindControl("lblVehID");
        Other_G obj = new Other_G();
        obj.DeleteModule(lblVehsID.Text.Trim(), "vehicle", "");
        MessageBox("Info ! \\r\\n Record Deleted!!!");
        grdVehicle.Rows[e.RowIndex].Visible = false;
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
        SaveVehicleMaster();
    }
}