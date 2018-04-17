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
using Other_Z;
using System.Xml;

#endregion


public partial class UserControls_uc_DC_Master : System.Web.UI.UserControl
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
    //  static string srate = "";
    decimal discount;
    decimal Adddiscount;
    decimal Tdiscount;
    string flag1;
    static int tabindex = 20;
    static int quantity = 0;
    static decimal tamount = 0;
    string Description = "";
    string strChetanaCompanyName;
    string strFY;
    decimal Upperlimit;
    decimal Lowerlimit;
    decimal OuStanding;
    string xmlstr;

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["FY"] != null)
        {
            strFY = Session["FY"].ToString();

        }
        else
        {
            Session.Clear();
        }
        //Response.Write(strFY);



        if (!Page.IsPostBack)
        {
            GetValidation(3, Convert.ToInt32(Session["Role"]));
            string grp = "BookSet";
            DDLSelectSet.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
            DDLSelectSet.DataBind();
            DDLSelectSet.Items.Insert(0, new ListItem("-Select book set-", "0"));
            string std = "Standard";
            DDLstandard.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(std, "DropDown");
            DDLstandard.DataBind();
            DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
            DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));

            //Dropdown Bind Zone Code With Bookseller
            DDLZone.Items.Insert(0, new ListItem("-Select-", "0"));
            lblZoneCode.Visible = false;
            DDLZone.Visible = false;

            txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtChalDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtOrdDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDeliverydte.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdocDate.Focus();
            Session["tempDCData"] = null;
            Session["UpperCaseLowerCase"] = null;
            quantity = 0;
            tamount = 0;
            // btncancel.Visible = false;
            //Session["tempDCData"] = null;

        }
        if (add)
        {
            btn_Save.Enabled = true;
        }
        if (!view)
        {
            BtnGetDCDetails.Enabled = false;
        }
    }

    #endregion

    #region ButtonEvents

    protected void btnaddbk_Click(object sender, EventArgs e)
    {

    }

    protected void btnaddBooks_Click(object sender, EventArgs e)
    {
        bool chklimit = true;
        if (Convert.ToBoolean(lblchksplitdc.Text) == true)
        {
            if (grdBookDetails.Rows.Count > 0)
            {
                chklimit = SplitDCValidate();
            }
        }
        if (chklimit == true)
        {

            if (srate.Value == "")
            {
                MessageBox("Kindly select Customer");
                txtcustomer.Focus();
            }
            else
            {
                if (txtDeliverydte.Text != "")
                {
                    setStateGridview();
                    Qty = Convert.ToString(txtbookqty.Text.Trim());
                    string date = DateTime.Now.ToString("MM/dd/yyyy");
                    date = txtDeliverydte.Text.Split('/')[1] + "/" + txtDeliverydte.Text.Split('/')[0] + "/" + txtDeliverydte.Text.Split('/')[2];

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
                        if (txtbkcod.Text.Contains(":"))
                        {
                            bookname = txtbkcod.Text.Split(':')[2].Trim();
                        }
                        else
                        {
                            bookname = bookcode;
                        }


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
                                //MessageBox(bookcode.Trim());
                                //   txtcustomer.Focus();

                                Session["tempDCData"] = fillTempBookData(bookcode.Trim(), "");
                                dt1 = (DataTable)Session["tempDCData"];
                                loder(bookname + " added successfully", "3000");
                            }
                            else
                            {
                                loder(bookname + " already added!", "3000");

                            }
                        }
                        else
                        {
                            Session["tempDCData"] = fillTempBookData(bookcode.Trim(), "");
                            dt1 = (DataTable)Session["tempDCData"];
                            loder(bookname + " added successfully", "3000");
                        }
                        grdBookDetails.DataSource = dt1;
                        grdBookDetails.DataBind();
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

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            //if (grdBookDetails.Rows.Count == 0)
            //{
            //    MessageBox("Kindly fill Book details");
            //}
            //else
            //{
            Other_Z.DCMaster_cs.DCMasterProp _objDC = new Other_Z.DCMaster_cs.DCMasterProp();
            Other_Z.DCMaster_cs objBal = new DCMaster_cs();
            // _objDC.DocumentNo = Convert.ToInt32(txtdoc.Text.Trim());

            string DocumentDate = DateTime.Now.ToString("MM/dd/yyyy");
            string ChallanDate = DateTime.Now.ToString("MM/dd/yyyy");
            string OrderDate = DateTime.Now.ToString("MM/dd/yyyy");


            DocumentDate = txtdocDate.Text.Split('/')[1] + "/" + txtdocDate.Text.Split('/')[0] + "/" + txtdocDate.Text.Split('/')[2];
            // ChallanDate = txtChalDate.Text.Split('/')[1] + "/" + txtChalDate.Text.Split('/')[0] + "/" + txtChalDate.Text.Split('/')[2];
            OrderDate = txtOrdDate.Text.Split('/')[1] + "/" + txtOrdDate.Text.Split('/')[0] + "/" + txtOrdDate.Text.Split('/')[2];

            if (txtdoc.Text != "")
            {
                _objDC._DocumentNo = Convert.ToInt32(txtdoc.Text.Trim());
            }
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

            //Add Zone Code With Dropdown Value + Transport Id
            _objDC._TransportID = txttransporter.Text.Trim() + "!" + DDLZone.SelectedValue.ToString();
            if (lbltransporter.Text == "Trans")
            {
                _objDC._Transporter = lbltransporter.Text;
            }
            else { _objDC._Transporter = lbltransporter.Text.Trim(); }
            _objDC._SpInstruction = txtspInstruct.Text.Trim();

            _objDC._BankCode = txtbankdet.Text.Trim();
            _objDC._IsActive = true;
            _objDC._IsDeleted = false;
            _objDC._CreatedBy = Convert.ToString(Session["UserName"]);
            _objDC._UpdatedBy = "admin";
            _objDC._ChetanaCompanyName = strChetanaCompanyName;
            //we are using following field to pass Financial Year AutoId while saving
            _objDC._FinancialYearFrom = Convert.ToInt32(strFY);
            //Xml String
            _objDC.Xmldata = SaveDcDetail();

            //_objDC.Save(out DocNo);

            //Validate against Audit CutOffDate
            bool i = Global.ValidateDate(txtdocDate.Text);
            i = true;
            if (i == true)
            {

                if (SplitDCValidate() == true)
                {
                    //Save Final Save DCMaster And Details
                    objBal.SaveDCWithXml(_objDC, out DocNo, out DocNewNo);

                    txtdoc.Text = Convert.ToString(DocNo);
                    //SaveDCDetails(DocNo);
                    MessageBox("Record saved successfully \\r\\n Documennt no.  " + DocNewNo);
                    loder("Last saved Document no. : " + DocNewNo, "3000");
                    grdBookDetails.DataBind();
                    lblmsg.Text = "Last saved Document no. : " + DocNewNo;
                    ClearFields();
                    DDLSelectSet.SelectedValue = null;
                    Session["tempDCData"] = null;
                    Session["UpperCaseLowerCase"] = null;
                    quantity = 0;
                    tamount = 0;
                    srate.Value = "";
                    txtorder.Text = "";

                    txtorder.Focus();
                }
                else
                {
                    MessageBox("Can not create dc more than " + lblsplitval.Text + " amount.");
                    return;
                }

            }
            else
            {
                MessageBox("You cannot create DC with Token Date less than Cutoff Date :" + HttpContext.Current.Session["AuditCutOffDate"].ToString());
            }
        }
        // }
        catch (Exception ex)
        {
            MessageBox(ex.Message.ToString());
            string ermsg = ex.Message.ToString();
        }
    }

    protected void btngetset_Click(object sender, EventArgs e)
    {
        if (srate.Value == "")
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
                Qty = Convert.ToString(txtsetqty.Text.Trim());
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
                    loder("Kindly select bookset", "3000");
                    DDLSelectSet.Focus();
                }
                else
                {
                    try
                    {

                        //DataTable bookdescription = new DataTable();
                        //bookdescription = BookSetDetails.GetDescription_Of_bookset((Convert.ToInt32(DDLSelectSet.SelectedItem.Value)), "DC").Tables[0];
                        // Description = bookdescription.Rows[0]["Description"].ToString();
                        // txtspInstruct.Text = txtspInstruct.Text + " " + Description;
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
                        loder(DDLSelectSet.SelectedItem.Text + "(bookset) added successfully", "3000");
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

    protected void btncancel_Click(object sender, EventArgs e)
    {
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        Session["tempDCData"] = null;
        grdBookDetails.Dispose();
    }

    #endregion

    #region GetDC Details By DocNum

    protected void BtnGetDCDetails_Click(object sender, EventArgs e)
    {
        Session["tempDCData"] = null;
        int DocNum = Convert.ToInt32(TxtDocNo.Text.ToString());


        DataTable dt = new DataTable();
        //  bool condition = false;

        dt = DCMaster.Get_DCMasterBy_DocNum(DocNum, "0").Tables[0];

        if (dt.Rows.Count > 0)
        {
            txtdoc.Text = dt.Rows[0]["DocumentNo"].ToString();
            txtchalan.Text = dt.Rows[0]["ChallanNo"].ToString();
            txtChalDate.Text = dt.Rows[0]["ChallanDate"].ToString();
            txtorder.Text = dt.Rows[0]["OrderNo"].ToString();
            txtcustomer.Text = dt.Rows[0]["CustCode"].ToString();
            lblCustName.Text = dt.Rows[0]["CustName"].ToString();
            // txtsalemanCode.Text = dt.Rows[0]["SalesmanCode"].ToString();
            // lblSalesManName.Text = dt.Rows[0]["SalesmanName"].ToString();
            txtOrdDate.Text = dt.Rows[0]["OrderDate"].ToString();
            txtdocDate.Text = dt.Rows[0]["DocumentDate"].ToString();
            txtpIncharge.Text = dt.Rows[0]["PIncharge"].ToString();
            txtspInstruct.Text = dt.Rows[0]["SpInstruction"].ToString();
            txtbankdet.Text = dt.Rows[0]["BankCode"].ToString();
            lblbankname.Text = dt.Rows[0]["BankName"].ToString();
            // Bind_DDL_Transport();
            //  Ddltransport.SelectedValue = dt.Rows[0]["TransportID"].ToString();
            txttransporter.Text = dt.Rows[0]["TransporterCode"].ToString();
            lbltransporter.Visible = true;
            lbltransporter.Text = dt.Rows[0]["Transporter"].ToString();

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
            //DataTable dt3 = new DataTable();
            //dt3 = ds.Tables[0];
            //Session["tempDCData"] = dt3;
            grdBookDetails.Visible = true;
            //  btn_Save.Visible = false;

        }
        else
        {
            message("Record not found for document no. " + TxtDocNo.Text);
            TxtDocNo.Text = "";
            TxtDocNo.Focus();
        }
    }

    #endregion

    #region TextChanged Events
    protected void txtbankdet_TextChanged(object sender, EventArgs e)
    {
        try
        {

            string BankCode = txtbankdet.Text.ToString().Split(':')[0].Trim();

            DataTable dt = new DataTable();
            dt = DCMaster.Get_Name(BankCode, "Bank").Tables[0];
            if (dt.Rows.Count != 0)
            {
                txtbankdet.Text = BankCode;
                lblbankname.Text = Convert.ToString(dt.Rows[0]["BankName"]);
                txtDeliverydte.Focus();

            }


            else
            {
                lblbankname.Text = "No such Bank code";
                txtbankdet.Focus();
                txtbankdet.Text = "";
            }
        }
        catch
        {


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
    //    if (dt.Rows.Count != 0)c 
    //    {
    //        txtsalemanCode.Text = ECode;
    //        Cust_AutoCompleteExtender.ContextKey = ECode;
    //        lblSalesManName.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
    //        txtcustomer.Focus();
    //    }
    //    else
    //    {
    //        lblSalesManName.Text = "No such salesman code";
    //        txtsalemanCode.Focus();
    //        txtsalemanCode.Text = "";
    //    }


    //}
    //protected void txtcustomer_TextChanged(object sender, EventArgs e)
    //{
    //    string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
    //    DataTable dt = new DataTable();
    //    dt = DCMaster.Get_Name(CustCode, "Customer").Tables[0];

    //    if (dt.Rows.Count != 0)
    //    {
    //        txtcustomer.Text = CustCode;
    //        lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
    //        if (dt.Rows[0]["State"].ToString().ToLower() == "maharashtra" || dt.Rows[0]["State"].ToString().ToLower() == "")
    //        {
    //            srate = "l";
    //        }
    //        else
    //        {
    //            srate = "m";
    //        }
    //        //txtpIncharge.Focus();
    //      //  ACExttransporter.ContextKey = CustCode;
    //        DDlemployee.Items.Clear();
    //        DDlemployee.DataSource = DCMaster.Get_Employee_By_Customer_Code(CustCode, "Employee");
    //        DDlemployee.DataBind();
    //        DDlemployee.Items.Insert(0,new ListItem("-Select-","0"));
    //        DDlemployee.Focus();  
    //        //Get_Employee_By_Customer_Code
    //       // TextBox1_AutoCompleteExtender.ContextKey = CustCode;
    //       //    Bind_DDL_Transport();
    //    }



    //    else
    //    {
    //        lblCustName.Text = "No such Customer code";
    //        txtcustomer.Focus();
    //        txtcustomer.Text = "";
    //        srate = "";
    //    }
    //}

    protected void txtcustomer_TextChanged(object sender, EventArgs e)
    {
        //Zaid
        //string CustCode = txtcustomer.Text.ToString().Split(':')[0].Trim();
        //DataTable dt = new DataTable();
        //dt = DCMaster.Get_Name(CustCode, "Customer!" + Convert.ToInt32(Session["FY"])).Tables[0];

        //if (dt.Rows.Count > 0)
        //{
        //    if (Convert.ToString(dt.Rows[0]["BlackList"]).ToLower() != "true")
        //    {
        //        txtcustomer.Text = CustCode;
        //        lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
        //        if (dt.Rows[0]["State"].ToString().ToLower() == "maharashtra" || dt.Rows[0]["State"].ToString().ToLower() == "")
        //        {
        //            srate.Value = "l";

        //        }
        //        else
        //        {
        //            srate.Value = "m";
        //        }

        //        //txtpIncharge.Focus();
        //        ACExttransporter.ContextKey = CustCode;
        //        DataSet empds = new DataSet();
        //        empds = DCMaster.Get_Employee_By_Customer_Code(CustCode, "Employee");
        //        DDlemployee.Items.Clear();
        //        DDlemployee.DataSource = empds.Tables[0];
        //        DDlemployee.DataBind();
        //        DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));
        //        DDlemployee.Focus();
        //        if (empds.Tables[1].Rows.Count > 0)
        //        {
        //            txttransporter.Text = empds.Tables[1].Rows[0]["Value"].ToString();
        //            lbltransporter.Text = "Trans";
        //            lbltransporter.Visible = false;
        //        }
        //        else
        //        {
        //            txttransporter.Text = "";
        //            lbltransporter.Text = "";
        //            lbltransporter.Visible = true;
        //        }
        //        //Get_Employee_By_Customer_Code
        //        // TextBox1_AutoCompleteExtender.ContextKey = CustCode;
        //        //    Bind_DDL_Transport();
        //        // DCMaster.Get_Transporter(custcode);
        //    }
        //    else
        //    {
        //        lblCustName.Text = "Customer is blacklisted";
        //        txtcustomer.Focus();
        //        txtcustomer.Text = "";
        //        srate.Value = "";
        //    }
        //}
        //else
        //{
        //    lblCustName.Text = "No such Customer code";
        //    txtcustomer.Focus();
        //    txtcustomer.Text = "";
        //    srate.Value = "";
        //}
    }

    #region Trasnpoter Text Change Event
    protected void txttransporter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txttransporter.Text != "")
            {
                string TransCode = txttransporter.Text.ToString().Split(':', '[', ']')[0].Trim();
                flag1 = txttransporter.Text.ToString().Split('[', ']')[1].Trim();
                txttransporter.Text = TransCode;

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
                        lbltransporter.Text = "No such record found";
                        txttransporter.Focus();
                        txttransporter.Text = "";
                    }
                    //   Bind_DDL_Transport();
                }
                else
                {
                    lbltransporter.Visible = false;
                    lbltransporter.Text = flag1;
                    //lbltransporter.Text = "";
                }
            }
            else
            {

                lbltransporter.Text = "No such record found";
                txttransporter.Text = "";
                txtbankdet.Focus();
            }

        }
        catch
        {
            txttransporter.Text = "";
            txtbankdet.Focus();
            lbltransporter.Text = "No such record found";
        }
        txtbankdet.Focus();
    }
    #endregion


    protected void TxtEmpCode_TextChanged(object sender, EventArgs e)
    {
        string ECode = TxtEmpCode.Text.ToString();

    }
    //protected void RdbLRate_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    UpdRate.Update();
    //    srate = RdbLRate.SelectedValue.ToString();

    //}

    #endregion

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
            dt.Columns.Add("HSNCode");
            dt.Columns.Add("GST");
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
            tempGetData = BookSetDetails.Get_BookSetDetailsOn_SetID_ForDC((Convert.ToInt32(DDLSelectSet.SelectedItem.Value)), srate.Value).Tables[0];
            //  GetDescription_Of_bookset

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


            tempGetData = Books.Get_BooksMasterForDC(bookcode, srate.Value).Tables[0];
            //MessageBox(srate.Value);

        }

        foreach (DataRow row in tempGetData.Rows)
        {

            price = row["SellingPrice"].ToString();
            if (price == "")
            {
                price = "0";
            }
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
                        //  rqty = row["RemainQty"].ToString();
                        //  gqty = row["GivedQty"].ToString();
                        dcid = row["DCDetailID"].ToString();
                        string EDate = row["DeliveryDate"].ToString();
                        EDate = EDate.Split('/')[1] + "/" + EDate.Split('/')[0] + "/" + EDate.Split('/')[2];
                        Delidate = Convert.ToDateTime(EDate);
                        price = row["SellingPrice"].ToString();
                        amt = Convert.ToDecimal(row["Amount"].ToString());

                    }

                    dt.Rows.Add(dcid, row["HSNCode"].ToString(), row["GST"].ToString(), row["Bookid"].ToString(), row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), Qty, gqty, Qty, Delidate.ToString("dd/MM/yyyy"), String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:0.00}", Convert.ToDecimal(amt)), String.Format("{0:0.00}", Convert.ToDecimal(discount)), String.Format("{0:0.00}", Convert.ToDecimal(Adddiscount)));

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
                    // rqty = row["RemainQty"].ToString();
                    // gqty = row["GivedQty"].ToString();
                    dcid = row["DCDetailID"].ToString();
                    string EDate = row["DeliveryDate"].ToString();
                    EDate = EDate.Split('/')[1] + "/" + EDate.Split('/')[0] + "/" + EDate.Split('/')[2];
                    Delidate = Convert.ToDateTime(EDate);
                    price = row["SellingPrice"].ToString();
                    amt = Convert.ToDecimal(row["Amount"].ToString());

                }
                dt.Rows.Add(dcid, row["HSNCode"].ToString(), row["GST"].ToString(), row["Bookid"].ToString(), row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), Qty, gqty, Qty, Delidate.ToString("dd/MM/yyyy"), String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:0.00}", Convert.ToDecimal(amt)), String.Format("{0:0.00}", Convert.ToDecimal(discount)), String.Format("{0:0.00}", Convert.ToDecimal(Adddiscount)));
            }
        }
        return dt;
    }

    #endregion

    #region Methods
    public void ClearFields()
    {
        txtdoc.Text = "";
        // txtchalan.Text = "";
        txtorder.Text = "";
        txtcustomer.Text = "";
        lblCustName.Text = "";
        DDlemployee.Items.Clear();
        DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));
        DDLstandard.Items.Clear();
        DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
        // DDlemployee.SelectedValue = "0";
        //  txtsalemanCode.Text = "";
        //  lblSalesManName.Text = "";
        txtpIncharge.Text = "";
        txtspInstruct.Text = "";
        txttransporter.Text = "";
        lbltransporter.Text = "";
        txtbankdet.Text = "";
        lblbankname.Text = "";
        DDLSelectSet.SelectedValue = "0";
        txtsetqty.Text = "";
        txtDeliverydte.Text = "";
        txtOrdDate.Text = "";
        lblOutstanding.Text = "0.00";
        DDLZone.Items.Clear();
        lblZoneCode.Visible = false;
        DDLZone.Visible = false;
        lblsplitval.Text = "0.0";
        lblchksplitdc.Text = "false";
        //UpdatePanel5.Update();
        //UpdatePanel6.Update();  
    }
    private void setStateGridview()
    {
        DataColumn colTax = new DataColumn();
        colTax.DataType = System.Type.GetType("System.String");
        colTax.ColumnName = "Rate";
        DataTable _d = new DataTable();
        _d.Columns.Add("DCDetailID");
        _d.Columns.Add("HSNCode");
        _d.Columns.Add("GST");
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
            //  string amt1;
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
            ((Label)row.FindControl("lblHNSCode")).Text,
            ((Label)row.FindControl("lblGstPer")).Text,
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

    #region Check Split DC Value Of Master Of Master And Group splitdc

    private bool SplitDCValidate()
    {
        bool chkSplitdc = false;
        decimal total = 0;
        foreach (GridViewRow row in grdBookDetails.Rows)
        {
            Reqty = Convert.ToInt32(((TextBox)row.FindControl("txtquty")).Text);
            discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
            amt = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Reqty;
            Tdiscount = amt * (discount / 100);
            //amt = amt - Tdiscount;
            total += amt - Tdiscount;
        }

        // MessageBox("amt" + lblsplitval.Text );
        // MessageBox("DC amount" + amt);

        if (Convert.ToBoolean(lblchksplitdc.Text) == false)
        {
            return true;
        }
        else if (Convert.ToBoolean(lblchksplitdc.Text) == true && total >= Convert.ToDecimal(lblsplitval.Text))
        {
            MessageBox("Can not create dc more than " + lblsplitval.Text + " amount.");
            chkSplitdc = false;
        }
        else
        {
            return true;
        }

        return chkSplitdc;
    }

    #endregion


    #region Validation UpperCase And Lower Case Validation
    private bool ValidationUpperCaseLowerCase()
    {
        bool CheckUpperCase = false;
        bool CheckLowerCase = false;

        foreach (GridViewRow row in grdBookDetails.Rows)
        {
            Reqty = Convert.ToInt32(((TextBox)row.FindControl("txtquty")).Text);
            discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
            amt = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Reqty;
            Tdiscount = amt * (discount / 100);
            amt = amt - Tdiscount;
        }
        DataTable dt = Session["UpperCaseLowerCase"] as DataTable;
        if (dt.Rows.Count > 0)
        {
            Upperlimit = Convert.ToDecimal(dt.Rows[0]["UpperCase"].ToString() == "" ? "0" : dt.Rows[0]["UpperCase"].ToString());
            Lowerlimit = Convert.ToDecimal(dt.Rows[0]["LowerCase"].ToString() == "" ? "0" : dt.Rows[0]["LowerCase"].ToString());
            OuStanding = Convert.ToDecimal(dt.Rows[0]["OutStanding"].ToString() == "" ? "0" : dt.Rows[0]["OutStanding"].ToString());
            amt = amt + OuStanding;
            if (Lowerlimit != Convert.ToInt32("0"))
            {
                if (amt <= Lowerlimit)
                {
                    MessageBox("DC " + amt + " is less than " + Lowerlimit.ToString("0.00").TrimEnd('0').TrimEnd('.') + " allowed for this customer Kindly contact Billing Department Head for the same");
                    CheckLowerCase = false;
                }
                else
                {
                    CheckLowerCase = true;
                }
            }
            else
            {
                CheckLowerCase = true;
            }

            if (Upperlimit != Convert.ToInt32("0"))
            {
                if (Upperlimit <= amt)
                {
                    MessageBox("DC " + amt + " is more than " + Upperlimit.ToString("0.00").TrimEnd('0').TrimEnd('.') + " allowed for this customer. Kindly contact Billing Department Head for the same.");
                    CheckUpperCase = false;
                }
                else
                {
                    CheckUpperCase = true;
                }
            }
            else
            {
                CheckUpperCase = true;
            }
        }

        return (CheckUpperCase && CheckLowerCase);
    }
    #endregion

    #region Save DC Details

    //public void SaveDCDetails(int docNo)
    //{
    //    setStateGridview();
    //    DCDetails _objDCD = new DCDetails();

    //    foreach (GridViewRow row in grdBookDetails.Rows)
    //    {
    //        _objDCD.DCDetailID = Convert.ToInt32(((Label)row.FindControl("lblDCDetailID")).Text);
    //        _objDCD.DocumentNo = docNo;
    //        _objDCD.BookCode = ((Label)row.FindControl("lblBookCode")).Text;
    //        _objDCD.BookName = ((Label)row.FindControl("lblBookName")).Text;
    //        _objDCD.Standard = ((Label)row.FindControl("lblStandard")).Text;
    //        _objDCD.Medium = ((Label)row.FindControl("lblMedium")).Text;
    //        Reqty = Convert.ToInt32(((TextBox)row.FindControl("txtquty")).Text);
    //        givqty = Convert.ToInt32(((Label)row.FindControl("lblgivedqty")).Text);
    //        _objDCD.Quantity = Reqty + givqty;
    //        string DDate = ((TextBox)row.FindControl("txtDeldate")).Text;
    //        DDate = DDate.Split('/')[1] + "/" + DDate.Split('/')[0] + "/" + DDate.Split('/')[2];


    //        _objDCD.DeliveryDate = Convert.ToDateTime(DDate);
    //        _objDCD.Rate = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text);
    //        _objDCD.Discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
    //        discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);

    //        // amt = Convert.ToDecimal(((Label)row.FindControl("lblAmt")).Text);
    //        // rate = Convert.ToDecimal(((Label)row.FindControl("lblRate")).Text);
    //        // qty1 = Convert.ToDecimal(((TextBox)row.FindControl("txtquty")).Text);
    //        amt = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Reqty;
    //        Tdiscount = amt * (discount / 100);
    //        amt = amt - Tdiscount;

    //        if (((Label)row.FindControl("lblAmt")).Text != "")
    //        {
    //            _objDCD.Amount = Convert.ToDecimal(amt);
    //        }
    //        else
    //        {
    //            _objDCD.Amount = 0;
    //        }

    //        //_objDCD.Publisher = ((Label)row.FindControl("lblPublisher")).Text;
    //        _objDCD.IsActive = true;
    //        _objDCD.CreatedBy = Convert.ToString(Session["UserName"]);
    //        _objDCD.Save();

    //    }
    //}

    #endregion

    #region Dc Details Save With Xml Data

    private string SaveDcDetail()
    {

        setStateGridview();

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
            //inode = doc.CreateElement("docno");
            //inode.InnerText = docNo.ToString();
            //element.AppendChild(inode);

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

            givqty = Convert.ToInt32(((Label)row.FindControl("lblgivedqty")).Text);
            Reqty = Convert.ToInt32(((TextBox)row.FindControl("txtquty")).Text);
            inode = doc.CreateElement("qty");
            inode.InnerText = Convert.ToInt32(Reqty + givqty).ToString();
            element.AppendChild(inode);

            inode = doc.CreateElement("bokid");
            inode.InnerText = ((Label)row.FindControl("lblBookid")).Text.ToString();
            element.AppendChild(inode);

            inode = doc.CreateElement("hsn");
            inode.InnerText = ((Label)row.FindControl("lblHNSCode")).Text.ToString();
            element.AppendChild(inode);


            inode = doc.CreateElement("gst");
            inode.InnerText = ((Label)row.FindControl("lblGstPer")).Text.ToString();
            element.AppendChild(inode);

            //givqty = Convert.ToInt32(((Label)row.FindControl("lblgivedqty")).Text);
            //inode = doc.CreateElement("gqty");
            //inode.InnerText = Convert.ToInt32(givqty).ToString();
            //element.AppendChild(inode);

            ////_objDCD.Quantity = Reqty + givqty;
            //inode = doc.CreateElement("rq");
            //inode.InnerText = Reqty + givqty.ToString();
            //element.AppendChild(inode);

            //_objDCD.DeliveryDate = Convert.ToDateTime(DDate);

            string DDate = ((TextBox)row.FindControl("txtDeldate")).Text;
            DDate = DDate.Split('/')[1] + "/" + DDate.Split('/')[0] + "/" + DDate.Split('/')[2];
            inode = doc.CreateElement("deld");
            inode.InnerText = Convert.ToDateTime(DDate).ToString();
            element.AppendChild(inode);

            //_objDCD.Rate = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text);
            inode = doc.CreateElement("rate");
            inode.InnerText = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text).ToString();
            element.AppendChild(inode);

            //_objDCD.Discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
            discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);

            inode = doc.CreateElement("dis");
            inode.InnerText = Convert.ToDecimal(discount).ToString();
            element.AppendChild(inode);

            amt = Convert.ToDecimal(((TextBox)row.FindControl("txtrate")).Text) * Reqty;
            Tdiscount = amt * (discount / 100);
            amt = amt - Tdiscount;

            if (((Label)row.FindControl("lblAmt")).Text != "")
            {
                // _objDCD.Amount = Convert.ToDecimal(amt);
                inode = doc.CreateElement("amt");
                inode.InnerText = amt.ToString();
                element.AppendChild(inode);
            }
            else
            {
                // _objDCD.Amount = 0;
                inode = doc.CreateElement("amt");
                inode.InnerText = 0.ToString();
                element.AppendChild(inode);
            }

            ////_objDCD.Publisher = ((Label)row.FindControl("lblPublisher")).Text;

            //_objDCD.IsActive = true;
            inode = doc.CreateElement("act");
            inode.InnerText = Convert.ToBoolean(true).ToString();
            element.AppendChild(inode);

            //_objDCD.CreatedBy = Convert.ToString(Session["UserName"]);
            inode = doc.CreateElement("us");
            inode.InnerText = Convert.ToString(Session["UserName"]).ToString();
            element.AppendChild(inode);

            fnode.AppendChild(element);
        }

        return xmlstr = fnode.OuterXml.ToString();
    }

    #endregion


    #region Token TextChange Event Get Details
    protected void txtchalan_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtorder_TextChanged(object sender, EventArgs e)
    {
        setDetailsBasedOnTokenNo();
        return;
        #region "Old Code"


        Other_Z.DCMaster_cs ObjBAL = new Other_Z.DCMaster_cs();
        DataSet ds = ObjBAL.GetDCOrderNoAuthentication(txtorder.Text.Trim(), Convert.ToInt32(strFY), "");
        DataTable dt = ds.Tables[0];
        if (dt.Columns.Contains("1"))
        {
            MessageBox(dt.Rows[0][0].ToString());
            txtorder.Text = "";
            txtcustomer.Text = "";
            lblCustName.Text = "";
            lblOutstanding.Text = "0";
            txttransporter.Text = "";
            lbltransporter.Text = "";
            DDLstandard.Items.Clear();
            DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
            DDlemployee.Items.Clear();
            DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));
            txtOrdDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDeliverydte.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DDLZone.Items.Clear();
            lblZoneCode.Visible = false;
            DDLZone.Visible = false;
            txtorder.Focus();
            return;
        }
        else
        {
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(dt.Rows[0]["BlackList"]).ToLower() != "true")
                {
                    // txtcustomer.Text = CustCode;
                    // lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
                    if (dt.Rows[0]["State"].ToString().ToLower() == "maharashtra" || dt.Rows[0]["State"].ToString().ToLower() == "")
                    {
                        srate.Value = "l";
                    }
                    else
                    {
                        srate.Value = "m";
                    }

                    if (!ds.Tables[1].Columns.Contains("NotBook"))
                    {
                        lblZoneCode.Visible = true;
                        DDLZone.Visible = true;
                        DDLZone.Items.Clear();
                        DDLZone.DataSource = ds.Tables[1];
                        DDLZone.DataBind();
                    }
                    else
                    {
                        DDLZone.Items.Clear();
                        lblZoneCode.Visible = false;
                        DDLZone.Visible = false;
                    }

                    txtcustomer.Text = dt.Rows[0]["CustCode"].ToString();
                    txtOrdDate.Text = dt.Rows[0]["Ord_Rec_Date"].ToString();
                    string OrderDate = txtOrdDate.Text.Split('/')[0] + "/" + txtOrdDate.Text.Split('/')[1] + "/" + txtOrdDate.Text.Split('/')[2];
                    txtOrdDate.Text = OrderDate;
                    txtDeliverydte.Text = dt.Rows[0]["DeliveryDate"].ToString();
                    string DeliveryDate = txtDeliverydte.Text.Split('/')[0] + "/" + txtDeliverydte.Text.Split('/')[1] + "/" + txtDeliverydte.Text.Split('/')[2];
                    txtDeliverydte.Text = DeliveryDate.ToString();
                    txtcustomer.Text = dt.Rows[0]["CustCode"].ToString();
                    lblCustName.Text = dt.Rows[0]["CustName"].ToString();
                    //txtpIncharge.Text = dt.Rows[0][""].ToString();
                    Upperlimit = Convert.ToDecimal(dt.Rows[0]["UpperCase"].ToString() == "" ? "0" : dt.Rows[0]["UpperCase"].ToString());
                    Lowerlimit = Convert.ToDecimal(dt.Rows[0]["LowerCase"].ToString() == "" ? "0" : dt.Rows[0]["LowerCase"].ToString());
                    lblOutstanding.Text = Convert.ToDecimal(dt.Rows[0]["OutStanding"] == "" ? "0" : dt.Rows[0]["OutStanding"]).ToString();

                    Session["UpperCaseLowerCase"] = dt;
                    txtcustomer.Enabled = false;

                    txttransporter.Text = dt.Rows[0]["Key"].ToString();
                    lbltransporter.Text = dt.Rows[0]["Value"].ToString();

                    DDLstandard.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown("Standard", "DropDown");
                    DDLstandard.DataBind();
                    DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
                    DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));

                    DDlemployee.Items.Clear();
                    DDlemployee.DataSource = DCMaster.Get_Employee_By_Customer_Code(txtcustomer.Text, "Employee");
                    DDlemployee.DataBind();
                    DDlemployee.Focus();
                }
                else
                {
                    lblCustName.Text = "Customer is blacklisted";
                    txtorder.Text = "";
                    txtcustomer.Text = "";
                    lblOutstanding.Text = "0";
                    txttransporter.Text = "";
                    lbltransporter.Text = "";
                    DDLstandard.Items.Clear();
                    DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
                    DDlemployee.Items.Clear();
                    DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));
                    txtOrdDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDeliverydte.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    DDLZone.Items.Clear();
                    lblZoneCode.Visible = false;
                    DDLZone.Visible = false;
                    srate.Value = "";

                    txtorder.Focus();
                    return;
                }
            }
            else
            {
                MessageBox("Invalid token number");
                txtorder.Text = "";
                txtcustomer.Text = "";
                lblCustName.Text = "";
                lblOutstanding.Text = "0";
                txttransporter.Text = "";
                lbltransporter.Text = "";
                DDLstandard.Items.Clear();
                DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
                DDlemployee.Items.Clear();
                DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));
                txtOrdDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDeliverydte.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DDLZone.Items.Clear();
                lblZoneCode.Visible = false;
                DDLZone.Visible = false;
                txtorder.Focus();
                return;
            }

        }
        #endregion
    }
    #endregion


    private void setDetailsBasedOnTokenNo()
    {

        Other_Z.DCMaster_cs ObjBAL = new Other_Z.DCMaster_cs();
        DataSet ds = ObjBAL.GetDCOrderNoAuthentication(txtorder.Text.Trim(), Convert.ToInt32(strFY), "");
        DataTable dt = ds.Tables[0];
        DataTable dt1 = ds.Tables[1];
        if (dt.Columns.Contains("1"))
        {
            MessageBox(dt.Rows[0][0].ToString());
            clearallfields();
            txtorder.Focus();
            return;
        }

        if (dt.Rows.Count > 0)
        {
            if (Convert.ToString(dt.Rows[0]["BlackList"]).ToLower() != "true")
            {
                string CustCode = dt.Rows[0]["CustCode"].ToString();
                txtcustomer.Text = CustCode;
                lblchksplitdc.Text = dt.Rows[0]["isSplit"].ToString();
                lblsplitval.Text = dt.Rows[0]["splitvalue"].ToString();

                lblCustName.Text = Convert.ToString(dt.Rows[0]["CustName"]);
                if (dt.Rows[0]["State"].ToString().ToLower() == "maharashtra" || dt.Rows[0]["State"].ToString().ToLower() == "")
                {
                    srate.Value = "l";

                }
                else
                {
                    srate.Value = "m";
                }

                Upperlimit = Convert.ToDecimal(dt.Rows[0]["UpperCase"].ToString() == "" ? "0" : dt.Rows[0]["UpperCase"].ToString());
                Lowerlimit = Convert.ToDecimal(dt.Rows[0]["LowerCase"].ToString() == "" ? "0" : dt.Rows[0]["LowerCase"].ToString());
                lblOutstanding.Text = Convert.ToDecimal(dt.Rows[0]["OutStanding"] == "" ? "0" : dt.Rows[0]["OutStanding"]).ToString();

                Session["UpperCaseLowerCase"] = dt;

                // set dates
                txtOrdDate.Text = dt.Rows[0]["Ord_Rec_Date"].ToString();
                string OrderDate = txtOrdDate.Text.Split('/')[0] + "/" + txtOrdDate.Text.Split('/')[1] + "/" + txtOrdDate.Text.Split('/')[2];
                txtOrdDate.Text = OrderDate;
                txtDeliverydte.Text = dt.Rows[0]["DeliveryDate"].ToString();
                string DeliveryDate = txtDeliverydte.Text.Split('/')[0] + "/" + txtDeliverydte.Text.Split('/')[1] + "/" + txtDeliverydte.Text.Split('/')[2];
                txtDeliverydte.Text = DeliveryDate.ToString();


                //txtpIncharge.Focus();
                ACExttransporter.ContextKey = CustCode;
                DataSet empds = new DataSet();
                empds = DCMaster.Get_Employee_By_Customer_Code(CustCode, "Employee");
                DDlemployee.Items.Clear();
                DDlemployee.DataSource = empds.Tables[0];
                DDlemployee.DataBind();
                DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));
                DDlemployee.Focus();
                if (empds.Tables[1].Rows.Count > 0)
                {
                    txttransporter.Text = empds.Tables[1].Rows[0]["Value"].ToString();
                    lbltransporter.Text = "Trans";
                    lbltransporter.Visible = false;
                }
                else
                {
                    txttransporter.Text = "";
                    lbltransporter.Text = "";
                    lbltransporter.Visible = true;
                }

                if (dt1.Rows.Count > 0)
                {
                    lblZoneCode.Visible = true;
                    DDLZone.Visible = true;
                    DDLZone.DataSource = dt1;
                    DDLZone.DataBind();

                }
                else
                {
                    lblZoneCode.Visible = false;
                    DDLZone.Visible = false;
                    DDLZone.Items.Clear();
                }

                //Get_Employee_By_Customer_Code
                // TextBox1_AutoCompleteExtender.ContextKey = CustCode;
                //    Bind_DDL_Transport();
                // DCMaster.Get_Transporter(custcode);
            }
            else
            {
                MessageBox("Customer is blacklisted");
                clearallfields();
                txtorder.Focus();
            }
        }
        else
        {

            MessageBox("Invalid token number");
            clearallfields();
            txtorder.Focus();
            return;



        }


    }

    private void clearallfields()
    {
        txtorder.Text = "";
        txtcustomer.Text = "";
        lblCustName.Text = "";
        lblOutstanding.Text = "0";
        txttransporter.Text = "";
        lbltransporter.Text = "";
        srate.Value = "";
        DDLstandard.Items.Clear();
        DDLstandard.Items.Insert(0, new ListItem("-STD-", "0"));
        DDlemployee.Items.Clear();
        DDlemployee.Items.Insert(0, new ListItem("-Select-", "0"));
        txtOrdDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDeliverydte.Text = DateTime.Now.ToString("dd/MM/yyyy");
        DDLZone.Items.Clear();
        lblZoneCode.Visible = false;
        DDLZone.Visible = false;
        lblsplitval.Text = "0.0";
    }


    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
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

    TextBox txtqty;
    TextBox txtrate;
    Label lblAmt;
    TextBox txtdisc;
    Label lbladddisc;

    #region gridview events
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

            tamount = tamount + Convert.ToDecimal(lblAmt.Text.Trim());
            txtdisc = (TextBox)e.Row.FindControl("txtDiscount");
            //  lbladddisc = (Label)e.Row.FindControl("txtAddDiscount");
            txtqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "')");
            tabindex = tabindex + 1;
            txtqty.Attributes.Add("TabIndex", tabindex.ToString());

            // txtDeldate.Attributes.Add("onkeyup", "multiplyQty(this," + txtrate.ClientID + "," + lblAmt.ClientID + "," + txtdisc.ClientID + ")");
            tabindex = tabindex + 1;
            txtDeldate.Attributes.Add("TabIndex", tabindex.ToString());

            txtrate.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "')");
            tabindex = tabindex + 1;
            txtrate.Attributes.Add("TabIndex", tabindex.ToString());

            txtdisc.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "')");
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

        setStateGridview();
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
            loder("Successfully Deleted...", "3000");


        }
        catch
        {


        }
    }

    protected void DDLstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        AutoCompleteExtender1.ContextKey = "book_" + DDLstandard.SelectedItem.Text;
        txtbkcod.Focus();
    }
    #endregion


}


