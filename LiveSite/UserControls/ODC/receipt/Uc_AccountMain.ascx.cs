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

public partial class UserControls_ODC_receipt_Uc_AccountMain : System.Web.UI.UserControl
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
//        AccountMain.aspx  == Account Entry
//AccountMain_Edit.aspx == Account  Edit


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

    //    string ECode = txtEMcode.Text.ToString().Split(':', '[', ']')[0].Trim();
    //    string flag = txtEMcode.Text.ToString().Split(':', '[', ']')[3].Trim();
    //    DataTable dt = new DataTable();
    //    dt = DCMaster.Get_Name(ECode, flag).Tables[0];
    //    if (dt.Rows.Count != 0)
    //    {
    //        txtEMcode.Text = ECode;
    //        if (flag == "AC")
    //        {
    //            lblshow.Visible = true;
    //            lblshow.Text = dt.Rows[0]["AC_NAME"].ToString();
    //            txtGroup.Focus();

    //        }
    //        else
    //        {
    //            lblshow.Visible = true;
    //            lblshow.Text = dt.Rows[0]["CustName"].ToString();
    //            txtGroup.Focus();
    //        }
    //    }
    //    else
    //    {
    //        lblshow.Text = "No such Party";
    //        txtEMcode.Focus();
    //        txtEMcode.Text = "";
    //    }
    //}
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] != null)
            {
                AccountMain ac = new AccountMain();
                ac.AutoID = Convert.ToInt32(lblID.Text);
                ac.AC_CODE =txtAcCode.Text.Trim();
                ac.AC_NAME = txtEMcode.Text.Trim();
                ac.AC_GROUP =txtGroup.Text.Trim();
                ac.AC_ADD1 = txtAdd1.Text.Trim();

                ac.AC_ADD2 = txtAdd2.Text.Trim();
                ac.AC_ADD3 = txtAdd3.Text.Trim();
                ac.TEL1 = txtpnon1.Text.Trim();
                ac.TEL2 = txtpnon2.Text.Trim();

                ac.CITY_CODE = txtCityCode.Text.Trim();
                ac.PIN_CODE = txtPin.Text.Trim();

                ac.COUNTRY = txtCOUNTRY.Text.Trim();
                ac.ZONE_CODE = txtZoneCode.Text.Trim();
                if (txtbroker.Text.Trim() != "")
                {
                    ac.BROKER = txtbroker.Text.ToString().Split(':')[0].Trim();
                }
                else { ac.BROKER = txtbroker.Text.ToString().Trim(); }
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
                txtAREA.Text = "";
               
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
