
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

public partial class UserControls_uc_CustomerTransport_Mapping : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          //  grdTransportDetails.DataSource = BindgrdTransportDetails();
          // grdTransportDetails.DataBind();
            BindDDlTransport();
            txtcustomer.Focus();
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            CustomerToTransport _objCST = new CustomerToTransport();
            _objCST.CustTransportID = 0;
            _objCST.CustCode = txtcustomer.Text.Trim();
            _objCST.TransportID = Convert.ToInt32(DDlTransport.SelectedItem.Value.ToString());
            _objCST.IsActive = true;
            _objCST.Save();
            MessageBox("Record saved successfully");
            txtcustomer.Text = "";
            DDlTransport.SelectedValue = null;
            lblCustName.Text = "";
        }
        catch
        {
        }
    }

    public void BindDDlTransport()
    {
        string grp = "Transport";
        DDlTransport.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
        DDlTransport.DataBind();
        DDlTransport.Items.Insert(0, new ListItem("-Select Transporter-", "none"));
    }
    public DataTable BindgrdTransportDetails()
    {
        DataTable dt = CustomerToTransport.GetCustomerandTransporter1();
        return dt;
    }
    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }
    #endregion

    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();

      //  txtcustomer.Text = CustCode;
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            DDlTransport.Focus();

            DataSet ds = new DataSet();
            ds = Idv.Chetana.BAL.CustomerToTransport.Get_CustomerandTransporterValueAD(CustCode);
            if (ds.Tables[0].Rows.Count != 0)
            {
                pnlGet_TransDetails.Visible = true;
                grdget.DataSource = ds.Tables[0];
                grdget.DataBind();
                grdget.Visible = true;
            }
            else
            {
                grdget.Visible = false;
              //  MessageBox("No Such Record Found");
            }
        }

        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
        }
    }
}
