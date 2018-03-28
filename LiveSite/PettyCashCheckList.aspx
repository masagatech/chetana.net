<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="PettyCashCheckList.aspx.cs" Inherits="PettyCashCheckList" Title="Petty Cash CheckList" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section-header">
  <div class="title">
    <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
    Petty Cash CheckList Report<a href="Campaigns.aspx" title="back to campaign list"></a>
  </div>
</div>
<div>
<asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Height="50px" Width="748px">
<table>
            <tr>
                <td>
                    <font color="red">*</font>
                    <asp:TextBox ID="txtFromDate"  Width="150px" CssClass="inp-form" TabIndex="1" Height="15px"
                        runat="server">
                    </asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtFromDate" />
                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtFromDate"
                        WatermarkText="From Date">
                    </ajaxCt:TextBoxWatermarkExtender>
                     <ajaxCt:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtFromDate"
          MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
          AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFromDate"
                        ErrorMessage="Enter From Date" ValidationGroup="ct1">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <font color="red">*</font>
                    <asp:TextBox ID="txtToDate" Width="150px" CssClass="inp-form" TabIndex="2" Height="15px"
                        runat="server">
                    </asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtToDate" />
                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtToDate"
                        WatermarkText="To Date">
                     </ajaxCt:TextBoxWatermarkExtender>
                      <ajaxCt:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtToDate"
          MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
          AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtToDate"
                        ErrorMessage="Enter ToDate" ValidationGroup="ct1">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="lblget" runat="server" Text="Get Data" TabIndex="3" 
                        Width="87px" ValidationGroup="ct1"
                        CssClass="submitbtn" onclick="lblget_Click"  />
                </td>
                
            </tr>
        </table>
</asp:Panel>
 <br />
 <br />   
<cr:crystalreportviewer id="PettyCashCheckListCR" runat="server" 
            AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="true" hasdrillupbutton="false" hasgotopagebutton="True" 
            haspagenavigationbuttons="True" hasrefreshbutton="true" 
            hassearchbutton="True" hastogglegrouptreebutton="True" hasviewlist="false" 
            haszoomfactorlist="false" height="1039px" width="773px" />
</div>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="ct1"
        runat="server" ID="valsum" />
</asp:Content>

