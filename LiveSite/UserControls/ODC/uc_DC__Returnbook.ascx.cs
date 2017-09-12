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
using Idv.Chetana.Common;

#endregion
public partial class UserControls_ODC_uc_DC__Returnbook : System.Web.UI.UserControl
{
    #region Variables

    string CustCode;
    int CNNo = 0;
    int quantity = 0;
    decimal tamount = 0;
    decimal tnamount = 0;
    //int GCN;
    // int SCN;
    string cndate;
    DateTime cndt;

    string strChetanaCompanyName = "cppl";
    string strFY;
    string flag1;
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();

        
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
       

        if (!Page.IsPostBack)
        {
            BindDDLstd();
            Txtgcn.Focus();
            // Panel3.Visible = false;
            //Panelview.Visible = false;
            // Pnlcustdet.Visible = false;
            Panel2.Visible = false;
            // btngetRec.Visible = true;
            btnSave.Visible = true;
            btnPrint.Visible = false;
            PnlPrint.Visible = false;
            Session["tempDCData1"] = null;
            txtCNDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
           
        }
        //else
        //{
        //}
        
    }
    #endregion

    #region Save And GST Save

    #region Save GST 

    protected void btnGSTSave_Click(object sender, EventArgs e)
    {
        btnSave.Enabled = false;
        cndate = txtCNDate.Text.Split('/')[2] + "/" + txtCNDate.Text.Split('/')[1] + "/" + txtCNDate.Text.Split('/')[0];
        cndt = Convert.ToDateTime(cndate);

        bool flag = false;
        int flag1 = 0;
        int flag2 = 0;
        CNNo = 0;
        int GCN;
        int SCN;
        if (Txtgcn.Text.Trim() == "")
        {
            Txtgcn.Text = "0";
        }
        if (Txtscn.Text.Trim() == "")
        {
            Txtscn.Text = "0";
        }

        GCN = Convert.ToInt32(Txtgcn.Text.Trim());
        SCN = Convert.ToInt32(Txtscn.Text.Trim());
        if (Session["UserName"] != null)
        {
            //DCReturnBook _obdcrtbk = new DCReturnBook();
            Other_Z.OtherReturn_Book.ReturnBook_Prop _obdcrtbk = new Other_Z.OtherReturn_Book.ReturnBook_Prop();
            Other_Z.OtherReturn_Book ObjBal = new Other_Z.OtherReturn_Book();
            //CreditNote _obcn = new CreditNote();
            Other_Z.OtherReturn_Book.DCCNProp _obcn = new Other_Z.OtherReturn_Book.DCCNProp();

            LedgerCN _oblcn = new LedgerCN();
            try
            {
                foreach (GridViewRow Row in Grd2.Rows)
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

                if (flag1 == 0)
                {
                    MessageBox("Please Enter Return Quantity");
                    Panel2.Visible = true;
                    btnSave.Enabled = true;
                }
                if (flag1 > flag2)
                {
                    MessageBox("Please Enter Comment For Respective Quantity");
                    Panel2.Visible = true;
                    btnSave.Enabled = true;
                }

                if (flag1 == flag2)
                {
                    CNNo = Convert.ToInt32(CreditNote.GetCNNo(Convert.ToInt32(strFY)));
                    lblCNNo.Text = CreditNote.GetCNNo(Convert.ToInt32(strFY));
                    foreach (GridViewRow Row in Grd2.Rows)
                    {
                        _obdcrtbk.DCReturnBkID = 0;
                        _obdcrtbk.CustCode = CustCode;
                        _obdcrtbk.BookCode = (((Label)Row.FindControl("lblbkcode")).Text.Trim());
                        string RQty = ((TextBox)Row.FindControl("txtreturn")).Text.Trim();
                        int rqty1 = Convert.ToInt32(RQty);
                        _obdcrtbk.ReturnQty = Convert.ToInt32(RQty);
                        string cmt = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();
                        _obdcrtbk.Comment = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();
                        _obdcrtbk.HSNCode = (((Label)Row.FindControl("lblHSNCode")).Text.Trim());
                        _obdcrtbk.GSTAmount = Convert.ToDecimal(((Label)Row.FindControl("lblGST")).Text.Trim());
                        _obdcrtbk.GSTPer = Convert.ToDecimal(((Label)Row.FindControl("lblGstPer")).Text.Trim());

                        _obdcrtbk.CreatedBy = Session["UserName"].ToString();
                        _obdcrtbk.Flag = "DC";
                        string dqty = ((TextBox)Row.FindControl("txtDefect")).Text.Trim();
                        // _obdcrtbk.DefectQty = Convert.ToInt32(dqty);
                        _obdcrtbk.DefectQty = 0;
                        _obdcrtbk.strFY = Convert.ToInt32(strFY);

                        if (RdbtnYN.SelectedValue == "1")
                        {
                            _obcn.AutoID = 0;
                            _obcn.CNNo = CNNo;
                            _obcn.CustCode = CustCode;
                            _obcn.BookCode = (((Label)Row.FindControl("lblbkcode")).Text.Trim());
                            _obcn.Rate = Convert.ToDecimal(((DropDownList)Row.FindControl("DDLR")).SelectedValue);
                            _obcn.Discount = Convert.ToDecimal(((DropDownList)Row.FindControl("DDLD")).SelectedValue);

                            string CNqty = ((TextBox)Row.FindControl("txtCN")).Text.Trim();
                            _obcn.ReturnQty = Convert.ToInt32(CNqty);
                            _obcn.DefectQty = 0;
                            _obcn.TotReturnQty = Convert.ToInt32(RQty);
                            _obcn.Comment = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();
                            _obcn.HSNCode = (((Label)Row.FindControl("lblHSNCode")).Text.Trim());
                            _obcn.GSTAmount = Convert.ToDecimal(((Label)Row.FindControl("lblGST")).Text.Trim());
                            _obcn.GSTPer = Convert.ToDecimal(((Label)Row.FindControl("lblGstPer")).Text.Trim());
                            _obdcrtbk.Typ = "G";
                            _obcn.IsActive = true;
                            _obcn.GCN = GCN;
                            _obcn.SCN = SCN;
                            _obcn.CreatedBy = Session["UserName"].ToString();
                            _obcn.Flag = "DC";
                            _obcn.strFY = Convert.ToInt32(strFY);
                            _obcn.CNDate = cndt;

                            _obcn.TransportName = lbltransporter.Text.ToString();
                            _obcn.LrNo = txtlrno.Text.ToString();
                            _obcn.Remark1 = "";
                            _obcn.Remark2 = "";
                            _obcn.Remark3 = "";
                            _obcn.Remark4 = "";
                            _obcn.Remark5 = "";
                        }
                        else
                        {
                        }

                        if (rqty1 > 0 && cmt != "")
                        {
                            //_obdcrtbk.Save_DC_ReturnBook(Convert.ToInt32(strFY));
                            ObjBal.Save_ReturnBook(_obdcrtbk);

                            if (RdbtnYN.SelectedValue == "1")
                            {
                                _oblcn.CNNo = CNNo;
                                _oblcn.strFY = Convert.ToInt32(strFY);
                                _oblcn.CNDate = cndt;
                                //_obcn.Save_CN(Convert.ToInt32(strFY));
                                ObjBal.SaveDCCN(_obcn);
                            }
                            else { }
                            flag = true;

                            //bind grid to display printdata 
                            Bindgrdcn();
                        }
                        else
                        {
                        }
                    }
                }

                if (flag)
                {
                    try
                    {
                        if (RdbtnYN.SelectedValue == "1")
                        {
                            _oblcn.Ledger_CN();
                            MessageBox(Constants.save + "\\r\\n CreditNote No: " + CNNo);
                            //BindGrd2();
                            PnlPrint.Visible = true;
                            btnPrint.Visible = true;
                            btnaddBooks.Visible = false;
                            txtcustomer.Enabled = true;
                            btnSave.Enabled = true;
                        }
                        else
                            if (RdbtnYN.SelectedValue == "0")
                        {
                            MessageBox(Constants.save);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox("Error : " + ex.Message.ToString());
                        clearall();
                        Txtgcn.Focus();
                    }
                    Panel2.Visible = false;
                    // RdbtnYN.SelectedIndex = 0;
                    // txtcustomer.Text = "";
                    //lblCustName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox("Error : " + ex.Message.ToString());
                btnSave.Enabled = true;

            }
        }
    }

    #endregion


    #region Normal Save

    protected void btnSave_Click(object sender, EventArgs e)
    {
       btnSave.Enabled = false;
        cndate = txtCNDate.Text.Split('/')[2] + "/" + txtCNDate.Text.Split('/')[1] + "/" + txtCNDate.Text.Split('/')[0];
        cndt = Convert.ToDateTime(cndate);

        bool flag = false;
        int flag1 = 0;
        int flag2 = 0;
        CNNo = 0;
        int GCN;
        int SCN;
        if (Txtgcn.Text.Trim() == "")
        {
            Txtgcn.Text = "0";
        }
        if (Txtscn.Text.Trim() == "")
        {
            Txtscn.Text = "0";
        }

        GCN = Convert.ToInt32(Txtgcn.Text.Trim());
        SCN = Convert.ToInt32(Txtscn.Text.Trim());
        if (Session["UserName"] != null)
        {
            //DCReturnBook _obdcrtbk = new DCReturnBook();
            Other_Z.OtherReturn_Book.ReturnBook_Prop _obdcrtbk = new Other_Z.OtherReturn_Book.ReturnBook_Prop();
            Other_Z.OtherReturn_Book ObjBal = new Other_Z.OtherReturn_Book();
            //CreditNote _obcn = new CreditNote();
            Other_Z.OtherReturn_Book.DCCNProp _obcn = new Other_Z.OtherReturn_Book.DCCNProp();

            LedgerCN _oblcn = new LedgerCN();
            try
            {
                foreach (GridViewRow Row in Grd2.Rows)
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

                if (flag1 == 0)
                {
                    MessageBox("Please Enter Return Quantity");
                    Panel2.Visible = true;
                    btnSave.Enabled = true;
                }
                if (flag1 > flag2)
                {
                    MessageBox("Please Enter Comment For Respective Quantity");
                    Panel2.Visible = true;
                    btnSave.Enabled = true;
                }

                if (flag1 == flag2)
                {
                    CNNo = Convert.ToInt32(CreditNote.GetCNNo(Convert.ToInt32(strFY)));
                    lblCNNo.Text = CreditNote.GetCNNo(Convert.ToInt32(strFY));
                    foreach (GridViewRow Row in Grd2.Rows)
                    {
                        _obdcrtbk.DCReturnBkID = 0;
                        _obdcrtbk.CustCode = CustCode;
                        _obdcrtbk.BookCode = (((Label)Row.FindControl("lblbkcode")).Text.Trim());
                        string RQty = ((TextBox)Row.FindControl("txtreturn")).Text.Trim();
                        int rqty1 = Convert.ToInt32(RQty);
                        _obdcrtbk.ReturnQty = Convert.ToInt32(RQty);
                        string cmt = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();
                        _obdcrtbk.Comment = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();
                        _obdcrtbk.HSNCode = "-"; //(((Label)Row.FindControl("lblHSNCode")).Text.Trim());
                        _obdcrtbk.GSTAmount = 0 ; //Convert.ToDecimal(((Label)Row.FindControl("lblGST")).Text.Trim());
                        _obdcrtbk.GSTPer = 0; //Convert.ToDecimal(((Label)Row.FindControl("lblGstPer")).Text.Trim());
                        _obdcrtbk.Typ = "N";


                        _obdcrtbk.CreatedBy = Session["UserName"].ToString();
                        _obdcrtbk.Flag = "DC";
                        string dqty = ((TextBox)Row.FindControl("txtDefect")).Text.Trim();
                        // _obdcrtbk.DefectQty = Convert.ToInt32(dqty);
                        _obdcrtbk.DefectQty = 0;
                        _obdcrtbk.strFY = Convert.ToInt32(strFY);

                        if (RdbtnYN.SelectedValue == "1")
                        {
                            _obcn.AutoID = 0;
                            _obcn.CNNo = CNNo;
                            _obcn.CustCode = CustCode;
                            _obcn.BookCode = (((Label)Row.FindControl("lblbkcode")).Text.Trim());
                            _obcn.Rate = Convert.ToDecimal(((DropDownList)Row.FindControl("DDLR")).SelectedValue);
                            _obcn.Discount = Convert.ToDecimal(((DropDownList)Row.FindControl("DDLD")).SelectedValue);
                            
                            string CNqty = ((TextBox)Row.FindControl("txtCN")).Text.Trim();
                            _obcn.ReturnQty = Convert.ToInt32(CNqty);
                            _obcn.DefectQty = 0;
                            _obcn.TotReturnQty = Convert.ToInt32(RQty);
                            _obcn.Comment = ((TextBox)Row.FindControl("txtcmmt")).Text.Trim();
                            _obcn.HSNCode = (((Label)Row.FindControl("lblHSNCode")).Text.Trim());
                            _obcn.GSTAmount = Convert.ToDecimal(((Label)Row.FindControl("lblGST")).Text.Trim());
                            _obcn.GSTPer = Convert.ToDecimal(((Label)Row.FindControl("lblGstPer")).Text.Trim());
                            _obcn.IsActive = true;
                            _obcn.GCN = GCN;
                            _obcn.SCN = SCN;
                            _obcn.CreatedBy = Session["UserName"].ToString();
                            _obcn.Flag = "DC";
                            _obcn.strFY = Convert.ToInt32(strFY);
                            _obcn.CNDate = cndt;

                            _obcn.TransportName = lbltransporter.Text.ToString();
                            _obcn.LrNo = txtlrno.Text.ToString();
                            _obcn.Remark1 = "";
                            _obcn.Remark2 = "";
                            _obcn.Remark3 = "";
                            _obcn.Remark4 = "";
                            _obcn.Remark5 = "";
                        }
                        else
                        {
                        }

                        if (rqty1 > 0 && cmt != "")
                        {
                            //_obdcrtbk.Save_DC_ReturnBook(Convert.ToInt32(strFY));
                            ObjBal.Save_ReturnBook(_obdcrtbk);

                            if (RdbtnYN.SelectedValue == "1")
                            {
                                _oblcn.CNNo = CNNo;
                                _oblcn.strFY = Convert.ToInt32(strFY);
                                _oblcn.CNDate = cndt;
                                //_obcn.Save_CN(Convert.ToInt32(strFY));
                                ObjBal.SaveDCCN(_obcn);
                            }
                            else { }
                            flag = true;

                            //bind grid to display printdata 
                            Bindgrdcn();
                        }
                        else
                        {
                        }
                    }
                }

                if (flag)
                {
                    try
                    {
                        if (RdbtnYN.SelectedValue == "1")
                        {
                            _oblcn.Ledger_CN();
                            MessageBox(Constants.save + "\\r\\n CreditNote No: " + CNNo);
                            //BindGrd2();
                            PnlPrint.Visible = true;
                            btnPrint.Visible = true;
                            btnaddBooks.Visible = false;
                            txtcustomer.Enabled = true;
                            btnSave.Enabled = true;
                        }
                        else
                            if (RdbtnYN.SelectedValue == "0")
                            {
                                MessageBox(Constants.save);
                            }
                    }
                    catch (Exception ex)
                    {
                        MessageBox("Error : " + ex.Message.ToString());
                        clearall();
                        Txtgcn.Focus();
                    }
                    Panel2.Visible = false;
                    // RdbtnYN.SelectedIndex = 0;
                    // txtcustomer.Text = "";
                    //lblCustName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox("Error : " + ex.Message.ToString());
                btnSave.Enabled = true;

            }
        }
    }

    #endregion
    public void clearall()
    {
        Txtgcn.Text = "";
        Txtscn.Text = "";
        txtcustomer.Text = "";
        txtlrno.Text = "";
        lbltransporter.Text = "";
        lblCustName.Text = "";


    }

    protected void btnClearGrid_Click(object sender, EventArgs e)
    {
        Session["tempDCData1"] = null;
        Grd2.DataSource = null;
        txtcustomer.Enabled = true;
        txtcustomer.ToolTip = "";
        BindGrd2(fillTempBookData("", ""));
        txtcustomer.Focus();

    }


    #region Get Record

    protected void btngetRec_Click(object sender, EventArgs e)
    {
        //BindGrd2();
        if (Grd2.Rows.Count > 0)
        {
            Grd2.Focus();
            btnSave.Visible = true;
            //Panelview.Visible = false;
            // Panel3.Visible = false;
            Panel2.Visible = true;
            PnlPrint.Visible = false;
            btnPrint.Visible = false;
        }
        else
        {
            btnSave.Visible = false;
            //Panelview.Visible = false;
            // Panel3.Visible = false;
            Panel2.Visible = false;
            PnlPrint.Visible = false;
            btnPrint.Visible = false;
            MessageBox("Record Not Available");
            lblCustName.Text = "";
            txtcustomer.Focus();
            txtcustomer.Text = "";
        }

    }

    protected void btnaddBooks_Click(object sender, EventArgs e)
    {
        string bookcode = txtbkcod.Text.Split(':')[0].Trim();
        string bookname = txtbkcod.Text.Split(':')[2].Trim();
//MessageBox("year " + strFY +  " bk " + bookcode);
        if (txtcustomer.Text == "")
        {
            MessageBox("Select Customer First!!");
            txtcustomer.Enabled = true;
            txtcustomer.Focus();
            Session["tempDCData1"] = null;
            BindGrd2(fillTempBookData(bookcode, CustCode));

        }

        else
        {
          //  MessageBox("message2");
            //  bookname = txtbkcod.Text.Split(':')[2].Trim();
            DataTable dt1 = new DataTable();
            if (Session["tempDCData1"] != null)
            {
                dt1 = (DataTable)Session["tempDCData1"];
                DataView dv = new DataView(dt1);
                dv.RowFilter = "BookCode = '" + bookcode.Trim() + "'";
                int i = 0;
                foreach (DataRowView row in dv)
                {
                    i++;
                }
                if (i == 0)
                {
                    BindGrd2(fillTempBookData(bookcode, CustCode));
                }
                else
                {
                    loder(bookname + " already added!", "3000");
                }
            }
            else
            {
                BindGrd2(fillTempBookData(bookcode, CustCode));
                loder(bookname + " added successfully", "3000");
            }

           // BindGrd2(fillTempBookData(bookcode, CustCode));
            if (Grd2.Rows.Count > 0)
            {

                btnSave.Visible = true;
                Panel2.Visible = true;
                PnlPrint.Visible = false;
                btnPrint.Visible = false;
                txtcustomer.Enabled = false;
                txtcustomer.ToolTip = "Remove data first from grid..";
            }
            else
            {
                btnSave.Visible = false;
                Panel2.Visible = false;
                PnlPrint.Visible = false;
                btnPrint.Visible = false;
                MessageBox("Record Not Available");

            }
            clearAddBooks();
            
        }
        txtbkcod.Focus();
    }

    private void clearAddBooks()
    {
        txtbkcod.Text = "";
        txRetqty.Text = "";
        
    }

    #endregion

    #region TextChanged Events

    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "CustomerNAC").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustNameCA"]);
            //btngetRec.Focus();
            //ACExttransporter.ContextKey = CustCode;

            //   Bind_DDL_Transport();
        }
        else
        {
            btnSave.Visible = false;
            //Panelview.Visible = false;
            // Panel3.Visible = false;
            Panel2.Visible = false;
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
        }
    }

    protected void DDLstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        AutoCompleteExtender1.ContextKey = "book_" + DDLstandard.SelectedItem.Text;
        txtbkcod.Focus();
    }

    protected void lbltransporter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (lbltransporter.Text != "")
            {
                string TransCode = (lbltransporter.Text.ToString().Split(':', '[', ']')[0].Trim());
                flag1 = (lbltransporter.Text.ToString().Split('[', ']')[1].Trim());

                if (flag1 == "Emp")
                {
                    string Empname = (lbltransporter.Text.ToString().Split(':', '[')[2].Trim());
                    (lbltransporter.Text) = Empname;
                }
                else if (flag1 == "Trans")
                {
                    (lbltransporter.Text) = TransCode;
                }
                else
                {
                    (lbltransporter.Text) = "No such record found";
                }

            }
        }

        catch
        {

        }
    }
    #endregion

    #endregion

    #region Methods

    #region Binddata method

    public void BindGrd2(DataTable dt)
    {
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        Grd2.DataSource = dt;
        Grd2.DataBind();
    }

    public void Bindgrdcn()
    {
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        grdcn.DataSource = CreditNote.PrintCN(Convert.ToInt32(strFY), CNNo);
        grdcn.DataBind();
    }

    public void BindDDLstd()
    {
        string std = "Standard";
        DDLstandard.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(std, "DropDown");
        DDLstandard.DataBind();
        DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
    }
    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string ap = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", ap, true);
    }

    public void loder(string msg)
    {
        string jv = "sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    public void loder(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }

    #endregion

    #endregion

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintCreditNote.aspx?d=" + lblCNNo.Text.Trim() + "&fy=" + strFY + "')", true);
    }

    protected void grdcn_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
            tnamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqty2 = (Label)e.Row.FindControl("lblqty");
            quantity = quantity + Convert.ToInt32(lblqty2.Text.Trim());
            Label lblamt2 = (Label)e.Row.FindControl("lblamt");
            tamount = tamount + Convert.ToDecimal(lblamt2.Text.Trim());
            Label lblnamt2 = (Label)e.Row.FindControl("lblnamt");
            tnamount = tnamount + Convert.ToDecimal(lblnamt2.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblqty3 = (Label)e.Row.FindControl("lbltqty");
            lblqty3.Text = quantity.ToString().Trim();
            Label lblamt3 = (Label)e.Row.FindControl("lbltamt");
            lblamt3.Text = tamount.ToString().Trim();
            Label lblnamt3 = (Label)e.Row.FindControl("lbltnamt");
            lblnamt3.Text = tnamount.ToString().Trim();
        }
    }

    protected void Grd2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblbkcode2 = (Label)e.Row.FindControl("lblbkcode");

            DataSet ds = DCReturnBook.Get_DC_RateByBook(CustCode + '-' + strFY.ToString(), lblbkcode2.Text);
            DropDownList DDLR = (DropDownList)e.Row.FindControl("DDLR");
            DDLR.DataSource = ds.Tables[1];
            DDLR.DataBind();

            DropDownList DDLD = (DropDownList)e.Row.FindControl("DDLD");
            DDLD.DataSource = ds.Tables[2];
            DDLD.DataBind();

            // DDLR.DataBind();
            //GetRateByBook_DCReturnBook
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            ViewState["data"] = null;
        }

    }

    protected void lblEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string BookCode = ((Label)((ImageButton)(sender)).Parent.FindControl("lblbkcode")).Text;
            // BindGrdviewRD()
            // string bookcode1 = ((Label)e.Row.FindControl("lblbkcode")).Trim;
            GrdRD.DataSource = DCReturnBook.Get_DC_RateByBook(CustCode + '-' + strFY.ToString(), BookCode).Tables[0];
            GrdRD.DataBind();

            modalPopupForRD.Show();
         
            // modalPopupForRD.Show();
        }
        catch
        {
        }
    }

    protected void RdbtnYN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnYN.SelectedValue == "0")
        {
            MessageBox(" CN will not be created - Are You Sure ? ");
        }
        else
        {
        }
    }

    protected void txtreturn_TextChanged(object sender, EventArgs e)
    {
        TextBox txtreturn = ((TextBox)((TextBox)sender).FindControl("txtreturn"));
        TextBox txtCN = ((TextBox)((TextBox)sender).FindControl("txtCN"));
        txtCN.Text = txtreturn.Text;
    }

    protected void txtCNDate_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtbkcod_TextChanged(object sender, EventArgs e)
    {
        //txtbookqty.Focus();
    }

    #region Fill grid data for books

    public DataTable fillTempBookData(string bookcode, string custCode)
    {

        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();
        DataColumn Discount = new DataColumn();
        Discount.DataType = System.Type.GetType("System.String");
        Discount.ColumnName = "Discount";

        DataColumn Amount = new DataColumn();
        Amount.DataType = System.Type.GetType("System.String");
        Amount.ColumnName = "Amount";

        if (Session["tempDCData1"] == null)
        {
            //CREATE NEW DATATABLE
            //ADD COLUMNS IN DATATABLE
            dt.Columns.Add("HSNCode");
            dt.Columns.Add("GST");
            dt.Columns.Add("GSTPer");
            dt.Columns.Add("BookCode");
            dt.Columns.Add("BookName");
            dt.Columns.Add("Standard");
            dt.Columns.Add("Medium");
            dt.Columns.Add("Qty");
            dt.Columns.Add("ReturnedQty");
            dt.Columns.Add("AvailableQty");
            dt.Columns.Add("CN");
            dt.Columns.Add(Amount);
            dt.Columns.Add(Discount);
            dt.Columns.Add("AddedrQty");
            dt.Columns.Add("AddeCnQty");
            dt.Columns.Add("Comment");
            //ADD DATA AS PER COLUMNS
            //Books _objBooks = new Books();
        }
        else
        {
            dt = (DataTable)Session["tempDCData1"];
        }

 custCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
// MessageBox("year " + strFY + " cc " + custCode + " bk " + bookcode);
        tempGetData = CreditNote.Get_DC_CNBook(Convert.ToInt32(strFY), custCode, bookcode).Tables[0];

        foreach (DataRow row in tempGetData.Rows)
        {
            //string price = row["Amount"].ToString();
            // decimal amt =0.00m;
            // if (price == "")
            // {
            //     price = "0";
            // }
            // amt = Convert.ToDecimal(quantity) * Convert.ToDecimal(price);

            if (dt.Rows.Count != 0)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "BookCode = '" + row["BookCode"].ToString() + "'";
                int i = 0;
                //price = row["Amount"].ToString();
                //amt = Convert.ToDecimal(quantity) * Convert.ToDecimal(price);
                foreach (DataRowView row1 in dv)
                {
                    i++;
                }

                if (i == 0)
                {
                    //DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString(), row["BookCode"].ToString());

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                    //    Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                    //    Tdiscount = amt * (discount / 100);
                    //    amt = amt - Tdiscount;
                    //}
                    dt.Rows.Add(row["HSNCode"].ToString(), row["GST"].ToString(), row["GSTPer"].ToString(), row["BookCode"].ToString(),
                   row["BookName"].ToString(),row["Standard"].ToString() , row["Medium"].ToString(),
                   row["Qty"].ToString(),
                   row["ReturnedQty"].ToString(),
                   row["AvailableQty"].ToString(),
                   "0.00", "0.00", "0.00",txRetqty.Text,txRetqty.Text, txtComment.Text);
                }
            }
            else
            {
                //  DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString(), row["BookCode"].ToString());

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                //    Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                //    //  Totaldiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][2]);
                //    Tdiscount = amt * (discount / 100);
                //    amt = amt - Tdiscount;
                //}

                dt.Rows.Add(row["HSNCode"].ToString(), row["GST"].ToString(), row["GSTPer"].ToString(), row["BookCode"].ToString(),
                    row["BookName"].ToString(),row["Standard"].ToString() , row["Medium"].ToString(),
                    row["Qty"].ToString(),
                    row["ReturnedQty"].ToString(),
                    row["AvailableQty"].ToString(),
                    "0.00", "0.00", "0.00", txRetqty.Text, txRetqty.Text, txtComment.Text);
            }
        }
        Session["tempDCData1"] = dt;
        return dt;
    }

    #endregion 

    protected void Grd2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
          //  setStateGridview();
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["tempDCData1"];
            dt1.Rows[e.RowIndex].Delete();
            Grd2.DataSource = dt1;
            Grd2.DataBind();
            Session["tempDCData"] = dt1;
            loder("Successfully Deleted...", "3000");
            if (Grd2.Rows.Count == 0)
            {
                btnSave.Visible = false;
            }
        }
        catch
        {
        }
    }
}
