#region Namespace
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
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
#endregion


public partial class UserControls_uc_View_EmployeeMaster : System.Web.UI.UserControl
{
    #region Variables
    int EId;
    public static string imgpath = "";
    int empid;
    #endregion

    #region page_load

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            LblEmpID.Visible = false;
            DdlRole.DataSource = Rolemaster.Get_RoleMaster();
            DdlRole.DataBind();
            fillQualification();
            fillDesignation();
            PnlLoginDetails.Visible = false;
            grdEmpDetails.DataSource = BindGvEmpDetail();
            grdEmpDetails.DataBind();
            //

            //DDLsuperzone.DataSource = SuperZone.GetSuperzonemaster();
            //DDLsuperzone.DataBind();
            DDLSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            DDLSDZone.DataBind();
            DDLSDZone.Items.Insert(0, new ListItem("All", "0"));
            DDLsuperzone.Items.Insert(0, new ListItem("All", "0"));
            DDLzone.Items.Insert(0, new ListItem("All", "0"));
            DDLareazone.Items.Insert(0, new ListItem("All", "0"));
           // DDLarea.Items.Insert(0, new ListItem("All", "0"));


            //
            DDLstate.DataSource = Customer_cs.Get_DestinationMaster("state");
            DDLstate.DataBind();
            DDLstate.Items.Insert(0, new ListItem("--Select State--", "0"));
            DDLcity.Items.Insert(0, new ListItem("--Select City--", "0"));
            SetView();
           


            //

            txtjoin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtResign.Text = "30/01/2050";
            EmpId();
        }
        else
        {

        }
    }
    #endregion

    #region Events

    protected void btnSavE_Click(object sender, EventArgs e)
    {
        try
        {
            string Empcode = txtempCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
            string DepartmentID = txtDepCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();

            Employee _objEmployee = new Employee();

            string JoinDate = txtjoin.Text.Split('/')[1] + "/" + txtjoin.Text.Split('/')[0] + "/" + txtjoin.Text.Split('/')[2];
            string ResignationDate = txtResign.Text.Split('/')[1] + "/" + txtResign.Text.Split('/')[0] + "/" + txtResign.Text.Split('/')[2];
            _objEmployee.JoinDate = Convert.ToDateTime(JoinDate);
            _objEmployee.ResignationDate = Convert.ToDateTime(ResignationDate);
            _objEmployee.EmpID = Convert.ToInt32(LblEmpID.Text);
            _objEmployee.EmpCode = Empcode;
            _objEmployee.FirstName = txtFname.Text.Trim();
            _objEmployee.MiddleName = txtMname.Text.Trim();
            _objEmployee.LastName = txtLname.Text.Trim();
            _objEmployee.Address = txtAdd.Text.Trim();
            _objEmployee.State = DDLstate.SelectedValue;
            if (Convert.ToString(DDLcity.SelectedValue) == "0")//rajnish
            {
                _objEmployee.City = "";  //rajnish 

            }
            else  //rajnish
            { 
            _objEmployee.City = Convert.ToString(DDLcity.SelectedItem);  //rajnish 
            }
                _objEmployee.Zip = txtzipCode.Text.Trim();
            _objEmployee.Phone1 = txtphne1.Text.Trim();
            _objEmployee.Phone2 = txtphne2.Text.Trim();
            _objEmployee.Gender = Rdogender.Text;
            _objEmployee.DOB = txtDob.Text.Trim();
            _objEmployee.Qualification = ddlqulification.SelectedItem.Value;
            _objEmployee.Designation = DDlDesignation.SelectedItem.Value;
            _objEmployee.EmailID = txtEmail.Text.Trim();
            _objEmployee.DepartmentID = DepartmentID;
            _objEmployee.ZoneID = Convert.ToInt32(DDLzone.SelectedValue);
            _objEmployee.SuperZoneID = Convert.ToInt32(DDLsuperzone.SelectedValue);
            _objEmployee.AreaZoneID = Convert.ToInt32(DDLareazone.SelectedValue);
            
            _objEmployee.AreaID = Convert.ToInt32(0);
            _objEmployee.IsActive = Convert.ToBoolean(Chekacv.Checked);
            _objEmployee.IsDeleted = false;

            _objEmployee.SDZoneID = Convert.ToInt32(DDLSDZone.SelectedValue);
            if (lblImage.Text == "" || lblImage.Text.Split('.')[0].ToLower() != Empcode.ToLower())
            {
                if (FileUpload1.HasFile)
                {
                    _objEmployee.Photo = fileupload(Empcode);
                }
            }
            else
            {
                _objEmployee.Photo = lblImage.Text;
            }
            if (LblEmpID.Text == "0")
            {
                _objEmployee.Save(out EId);

                LblEmpID.Text = Convert.ToString(EId);
                Panel1.Visible = true;
                pnlEmployeeDetails.Visible = false;

               
                txtFname.Text = "";
                txtMname.Text = "";
                txtLname.Text = "";
                txtAdd.Text = "";
                txtzipCode.Text = "";
                txtphne1.Text = "";
                txtphne2.Text = "";
               // txtjoin.Text = "";
              //  txtResign.Text = "";
                txtDob.Text = "";
                txtEmail.Text = "";
                txtDepCode.Text = "";
                txtempCode.Text = "";
               // Chekacv.Checked = false;
                DDLstate.SelectedValue = null;
                DDLcity.SelectedValue = null;
                Rdogender.SelectedValue = null;
                DDlDesignation.SelectedValue = null;
                ddlqulification.SelectedValue = null;
                DDLsuperzone.SelectedValue = null;
                DDLzone.SelectedValue = null;
                DDLareazone.SelectedValue = null;
                DDLSDZone.SelectedValue = null;
               // DDLarea.SelectedValue = null;
            }
            else
            {

                _objEmployee.EmpID = Convert.ToInt32(LblEmpID.Text);
                _objEmployee.Update();
                pnlEmployeeDetails.Visible = true;
                Panel1.Visible = false;
                btnSavE.Visible = false;
                filter.Visible = true;
                grdEmpDetails.DataSource = BindGvEmpDetail();
                grdEmpDetails.DataBind();

            }
            int i = 0;
            foreach (ListItem lst in Chkarea.Items)
            {
                if (lst.Selected == true)
                {
                    if (lst.Value.ToString() == "0")
                    {
                        i = 1;
                    }
                }

                if (i == 1)
                {
                    if (lst.Value.ToString() != "0")
                    {
                        AreaEmployeeMapping _AEMapping = new AreaEmployeeMapping();
                        _AEMapping.EAmappingID = 0;
                        _AEMapping.EmpID = Convert.ToInt32(LblEmpID.Text);
                        _AEMapping.AreaID = Convert.ToInt32(lst.Value);
                        _AEMapping.IsActive = true;
                        _AEMapping.Save();
                        //Convert.ToInt32(LblEmpID.Text)
                        //lst.Value
                    }
                }
                else
                {
                    if (lst.Selected == true)
                    {
                        AreaEmployeeMapping _AEMapping = new AreaEmployeeMapping();
                        _AEMapping.EAmappingID = 0;
                        _AEMapping.EmpID = Convert.ToInt32(LblEmpID.Text);
                        _AEMapping.AreaID = Convert.ToInt32(lst.Value);
                        _AEMapping.IsActive = true;
                        _AEMapping.Save();
                        //Convert.ToInt32(LblEmpID.Text)
                        //lst.Value

                    }
                }
            }


            LblEmpID.Text = ""; 
            if (ChkLogin.Checked == true)
            {
                UserLoginDetails _objUsreLoginDetails = new UserLoginDetails();
                _objUsreLoginDetails.EmpID = Convert.ToInt32(LblEmpID.Text);
                _objUsreLoginDetails.RoleID = Convert.ToInt32(DdlRole.SelectedValue);
                _objUsreLoginDetails.Password = TxtPassword.Text.Trim();
                _objUsreLoginDetails.IsActive = true;
                _objUsreLoginDetails.Save();
            }
            MessageBox("Record saved successfully");
            LblEmpID.Text = "0";

        }
        catch
        {

        }
    }

    protected void ChkLogin_CheckedChanged(object sender, EventArgs e)
    {

        if (ChkLogin.Checked == true)
        {
            PnlLoginDetails.Visible = true;
        }
        else
        {
            PnlLoginDetails.Visible = false;
        }
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        LblEmpID.Text = "0";
        Panel1.Visible = true;
        pnlEmployeeDetails.Visible = false;

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        pnlEmployeeDetails.Visible = true;
        filter.Visible = true;
        btnSavE.Visible = false;
        btncancel.Visible = false;
    }

    protected void txtempCode_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string Empcode = txtempCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
                bool Auth = Masters.GetCodeValidation("EmpCode", Empcode);
                if (Auth)
                {
                    MessageBox("Emp Code is Already Exist");
                    txtempCode.Text = "";
                    txtempCode.Focus();

                }
                else
                {
                    FileUpload1.Focus();
                }
            }
            catch
            {

            }
        }
    }

    protected void txtDepCode_TextChanged(object sender, EventArgs e)
    {
        {
            try
            {
                string Departmentcode = txtDepCode.Text.Trim().Split(Constants.splitseperator)[0].ToString().Trim();
                bool Auth = Masters.GetCodeValidation("department", Departmentcode);
                if (Auth)
                {
                    DDLsuperzone.Focus();
                }
                else
                {
                    MessageBox("Deparment Code does not Exist");
                    txtDepCode.Text = "";
                    txtDepCode.Focus();
                }
            }
            catch
            {

            }
        }
    }

    #endregion

    #region GridviewEvent

    protected void grdEmpDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            pnlEmployeeDetails.Visible = false;
            Panel1.Visible = true;
            btnSavE.Visible = true;
            filter.Visible = false;

            txtempCode.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblEmpcode")).Text;
           // DDLsuperzone.DataSource = SuperZone.GetSuperzonemaster();
           // DDLsuperzone.DataBind();
          //  DDLsuperzone.Items.Insert(0, new ListItem("--Select SuperZone--", "0"));
            DDLSDZone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(0, "SDZone");
            DDLSDZone.DataBind();
            DDLSDZone.Items.Insert(0, new ListItem("All", "0"));
            //
            DDLstate.DataSource = Customer_cs.Get_DestinationMaster("state");
            DDLstate.DataBind();
            DDLstate.Items.Insert(0, new ListItem("--Select State--", "0"));
            //
            pnlEmployeeDetails.Visible = false;
            Panel1.Visible = true;
            LblEmpID.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblEID")).Text;
            txtFname.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblFName")).Text;
            txtMname.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblMiddleName")).Text;
            txtLname.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblLastName")).Text;
            Rdogender.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblGender")).Text;
            txtDob.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblDOB")).Text;
            //
            txtphne1.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblPhone1")).Text;
            txtphne2.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblPhone2")).Text;
            txtzipCode.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblZip")).Text;
            txtEmail.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblEmailID")).Text;
            txtAdd.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblAddress")).Text;
            ///
            DDLSDZone.SelectedValue = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblSDZoneId")).Text;
            DDLsuperzone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSDZone.SelectedValue.ToString()), "SuperZone1");
            DDLsuperzone.DataBind();
            DDLsuperzone.Items.Insert(0, new ListItem("All", "0"));
            ///
            //
            DDLsuperzone.SelectedValue = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblSuperZoneID")).Text;
            DDLzone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLsuperzone.SelectedValue.ToString()), "Zone");
            DDLzone.DataBind();
            DDLzone.Items.Insert(0, new ListItem("All", "0"));
            DDLzone.Enabled = true;

            //// 
            DDLzone.SelectedValue = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblZoneID")).Text;
            DDLareazone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLzone.SelectedValue.ToString()), "AreaZone");
            DDLareazone.DataBind();
            DDLareazone.Items.Insert(0, new ListItem("All", "0"));
            DDLareazone.Enabled = true;
            ////  
            DDLareazone.SelectedValue = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblAreaZoneID")).Text;
            Chkarea.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLareazone.SelectedValue.ToString()), "Area");
            Chkarea.DataBind();
            Chkarea.Items.Insert(0, new ListItem("All", "0"));
            Chkarea.Enabled = true;
            selectArea(Convert.ToInt32(LblEmpID.Text.Trim()));
              //Chkarea.SelectedValue = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblAreaID")).Text;
           
            txtDepCode.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblDeptId")).Text;
            string JoinDate = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblJoinDate")).Text;
            string ResignationDate = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblResignationDate")).Text;
            Chekacv.Checked = ((CheckBox)grdEmpDetails.Rows[e.NewEditIndex].FindControl("chkisActive")).Checked;
            txtjoin.Text = JoinDate;
            txtResign.Text = ResignationDate;
     
            DDLstate.SelectedValue = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblState")).Text;


                DDLcity.DataSource = Customer_cs.Get_DestinationMaster(DDLstate.SelectedValue.ToString());
                DDLcity.DataBind();
                DDLcity.Items.Insert(0, new ListItem("--Select City--", "0"));
                DDLcity.Enabled = true;
                DDLcity.Focus();
        
           // DDLcity.DataSource = Customer_cs.Get_DestinationMaster(DDLstate.SelectedValue.ToString());
           // DDLcity.DataBind();
           // DDLcity.Items.Insert(0, new ListItem("--Select City--", "0"));
           // DDLcity.Enabled = true;


            DDLcity.SelectedItem.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblCity")).Text;
            imgprof.ImageUrl = "../Images/profileimg/" + ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblphoto")).Text;
            lblImage.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("lblphoto")).Text;

            ddlqulification.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblQualification")).Text;
            fillQualification();
            DDlDesignation.Text = ((Label)grdEmpDetails.Rows[e.NewEditIndex].FindControl("LblDesignation")).Text;
            fillDesignation();

           
        }
        catch
        {

        }
    }

    protected void grdEmpDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int outid = 0;
        Employee _objEmp = new Employee();
        _objEmp.EmpID = Convert.ToInt32(((Label)grdEmpDetails.Rows[e.RowIndex].FindControl("lblEID")).Text);
        _objEmp.FirstName = ((Label)grdEmpDetails.Rows[e.RowIndex].FindControl("lblFName")).Text;
        _objEmp.EmpCode = ((Label)grdEmpDetails.Rows[e.RowIndex].FindControl("lblEmpCode")).Text;
        _objEmp.IsActive = Convert.ToBoolean(false);
        _objEmp.IsDeleted = Convert.ToBoolean(true);

        try
        {
            _objEmp.Save(out outid);
            MessageBox("Your record is Deleted");
            grdEmpDetails.DataSource = BindGvEmpDetail();
            grdEmpDetails.DataBind();
            Panel1.Visible = false;
            pnlEmployeeDetails.Visible = true;
        }
        catch
        {

        }
    }

    protected void grdEmpDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdEmpDetails.PageIndex = e.NewPageIndex;
        grdEmpDetails.DataSource = BindGvEmpDetail();
        grdEmpDetails.DataBind();
    }

    #endregion

    #region Binddata method

    public DataView BindGvEmpDetail()
    {
        DataTable dt = new DataTable();
        dt = Employee.Get_EmpList();
        DataView dv = new DataView(dt);
        return dv;
    }

    public void SetView()
    {
        if (Request.QueryString["a"] != null)
        {
            if (Request.QueryString["a"] == "a")
            {
                pageName.InnerHtml = "ADD Employee";
                LblEmpID.Text = "0";
                Panel1.Visible = true;
                txtempCode.Focus();
                pnlEmployeeDetails.Visible = false;
                BtnAdd.Visible = false;
                btnSavE.Visible = true;
                filter.Visible = false;
                btncancel.Visible = false;
                btnSavE.Visible = false;

            }
            else
                if (Request.QueryString["a"] == "v")
                {
                    pageName.InnerHtml = "Edit Employee";
                    Panel1.Visible = false;
                    pnlEmployeeDetails.Visible = true;
                    BtnAdd.Visible = false;
                    btnSavE.Visible = false;
                    btncancel.Visible = false;
                    filter.Visible = true;


                }
        }

    }

    public void fillQualification()
    {
        DataView dv = new DataView(Masterofmaster.Get_MasterOfMaster_ByGroup("Qualification").Tables[0]);
        dv.RowFilter = "IsActive = 1";
      
        ddlqulification.DataSource = dv;
        ddlqulification.DataBind();
        ddlqulification.Items.Insert(0, new ListItem("--Select Qualification--", "0"));
    }

    public void fillDesignation()
    {
        DataView dv1 = new DataView(Masterofmaster.Get_MasterOfMaster_ByGroup("Designation").Tables[0]);
        dv1.RowFilter = "IsActive = 1";
        
        DDlDesignation.DataSource = dv1;
        DDlDesignation.DataBind();
        DDlDesignation.Items.Insert(0, new ListItem("--Select Designation--", "0"));
    }
    #endregion

    #region MsgBox

    public void MessageBox(string msg)
    {
        string jv = "alert('" + msg + "');";
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", jv, true);
    }
    #endregion

    #region Selected Index Changed

    protected void DDLSDZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLsuperzone.Items.Clear();
        DDLsuperzone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLSDZone.SelectedValue.ToString()), "SuperZone1");
        DDLsuperzone.DataBind();
        DDLsuperzone.Items.Insert(0, new ListItem("All", "0"));
        DDLsuperzone.Enabled = true;
        DDLsuperzone.Focus();
    }

    protected void DDLsuperzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLzone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLsuperzone.SelectedValue.ToString()), "Zone");
        DDLzone.DataBind();
        DDLzone.Items.Insert(0, new ListItem("All", "0"));
        DDLzone.Enabled = true;

        if (DDLsuperzone.SelectedValue == "0")
                {
                    DDLzone.SelectedValue = "0";
                    DDLareazone.SelectedValue = "0";
                  //  DDLarea.SelectedValue = "0";
                    
                }
        DDLzone.Focus();
    }

    protected void DDLzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLareazone.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLzone.SelectedValue.ToString()), "AreaZone");
        DDLareazone.DataBind();
        DDLareazone.Items.Insert(0, new ListItem("All", "0"));
        DDLareazone.Enabled = true;
        DDLareazone.Focus();
    }

    protected void DDLareazone_SelectedIndexChanged(object sender, EventArgs e)
    {
        Chkarea.DataSource = Masters.Get_AreaZone_Zone_SuperZone(Convert.ToInt32(DDLareazone.SelectedValue.ToString()), "Area");
        Chkarea.DataBind();
        Chkarea.Items.Insert(0, new ListItem("All", "0"));
        //DDLarea.Enabled = true;
        Chkarea.Focus();
    }

    protected void DDLstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLstate.SelectedValue == "0")
        {
            
            DDLcity.Items.Clear();//rajnish
            DDLcity.Items.Insert(0, new ListItem("--Select City--", "0"));  //rajnish                        
        }
        else
        {
            DDLcity.DataSource = Customer_cs.Get_DestinationMaster(DDLstate.SelectedValue.ToString());
            DDLcity.DataBind();
            DDLcity.Items.Insert(0, new ListItem("--Select City--", "0"));
            //DDLcity.Items.Insert(0, new ListItem("--Select City--", "0"));
            DDLcity.Enabled = true;
             DDLcity.Focus();
            
        }
    }
    #endregion

    private void GenerateThumbnails(Stream sourcePath, string targetPath, int width, int height)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            var newWidth = width;//(int)(image.Width * scaleFactor);
            var newHeight = height;//(int)(image.Height * scaleFactor);
            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
            thumbGraph.Dispose();
            thumbnailImg.Dispose();
        }
    }

    //protected void FileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    //    {
     

    //}

    public  string fileupload(string fileName)
    {
        string filename = fileName;
        string ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
        string targetPath = Server.MapPath("Images/profileimg/" + filename + ext);
        Stream strm = FileUpload1.PostedFile.InputStream;
        var targetFile = targetPath;
        //Based on scalefactor image size will vary
        GenerateThumbnails(strm, targetFile, 90, 100);
        imgprof.ImageUrl = targetPath;
        
        return filename + ext;
    }

    public void selectArea(int empid)
    {
        
        DataTable dt = AreaEmployeeMapping.Get_EmployeeArea_Mapping(empid).Tables[0];
        for (int i = 0; i < dt.Rows.Count; i++)
        {   foreach (ListItem item in Chkarea.Items)
            {
                if (item.Value == dt.Rows[i]["AreaID"].ToString())
                {
                    item.Selected = true;
                }
            }
        }



    }
    public void EmpId()
    {
       // DataSet dsEmp = new DataSet();
     int   dsEmp = Employee.Get_EmployeeMaster_MaxId(out empid);
        
            txtempCode.Text = "Emp" + dsEmp;
       
    }

    protected void Chkarea_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}




