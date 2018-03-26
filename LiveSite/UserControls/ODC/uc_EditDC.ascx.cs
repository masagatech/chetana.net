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
using System.Xml;
using Other_Z;

#endregion

public partial class UserControls_ODC_uc_EditDC : System.Web.UI.UserControl
{
    #region Variables

    int DocNo;
    int DocNewNo;
    string Qty = "1";
    int Reqty, givqty;
    decimal amt;
    string rqty = "1";
    string bookname = "";
    string gqty = "0";
    string dcid = "0";
    string price;
    int DCDid;
    DateTime Delidate;
    static string srate;
    decimal discount;
    decimal Adddiscount;
    decimal Tdiscount, rate;
    string flag1;
    static int tabindex = 20;
    static string sDateFormat = "dd/MM/yyyy";
    static int quantity = 0;
    static decimal tamount = 0;
    string strChetanaCompanyName = "cppl";
    string strFY;
    bool Isblock;
    string xmlstr;

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
            GetValidation(3, Convert.ToInt32(Session["Role"]));
            ModalPopUpDocNum.Show();
            TxtDocNo.Focus();

            string grp = "BookSet";
            DDLSelectSet.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
            DDLSelectSet.DataBind();
            DDLSelectSet.Items.Insert(0, new ListItem("-Select book set-", "0"));

            string std = "Standard";
            DDLstandard.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(std, "DropDown");
            DDLstandard.DataBind();
            DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
            //   txtdocDate.Text = DateTime.Now.ToString(sDateFormat);
            txtChalDate.Text = DateTime.Now.ToString(sDateFormat);
            //  txtDeliverydte.Text = DateTime.Now.ToString(sDateFormat);
            //    txtOrdDate.Text = DateTime.Now.ToString(sDateFormat);
            //txtorder.Focus();
            Session["tempDCData"] = null;
            // Openpopup(2).;
            // btncancel.Visible = false;
            //Session["tempDCData"] = null;
            Bindcustomer();
            // DCMaster.Get_Transporter(custcode);
            lblZoneCode.Visible = false;
            DDLZone.Visible = false;
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {

            if (grdBookDetails.Rows.Count == 0)
            {
                MessageBox("Kindly fill Book details");
            }
            else
            {
                //DCMaster _objDC = new DCMaster();
                // _objDC.DocumentNo = Convert.ToInt32(txtdoc.Text.Trim());

                //string DocumentDate = DateTime.Now.ToString("MM/dd/yyyy");
                //string ChallanDate = DateTime.Now.ToString("MM/dd/yyyy");
                //string OrderDate = DateTime.Now.ToString("MM/dd/yyyy");

                string DocumentDate = txtdocDate.Text.Split('/')[1] + "/" + txtdocDate.Text.Split('/')[0] + "/" + txtdocDate.Text.Split('/')[2];
                string ChallanDate = txtChalDate.Text.Split('/')[1] + "/" + txtChalDate.Text.Split('/')[0] + "/" + txtChalDate.Text.Split('/')[2];
                string OrderDate = txtOrdDate.Text.Split('/')[1] + "/" + txtOrdDate.Text.Split('/')[0] + "/" + txtOrdDate.Text.Split('/')[2];

                Other_Z.DCMaster_cs.DCMasterProp _objDC = new Other_Z.DCMaster_cs.DCMasterProp();
                Other_Z.DCMaster_cs objBal = new DCMaster_cs();

                if (txtdoc.Text != "")
                {

                    _objDC._DocumentNo = Convert.ToInt32(txtdoc.Text.Trim());
                }
                if (SplitDCValidate() == true)
                {
                    _objDC._DocumentDate = Convert.ToDateTime(DocumentDate);
                    _objDC._ChallanNo = txtchalan.Text.Trim();
                    _objDC._ChallanDate = Convert.ToDateTime(ChallanDate);
                    // string ordno = txtorder.Text.Trim();
                    //if (ordno == "")
                    //{
                    //    ordno = "0";
                    //}
                    _objDC._OrderNo = txtorder.Text.Trim();
                    _objDC._OrderDate = Convert.ToDateTime(OrderDate);
                    _objDC._CustCode = txtcustomer.Text.Trim();
                    _objDC._SalesmanCode = DDlemployee.SelectedValue.Trim();
                    _objDC._PIncharge = txtpIncharge.Text.Trim();
                    _objDC._TransportID = txttransporter.Text.Trim() + "!" + DDLZone.SelectedValue.ToString();
                    if (lbltransporter.Text == "Trans")
                    {
                        _objDC._Transporter = lbltransporter.Text;
                    }
                    else
                    {
                        _objDC._Transporter = lbltransporter.Text.Trim();
                    }
                    _objDC._SpInstruction = txtspInstruct.Text.Trim();
                    _objDC._BankCode = txtbankdet.Text.Trim();
                    _objDC._IsActive = true;
                    _objDC._IsDeleted = false;
                    _objDC._UpdatedBy = Convert.ToString(Session["UserName"]);
                    _objDC._ChetanaCompanyName = strChetanaCompanyName;
                    _objDC._FinancialYearFrom = Convert.ToInt32(strFY);
                    _objDC.Xmldata = SaveDetailXML(_objDC._DocumentNo);
                    //_objDC.Save(out DocNo, 1, out DocNewNo);
                    objBal.SaveDCWithXml(_objDC, out DocNo, out DocNewNo);
                    txtdoc.Text = Convert.ToString(DocNo);
                    //SaveDCDetails(DocNo);

                    MessageBox("Record saved successfully \\r\\n Documennt no.  " + DocNewNo);
                    loder("Last saved Document no. : " + DocNewNo);
                    grdBookDetails.DataBind();

                    lblmsg.Text = "Last saved Document no. : " + DocNewNo;

                    DDLSelectSet.SelectedValue = null;
                    Session["tempDCData"] = null;
                    ClearFields();
                    btn_Save.Visible = false;
                }

            }
        }
        catch (Exception ex)
        {
            // Response.Write("Message " + ex.StackTrace.ToString());
            string ex1 = ex.Message.ToString();
            string je = "alert('" + ex1 + "')";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "new", je, true);
            // Response.Write(ex.Message.ToString());
        }
    }
    #region GetDC Details By DocNum

    protected void BtnGetDCDetails_Click(object sender, EventArgs e)
    {


        ModalPopUpDocNum.Hide();
        Session["tempDCData"] = null;

        int DocNum = Convert.ToInt32(ddldocno.SelectedValue);


        //  bool condition = false;

        DataSet ds = DCMaster.Get_DCMasterBy_DocNum(DocNum, "1");
        DataTable dt = ds.Tables[0];
        DataTable dtzone = ds.Tables[2];
        if (dt.Rows.Count > 0)
        {
            lblchksplitdc.Text = dt.Rows[0]["isSplit"].ToString();
            lblsplitval.Text = dt.Rows[0]["splitvalue"].ToString();
            txtdocnew.Text = dt.Rows[0]["DocumentNo_New"].ToString();
            txtdoc.Text = dt.Rows[0]["DocumentNo"].ToString();
            txtchalan.Text = dt.Rows[0]["ChallanNo"].ToString();
            txtChalDate.Text = dt.Rows[0]["ChallanDate"].ToString();
            txtorder.Text = dt.Rows[0]["OrderNo"].ToString();
            txtcustomer.Text = dt.Rows[0]["CustCode"].ToString();
            lblCustName.Text = dt.Rows[0]["CustName"].ToString();
            DDlemployee.Items.Clear();
            DDlemployee.DataSource = DCMaster.Get_Employee_By_Customer_Code(txtcustomer.Text.ToString(), "Employee");
            DDlemployee.DataBind();
            DDlemployee.SelectedValue = dt.Rows[0]["SalesmanCode"].ToString();
            DDlemployee.SelectedItem.Text = dt.Rows[0]["SalesmanName"].ToString();
            txtOrdDate.Text = dt.Rows[0]["OrderDate"].ToString();
            txtdocDate.Text = dt.Rows[0]["DocumentDate"].ToString();
            txtpIncharge.Text = dt.Rows[0]["PIncharge"].ToString();
            txtspInstruct.Text = dt.Rows[0]["SpInstruction"].ToString();
            txtbankdet.Text = dt.Rows[0]["BankCode"].ToString();
            lblbankname.Text = dt.Rows[0]["BankName"].ToString();

            //Extra Zone Code Bind
            if (dtzone.Rows.Count > 0)
            {
                lblZoneCode.Visible = true;
                DDLZone.Visible = true;
                DDLZone.Items.Clear();
                DDLZone.DataSource = ds.Tables[2];
                DDLZone.DataBind();
                if (dt.Rows[0]["ExtraZoneCode"].ToString() != "")
                {
                    //DDLZone.SelectedValue = dt.Rows[0]["ExtraZoneCode"].ToString();
                }
            }
            else
            {
                DDLZone.Items.Clear();
                lblZoneCode.Visible = false;
                DDLZone.Visible = false;
            }

            try
            {
                txtDeliverydte.Text = Convert.ToDateTime(DCMaster.Get_DCMasterBy_DocNum(DocNum, "0").Tables[1].Rows[0]["DeliveryDate"].ToString()).ToString("dd/MM/yyyy");
                UpdatePanel14.Update();

            }
            catch
            {


            }

            // Bind_DDL_Transport();
            //  Ddltransport.SelectedValue = dt.Rows[0]["TransportID"].ToString();
            if (dt.Rows[0]["TransporterCode"].ToString() == "Trans")
            {
                lbltransporter.Visible = false;
                lbltransporter.Text = dt.Rows[0]["TransporterCode"].ToString();

                txttransporter.Text = dt.Rows[0]["Transporter"].ToString();
            }
            else
            {
                txttransporter.Text = dt.Rows[0]["TransporterCode"].ToString();
                lbltransporter.Visible = true;
                lbltransporter.Text = dt.Rows[0]["Transporter"].ToString();
            }
            //DataSet ds = new DataSet();
            // ds = SpecimanDetails.GetSpecimenDatilsByEmpCode(Convert.ToString(DocNum), "documentno");

            DataTable dt1 = new DataTable();
            if (Session["tempDCData"] != null)
            {
                Session["tempDCData"] = fillTempBookData(DocNum.ToString(), "get");
                dt1 = (DataTable)Session["tempDCData"];
            }
            else
            {
                Session["tempDCData"] = fillTempBookData(DocNum.ToString(), "get");
                dt1 = (DataTable)Session["tempDCData"];
            }

            grdBookDetails.DataSource = dt1;
            grdBookDetails.DataBind();
            grdBookDetails.Columns[5].Visible = true;
            grdBookDetails.Columns[4].Visible = true;
            btn_Save.Visible = true;
            //DataTable dt3 = new DataTable();
            //dt3 = ds.Tables[0];
            //Session["tempDCData"] = dt3;
            grdBookDetails.Visible = true;
            //  btn_Save.Visible = false;

        }
        else
        {
            message("Record not found for document no. " + TxtDocNo.Text);
            ModalPopUpDocNum.Show();
            TxtDocNo.Text = "";
            TxtDocNo.Focus();
            btn_Save.Visible = false;
        }
    }

    #endregion

    #region Check Split DC Value Of Master Of Master And Group splitdc

    private bool SplitDCValidate()
    {
        bool chkSplitdc = true;
        foreach (GridViewRow row in grdBookDetails.Rows)
        {
            Reqty = Convert.ToInt32(((TextBox)row.FindControl("txtquty")).Text);
            discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
            amt = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Reqty;
            Tdiscount = amt * (discount / 100);
            amt = amt - Tdiscount;
        }

        if (Convert.ToBoolean(lblchksplitdc.Text) == true && amt > Convert.ToDecimal(lblsplitval.Text))
        {
            MessageBox("Can not create dc more than " + lblsplitval.Text + " amount.");
            chkSplitdc = false;
        }

        return chkSplitdc;
    }

    #endregion

    protected void btnaddBooks_Click(object sender, EventArgs e)
    {
        if (srate == "")
        {
            MessageBox("Kindly select Customer");
            txtcustomer.Focus();
        }
        else
        {
            if (txtDeliverydte.Text != "")
            {

                setStateGridview();
                AddRate();
                Qty = Convert.ToString(txtbookqty.Text.Trim());
                rqty = Convert.ToString(txtbookqty.Text.Trim());
                string date = txtDeliverydte.Text.Split('/')[1] + "/" + txtDeliverydte.Text.Split('/')[0] + "/" + txtDeliverydte.Text.Split('/')[2];

                Delidate = Convert.ToDateTime(date);

                if (Qty == "" || Qty == "0")
                {
                    Qty = "1";
                    rqty = "1";
                }
                if (txtbookqty.Text != "")
                {
                    rqty = Convert.ToString(txtbookqty.Text);
                    Qty = Convert.ToString(txtbookqty.Text);
                }
                if (txtdoc.Text != "")
                {
                    grdBookDetails.Columns[5].Visible = true;
                    grdBookDetails.Columns[4].Visible = true;
                }
                else
                {
                    grdBookDetails.Columns[5].Visible = false;
                    grdBookDetails.Columns[4].Visible = false;
                }
                try
                {


                    string bookcode = txtbkcod.Text.Split(':')[0].Trim();
                    bookname = txtbkcod.Text.Split(':')[2].Trim();

                    DataTable dt1 = new DataTable();
                    if (Session["tempDCData"] != null)
                    {
                        dt1 = (DataTable)Session["tempDCData"];
                        DataView dv = new DataView(dt1);
                        dv.RowFilter = "BookCode = '" + bookcode.Trim() + "'";
                        int i = 0;
                        foreach (DataRowView row in dv)
                        {
                            i++;
                        }
                        if (i == 0)
                        {
                            Session["tempDCData"] = fillTempBookData(bookcode.Trim(), "");
                            dt1 = (DataTable)Session["tempDCData"];
                            if (Isblock != true)
                            {
                                loder(bookname + " added successfully", "3000");
                            }
                            else { loder(bookname + " Book Is Blocked", "3000"); }
                        }
                        else
                        {
                            loder(bookname + " already added!");

                        }
                    }
                    else
                    {
                        Session["tempDCData"] = fillTempBookData(bookcode.Trim(), "");
                        dt1 = (DataTable)Session["tempDCData"];
                        if (Isblock != true)
                        {
                            loder(bookname + " added successfully", "3000");
                        }
                        else { loder(bookname + " Book Is Blocked", "3000"); }
                    }
                    if (Isblock != true)
                    {
                        grdBookDetails.DataSource = dt1;
                        grdBookDetails.DataBind();

                    }
                    else
                    {

                        MessageBox("Book Is Blocked ");
                        //txtbkcod.Focus();
                    }
                    string jv = "clearAddbook()";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "as", jv, true);
                    txtbkcod.Focus();

                }
                catch
                {


                }
            }
            else
            {
                MessageBox("Select delivery date");
                txtDeliverydte.Focus();
            }
        }

    }

    protected void btngetset_Click(object sender, EventArgs e)
    {
        if (srate == "")
        {
            MessageBox("Kindly select Customer");
            txtcustomer.Focus();
        }
        else
        {
            if (txtDeliverydte.Text != "")
            {
                //if (Convert.ToDateTime(Convert.ToDateTime(txtDeliverydte.Text).ToShortDateString()) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                //{
                setStateGridview();
                AddRate();
                Qty = Convert.ToString(txtsetqty.Text.Trim());
                rqty = Convert.ToString(txtbookqty.Text.Trim());
                string date = txtDeliverydte.Text.Split('/')[1] + "/" + txtDeliverydte.Text.Split('/')[0] + "/" + txtDeliverydte.Text.Split('/')[2];

                Delidate = Convert.ToDateTime(date);

                if (Qty == "" || Qty == "0")
                {
                    Qty = "1";
                    rqty = "1";
                }
                if (txtsetqty.Text != "")
                {
                    rqty = Convert.ToString(txtsetqty.Text.Trim());
                    Qty = Convert.ToString(txtsetqty.Text.Trim());

                }
                if (txtdoc.Text != "")
                {
                    grdBookDetails.Columns[5].Visible = true;
                    grdBookDetails.Columns[4].Visible = true;
                    // grdBookDetails.Columns[10].Visible = false;
                }
                else
                {
                    grdBookDetails.Columns[5].Visible = false;
                    grdBookDetails.Columns[4].Visible = false;
                    //  grdBookDetails.Columns[10].Visible = true;
                }
                if (DDLSelectSet.SelectedValue == "0")
                {
                    loder("Kindly select bookset");
                    DDLSelectSet.Focus();
                }
                else
                {
                    try
                    {
                        DataTable dt1 = new DataTable();
                        if (Session["tempDCData"] != null)
                        {
                            Session["tempDCData"] = fillTempBookData("", "set");
                            dt1 = (DataTable)Session["tempDCData"];
                        }
                        else
                        {
                            Session["tempDCData"] = fillTempBookData("", "set");
                            dt1 = (DataTable)Session["tempDCData"];
                        }
                        foreach (GridViewRow row in grdBookDetails.Rows)
                        {
                            ((Label)row.FindControl("lblavailable")).Visible = false;
                        }
                        grdBookDetails.DataSource = dt1;
                        grdBookDetails.DataBind();
                        loder(DDLSelectSet.SelectedItem.Text + "(bookset) added successfully");
                        string jv1 = "clearBookset()";
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "as", jv1, true);
                        DDLSelectSet.Focus();
                    }
                    catch
                    {


                    }
                }
                //}
                //else {
                //    MessageBox("Delivery date should be more than todays date");
                //    txtDeliverydte.Focus();
                //}
            }
            else
            {
                MessageBox("Select delivery date");
                txtDeliverydte.Focus();
            }
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
    public void loder(string msg, string timetohid)
    {
        string jv = "autosloder('" + msg + "'," + timetohid + ");";
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

    #region Fill grid data for books

    public DataTable fillTempBookData(string bookcode, string flag)
    {

        DataTable dt = new DataTable();
        DataTable tempGetData = new DataTable();

        DataColumn colTax = new DataColumn();
        colTax.DataType = System.Type.GetType("System.String");
        colTax.ColumnName = "Rate";
        DataColumn Discount = new DataColumn();
        Discount.DataType = System.Type.GetType("System.String");
        Discount.ColumnName = "Discount";
        DataColumn AdditionalDiscount = new DataColumn();
        AdditionalDiscount.DataType = System.Type.GetType("System.String");
        AdditionalDiscount.ColumnName = "AdditionalDiscount";
        DataColumn Amount = new DataColumn();
        Amount.DataType = System.Type.GetType("System.String");
        Amount.ColumnName = "Amount";

        if (Session["tempDCData"] == null)
        {
            //CREATE NEW DATATABLE
            //ADD COLUMNS IN DATATABLE
            dt.Columns.Add("DCDetailID");
            dt.Columns.Add("BookId");
            dt.Columns.Add("BookCode");
            dt.Columns.Add("BookName");
            //dt.Columns.Add("BookType");
            dt.Columns.Add("Standard");
            dt.Columns.Add("Medium");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("GivedQty");
            dt.Columns.Add("RemainQty");
            dt.Columns.Add("DeliveryDate");
            dt.Columns.Add(colTax);
            dt.Columns.Add(Amount);
            dt.Columns.Add(Discount);
            dt.Columns.Add(AdditionalDiscount);
            //ADD DATA AS PER COLUMNS
            //Books _objBooks = new Books();
        }
        else
        {
            dt = (DataTable)Session["tempDCData"];

        }
        if (flag == "set")
        {
            tempGetData = BookSetDetails.Get_BookSetDetailsOn_SetID_ForDC((Convert.ToInt32(DDLSelectSet.SelectedItem.Value)), srate).Tables[0];
        }
        else if (flag == "get")
        {
            try
            {
                tempGetData = DCDetails.GetDCDatilsByCode(bookcode, "documentno").Tables[0];
            }
            catch
            {


            }

        }
        else
        {
            tempGetData = Books.Get_BooksMasterForDC(bookcode, srate).Tables[0];
            Isblock = (Convert.ToBoolean(tempGetData.Rows[0]["IsBlock"].ToString()));
        }

        foreach (DataRow row in tempGetData.Rows)
        {

            price = row["SellingPrice"].ToString();
            amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(price);

            if (dt.Rows.Count != 0)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "BookCode = '" + row["BookCode"].ToString() + "'";
                int i = 0;
                price = row["SellingPrice"].ToString();
                amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(price);
                foreach (DataRowView row1 in dv)
                {
                    i++;
                }


                if (i == 0)
                {
                    DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString() + "!" + Session["FY"].ToString(), row["BookCode"].ToString());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                        Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                        //  Totaldiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][2]);
                        Tdiscount = amt * (discount / 100);
                        amt = amt - Tdiscount;
                    }
                    if (flag == "get")
                    {
                        Qty = row["Quantity"].ToString();
                        rqty = row["RemainQty"].ToString();
                        gqty = row["GivedQty"].ToString();
                        dcid = row["DCDetailID"].ToString();
                        string EDate = row["DeliveryDate"].ToString();
                        EDate = EDate.Split('/')[1] + "/" + EDate.Split('/')[0] + "/" + EDate.Split('/')[2];
                        Delidate = Convert.ToDateTime(EDate);
                        price = row["SellingPrice"].ToString();
                        amt = Convert.ToDecimal(row["Amount"].ToString());
                        discount = Convert.ToDecimal(row["Discount"].ToString());

                    }


                    dt.Rows.Add(dcid, row["Bookid"].ToString(), row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), Qty, gqty, rqty, Delidate.ToString("dd/MM/yyyy"), String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:0.00}", Convert.ToDecimal(amt)), String.Format("{0:0.00}", Convert.ToDecimal(discount)), String.Format("{0:0.00}", Convert.ToDecimal(Adddiscount)));

                }
            }
            else
            {
                DataSet ds = DCMaster.Get_Discount_On_CusomerAND_Booktype(txtcustomer.Text.ToString() + "!" + Session["FY"].ToString(), row["BookCode"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    discount = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                    Adddiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                    //  Totaldiscount = Convert.ToDecimal(ds.Tables[0].Rows[0][2]);
                    Tdiscount = amt * (discount / 100);
                    amt = amt - Tdiscount;
                }
                if (flag == "get")
                {
                    Qty = row["Quantity"].ToString();
                    rqty = row["RemainQty"].ToString();
                    gqty = row["GivedQty"].ToString();
                    dcid = row["DCDetailID"].ToString();
                    string EDate = row["DeliveryDate"].ToString();
                    EDate = EDate.Split('/')[1] + "/" + EDate.Split('/')[0] + "/" + EDate.Split('/')[2];
                    Delidate = Convert.ToDateTime(EDate);
                    price = row["SellingPrice"].ToString();
                    amt = Convert.ToDecimal(row["Amount"].ToString());
                    discount = Convert.ToDecimal(row["Discount"].ToString());

                }

                dt.Rows.Add(dcid, row["Bookid"].ToString(), row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), Qty, gqty, rqty, Delidate.ToString("dd/MM/yyyy"), String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:0.00}", Convert.ToDecimal(amt)), String.Format("{0:0.00}", Convert.ToDecimal(discount)), String.Format("{0:0.00}", Convert.ToDecimal(Adddiscount)));
            }
        }
        return dt;
    }

    #endregion

    #region TextChanged Events
    protected void txtbankdet_TextChanged(object sender, EventArgs e)
    {
        string BankCode = txtbankdet.Text.ToString().Split(':')[0].Trim();


        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtbankdet.Text = BankCode;
            lblbankname.Text = Convert.ToString(dt.Rows[0]["BankName"]);
            DDLSelectSet.Focus();

        }


        else
        {
            lblbankname.Text = "No such Bank code";
            txtbankdet.Focus();
            txtbankdet.Text = "";
        }
    }
    protected void txtbkcod_TextChanged(object sender, EventArgs e)
    {

    }
    //protected void txtsalemanCode_TextChanged(object sender, EventArgs e)
    //{
    //    string ECode = txtsalemanCode.Text.ToString().Split(':')[0].Trim();


    //    DataTable dt = new DataTable();
    //    dt = DCMaster.Get_Name(ECode, "Employee").Tables[0];
    //    if (dt.Rows.Count != 0)
    //    {
    //        txtsalemanCode.Text = ECode;
    //        lblSalesManName.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
    //        txtpIncharge.Focus();
    //    }
    //    else
    //    {
    //        lblSalesManName.Text = "No such salesman code";
    //        txtsalemanCode.Focus();
    //        txtsalemanCode.Text = "";
    //    }


    //}
    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {
            txtcustomer.Text = CustCode;
            lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
            if (dt.Rows[0]["State"].ToString().ToLower() == "maharashtra")
            {

                srate = "l";
            }
            else
            {
                srate = "m";

            }
            //txtsalemanCode.Focus();
            ACExttransporter.ContextKey = CustCode;
            DDlemployee.DataSource = DCMaster.Get_Employee_By_Customer_Code(CustCode, "Employee");
            DDlemployee.DataBind();
            DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));
            DDlemployee.Focus();
            //   Bind_DDL_Transport();
        }


        else
        {
            lblCustName.Text = "No such Customer code";
            txtcustomer.Focus();
            txtcustomer.Text = "";
            srate = "";
        }
    }
    protected void txttransporter_TextChanged(object sender, EventArgs e)
    {
        if (txttransporter.Text != "")
        {
            string TransCode = txttransporter.Text.ToString().Split(':', '[', ']')[0].Trim();
            flag1 = txttransporter.Text.ToString().Split('[', ']')[1].Trim();
            txttransporter.Text = TransCode;
            ACExttransporter.ContextKey = TransCode;
            if (flag1 == "Emp")
            {
                lbltransporter.Visible = true;
                DataTable dt = new DataTable();
                dt = DCMaster.Get_Name(TransCode, flag1).Tables[0];

                if (dt.Rows.Count != 0)
                {
                    // txttransporter.Text = TransCode;
                    if (flag1 == "Emp")
                    {

                        lbltransporter.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
                    }
                    txtbankdet.Focus();

                }
                else
                {
                    lblCustName.Text = "No such Customer code";
                    txtcustomer.Focus();
                    txtcustomer.Text = "";
                }
                //   Bind_DDL_Transport();
            }
            else
            {
                lbltransporter.Visible = false;
                lbltransporter.Text = flag1;
            }
        }
        else
        {
            lbltransporter.Text = "";
        }
    }


    #endregion

    #region Authentication Event
    protected void txtchalan_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtorder_TextChanged(object sender, EventArgs e)
    {
        bool Auth = DCMaster.GetDCOrderNoAuthentication(txtorder.Text.Trim(), Convert.ToInt32(strFY));
        if (Auth)
        {
            MessageBox("Order no is already Exist");
            txtorder.Text = "";
            txtorder.Focus();

        }
        else
        {
            txtOrdDate.Focus();
        }
    }
    #endregion

    #region Methods
    public void ClearFields()
    {
        txtdoc.Text = "";
        //   txtchalan.Text = "";
        txtorder.Text = "";
        txtcustomer.Text = "";
        lblCustName.Text = "";
        DDlemployee.Items.Clear();
        DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));
        //txtsalemanCode.Text = "";
        //lblSalesManName.Text = "";
        txtpIncharge.Text = "";
        txtspInstruct.Text = "";
        txttransporter.Text = "";
        lbltransporter.Text = "";
        txtbankdet.Text = "";
        lblbankname.Text = "";
        DDLSelectSet.SelectedValue = "0";
        DDLZone.Items.Clear();
        DDLZone.Visible = false;
        lblZoneCode.Visible = false;
        txtsetqty.Text = "";
        txtOrdDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDeliverydte.Text = "";
        lblsplitval.Text = "0.0";
        lblchksplitdc.Text = "false";


    }

    private void setStateGridview()
    {
        DataColumn colTax = new DataColumn();
        colTax.DataType = System.Type.GetType("System.String");
        colTax.ColumnName = "Rate";
        DataTable _d = new DataTable();
        _d.Columns.Add("DCDetailID");
        _d.Columns.Add("Bookid");
        _d.Columns.Add("BookCode");
        _d.Columns.Add("BookName");
        //dt.Columns.Add("BookType");
        _d.Columns.Add("Standard");
        _d.Columns.Add("Medium");
        _d.Columns.Add("Quantity");
        _d.Columns.Add("GivedQty");
        _d.Columns.Add("RemainQty");
        _d.Columns.Add("DeliveryDate");
        _d.Columns.Add(colTax);
        _d.Columns.Add("Amount");
        _d.Columns.Add("Discount");
        _d.Columns.Add("AdditionalDiscount");



        foreach (GridViewRow row in grdBookDetails.Rows)
        {
            decimal amt1, rate1, qty1;
            decimal discount1;
            decimal Tdiscount1;
            string amt;
            if (((TextBox)row.FindControl("txtDiscount")).Text != "")
            {
                discount1 = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
            }
            else
            {
                discount1 = 0;
            }
            if (((Label)row.FindControl("lblAmt")).Text != "")
            {
                rate1 = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text);
                qty1 = Convert.ToDecimal(((TextBox)row.FindControl("txtquty")).Text);
                amt1 = rate1 * qty1;
                Tdiscount1 = amt1 * (discount1 / 100);
                amt1 = amt1 - Tdiscount1;
            }
            else
            {
                amt1 = 0;
            }

            _d.Rows.Add(Convert.ToInt32(((Label)row.FindControl("lblDCDetailID")).Text),
            ((Label)row.FindControl("lblBookid")).Text,
            ((Label)row.FindControl("lblBookCode")).Text,
            ((Label)row.FindControl("lblBookName")).Text,
            ((Label)row.FindControl("lblStandard")).Text,
            ((Label)row.FindControl("lblMedium")).Text,
            ((Label)row.FindControl("lblavailable")).Text,
            ((Label)row.FindControl("lblgivedqty")).Text,
            ((TextBox)row.FindControl("txtquty")).Text,
            ((TextBox)row.FindControl("txtDeldate")).Text,
            ((TextBox)row.FindControl("txtrate")).Text,
            String.Format("{0:0.00}", amt1),
            ((TextBox)row.FindControl("txtDiscount")).Text,
            ((Label)row.FindControl("txtAddDiscount")).Text
            );



        }
        Session["tempDCData"] = null;
        Session["tempDCData"] = _d;
    }
    #endregion

    #region Save DC Details

    public void SaveDCDetails(int docNo)
    {
        DCDetails _objDCD = new DCDetails();
        try
        {
            foreach (GridViewRow row in grdBookDetails.Rows)
            {
                _objDCD.DCDetailID = Convert.ToInt32(((Label)row.FindControl("lblDCDetailID")).Text);
                _objDCD.DocumentNo = docNo;
                _objDCD.BookCode = ((Label)row.FindControl("lblBookCode")).Text;
                _objDCD.BookName = ((Label)row.FindControl("lblBookName")).Text;
                _objDCD.Standard = ((Label)row.FindControl("lblStandard")).Text;
                _objDCD.Medium = ((Label)row.FindControl("lblMedium")).Text;
                Reqty = Convert.ToInt32(((TextBox)row.FindControl("txtquty")).Text);
                givqty = Convert.ToInt32(((Label)row.FindControl("lblgivedqty")).Text);
                _objDCD.Quantity = Reqty + givqty;
                // string DDate = ((TextBox)row.FindControl("txtDeldate")).Text;
                // DDate = DDate.Split('/')[1] + "/" + DDate.Split('/')[0] + "/" + DDate.Split('/')[2];
                string DDate = txtDeliverydte.Text.Split('/')[1] + "/" + txtDeliverydte.Text.Split('/')[0] + "/" + txtDeliverydte.Text.Split('/')[2];

                _objDCD.DeliveryDate = Convert.ToDateTime(DDate);
                _objDCD.Rate = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text);
                _objDCD.Discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
                discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);

                amt = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Reqty;
                Tdiscount = amt * (discount / 100);
                amt = amt - Tdiscount;

                if (((Label)row.FindControl("lblAmt")).Text != "")
                {
                    _objDCD.Amount = Convert.ToDecimal(amt);
                }
                else
                {
                    _objDCD.Amount = 0;
                }



                //_objDCD.Publisher = ((Label)row.FindControl("lblPublisher")).Text;
                _objDCD.CreatedBy = Convert.ToString(Session["UserName"]);
                _objDCD.IsActive = true;
                _objDCD.Save();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }

    #endregion

    #region Save Details With XML

    private string SaveDetailXML(int docNo)
    {
        XmlDocument doc = new XmlDocument();
        XmlNode inode = doc.CreateElement("f");
        XmlNode fnode = doc.CreateElement("r");
        foreach (GridViewRow row in grdBookDetails.Rows)
        {
            XmlNode element = doc.CreateElement("i");

            //_objDCD.DCDetailID = Convert.ToInt32(((Label)row.FindControl("lblDCDetailID")).Text);
            inode = doc.CreateElement("ddid");
            inode.InnerText = Convert.ToInt32(((Label)row.FindControl("lblDCDetailID")).Text).ToString();
            element.AppendChild(inode);

            //_objDCD.DocumentNo = docNo;
            inode = doc.CreateElement("docno");
            inode.InnerText = docNo.ToString();
            element.AppendChild(inode);

            //_objDCD.BookCode = ((Label)row.FindControl("lblBookCode")).Text;
            inode = doc.CreateElement("bcode");
            inode.InnerText = ((Label)row.FindControl("lblBookCode")).Text.ToString();
            element.AppendChild(inode);

            //_objDCD.BookName = ((Label)row.FindControl("lblBookName")).Text;
            inode = doc.CreateElement("bname");
            inode.InnerText = ((Label)row.FindControl("lblBookName")).Text.ToString();
            element.AppendChild(inode);

            //_objDCD.Standard = ((Label)row.FindControl("lblStandard")).Text;
            inode = doc.CreateElement("stand");
            inode.InnerText = ((Label)row.FindControl("lblStandard")).Text.ToString();
            element.AppendChild(inode);

            //_objDCD.Medium = ((Label)row.FindControl("lblMedium")).Text;
            inode = doc.CreateElement("medi");
            inode.InnerText = ((Label)row.FindControl("lblMedium")).Text.ToString();
            element.AppendChild(inode);

            Reqty = Convert.ToInt32(((TextBox)row.FindControl("txtquty")).Text);
            givqty = Convert.ToInt32(((Label)row.FindControl("lblgivedqty")).Text);
            inode = doc.CreateElement("qty");
            inode.InnerText = Convert.ToInt32(Reqty + givqty).ToString();
            element.AppendChild(inode);

            inode = doc.CreateElement("bokid");
            inode.InnerText = ((Label)row.FindControl("lblBookid")).Text.ToString();
            element.AppendChild(inode);


            //_objDCD.Quantity = Reqty + givqty;
            //// string DDate = ((TextBox)row.FindControl("txtDeldate")).Text;
            //// DDate = DDate.Split('/')[1] + "/" + DDate.Split('/')[0] + "/" + DDate.Split('/')[2];
            string DDate = txtDeliverydte.Text.Split('/')[1] + "/" + txtDeliverydte.Text.Split('/')[0] + "/" + txtDeliverydte.Text.Split('/')[2];
            inode = doc.CreateElement("deld");
            inode.InnerText = Convert.ToDateTime(DDate).ToString();
            element.AppendChild(inode);

            //_objDCD.DeliveryDate = Convert.ToDateTime(DDate);
            //_objDCD.Rate = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text);
            inode = doc.CreateElement("rate");
            inode.InnerText = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text).ToString();
            element.AppendChild(inode);

            //_objDCD.Discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
            discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
            inode = doc.CreateElement("dis");
            inode.InnerText = Convert.ToDecimal(discount).ToString();
            element.AppendChild(inode);

            //amt = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Reqty;
            //Tdiscount = amt * (discount / 100);
            //amt = amt - Tdiscount;
            amt = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Reqty;
            Tdiscount = amt * (discount / 100);
            amt = amt - Tdiscount;

            if (((Label)row.FindControl("lblAmt")).Text != "")
            {
                //.Amount = Convert.ToDecimal(amt);
                inode = doc.CreateElement("amt");
                inode.InnerText = amt.ToString();
                element.AppendChild(inode);
            }
            else
            {
                //  _objDCD.Amount = 0;
                inode = doc.CreateElement("amt");
                inode.InnerText = 0.ToString();
                element.AppendChild(inode);
            }

            ////_objDCD.Publisher = ((Label)row.FindControl("lblPublisher")).Text;
            //_objDCD.CreatedBy = Convert.ToString(Session["UserName"]);
            inode = doc.CreateElement("us");
            inode.InnerText = Convert.ToString(Session["UserName"]).ToString();
            element.AppendChild(inode);
            //_objDCD.IsActive = true;
            inode = doc.CreateElement("act");
            inode.InnerText = Convert.ToBoolean(true).ToString();
            element.AppendChild(inode);
            //_objDCD.Save();
            fnode.AppendChild(element);
        }
        return xmlstr = fnode.OuterXml.ToString();
    }

    #endregion

    #region Validation Methods

    #region Variables

    private static bool add = false;
    private static bool view = false;
    private static bool edit = false;
    private static bool delete = false;

    #endregion

    public void GetValidation(int Menuid, int Roleid)
    {
        DataTable dt = new DataTable();
        dt = Mappings.Get_MenuFunctions(Menuid, Roleid).Tables[0];
        add = Convert.ToBoolean(dt.Rows[0]["Add"].ToString());
        view = Convert.ToBoolean(dt.Rows[0]["View"].ToString());
        edit = Convert.ToBoolean(dt.Rows[0]["Edit"].ToString());
        delete = Convert.ToBoolean(dt.Rows[0]["Delete"].ToString());
    }

    #endregion

    #region gridview events

    TextBox txtqty;
    TextBox txtrate;
    Label lblAmt;
    TextBox txtdisc;
    Label lbladddisc;
    Label lblQty;
    protected void grdBookDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            quantity = 0;
            tamount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            txtqty = (TextBox)e.Row.FindControl("txtquty");
            quantity = quantity + Convert.ToInt32(txtqty.Text.Trim());
            TextBox txtDeldate = (TextBox)e.Row.FindControl("txtDeldate");
            txtrate = (TextBox)e.Row.FindControl("txtrate");
            lblAmt = (Label)e.Row.FindControl("lblAmt");
            lblQty = (Label)e.Row.FindControl("lblgivedqty");
            tamount = tamount + Convert.ToDecimal(lblAmt.Text.Trim());
            txtdisc = (TextBox)e.Row.FindControl("txtDiscount");
            //  lbladddisc = (Label)e.Row.FindControl("txtAddDiscount");
            txtqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "','" + lblQty.ClientID + "')");
            tabindex = tabindex + 1;
            txtqty.Attributes.Add("TabIndex", tabindex.ToString());

            // txtDeldate.Attributes.Add("onkeyup", "multiplyQty(this," + lblrate.ClientID + "," + lblAmt.ClientID + "," + txtdisc.ClientID + ")");
            tabindex = tabindex + 1;
            txtDeldate.Attributes.Add("TabIndex", tabindex.ToString());

            txtrate.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "','" + lblQty.ClientID + "')");
            tabindex = tabindex + 1;
            txtrate.Attributes.Add("TabIndex", tabindex.ToString());

            txtdisc.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "','" + lblQty.ClientID + "')");
            tabindex = tabindex + 1;
            txtdisc.Attributes.Add("TabIndex", tabindex.ToString());




            if (e.Row.FindControl("lblgivedqty") != null)
            {
                Label lblconfirmQty = (Label)e.Row.FindControl("lblgivedqty");
                if (lblconfirmQty.Text != "0")
                {
                    ImageButton imgremovw = (ImageButton)e.Row.FindControl("btnRemove");
                    imgremovw.Visible = false;
                }

            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl1 = (Label)e.Row.FindControl("lblTotalqty");
            lbl1.Text = quantity.ToString().Trim();
            Label lblamt1 = (Label)e.Row.FindControl("lblTotalamt");
            lblamt1.Text = tamount.ToString().Trim();
            lblTotalqtyId.Text = lbl1.ClientID.ToString();
            lblTotalamtId.Text = lblamt1.ClientID.ToString();

        }


    }
    protected void grdBookDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DCDetails _objdcd = new DCDetails();
        DCDid = Convert.ToInt32(((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblDCDetailID")).Text);

        try
        {
            if (DCDid != 0)
            {
                _objdcd.DCDetailID = DCDid;
                _objdcd.IsActive = false;
                _objdcd.Amount = 0;
                _objdcd.Rate = 0;
                _objdcd.Discount = 0;

                _objdcd.Save();
            }
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["tempDCData"];
            dt1.Rows[e.RowIndex].Delete();
            grdBookDetails.DataSource = dt1;
            grdBookDetails.DataBind();
            Session["tempDCData"] = dt1;
            loder("Successfully Deleted...");


        }
        catch
        {


        }
    }
    #endregion
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        ModalPopUpDocNum.Show();
        TxtDocNo.Focus();
        Upanelcust.Update();
        Bindcustomer();
    }
    #region SelectedIndexChanged event


    public void AddRate()
    {
        string CustCode = txtcustomer.Text.ToString();
        DataTable dt = new DataTable();
        dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];
        if (dt.Rows.Count != 0)
        {


            if (dt.Rows[0]["State"].ToString().ToLower() == "maharashtra")
            {

                srate = "l";
            }
            else
            {
                srate = "m";

            }
        }
    }
    protected void DDLstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        AutoCompleteExtender1.ContextKey = "book_" + DDLstandard.SelectedItem.Text;
        txtbkcod.Focus();
    }
    protected void TxtcustCode_TextChanged(object sender, EventArgs e)
    {


    }
    public void Bindcustomer()
    {
        DDLCustomer.Items.Clear();
        DDLCustomer.DataSource = DCMaster.Get_Customer_PendingDocNo("Customer", Convert.ToInt32(strFY));
        DDLCustomer.DataBind();
        DDLCustomer.Items.Insert(0, new ListItem("-Select Customer-", "0"));
        ddldocno.Items.Clear();
        ddldocno.Items.Insert(0, new ListItem("-Select Docno-", "0"));
        DDLCustomer.Focus();

    }

    protected void DDLCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddldocno.Items.Clear();
        //ddldocno.DataSource = ActualInvoiceDetails.GetCustomer_OnView(Convert.ToInt32(DDLCustomer.SelectedValue), "EditDC")
        ddldocno.DataSource = ActualInvoiceDetails.GetCustomer_OnView(Convert.ToInt32(DDLCustomer.SelectedValue), "EditDC", Convert.ToInt32(strFY));
        ddldocno.DataBind();
        ddldocno.Items.Insert(0, new ListItem("-Select Docno-", "0"));
        ddldocno.Focus();

    }

    #endregion
}
