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
//using Others;

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
                Decimal OP = Convert.ToDecimal(Request.QueryString["OP"].ToString());

                DataSet ds = new DataSet();
                ds = Bank.Get_Bank_Reco(Request.QueryString["code"].ToString(), 
                    Convert.ToInt32(Request.QueryString["d"].ToString()), 
                    Convert.ToInt32(Request.QueryString["FY"].ToString()),
                    OP, 
                    Request.QueryString["flag"].ToString());
                gvBankreco.DataSource = ds.Tables[0];
                gvBankreco.DataBind();
                //ds = Others.OtherClass.Get_Bank_Ballance(Request.QueryString["code"].ToString(), Convert.ToInt32(Request.QueryString["d"].ToString()), Convert.ToInt32(Request.QueryString["FY"].ToString()), Convert.ToDecimal(Request.QueryString["OP"]), Request.QueryString["flag"].ToString());
                if (Request.QueryString["flag"].ToString() != "yes")
                {

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataTable tbl = ds.Tables[1];
                        DataRow dr = tbl.Rows[0];

                        Decimal debit = Convert.ToDecimal(dr[0].ToString());
                        Decimal credit = Convert.ToDecimal(dr[1].ToString());

                        lblCoBalance.Text = "Rs. " + Request.QueryString["OP"].ToString();
                        lbldebit.Text = "Rs. " + debit;
                        lblcredit.Text = "Rs. " + credit;

                        //lblBankBalance.Text = "Rs. " + (Math.Abs(OP) - credit + debit).ToString();
                        lblBankBalance.Text = "Rs. " + ( (OP + credit) - debit).ToString();

                    }
                    else
                    {
                        lblCoBalance.Text = "Not Applicable";
                    }
                }
                else
                {
                    //ToDo: need to get data for reconsiled Data
                }

                

            }
        }


        // Get_Bank_Reco     

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        Bank _objbnk = new Bank();
        string strMinValue = "1/1/2099";



        foreach (GridViewRow row in gvBankreco.Rows)
        {

            if (((CheckBox)row.FindControl("chkBxSelect")).Checked == true)
            {
                /////To check RDate should not more than 3 months
                string CDate, RDate;
                DateTime RecoDate;
                DateTime ChkDate;
                int flag1 = 0;
                RDate = ((TextBox)row.FindControl("txtrecodate")).Text;
                CDate = ((Label)row.FindControl("lbldDate")).Text;

                ChkDate = Convert.ToDateTime(CDate);

                if (RDate == "")
                {
                    RecoDate = Convert.ToDateTime(strMinValue);
                    flag1 = 1;
                }
                else
                {
                    RDate = RDate.Split('/')[1] + "/" + RDate.Split('/')[0] + "/" + RDate.Split('/')[2];
                    RecoDate = Convert.ToDateTime(RDate);
                }

                if (flag1 == 0)
                {

                    if (ChkDate > RecoDate)
                    {
                        MessageBox("Reconsile date should be greater than deposit date...");
                    }
                    else
                    {
                        int compMonth = (RecoDate.Month + RecoDate.Year * 12) - (ChkDate.Month + ChkDate.Year * 12);
                        double daysInEndMonth = (RecoDate - RecoDate.AddMonths(1)).Days;
                        double months = compMonth + (ChkDate.Day - RecoDate.Day) / daysInEndMonth;
                        if (months > 3)
                        {
                            MessageBox("Recosile date should be within 3 months from CheckDate");
                        }
                        else
                        {
                            _objbnk.Recoid = Convert.ToInt32(((Label)row.FindControl("lbldetailid")).Text);
                            _objbnk.IsReco = Convert.ToBoolean(((CheckBox)row.FindControl("chkBxSelect")).Checked);

                            // string DDate = ((TextBox)row.FindControl("txtrecodate")).Text;
                            //if (RDate  == "")
                            //{
                            //    _objbnk.RecoDate = Convert.ToDateTime(strMinValue);
                            //    //_objbnk.BankDescription = "-1";
                            //}
                            //else
                            //{
                            //    //DDate = DDate.Split('/')[1] + "/" + DDate.Split('/')[0] + "/" + DDate.Split('/')[2];
                            //    _objbnk.RecoDate = Convert.ToDateTime(RDate);
                            //}
                            _objbnk.RecoDate = RecoDate;
                            _objbnk.flag = ((Label)row.FindControl("lblflag")).Text.ToString().Trim();
                            _objbnk.Update_BankRaconcilation();
                            MessageBox("Record saved Successfully");
                            BindGrid();
                        }

                    }
                }
                else
                {
                     
                            _objbnk.Recoid = Convert.ToInt32(((Label)row.FindControl("lbldetailid")).Text);
                            _objbnk.IsReco = Convert.ToBoolean(((CheckBox)row.FindControl("chkBxSelect")).Checked);
                            _objbnk.RecoDate = RecoDate;
                            _objbnk.flag = ((Label)row.FindControl("lblflag")).Text.ToString().Trim();
                            _objbnk.Update_BankRaconcilation();
                            MessageBox("Record saved Successfully");
                            BindGrid();
                       
                }
            }
        }
    }

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }

    public void BindGrid()
    {
        DataSet ds = new DataSet();
        ds = Bank.Get_Bank_Reco(Request.QueryString["code"].ToString(), Convert.ToInt32(Request.QueryString["d"].ToString()), Convert.ToInt32(Request.QueryString["FY"].ToString()), Convert.ToDecimal(Request.QueryString["OP"]), Request.QueryString["flag"].ToString());
        gvBankreco.DataSource = ds.Tables[0];
        gvBankreco.DataBind();
    }


    protected void gvBankreco_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
           {
               Label drv = (Label)e.Row.FindControl("lblcolbit");
               if (drv.Text.ToString().Equals("1"))
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
           }
    }
}
