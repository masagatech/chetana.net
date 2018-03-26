using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Using Namesapce
using System.Data;
using System.Xml;

public partial class SpecimanMaster : System.Web.UI.Page
{
    #region ALl Veriable Declaretion
    string strChetanaCompanyName = "cppl";
    string strFY = "0";
    string UserName = "";
    #endregion

    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChetanaCompanyName"] != null)
        {

            if (Session["FY"] != null)
            {
                strChetanaCompanyName = Session["ChetanaCompanyName"].ToString();
                strFY = Session["FY"].ToString();
                UserName = Session["UserName"].ToString();
            }
        }
        else
        {
            Session.Clear();
        }
    }
    #endregion

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    #region Save Button Click Event
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        XmlNode finode = doc.CreateElement("r");
        XmlNode inode = doc.CreateElement("f");
        bool flag = false;
        foreach (GridViewRow item in grdBookset.Rows)
        {
            XmlNode element = doc.CreateElement("i");
            string limit = ((TextBox)item.FindControl("lbllimit")).Text.ToString();
            if (limit!="")
            {
                flag = true;
                inode = doc.CreateElement("c");
                inode.InnerText = ((Label)item.FindControl("lblCode")).Text.ToString().Trim();
                element.AppendChild(inode);

                inode = doc.CreateElement("l");
                inode.InnerText = ((TextBox)item.FindControl("lbllimit")).Text.ToString();
                element.AppendChild(inode);

                inode = doc.CreateElement("n");
                inode.InnerText = ((Label)item.FindControl("lblname")).Text.ToString().Trim();
                element.AppendChild(inode);

                finode.AppendChild(element);
            }
        }
        if (flag == true)
        {
            Other_Z.OtherBAL objbl = new Other_Z.OtherBAL();
            objbl.SaveSalesmnBookSetLimit(finode.OuterXml.ToString(), txtMRCode.Text.Split(':')[0].ToString(), Convert.ToInt32(strFY), UserName, "booksetsave", "");
            MessageBox("Record Save Successfull");
            txtMRCode.Text = "";
            txtMRCode.Focus();
            grdBookset.Visible = false;
            btndownsave.Visible = false;
        }
        else
        {
            MessageBox("Kindly, enter the limit");
            return;
        }   
    }
    #endregion

    #region MR Code text Change Event
    protected void txtMRCode_TextChanged(object sender, EventArgs e)
    {
       string MrCode = txtMRCode.Text.Split(':')[0].ToString();
       DataSet ds = Other_Z.OtherBAL.SalesmanBook_Get(MrCode, Convert.ToInt32(strFY), "", "");

       if (ds.Tables[0].Rows[0]["key"].ToString() == "Msg")
       {
           grdBookset.Visible = false;
           MessageBox("Kindly, Enter Valid M R Code");
           txtMRCode.Focus();
           btndownsave.Visible = false;
           return;
       }
       else
       {
           grdBookset.Visible = true;
           btndownsave.Visible = true;
           grdBookset.DataSource = ds;
           grdBookset.DataBind();
       }
     }
    #endregion
}