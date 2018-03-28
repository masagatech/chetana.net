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

public partial class UserControls_uc_Outward : System.Web.UI.UserControl
{
    #region Variables
    string flag;

    char TFlag;
    decimal TNo;
    string TCustName;
    string TAreaName;
    string ODdate;
    DateTime ddt;
    int DocNo;
    int OdMID;
    int OutDetailID;
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
            txtOutwardDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Session["tempODData"] = null;
            btnSave.Visible = false;
            txtOutwardDate.Focus();
            SetView();
        }
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pnlview.Visible = false;
                Pnlselect.Visible = true;
                GrdOD.DataBind();
                // pageName.InnerHtml = "ADD Book";
                //txtcode.Focus();
                //lblID.Text = "0";
                //Panel1.Visible = true;
                //pnlBookDetails.Visible = false;
                //btn_Save.Visible = true;
                //Label13.Visible = false;
                //Label14.Visible = false;
                //LblOldqty.Visible = false;
                //filter.Visible = false;
                //btnprint.Visible = false;
                //btnExport.Visible = false;
            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pnlview.Visible = true;
                    Pnlselect.Visible = false;
                    GrdOD.DataBind();
                    //pageName.InnerHtml = "View / Edit Book";
                    //filter.Focus();
                    //pnlBookDetails.Visible = true;
                    //Panel1.Visible = false;
                    //btn_Save.Visible = false;
                    //Label13.Visible = true;
                    //Label14.Visible = true;
                    //LblOldqty.Visible = true;
                    //filter.Visible = true;
                    //btnprint.Visible = true;
                    //btnExport.Visible = true;
                }
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {

        btnForceAdd.Visible = false;
        try
        {
            if (RdbtnSelect.SelectedValue == "Invoice")
            {
                flag = "I";
                TFlag = 'I';
                DataTable dt1 = new DataTable();
                dt1 = OutwardDetail.GetCustN_Invoice(Convert.ToDecimal(Txtno.Text.Trim()), Convert.ToInt32(strFY)).Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["Exist"].ToString().Trim() == "no")
                    {
                        lblCustName.Text = Convert.ToString(dt1.Rows[0]["CustName"]);
                        lblArea.Text = Convert.ToString(dt1.Rows[0]["AreaName"]);
                        Adddata(Txtno.Text.Trim());
                        Txtno.Focus();
                    }
                    else
                    {
                        message("Invoice No has already been added to OUT Ward Entry. Document No for the same is "
                      + dt1.Rows[0]["RefOut"]);
                        Txtno.Focus();

                    }
                }
                else
                {
                    btnSave.Visible = false;
                    message("Records Not Available");
                    Txtno.Focus();
                }
            }
            if (RdbtnSelect.SelectedValue == "Document")
            {
                flag = "D";
                TFlag = 'D';
                DataTable dt2 = new DataTable();
                try
                {
                    dt2 = OutwardDetail.GetCustN_Doc(Convert.ToInt32(Txtno.Text.Trim()), Convert.ToInt32(strFY)).Tables[0];
                    if (dt2.Rows.Count > 0)
                    {
                        if (dt2.Rows[0]["Exist"].ToString().Trim() == "no")
                        {
                            lblCustName.Text = Convert.ToString(dt2.Rows[0]["CustName"]);
                            lblArea.Text = Convert.ToString(dt2.Rows[0]["AreaName"]);
                            Adddata(Txtno.Text.Trim());
                            Txtno.Focus();
                        }   //btngetRec.Focus();
                        else
                        {
                            message("DC No has already been added to OUT Ward Entry. New Document No can be "
                          + dt2.Rows[0]["NewDCNo"] + " ");
                            lblCustName.Text = Convert.ToString(dt2.Rows[0]["CustName"]);
                            lblArea.Text = Convert.ToString(dt2.Rows[0]["AreaName"]);
                            lblSelectedDoc.Text = dt2.Rows[0]["NewDCNo"].ToString();
                            btnForceAdd.Visible = true;
                            lblMsg.Visible = true;
                            lblSelectedDoc.Visible = true;
                            btnForceAdd.Focus();
                        }
                    }
                    else
                    {
                        btnSave.Visible = false;
                        message("Records Not Available");
                        Txtno.Focus();
                    }
                }
                catch (Exception ex) { message("Plase Enter Correct DC Number "); }
            }
            // TNo = Convert.ToDecimal(Txtno.Text.Trim());
            // TCustName = lblCustName.Text.Trim();
            // TAreaName = lblArea.Text.Trim();

            // DataTable dt = new DataTable();
            // if (Session["tempODData"] != null)
            // {
            //     Session["tempODData"] = fillTempODData();
            //     dt = (DataTable)Session["tempODData"];
            // }
            // else
            // {
            //     Session["tempODData"] = fillTempODData();
            //     dt = (DataTable)Session["tempODData"];
            // }
            // GrdOD.DataSource = dt;
            // GrdOD.DataBind();
            //// txtOutwardDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Txtno.Text = "";
            // lblCustName.Text = "";
            // lblArea.Text = "";
            // RdbtnSelect.Focus();
        }
        catch (Exception ex) { message("Plase Enter Correct DC Number " + ex.Message.ToString()); }

    }
    public void Adddata(string txtno)
    {
        TNo = Convert.ToDecimal(txtno);
        TCustName = lblCustName.Text.Trim();
        TAreaName = lblArea.Text.Trim();

        DataTable dt = new DataTable();
        if (Session["tempODData"] != null)
        {
            Session["tempODData"] = fillTempODData();
            dt = (DataTable)Session["tempODData"];
        }
        else
        {
            Session["tempODData"] = fillTempODData();
            dt = (DataTable)Session["tempODData"];
        }
        GrdOD.DataSource = dt;
        GrdOD.DataBind();
        // txtOutwardDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        Txtno.Text = "";
        lblCustName.Text = "";
        lblArea.Text = "";
        Txtno.Focus();
    }
    protected void RdbtnSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbtnSelect.SelectedValue == "Invoice")
        {
            flag = "I";
            TFlag = 'I';
        }
        if (RdbtnSelect.SelectedValue == "Document")
        {
            flag = "D";
            TFlag = 'D';
        }
    }

    #region Fill grid data for Outward entry
    public DataTable fillTempODData()
    {
        DataTable dt = new DataTable();

        if (Session["tempODData"] == null)
        {
            //CREATE NEW DATATABLE
            //ADD COLUMNS IN DATATABLE
            //dt.Columns.Add("ODDetailID");
            dt.Columns.Add("OdDAutoId");
            dt.Columns.Add("Flag");
            dt.Columns.Add("Invoice");
            dt.Columns.Add("CustName");
            dt.Columns.Add("AreaName");

            dt.Rows.Add(0, TFlag, TNo, TCustName, TAreaName);

            btnSave.Visible = true;
            //return dt;
            //ADD DATA AS PER COLUMNS
        }
        else
        {

            dt = (DataTable)Session["tempODData"];
            DataView dv = new DataView(dt);
            dv.RowFilter = "Invoice = '" + TNo + "' and Flag= '" + TFlag + "' ";
            if (dv.ToTable().Rows.Count > 0)
            {
                message("Already Exist");
            }
            else
            {
                dt.Rows.Add(0, TFlag, TNo, TCustName, TAreaName);
            }
            btnSave.Visible = true;
        }
        return dt;
    }
    #endregion
    protected void Txtno_TextChanged(object sender, EventArgs e)
    {
        //if (RdbtnSelect.SelectedValue == "Invoice")
        //{
        //    DataTable dt1 = new DataTable();
        //    dt1 = OutwardDetail.GetCustN_Invoice(Convert.ToDecimal(Txtno.Text.Trim()), Convert.ToInt32(strFY)).Tables[0];
        //    if (dt1.Rows.Count != 0)
        //    {
        //        lblCustName.Text = Convert.ToString(dt1.Rows[0]["CustName"]);
        //        lblArea.Text = Convert.ToString(dt1.Rows[0]["AreaName"]);
        //        //btnadd.Focus();
        //    }
        //    else
        //    {
        //        btnSave.Visible = false;
        //        //Panelview.Visible = false;
        //        // Panel3.Visible = false;
        //        //Panel2.Visible = false;
        //        message("Plase Enter Correct Number");
        //       // lblCustName.Text = "No such Customer code";
        //        Txtno.Focus();
        //     //   lblCustName.Text = "";
        //     //   lblArea.Text = "";
        //    }
        //}
        //if (RdbtnSelect.SelectedValue == "Document")
        //{
        //    DataTable dt2 = new DataTable();
        //    dt2 = OutwardDetail.GetCustN_Doc(Convert.ToInt32(Txtno.Text.Trim()), Convert.ToInt32(strFY)).Tables[0];
        //    if (dt2.Rows.Count != 0)
        //    {
        //        lblCustName.Text = Convert.ToString(dt2.Rows[0]["CustName"]);
        //        lblArea.Text = Convert.ToString(dt2.Rows[0]["AreaName"]);
        //        //btngetRec.Focus();
        //    }
        //    else
        //    {
        //        btnSave.Visible = false;
        //        //Panelview.Visible = false;
        //        //Panel3.Visible = false;
        //        //Panel2.Visible = false;
        //        message("Plase Enter Correct Number");
        //       // lblCustName.Text = "No such Customer code";
        //        Txtno.Focus();
        //      //  lblCustName.Text = "";
        //     //   lblArea.Text = "";
        //    }
        //}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ODdate = txtOutwardDate.Text.Split('/')[2] + "/" + txtOutwardDate.Text.Split('/')[1] + "/" + txtOutwardDate.Text.Split('/')[0];
        ddt = Convert.ToDateTime(ODdate);

        if (Session["UserName"] != null)
        {
            if (flag != "")
            {
                try
                {
                    OutwardMaster objodm = new OutwardMaster();
                    OutwardDetail objodd = new OutwardDetail();

                    objodm.OdMAutoId = 0;
                    objodm.OutWardDate = ddt;
                    objodm.IsActive = true;
                    objodm.CreatedBy = Session["UserName"].ToString();
                    objodm.FY = Convert.ToInt32(strFY);
                    objodm.HandOverTo = TxtEmp.Text.Trim();
                    objodm.Remarks = TxtRemark.Text.Trim();
                    objodm.Save(out DocNo, out OdMID);
                    //Txtdocno.Text = Convert.ToString(DocNo);

                    foreach (GridViewRow Row in GrdOD.Rows)
                    {
                        objodd.OdDAutoId = 0;
                        objodd.OdMAutoId = OdMID;

                        objodd.InvoiceOrDC = ((Label)Row.FindControl("LblFlag")).Text.Trim();
                        objodd.InvoiceNo = ((Label)Row.FindControl("LblInvoiceNo")).Text.Trim();
                        objodd.CustomerName = ((Label)Row.FindControl("LblCustN")).Text.Trim();
                        objodd.CustArea = ((Label)Row.FindControl("LblArea")).Text.Trim();
                        objodd.IsActive = true;
                        objodd.FY = Convert.ToInt32(strFY);
                        //if (RdbtnSelect.SelectedValue == "Invoice")
                        //{
                        //    TFlag = 'I';
                        //    objodd.InvoiceNo = (Txtno.Text.Trim());
                        //}
                        //if (RdbtnSelect.SelectedValue == "Document")
                        //{
                        //    TFlag = 'D';
                        //    objodd.InvoiceNo = (Txtno.Text.Trim());
                        //}
                        objodd.Save();
                    }
                    MessageBox(Constants.save + "\\r\\n Document No: " + DocNo);
                    //MessageBox(Constants.save);

                    //loder("Last saved Document no. : " + Txtdocno.Text);
                    TxtEmp.Text = "";
                    Txtno.Text = "";
                    txtOutwardDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    Session["tempODData"] = null;
                    btnSave.Visible = false;
                    GrdOD.DataBind();
                }
                catch
                {
                }
            }
        }
    }
    protected void GrdOD_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GrdOD_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        OutwardDetail objodd = new OutwardDetail();

        OutDetailID = Convert.ToInt32(((Label)GrdOD.Rows[e.RowIndex].FindControl("lbldetailid")).Text);

        try
        {
            if (OutDetailID != 0)
            {
                objodd.OdDAutoId = OutDetailID;
                objodd.IsActive = false;
                objodd.InvoiceNo = ((Label)GrdOD.Rows[e.RowIndex].FindControl("LblInvoiceNo")).Text.Trim();
                objodd.CustomerName = ((Label)GrdOD.Rows[e.RowIndex].FindControl("LblCustN")).Text.Trim();
                objodd.CustArea = ((Label)GrdOD.Rows[e.RowIndex].FindControl("LblArea")).Text.Trim();
                objodd.FY = Convert.ToInt32(strFY);
                objodd.Save();
            }
            DataTable dt3 = new DataTable();
            dt3 = (DataTable)Session["tempODData"];
            dt3.Rows[e.RowIndex].Delete();
            GrdOD.DataSource = dt3;
            GrdOD.DataBind();
            Session["tempODData"] = dt3;

            if (dt3.Rows.Count == 0)
            {
                btnSave.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
            }
        }
        catch { }
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

    #endregion

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion



    protected void btngetreport_Click(object sender, EventArgs e)
    {
        try
        {
            if (Rdboutward.SelectedValue == "Outward")
            {
                DataTable dt = OutwardDetail.Get_OutwardDetails(txtoutwardno1.Text.ToString().Trim(), "Outward", "G", Convert.ToInt32(strFY), Convert.ToDateTime("2011/2/2"), Convert.ToDateTime("2012/3/3")).Tables[0];
                GrdOD.DataSource = dt;
                GrdOD.DataBind();
            }//[Idv_Chetana_Get_OutwardDetails]
            else
                if (Rdboutward.SelectedValue == "Invoice")
                {
                    DataTable dt = OutwardDetail.Get_OutwardDetails(txtoutwardno1.Text.ToString().Trim(), "ss", "I", Convert.ToInt32(strFY), Convert.ToDateTime("2011/2/2"), Convert.ToDateTime("2012/3/3")).Tables[0];
                    GrdOD.DataSource = dt;
                    GrdOD.DataBind();
                }
                else
                {
                    DataTable dt = OutwardDetail.Get_OutwardDetails(txtoutwardno1.Text.ToString().Trim(), "ss", "D", Convert.ToInt32(strFY), Convert.ToDateTime("2011/2/2"), Convert.ToDateTime("2012/3/3")).Tables[0];
                    GrdOD.DataSource = dt;
                    GrdOD.DataBind();
                }
        }
        catch { }

    }


    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            if (Rdboutward.SelectedValue == "Outward")
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintOutWard.aspx?d=" + txtoutwardno1.Text.ToString().Trim() + "&sd=" + "Outward" + "&IOD=" + "G" + "&FY=" + Convert.ToInt32(strFY) + "')", true);
                //DataTable dt = OutwardDetail.Get_OutwardDetails(txtoutwardno1.Text.ToString().Trim(), "Outward", "G", Convert.ToInt32(strFY), Convert.ToDateTime("2011/2/2"), Convert.ToDateTime("2012/3/3")).Tables[0];
                //GrdOD.DataSource = dt;
                //GrdOD.DataBind();
            }//[Idv_Chetana_Get_OutwardDetails]
            else
                if (Rdboutward.SelectedValue == "Invoice")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintOutWard.aspx?d=" + txtoutwardno1.Text.ToString().Trim() + "&sd=" + "ss" + "&IOD=" + "I" + "&FY=" + Convert.ToInt32(strFY) + "')", true);
                    //DataTable dt = OutwardDetail.Get_OutwardDetails(txtoutwardno1.Text.ToString().Trim(), "ss", "I", Convert.ToInt32(strFY), Convert.ToDateTime("2011/2/2"), Convert.ToDateTime("2012/3/3")).Tables[0];
                    //GrdOD.DataSource = dt;
                    //GrdOD.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintOutWard.aspx?d=" + txtoutwardno1.Text.ToString().Trim() + "&sd=" + "ss" + "&IOD=" + "D" + "&FY=" + Convert.ToInt32(strFY) + "')", true);
                    //DataTable dt = OutwardDetail.Get_OutwardDetails(txtoutwardno1.Text.ToString().Trim(), "ss", "D", Convert.ToInt32(strFY), Convert.ToDateTime("2011/2/2"), Convert.ToDateTime("2012/3/3")).Tables[0];
                    //GrdOD.DataSource = dt;
                    //GrdOD.DataBind();
                }
        }
        catch { }
        // ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "window", "f_open_window_max('print/PrintOutWard.aspx?d=" + docnewno + "&sd=" + ((Button)(sender)).CommandArgument.Trim() + "')", true);
    }
    protected void btnForceAdd_Click(object sender, EventArgs e)
    {
        flag = "D";
        TFlag = 'D';
        Adddata(lblSelectedDoc.Text.Trim());
        btnForceAdd.Visible = false;
        lblMsg.Visible = false;
        lblSelectedDoc.Visible = false;
        Txtno.Focus();
    }
}
