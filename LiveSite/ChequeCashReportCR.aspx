<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ChequeCashReportCR.aspx.cs" Inherits="ChequeCashReportCR" Title="ChequeCashReport" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Height="50px" Width="748px">
<table>
<tr>
        <td width="90px">
            <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Customer"></asp:Label>
            <font color="red">*</font>
        </td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
            <asp:TextBox ID="txtcustomerCRid" AutoPostBack="true" CssClass="inp-form" TabIndex="1"
                Width="160px" runat="server" Height="15px"></asp:TextBox>
              <div id="dvcust" class="divauto350">
                        </div>
            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomerCRid"
                UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
            </ajaxCt:AutoCompleteExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Customer"
                ValidationGroup="Discount" ControlToValidate="txtcustomerCRid">.</asp:RequiredFieldValidator>
            <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                runat="server" Width="500px"></asp:Label>
                </ContentTemplate>
                </asp:UpdatePanel>
        </td>
    
    <td>
    <asp:Button ID="btnget" runat="server" Text="Get" width="80px" TabIndex="1" CssClass="submitbtn" 
            style="height: 26px" onclick="btnget_Click"/>
    <input id="btnprint" type="BUTTON" value="Print this Page" style="display: none" onclick="printThis()"/> 
    </td>
    </tr>

</table>
</asp:Panel>
 <br />
 <br />   
<cr:crystalreportviewer id="crystalreportviewercheque" runat="server" 
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="false" 
            haspagenavigationbuttons="false" hasrefreshbutton="true" 
            hassearchbutton="false" hastogglegrouptreebutton="false" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" />
</div>
   <asp:validationsummary showmessagebox="true" showsummary="false" validationgroup="Discount"
    runat="server" id="ss" />
</asp:Content>

