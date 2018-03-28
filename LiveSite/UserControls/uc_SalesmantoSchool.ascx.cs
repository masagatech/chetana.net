#region Name Spaces

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

public partial class UserControls_uc_SalesmantoSchool : System.Web.UI.UserControl
{
    #region Variables
    public int sum = 0;
    public int Qty;
    public int Qty1;
    public int sum2 = 0;
    public int Totalsum = 0;
    public static string EmpCode;
    public int remainingQty = 0;
    public int TxtQty = 0;
    int CountGrd = 0;
    int Grd1Qty = 0;
    int Grdsum = 0;
    int remainingQtyGrd = 0;
    int Grd1Qty1 = 0;
    int Grdsum1 = 0;
    int remainingQtyGrd1 = 0;
    int ChkQuantity = 0;
    int ChkQuantity2 = 0;
    int ChkQuantity3 = 0;
     static int Custid = 0;
    static string CustCode;

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
           if (!Page.IsPostBack)
        {

            EmpCode = Convert.ToString(Session["UserName"]);
            BindSalesman();
            //  DDlSelectSchool.DataSource = Customer.GetSchool_Names(EmpCode);
            //   DDlSelectSchool.DataBind();
            pnlSchooldetails.Visible = false;
            BtnSaveAllotDetails.Visible = false;
            BtnSaveAllotDetails.Enabled = false;
            BtnBack.Visible = false;
            PnlDashboard.Visible = true;
            showFilter(); 
        }
          
    }

    #endregion

    #region Methods

    #region Get All Salesman

    public void BindSalesman()
    {
        DDLSalesman.DataSource = Employee.Get_EmployeeOnAreaWise(EmpCode);
        DDLSalesman.DataBind();
        DDLSalesman.Items.Insert(0, new ListItem("-- Select Salesman --"));
    }

    #endregion

    #region Bind Speciman Details

    public void BindSpeciman()
    {
        grdSchooldetails.DataSource = SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "empcode");
        grdSchooldetails.DataBind();

    }
    #endregion

    #region Bind Dashboard
    public void BindDashboardQty()
    {
        
        EmpCode = DDLSalesman.SelectedItem.Value.ToString();
        DataTable dt = new DataTable();
        dt = Specimen_AllotQty_To_Customer.Get_DashBoardAllotQty(EmpCode).Tables[0];
        lnkorder.Text = dt.Rows[0][0].ToString();
        lnkReceive.Text = dt.Rows[0][1].ToString();
        lnkAllot.Text = dt.Rows[0][2].ToString();
        lnkPending.Text = dt.Rows[0][3].ToString();
        lnkCustomerCount.Text = dt.Rows[0][4].ToString();
    }
    #endregion
    #endregion

    #region Get Records
    protected void btngetRec_Click(object sender, EventArgs e)
    {
        //   BindSpeciman();
        BindDashboardQty();
        
    }

    protected void BtnGetByDocNum_Click(object sender, EventArgs e)
    {
        grdSchooldetails.DataSource = SpecimanDetails.GetSpecimenDatilsByEmpCode(TxtDocNum.Text.ToString(), "documentno");
        grdSchooldetails.DataBind();
    }

    protected void grdSchooldetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Session["schoolAllotment"] = null;
        pnlSchooldetails.Visible = true;
        grdSchooldetails.Visible = false;
        PnlDashboard.Visible = false;
        LblOriginalQty.Text = ((Label)grdSchooldetails.Rows[e.NewEditIndex].FindControl("lblReceivedqty")).Text;
        LblBookName.Text = ((Label)grdSchooldetails.Rows[e.NewEditIndex].FindControl("lblBookname")).Text;
        lblSpDetailid.Text = ((Label)grdSchooldetails.Rows[e.NewEditIndex].FindControl("lblSpecimenDetailID")).Text;
        lblRemainingQuantity.Text = ((Label)grdSchooldetails.Rows[e.NewEditIndex].FindControl("lblremain")).Text;
        EmpCode = DDLSalesman.SelectedValue.ToString();
        //DDlSelectSchool.DataSource = Customer_cs.GetSchool_Names(EmpCode);
        //DDlSelectSchool.DataBind();
        GrdPreviousallot.DataSource = Specimen_AllotQty_To_Customer.Get_AllotedSpecimenDetailId(Convert.ToInt32(lblSpDetailid.Text));
        GrdPreviousallot.DataBind();
        pnlSchooldetails.Visible = true;

        BtnBack.Visible = true;
        Session["schoolAllotment"] = null;
        int Totalqty = Convert.ToInt32(LblOriginalQty.Text);
        ChkQuantity = Convert.ToInt32(lblRemainingQuantity.Text);
        if (ChkQuantity > 0)
        {
            txtqnty.Visible = true;
            btnadd.Visible = true;
            //DDlSelectSchool.Visible = true;
            lbl2.Visible = true;
        }
        else
        {
            txtqnty.Visible = false;
            btnadd.Visible = false;
          //  DDlSelectSchool.Visible = false;
            lbl2.Visible = false;

        }
        foreach (GridViewRow row in GrdPreviousallot.Rows)
        {
            int Quantity = Convert.ToInt32(((Label)row.FindControl("LblQuantity")).Text);
            Qty = Qty + Quantity;
        }
        sum = sum + Qty;

        demolabel.Text = Convert.ToString(sum);


        Session["schoolAllotment"] = null;
        int sum1 = Convert.ToInt32(demolabel.Text);
        remainingQty = Totalqty - sum1;
        lblRemainingQuantity.Text = Convert.ToString(remainingQty);
        if (sum1 >= Totalqty)
        {
            BtnSaveAllotDetails.Visible = false;
        }
        else
        {


        }
        filter.Visible = false;
    }

    protected void grdSchooldetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    #endregion

    #region Event
    protected void btnadd_Click(object sender, EventArgs e)
    {
        ChkQuantity3 = Convert.ToInt32(lblRemainingQuantity.Text);
        if (ChkQuantity3 > 0)
        {

            if (txtqnty.Text != "")
            {

                remainingQtyGrd = Convert.ToInt32(lblRemainingQuantity.Text);
                DataTable dt1 = new DataTable();
                dt1 = Other.GetIDByCode(txtcustomer.Text.Trim(), "customer").Tables[0];
                Custid = Convert.ToInt32(dt1.Rows[0]["CustID"]);

                Grd1Qty = Convert.ToInt32(txtqnty.Text);
                Grdsum = remainingQtyGrd - Grd1Qty;
                lblRemainingQuantity.Text = Convert.ToString(Grdsum);

                string bk = LblBookName.Text.ToString();
                DataTable dt = new DataTable();
                if (Session["schoolAllotment"] != null)
                {
                    dt = (DataTable)Session["schoolAllotment"];
                    DataView dv = new DataView(dt);

                    int i = 0;
                    foreach (DataRowView row in dv)
                    {
                        i++;
                    }

                    Session["schoolAllotment"] = fillTempSchoolData(bk);
                    dt = (DataTable)Session["schoolAllotment"];

                }

                else
                {
                    Session["schoolAllotment"] = fillTempSchoolData(bk);
                    dt = (DataTable)Session["schoolAllotment"];

                }




                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();

                BtnSaveAllotDetails.Visible = true;
                BtnSaveAllotDetails.Enabled = true;

            }
            else
            {
                MessageBox("kindly insert quantity.");
            }

        }

        else
        {
            MessageBox("You can not allot more than remaining quantity.");
        }


    }

    #endregion

    #region Fill grid data for books

    public DataTable fillTempSchoolData(string bookcode)
    {
        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();
        if (Session["schoolAllotment"] == null)
        {
            //CREATE NEW DATATABLE

            //ADD COLUMNS IN DATATABLE

            dt.Columns.Add("BookName");
            dt.Columns.Add("CustID");
            dt.Columns.Add("CustName");
            dt.Columns.Add("AllotQty");

            //ADD DATA AS PER COLUMNS
            //Books _objBooks = new Books();

        }
        else
        {

            dt = (DataTable)Session["schoolAllotment"];

        }
        //  tempGetData = Books.Get_BooksMaster(bookcode).Tables[0];


        dt.Rows.Add(LblBookName.Text.Trim(), Custid, lblCustName.Text.ToString(), txtqnty.Text.ToString());


        return dt;
    }

    #endregion

    #region Save Allotment details

    protected void BtnSaveAllotDetails_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {


            int Totalqty = Convert.ToInt32(LblOriginalQty.Text);
            foreach (GridViewRow row in GridView1.Rows)
            {
                int Quantity = Convert.ToInt32(((Label)row.FindControl("LblQuantity")).Text);
                Qty = Qty + Quantity;
            }
            sum = sum + Qty;


            foreach (GridViewRow row in GrdPreviousallot.Rows)
            {
                int Quantity = Convert.ToInt32(((Label)row.FindControl("LblQuantity")).Text);
                Qty1 = Qty1 + Quantity;
            }
            sum2 = sum2 + Qty1;

            Totalsum = sum2 + sum;

            demolabel.Text = Convert.ToString(Totalsum);
            int sum1 = Convert.ToInt32(demolabel.Text);

            if (Totalqty < sum1)
            {
                MessageBox("You can not allot this book now");
            }
            else
            {

                DataTable dt = new DataTable();
                dt = (DataTable)Session["schoolAllotment"];
                Specimen_AllotQty_To_Customer _objAD = new Specimen_AllotQty_To_Customer();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    _objAD.AllotCustID = 0;
                    _objAD.SpecimenDetailId = Convert.ToInt32(lblSpDetailid.Text);
                    _objAD.CustID = Convert.ToInt32(((Label)row.FindControl("LblSchoolId")).Text);
                    _objAD.AllotQty = Convert.ToInt32(((Label)row.FindControl("LblQuantity")).Text);
                    _objAD.CreatedBy = "Admin";
                    _objAD.IsDelete = false;
                    _objAD.Save();
                }
                MessageBox("Your books are alloted sucessfully.");
                Session["schoolAllotment"] = null;
                txtqnty.Text = "";
                GrdPreviousallot.DataSource = Specimen_AllotQty_To_Customer.Get_AllotedSpecimenDetailId(Convert.ToInt32(lblSpDetailid.Text));
                GrdPreviousallot.DataBind();
                GridView1.Visible = false;

                BtnSaveAllotDetails.Visible = false;
                BtnSaveAllotDetails.Enabled = false;
                ChkQuantity2 = Convert.ToInt32(lblRemainingQuantity.Text);
                if (ChkQuantity3 > 0)
                {
                    txtqnty.Visible = true;
                    btnadd.Visible = true;
                    DDlSelectSchool.Visible = true;
                    lbl2.Visible = true;
                }
                else
                {
                    txtqnty.Visible = false;
                    btnadd.Visible = false;
                    DDlSelectSchool.Visible = false;
                    lbl2.Visible = false;

                }

            }
        }
    }

    #endregion

    #region Delete Event
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            LblRQty1.Text = ((Label)GridView1.Rows[e.RowIndex].FindControl("LblQuantity")).Text;
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["schoolAllotment"];
            dt1.Rows[e.RowIndex].Delete();
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            remainingQtyGrd1 = Convert.ToInt32(lblRemainingQuantity.Text);


            Grd1Qty1 = Convert.ToInt32(LblRQty1.Text);


            Grdsum1 = Grd1Qty1 + remainingQtyGrd1;
            lblRemainingQuantity.Text = Convert.ToString(Grdsum1);
            txtqnty.Text = "";
            CountGrd = GridView1.Rows.Count;
            if (CountGrd != 0)
            {
                BtnSaveAllotDetails.Visible = true;
                BtnSaveAllotDetails.Enabled = true;
            }
            else
            {
                BtnSaveAllotDetails.Visible = false;
            }
        }
        catch
        {


        }
    }

    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Session["schoolAllotment"] = null;
        txtqnty.Text = "";
        BindDashboardQty();
        DataView dv = new DataView(SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "empcode").Tables[0]);
        //grdSchooldetails.DataSource = SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "empcode");
        dv.RowFilter = "RemainQty <>0 ";
        grdSchooldetails.DataSource = dv;
        grdSchooldetails.DataBind();
        PnlDashboard.Visible = true;
        BtnSaveAllotDetails.Visible = false;
        BtnSaveAllotDetails.Enabled = false;
        GridView1.DataSource = null;
        GridView1.DataBind();
        pnlSchooldetails.Visible = false;
        grdSchooldetails.Visible = true;
        BtnBack.Visible = false;
    }

    protected void txtqnty_TextChanged(object sender, EventArgs e)
    {
        TxtQty = Convert.ToInt32(txtqnty.Text);
        remainingQty = Convert.ToInt32(lblRemainingQuantity.Text);

        if (txtqnty.Text == "0")
        {
            MessageBox("0 value is not allow");
            txtqnty.Text = "";
            txtqnty.Focus();
        }

        if (TxtQty > remainingQty)
        {
            MessageBox("you can not allot more than remaining quantity");
            txtqnty.Text = "";
            txtqnty.Focus();
        }

    }

    #region Dashboard Event
    protected void lnkorder_Click(object sender, EventArgs e)
    {
        DataView dv = new DataView(SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "empcode").Tables[0]);
        //dv.RowFilter = "RemainQty <>0 ";
        grdSchooldetails.DataSource = dv;
        grdSchooldetails.DataBind();
        grdSchooldetails.Visible = true;
        // PnlDashboard.Visible = false;
        grdSchooldetails.Columns[4].Visible = true;
        grdSchooldetails.Columns[5].Visible = false;
        grdSchooldetails.Columns[6].Visible = false;
        grdSchooldetails.Columns[7].Visible = false;
        grdSchooldetails.Columns[8].Visible = false;
        showFilter();



    }
    protected void lnkAllot_Click(object sender, EventArgs e)
    {
        //alloted
        DataView dv = new DataView(SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "empcode").Tables[0]);
        dv.RowFilter = "GivedQty <> 0 ";
        grdSchooldetails.DataSource = dv;
        grdSchooldetails.DataBind();
        grdSchooldetails.Visible = true;
        //  PnlDashboard.Visible = false;
        grdSchooldetails.Columns[4].Visible = false;
        grdSchooldetails.Columns[5].Visible = true;
        grdSchooldetails.Columns[6].Visible = true;
        grdSchooldetails.Columns[7].Visible = false;
        grdSchooldetails.Columns[8].Visible = false;
        showFilter();
    }
    protected void lnkPending_Click(object sender, EventArgs e)
    {
        //pending
        DataView dv = new DataView(SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "empcode").Tables[0]);
        dv.RowFilter = "RemainQty <>0 ";
        grdSchooldetails.DataSource = dv;
        grdSchooldetails.DataBind();
        grdSchooldetails.Visible = true;
        // PnlDashboard.Visible = false;
        grdSchooldetails.Columns[4].Visible = false;
        grdSchooldetails.Columns[5].Visible = true;
        grdSchooldetails.Columns[6].Visible = false;
        grdSchooldetails.Columns[7].Visible = true;
        grdSchooldetails.Columns[8].Visible = true;
        showFilter();
    }
    protected void lnkReceive_Click(object sender, EventArgs e)
    {
        //Received
        DataView dv = new DataView(SpecimanDetails.GetSpecimenDatilsByEmpCode(DDLSalesman.SelectedItem.Value.ToString(), "empcode").Tables[0]);
        grdSchooldetails.DataSource = dv;
        grdSchooldetails.DataBind();
        grdSchooldetails.Visible = true;
        //  PnlDashboard.Visible = false;
        grdSchooldetails.Columns[4].Visible = true;
        grdSchooldetails.Columns[5].Visible = true;
        grdSchooldetails.Columns[6].Visible = false;
        grdSchooldetails.Columns[7].Visible = false;
        grdSchooldetails.Columns[8].Visible = false;
        showFilter();
    }

    protected void lnkCustomerCount_Click(object sender, EventArgs e)
    {
     
     
    }
    
    #endregion

    public void showFilter()
    {
        //if (grdSchooldetails.Rows.Count > 0)
        //{
        //    filter.Visible = true;
        //}
        //else
        //{
        //    filter.Visible = false;
        //}
       // upgrddetails.Update();
    }


    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {

         CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            btnadd.Focus();
         }



        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
            
        }
    }
}
