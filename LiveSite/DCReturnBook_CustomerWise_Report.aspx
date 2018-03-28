<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DCReturnBook_CustomerWise_Report.aspx.cs" Inherits="DCReturnBook_CustomerWise_Report" Title="Order Return Book Report" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div> 
<asp:Panel ID="pnl1" CssClass="panelDetails" runat="server" Width="700px">

    <table>
    <tr>
        <td>
            <asp:Label ID="LblCC" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
            <font color="red">*</font>
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                        Width="80px" CssClass="inp-form" TabIndex="1" runat="server" 
                        AutoPostBack="true" ontextchanged="txtcustomer_TextChanged">
                    </asp:TextBox>
                    <div id="dvcust" class="divauto">
                    </div>
                    <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                        ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                        CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                        UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                    </ajaxCt:AutoCompleteExtender>
                    <asp:RequiredFieldValidator ID="RFVCust1" runat="server" ErrorMessage="Require Customer Code"
                        ValidationGroup="DCRBR" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>
                    <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" Width="350px"
                        runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td width="100px">
        <asp:Button ID="btngetRec" Style="float: left;" CssClass="submitbtn" runat="server"
            TabIndex="2" Text="Get Records" onclick="btngetRec_Click" ValidationGroup="DCRBR"  />
        </td>
     </tr>
    
    <tr>
    <td width="100px"></td>
   
    </tr>
    </table>
    
    
    
</asp:Panel>
     <br />
        <br />    
    <br />
    <cr:crystalreportviewer id="crystalreportviewer2" runat="server" 
            AutoDataBind="True" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="false" 
            haspagenavigationbuttons="true" hasrefreshbutton="true" 
            hassearchbutton="false" hastogglegrouptreebutton="false" height="50px" 
            width="350px" />

</div>
</asp:Content>
