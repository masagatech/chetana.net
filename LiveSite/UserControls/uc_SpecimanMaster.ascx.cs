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

#endregion

public partial class UserControls_SpecimanMaster : System.Web.UI.UserControl
{
    #region Variables
    int DocNo;
    string Qty = "1";
    int Reqty, givqty;
    decimal amt;
    string rqty = "1";
    string bookname = "";
    string gqty = "0";
    string spcid = "0";
    string price;
    int booksetid = 0;
    string xmlstr;
   
    int SpecID;
    static string srate = "";
    int Quantity;
    decimal Amount;
    int tabindex = 20;
    static string Description = "";
    string strChetanaCompanyName = "cppl";
    string strFY;
    int DocNewNo;
    #endregion

    #region Page Load

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
            //Response.Write(strFY);

        }
        if (!Page.IsPostBack)
        {
            ViewState["srate"] = "";
            SetView();
            GetValidation(3, Convert.ToInt32(Session["Role"]));
            string grp = "BookSet";
            DDLSelectSet.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(grp, "DropDown");
            DDLSelectSet.DataBind();
            DDLSelectSet.Items.Insert(0, new ListItem("-Select book set-", "0"));
            string std = "Standard";
            DDlstandard.DataSource = Masterofmaster.Get_MasterOfMaster_ByGroup_ForDropdown(std, "DropDown");
            DDlstandard.DataBind();
            DDlstandard.Items.Insert(0, new ListItem("-STD-", "0"));
            txtdocDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtChalDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtOrdDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtorder.Focus();
            Session["tempBookData"] = null;

            // btncancel.Visible = false;
            //Session["tempBookData"] = null;
        }
        if (add)
        {
            btn_Save.Enabled = true;
        }
        if (!view)
        {
            BtnGetSpecimanDetails.Enabled = false;
        }
    }

    #endregion

    #region Events

    protected void btnaddbk_Click(object sender, EventArgs e)
    {

    }

    protected void btnaddBooks_Click(object sender, EventArgs e)
    {
        if (ViewState["srate"].ToString() == "")
        {
            MessageBox("Kindly select Employee");
            txtsalemanCode.Focus();
            ViewState["srate"] = "";
        }
        else
        {
            setStateGridview();
            Qty = Convert.ToString(txtbookqty.Text.Trim());
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
                grdBookDetails.Columns[7].Visible = true;
                grdBookDetails.Columns[8].Visible = true;

            }
            else
            {
                grdBookDetails.Columns[7].Visible = false;
                grdBookDetails.Columns[8].Visible = false;
            }
            try
            {
                
                string bookcode = txtbkcod.Text.Split(':')[0].Trim();
                bookname = txtbkcod.Text.Split(':')[2].Trim();

                DataTable dt1 = new DataTable();
                if (Session["tempBookData"] != null)
                {


                    dt1 = (DataTable)Session["tempBookData"];
                    DataView dv = new DataView(dt1);
                    dv.RowFilter = "BookCode = '" + bookcode.Trim() + "'";
                    int i = 0;
                    foreach (DataRowView row in dv)
                    {
                        i++;
                    }
                    if (i == 0)
                    {
                        Session["tempBookData"] = fillTempBookData(bookcode.Trim(), "");
                        dt1 = (DataTable)Session["tempBookData"];
                        loder(bookname + " added successfully");
                    }
                    else
                    {
                        loder(bookname + " already added!");

                    }
                }
                else
                {
                    Session["tempBookData"] = fillTempBookData(bookcode.Trim(), "");
                    dt1 = (DataTable)Session["tempBookData"];
                    loder(bookname + " added successfully");
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
    }

    protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        setStateGridview();
        SpecimanDetails _objsd1 = new SpecimanDetails();
        SpecID = Convert.ToInt32(((Label)grdBookDetails.Rows[e.RowIndex].FindControl("lblspecDetailID")).Text);

        try
        {
            if (SpecID != 0)
            {
                _objsd1.SpecimenDetailID = SpecID;
                _objsd1.IsActive = false;
                _objsd1.Amount = 0;
                _objsd1.Rate = 0;
                _objsd1.Discount = 0;
                _objsd1.Save();
            }

            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["tempBookData"];
            dt1.Rows[e.RowIndex].Delete();
            grdBookDetails.DataSource = dt1;
            grdBookDetails.DataBind();
            Session["tempBookData"] = dt1;
            loder("Successfully Deleted...");
        }
        catch
        {


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
                Specimen _objSepciman = new Specimen();
                // _objSepciman.DocumentNo = Convert.ToInt32(txtdoc.Text.Trim());

                string DocumentDate = txtdocDate.Text.Split('/')[1] + "/" + txtdocDate.Text.Split('/')[0] + "/" + txtdocDate.Text.Split('/')[2];
                string ChallanDate = txtChalDate.Text.Split('/')[1] + "/" + txtChalDate.Text.Split('/')[0] + "/" + txtChalDate.Text.Split('/')[2];
                string OrderDate = txtOrdDate.Text.Split('/')[1] + "/" + txtOrdDate.Text.Split('/')[0] + "/" + txtOrdDate.Text.Split('/')[2];
                if (txtdoc.Text != "")
                {
                    _objSepciman.DocumentNo = Convert.ToInt32(txtdoc.Text.Trim());
                }
                _objSepciman.DocumentDate = Convert.ToDateTime(DocumentDate);
                _objSepciman.ChallanNo = txtchalan.Text.Trim();
                _objSepciman.ChallanDate = Convert.ToDateTime(ChallanDate);
                // string ordno = txtorder.Text.Trim();
                //if (ordno == "")
                //{
                //    ordno = "0";
                //}
                _objSepciman.OrderNo = txtorder.Text.Trim();
                _objSepciman.OrderDate = Convert.ToDateTime(OrderDate);
                _objSepciman.SalesmanCode = txtsalemanCode.Text.Trim();
                _objSepciman.SpInstruction = txtspInstruct.Text.Trim();
                _objSepciman.IsActive = true;
                _objSepciman.IsDeleted = false;
                _objSepciman.CreatedBy = Convert.ToString(Session["UserName"]); ;
                _objSepciman.Description = Description;

                _objSepciman.FinancialYearFrom = Convert.ToInt32(strFY);
                _objSepciman.Save(out DocNo, 1, out DocNewNo);
               // _objSepciman.Save(out DocNo);
                txtdoc.Text = Convert.ToString(DocNo);
                SaveSpecimanDetails(DocNo);
                Other_Z.OtherBAL objBal = new Other_Z.OtherBAL();
                if (DDLSelectSet.SelectedValue != "0")
                {
                    objBal.SaveSalesmnBookSetLimit(xmlstr, txtsalemanCode.Text, Convert.ToInt32(strFY), Convert.ToString(Session["UserName"]), "Updatebookset", "");
                }

                MessageBox("Record saved successfully \\r\\n Documennt no.  " + txtdoc.Text);
               


                lblmsg.Text = "Last saved Document no. : " + txtdoc.Text;
                txtdoc.Text = "";
                txtchalan.Text = "";
                txtorder.Text = "";
                txtsalemanCode.Text = "";
                lblSalesManName.Text = "";
                txtorder.Focus();
                Session["tempBookData"] = null;
                grdBookDetails.DataSource = null;
                grdBookDetails.DataBind();
                upGridData.Update();
                DDLSelectSet.SelectedValue = "0";
                Description = "";

            }
        }
        catch (Exception ex)
        {
            string ermsg = ex.Message.ToString();
        }
    }

    protected void btngetset_Click(object sender, EventArgs e)
    {
	 //Validate Bookset
        if (DDLSelectSet.SelectedValue != "0")
        {
            Qty = Convert.ToString(txtsetqty.Text.Trim());
            if (Qty != "" && Qty != "0")
            {
                DataTable dt = Other_Z.OtherBAL.GetValidate_Speciman(Convert.ToInt32(DDLSelectSet.SelectedItem.Value), Qty, txtsalemanCode.Text.Trim(), 		Convert.ToInt32(strFY), "", "").Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0][0]) >= 0)
                    {

                    }
                    else
                    {
                        MessageBox("Out of Limit Book Set " + DDLSelectSet.SelectedItem + "\n Total Limit" + dt.Rows[0][1] + "\n Remaining Qty" + dt.Rows[0][2]);
                        txtsetqty.Text = "";
                        txtsetqty.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox("Please Set BookSet Limit " + DDLSelectSet.SelectedItem);
                    txtsetqty.Text = "";
                    txtsetqty.Focus();
                    return;
                }
            }
            else
            {
                MessageBox("Please Enter Quntity");
                txtsetqty.Focus();
                return;
            }
        }
        else
        {
            MessageBox("Please Select Book Set");
            DDLSelectSet.Focus();
            return;
        }	

        if (ViewState["srate"].ToString() == "")
        {
            MessageBox("Kindly select Employee");
            txtsalemanCode.Focus();
            ViewState["srate"] = "";
        }
        else
        {
            setStateGridview();
            Qty = Convert.ToString(txtsetqty.Text.Trim());
            if (Qty == "" || Qty == "0")
            {
                Qty = "1";
                rqty = "1";
            }
            if (txtsetqty.Text != "")
            {
                rqty = Convert.ToString(txtsetqty.Text);
                Qty = Convert.ToString(txtsetqty.Text);

            }
            if (txtdoc.Text != "")
            {
                grdBookDetails.Columns[7].Visible = true;
                grdBookDetails.Columns[8].Visible = true;
                // grdBookDetails.Columns[10].Visible = false;
            }
            else
            {
                grdBookDetails.Columns[7].Visible = false;
                grdBookDetails.Columns[8].Visible = false;
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
                    DataTable bookdescription = new DataTable();
                    bookdescription = BookSetDetails.GetDescription_Of_bookset((Convert.ToInt32(DDLSelectSet.SelectedItem.Value)), "Specimen").Tables[0];
                    Description = bookdescription.Rows[0]["Description"].ToString();
                   

                    DataTable dt1 = new DataTable();
                    if (Session["tempBookData"] != null)
                    {
                        Session["tempBookData"] = fillTempBookData("", "set");
                        dt1 = (DataTable)Session["tempBookData"];
                    }
                    else
                    {
                        Session["tempBookData"] = fillTempBookData("", "set");
                        dt1 = (DataTable)Session["tempBookData"];
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

                }
                catch
                {


                }
            }
        }
    }

    #endregion

    #region TextChanged Events

    protected void txtbkcod_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtsalemanCode_TextChanged(object sender, EventArgs e)
    {
        string ECode = txtsalemanCode.Text.ToString().Split(':')[0].Trim();


        DataTable dt = new DataTable();
        dt = Employee.Get_EmployeeName(ECode).Tables[0];

        if (dt.Rows.Count != 0)
        {
            txtsalemanCode.Text = ECode;
            lblSalesManName.Text = dt.Rows[0]["FirstName"] + " " + dt.Rows[0]["MiddleName"] + " " + dt.Rows[0]["LastName"];
            if (dt.Rows[0]["State"].ToString().ToLower() == "maharashtra")
            {

                ViewState["srate"] = "l";
            }
            else
            {
                ViewState["srate"] = "m";

            }
            txtspInstruct.Focus();
        }


        else
        {
            lblSalesManName.Text = "No such salesman code";
            txtsalemanCode.Focus();
            txtsalemanCode.Text = "";
            ViewState["srate"] = "";
        }


    }

    protected void TxtEmpCode_TextChanged(object sender, EventArgs e)
    {
        string ECode = TxtEmpCode.Text.ToString();

    }

    #endregion

    #region GetSpecimen Details By DocNum

    protected void BtnGetSpecimanDetails_Click(object sender, EventArgs e)
    {
        btn_Save.Visible = true;
        Session["tempBookData"] = null;
        int DocNum = Convert.ToInt32(TxtDocNo.Text.ToString());


        DataTable dt = new DataTable();
        // bool condition = false;

        dt = Specimen.Get_SpecimenMasterBy_DocNum(DocNum, "0").Tables[0];

        if (dt.Rows.Count > 0)
        {
            txtdoc.Text = dt.Rows[0]["DocumentNo"].ToString();
            txtchalan.Text = dt.Rows[0]["ChallanNo"].ToString();
            txtChalDate.Text = dt.Rows[0]["ChallanDate"].ToString();
            txtorder.Text = dt.Rows[0]["OrderNo"].ToString();
            txtsalemanCode.Text = dt.Rows[0]["SalesmanCode"].ToString();
            lblSalesManName.Text = dt.Rows[0]["SalesmanName"].ToString();
            txtOrdDate.Text = dt.Rows[0]["OrderDate"].ToString();
            txtdocDate.Text = dt.Rows[0]["DocumentDate"].ToString();
            txtspInstruct.Text = dt.Rows[0]["SpInstruction"].ToString();
            //DataSet ds = new DataSet();
            //ds = SpecimanDetails.GetSpecimenDatilsByEmpCode(Convert.ToString(DocNum), "documentno");

            DataTable dt1 = new DataTable();
            if (Session["tempBookData"] != null)
            {
                Session["tempBookData"] = fillTempBookData(DocNum.ToString(), "get");
                dt1 = (DataTable)Session["tempBookData"];
            }
            else
            {
                Session["tempBookData"] = fillTempBookData(DocNum.ToString(), "get");
                dt1 = (DataTable)Session["tempBookData"];
            }
            grdBookDetails.DataSource = dt1;
            grdBookDetails.DataBind();
            grdBookDetails.Columns[7].Visible = true;
            grdBookDetails.Columns[8].Visible = true;
            //DataTable dt3 = new DataTable();
            //dt3 = ds.Tables[0];
            //Session["tempBookData"] = dt3;
            grdBookDetails.Visible = true;
            //  btn_Save.Visible = false;

        }
        else
        {
            message("Record not found for document no. " + TxtDocNo.Text);
            TxtDocNo.Text = "";
            TxtDocNo.Focus();
            btn_Save.Visible = false;
        }
    }

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


        if (Session["tempBookData"] == null)
        {
            //CREATE NEW DATATABLE
            //ADD COLUMNS IN DATATABLE
            dt.Columns.Add("SpecimenDetailId");
            dt.Columns.Add("BookSetID");
            dt.Columns.Add("BookCode");
            dt.Columns.Add("BookName");
            //dt.Columns.Add("BookType");
            dt.Columns.Add("Standard");
            dt.Columns.Add("Medium");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("GivedQty");
            dt.Columns.Add("RemainQty");
            dt.Columns.Add(colTax);
            dt.Columns.Add("Amount");
            dt.Columns.Add("Discount");
            //ADD DATA AS PER COLUMNS
            //Books _objBooks = new Books();
        }
        else
        {
            dt = (DataTable)Session["tempBookData"];

        }
        if (flag == "set")
        {
            tempGetData = BookSetDetails.Get_BookSetDetailsOn_SetIDForSpec((Convert.ToInt32(DDLSelectSet.SelectedItem.Value)), ViewState["srate"].ToString()).Tables[0];
        }
        else if (flag == "get")
        {
            tempGetData = SpecimanDetails.GetSpecimenDatilsByEmpCode(bookcode, "documentno").Tables[0];
        }
        else
        {
            tempGetData = Books.Get_BooksMasterForspecimen(bookcode, ViewState["srate"].ToString()).Tables[0];

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
                    if (flag == "get")
                    {
                        Qty = row["Quantity"].ToString();
                        rqty = row["RemainQty"].ToString();
                        gqty = row["GivedQty"].ToString();
                        spcid = row["SpecimenDetailId"].ToString();
                        price = row["SellingPrice"].ToString();
                        amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(price);
                    }
                    dt.Rows.Add(spcid, Convert.ToInt32(row["BookSetID"].ToString()), row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), Qty, gqty, rqty, String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:.00}", amt), "0.00");

                }
            }
            else
            {
                if (flag == "get")
                {
                    Qty = row["Quantity"].ToString();
                    rqty = row["RemainQty"].ToString();
                    gqty = row["GivedQty"].ToString();
                    spcid = row["SpecimenDetailId"].ToString();
                    booksetid = Convert.ToInt32(row["BookSetID"].ToString());
                    price = row["SellingPrice"].ToString();
                    amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(price);
                }
                dt.Rows.Add(spcid, Convert.ToInt32(row["BookSetID"].ToString()), row["BookCode"].ToString(), row["BookName"].ToString(), row["Standard"].ToString(), row["Medium"].ToString(), Qty, gqty, rqty, String.Format("{0:0.00}", Convert.ToDecimal(row["SellingPrice"].ToString())), String.Format("{0:.00}", amt), "0.00");
            }
        }
        return dt;
    }

    #endregion

    #region Save Speciman Details

    public void SaveSpecimanDetails(int docNo)
    {
        setStateGridview();

        DataTable dt1 = new DataTable();
        dt1 = (DataTable)Session["tempBookData"];
        grdBookDetails.DataSource = dt1;
        grdBookDetails.DataBind();


        SpecimanDetails _objSD = new SpecimanDetails();

        XmlDocument doc = new XmlDocument();
        XmlNode inode = doc.CreateElement("f");
        XmlNode fnode = doc.CreateElement("r");

        foreach (GridViewRow row in grdBookDetails.Rows)
        {
            XmlNode element = doc.CreateElement("i");

            _objSD.SpecimenDetailID = Convert.ToInt32(((Label)row.FindControl("lblspecDetailID")).Text);
            _objSD.DocumentNo = docNo;
            _objSD.BookCode = ((Label)row.FindControl("lblBookCode")).Text;
            _objSD.BookName = ((Label)row.FindControl("lblBookName")).Text;
            _objSD.Standard = ((Label)row.FindControl("lblStandard")).Text;
            _objSD.Medium = ((Label)row.FindControl("lblMedium")).Text;
            Reqty = Convert.ToInt32(((TextBox)row.FindControl("txtquty")).Text);
            givqty = Convert.ToInt32(((Label)row.FindControl("lblgivedqty")).Text);
            _objSD.Quantity = Reqty + givqty;

            _objSD.Rate = Convert.ToDecimal(((Label)row.FindControl("lblRate")).Text);
            if (((Label)row.FindControl("lblAmt")).Text != "")
            {
                _objSD.Amount = Convert.ToDecimal(((Label)row.FindControl("lblAmt")).Text);
            }
            else
            {
                _objSD.Amount = 0;
            }
            _objSD.Discount = Convert.ToDecimal(((TextBox)row.FindControl("txtDiscount")).Text);
            //_objSD.Publisher = ((Label)row.FindControl("lblPublisher")).Text;
            _objSD.IsActive = true;
            _objSD.Save();

            inode = doc.CreateElement("bsi");
            inode.InnerText = Convert.ToInt32(((TextBox)row.FindControl("txtbooksetid")).Text).ToString();
            element.AppendChild(inode);

            inode = doc.CreateElement("q");
            inode.InnerText = Convert.ToInt32(((TextBox)row.FindControl("txtquty")).Text).ToString();
            element.AppendChild(inode);

            fnode.AppendChild(element);
        }
        xmlstr = fnode.OuterXml.ToString();
    }

    #endregion

    protected void btncancel_Click(object sender, EventArgs e)
    {
    }

    #region Authentication Event
    protected void txtchalan_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Specimen.GetChallanNoAuthentication(txtchalan.Text.Trim());
        if (Auth)
        {
            MessageBox("Challan no is already present");
            txtchalan.Text = "";
            txtchalan.Focus();
        }
        else
        {
            txtChalDate.Focus();
        }
    }


    protected void txtorder_TextChanged(object sender, EventArgs e)
    {
        bool Auth = Specimen.GetOrderNoAuthentication(txtorder.Text.Trim());
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

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');sloder('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    protected void btnclear_Click(object sender, EventArgs e)
    {

    }

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
    //TextBox txt;
    //Label lblrate;
    //Label lblAmt;


    TextBox txtqty;
    Label lblrate;
    Label lblAmt;
    protected void grdBookDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            Quantity = 0;
            Amount = 0;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            txtqty = (TextBox)e.Row.FindControl("txtquty");
            Quantity = Quantity + Convert.ToInt32(txtqty.Text.Trim());
            lblrate = (Label)e.Row.FindControl("lblRate");
            lblAmt = (Label)e.Row.FindControl("lblAmt");
            Amount = Amount + Convert.ToDecimal(lblAmt.Text.Trim());

            txtqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + lblrate.ClientID + "','" + lblAmt.ClientID + "')");
            tabindex = tabindex + 1;
            txtqty.Attributes.Add("TabIndex", tabindex.ToString());

            //txtqty.Attributes.Add("onkeyup", "multiplyQty('" + txtqty.ClientID + "','" + txtrate.ClientID + "','" + lblAmt.ClientID + "','" + txtdisc.ClientID + "')");
           // tabindex = tabindex + 1;
           // txtqty.Attributes.Add("TabIndex", tabindex.ToString());


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
            //lblTotalqty 
            //lblTotalamt
            //lbl1
           // lblamt1
            Label lblTotalqty = (Label)e.Row.FindControl("lblTotalqty");
            lblTotalqty.Text = Quantity.ToString().Trim();
            Label lblTotalamt = (Label)e.Row.FindControl("lblTotalamt");
            lblTotalamt.Text = Amount.ToString().Trim();
            lblTotalqtyId.Text = lblTotalqty.ClientID.ToString();
            lblTotalamtId.Text = lblTotalamt.ClientID.ToString();
        }
    }

    protected void grdBookDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        //{
        //    e.Row.TabIndex = -1;
        //    e.Row.Attributes["onclick"] = string.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex);
        //    e.Row.Attributes["onkeydown"] = "javascript:return SelectSibling(event);";
        //    e.Row.Attributes["onselectstart"] = "javascript:return false;";
        //}
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "Create D.C.";
                btn_Save.Visible = true;
                btnEdit1.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "Edit  D.C.";
                    btn_Save.Visible = false;
                    btnEdit1.Visible = true;
                }
        }
    }
    private void setStateGridview()
    {
        DataColumn colTax = new DataColumn();
        colTax.DataType = System.Type.GetType("System.String");
        colTax.ColumnName = "Rate";
        DataTable _d = new DataTable();
        _d.Columns.Add("SpecimenDetailId");
        _d.Columns.Add("BookSetID");
        _d.Columns.Add("BookCode");
        _d.Columns.Add("BookName");
        //dt.Columns.Add("BookType");
        _d.Columns.Add("Standard");
        _d.Columns.Add("Medium");
        _d.Columns.Add("Quantity");
        _d.Columns.Add("GivedQty");
        _d.Columns.Add("RemainQty");
        _d.Columns.Add(colTax);
        _d.Columns.Add("Amount");
        
        _d.Columns.Add("Discount");



        foreach (GridViewRow row in grdBookDetails.Rows)
        {
            string amt;
            if (((Label)row.FindControl("lblAmt")).Text != "")
            {
                amt = ((Label)row.FindControl("lblAmt")).Text;
            }
            else
            {
                amt = "0";
            }

            _d.Rows.Add(Convert.ToInt32(((Label)row.FindControl("lblspecDetailID")).Text),
            ((TextBox)row.FindControl("txtbooksetid")).Text,
            ((Label)row.FindControl("lblBookCode")).Text,
            ((Label)row.FindControl("lblBookName")).Text,
            ((Label)row.FindControl("lblStandard")).Text,
            ((Label)row.FindControl("lblMedium")).Text,
            ((Label)row.FindControl("lblavailable")).Text,
            ((Label)row.FindControl("lblgivedqty")).Text,
            ((TextBox)row.FindControl("txtquty")).Text,
            ((Label)row.FindControl("lblRate")).Text,
            Convert.ToDecimal(((TextBox)row.FindControl("txtquty")).Text) * Convert.ToDecimal(((Label)row.FindControl("lblRate")).Text),
            ((TextBox)row.FindControl("txtDiscount")).Text
            );



        }
        Session["tempBookData"] = null;
        Session["tempBookData"] = _d;
    }
    protected void DDlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        AutoCompleteExtender1.ContextKey = "book_" + DDlstandard.SelectedItem.Text;
        txtbkcod.Focus();
    }
}
