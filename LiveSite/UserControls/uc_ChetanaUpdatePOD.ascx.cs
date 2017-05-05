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
//using Idv.Chetana.BAL;
using System.Data.SqlClient;
using Other_Z;
using System.Xml;

public partial class UserControls_uc_ChetanaUpdatePOD : System.Web.UI.UserControl
{
    #region Goloval Varables

    static int quantity = 0;
    static decimal APODId = 0;
    static decimal totalamount = 0;
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    static int docnewno = 0;
    string RdBValue;
    DateTime fdate;
    DateTime tdate;
    Other_Z.OtherBAL ObjDal = new OtherBAL();
    OtherBAL.Courier_Property ObjProp = new OtherBAL.Courier_Property();
    string DocNo;
    #endregion

    #region Page Load Event
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
        if (IsPostBack == true) { return; }
        lblMessage.Text = "";
        divLevel2.Visible = true;
        divGeneral.Visible = false;
        Branch();
        Courier();
    }
    #endregion

    #region Get Button Click Event
    protected void btnget_Click(object sender, EventArgs e)
    {

        ViewState["DocNo"] = ViewState["DocNo"] + "," + txtDocNoGet.Text + ",";
        DataSet DS = new DataSet();
        if (txtCourierId.Text.ToString() != "")
        {
            DS = ObjDal.GetUpdatePOD(float.Parse(txtCourierId.Text), "", "", "", "", "CourierId", Convert.ToInt32(strFY));

        }
        else if (txtInvoiceNoGet.Text.ToString() != "")
        {
            DS = ObjDal.GetUpdatePOD(float.Parse(txtInvoiceNoGet.Text), "", "", "", "", "Invoice", Convert.ToInt32(strFY));

        }
        else if (txtDocNoGet.Text.ToString() != "")
        {
            DS = ObjDal.GetUpdatePOD(float.Parse(txtDocNoGet.Text), "", "", "", "", "DocNo", Convert.ToInt32(strFY));

        }
        else if (txtGeneralCourierID.Text.ToString() != "")
        {
            DS = ObjDal.GetUpdatePOD(float.Parse(txtGeneralCourierID.Text), "", "", "", "", "GeneralCourierID", Convert.ToInt32(strFY));

        }
        else if (ddlBranch.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "Others"))
        {
            if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
            {
                DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY));
            }
            else
            {
                DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY));
            }
        }
        else if ((ddlCourier.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "Others"))
        {
            if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
            {
                DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY));
            }
            else
            {
                DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY));
            }
        }
        else if (ddlBranchI.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "InvoiceNo"))
        {
            if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
            {
                DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY));
            }
            else
            {
                DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY));
            }
        }
        else if ((ddlCourierI.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "InvoiceNo"))
        {
            if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
            {
                DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY));
            }
            {
                DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY));

            }
        }
        else if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
        {
            DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00",
            (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(),
            ddlCourier.SelectedValue.ToString(), "Date", Convert.ToInt32(strFY));
        }
        else if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
        {
            DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralDate", Convert.ToInt32(strFY));

        }
        try
        {
            RepDetailsConfirm.DataSource = DS.Tables[1];
            RepDetailsConfirm.DataBind();
        }
        catch (Exception ex)
        {

            throw;
        }

        //txtCourierId.Text = "";
        //txtInvoiceNoGet.Text = "";
        //txtDocNoGet.Text = "";
        //ddlBranchI.SelectedValue = "0";
        //ddlCourierI.SelectedValue = "0";
        //txtFrom.Text = "";
        //txtTo.Text = "";
        //txtGeneralCourierID.Text = "";
        //ddlBranch.SelectedValue = "0";
        //ddlCourier.SelectedValue = "0";
        //txtFromGeneral.Text = "";
        //txtToGeneral.Text = "";
    }
    #endregion

    protected void grdCD_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSCMasterAutoId = (Label)e.Row.Parent.Parent.Parent.FindControl("lblSCMasterAutoId");
            Label lblDocumentNo = (Label)e.Row.Parent.Parent.Parent.FindControl("lblDocumentNo");
            Label lblInvoiceNo = (Label)e.Row.Parent.Parent.Parent.FindControl("lblInvoiceNo");
            TextBox txtPODId = (TextBox)e.Row.Parent.Parent.Parent.FindControl("txtPODId");
            lblSCMasterAutoId = (Label)e.Row.FindControl("lblSCMasterAutoId");
            txtPODId = (TextBox)e.Row.FindControl("txtPODId");
            lblDocumentNo = (Label)e.Row.FindControl("lblDocumentNo");
            lblInvoiceNo = (Label)e.Row.FindControl("lblInvoiceNo");

        }
    }
    protected void gdGeneral_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSCMasterAutoIdGeneral = (Label)e.Row.Parent.Parent.Parent.FindControl("lblSCMasterAutoIdGeneral");
            Label lblValue = (Label)e.Row.Parent.Parent.Parent.FindControl("lblValue");
            Label lblBranchName = (Label)e.Row.Parent.Parent.Parent.FindControl("lblBranchName");
            Label lblBranchAdd = (Label)e.Row.Parent.Parent.Parent.FindControl("lblBranchAdd");
            Label lblDepartment = (Label)e.Row.Parent.Parent.Parent.FindControl("lblDepartment");
            TextBox txtPODIdG = (TextBox)e.Row.Parent.Parent.Parent.FindControl("txtPODIdG");
            lblSCMasterAutoIdGeneral = (Label)e.Row.FindControl("lblSCMasterAutoIdGeneral");
            //lblValue = (Label)e.Row.FindControl("lblValue");
            //lblBranchName = (Label)e.Row.FindControl("lblBranchName");
            //lblBranchAdd = (Label)e.Row.FindControl("lblBranchAdd");
            //lblDepartment = (Label)e.Row.FindControl("lblDepartment");
            txtPODIdG = (TextBox)e.Row.FindControl("txtPODIdG");

        }
    }

    #region Update Button Click Event
    protected void RepDetailsConfirm_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int Val = 0;
        if (e.CommandName == "update")
        {
            try
            {
                DataSet DS = new DataSet();
                Repeater objrep = (Repeater)this.FindControl("RepDetailsConfirm");
                GridView objgrid = (GridView)objrep.Items[e.Item.ItemIndex].FindControl("grdCD");
                if (rdLevel1.SelectedValue == "InvoiceNo")
                    objgrid = (GridView)objrep.Items[e.Item.ItemIndex].FindControl("grdCD");
                else if (rdLevel1.SelectedValue == "Others")
                    objgrid = (GridView)objrep.Items[e.Item.ItemIndex].FindControl("gdGeneral");

                XmlDocument doc = new XmlDocument();
                XmlNode node = doc.CreateElement("r");
                XmlNode nd = doc.CreateElement("I");
                if (rdLevel1.SelectedValue == "InvoiceNo")
                {
                    #region Invoice No Update Loop
                    foreach (GridViewRow row in objgrid.Rows)
                    {
                        CheckBox checkpod = (CheckBox)row.FindControl("chkIsActive");
                        XmlNode elem = doc.CreateElement("T");
                        if (checkpod.Checked)
                        {
                            Val = 1;
                            if (Txtpod.Text != "")
                            {
                                nd = doc.CreateElement("d");
                                nd.InnerText = Convert.ToInt32(Txtpod.Text).ToString();
                                elem.AppendChild(nd);

                                nd = doc.CreateElement("f");
                                nd.InnerText = Convert.ToInt32(Session["FY"]).ToString();
                                elem.AppendChild(nd);

                                nd = doc.CreateElement("u");
                                nd.InnerText = Convert.ToString(Session["UserName"]).ToString();
                                elem.AppendChild(nd);
                                node.AppendChild(elem);

                                nd = doc.CreateElement("a");
                                nd.InnerText = float.Parse(((Label)row.FindControl("lblSCMasterAutoId")).Text).ToString();
                                elem.AppendChild(nd);
                            }
                            else
                            {
                                string no = ((TextBox)row.FindControl("txtPODId")).Text == "" ? "0" : ((TextBox)row.FindControl("txtPODId")).Text;
                                if (no != "")
                                {
                                    nd = doc.CreateElement("d");
                                    nd.InnerText = Convert.ToInt32(no).ToString();//Convert.ToInt32(((TextBox)row.FindControl("txtPODId")).Text).ToString();
                                    elem.AppendChild(nd);

                                    nd = doc.CreateElement("f");
                                    nd.InnerText = Convert.ToInt32(Session["FY"]).ToString();
                                    elem.AppendChild(nd);

                                    nd = doc.CreateElement("u");
                                    nd.InnerText = Convert.ToString(Session["UserName"]).ToString();
                                    elem.AppendChild(nd);

                                    nd = doc.CreateElement("a");
                                    nd.InnerText = float.Parse(((Label)row.FindControl("lblSCMasterAutoId")).Text).ToString();
                                    elem.AppendChild(nd);
                                    node.AppendChild(elem);
                                }
                            }
                        }
                       
                    }
                    #endregion
                }
                else if (rdLevel1.SelectedValue == "Others")
                {

                    foreach (GridViewRow row in objgrid.Rows)
                    {
                        XmlNode elem = doc.CreateElement("T");
                        CheckBox checkpod = (CheckBox)row.FindControl("chkIsActive1");
                        if (checkpod.Checked)
                        {
                            Val = 1;
                            if (Txtpod1.Text != "")
                            {
                                nd = doc.CreateElement("d");
                                nd.InnerText = Convert.ToInt32(Txtpod1.Text).ToString();
                                elem.AppendChild(nd);

                                nd = doc.CreateElement("f");
                                nd.InnerText = Convert.ToInt32(Session["FY"]).ToString();
                                elem.AppendChild(nd);

                                nd = doc.CreateElement("u");
                                nd.InnerText = Convert.ToString(Session["UserName"]).ToString();
                                elem.AppendChild(nd);

                                nd = doc.CreateElement("a");
                                nd.InnerText = float.Parse(((Label)row.FindControl("lblUNIQ")).Text).ToString();
                                elem.AppendChild(nd);
                                node.AppendChild(elem);
                            }
                            else
                            {
                                string nos = ((TextBox)row.FindControl("txtPODIdG")).Text == "" ? "0" : ((TextBox)row.FindControl("txtPODIdG")).Text;
                                if (nos != "")
                                {
                                    nd = doc.CreateElement("d");
                                    nd.InnerText = Convert.ToInt32(nos).ToString(); //Convert.ToInt32(((TextBox)row.FindControl("txtPODIdG")).Text).ToString();
                                    elem.AppendChild(nd);

                                    nd = doc.CreateElement("f");
                                    nd.InnerText = Convert.ToInt32(Session["FY"]).ToString();
                                    elem.AppendChild(nd);

                                    nd = doc.CreateElement("u");
                                    nd.InnerText = Convert.ToString(Session["UserName"]).ToString();
                                    elem.AppendChild(nd);

                                    nd = doc.CreateElement("a");
                                    nd.InnerText = float.Parse(((Label)row.FindControl("lblUNIQ")).Text).ToString();
                                    elem.AppendChild(nd);
                                    node.AppendChild(elem);
                                }
                            }
                        }
                    }
                }
                if (Val == 1)
                {
                    ObjProp.XMLData = node.OuterXml.ToString();
                    ObjDal.Idv_Chetana_UpdatePODNo("", "", "", "Update", ObjProp.XMLData, "", 0);
                }
                else
                {
                    MessageBox("Please Seleted Is Active Box");
                    return;
                }

                
                #region Get data After Update
                if (txtCourierId.Text.ToString() != "")
                {
                    DS = ObjDal.GetUpdatePOD(float.Parse(txtCourierId.Text), "", "", "", "", "CourierId", Convert.ToInt32(strFY));
                }
                else if (txtInvoiceNoGet.Text.ToString() != "")
                {
                    DS = ObjDal.GetUpdatePOD(float.Parse(txtInvoiceNoGet.Text), "", "", "", "", "Invoice", Convert.ToInt32(strFY));
                }
                else if (txtDocNoGet.Text.ToString() != "")
                {
                    DS = ObjDal.GetUpdatePOD(float.Parse(txtDocNoGet.Text), "", "", "", "", "DocNo", Convert.ToInt32(strFY));
                }
                else if (txtGeneralCourierID.Text.ToString() != "")
                {
                    DS = ObjDal.GetUpdatePOD(float.Parse(txtGeneralCourierID.Text), "", "", "", "", "GeneralCourierID", Convert.ToInt32(strFY));
                }

                else if (ddlBranch.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "Others"))
                {
                    if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
                    {
                        DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY));
                    }
                    else
                    {
                        DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY));
                    }
                }
                else if ((ddlCourier.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "Others"))
                {
                    if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
                    {
                        DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY));
                    }
                    else
                    {
                        DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY));
                    }
                }
                else if (ddlBranchI.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "InvoiceNo"))
                {
                    if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
                    {
                        DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY));
                    }
                    else
                    {
                        DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY));
                    }
                }
                else if ((ddlCourierI.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "InvoiceNo"))
                {
                    if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
                    {
                        DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY));
                    }
                    else
                    {
                        DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY));
                    }

                }
                else if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
                {
                    DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "Date", Convert.ToInt32(strFY));
                }
                else if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
                {
                    DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralDate", Convert.ToInt32(strFY));
                }
                #endregion

                if (DS.Tables[0].Rows[0]["PODId"].ToString() != "")
                    MessageBox("POD updated successfully");


                RepDetailsConfirm.DataSource = DS.Tables[1];
                RepDetailsConfirm.DataBind();
                Txtpod.Text = "";
                Txtpod1.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox(ex.Message.ToString());
            }
        }

        #region Delete Record
        if (e.CommandName == "delete")
        {
            try
            {
                DataSet DS = new DataSet();
                Repeater objrep = (Repeater)this.FindControl("RepDetailsConfirm");
                GridView objgrid = (GridView)objrep.Items[e.Item.ItemIndex].FindControl("grdCD");
                if (rdLevel1.SelectedValue == "InvoiceNo")
                    objgrid = (GridView)objrep.Items[e.Item.ItemIndex].FindControl("grdCD");
                else if (rdLevel1.SelectedValue == "Others")
                    objgrid = (GridView)objrep.Items[e.Item.ItemIndex].FindControl("gdGeneral");

                XmlDocument doc = new XmlDocument();
                XmlNode node = doc.CreateElement("r");
                XmlNode nd = doc.CreateElement("I");
                    ObjProp.UpDateBy = Convert.ToString(Session["UserName"]);
                    if (rdLevel1.SelectedValue == "InvoiceNo")
                    {
                        
                        foreach (GridViewRow row in objgrid.Rows)
                        {
                            XmlNode elem = doc.CreateElement("T");
                            CheckBox checkpod = (CheckBox)row.FindControl("chkIsActive");
                            if (checkpod.Checked)
                            {
                                Val = 1;

                                nd = doc.CreateElement("us");
                                nd.InnerText = Convert.ToString(Session["UserName"]).ToString();
                                elem.AppendChild(nd);

                                nd = doc.CreateElement("ai");
                                nd.InnerText = float.Parse(((Label)row.FindControl("lblSCMasterAutoId")).Text).ToString();
                                elem.AppendChild(nd);
                                node.AppendChild(elem);
                            }
                        }
                    }
                    else if (rdLevel1.SelectedValue == "Others")
                    {
                        ObjProp.IsActive = Convert.ToBoolean(false);
                        ObjProp.UpDateBy = Convert.ToString(Session["UserName"]);
                        foreach (GridViewRow row in objgrid.Rows)
                        {
                            XmlNode elem = doc.CreateElement("T");
                            CheckBox checkpod = (CheckBox)row.FindControl("chkIsActive1");
                            if (checkpod.Checked)
                            {
                                Val = 1;
                                nd = doc.CreateElement("us");
                                nd.InnerText = Convert.ToString(Session["UserName"]).ToString();
                                elem.AppendChild(nd);

                                nd = doc.CreateElement("ai");
                                nd.InnerText = float.Parse(((Label)row.FindControl("lblUNIQ")).Text).ToString();
                                elem.AppendChild(nd);
                                node.AppendChild(elem);
                            }
                        }

                    }
                    if (Val == 1)
                    {
                        ObjProp.XMLData = node.OuterXml.ToString();
                        ObjDal.Idv_Chetana_UpdatePODNo("", "", "", "", ObjProp.XMLData, "", 0);
                         
                    }
                    else
                    {
                        MessageBox("Please Select Is Active Box");
                        return;
                    }

                    #region After Delete Get data

                    if (txtCourierId.Text.ToString() != "")
                    {
                        DS = ObjDal.GetUpdatePOD(float.Parse(txtCourierId.Text), "", "", "", "", "CourierId", Convert.ToInt32(strFY));

                    }
                    else if (txtInvoiceNoGet.Text.ToString() != "")
                    {
                        DS = ObjDal.GetUpdatePOD(float.Parse(txtInvoiceNoGet.Text), "", "", "", "", "Invoice", Convert.ToInt32(strFY));

                    }
                    else if (txtDocNoGet.Text.ToString() != "")
                    {
                        DS = ObjDal.GetUpdatePOD(float.Parse(txtDocNoGet.Text), "", "", "", "", "DocNo", Convert.ToInt32(strFY));

                    }
                    else if (txtGeneralCourierID.Text.ToString() != "")
                    {
                        DS = ObjDal.GetUpdatePOD(float.Parse(txtGeneralCourierID.Text), "", "", "", "", "GeneralCourierID", Convert.ToInt32(strFY));
                    }

                    else if (ddlBranch.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "Others"))
                    {
                        if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
                        {
                            DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY));
                        }
                        else
                        {
                            DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY));
                        }
                    }
                    else if ((ddlCourier.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "Others"))
                    {
                        if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
                        {
                            DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY));
                        }
                        else
                        {
                            DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY));
                        }
                    }
                    else if (ddlBranchI.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "InvoiceNo"))
                    {
                        if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
                        {
                            DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY));
                        }
                        else
                        {
                            DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY));
                        }
                    }
                    else if ((ddlCourierI.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "InvoiceNo"))
                    {
                        if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
                        {
                            DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY));
                        }
                        else
                        {
                            DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY));
                        }

                    }
                    else if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
                    {
                        DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "Date", Convert.ToInt32(strFY));
                    }
                    else if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
                    {
                        DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralDate", Convert.ToInt32(strFY));
                    }
                    #endregion

                //if (DS.Tables[0].Rows[0]["PODId"].ToString() != "")
                  //  if (DS.Tables[0].Rows[0] > "0".ToString())
                    MessageBox("Record Deleted successfully");


                RepDetailsConfirm.DataSource = DS.Tables[1];
                RepDetailsConfirm.DataBind();
                Txtpod.Text = "";
                Txtpod1.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox(ex.Message.ToString());
            }


        }
        #endregion
    }
    #endregion

    protected void RepDetailsConfirm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        TextBox txtPODId = null;
        Label lblSCMasterAutoId = null;
        Label lblDocumentNo = null;
        Label lblInvoiceNo = null;
        Label lblCustName = null;
        Label lblSCMasterAutoIdGeneral = null;
        Label lblValue = null;
        Label lblBranchName = null;
        Label lblBranchAdd = null;
        Label lblDepartment = null;
        GridView grdView = null;
        if (rdLevel1.SelectedValue == "InvoiceNo")
        {
            lblSCMasterAutoId = (Label)e.Item.FindControl("lblSCMasterAutoId");
            ////lblDocumentNo = (Label)e.Item.FindControl("lblDocumentNo");
            ////lblInvoiceNo = (Label)e.Item.FindControl("lblInvoiceNo");
            ////lblCustName = (Label)e.Item.FindControl("lblCustName");
            txtPODId = (TextBox)e.Item.FindControl("txtPODId");
            grdView = (GridView)e.Item.FindControl("grdCD");
        }
        else if (rdLevel1.SelectedValue == "Others")
        {
            lblSCMasterAutoIdGeneral = (Label)e.Item.FindControl("lblSCMasterAutoIdGeneral");
            //lblValue = (Label)e.Item.FindControl("lblValue");
            //lblBranchName = (Label)e.Item.FindControl("lblBranchName");
            //lblBranchAdd = (Label)e.Item.FindControl("lblBranchAdd");
            //lblDepartment = (Label)e.Item.FindControl("lblDepartment");
            txtPODId = (TextBox)e.Item.FindControl("txtPODIdG");
            grdView = (GridView)e.Item.FindControl("gdGeneral");
        }

        ViewState["DocNo"] = ViewState["DocNo"] + "," + txtDocNoGet.Text + ",";
        DataSet DS = new DataSet();
        if (txtCourierId.Text.ToString() != "")
        {
            DS = ObjDal.GetUpdatePOD(float.Parse(txtCourierId.Text), "", "", "", "", "CourierId", Convert.ToInt32(strFY));
        }
        else if (txtInvoiceNoGet.Text.ToString() != "")
        {
            DS = ObjDal.GetUpdatePOD(float.Parse(txtInvoiceNoGet.Text), "", "", "", "", "Invoice", Convert.ToInt32(strFY));
        }
        else if (txtDocNoGet.Text.ToString() != "")
        {
            DS = ObjDal.GetUpdatePOD(float.Parse(txtDocNoGet.Text), "", "", "", "", "DocNo", Convert.ToInt32(strFY));
        }
        else if (txtGeneralCourierID.Text.ToString() != "")
        {
            DS = ObjDal.GetUpdatePOD(float.Parse(txtGeneralCourierID.Text), "", "", "", "", "GeneralCourierID", Convert.ToInt32(strFY));
        }
        else if (ddlBranch.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "Others"))
        {
            if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
            {
                DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY));
            }
            else
            {
                DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralBranch", Convert.ToInt32(strFY));
            }
        }
        else if ((ddlCourier.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "Others"))
        {
            if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
            {
                DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY));
            }
            else
            {
                DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralCourier", Convert.ToInt32(strFY));
            }
        }
        else if (ddlBranchI.SelectedValue.ToString() != "0" && (rdLevel1.SelectedValue == "InvoiceNo"))
        {
            if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
            {
                DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY));
            }
            else
            {
                DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceBranch", Convert.ToInt32(strFY));
            }
        }
        else if ((ddlCourierI.SelectedValue.ToString() != "0") && (rdLevel1.SelectedValue == "InvoiceNo"))
        {
            if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
            {

                DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY));
            }
            else
            {
                DS = ObjDal.GetUpdatePOD(0, "", "", ddlBranchI.SelectedValue.ToString(), ddlCourierI.SelectedValue.ToString(), "InvoiceCourier", Convert.ToInt32(strFY));

            }
        }
        else if ((txtFrom.Text.ToString()) != "" && (txtTo.Text.ToString() != "") && (rdLevel1.SelectedValue == "InvoiceNo"))
        {
            DS = ObjDal.GetUpdatePOD(0, (txtFrom.Text.Split('/')[1] + "/" + txtFrom.Text.Split('/')[0] + "/" + txtFrom.Text.Split('/')[2]) + " 00:00:00", (txtTo.Text.Split('/')[1] + "/" + txtTo.Text.Split('/')[0] + "/" + txtTo.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "Date", Convert.ToInt32(strFY));

        }
        else if ((txtFromGeneral.Text.ToString()) != "" && (txtToGeneral.Text.ToString() != "" && (rdLevel1.SelectedValue == "Others")))
        {
            DS = ObjDal.GetUpdatePOD(0, (txtFromGeneral.Text.Split('/')[1] + "/" + txtFromGeneral.Text.Split('/')[0] + "/" + txtFromGeneral.Text.Split('/')[2]) + " 00:00:00", (txtToGeneral.Text.Split('/')[1] + "/" + txtToGeneral.Text.Split('/')[0] + "/" + txtToGeneral.Text.Split('/')[2]) + " 23:59:59", ddlBranch.SelectedValue.ToString(), ddlCourier.SelectedValue.ToString(), "GeneralDate", Convert.ToInt32(strFY));

        }
        DataView dv = new DataView(DS.Tables[0]);
        grdView.DataSource = dv;
        grdView.DataBind();
    }

    #region MsgBox
    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelte_Click(object sender, EventArgs e)
    {

    }

    #region Radio Button Seleted Event
    protected void rdLevel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdLevel1.SelectedValue == "InvoiceNo")
        {
            divLevel2.Visible = true;
            divGeneral.Visible = false;
            Branch();
            Courier();
        }
        else
        {
            divLevel2.Visible = false;
            divGeneral.Visible = true;
            Branch();
            Courier();
        }
    }
    #endregion

    #region Courier Dropdown Bind
    public void Courier()
    {
        if (rdLevel1.SelectedValue == "InvoiceNo")
        {
            ddlCourierI.DataSource = ObjDal.GetBranch("Courier");
            ddlCourierI.DataBind();
            ddlCourierI.Items.Insert(0, new ListItem("--Select Courier Company--", "0"));
        }
        else if (rdLevel1.SelectedValue == "Others")
        {
            ddlCourier.DataSource = ObjDal.GetBranch("Courier");
            ddlCourier.DataBind();
            ddlCourier.Items.Insert(0, new ListItem("--Select Courier Company--", "0"));
        }


    }
    #endregion

    #region  Branch Dropdown Bind
    public void Branch()
    {
        if (rdLevel1.SelectedValue == "InvoiceNo")
        {
            ddlBranchI.DataSource = ObjDal.GetBranch("Branch");
            ddlBranchI.DataBind();
            ddlBranchI.Items.Insert(0, new ListItem("--Select Branch Company--", "0"));
        }
        else if (rdLevel1.SelectedValue == "Others")
        {
            ddlBranch.DataSource = ObjDal.GetBranch("Branch");
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("--Select Branch Company--", "0"));
        }

    }
    #endregion

}