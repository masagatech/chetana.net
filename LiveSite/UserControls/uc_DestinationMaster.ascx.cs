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

public partial class UserControls_uc_DestinationMaster : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            Destination _objDestination = new Destination();
            _objDestination.DMID = 0;
            _objDestination.DMCode = txtDmcode.Text.Trim();
            _objDestination.Name = txtname.Text.Trim();
            _objDestination.IsActive = true;
            _objDestination.Save();
        }
        catch
        {

        }
    }
}
