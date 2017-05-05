<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditInvoiceDeliverStatus.ascx.cs" Inherits="UserControls_ODC_receipt_EditInvoiceDeliverStatus" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<style type="text/css">
    .style1
    {
        width: 106px;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Invoice Delivery Status<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div style="float: right; width: 82%">
    <asp:Button ID="BtnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="Save"
        Width="80px"  ValidationGroup="ct" onclick="BtnSave_Click" />
</div>
</div>
<br />

<asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="280" Height="200px">
    <table>
        <tr>
            <td >
                <asp:Label ID="lblID" runat="server" Style="display: none"></asp:Label>
               <%-- <asp:Label ID="lblStatus" runat="server" Style="display: none"></asp:Label>--%>
                <asp:Label ID="lblInvoiceNo" runat="server" CssClass="lbl-form" Text="InvoiceNO"></asp:Label>
                <span style="color: Red">*</span>
            </td>
            <td>
                 <asp:TextBox ID="txtInvoive"  runat="server" TabIndex="1" Style="margin-left: 0px" AutoPostBack="true"
          CssClass="inp-form" Width="150px" ontextchanged="txtInvoive_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter InvoiceNo"
                    ValidationGroup="ct" Text="." ControlToValidate="txtInvoive"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Text="Customer Code"></asp:Label>
               
            </td>
            <td>
              <asp:TextBox ID="txtCustcode" Enabled="false" runat="server" TabIndex="2" Style="margin-left: 0px"
          CssClass="inp-form" Width="150px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
         <td >
                <asp:Label ID="lblCustCode" runat="server" CssClass="lbl-form" Text="Customer Name"></asp:Label>
               
            </td>
            <td>
              <asp:TextBox ID="txtCustName" Enabled="false" runat="server" TabIndex="3" Style="margin-left: 0px"
          CssClass="inp-form" Width="150px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblArea" runat="server" CssClass="lbl-form" Text="Area Name"></asp:Label>
               
            </td>
            <td>
                <asp:TextBox ID="txtArea" Enabled="false" CssClass="ddl-form" runat="server" Width="163px" Height="17px" Style="margin-left: 0px"
                    TabIndex="4" autocomplete="off"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblInvoiceDate" runat="server" CssClass="lbl-form" Text="Invoice Date"></asp:Label>
               
            </td>
            <td>
                <asp:TextBox ID="txtInvoiceDate" Enabled="false" CssClass="ddl-form" runat="server" Width="163px" Height="17px" Style="margin-left: 0px"
                    TabIndex="5" autocomplete="off"></asp:TextBox>
                
            </td>
        </tr>
         <tr>
            <td >
                <asp:Label ID="lblTotalAmount" runat="server" CssClass="lbl-form" Text="Total Amount"></asp:Label>
               
            </td>
            <td>
                <asp:TextBox ID="txtTotalAmount" Enabled="false" CssClass="ddl-form" runat="server" Width="163px" Height="17px" Style="margin-left: 0px"
                    TabIndex="4" autocomplete="off"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
        <td >
        <asp:Label ID="lblDStatus" runat="server" CssClass="lbl-form" Text="Delivery Status"></asp:Label>
        </td>
        <td>
        <asp:CheckBox ID="chkCheck" runat="server" TabIndex="6" CssClass="lbl-form"/>
        </td>
        </tr>
    </table>
</asp:Panel>
 <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ct"
    runat="server" ID="ss" />