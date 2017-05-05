<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HelpDesk.ascx.cs" Inherits="UserControls_HelpDesk" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<link href="Css/popupmlz.css" rel="stylesheet" type="text/css" />

<script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
<link href="Css/TktHistory.css" type="text/css" rel="Stylesheet" />
<link href="Css/controls.css" type="text/css" rel="Stylesheet" />
<link href="Css/_newStyle.css" type="text/css" rel="Stylesheet" />
<link href="Css/dashcssFrontdesk.css" type="text/css" rel="Stylesheet" />



<script type="text/javascript">
    $(document).ready(function () {
        //hide the all of the element with class msg_body
        $(".msg_body").show();
        //toggle the componenet with class msg_body
        $(".msg_head").click(function () {
            $(this).next(".msg_body").toggle();
        });
    });

    function pageLoad(sender, args) {


        //toggle the componenet with class msg_body
        $(".msg_head").click(function () {
            $(this).next(".msg_body").toggle();
        });
    }

    function Closepopup(id) {
        if (id == 1) {
            $find('<%=ModalPopUpDocNum.ClientID %>').hide();
        }
        if (id == 2) {
            $find('<%=ModalPopupExtender1.ClientID %>').hide();
        }
        if (id == 3) {
            $find('<%=ModalPopupExtender2.ClientID %>').hide();
        }
        if (id == 4) {
            $find('<%=ModalPopupExtender3.ClientID %>').hide();
        }

    }
</script>
<script type="text/javascript">

    function onUpdating(divid) {
        // get the divImage
        var panelProg = $get(divid);
        // set it to visible
        panelProg.style.display = '';


    }

    function onUpdated(divid) {
        // get the divImage
        var panelProg = $get(divid);
        // set it to invisible
        panelProg.style.display = 'none';
    }
 
 
</script>
<script language="javascript" type="text/javascript">
    function validate() {
        if (document.getElementById("<%=txtcustomer.ClientID%>").value == "") {
            alert("Please Enter the Customer Details");
            document.getElementById("<%=txtcustomer.ClientID%>").focus();
            return false;
        }
        if (document.getElementById("<%=InqSeverity.ClientID%>").value == "-Select-") {
            alert("Plese Select the Severity");
            document.getElementById("<%=InqSeverity.ClientID%>").focus();
            return false;
        }
        if (document.getElementById("<%=InqSatatus.ClientID%>").value == "-Select-") {
            alert("Plese Select the Status");
            document.getElementById("<%=InqSatatus.ClientID%>").focus();
            return false;
        }
        if (document.getElementById("<%=txtRemarks.ClientID%>").value == "") {
            alert("Plese Enter the Remarks");
            document.getElementById("<%=txtRemarks.ClientID%>").focus();
            return false;
        }
    }
</script>
<style type="text/css">
    .style1
    {
        width: 255px;
    }
    .style2
    {
        width: 272px;
    }
</style>


<div class="column_left" id="clmlest" runat="server"  >
<asp:UpdatePanel ID="UpTicketInfo" runat="server">
<ContentTemplate>
<asp:UpdatePanel ID="UpdatePanel1385" ChildrenAsTriggers="true" runat="server">
<triggers>
<asp:AsyncPostBackTrigger ControlID="gvBind" />
</triggers>               
<ContentTemplate>
<asp:Panel ID="test12" runat="server">
<div id="testDiv" runat="server" style="margin: 4px 0px 2px 0px" >
<fieldset class="fieldsetTktHistory" id="FDTH" runat="server"><legend style="background-color: white; display:block;">Ticket History.</legend>
       <asp:GridView ID="gvBind" AutoGenerateColumns="False"
        HeaderStyle-BackColor="#6788BE" runat="server" AutoPostBack="true"  
        AllowSorting="True" AutoGenerateSelectButton="true" Width="100%"   
        ShowHeaderWhenEmpty="True" ToolTip="Click Here To View Ticket Details" 
           onrowdatabound="gvBind_RowDataBound" 
           onselectedindexchanged="gvBind_SelectedIndexChanged">
        <Columns>
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="TKTID" runat="server" Text='<%#Eval("TKTID") %>'></asp:Label> 
        </ItemTemplate>
        
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TKTNO" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="txtTktNo" runat="server" Text='<%#Eval("TktNumber") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Severity" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="Severity_Name" runat="server" Text='<%#Eval("Severity_Name") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>

    <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="Calling_Date" runat="server" Text='<%#Eval("CEmpLinkDate_Date") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>


    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="Status_Name" runat="server" Text='<%#Eval("Status_Name") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Exlation" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lblEclation" runat="server" Text='<%#Eval("Exlation") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
</Columns>
        
    </asp:GridView>
   </fieldset>
</div>  
</asp:Panel>

<div style="margin: 0px 1px 18px -1px;" id="divCMS" runat="server">
<asp:UpdatePanel ID="UpdateTicketInfo" runat="server"><ContentTemplate>
    <fieldset style="border-radius:5px;background-color: aliceblue;">
    <fieldset style="border-radius: 6px;"><legend style="display:block;"  Font-Size="Small" class="label">Ticket Information</legend>
    <table class="ticket_info">
     
        <tr style="float: left;">
            <td>
                &nbsp;</td>
            <%--<td class="label">
             Inquiry Types
                &nbsp;</td>--%>


          
                    <td>
            <asp:Label ID="Label4" Font-Size="Small" CssClass="lbl-form" runat="server" Text=" Inquiry Types"></asp:Label></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr style="float:left">
        <tr style="float: left; margin: 14px 17px 11px -117px;">
        <td class="label">
            <asp:RadioButtonList ID="iqnRadioButtonList" runat="server" 
                    RepeatDirection="Vertical" RepeatColumns="3"></asp:RadioButtonList></td>
        </tr>
        <tr style="float:left;margin: -10px 7px -6px 15px">
            <td>
            
                &nbsp;</td>
           <%-- <td class="label">
             Severity
                &nbsp;</td>--%>
                    <td>
            <asp:Label ID="Label3" Font-Size="Small" CssClass="lbl-form" runat="server" Text="Severity"></asp:Label></td>
            <td class="data">
            <asp:DropDownList ID="InqSeverity" runat="server" style="height:auto; width:113px;">
             </asp:DropDownList>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class="styleInqStatus">
            <td>
                &nbsp;
                </td>
                <td>
                
                <asp:Label ID="Label1" Font-Size="Small" CssClass="lbl-form" runat="server" Text="Status"></asp:Label></td>
            <td calss="data">
            <asp:DropDownList ID="InqSatatus" style="margin-left:0px; height:auto; width:113px;" runat="server">
             
          </asp:DropDownList>
                &nbsp;</td>
            <td>&nbsp;</td>
           <%-- <td>
                &nbsp;</td>--%>
        </tr>
        <tr class="styleInqStatus">
         <td>
             <asp:Label ID="lblExlation" Font-Size="Small" CssClass="lbl-form" runat="server" Text="Escalation"></asp:Label>
            </td>
            <td calss="data">
            <asp:DropDownList ID="ddlExlation" runat="server" DataTextField="Value" DataValueField="AutoId" style="margin-left:0px; height:auto; width:113px;">
            </asp:DropDownList>
            </td>
        </tr>
        <tr  style="float:left;margin: -16px 0px 4px 15px;">
            <td>
               </td>
           <%-- <td class="label"> Remarks</td>--%>
            <td>
            <asp:Label ID="Label2" Font-Size="Small" CssClass="lbl-form" runat="server" Text="Remarks"></asp:Label></td>
            <td class="data">
            <asp:TextBox ID="txtRemarks" CssClass="TextAera" runat="server"  TextMode="MultiLine"></asp:TextBox>
             </td>
         
        </tr>
     
        <tr style="float: left; margin: 35px -3px 0px 60px;">             
            <td align="right">
                &nbsp;</td>
            <td>
            <asp:Button ID="cmdCancel" CssClass="submitbtn" runat="server"  Text="Reset" 
                    onclick="cmdCancel_Click"/>
                &nbsp;&nbsp;
            <asp:Button ID="CmdGenerated"  runat="server" CssClass="submitbtn"  Text="Add New" OnClientClick="return validate()" onclick="CmdGenerated_Click" />
            <asp:Button ID="cmdUpdate" CssClass="submitbtn" runat="server"  Text="Append" OnClientClick="return validate()" onclick="cmdUpdate_Click" style="margin: 0px 5px 3px;"/>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        
    </table>
    </fieldset>
    </fieldset>
</ContentTemplate></asp:UpdatePanel>
</div>
    
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="PopupMP" UpdateMode="Conditional" runat="server"><ContentTemplate>
<asp:Panel ID="Rmkls" runat="server">
<div id="testRmk" runat="server" style="margin: -19px 2px 2px 5px; display: block; height: 62px;"   >
   <fieldset id="FDTH1" runat="server" style="background: rgb(190, 177, 177);padding-right:inherit;padding-left:inherit; border-radius:5%; padding:3px 2px 1px;"><legend style="background-color: white; display:block;">Remark History</legend>
        <asp:LinkButton ID="lblTicketNumber" runat="server" 
           onclick="lblTicketNumber_Click"></asp:LinkButton>
       <asp:GridView ID="gvRemarks" AutoGenerateColumns="False"  AutoGenerateSelectButton="true"
        HeaderStyle-BackColor="#6788BE" runat="server" AutoPostBack="true"  
        AllowSorting="false" Width="100%" 
           onselectedindexchanged="gvRemarks_SelectedIndexChanged" 
           onrowdatabound="gvRemarks_RowDataBound">
        <Columns>
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="TKTID" runat="server" Text='<%#Eval("TKT_ID") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="InquiryDate" runat="server" Text='<%#Eval("CEmpLink_Date") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
    <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <div style="overflow:hidden;text-overflow:ellipsis;white-space:nowrap;width:100px">
            <asp:Label ID="Remarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
    <asp:TemplateField HeaderText="CBD Representative" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="EmpName" runat="server" Text='<%#Eval("EmpCode") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>  
</Columns>
    </asp:GridView>
   </fieldset>
    </div>
    </asp:Panel>
</ContentTemplate>
</asp:UpdatePanel>
</div>
</ContentTemplate></asp:UpdatePanel>
</div>
<asp:Panel ID="PnlCR" runat="server" DefaultButton="btnGetRecords">
<div class="column_right">
<div class="column_right">
<div id="contentWrapWrap">
<table>
<tr>
<td> 
    <div id="contentWrap">
        <div id="contentTop">
        </div>
        <div id="contentMid">
            <div class="search">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox MaxLength="70" ID="txtcustomer" CssClass="txtSearchBar" runat="server"></asp:TextBox>
                            <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender1" CompletionListItemCssClass="AutoExtenderList1"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight1" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                                UseContextKey="true" ContextKey="EmpSuper" CompletionListElementID="dvcust">
                                <%-- customer --%>
                            </ajaxCt:AutoCompleteExtender>
                            <div id="dvcust" class="divauto1">
                            </div>
                        </td>
                        <td>
                            <asp:Button ID="btnGetRecords" runat="server" CssClass="btngetdetails" Text="Get Details"
                                OnClick="btnGetRecords_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCustomerName" CssClass="CustomerBigName" runat="server"></asp:Label>
                        <asp:Label ID="lblCustID" CssClass="CustomerBigName" runat="server" Style="display: none;"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="view view-dashboard-frontpage">
                <div class="view-content view-content-dashboard-frontpage">
                    <div class="panel-3col-33">
                        <div class="panel-col-first">
                            <div>
                                <div class="widget node">
                                    <div class="widgetTop">
                                    </div>
                                    <div class="widgetMid">
                                        <div class="widgetMidPad">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div id="divImage" style="display: none">
                                                        Processing...
                                                    </div>
                                                    <table class="uiInfoTable profileInfoTable">
                                                        <asp:Repeater ID="RepCustomerDetails" runat="server">
                                                            <ItemTemplate>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Code
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("CustCode")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Addr.
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("Address")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            City
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("City")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            State
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("State")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Zip
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("Zip")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Contact
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("contact")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Email
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("Email")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Type
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("type")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Principal
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("PrincipalName")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Black Listed
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("blkList")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <%--<asp:Repeater ID="RepOutStanding" runat="server">
                                                            <ItemTemplate>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            OutStanding
                                                                        </th>
                                                                        <td class="data">
                                                                            <img src="Images/dash/rupee_symbol_bl.gif" />
                                                                            <%# " " + Eval("OutStanding") %>&nbsp;<%#Eval("crdr")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </ItemTemplate>
                                                        </asp:Repeater>--%>
                                                        <asp:Repeater ID="RepOutStanding" runat="server">
                                                            <ItemTemplate>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            OutStanding
                                                                        </th>
                                                                        <td class="data">
                                                                            <img src="Images/dash/rupee_symbol_bl.gif" />
                                                                            <%# " " + Eval("os","{0:0.00}") %>
                                                                            <%--<%# Convert.ToDecimal(Eval("os", "{0:0.00}")) > 0 ? Eval("os", "{0:0.00}") + " Dr." : Eval("os", "{0:0.00}") + " Cr."%>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widgetInfoBar">
                                        <div class="updated">
                                            <p>
                                                Customer Details</p>
                                        </div>
                                        <%--<div class="more">
                                                <a href="/series/New+Works+on+View">More</a></div>--%>
                                    </div>
                                </div>
                                <div class="widget node">
                                    <div class="widgetTop">
                                    </div>
                                    <div class="widgetMid">
                                        <div class="widgetMidPad">
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <div id="div1" style="display: none">
                                                        Processing...
                                                    </div>
                                                    <table class="uiInfoTable profileInfoTable">
                                                        <tbody>
                                                            <asp:Repeater ID="CustomerDiscount" runat="server">
                                                                <HeaderTemplate>
                                                                    <tr>
                                                                        <th>
                                                                            Book Types
                                                                        </th>
                                                                        <td>
                                                                            Discount(%)
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="border-bottom: 2px solid #000">
                                                                        <td>
                                                                            &nbsp
                                                                        </td>
                                                                        <td class="data" align="right">
                                                                        </td>
                                                                    </tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr style="border-bottom: 1px solid #ccc">
                                                                        <td>
                                                                            <%#Eval("Name")%>
                                                                        </td>
                                                                        <td class="data" align="right">
                                                                            <b>
                                                                                <%#Eval("Discount","{0:0.00}")%></b>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <tr class="spacer">
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblDiscMsg" ForeColor="Red" Font-Bold="true" runat="server" Visible="false"
                                                                        Text="Discount yet not given."></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widgetInfoBar">
                                        <div class="updated">
                                            <p>
                                                Customer Discount</p>
                                        </div>
                                        <%--<div class="more">
                                                <a href="/series/New+Works+on+View">More</a></div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-col">
                            <div>
                                <div class="widget node">
                                    <div class="widgetTop">
                                    </div>
                                    <div class="widgetMid">
                                        <div class="widgetMidPad">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <div id="divup2" style="display: none">
                                                        Processing...
                                                    </div>
                                                    <table class="uiInfoTable profileInfoTable">
                                                        <asp:Repeater ID="REpChetanaForcust" runat="server">
                                                            <ItemTemplate>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Salesman
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("Employee")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            SuperZone
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("superzone")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Zone
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("Zone")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Zone Area
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("AZone")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Area
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("area")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="label">
                                                                            Transporter
                                                                        </th>
                                                                        <td class="data">
                                                                            <%#Eval("Transporter")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widgetInfoBar">
                                        <div class="updated">
                                            <p>
                                                Zone & Transporter Details
                                            </p>
                                        </div>
                                        <%--<div class="more">
                                                <a href="/series/New+Works+on+View">More</a></div>--%>
                                    </div>
                                </div>
                                <div class="widget node">
                                    <div class="widgetTop">
                                    </div>
                                    <div class="widgetMid">
                                        <div class="widgetMidPad">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <div id="divup3" style="display: none">
                                                        Processing...
                                                    </div>
                                                    <table class="uiInfoTable profileInfoTable" style="width: 100%">
                                                        <asp:Repeater ID="RepPayment" runat="server">
                                                            <ItemTemplate>
                                                                <tbody>
                                                                    <tr class="msg_head">
                                                                        <th class="label" style="width: 60px;">
                                                                            <%#Eval("ICOn")%>
                                                                            <%--<%#Eval("Deposite_Type")%>--%>
                                                                        </th>
                                                                        <td class="data">
                                                                            <b>
                                                                                <%# Eval("ChequeDate")%></b>
                                                                            <div style="float: right; width: 107px">
                                                                                <img src="Images/dash/rupee_symbol_bl.gif" /><%# " " +Eval("Amount","{0:0.00}")%>
                                                                                <span style="float: right">
                                                                                    <img src="Images/dash/drill.png" /></span></div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="msg_body">
                                                                        <th class="label">
                                                                            Details
                                                                        </th>
                                                                        <td class="data">
                                                                            <%# "<b>Dep. Date: </b>" + Eval("DepositDate")%><br />
                                                                            <%--<%# "<b>Chq. Date: </b>" + Eval("ChequeDate")%><br />--%>
                                                                            <%# "<b>Chq. No.: </b>" + Eval("ChequeNo")%><br />
                                                                            <%# "<b>Bank.: </b>" + Eval("BankName")%><br />
                                                                            -------------------------------------<br />
                                                                            <%# "<b>Recp. No: </b>" + Eval("ReciptNo")%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widgetInfoBar">
                                        <div class="updated">
                                            <p>
                                                Payment
                                            </p>
                                        </div>
                                        <%--<div class="more">
                                                <a href="/series/New+Works+on+View">More</a></div>--%>
                                    </div>
                                </div>
                                <div class="widget node">
                                    <div class="widgetTop">
                                    </div>
                                    <div class="widgetMid">
                                        <div class="widgetMidPad">
                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                <ContentTemplate>
                                                    <div id="div2" style="display: none">
                                                        Processing...
                                                    </div>
                                                    <table class="uiInfoTable profileInfoTable">
                                                        <tbody>
                                                            <asp:Repeater ID="rptPOD" runat="server">
                                                                <HeaderTemplate>
                                                                    <tr>
                                                                        
                                                                        <th>
                                                                            Doc Date
                                                                        </th>
                                                                        <th>
                                                                            Invoice No
                                                                        </th>
                                                                        <th>
                                                                           Courier No
                                                                        </th>
                                                                        <th>
                                                                          POD
                                                                        </th>
                                                                       
                                                                    </tr>
                                                                    <tr style="border-bottom: 2px solid #000">
                                                                        <td>
                                                                            &nbsp
                                                                        </td>
                                                                        <td class="data" align="right">
                                                                        </td>
                                                                    </tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr style="border-bottom: 1px solid #ccc">
                                                                      
                                                                        <td align="center">
                                                                            <%#Eval("CreatedOn")%>
                                                                        </td>
                                                                        <td align="center">
                                                                            <%#Eval("InvoiceNo")%>
                                                                        </td>
                                                                        <td align="center">
                                                                            <%#Eval("SCMasterAutoId")%>
                                                                        </td>
                                                                        <td align="center">
                                                                            <%#Eval("PODId")%>
                                                                        </td>
                                                                       
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widgetInfoBar">
                                        <div class="updated">
                                            <p>
                                                Courier - POD Details</p>
                                        </div>
                                        <%--<div class="more">
                                                <a href="/series/New+Works+on+View">More</a></div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-col-last">
                            <div>
                                <div class="widget node">
                                    <div class="widgetTop">
                                    </div>
                                    <div class="widgetMid">
                                        <div class="widgetMidPad">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div id="divup4" style="display: none">
                                                        Processing...
                                                    </div>
                                                    <table class="uiInfoTable profileInfoTable" style="width: 255px">
                                                        <asp:Repeater ID="RepChLstOrder" runat="server" OnItemDataBound="RepChLstOrder_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDocId" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                                                <tbody>
                                                                    <tr class="msg_head">
                                                                        <th class="label" style="width: 60px">
                                                                            Doc. No.
                                                                        </th>
                                                                        <td class="data">
                                                                            <b>
                                                                                <%#Eval("DocumentNo_New")%></b>
                                                                            <div style="float: right">
                                                                                <%#Eval("Status")%>
                                                                                &nbsp;&nbsp;
                                                                                <asp:ImageButton ID="img01" ImageUrl="../Images/dash/expand.png" ToolTip="D.C. Details"
                                                                                    runat="server" OnClick="img01_Click" CommandName='<%#Eval("type")%>' CommandArgument='<%#Eval("DocumentNo")%>' />&nbsp;&nbsp;
                                                                                <img src="Images/dash/drill.png" /></span></div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="msg_body">
                                                                        <th class="label">
                                                                            Details
                                                                        </th>
                                                                        <td class="data">
                                                                            <b>DC Amt</b>
                                                                            <img src="Images/dash/rupee_symbol_bl.gif" /><%# " " +Eval("Amount","{0:0.00}")%><br />
                                                                            ----------------------------------
                                                                            <asp:Repeater ID="RepSubDetails" runat="server">
                                                                                <ItemTemplate>
                                                                                    <%#"<b>Inv.Date</b>: "+Eval("InvoiceDate")%><br />
                                                                                    <%#"<b>Inv.No.</b>: " + Eval("SubDocId")%><br />
                                                                                    <b>Inv.Amt.</b>:
                                                                                    <img src="Images/dash/rupee_symbol_bl.gif" /><%#" " + Eval("Amount","{0:0.00}")%><br />
                                                                                    <%#"<b title='Bundles'>Bundles</b>: " + Eval("Bundles")%><br />
                                                                                    <%#"<b title='Transporter'>Trns.</b>: " + Eval("Transporter")%><br />
                                                                                    <%#"<b>LR No.</b>: " + Eval("LRNo")%><br />
                                                                                    <%#"<b title='Special Instruction'>Sp. Inst</b>: " + Eval("SpInstruction")%><br />
                                                                                    ----------------------------------
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="spacer">
                                                                        <td colspan="2">
                                                                            <hr>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widgetInfoBar">
                                        <div class="updated">
                                            <p>
                                                Last 3 D.C. Status</p>
                                        </div>
                                        <%--<div class="more">
                                                <a href="/series/New+Works+on+View">More</a></div>--%>
                                    </div>
                                </div>
                                <div class="widget node">
                                    <div class="widgetTop">
                                    </div>
                                    <div class="widgetMid">
                                        <div class="widgetMidPad">
                                            <div class="widgetMidPad">
                                                <asp:UpdatePanel ID="UpdatePanel11" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>
                                                        <div id="divup6" style="display: none">
                                                            Processing...
                                                        </div>
                                                        <table class="uiInfoTable profileInfoTable" style="width: 100%">
                                                            <asp:Repeater ID="rptConfirmed" runat="server">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDocId3" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                                                    <tbody>
                                                                        <tr>
                                                                            <th class="label" style="width: 60px">
                                                                                Doc. No.
                                                                            </th>
                                                                            <td class="data">
                                                                                <b>
                                                                                    <%#Eval("DocumentNo_New")%></b>
                                                                                <%-- <span style="float: right">
                                                                                    <img src="Images/dash/drill.png" /></span>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="label">
                                                                                Details
                                                                            </th>
                                                                            <td class="data">
                                                                                <%#"<b>Ord.Date</b>: " + Eval("OrderDate")%><br />
                                                                                <%--<b>DC Amt</b>
                                                                                <img src="Images/dash/rupee_symbol_bl.gif" />--%>
                                                                                <%--<%# " " +Eval("Amount","{0:0.00}")%>--%>
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("DocumentNo_New")%>'  OnClick="lnkMoreDc_Click"
                                                                                    Visible="True">Details</asp:LinkButton>
                                                                                <br />
                                                                                <%--<asp:Repeater ID="RepSubDetails" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <%#"<b>Inv.Date</b>: "+Eval("InvoiceDate")%><br />
                                                                                        <%#"<b>Inv.No.</b>: " + Eval("SubDocId")%><br />
                                                                                        <b>Inv.Amt.</b>:
                                                                                        <img src="Images/dash/rupee_symbol_bl.gif" /><%#Eval("Amount","{0:0.00}")%><br />
                                                                                        <%#"<b>LR No.</b>: " + Eval("LRNo")%><br />
                                                                                        <%#"<b title='Special Instruction'>Sp. Inst</b>: " + Eval("SpInstruction")%><br />
                                                                                        ----------------------------------
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="spacer">
                                                                            <td colspan="2">
                                                                                <hr>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <div class="clear">
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widgetInfoBar">
                                        <div class="updated">
                                            <p>
                                                Last 3 Confirmed D.C.</p>
                                        </div>
                                        <div class="more">
                                            <asp:UpdatePanel ID="UpdatePanel12" UpdateMode="Conditional" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument="confirmed" OnClick="lnkMoreDc_Click"
                                                        Visible="True">View All</asp:LinkButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="widget node">
                                    <div class="widgetTop">
                                    </div>
                                    <div class="widgetMid">
                                        <div class="widgetMidPad">
                                            <div class="widgetMidPad">
                                                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                                                    <ContentTemplate>
                                                        <div id="divup5" style="display: none">
                                                            Processing...
                                                        </div>
                                                        <table class="uiInfoTable profileInfoTable" style="width: 100%">
                                                            <asp:Repeater ID="RepPendingDC" runat="server">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDocId" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                                                    <tbody>
                                                                        <tr>
                                                                            <th class="label" style="width: 60px">
                                                                                Doc. No.
                                                                            </th>
                                                                            <td class="data">
                                                                                <b>
                                                                                    <%#Eval("DocumentNo_New")%></b>
                                                                                <%-- <span style="float: right">
                                                                                    <img src="Images/dash/drill.png" /></span>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th class="label">
                                                                                Details
                                                                            </th>
                                                                            <td class="data">
                                                                                <%#"<b>Ord.Date</b>: " + Eval("OrderDate")%><br />
                                                                                <b>DC Amt</b>
                                                                                <img src="Images/dash/rupee_symbol_bl.gif" />
                                                                                <%# " " +Eval("Amount","{0:0.00}")%><br />
                                                                                <%--<asp:Repeater ID="RepSubDetails" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <%#"<b>Inv.Date</b>: "+Eval("InvoiceDate")%><br />
                                                                                        <%#"<b>Inv.No.</b>: " + Eval("SubDocId")%><br />
                                                                                        <b>Inv.Amt.</b>:
                                                                                        <img src="Images/dash/rupee_symbol_bl.gif" /><%#Eval("Amount","{0:0.00}")%><br />
                                                                                        <%#"<b>LR No.</b>: " + Eval("LRNo")%><br />
                                                                                        <%#"<b title='Special Instruction'>Sp. Inst</b>: " + Eval("SpInstruction")%><br />
                                                                                        ----------------------------------
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="spacer">
                                                                            <td colspan="2">
                                                                                <hr>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <div class="clear">
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widgetInfoBar">
                                        <div class="updated">
                                            <p>
                                                Last 3 Pending D.C.</p>
                                        </div>
                                        <div class="more">
                                            <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Conditional" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="lnkMoreDc1" runat="server" OnClick="lnkMoreDc_Click" CommandArgument="pendingdc"
                                                        Visible="True">View All</asp:LinkButton>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnGetRecords" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br class="panel-clearer">
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="contentBtm">
        </div>
    </div>
    </table>
    </td>
    
    </tr>
    
<div>
<ajaxCt:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender1" TargetControlID="UpdatePanel1"
    runat="server">
    <Animations>
            <OnUpdating>
               <Parallel duration="0">
                    <ScriptAction Script="onUpdating('divImage');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="false" />                   
                </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                    <ScriptAction Script="onUpdated('divImage');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="true" />
                </Parallel>
            </OnUpdated>
    </Animations>
</ajaxCt:UpdatePanelAnimationExtender>
<ajaxCt:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender2" TargetControlID="UpdatePanel2"
    runat="server">
    <Animations>
            <OnUpdating>
               <Parallel duration="0">
                    <ScriptAction Script="onUpdating('divup2');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="false" />                   
                </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                    <ScriptAction Script="onUpdated('divup2');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="true" />
                </Parallel>
            </OnUpdated>
    </Animations>
</ajaxCt:UpdatePanelAnimationExtender>
<ajaxCt:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender3" TargetControlID="UpdatePanel5"
    runat="server">
    <Animations>
            <OnUpdating>
               <Parallel duration="0">
                    <ScriptAction Script="onUpdating('divup3');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="false" />                   
                </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                    <ScriptAction Script="onUpdated('divup3');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="true" />
                </Parallel>
            </OnUpdated>
    </Animations>
</ajaxCt:UpdatePanelAnimationExtender>
<ajaxCt:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender4" TargetControlID="UpdatePanel3"
    runat="server">
    <Animations>
            <OnUpdating>
               <Parallel duration="0">
                    <ScriptAction Script="onUpdating('divup4');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="false" />                   
                </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                    <ScriptAction Script="onUpdated('divup4');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="true" />
                </Parallel>
            </OnUpdated>
    </Animations>
</ajaxCt:UpdatePanelAnimationExtender>
<ajaxCt:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender5" TargetControlID="UpdatePanel4"
    runat="server">
    <Animations>
            <OnUpdating>
               <Parallel duration="0">
                    <ScriptAction Script="onUpdating('divup5');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="false" />                   
                </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                    <ScriptAction Script="onUpdated('divup5');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="true" />
                </Parallel>
            </OnUpdated>
    </Animations>
</ajaxCt:UpdatePanelAnimationExtender>
<ajaxCt:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender6" TargetControlID="UpdatePanel12"
    runat="server">
    <Animations>
            <OnUpdating>
               <Parallel duration="0">
                    <ScriptAction Script="onUpdating('divup6');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="false" />                   
                </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                    <ScriptAction Script="onUpdated('divup6');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="true" />
                </Parallel>
            </OnUpdated>
    </Animations>
</ajaxCt:UpdatePanelAnimationExtender>
<asp:Panel ID="pnlBooks" Style="display: none; width: 80%; height: 400px" runat="server">
    <div class="facebox" style="width: 100%; height: 390px;">
        <a id="A1" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup(1);">
            <img src="Images/button-cross.png" /></a>
        <br />
        <div class="content" style="width: 98%; height: 347px; overflow: auto; display: block;">
            <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdconfirm" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                        AutoGenerateColumns="false" runat="server" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:Label ID="lblbook" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                    <asp:Label ID="lblDCdatils" Style="display: none;" runat="server" Text='<%#Eval("DCDetailID")%>'></asp:Label>
                                    <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Book Name" HeaderStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                                <ItemTemplate>
                                    <asp:Label ID="lblqty" Style="text-align: right;" runat="server" Text='<%#Eval("RemainQty")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                                <ItemTemplate>
                                    <asp:Label ID="lblprice" Style="text-align: right;" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeliveryDate" Style="text-align: right;" runat="server" Text='<%#Eval("DeliveryDate")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="Panel1" Style="display: none; width: 80%; height: 400px" runat="server">
    <div class="facebox" style="width: 100%; height: 390px;">
        <a id="A2" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup(2);">
            <img src="Images/button-cross.png" /></a>
        <br />
        <div class="content" style="width: 98%; height: 347px; overflow: auto; display: block;">
            <asp:UpdatePanel ID="UpdatePanel8" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="RepDetailsApprove" runat="server" OnItemDataBound="RepDetailsConfirm_ItemDataBound">
                        <ItemTemplate>
                            <div class="actiontab" style="margin-bottom: 2px;">
                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                    <tr>
                                        <td valign="bottom">
                                            <span>Invoice No :
                                                <asp:Label ID="SubConfirmID" Style="font-weight: bold; font-size: 13px;" runat="server"
                                                    Text='<%#Eval("SubConfirmID")%>'></asp:Label>
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:GridView ID="grdapproval" AlternatingRowStyle-CssClass="alt" Width="100%" CssClass="product-table"
                                ShowFooter="true" AutoGenerateColumns="false" runat="server" OnRowDataBound="grdapproval_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbookC" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                            <asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("GanerateinvoiceId")%>'></asp:Label>
                                            <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Book Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbookN" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                        FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                        FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("Discount","{0:0.00}")%>'
                                                HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblT" runat="server" Text=" Total : "></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqunty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Qty" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="right"
                                        HeaderStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqunty" Style="display: none; text-align: right;" runat="server"
                                                Text='<%#Eval("Quantity")%>'></asp:Label>
                                            <asp:Label ID="lblAqty" Style="text-align: right;" runat="server" Text='<%#Eval("AvailableQty")%>'
                                                ToolTip="show details"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalqty" runat="server" Text=""></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                        FooterStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamt" runat="server" Text='<%#Eval("RevisedAmt","{0:0.00}")%>' HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalAmt" runat="server" Text=""></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <table style="float: right;" cellspacing="2" cellpadding="2">
                                <tr>
                                    <td valign="bottom">
                                        <asp:Label ID="lbl1" Style="font-size: 12px; font-weight: bold;" runat="server" Text="  Freight   "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblfright" CssClass="inp-form" Width="50px" Style="font-size: 12px;
                                            text-align: right; font-weight: bold" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl2" Style="font-size: 12px; text-align: right; font-weight: bold"
                                            runat="server" Text="  Tax   "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltax" CssClass="inp-form" Width="50px" Style="font-size: 12px; text-align: right;
                                            font-weight: bold" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblt" Style="font-size: 12px; text-align: right; font-weight: bold"
                                            runat="server" Text="  Total Amount  "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbltotalamt" CssClass="inp-form" Width="50px" Style="font-size: 12px;
                                            text-align: right; font-weight: bold" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <hr style="background-color: Red" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Panel>
<div>
<asp:Panel ID="Panel2" Style="display:block; width: 80%; height: 400px" runat="server">
     <div class="facebox" style="width: 100%; height: 390px;">
        <a id="A3" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup(3);">
            <img src="Images/button-cross.png" /></a>
        <br />
        <div class="content" style="width: 98%; height: 347px; overflow: auto; display: block;">
            <asp:UpdatePanel ID="UpdatePanel13" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                <ItemTemplate>
               <div class="actiontab" style="margin-bottom: 2px;">
                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                    <tr>
                        <p style="font-size: 17px; align-items: center; margin: 3px 4px 4px 111px;">
                            Remarks Details</p>
                        <p>
                            Ticket Number    
                            <asp:TextBox ID="lblTicket" runat="server" ReadOnly="true" style="width: 250px; margin: 10px 7px 9px;" /><br />
                            Raised Date    
                            <asp:TextBox ID="lblDate" runat="server" ReadOnly="true" style="width: 250px; margin: 10px 18px 11px;" /><br />
                            EmpName
                            <asp:TextBox ID="lblEmpName" runat="server" ReadOnly="true" style="width: 250px; margin: 10px 28px 13px;"/><br />
                            Remarks
                            <asp:TextBox ID="lblRemarks" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="10" style="width: 400px; margin: 3px 3px -165px 32px; resize: none;"/>
                        </p>
                        
                        </tr>
                            </table>
                            </div>  
         </ItemTemplate>
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        </div>
        </asp:Panel>
</div>

<asp:Panel ID="Panel3" Style="display:block; width: 80%; height: 400px" runat="server">
     <div class="facebox" style="width: 100%; height: 390px;">
        <a id="A4" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup(4);">
            <img src="Images/button-cross.png" /></a>
        <br />
        <div class="content" style="width: 98%; height: 347px; overflow: auto; display: block;">
            <asp:UpdatePanel ID="UpdatePanel15" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                <ItemTemplate>
               <div class="actiontab" style="margin-bottom: 2px;">
                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                    <tr>
                   <asp:GridView ID="popGridview" AutoGenerateColumns="False"
        HeaderStyle-BackColor="#6788BE" runat="server" AutoPostBack="true"  
        AllowSorting="false" Width="100%">
        <Columns>
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="TKTID" runat="server" Text='<%#Eval("TKT_ID") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="InquiryDate" runat="server" Text='<%#Eval("CEmpLink_Date") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
    <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
             <asp:Label ID="Remarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
    <asp:TemplateField HeaderText="CBD Representative" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="EmpName" runat="server" Text='<%#Eval("EmpCode") %>'></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>  
</Columns>
    </asp:GridView>
                        </tr>
                            </table>
                            </div>  
         </ItemTemplate>
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        </div>
        </asp:Panel>
</div>



</div>
    <ajaxCt:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="LinkButton4"
    PopupControlID="Panel2" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false"/>

     <ajaxCt:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="LinkButton5"
    PopupControlID="Panel3" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false"/>

      <ajaxCt:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
    PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false"/>


<asp:LinkButton ID="LinkButton5" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<asp:LinkButton ID="LinkButton4" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<asp:LinkButton ID="LinkButton1" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<ajaxCt:ModalPopupExtender ID="ModalPopUpDocNum" runat="server" TargetControlID="LnkBtn"
    PopupControlID="pnlBooks" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<ajaxCt:ModalPopupExtender ID="TicketRemarksMP" runat="server" TargetControlID="LinkButton3"
    PopupControlID="pnlPopup" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LinkButton3" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
</div>
</div>
</asp:Panel>