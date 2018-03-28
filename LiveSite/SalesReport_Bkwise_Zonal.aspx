<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SalesReport_Bkwise_Zonal.aspx.cs" Inherits="SalesReport_Bkwise_Zonal" Title="Zonewise Book Sales" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    <%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section-header">

    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
     Zonewise Book Sales 
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
 </div>
    <div>
<asp:Panel ID ="pnldt" CssClass="panelDetails" runat ="server" Width="735px">
    <table>
    <tr>
        <td colspan="4">
            <asp:RadioButtonList ID="RdbtnSelect" runat="server" RepeatDirection="Horizontal"
                TabIndex="1" Width="180px" AutoPostBack="True" 
                OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged">
                <asp:ListItem Value="Bookwise" Text="Bookwise" Selected="True"></asp:ListItem>
                <asp:ListItem Value="BookTypewise" Text="BookTypewise"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <%--      <td width="80px" >
        </td>--%>
        <%--       <td width="30px" >
        </td>--%>
         
      <td width="70px">
            <asp:Label ID="LblSZ" runat="server" CssClass="lbl-form" Text="Super Zone"></asp:Label>
            <font color="red">*</font>
        </td>
        <td>
            <asp:DropDownList ID="DDLsuperzone" runat="server" ValidationGroup="bkwZonal"
               TabIndex="2" DataTextField="SuperZoneName" DataValueField="SuperZoneID" 
                Width="152px" onselectedindexchanged="DDLsuperzone_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
             <asp:RequiredFieldValidator ID="Rfvfsz" runat="server" ErrorMessage="Require SuperZone"
                    ValidationGroup="bkwZonal" ControlToValidate="DDLsuperzone">.</asp:RequiredFieldValidator>
         </td>
         <td >
                <asp:Label ID="LblZ" style="text-align:right" CssClass="lbl-form" runat="server" Text="Zone" Width="70px" ></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList  CssClass="ddl-form" ID="DDLzone" DataTextField="ZoneName" DataValueField="ZoneID" runat="server"
                           TabIndex="4" AutoPostBack="True" Width="200px" OnSelectedIndexChanged="DDLzone_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLsuperzone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        
    </tr>
    <tr>
    <td width="10px">
    </td>
    <td>
        <asp:Label ID="lblbkt" CssClass="lbl-form" runat="server" Text="Book type"></asp:Label>
    </td>
    <td colspan="4">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtbktype" CssClass="inp-form" AutoPostBack="true" autocomplete="off"
                    TabIndex="3" runat="server" Enabled="true"></asp:TextBox>
                <div id="dvbook" class="divauto">
                </div>
                <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtbktype"
                    UseContextKey="true" ContextKey="bktype" CompletionListElementID="dvbook">
                </ajaxCt:AutoCompleteExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
    </td>
    </tr>
    <tr>
    <td width="10px">
    </td>
        <td>
            <asp:Label ID="lblbk" CssClass="lbl-form" runat="server" Text="Book"></asp:Label>
        </td>
        <td colspan="4">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtbkcod" CssClass="inp-form" AutoPostBack="true"  autocomplete="off"
                       TabIndex="4" runat="server" Enabled="true"></asp:TextBox>
                    <div id="divwidth" class="divauto">
                    </div>
                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                        ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                        ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbkcod"
                        UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                    </ajaxCt:AutoCompleteExtender>
                </ContentTemplate>
            </asp:UpdatePanel>         
    </td> 
    </tr>
    <tr>
    <td width="10px">
    </td>
        <td width="70px">
            <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="5" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxct:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                    Format="dd/MM/yyyy" />
                <ajaxct:maskededitextender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rfvfdt" runat="server" ErrorMessage="Require From Date"
                    ValidationGroup="bkwZonal" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
        </td>
       <td width="15px"></td>
        <td width="70px">
            <asp:Label ID="Label2" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="6" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxct:calendarextender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                    Format="dd/MM/yyyy" />
                <ajaxct:maskededitextender ID="toDate" runat="server" TargetControlID="txttoDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rfvtdt" runat="server" ErrorMessage="Require To Date"
                    ValidationGroup="bkwZonal" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
        </td>
        <td>
             <asp:Button ID="btnget" runat="server" width="80px" Text="Get" CssClass="submitbtn" 
                TabIndex="7" ValidationGroup="bkwZonal"
                onclick="btnget_Click" style="height: 26px" />
        </td>
      </tr>
</table>
</asp:Panel>
<br />
<br />
<cr:crystalreportviewer id="CrptBkwiseZonal" runat="server" 
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" 
            enabletheming="false" hasdrillupbutton="True" hasgotopagebutton="True"  
            haspagenavigationbuttons="true" hasrefreshbutton="true" 
            hassearchbutton="True" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" 
            ShowAllPageIds="True"  />
            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="bkwZonal"
    runat="server" ID="ss" />
</div>

</asp:Content>
