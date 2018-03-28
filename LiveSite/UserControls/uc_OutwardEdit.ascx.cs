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


public partial class UserControls_uc_OutwardEdit : System.Web.UI.UserControl
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

    #region Page_Load
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
            //Pnlselect.Visible = true;
            GrdOD.DataBind();

            txtOutwardDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Session["tempODData"] = null;
            btnSave.Visible = false;
            txtOutwardDate.Focus();

        }
    }
    #endregion

    #region Events

    #region Click Events
    #region Add
    protected void btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (RdbtnSelect.SelectedValue == "Invoice")
            {
                flag = "I";
                TFlag = 'I';
                DataTable dt1 = new DataTable();
                dt1 = OutwardDetail.GetCustN_Invoice(Convert.ToDecimal(Txtno.Text.Trim()), Convert.ToInt32(strFY)).Tables[0];
                if (dt1.Rows.Count != 0)
                {
                    lblCustName.Text = Convert.ToString(dt1.Rows[0]["CustName"]);
                    lblArea.Text = Convert.ToString(dt1.Rows[0]["AreaName"]);
                    Adddata();
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
                    if (dt2.Rows.Count != 0)
                    {
                        lblCustName.Text = Convert.ToString(dt2.Rows[0]["CustName"]);
                        lblArea.Text = Convert.ToString(dt2.Rows[0]["AreaName"]);
                        Adddata();
                        //btngetRec.Focus();
                    }
                    else
                    {
                        btnSave.Visible = false;
                        message("Records Not Available");
                        Txtno.Focus();
                    }
                }
                catch { message("Plase Enter Correct DC Number"); }
            }
        }
        catch
        {
        }
    }
    #endregion

    #region Save
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

                    string Mid = LblODMID.Text.Trim();
                    int odMid = Convert.ToInt32(Mid);
                    objodm.OdMAutoId = odMid;
                    objodm.OutWardDate = ddt;
                    objodm.IsActive = true;
                    objodm.IsDeleted = false;
                    objodm.UpdatedBy = Session["UserName"].ToString();
                    objodm.FY = Convert.ToInt32(strFY);
                    objodm.HandOverTo = TxtEmp.Text.Trim();
                    objodm.Remarks = TxtRemark.Text.Trim();
                    objodm.Save(out DocNo, out OdMID);
                    //Txtdocno.Text = Convert.ToString(DocNo);

                    foreach (GridViewRow Row in GrdOD.Rows)
                    {
                        string Aid = ((Label)Row.FindControl("lbldetailid")).Text.Trim();
                        int Atid = Convert.ToInt32(Aid);

                        if (Atid == 0)
                        {
                            objodd.OdDAutoId = 0;
                            objodd.OdMAutoId = OdMID;

                            objodd.InvoiceOrDC = ((Label)Row.FindControl("LblFlag")).Text.Trim();
                            objodd.InvoiceNo = ((Label)Row.FindControl("LblInvoiceNo")).Text.Trim();
                            objodd.CustomerName = ((Label)Row.FindControl("LblCustN")).Text.Trim();
                            objodd.CustArea = ((Label)Row.FindControl("LblArea")).Text.Trim();
                            objodd.IsActive = true;
                            objodd.IsDeleted = false;
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
                            MessageBox("DocNo " + DocNo + " saved successfully" );
                        }
                    }
                    
                    //MessageBox(Constants.save);

                    //loder("Last saved Document no. : " + Txtdocno.Text);
                    LblODMID.Text = "";
                    Txtdocno.Text = "";
                    TxtEmp.Text = "";
                    Txtno.Text = "";
                    TxtRemark.Text = "";
                    //Response.Redirect(Request.RawUrl);
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
    #endregion

    #endregion

    # region SelectedIndexChanged
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
    #endregion

    #region Grid Events
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
                objodd.IsDeleted = true;
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

    #endregion

    #region TextChanged
    protected void Txtdocno_TextChanged(object sender, EventArgs e)
    {
        string DocNost = Txtdocno.Text.Trim();
        int DocNo2 = Convert.ToInt32(DocNost);
        int strFY2 = Convert.ToInt32(strFY);
        DataTable dt6 = new DataTable();
        dt6 = OutwardDetail.GetOutward(DocNo2, strFY2).Tables[1];

        DataTable dt5 = new DataTable();
        dt5 = OutwardDetail.GetOutward(DocNo2, strFY2).Tables[0];

        if (dt5.Rows.Count != 0)
        {
            txtOutwardDate.Text = Convert.ToString(OutwardDetail.GetOutward(DocNo2, strFY2).Tables[0].Rows[0]["OutWardDate"]);
            LblODMID.Text = Convert.ToString(OutwardDetail.GetOutward(DocNo2, strFY2).Tables[0].Rows[0]["OdMAutoId"]);
            TxtEmp.Text = Convert.ToString(OutwardDetail.GetOutward(DocNo2, strFY2).Tables[0].Rows[0]["HandOverTo"]);
            TxtRemark.Text = Convert.ToString(OutwardDetail.GetOutward(DocNo2, strFY2).Tables[0].Rows[0]["Remarks"]);
            GrdOD.DataSource = OutwardDetail.GetOutward(DocNo2, strFY2).Tables[1];
            GrdOD.DataBind();
           

            if (dt5.Rows.Count != 0)
            {
                Session["tempODData"] = dt6;
                btnSave.Visible = true;
            }
            else
            {
                Session["tempODData"] = null;
            }
        }
        else
        {
            MessageBox("Invalid Document No.");
            txtOutwardDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //GrdOD.DataSource = OutwardDetail.GetOutward(DocNo2, strFY2).Tables[1];
            GrdOD.DataBind();
        }
    }

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
    #endregion

    #endregion

    #region Methods
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
            dt.Rows.Add(0, TFlag, TNo, TCustName, TAreaName);
            btnSave.Visible = true;
        }
        return dt;
    }
    #endregion

    public void Adddata()
    {
        TNo = Convert.ToDecimal(Txtno.Text.Trim());
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

    #endregion
}

