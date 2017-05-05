#region NameSpace

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

#endregion
public partial class UserControls_uc_ReturnBooks : System.Web.UI.UserControl
{

    #region Variables
    public static string EmpCode;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            EmpCode = Convert.ToString(Session["UserName"]);
            BindSalesman();
            Panel3.Visible = false;
            btngetRec.Visible = true;
            btnview.Visible = true;
            btnSave.Visible = false;
        }
        else
        {

        }
    }
    #endregion 

    #region Events

    #region Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool flag = false;
        int flag1 = 0;
        int flag2 = 0;

        ReturnBook _obrtbk = new ReturnBook();
        try
        {
            foreach (GridViewRow Row in GrdSpecdetails.Rows)
            {
                string RQty = ((TextBox)Row.FindControl("txtreturn")).Text.Trim();
                int qty = (Convert.ToInt32(RQty));
                string cmt = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();

                if (qty > 0)
                {
                    flag1 = flag1 + 1;
                    if (cmt != "")
                    {
                        flag2 = flag2 + 1;
                    }
                    else
                    {
                    }
                }
            }
            if (flag1 > flag2)
            {
                MessageBox("Please Enter Comment For Respective Quantity");
                Panel2.Visible = true;
            }

            if (flag1 == flag2)
            {
                foreach (GridViewRow Row in GrdSpecdetails.Rows)
                {
                    _obrtbk.ReturnBkID = 0;
                    _obrtbk.SpecimenDetailID = Convert.ToInt32(((Label)Row.FindControl("lblspdt")).Text.Trim());
                    _obrtbk.DocumentNo = Convert.ToInt32(((Label)Row.FindControl("lbldocNo")).Text.Trim());
                    _obrtbk.EmpID = Convert.ToInt32(((Label)Row.FindControl("lblempid")).Text.Trim());
                    string RQty = ((TextBox)Row.FindControl("txtreturn")).Text.Trim();
                    int rqty1 = Convert.ToInt32(RQty);
                    _obrtbk.ReturnQty = Convert.ToInt32(RQty);
                    string cmt = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();
                    _obrtbk.Comment = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();

                    if (rqty1 > 0 && cmt != "")
                    {
                        _obrtbk.Save();
                        flag = true;
                    }
                    else
                    {
                    }
                }
            }

            if (flag)
            {
                MessageBox("Record saved successfully");

                BindGvDetail();                
                Panel2.Visible = false;
            }

        }
        catch
        {

        }
    }
    #endregion

    #region View

    protected void btnview_Click(object sender, EventArgs e)
    {
        BindGvDetail1();
        btnSave.Visible = false;
        Panel3.Visible = true;
        Panel2.Visible = false;
    }
    #endregion

    protected void btngetRec_Click(object sender, EventArgs e)
    {
        BindGvDetail();

        if (GrdSpecdetails.Rows.Count > 0)
        {
            GrdSpecdetails.Focus();
            btnSave.Visible = true;
            Panel2.Visible = true;
        }
        else
        {
            GrdSpecdetails.Focus();
            btnSave.Visible = true;
            Panel2.Visible = true;
            MessageBox("Record Not Available");
        }
    }
    //#region Get
    //protected void btnget_Click(object sender, EventArgs e)
    //{
    //    BindGvDetail();
    //    btnSave.Visible = true;
    //    Panel2.Visible = true;
    //    Panel3.Visible = false;
    //}
    //#endregion

    #endregion

    #region Methods

    #region Binddata method

    public void BindGvDetail()
    {
        GrdSpecdetails.DataSource = SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "rtbk");
        GrdSpecdetails.DataBind();
    }
    public void BindGvDetail1()
    {
        GrdSpecdetails1.DataSource = SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "rtbkview");
        GrdSpecdetails1.DataBind();
    }
    #endregion

    #region Get Salesman

    public void BindSalesman()
    {
        DDLSalesman.DataSource = Employee.Get_EmployeeOnAreaWise(EmpCode);
        DDLSalesman.DataBind();
        DDLSalesman.Items.Insert(0, new ListItem("-- Select Salesman --","none"));
    }

    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    #endregion

    #endregion

   

   
}
