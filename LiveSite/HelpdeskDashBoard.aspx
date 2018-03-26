<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="HelpdeskDashBoard.aspx.cs" Inherits="HelpdeskDashBoard" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript">
    $(document).ready(function () {
        //hide the all of the element with class msg_body
        $(".msg_body").show();
        //toggle the componenet with class msg_body
        $(".msg_head").click(function () {
            $(this).next(".msg_body").toggle();
        });
    });d

    function pageLoad(sender, args) {


        //toggle the componenet with class msg_body
        $(".msg_head").click(function () {
            $(this).next(".msg_body").toggle();
        });
    }
</script>

<script type="text/javascript">
  function Closepopup(id)
     {
       
        if (id == 4) 
        {
            $find('<%=ModalPopupExtender2.ClientID %>').hide();
        }

    }
</script>

 <div class="section-header">


        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details"/>
            CMS DashBoard <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
  
 <div class="dashboard_panel">
    <asp:DataList ID="DLDashboard1" CellPadding="0" runat="server" RepeatColumns="4">
    <ItemTemplate>
        
        <div id="Div1" class="dashboardback_edited" CssClass="panelDetails" runat="server" >
            <table border="0" width="90%" cellpadding="0">
                <tr>
                    <td valign="bottom" align="left"> <asp:Label ID="Label2" CssClass="count1" runat="server" Text='<%#Eval("statusno ")%>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top:08px;" align="left">
                        <span>
                            <%#Eval("Status_Name")%></span>
                    </td>
                </tr>
            </table>
        </div>
    </ItemTemplate>
</asp:DataList>
<asp:DataList ID="DLDashboard2" CellPadding="0" runat="server" RepeatColumns="4">
    <ItemTemplate>
        <div class="dashboardback_edited" CssClass="panelDetails" runat="server" >
            <table border="0" width="90%" cellpadding="0">
                <tr>
                    <td valign="bottom" align="left"> <asp:Label ID="Label1" CssClass="count1" runat="server" Text='<%#Eval("Severityno ")%>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top:08px;" align="left">
                        <span>
                            <%#Eval("Severity_Name")%></span>
                    </td>
                </tr>
            </table>
        </div>
    </ItemTemplate>
</asp:DataList>
</div>
<br />
<asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" style="float: left; margin: 0 10px 7px 0; position: relative; width: 971px;">
<asp:Panel ID="pnlEmployeeDetails" CssClass="pnldash" runat="server"   GroupingText="Recent Open Enquiries">
        <asp:GridView ID="grdEnquires" runat="server" 
        AutoGenerateColumns="False" AutoGenerateSelectButton="false"  AutoPostBack="true" 
        CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="957px" 
            AllowPaging="True" onpageindexchanging="grdEnquires_PageIndexChanging1">
        <Columns>
         <asp:TemplateField HeaderText="Sr No" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lbltktno" runat="server" Text= <%#Container.DataItemIndex+1 %>></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Edit Date" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblDateCEmpLink_Date" runat="server" Text='<%#Eval("CEmpLink_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ticket No" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lbltktnoTktNumber" runat="server" Text='<%#Eval("TktNumber") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cust Code" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblcustnmCustCode" runat="server" Text='<%#Eval("CustCode") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cust Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblcustnm2" runat="server" Text='<%#Eval("CustName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            
          <%--  <asp:TemplateField HeaderText="Area" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblinType" runat="server" Text='<%#Eval("AreaCode ") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblSvType" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Inquiry Remraks" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblStypeRemarks" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblDateStatus_Name" runat="server" Text='<%#Eval("Status_Name") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Severity" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblSeverity" runat="server" Text='<%#Eval("Severity") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="CBD Representative" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblDateFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                </ItemTemplate>
                 <HeaderStyle HorizontalAlign="Center" />
                 <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Status Escalation" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblStatus_Escalation" runat="server" Text='<%#Eval("Status_Escalation") %>'></asp:Label>
                </ItemTemplate>
                 <HeaderStyle HorizontalAlign="Center" />
                 <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Remark Escalation" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="LblRemark_Escalation" runat="server" Text='<%#Eval("Remark_Escalation") %>'></asp:Label>
                </ItemTemplate>
                 <HeaderStyle HorizontalAlign="Center" />
                 <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
         
              <asp:TemplateField HeaderText="Action"  HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                 <asp:LinkButton ID="lnkView" runat="server" Text="View Details" 
                        onclick="lnkView_Click"></asp:LinkButton>
                </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
</asp:Panel>

<asp:Panel ID="Panel3" Style="display:none; width: 80%; height: 400px" runat="server">
     <div class="facebox" style="width: 100%; height: 390px;">
        <a id="A4" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup(4);">
            <img src="Images/button-cross.png" /></a>
        <br />
        <div class="content" style="width: 97%; height: 347px; overflow: auto; display: block;">
            <asp:UpdatePanel ID="UpdatePanel15" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                <ItemTemplate>
               <div class="actiontab" style="margin-bottom: 2px;">
                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                    <asp:GridView ID="popGridview" runat="server" AllowSorting="false" 
                                        AutoGenerateColumns="False" AutoPostBack="true" HeaderStyle-BackColor="#6788BE" 
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="TKTID" runat="server" Text='<%#Eval("TKT_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="InquiryDate" runat="server" Text='<%#Eval("CEmpLink_Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="Remarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="EmpName">
                                                <ItemTemplate>
                                                    <asp:Label ID="EmpName" runat="server" Text='<%#Eval("EmpCode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                            </table>
                            </div>  
         </ItemTemplate>
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        </div>
        </asp:Panel>

           <ajaxCt:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="LinkButton5"
    PopupControlID="Panel3" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false"/>
    <asp:LinkButton ID="LinkButton5" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
</asp:Content>


