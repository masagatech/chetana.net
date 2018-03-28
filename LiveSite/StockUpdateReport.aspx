<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="StockUpdateReport.aspx.cs" Inherits="StockUpdateReport" Title="Stock Update Report" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
     <asp:Panel ID ="PnlStockUpd" CssClass="panelDetails" runat ="server">
        <table>
        <tr>
        <td width="100px">
        <asp:Label ID="LblBookcode" CssClass="lbl-form" runat="server" Text="Book Code"></asp:Label>
    </td>
        <td colspan = 3> 
        <asp:TextBox ID="Txtbkcode" autocomplete="off" TabIndex="1" CssClass="inp-form" runat="server"
         Width="240px" AutoPostBack="True"></asp:TextBox>
        <div id="divwidth" class="divauto">
        </div>
        <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
            ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
            ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="Txtbkcode"
            UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
        </ajaxCt:AutoCompleteExtender>
        <asp:RequiredFieldValidator ID="ReqBkcode5" runat="server" ErrorMessage="Enter Book Code"
            ValidationGroup="Stockr" ControlToValidate="Txtbkcode">.</asp:RequiredFieldValidator>       
            </td>       
       </tr>
       <%--<tr>
        <td>
            <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                      <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                    ValidationGroup="S" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
        </td>
        
        <td>
            <asp:Label ID="Label2" runat="server" Text="TO Date" CssClass="lbl-form"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="toDate" runat="server" TargetControlID="txttoDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To Date"
                    ValidationGroup="S" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
        </td>
     </tr>--%>
        </table>
        
        <asp:Button ID="btnget" runat="server" width="80px" Text="Get"  ValidationGroup="Stockr" CssClass="submitbtn"
          onclick="btnget_Click" style="height: 26px; display: none"  />
             
            <input id="btnprint" type="BUTTON" value="Print this Page" style="display: none" onclick="printThis()"/> 
            
    </asp:Panel>        
      <br />
        <br />    
    <br />
     
<cr:crystalreportviewer id="crystalreportviewer1" runat="server" 
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="false" 
            haspagenavigationbuttons="false" hasrefreshbutton="true" 
            hassearchbutton="false" hastogglegrouptreebutton="false" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" />
    </div>
    <asp:validationsummary showmessagebox="true" showsummary="false" validationgroup="Stockr"
    runat="server" id="ss" />

</asp:Content>

