<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ReceiptBookReport.aspx.cs" Inherits="ReceiptBookReport" Title="Receipt Book Report" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="section-header">
  <div class="title">
    <img src="Images/forms/ico-promotions.png" alt=" " />
    Print Receipt Books <a href="Campaigns.aspx" title=""></a>
  </div>
</div>
<div>
<asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Height="50px" Width="748px">
<table>
<tr>
        <td width="90px">
            <asp:Label ID="lblReceipt" runat="server" CssClass="lbl-form" Text="Receipt BookId"></asp:Label>
            <font color="red">*</font>
        </td>
        <td>
       
            <asp:TextBox ID="txtReceiptBook" CssClass="inp-form" TabIndex="1"
                Width="80px" runat="server" Height="15px" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Receipt Book ID separated by comma"
                ValidationGroup="Discount" ControlToValidate="txtReceiptBook">.</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txttoNo" CssClass="inp-form" TabIndex="2"
                Width="80px" runat="server" Height="15px" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Receipt Book ID separated by comma"
                ValidationGroup="Discount" ControlToValidate="txttoNo">.</asp:RequiredFieldValidator>
    </td>
    
    <td>
    <asp:Button ID="btnget" runat="server" Text="Get" width="80px" TabIndex="3" CssClass="submitbtn" 
            style="height: 26px" ValidationGroup="Discount" onclick="btnget_Click"/>
    <%--<input id="btnprint" type="BUTTON" value="Print this Page" style="display: none" onclick="printThis()"/> --%>
    </td>
    </tr>

</table>
</asp:Panel>
 <br />
 <br />   
<cr:crystalreportviewer id="ReceiptReport" runat="server" 
            AutoDataBind="true" displaygrouptree="False" enabledatabaselogonprompt="false" 
            enabledrilldown="true" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="True" 
            haspagenavigationbuttons="True" hasrefreshbutton="true" 
            hassearchbutton="True" hastogglegrouptreebutton="false" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" />
</div>
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
        runat="server" ID="valsum" />
</asp:Content>

