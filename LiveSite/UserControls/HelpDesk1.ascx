<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HelpDesk.ascx.cs" Inherits="UserControls_HelpDesk" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<link href="Css/popupmlz.css" rel="stylesheet" type="text/css" />

<script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

<script type="text/javascript">
$(document).ready(function()
{
  //hide the all of the element with class msg_body
  $(".msg_body").hide();
  //toggle the componenet with class msg_body
  $(".msg_head").click(function()
  {
    $(this).next(".msg_body").toggle();
  });
});

function pageLoad(sender, args) 
        {
 
 
  //toggle the componenet with class msg_body
  $(".msg_head").click(function()
  {
    $(this).next(".msg_body").toggle();
  });
        }

function Closepopup(id)
   {
    if(id==1)
     {
        $find('<%=ModalPopUpDocNum.ClientID %>').hide();
     }
      if(id==2)
     {
        $find('<%=ModalPopupExtender1.ClientID %>').hide();
     }
     
   }
</script>

<script type="text/javascript">
 
        function onUpdating(divid)
        {
            // get the divImage
            var panelProg = $get(divid);
            // set it to visible
            panelProg.style.display = '';
 
            
        }
 
        function onUpdated(divid)
        {
            // get the divImage
            var panelProg = $get(divid);
            // set it to invisible
            panelProg.style.display = 'none';
        }
 
 
</script>

<div id="contentWrapWrap">
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
                                UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
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
                                                                            <%# "<b>Chq. Date: </b>" + Eval("ChequeDate")%><br />
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
                                                    <asp:LinkButton ID="lnkMoreDc" runat="server" OnClick="lnkMoreDc_Click" Visible="false">View All</asp:LinkButton>
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
</div>
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
<%--<ajaxCt:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender6" TargetControlID="UpdatePanel4"
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
</ajaxCt:UpdatePanelAnimationExtender>--%>
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
<ajaxCt:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
    PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LinkButton1" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
<ajaxCt:ModalPopupExtender ID="ModalPopUpDocNum" runat="server" TargetControlID="LnkBtn"
    PopupControlID="pnlBooks" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>
