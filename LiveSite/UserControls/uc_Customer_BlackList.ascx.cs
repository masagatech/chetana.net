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

public partial class UserControls_uc_Customer_BlackList : System.Web.UI.UserControl
{
    #region Variable

    int IsShowData = 0;/*IsShowData data for setting 0=first show data then allow to back list AND 1=Direct blacklist all records then show*/

    public int ViewAdd = 0;/*ViewAdd data for setting 0=Allow to black list AND 1=Show last saved history*/

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            btnSetBlackList.Visible = false;
        //if (IsShowData = 1)
        //    btnGetData.Text = "Blacklist";

    }

    #region Get BlackList

    public DataSet getBlackListedCustomer(int showdata, int view)
    {
        DataSet ds = new DataSet();
        if (txtRs.Text == "")
            txtRs.Text = "0";
        try
        {
            string date="";
            if (view != 1)
            {
                date = txttoDate.Text.Split('/')[1] + "/" + txttoDate.Text.Split('/')[0] + "/" + txttoDate.Text.Split('/')[2];
            }
            ds = Customer_cs.Idv_Chetana_Customer_BlackList(view, "", date, Convert.ToDecimal(txtRs.Text.Trim()), 1, IsShowData, 0);
            lblTotalOS.Text = "Total Outstanding : " + ds.Tables[1].Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
            return ds = null;
        }
        return ds;
    }

    #endregion


    protected void btnGetData_Click(object sender, EventArgs e)
    {

        gvBlackListCustomer.DataSource = getBlackListedCustomer(0, 0);
        gvBlackListCustomer.DataBind();
        lblCustomerCount.Text = "Total " + gvBlackListCustomer.Rows.Count.ToString() + " Customer Found";
        if (gvBlackListCustomer.Rows.Count > 0)
            btnSetBlackList.Visible = true;
        else
            btnSetBlackList.Visible = false;

    }
    protected void btnGetData1_Click(object sender, EventArgs e)
    {

        gvBlackListCustomer.DataSource = getBlackListedCustomer(1, 0);
        gvBlackListCustomer.DataBind();
        lblCustomerCount.Text = "Total " + gvBlackListCustomer.Rows.Count.ToString() + " Customer Found";
        btnSetBlackList.Visible = false;
    }

    protected void btnGetHistoryData_Click(object sender, EventArgs e)
    {

        gvBlackListCustomer.DataSource = getBlackListedCustomer(1, 1);
        gvBlackListCustomer.DataBind();
        lblCustomerCount.Text = "Total " + gvBlackListCustomer.Rows.Count.ToString() + " Customer Found";
        btnSetBlackList.Visible = false;
    }
}
