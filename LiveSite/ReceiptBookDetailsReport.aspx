<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ReceiptBookDetailsReport.aspx.cs" Inherits="ReceiptBookDetailsReport" Title="Receipt Book Details" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 92px;
        }
        .style3
        {
            width: 113px;
        }
    .style4
    {
        width: 185px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section-header">
  <div class="title">
    <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
    Receipts Details Report<a href="Campaigns.aspx" title="back to campaign list"></a>
  </div>
</div>
<div>
<asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Height="50px" Width="748px">
<table>

     <tr>
            <td class="style4">
                <asp:RadioButton ID="rdorecnumwise" runat="server" Checked="True" GroupName="a" 
                    Text="Receipt Book Number" /></td>
                <td>
                    <asp:RadioButton ID="rdodatewise" runat="server" GroupName="a" 
                         Text="Date Issued" /></td>
            </tr>


<tr>
        <td class="style4">
            <asp:Label ID="lblActualReceipno" runat="server" CssClass="lbl-form" Text="Receipt Book No"></asp:Label>
            <font color="red">*</font>
        </td>
        <td>
       
            <asp:TextBox ID="txtReceiptBook" CssClass="inp-form" TabIndex="1" onkeypress="return CheckNumeric(event)"
                Width="160px" runat="server" Height="15px"></asp:TextBox>
      <%--      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Receipt BookID"
                ValidationGroup="Discount" ControlToValidate="txtReceiptBook">.</asp:RequiredFieldValidator>--%>
    
    <%--<input id="btnprint" type="BUTTON" value="Print this Page" style="display: none" onclick="printThis()"/> --%>
    </td>
    </tr>

 <tr>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="inp-form" 
                        TabIndex="2"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtFromDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="true"
                        AutoComplete="true" CultureName="en-GB" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                        TargetControlID="txtFromDate" />
                </td>
                <td class="style2">
                    <asp:Label ID="lblToDateCust" runat="server" CssClass="lbl-form" Text="To Date"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtTo" runat="server" CssClass="inp-form" 
                        TabIndex="3"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtTo" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="true"
                        AutoComplete="true" CultureName="en-GB" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="false"
                        TargetControlID="txtTo" />
                    <%-- <ajaxCt:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlToValidate="txtTo"
                                            ControlExtender="MaskedEditExtender2" CssClass="RedLabel" Display="Dynamic" EmptyValueBlurredText="*"
                                            InvalidValueBlurredMessage="Invalid Date" IsValidEmpty="False" ValidationExpression="^\d{2}/\d{2}/\d{4}$">  
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                                        </ajaxCt:MaskedEditValidator>--%>
                </td>
                
                <td>
                    <asp:Button ID="btnget" runat="server" CssClass="submitbtn" OnClick="btnget_Click"
                        TabIndex="4" Text="Get" ValidationGroup="Discount" Width="80px"  
                        style="height: 26px" />
                </td>
            </tr>


       
</table>
</asp:Panel>
 <br />
 <br />   
<cr:crystalreportviewer id="ReceiptDetailsReport" runat="server" 
            AutoDataBind="True" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="True" 
            haspagenavigationbuttons="True" hasrefreshbutton="True" 
            hassearchbutton="True" hastogglegrouptreebutton="false" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" />
</div>
  <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
        runat="server" ID="valsum" />
</asp:Content>

