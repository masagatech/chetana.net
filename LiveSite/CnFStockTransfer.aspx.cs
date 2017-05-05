#region Add Namespace
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
using Idv.Chetana.CnF;
using Idv.Chetana.Common;
using System.Xml;
using CnF_Other_Z;
#endregion

public partial class StockTransfer_Cnf : System.Web.UI.Page
{
    #region Goloval Veriable
    string strFY;
    CnF_Other_Z.CnF_BAL objBal = new CnF_BAL();
    CnF_Other_Z.CnF_BAL.CnfStockTransfer_Property ObjProp = new CnF_BAL.CnfStockTransfer_Property();
    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        btnsave.Visible = false;
        if (Session["FY"] != null)
        {
            strFY = Session["FY"].ToString();
        }
        else
        {
            Session.Clear();
        }
        if (!Page.IsPostBack)
        {
            txtFromDate.Focus();
        }
    }
    #endregion

    #region MessageBox
    public void Message(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);

    }
    #endregion

    #region Grid Bind Method
    public void Bind()
    {
        string from = txtFromDate.Text.Split('/')[1] + "/" + txtFromDate.Text.Split('/')[0] + "/" + txtFromDate.Text.Split('/')[2];
        string To = txtToDate.Text.Split('/')[1] + "/" + txtToDate.Text.Split('/')[0] + "/" + txtToDate.Text.Split('/')[2];
        DateTime FromDate = Convert.ToDateTime(from);
        DateTime ToDate = Convert.ToDateTime(To);
                                                                            //Session["CnFID"].ToString()
        Grdstockreport.DataSource = objBal.IDV_Chetana_REP_Physical_STOCK_Cnf("18", FromDate, ToDate, Convert.ToInt32(strFY), "").Tables[0];
        Grdstockreport.DataBind();
    }
    #endregion

    #region Button Get Click Event
    protected void btngetdate_Click(object sender, EventArgs e)
    {
        Bind();
        btnsave.Visible = true;
    }
    #endregion

    #region Button Transfer Click Event
    protected void btnsave_Click(object sender, EventArgs e)
    {
        int flag = 0;
        btnsave.Visible = false;
        XmlDocument doc = new XmlDocument();
        XmlNode objnode = doc.CreateElement("n");
        XmlNode objroot = doc.CreateElement("r");

        foreach (GridViewRow g1 in Grdstockreport.Rows)
        {
            if ((g1.FindControl("chkselect") as CheckBox).Checked)
            {
                flag = 1;
                XmlNode element = doc.CreateElement("t");
                objnode = doc.CreateElement("b");
                objnode.InnerText = (g1.FindControl("lblbkcode") as Label).Text;
                element.AppendChild(objnode);

                objnode = doc.CreateElement("a");
                objnode.InnerText = Convert.ToInt32((g1.FindControl("txtavailable") as TextBox).Text).ToString();
                element.AppendChild(objnode);

                //objnode = doc.CreateElement("f");
                //objnode.InnerText = Convert.ToInt32(strFY.ToString()).ToString();
                //element.AppendChild(objnode);

                objnode = doc.CreateElement("c");
                objnode.InnerText = Convert.ToInt32("18").ToString();//Session["CnFID"]
                element.AppendChild(objnode);

                objnode = doc.CreateElement("u");
                objnode.InnerText = Session["UserName"].ToString();
                element.AppendChild(objnode);

                objroot.AppendChild(element);
            }
        }
        if (flag == 1)
        {
            ObjProp.OtherFieldXML = objroot.OuterXml.ToString();
            ObjProp.Flag = "";
            ObjProp.FY = Convert.ToInt32(strFY.ToString());
            ObjProp.R1 = "";
            ObjProp.R2 = "";
            ObjProp.R3 = "";
            ObjProp.R4 = "";
            ObjProp.R5 = "";
            objBal.Idv_Chetana_Save_StockTransfer_Cnf(ObjProp);
            Message("Record Save Successfully");
        }
        else
        {
            Message("Please Checked Any Books");
            btnsave.Visible = true;
            return;
        }
    }
    #endregion
}

