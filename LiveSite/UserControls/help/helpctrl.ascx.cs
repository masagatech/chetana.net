﻿using System;
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

public partial class UserControls_help_helpctrl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Other objother = new Other();

        if (lblhelp.Text != "")
        {
            lstShorthelp.DataSource = objother.GetNameHelp(lblhelp.Text.Trim());
            lstShorthelp.DataBind();
        }
    }
}
