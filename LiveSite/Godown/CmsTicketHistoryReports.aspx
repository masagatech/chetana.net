<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/NewChetana.master" CodeFile="CmsTicketHistoryReports.aspx.cs" Inherits="CmsTicketHistoryReports" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
--%>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="ContentTicketHistory" ContentPlaceHolderID=head runat="server">
    </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
 <div class="section-header">
        <div class="title" id="divtitle" runat="server" visible="false">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
               Call Report<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:updatepanel id="TktHistoryUp" runat="server">
        <Triggers>
        <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
        <ContentTemplate>
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="354px" Height="90px" Visible="false">
            <table id="tblReport" runat="server" visible="false">
                <tr>
                    <td>
                        <asp:Label ID="lblFromdateCust" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom" Format="dd/MM/yyyy"/>
                        <asp:Label ID="lblToDateCust" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label>
                        <font color="red">*</font>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTo" 
                            CssClass="inp-form" TabIndex="5" runat="server" ></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                            Format="dd/MM/yyyy"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
                            ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                        <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtTo" MaskType="Date"
                            Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false" AutoComplete="true"
                            CultureName="en-US" />
                    </td>
                </tr>
                <tr>
                <td>
                <asp:Label ID="lblTicktNoFrom" runat="server" Text="TicketNoFrom" CssClass="lbl-form"></asp:Label>
                <font color="red">*</font>
                </td>
                    <td>
                    <asp:TextBox ID="txtTicketNoFrom" runat="server" CssClass="inp-form" ></asp:TextBox>
                    <asp:Label ID="lblTicktNoTrom" runat="server" Text="TicketNoTo" CssClass="lbl-form"></asp:Label>
                    <font color="red">*</font>
                    <asp:TextBox ID="txtTicketNoTo" runat="server" CssClass="inp-form" ></asp:TextBox>
                    </td>
                
                </tr>
                <tr>
                <td>
                <asp:Label ID="lblCustName" runat="server" Text="Customer Name" CssClass="lbl-form"></asp:Label>
                <font color="red">*</font>
                </td>
                    <td>
                    <asp:TextBox ID="txtCutomerName" runat="server" onfocus="setfocus('customer');" autocomplete="off"
                            Width="80px" CssClass="inp-form" TabIndex="1" AutoPostBack="true"></asp:TextBox>
                            <div id="dvcust" class="divauto">
                        </div>
                    <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtCutomerName"
                            UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                          <asp:Label ID="Label1" runat="server" Text="Status" CssClass="lbl-form"></asp:Label>
                    <font color="red">*</font>
                        <asp:DropDownList ID="InqSatatus" runat="server" style="margin:0 0 0 22px; padding:0 9px 3px 0px;">                    
                        </asp:DropDownList>
                     </td>
                    
                </tr>
                
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" CssClass="submitbtn" TabIndex="8" runat="server" Text="Search"
                            Width="80px" onclick="Button1_Click1"/>
                        <asp:Button ID="cmdCancel" runat="server" CssClass="submitbtn"  TabIndex="8" Text="Cancel" 
                            Width="80px" onclick="cmdCancel_Click"/>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="AZone"
            runat="server" ID="ValidationSummary3" />
          <cr:crystalreportviewer id="crystalreportviewercheque" runat="server" 
           EnableDatabaseLogonPrompt="false" EnableDrillDown="true" EnableParameterPrompt="false"
            EnableTheming="false" EnableToolTips="true" HasDrillUpButton="True" HasGotoPageButton="True"
            HasPageNavigationButtons="True" HasRefreshButton="true" HasSearchButton="false"
            HasToggleGroupTreeButton="True"  HasZoomFactorList="false"
            Height="1039px" Width="773px" //>






    </div>
     </ContentTemplate></asp:updatepanel>  
</asp:Content>
