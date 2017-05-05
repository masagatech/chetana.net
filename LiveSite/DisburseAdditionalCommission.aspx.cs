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

public partial class DisburseAdditionalCommission : System.Web.UI.Page
{
    #region Variables
    int CID;
    string flag = "state";
    static DataView dv = null;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    Other_Z.OtherBAL ObjDAl = new Other_Z.OtherBAL();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != "" || Session["ChetanaCompanyName"] != null)
        {
            if (Session["FY"] != "" || Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
            }
            else
            {
                Session.Clear();
            }
        }
        if (!Page.IsPostBack)
        {
            DDLSuperZone.Focus();
            Bind_DDL_SuperZone();
            pnlcust.Visible = true;
            ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
            Bind_DDL_CC();

        }
        if (IsPostBack)
        {
            if (DDLSuperZone.SelectedValue.ToLower().ToString() == "0")
            {
                MessageBox("Select Items");
            }
        }
        PnlAddDAC.Visible = false;
    }



    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShowDetails();
    }
    public void ShowDetails()
    {

        DataSet ds = new DataSet();
        ds = Idv.Chetana.BAL.Customer_cs.Idv_Chetana_Rep_Customer_DisburseAdditionalCommission(
           Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()),
           Convert.ToInt32(DDLZone.SelectedValue.ToString()),
           Convert.ToInt32(ddlCustmore.SelectedValue.ToString()),
           Convert.ToInt32(DDLCC.SelectedValue.ToString()),
           Convert.ToInt32(strFY));
        DataView dv = new DataView(ds.Tables[0]);
        grdACC.DataSource = dv;
        grdACC.DataBind();
    }
    protected void DDLSuperZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLSuperZone.SelectedIndex == 0)
        {
            DDLSuperZone.Focus();
            DDLZone.Items.Clear();
            Bind_DDL_SuperZone();
        }
        else
        {
            Bind_DDL_Zone();
            DDLZone.Focus();
        }
    }

    protected void DDLZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DDLZone.SelectedIndex == 0)
            {
                DDLZone.Focus();
                ddlCustmore.Items.Clear();
                Bind_DDL_ZoneCust();
            }
            else
            {
                Bind_DDL_Customer();
                ddlCustmore.Focus();
            }

        }
        catch (Exception)
        {
            
            throw;
        }
        
    }
    public void Bind_DDL_ZoneCust()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    public void Bind_DDL_Customer()
    {
        ddlCustmore.DataSource = ObjDAl.Idv_Chetana_Get_ZoneCustomerAdditionalCommissionOtherZ(Convert.ToInt32(DDLZone.SelectedValue.ToString()));
        ddlCustmore.DataBind();
        ddlCustmore.Items.Insert(0, new ListItem("-Select Customer-", "0"));
    }
    public void Bind_DDL_Zone()
    {
        DDLZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSuperZone.SelectedValue.ToString()), "Zone");
        DDLZone.DataBind();
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }

    public void Bind_DDL_SuperZone()
    {
        DDLSuperZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SuperZone");
        DDLSuperZone.DataBind();
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));
        DDLZone.Items.Insert(0, new ListItem("-Select Zone-", "0"));
    }
    public void Bind_DDL_CC()
    {
        DDLCC.DataSource = CustCategory.GetCustomerCategoryMaster("adminCCM");
        DDLCC.DataBind();
        DDLCC.Items.Insert(0, new ListItem("-Select Customer Category-", "0"));
        DDLSuperZone.Items.Insert(0, new ListItem("-Select SuperZone-", "0"));

    }
    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            int CustId;
            string CustCode = "";
            decimal NETBILLAMT = 0;
            decimal NETCNAMT = 0;
            decimal NETAMT = 0;
            decimal NETADDDIS = 0;
            decimal GROSSBILLAMT = 0;
            decimal GROSSCNAMT = 0;
            decimal GROSSNETAMT = 0;
            decimal GROSSADDDIS = 0;
            decimal Amount = 0;
            string Details = "";
            int DACId;
            Customer_cs objDAC = new Customer_cs();

            for (int i = 0; i <= grdACC.Rows.Count - 1; i++)
            {
                System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)grdACC.Rows[i].Cells[0].Controls[1];
                if (cb.Checked == true)
                {
                    try
                    {
                        System.Web.UI.WebControls.Label WbCustCode = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[1].Controls[1];
                        CustCode = WbCustCode.Text.ToString();

                        System.Web.UI.WebControls.Label Wb1 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[11].Controls[1];
                        NETBILLAMT = Convert.ToDecimal(Wb1.Text.ToString());
                        try
                        {
                            if (NETBILLAMT > 0)
                            {
                                System.Web.UI.WebControls.Label Wb2 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[12].Controls[1];
                                NETCNAMT = Convert.ToDecimal(Wb2.Text.ToString());
                                System.Web.UI.WebControls.Label Wb3 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[13].Controls[1];
                                NETAMT = Convert.ToDecimal(Wb3.Text.ToString());
                                System.Web.UI.WebControls.Label Wb4 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[14].Controls[1];
                                NETADDDIS = Convert.ToDecimal(Wb4.Text.ToString());
                                System.Web.UI.WebControls.Label Wb5 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[15].Controls[1];
                                GROSSBILLAMT = Convert.ToDecimal(Wb5.Text.ToString());
                                System.Web.UI.WebControls.Label Wb6 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[16].Controls[1];
                                GROSSCNAMT = Convert.ToDecimal(Wb6.Text.ToString());
                                System.Web.UI.WebControls.Label Wb7 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[17].Controls[1];
                                GROSSNETAMT = Convert.ToDecimal(Wb7.Text.ToString());
                                System.Web.UI.WebControls.Label Wb8 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[18].Controls[1];
                                GROSSADDDIS = Convert.ToDecimal(Wb8.Text.ToString());
                                System.Web.UI.WebControls.Label Wb9 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[19].Controls[1];
                                System.Web.UI.WebControls.Label Wb10 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[20].Controls[1];
                                objDAC.Idv_Chetana_Rep_Customer_SaveDisburseAdditionalCommission(CustCode, NETBILLAMT, NETCNAMT, NETAMT, NETADDDIS, GROSSBILLAMT, GROSSCNAMT,
                                    GROSSNETAMT, GROSSADDDIS, Convert.ToDecimal(txtAmount.Text), txtDetails.Text.ToString(), Convert.ToInt32(strFY), Convert.ToString(Session["UserName"]), out DACId);

                                MessageBox("Record saved successfully");
                                PnlAddDAC.Visible = false;
                                ShowDetails();
                            }
                            else
                            {
                                MessageBox("Bill Amount Should not be Zero");
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox(ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox(ex.Message);
                    }



                }
            }
        }
        catch { }
    }

    protected void grdACC_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            
            int CustId;
            string CustCode = "";
            decimal NETBILLAMT = 0;
            decimal NETCNAMT = 0;
            decimal NETAMT = 0;
            decimal NETADDDIS = 0;
            decimal GROSSBILLAMT = 0;
            decimal GROSSCNAMT = 0;
            decimal GROSSNETAMT = 0;
            decimal GROSSADDDIS = 0;
            decimal Amount = 0;
            string Details = "";
            int DACId;
            Customer_cs objDAC = new Customer_cs();

            for (int i = 0; i <= grdACC.Rows.Count - 1; i++)
            {
                System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)grdACC.Rows[i].Cells[0].Controls[1];
                if (cb.Checked == true)
                {
                    try
                    {
                        System.Web.UI.WebControls.Label WbCustCode = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[1].Controls[1];
                        CustCode = WbCustCode.Text.ToString();

                        System.Web.UI.WebControls.Label Wb1 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[11].Controls[1];
                        NETBILLAMT = Convert.ToDecimal(Wb1.Text.ToString());
                        // try
                        //{
                            if (NETBILLAMT > 0)
                            {
                                PnlAddDAC.Visible = true;
                        System.Web.UI.WebControls.Label Wb2 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[12].Controls[1];
                        NETCNAMT = Convert.ToDecimal(Wb2.Text.ToString());
                        System.Web.UI.WebControls.Label Wb3 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[13].Controls[1];
                        NETAMT = Convert.ToDecimal(Wb3.Text.ToString());
                        System.Web.UI.WebControls.Label Wb4 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[14].Controls[1];
                        NETADDDIS = Convert.ToDecimal(Wb4.Text.ToString());
                        System.Web.UI.WebControls.Label Wb5 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[15].Controls[1];
                        GROSSBILLAMT = Convert.ToDecimal(Wb5.Text.ToString());
                        System.Web.UI.WebControls.Label Wb6 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[16].Controls[1];
                        GROSSCNAMT = Convert.ToDecimal(Wb6.Text.ToString());
                        System.Web.UI.WebControls.Label Wb7 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[17].Controls[1];
                        GROSSNETAMT = Convert.ToDecimal(Wb7.Text.ToString());
                        System.Web.UI.WebControls.Label Wb8 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[18].Controls[1];
                        GROSSADDDIS = Convert.ToDecimal(Wb8.Text.ToString());
                        System.Web.UI.WebControls.Label Wb9 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[19].Controls[1];
                        System.Web.UI.WebControls.Label Wb10 = (System.Web.UI.WebControls.Label)grdACC.Rows[i].Cells[20].Controls[1];
                        txtAmount.Text = ((Label)grdACC.Rows[e.NewEditIndex].FindControl("lblDACAmount")).Text;
                       // txtDetails.Text = ((Label)grdACC.Rows[e.NewEditIndex].FindControl("lblDetails")).Text;
                            }
                            else
                            {
                                MessageBox("Bill Amount Should not be Zero");
                            }
                        //}
                        // catch
                        // {
                        //     MessageBox("Bill Amount Should not be Zero");
                        // }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox(ex.Message);
                    }



                }
            }
        }
        catch { }
    }
   

}