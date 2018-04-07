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
using System.IO;
using System.Text;
using Others;

public partial class UserControls_ODC_receipt_Uc_AccountMain_Edit : System.Web.UI.UserControl
{
    #region Variables

    string strCompany = "cppl";
    string strFY = "0";

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != null)
            {
                strCompany = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }

        if (!IsPostBack)
        {
            lblID.Text = "0";
            Session["tempdata"] = null;
            BindStateDropDown();
            BindApplicableGSTCheckBox();
        }
    }

    protected void txtGroup_TextChanged(object sender, EventArgs e)
    {
        txtAdd1.Focus();
    }

    protected void txtEMcode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtEMcode.Text.ToString().Split(':', '[', ']')[0].Trim();

        DataTable dt = new DataTable();
        dt = Common.Get_Name(ECode, "AC").Tables[0];

        if (dt.Rows.Count != 0)
        {
            txtEMcode.Text = ECode;
            txtAcCode.Text = dt.Rows[0]["AC_NAME"].ToString();
            GetAccountMain();
        }
        else
        {
            MessageBox("No such Party");

            txtEMcode.Focus();
            txtEMcode.Text = "";
        }
    }

    protected void txtAcCode_TextChanged(object sender, EventArgs e)
    {
        string AcCode = txtAcCode.Text.Trim();
        bool Auth = AccountMain.ACCodeValidaton(AcCode);

        if (Auth)
        {
            MessageBox("Already Exists...");
            txtAcCode.Text = "";
            txtAcCode.Focus();
        }

        txtGroup.Focus();
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] != null)
            {
                AccountMain ac = new AccountMain();
                ac.AutoID = Convert.ToInt32(lblID.Text);
                ac.AC_CODE = txtEMcode.Text.Trim();
                ac.AC_NAME = txtAcCode.Text.Trim();
                ac.AC_GROUP = txtGroup.Text.Trim();
                ac.AC_ADD1 = txtAdd1.Text.Trim();

                ac.AC_ADD2 = txtAdd2.Text.Trim();
                ac.AC_ADD3 = txtAdd3.Text.Trim();
                ac.TEL1 = txtpnon1.Text.Trim();
                ac.TEL2 = txtpnon2.Text.Trim();

                ac.CITY_CODE = txtCityCode.Text.Trim();
                ac.PIN_CODE = txtPin.Text.Trim();

                ac.STATE_CODE = ddlStateCode.SelectedValue.Trim();
                ac.COUNTRY = txtCOUNTRY.Text.Trim();
                ac.ZONE_CODE = txtZoneCode.Text.Trim();

                ac.GST_NO = txtGST_NO.Text.Trim();

                StringBuilder appgst = new StringBuilder(string.Empty);

                foreach (ListItem li in chkApplicableGST.Items)
                {
                    if (li.Selected)
                    {
                        appgst.Append(li.Value).Append(",");
                    }
                }

                string APPLICABLE_GST = appgst.ToString().TrimEnd(' ').TrimEnd(',');
                ac.APPLICABLE_GST = APPLICABLE_GST;

                if (txtbroker.Text.Trim() != "")
                {
                    ac.BROKER = txtbroker.Text.ToString().Split(':')[0].Trim();
                }
                else
                {
                    ac.BROKER = txtbroker.Text.ToString().Trim();
                }

                ac.MEDIUM = txtMedium.Text.Trim();

                if (txtBrokper.Text == "")
                {
                    ac.BROK_PERC = Convert.ToDecimal(0);
                }
                else
                {
                    ac.BROK_PERC = Convert.ToDecimal(txtBrokper.Text.Trim());
                }

                ac.PRIN_int = txtPrintint.Text.Trim();
                ac.BLACKLIST = txtBlackList.Text.Trim();

                ac.AC_TYPE = txtAcType.Text.Trim();
                ac.AC_ST_NO = txtAcStNo.Text.Trim();
                ac.AC_PA_NO = txtPincode.Text.Trim();
                ac.AC_CST_NO = txtAC_CST_NO.Text.Trim();

                if (txtAcIntRate.Text == "")
                {
                    ac.AC_int_RAT = Convert.ToDecimal(0);
                }
                else
                {
                    ac.AC_int_RAT = Convert.ToDecimal(txtAcIntRate.Text.Trim());
                }

                if (txtAC_TDS_LIM.Text == "")
                {
                    ac.AC_TDS_LIM = Convert.ToDecimal(0);
                }
                else
                {
                    ac.AC_TDS_LIM = Convert.ToDecimal(txtAC_TDS_LIM.Text.Trim());
                }

                if (txtAC_TDS_RAT.Text == "")
                {
                    ac.AC_TDS_RAT = Convert.ToDecimal(0);
                }
                else
                {
                    ac.AC_TDS_RAT = Convert.ToDecimal(txtAC_TDS_RAT.Text.Trim());
                }

                ac.AC_H15 = true;

                if (txtAC_DEPR_C.Text == "")
                {
                    ac.AC_DEPR_C = Convert.ToDecimal(0);
                }
                else
                {
                    ac.AC_DEPR_C = Convert.ToDecimal(txtAC_DEPR_C.Text.Trim());
                }

                if (txtAC_DEPR_N.Text == "")
                {
                    ac.AC_DEPR_N = Convert.ToDecimal(0);
                }
                else
                {
                    ac.AC_DEPR_N = Convert.ToDecimal(txtAC_DEPR_N.Text.Trim());
                }

                if (txtDISC_PREC.Text == "")
                {
                    ac.DISC_PREC = Convert.ToDecimal(0);
                }
                else
                {
                    ac.DISC_PREC = Convert.ToDecimal(txtDISC_PREC.Text.Trim());
                }

                ac.AREA = txtAREA.Text.Trim();

                if (txtSR_ORDER.Text == "")
                {
                    ac.SR_ORDER = Convert.ToInt32(0);
                }
                else
                {
                    ac.SR_ORDER = Convert.ToInt32(txtSR_ORDER.Text.Trim());
                }

                if (txtOPEN_BAL.Text == "")
                {
                    ac.OPEN_BAL = Convert.ToDecimal(0);
                }
                else
                {
                    ac.OPEN_BAL = Convert.ToDecimal(txtOPEN_BAL.Text.Trim());
                }

                if (txtPROFIT.Text == "")
                {
                    ac.PROFIT = Convert.ToDecimal(0);
                }
                else
                {
                    ac.PROFIT = Convert.ToDecimal(txtPROFIT.Text.Trim());
                }

                if (txtREMUNA.Text == "")
                {
                    ac.REMUNA = Convert.ToDecimal(0);
                }
                else
                {
                    ac.REMUNA = Convert.ToDecimal(txtREMUNA.Text.Trim());
                }

                if (txtCR_LIMIT.Text == "")
                {
                    ac.CR_LIMIT = Convert.ToDecimal(0);
                }
                else
                {
                    ac.CR_LIMIT = Convert.ToDecimal(txtCR_LIMIT.Text.Trim());
                }

                if (txtSP_DISC.Text == "")
                {
                    ac.SP_DISC = Convert.ToDecimal(0);
                }
                else
                {
                    ac.SP_DISC = Convert.ToDecimal(txtSP_DISC.Text.Trim());
                }

                ac.IN_CHARGE = txtIN_CHARGE.Text.Trim();
                ac.CTYPE_CODE = txtCTYPE_CODE.Text.Trim();
                ac.L_O = txtL_O.Text.Trim();
                ac.CF_CODE = txtCF_CODE.Text.Trim();
                ac.ACTIVE = Convert.ToBoolean(true);
                ac.CreatedBy = Session["UserName"].ToString();

                ac.SaveAccountMain();

                Session["tempdata"] = null;
                message("Record save successfully");

                txtAcCode.Text = "";
                txtEMcode.Text = "";
                txtGroup.Text = "";
                txtAdd1.Text = "";
                txtAdd2.Text = "";
                txtAdd3.Text = "";
                txtpnon1.Text = "";
                txtpnon2.Text = "";
                txtCityCode.Text = "";
                txtPincode.Text = "";
                ddlStateCode.SelectedValue = "";
                txtCOUNTRY.Text = "";
                txtZoneCode.Text = "";
                txtbroker.Text = "";
                txtMedium.Text = "";
                txtBrokper.Text = "";
                txtPrintint.Text = "";
                txtBlackList.Text = "";
                txtAcType.Text = "";
                txtAcStNo.Text = "";
                txtPincode.Text = "";
                txtAC_CST_NO.Text = "";
                txtAcIntRate.Text = "";
                txtAC_TDS_LIM.Text = "";
                txtAC_TDS_RAT.Text = "";
                txtAC_DEPR_C.Text = "";
                txtAC_DEPR_N.Text = "";
                txtDISC_PREC.Text = "";
                txtSR_ORDER.Text = "";
                txtOPEN_BAL.Text = "";
                txtPROFIT.Text = "";
                txtREMUNA.Text = "";
                txtCR_LIMIT.Text = "";
                txtSP_DISC.Text = "";
                txtIN_CHARGE.Text = "";
                txtCTYPE_CODE.Text = "";
                txtL_O.Text = "";
                txtCF_CODE.Text = "";
                txtGST_NO.Text = "";

                foreach (ListItem item in chkApplicableGST.Items)
                {
                    item.Selected = false;
                }
            }
        }
        catch
        {
        }
    }

    public void GetAccountMain()
    {
        string AcCode = txtEMcode.Text.ToString();
        DataTable dt = new DataTable();
        dt = AccountMain.GetAccountMain(AcCode).Tables[0];

        if (dt.Rows.Count != 0)
        {
            lblID.Text = Convert.ToString(dt.Rows[0]["AutoID"]);
            txtEMcode.Text = dt.Rows[0]["AC_CODE"].ToString();
            txtAcCode.Text = dt.Rows[0]["AC_NAME"].ToString();

            txtGroup.Text = Convert.ToString(dt.Rows[0]["GR_HEAD"]);
            txtAdd1.Text = dt.Rows[0]["AC_ADD1"].ToString();

            txtAdd2.Text = dt.Rows[0]["AC_ADD2"].ToString();
            txtAdd3.Text = dt.Rows[0]["AC_ADD3"].ToString();
            txtpnon1.Text = dt.Rows[0]["TEL1"].ToString();
            txtpnon2.Text = dt.Rows[0]["TEL2"].ToString();

            txtCityCode.Text = dt.Rows[0]["CITY_CODE"].ToString();
            txtPincode.Text = dt.Rows[0]["PIN_CODE"].ToString();

            ddlStateCode.SelectedValue = dt.Rows[0]["STATE_CODE"].ToString();
            txtCOUNTRY.Text = dt.Rows[0]["COUNTRY"].ToString();
            txtZoneCode.Text = dt.Rows[0]["ZONE_CODE"].ToString();
            txtbroker.Text = dt.Rows[0]["BROKER"].ToString();
            txtMedium.Text = dt.Rows[0]["MEDIUM"].ToString();
            txtBrokper.Text = dt.Rows[0]["BROK_PERC"].ToString();
            txtPrintint.Text = dt.Rows[0]["PRIN_int"].ToString();
            txtBlackList.Text = dt.Rows[0]["BLACKLIST"].ToString();
            txtAcType.Text = dt.Rows[0]["AC_TYPE"].ToString();
            txtAcStNo.Text = dt.Rows[0]["AC_ST_NO"].ToString();
            txtPincode.Text = dt.Rows[0]["AC_PA_NO"].ToString();
            txtAC_CST_NO.Text = dt.Rows[0]["AC_CST_NO"].ToString();
            txtAcIntRate.Text = dt.Rows[0]["AC_int_RAT"].ToString();
            txtAC_TDS_LIM.Text = dt.Rows[0]["AC_TDS_LIM"].ToString();
            txtAC_TDS_RAT.Text = dt.Rows[0]["AC_TDS_RAT"].ToString();

            txtGST_NO.Text = dt.Rows[0]["GST_NO"].ToString();

            DataTable dtable = new DataTable();
            dtable.Columns.Add("Key", typeof(string));

            string appgst = dt.Rows[0]["APPLICABLE_GST"].ToString();

            string[] keys = appgst.Split(',');

            for (int i = 0; i < keys.Length; i++)
            {
                dtable.Rows.Add(new object[] { keys[i] });
            }

            foreach (ListItem agstrow in chkApplicableGST.Items)
            {
                agstrow.Selected = false;
            }

            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                string dkey = dtable.Rows[i]["Key"].ToString();

                foreach (ListItem gstrow in chkApplicableGST.Items)
                {
                    if (gstrow.Value == dkey)
                    {
                        gstrow.Selected = true;
                    }
                }
            }

            txtAC_DEPR_C.Text = dt.Rows[0]["AC_DEPR_C"].ToString();
            txtAC_DEPR_N.Text = dt.Rows[0]["AC_DEPR_N"].ToString();
            txtDISC_PREC.Text = dt.Rows[0]["DISC_PREC"].ToString();
            txtSR_ORDER.Text = dt.Rows[0]["SR_ORDER"].ToString();
            txtOPEN_BAL.Text = dt.Rows[0]["OPEN_BAL"].ToString();
            txtPROFIT.Text = dt.Rows[0]["PROFIT"].ToString();
            txtREMUNA.Text = dt.Rows[0]["REMUNA"].ToString();
            txtCR_LIMIT.Text = dt.Rows[0]["CR_LIMIT"].ToString();
            txtSP_DISC.Text = dt.Rows[0]["SP_DISC"].ToString();
            txtIN_CHARGE.Text = dt.Rows[0]["IN_CHARGE"].ToString();

            txtCTYPE_CODE.Text = dt.Rows[0]["CTYPE_CODE"].ToString();
            txtL_O.Text = dt.Rows[0]["L_O"].ToString();
            txtCF_CODE.Text = dt.Rows[0]["CF_CODE"].ToString();
        }
        else
        {
            MessageBox("No Records Found");
        }
    }

    #region "User-Defined Function"

    public void BindStateDropDown()
    {
        ddlStateCode.DataSource = Common.GetDropDownFields("State", "");
        ddlStateCode.DataBind();

        ddlStateCode.Items.Insert(0, new ListItem("-- Select State --", ""));
    }

    public void BindApplicableGSTCheckBox()
    {
        chkApplicableGST.DataSource = Common.GetDropDownFields("GST_PER", "");
        chkApplicableGST.DataBind();
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

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    #endregion
}
