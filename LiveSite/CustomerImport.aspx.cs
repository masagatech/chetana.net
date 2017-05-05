using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class CustomerImport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Message Box Method
    public void MessageBox(string MsgText)
    {
        string JavascriptAlert = "alert('" + MsgText + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", JavascriptAlert, true);
    }
    #endregion

    #region View Excel Data
    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                string connString = "";
                string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + fileName));
                string strFileType = Path.GetExtension(FileUpload1.FileName).ToLower();
                string path = Server.MapPath("~/Uploads/" + fileName);
                //if (strFileType.Trim() == ".xls")
                //{
                //    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";ReadOnly=1;Extended Properties=\"Excel 8.0;HDR=NO;IMEX=2\"";
                //}
                //else if (strFileType.Trim() == ".xlsx")
                //{
                //    connString = "Provider=Microsoft.Jet.OLEDB.12.0;Data Source='" + path + "';Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"";
                //}
                
                //System.Data.OleDb.OleDbConnection con;
                //System.Data.DataSet DtSet;
                //System.Data.OleDb.OleDbDataAdapter da;
                //con = new System.Data.OleDb.OleDbConnection(connString);
                //da = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", con);
                //// MyCommand.TableMappings.Add("Table", "TestTable");
                //DtSet = new System.Data.DataSet();

                DataTable dt = GetDataTableFromExcel(path,true);
                //da.Fill(DtSet);
                grdImportCust.DataSource = dt;
                grdImportCust.DataBind();
                btnUpload.Visible = true;
                grdpanl.Visible = true;
                //con.Close();
            }
        }
        catch (IOException ex)
        {
            Response.Write(ex.ToString());
            MessageBox(ex.ToString());
        }
        catch (Exception ex)
        {
            MessageBox(ex.ToString());
            Response.Write(ex.ToString());
        }
    }
    #endregion

    public static DataTable GetDataTableFromExcel(string path, bool hasHeader)
    {
        using (var pck = new OfficeOpenXml.ExcelPackage())
        {
            using (var stream = File.OpenRead(path))
            {
                pck.Load(stream);
            }
            var ws = pck.Workbook.Worksheets.First();
            DataTable tbl = new DataTable();
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
            {
                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }
            var startRow = hasHeader ? 2 : 1;
            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                DataRow row = tbl.Rows.Add();
                foreach (var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
            }
            return tbl;
        }
    }

    #region Upload Grid Data In DataBase
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        XmlNode inode = doc.CreateElement("f");
        XmlNode fnode = doc.CreateElement("r");
        foreach (GridViewRow row in grdImportCust.Rows)
        {
            XmlNode element = doc.CreateElement("i");

            inode = doc.CreateElement("c");
            inode.InnerText = ((Label)row.FindControl("lblcode")).Text.ToString();
            element.AppendChild(inode);

            inode = doc.CreateElement("s");
            inode.InnerText = ((Label)row.FindControl("lblsplitdc")).Text.ToString();
            element.AppendChild(inode);

            fnode.AppendChild(element);
        }

        Other_Z.OtherBAL objBal = new Other_Z.OtherBAL();
        objBal.UpdateCustomermaster(fnode.OuterXml, "", "", "");
        MessageBox("Data Upload Success");
        grdpanl.Visible = false;
        btnUpload.Visible = false;

    }
    #endregion
}