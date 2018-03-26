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
using System.IO;

public partial class UserControls_ODC_receipt_Uc_AccountMain_View : System.Web.UI.UserControl
{
    #region Variables
    int IDNo;
    int NewDocNo;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";

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
        }
        if (!IsPostBack)
        {

            lblID.Text = "0";
            //lblID1.Text = "0";

            Session["tempdata"] = null;
            btn_Save.Visible = false;
        }


    }
    protected void txtGroup_TextChanged(object sender, EventArgs e)
    {
        txtAdd1.Focus();
        //  string ECode = txtGroup.Text.ToString().Split(':', '[', ']')[0].Trim();
        ////  string flag = txtGroup.Text.ToString().Split(':', '[', ']')[3].Trim();
        //  DataTable dt = new DataTable();
        //  dt = DCMaster.Get_Name(ECode, "GR_HEAD").Tables[0];
        //  if (dt.Rows.Count != 0)
        //  {
        //      txtEMcode.Text = ECode;
        //     // if (flag == "GR_HEAD")
        //     // {
        //          lblGroup.Visible = true;
        //          lblGroup.Text = dt.Rows[0]["GR_HEAD"].ToString();


        //    //  }
        //  }
        //  else
        //  {
        //      lblshow.Text = "No such Group";
        //     txtGroup.Focus();
        //      txtGroup.Text = "";
        //  }

    }

    //protected void txtEMcode_TextChanged(object sender, EventArgs e)
    //{


    //}

    protected void txtEMcode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtEMcode.Text.ToString().Split(':', '[', ']')[0].Trim();
       // string flag = txtEMcode.Text.ToString().Split(':', '[', ']')[3].Trim();
        string Code = ECode;
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(Code, "AC").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtEMcode.Text = ECode;
            //if (flag == "AC")
            //{
                //lblshow.Visible = true;
                txtAcCode.Text = dt.Rows[0]["AC_NAME"].ToString();
               // txtGroup.Focus();
                BindAcMain();
           // }
           // else
           // {
              //  txtAcCode.Visible = true;
              //  txtAcCode.Text = dt.Rows[0]["CustName"].ToString();
                //txtGroup.Focus();
           // }
        }
        else
        {
            MessageBox("No such Party");

            txtEMcode.Focus();
            txtEMcode.Text = "";
        }
    }
    public void BindAcMain()
    {
        string AcCode = txtEMcode.Text.ToString();
        DataTable dt = new DataTable();
        dt = AccountMain.ACCodeGet(AcCode).Tables[0];
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

            txtAC_DEPR_C.Text = dt.Rows[0]["AC_DEPR_C"].ToString();
            txtAC_DEPR_N.Text =dt.Rows[0]["AC_DEPR_N"].ToString();
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
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] != null)
            {
                AccountMain ac = new AccountMain();
                ac.AutoID = Convert.ToInt32(lblID.Text);
                ac.AC_CODE =txtEMcode.Text.Trim();
                ac.AC_NAME = txtAcCode.Text.Trim();
                ac.AC_GROUP = txtGroup.Text.Trim();
                ac.AC_ADD1 = txtAdd1.Text.Trim();

                ac.AC_ADD2 = txtAdd2.Text.Trim();
                ac.AC_ADD3 = txtAdd3.Text.Trim();
                ac.TEL1 = txtpnon1.Text.Trim();
                ac.TEL2 = txtpnon2.Text.Trim();

                ac.CITY_CODE = txtCityCode.Text.Trim();
                ac.PIN_CODE = txtPincode.Text.Trim();

                ac.COUNTRY = txtCOUNTRY.Text.Trim();
                ac.ZONE_CODE = txtZoneCode.Text.Trim();
                ac.BROKER = txtbroker.Text.Trim();

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
                ac.ACTIVE =Convert.ToBoolean(true);
                ac.CreatedBy = Session["UserName"].ToString();
                ac.Save();
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

            }
        }
        catch
        {
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
    protected void txtAcCode_TextChanged(object sender, EventArgs e)
    {
        string AcCode;
        AcCode = txtAcCode.Text.Trim();
        bool Auth;
        Auth = AccountMain.ACCodeValidaton(AcCode);
        if (Auth)
        {
            MessageBox("Already Exists...");
            txtAcCode.Text = "";
            txtAcCode.Focus();
        }
        txtGroup.Focus();

    }

}
