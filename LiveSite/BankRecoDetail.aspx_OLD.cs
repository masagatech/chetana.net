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

public partial class BankRecoDetail : System.Web.UI.Page
{
    #region Vaiables
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
            if (Request.QueryString["d"] != null)
            {
                DataSet ds = new DataSet();
                ds = Bank.Get_Bank_Reco(Request.QueryString["code"].ToString(), Convert.ToInt32(Request.QueryString["d"].ToString()), Convert.ToInt32(Request.QueryString["FY"].ToString()), Convert.ToDecimal(Request.QueryString["OP"]), Request.QueryString["flag"].ToString());
                gvBankreco.DataSource = ds.Tables[0];
                gvBankreco.DataBind();
            }
        }
        
        
        // Get_Bank_Reco     

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        Bank  _objbnk = new Bank();

        foreach (GridViewRow row in gvBankreco.Rows)
        {
            if (((CheckBox)row.FindControl("chkBxSelect")).Checked == true)
            {
                _objbnk.Recoid = Convert.ToInt32(((Label)row.FindControl("lbldetailid")).Text);
                _objbnk.IsReco = Convert.ToBoolean(((CheckBox)row.FindControl("chkBxSelect")).Checked); 

                 string DDate = ((TextBox)row.FindControl("txtrecodate")).Text;
                     DDate = DDate.Split('/')[2] + "/" + DDate.Split('/')[1] + "/" + DDate.Split('/')[0];

                      _objbnk.flag = Convert.ToString(((Label)row.FindControl("lblflag")).Text);
              //   _objbnk.RecoDate = DDate;
                 _objbnk.Update_BankRaconcilation();
            }
        } 
    }
   
}
