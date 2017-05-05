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
using Other_Z;

public partial class KycForm_View : System.Web.UI.Page
{

    #region Goloval Veriable
    string strFY;
    Other_Z.OtherBAL ObjBal = new OtherBAL();
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FY"] != null)
        {
            if (!Page.IsPostBack)
            {
                strFY = Session["FY"].ToString();
                txtFrom.Focus();

                string grp = "Transport";
                txtTransport.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
                txtTransport.DataBind();
                txtTransport.Items.Insert(0, new ListItem("-Select Transporter-", "0"));
            }
        }
        else
        {
            Session.Clear();
        }
    }
    #endregion

    #region Message Method
    private void Message(string Msg)
    {
        string Javascrip = "alert('" + Msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", Javascrip, true);
    }
    #endregion

    #region Get Button Click Event
    protected void btnGet_Click(object sender, EventArgs e)
    {
      DataSet ds = ObjBal.Idv_Chetana_Get_KycForm(Convert.ToInt32("0"), Convert.ToInt32(Session["FY"]), Convert.ToInt32(txtFrom.Text),
            Convert.ToInt32(txtTo.Text), "kycview", "", "", "");
      DataTable dt = ds.Tables[0];
      if (dt.Rows.Count > 0)
      {
          GridKycView.DataSource = dt;
          GridKycView.DataBind();
      }
      else
      {
          Message("Record Not Found");
          txtCustCode.Focus();
          return;
      }
      

    }
    #endregion

    #region Lick Button Click Event
    protected void btnView_Click(object sender, EventArgs e)
    {

        LinkButton btn = ((LinkButton)sender);
        lblKycId.Text = ((Label)btn.Parent.FindControl("lblKycNo")).Text.ToString();
        txtKycDate.Text = ((Label)btn.Parent.FindControl("lblKycDate")).Text.ToString();
        txtCustCode.Text = ((Label)btn.Parent.FindControl("lblCustCode")).Text.ToString();
        txtCustName.Text = ((Label)btn.Parent.FindControl("lblCustName")).Text.ToString();
        txtCustAdd.Text = ((Label)btn.Parent.FindControl("lblCustAddress")).Text.ToString();
        txtArea.Text = ((Label)btn.Parent.FindControl("lblArea")).Text.ToString();
        txtCity.Text = ((Label)btn.Parent.FindControl("lblCity")).Text.ToString();
        txtZipCode.Text = ((Label)btn.Parent.FindControl("lblZipCode")).Text.ToString();
        txtZoneCode.Text = ((Label)btn.Parent.FindControl("lblzodeCode")).Text.ToString();
        txtTelephone.Text = ((Label)btn.Parent.FindControl("lblTelNo")).Text.ToString();
        txtMobile.Text = ((Label)btn.Parent.FindControl("lblMobile")).Text.ToString();
        txtDelAdd.Text = ((Label)btn.Parent.FindControl("lblDelAddress")).Text.ToString();
        txtTransport.SelectedValue = Convert.ToInt32(((Label)btn.Parent.FindControl("lblTrasport")).Text).ToString();
        txtDisYear.Text = Convert.ToSingle(((Label)btn.Parent.FindControl("lblDis")).Text).ToString();
        txtTitlesYear.Text = Convert.ToInt32(((Label)btn.Parent.FindControl("lblTitle")).Text).ToString();

        lblprvyeardisc.Text = Convert.ToSingle(((Label)btn.Parent.FindControl("lblPrevDis")).Text).ToString();
        lblpreyeartitles.Text = Convert.ToInt32(((Label)btn.Parent.FindControl("lblPrevtitle")).Text).ToString();

        rbtnChr.Checked = ((Label)btn.Parent.FindControl("lblIfBkseller")).Text.ToString() == "CH RECD" ? rbtnChr.Checked = true : rbtnChr.Checked = false;
        rbtnSch.Checked = ((Label)btn.Parent.FindControl("lblIfBkseller")).Text.ToString() == "SCH" ? rbtnSch.Checked = true : rbtnSch.Checked = false;
        rbtnWcp.Checked = ((Label)btn.Parent.FindControl("lblIfBkseller")).Text.ToString() == "WCP" ? rbtnWcp.Checked = true : rbtnWcp.Checked = false;


        ChkScheme.Checked = Convert.ToBoolean(((Label)btn.Parent.FindControl("lblSchTr")).Text);
        ChkAddComminsion.Checked = Convert.ToBoolean(((Label)btn.Parent.FindControl("lblAddComm")).Text);
        ChkDisForm.Checked = Convert.ToBoolean(((Label)btn.Parent.FindControl("lblDisForm")).Text);

        lblOS.Text = ((Label)btn.Parent.FindControl("lblOS")).Text.ToString();
        lblAvg.Text = ((Label)btn.Parent.FindControl("lblAvg")).Text.ToString();
        txtRemrk.Text = ((Label)btn.Parent.FindControl("lblRemark")).Text.ToString();
        ModalPopUpDocNum.Show();
        updetails.Update();
    }

    #endregion


}
